namespace kol2.DTOs;

public class CharacterDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public List<BackpackDTO> BackpackItems { get; set; } = new List<BackpackDTO>();
}
public class BackpackDTO
{
    public string ItemName { get; set; } = string.Empty;
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}