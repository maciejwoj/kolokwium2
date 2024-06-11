using kol2.DTOs;

namespace kol2.Services;

public class DbService : IDbService
{
    public Task<CharacterDTO> GetCharacterData(int characterId)
    {
        throw new NotImplementedException();
    }

    public Task<List<BackpackDTO>> AddItems(int characterId, List<int> itemIds)
    {
        throw new NotImplementedException();
    }
}