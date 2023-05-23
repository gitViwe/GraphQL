using Domain;
using gitViwe.Shared.Model;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace Infrastructure.Service;

internal class OverwatchDataService
{
    private const string HERO_JSON_FILE = "sample-data/overfast_api/heroes.json";
    private const string HERO_DETAIL_PATH = "sample-data/overfast_api/hero_detail";
    private const string HERO_ROLE_JSON_FILE = "sample-data/overfast_api/hero_role/roles.json";
    private const string GAME_MODE_JSON_FILE = "sample-data/overfast_api/game_mode/gamemodes.json";
    private const string GAME_MAP_JSON_FILE = "sample-data/overfast_api/game_map/maps.json";
    private readonly IWebHostEnvironment _environment;

    public OverwatchDataService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    internal async Task<IEnumerable<OverwatchHero>> GetOverwatchHeroesAsync(CancellationToken cancellationToken = default)
    {
        var filePath = System.IO.Path.Combine(_environment.WebRootPath, HERO_JSON_FILE);
        var jsonString = await File.ReadAllTextAsync(filePath, cancellationToken);
        var output = JsonSerializer.Deserialize<IEnumerable<OverwatchHero>>(jsonString);
        return output ?? Enumerable.Empty<OverwatchHero>();
    }

    internal IEnumerable<OverwatchHeroDetail> GetOverwatchHeroDetails()
    {
        var folderPath = System.IO.Path.Combine(_environment.WebRootPath, HERO_DETAIL_PATH);

        foreach (string filePath in Directory.GetFiles(folderPath))
        {
            var jsonString = File.ReadAllText(filePath);
            var detail = JsonSerializer.Deserialize<OverwatchHeroDetail>(jsonString);
            if (detail is null) continue;
            yield return detail;
        }
    }

    internal async Task<IEnumerable<OverwatchHeroRole>> GetOverwatchHeroRolesAsync(CancellationToken cancellationToken = default)
    {
        var filePath = System.IO.Path.Combine(_environment.WebRootPath, HERO_ROLE_JSON_FILE);
        var jsonString = await File.ReadAllTextAsync(filePath, cancellationToken);
        var output = JsonSerializer.Deserialize<IEnumerable<OverwatchHeroRole>>(jsonString);
        return output ?? Enumerable.Empty<OverwatchHeroRole>();
    }

    internal async Task<IEnumerable<OverwatchGameMode>> GetOverwatchGameModesAsync(CancellationToken cancellationToken = default)
    {
        var filePath = System.IO.Path.Combine(_environment.WebRootPath, GAME_MODE_JSON_FILE);
        var jsonString = await File.ReadAllTextAsync(filePath, cancellationToken);
        var output = JsonSerializer.Deserialize<IEnumerable<OverwatchGameMode>>(jsonString);
        return output ?? Enumerable.Empty<OverwatchGameMode>();
    }

    internal async Task<IEnumerable<OverwatchMap>> GetOverwatchMapsAsync(CancellationToken cancellationToken = default)
    {
        var filePath = System.IO.Path.Combine(_environment.WebRootPath, GAME_MAP_JSON_FILE);
        var jsonString = await File.ReadAllTextAsync(filePath, cancellationToken);
        var output = JsonSerializer.Deserialize<IEnumerable<OverwatchMap>>(jsonString);
        return output ?? Enumerable.Empty<OverwatchMap>();
    }
}

internal static class Mapper
{
    internal static OverwatchMode ToOverwatchMode(this OverwatchGameMode mode)
    {
        return new OverwatchMode
        {
            Description = mode.Description,
            Icon = mode.Icon,
            Key = mode.Key,
            Name = mode.Name,
            Screenshot = mode.Screenshot,
        };
    }
    internal static OverwatchCombatMap ToOverwatchCombatMap(this OverwatchMap map, IEnumerable<OverwatchMode> modes)
    {
        return new OverwatchCombatMap
        {
            CountryCode = map.CountryCode ?? string.Empty,
            Location = map.Location,
            Name = map.Name,
            Screenshot = map.Screenshot,
            Gamemodes = modes.Where(x => map.Gamemodes.Contains(x.Key)).ToList()
        };
    }
    internal static OverwatchSuperHeroRole ToOverwatchSuperHeroRole(this OverwatchHeroRole role)
    {
        return new OverwatchSuperHeroRole
        {
            Description = role.Description,
            Icon = role.Icon,
            Key = role.Key,
            Name = role.Name,
        };
    }
    internal static OverwatchSuperHero ToOverwatchSuperHero(this OverwatchHero hero)
    {
        return new OverwatchSuperHero
        {
            Key = hero.Key,
            Name = hero.Name,
            Portrait = hero.Portrait,
        };
    }
    internal static OverwatchSuperHero AddDetail(this OverwatchSuperHero hero, IEnumerable<OverwatchHeroDetail> details, IEnumerable<OverwatchSuperHeroRole> roles)
    {
        var detail = details.FirstOrDefault(x => x.Name == hero.Name);
        if (detail is null) return hero;

        hero.Detail.Abilities = detail.Abilities.Select(x => new OverwatchSuperHeroAbility
        {
            Description = x.Description,
            Icon = x.Icon,
            Name = x.Name,
            Video = new()
            {
                Thumbnail = x.Video.Thumbnail,
                Link = new()
                {
                    Mp4 = x.Video.Link.Mp4,
                    Webm = x.Video.Link.Webm,
                },
            },
        }).ToList();

        hero.Detail.Description = detail.Description;

        hero.Detail.Hitpoints = new()
        {
            Armor = detail.Hitpoints.Armor,
            Health = detail.Hitpoints.Health,
            Shields = detail.Hitpoints.Shields,
            Total = detail.Hitpoints.Total,
        };

        hero.Detail.Location = detail.Location;
        hero.Detail.Name = detail.Name;
        hero.Detail.Portrait = detail.Portrait;

        var role = roles.FirstOrDefault(x => x.Key == detail.Role);
        if (role is not null) hero.Detail.Role = role;

        hero.Detail.Story = new()
        {
            Chapters = detail.Story.Chapters.Select(x => new OverwatchSuperHeroChapter
            {
                Content = x.Content,
                Picture = x.Picture,
                Title = x.Title,
            }).ToList(),
            Media = new()
            {
                Link = detail.Story.Media?.Link ?? string.Empty,
                Type = detail.Story.Media?.Type ?? string.Empty,
            },
            Summary = detail.Story.Summary,
        };

        return hero;
    }
}