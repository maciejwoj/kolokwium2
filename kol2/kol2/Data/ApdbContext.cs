using kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Data;

public class ApdbContext : DbContext
{
    protected ApdbContext()
    {
    }

    public ApdbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Item> Items { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);


    modelBuilder.Entity<Backpack>()
        .HasKey(b => new { b.CharacterId, b.ItemId });
    modelBuilder.Entity<CharacterTitle>()
        .HasKey(ct => new { ct.CharacterId, ct.TitleId });


    modelBuilder.Entity<Character>().HasData(
        new Character
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            CurrentWeight = 10,
            MaxWeight = 100
        },
        new Character
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Smith",
            CurrentWeight = 20,
            MaxWeight = 120
        }
    );


    modelBuilder.Entity<Item>().HasData(
        new Item
        {
            Id = 1,
            Name = "Sword",
            Weight = 10
        },
        new Item
        {
            Id = 2,
            Name = "Shield",
            Weight = 15
        }
    );

 
    modelBuilder.Entity<Title>().HasData(
        new Title
        {
            Id = 1,
            Name = "Warrior"
        },
        new Title
        {
            Id = 2,
            Name = "Mage"
        }
    );


    modelBuilder.Entity<Backpack>().HasData(
        new Backpack
        {
            CharacterId = 1,
            ItemId = 1,
            Amount = 1
        },
        new Backpack
        {
            CharacterId = 2,
            ItemId = 2,
            Amount = 2
        }
    );

    modelBuilder.Entity<CharacterTitle>().HasData(
        new CharacterTitle
        {
            CharacterId = 1,
            TitleId = 1,
            AcquiredAt = DateTime.Now.AddDays(-10)
        },
        new CharacterTitle
        {
            CharacterId = 2,
            TitleId = 2,
            AcquiredAt = DateTime.Now.AddDays(-5)
        }
    );
}


}