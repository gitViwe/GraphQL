using System.ComponentModel.DataAnnotations;

namespace API.Model;

public class Hero
{
    [Key]
    public int Id { get; set; }
    public string Avatar { get; set; } = string.Empty;
    public string Alias { get; set; } = string.Empty;
    public Morality Morality { get; set; }
}


public enum Morality
{
    SuperHero,
    Hero,
    Neutral,
    Vilian,
    SuperVilian
}
