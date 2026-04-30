using Microsoft.UI.Xaml.Media;
using Windows.UI;

namespace LabsAuroraGallery.Design;

public static class SwatchCatalog
{
    public static IReadOnlyList<(string Label, string ColorKey)> SolidKeys { get; } =
    [
        ("Background", "BgColor"),
        ("Surface", "SurfaceColor"),
        ("SurfaceElevated", "SurfaceElevatedColor"),
        ("Text", "TextColor"),
        ("TextMuted", "TextMutedColor"),
        ("Accent", "AccentColor"),
        ("AccentStrong", "AccentStrongColor"),
        ("AccentMuted", "AccentMutedColor"),
        ("Border", "BorderColor"),
        ("HoverSurface", "HoverColor"),
        ("BubbleMine", "BubbleMineColor"),
        ("DestructiveStrong", "DestructiveStrongColor"),
        ("PresenceOnline", "PresenceOnlineColor"),
        ("PresenceAway", "PresenceAwayColor"),
        ("Avatar 0", "AvatarTone0Color"),
        ("Avatar 1", "AvatarTone1Color"),
        ("Avatar 2", "AvatarTone2Color"),
        ("Avatar 3", "AvatarTone3Color"),
        ("Avatar 4", "AvatarTone4Color"),
        ("Avatar 5", "AvatarTone5Color"),
    ];

    public static IEnumerable<SwatchItem> Resolve(Microsoft.UI.Xaml.ResourceDictionary lookup)
    {
        foreach (var (label, key) in SolidKeys)
        {
            if (!lookup.ContainsKey(key))
            {
                continue;
            }

            var raw = lookup[key];
            Color color = raw switch
            {
                Color c => c,
                SolidColorBrush scb when scb.Color != default => scb.Color,
                _ => default,
            };

            if (color == default)
            {
                continue;
            }

            var hex =
                $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            yield return new SwatchItem
            {
                TokenLabel = label,
                ResourceKey = key,
                HexLabel = hex,
                Tint = new SolidColorBrush(color),
            };
        }
    }
}
