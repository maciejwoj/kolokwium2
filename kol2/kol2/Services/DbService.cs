using kol2.Data;
using kol2.DTOs;
using kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Services;

public class DbService : IDbService
{

    private readonly ApdbContext _context;

    public DbService(ApdbContext context)
    {
        _context = context;
    }

    public async Task<CharacterDTO> GetCharacterData(int Id)
    {
        var character = await _context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitles)
            .FirstOrDefaultAsync(c => c.Id == Id);
        
        if (character == null)
        {
            return null!;
        }
        
        return new CharacterDTO
        {
            Id = character.Id,
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = character.Backpacks.Select(b => new BackpackDTO
            {
                ItemName = b.Item.Name,
                ItemWeight = b.Item.Weight,
                Amount = b.Amount
            }).ToList()
        };
    }

public async Task<List<BackpackDTO>> AddItems(int characterId, List<int> itemsList)
{

    var character = await _context.Characters
        .Include(c => c.Backpacks)
        .ThenInclude(b => b.Item) 
        .FirstOrDefaultAsync(c => c.Id == characterId);
    
    if (character == null)
    {
        return null!;
    }
    

    var items = await _context.Items.Where(i => itemsList.Contains(i.Id)).ToListAsync();
    

    if (items.Count != itemsList.Count)
    {
        throw new ArgumentException("some items do not exist");
    }
    
    int totalNewItemsWeight = items.Sum(i => i.Weight);

    if (character.CurrentWeight + totalNewItemsWeight > character.MaxWeight)
    {
        throw new InvalidOperationException("not enough space");
    }
    

    foreach (var item in items)
    {
        var backpackItem = character.Backpacks.FirstOrDefault(b => b.ItemId == item.Id);
        if (backpackItem == null)
        {
            backpackItem = new Backpack
            {
                CharacterId = characterId,
                ItemId = item.Id,
                Amount = 1
            };
            character.Backpacks.Add(backpackItem);
        }
        else
        {
            backpackItem.Amount++;
        }
        character.CurrentWeight += item.Weight;
    }
    
    await _context.SaveChangesAsync();
    
    return character.Backpacks.Select(b => new BackpackDTO
    {
        ItemName = b.Item.Name,
        ItemWeight = b.Item.Weight,
        Amount = b.Amount
    }).ToList();
}

}
