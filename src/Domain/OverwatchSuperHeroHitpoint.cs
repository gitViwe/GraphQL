using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchSuperHeroHitpoint
{
    [Key]
    public int Id { get; set; }
    public int Health { get; set; }
    public int Armor { get; set; }
    public int Shields { get; set; }
    public int Total { get; set; }
}
