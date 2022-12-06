using System.ComponentModel.DataAnnotations;

namespace Domain;

public class SuperHero
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Alias { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
}