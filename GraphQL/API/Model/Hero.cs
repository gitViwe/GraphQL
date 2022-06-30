using System.ComponentModel.DataAnnotations;

namespace API.Model;

public class Hero
{
    [Key]
    public int Id { get; set; }
    public string Avatar { get; set; } = string.Empty;
    public string Alias { get; set; } = string.Empty;
    public ICollection<Elemental> Elementals { get; set; } = new List<Elemental>();
    public Morality Morality { get; set; }
    public DateTime CreatedAt => DateTime.Now;
}

public class Elemental
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public enum Morality
{
    SuperHero,
    Hero,
    Neutral,
    Vilian,
    SuperVilian
}
