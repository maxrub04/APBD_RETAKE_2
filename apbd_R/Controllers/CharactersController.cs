using apbd_R.DTOs;
using apbd_R.Services;      
using Microsoft.AspNetCore.Mvc;

namespace apbd_R.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;         
    public CharactersController(IDbService dbService) => _dbService = dbService;

    // GET api/characters/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        CharacterResponseDto? dto = await _dbService.GetCharacterAsync(id);
        return dto is null ? NotFound() : Ok(dto);
    }

    // POST api/characters/{id}/backpacks
    [HttpPost("{id:int}/backpacks")]
    public async Task<IActionResult> AddItems(
        int id, 
        [FromBody] AddItemsRequestDto request)  
    {
        if (!ModelState.IsValid)  
        {
            return BadRequest(ModelState);
        }
        if (request.ItemIds is null) return BadRequest("Request body must be an array of item ids");

        try
        {
            await _dbService.AddItemsToBackpackAsync(id, request.ItemIds);
            return Created($"api/characters/{id}", null);
        }
        catch (KeyNotFoundException ex)        { return NotFound(ex.Message); }
        catch (InvalidOperationException ex)   { return BadRequest(ex.Message); }
        catch (ArgumentException ex)           { return BadRequest(ex.Message); }
    }
}