using apbd_R.DTOs;

namespace apbd_R.Services;

public interface IDbService         
{
    Task<CharacterResponseDto?> GetCharacterAsync(int characterId);
    
    Task AddItemsToBackpackAsync(int characterId, IReadOnlyCollection<int> itemIds);
}

