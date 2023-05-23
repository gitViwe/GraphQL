using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchSuperHeroChapter
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Picture { get; set; } = string.Empty;
}
