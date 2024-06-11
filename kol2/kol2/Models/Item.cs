using System.ComponentModel.DataAnnotations;

namespace kol2.Models;

public class Item
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    [Required]
    public String Name { get; set; } = string.Empty;
    public int Weight { get; set; }
    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
}