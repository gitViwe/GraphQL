using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchCombatMap
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Screenshot { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public virtual ICollection<OverwatchMode> Gamemodes { get; set; } = new HashSet<OverwatchMode>();
}
