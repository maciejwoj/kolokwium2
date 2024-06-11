using System.ComponentModel.DataAnnotations;

namespace kol2.Models;


public class Title
{
    [Key]
    public int Id { get; set; }
    public String Name { get; set; } = string.Empty;
    public ICollection<CharacterTitle> CharacterTitles { get; set; } = new HashSet<CharacterTitle>();
}