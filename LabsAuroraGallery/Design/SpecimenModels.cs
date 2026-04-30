namespace LabsAuroraGallery.Design;

public sealed class SwatchItem
{
    public string TokenLabel { get; init; } = "";

    public string ResourceKey { get; init; } = "";

    public string HexLabel { get; init; } = "";

    public Microsoft.UI.Xaml.Media.Brush Tint { get; init; } = null!;
}

public sealed class AvatarRowSpec
{
    public string Title { get; init; } = "";

    public string ShortLabel { get; init; } = "";

    public string ToneBrushKey { get; init; } = "";

    public Microsoft.UI.Xaml.Media.SolidColorBrush Tint { get; init; } = null!;
}
