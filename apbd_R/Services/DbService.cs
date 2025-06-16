using apbd_R.Data;         
using apbd_R.DTOs;
using apbd_R.Models;   
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Extensions.Logging;

namespace apbd_R.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    private readonly ILogger<DbService> _logger;

    public DbService(DatabaseContext context, ILogger<DbService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task<CharacterResponseDto?> GetCharacterAsync(int characterId)
    {
        return await _context.Characters
            .Include(c => c.Backpacks).ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitles).ThenInclude(ct => ct.Title)
            .AsNoTracking()
            .Where(c => c.CharacterId == characterId)
            .Select(c => new CharacterResponseDto
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                CurrentWeight = c.CurrentWeight,
                MaxWeight = c.MaxWeight,
                BackpackItems = c.Backpacks.Select(b => new BackpackItemDto
                {
                    ItemName = b.Item.Name,
                    ItemWeight = b.Item.Weight,
                    Amount = b.Amount
                }).ToList(),
                Titles = c.CharacterTitles
                    .OrderByDescending(t => t.AcquiredAt)
                    .Select(t => new TitleDto
                    {
                        Title = t.Title.Name,
                        AcquiredAt = t.AcquiredAt
                    }).ToList()
            })
            .FirstOrDefaultAsync();
    }
    
    public async Task AddItemsToBackpackAsync(int characterId, IReadOnlyCollection<int> itemIds)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
        
        try
        {
            var character = await _context.Characters
                .Include(c => c.Backpacks)
                .ThenInclude(b => b.Item)
                .FirstOrDefaultAsync(c => c.CharacterId == characterId)
                ?? throw new KeyNotFoundException($"Character with id {characterId} not found");
            
            var existingItemIds = await _context.Items
                .Where(i => itemIds.Contains(i.ItemId))
                .Select(i => i.ItemId)
                .ToListAsync();

            if (existingItemIds.Count != itemIds.Count)
            {
                var missingIds = itemIds.Except(existingItemIds);
                throw new KeyNotFoundException($"Items not found: {string.Join(", ", missingIds)}");
            }
            
            var items = await _context.Items
                .Where(i => itemIds.Contains(i.ItemId))
                .ToDictionaryAsync(i => i.ItemId, i => i.Weight);

            var addedWeight = itemIds.Sum(id => items[id]);
            
            if (character.CurrentWeight + addedWeight > character.MaxWeight)
            {
                throw new InvalidOperationException(
                    $"Cannot add {addedWeight} weight. Current: {character.CurrentWeight}, Max: {character.MaxWeight}");
            }
            
            foreach (var itemId in itemIds)
            {
                var existingItem = character.Backpacks.FirstOrDefault(b => b.ItemId == itemId);
                
                if (existingItem != null)
                {
                    existingItem.Amount++;
                }
                else
                {
                    character.Backpacks.Add(new Backpack
                    {
                        CharacterId = characterId,
                        ItemId = itemId,
                        Amount = 1
                    });
                }
                
                character.CurrentWeight += items[itemId];
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while adding items to backpack");
            await transaction.RollbackAsync();
            throw;
        }
    }
}