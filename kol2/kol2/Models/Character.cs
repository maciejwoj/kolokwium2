﻿using System.ComponentModel.DataAnnotations;

namespace kol2.Models;

public class Character
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    [Required]
    public String FirstName { get; set; } = string.Empty;
    [MaxLength(120)]
    [Required]
    public String LastName { get; set; } = string.Empty;

    public int CurrentWeight { get; set; }
    
    public int MaxWeight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
    public ICollection<CharacterTitle> CharacterTitles { get; set; } = new HashSet<CharacterTitle>();
}