using kol2.DTOs;

namespace kol2.Services;

public interface IDbService
{
    Task<CharacterDTO> GetCharacterData(int characterId);
    Task<List<BackpackDTO>> AddItems(int characterId, List<int> itemIds);
}