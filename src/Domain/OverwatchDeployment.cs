using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchDeployment
{
    [Key]
    public int Id { get; set; }
    public int CombatMapId { get; set; }
    public int GameModeId { get; set; }
    public int SuperHeroId { get; set; }
    public DateTime DeployedAt { get; init; }
    public string DeployedBy { get; init; } = string.Empty;
}
