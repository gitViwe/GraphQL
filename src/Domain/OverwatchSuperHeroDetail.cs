using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchSuperHeroDetail
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Portrait { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    public OverwatchSuperHeroHitpoint Hitpoints { get; set; } = new();
    public OverwatchSuperHeroStory Story { get; set; } = new();
    public OverwatchSuperHeroRole Role { get; set; } = new();
    public virtual ICollection<OverwatchSuperHeroAbility> Abilities { get; set; } = new HashSet<OverwatchSuperHeroAbility>();
}
