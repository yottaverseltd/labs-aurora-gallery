# labs-aurora-gallery

Design tokens that survive contact with code.

Live: https://yottaverseltd.github.io/labs-aurora-gallery/ (requires GitHub Actions Pages enabled once under Settings).

## Build

```bash
dotnet restore
dotnet build LabsAuroraGallery/LabsAuroraGallery.csproj -c Release -f net9.0-browserwasm
dotnet build LabsAuroraGallery/LabsAuroraGallery.csproj -c Release -f net9.0-desktop
```

## Layout

- `Styles/Tokens.xaml` theme colors, spacing scale, radii, type sizes.
- `Styles/Typography.xaml` named text styles.
- `Styles/Motion.xaml` canonical durations and eases.
- `Styles/Aurora.xaml` decorative gradients (non-text chrome).
- `Styles/GalleryControls.xaml` control specimen styles only.
