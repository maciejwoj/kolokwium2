using kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kol2.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharacterController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharacter(int characterId)
    {
        var character = await _dbService.GetCharacterData(characterId);
        return Ok(character);
    }

    [HttpPost("{characterId}/backpacks")]
    public async Task<IActionResult> AddCharacterItems(int characterId, List<int> itemsList)
    {
        try
        {
            var backpackItems = await _dbService.AddItems(characterId, itemsList);
            return Ok(backpackItems);
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }
}