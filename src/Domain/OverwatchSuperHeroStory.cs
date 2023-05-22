using System.ComponentModel.DataAnnotations;

namespace Domain;

public class OverwatchSuperHeroStory
{
    [Key]
    public int Id { get; set; }
    public string Summary { get; set; } = string.Empty;
    public OverwatchMedia Media { get; set; } = new();
    public virtual ICollection<OverwatchSuperHeroChapter> Chapters { get; set; } = new HashSet<OverwatchSuperHeroChapter>();
}
