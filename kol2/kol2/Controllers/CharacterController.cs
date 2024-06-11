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

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetCharacter(int Id)
    {
        var character = await _dbService.GetCharacterData(Id);
        if (character == null)
            return NotFound();
        return Ok(character);
    }
}