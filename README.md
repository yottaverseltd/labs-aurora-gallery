# labs-aurora-gallery

## Try it on GitHub Pages

**Live:** https://yottaverseltd.github.io/labs-aurora-gallery/

**Prerequisites:** none. **`PrimaryFontFamily`** resolves **system UI fonts first** (`system-ui`, **Segoe UI**, then **Inter**/generic sans-serif) so Skia WASM text stays readable on GitHub Pages. Optional **Inter** weights load via **`@import` from Google Fonts** in `WasmCSS/Fonts.css` (HTTPS subsets; unaffected by `WasmShellWebAppBasePath`). Desktop builds ship from tagged **`v*`** releases only (no APK in this repo).

**Troubleshooting:** If the live URL returns 404, open **Settings → Pages → Build and deployment** and set **Source** to **GitHub Actions**, then re-run the latest **deploy-pages** workflow.

**Source:** https://github.com/yottaverseltd/labs-aurora-gallery

Design-token and motion **gallery** for Uno: colors, type ramp, spacing, radii, motion curves, and control specimens in one scrollable lab.

## Downloads

### Desktop (Windows)

Zip builds attach to **[GitHub Releases](https://github.com/yottaverseltd/labs-aurora-gallery/releases)** when you push a version tag (`v*`). The **`release-desktop`** workflow publishes **`labs-aurora-gallery-net9.0-desktop.zip`** from **`net9.0-desktop`**.

### Mobile / APK

Not shipped from this repo. **`LabsAuroraGallery.csproj`** targets **`net9.0-browserwasm`** and **`net9.0-desktop`** only. On phones and tablets, use the **Live** WASM link in the browser.

## What it is

A reference surface for Aurora-style tokens before they land in production apps. No backend. No analytics.

Suggested repo topics: `uno-platform`, `dotnet`, `wasm`, `skia`, `design-system`

## Run locally

```powershell
dotnet workload install wasm-tools
dotnet restore
dotnet build LabsAuroraGallery/LabsAuroraGallery.csproj -c Release -f net9.0-desktop
dotnet run --project LabsAuroraGallery/LabsAuroraGallery.csproj -f net9.0-desktop
```

Publish WASM (same base path as Pages):

```powershell
dotnet publish LabsAuroraGallery/LabsAuroraGallery.csproj -c Release -f net9.0-browserwasm -p:WasmShellWebAppBasePath=/labs-aurora-gallery/
```

## Layout

- `Styles/Tokens.xaml` theme colors, spacing, radii, type sizes.
- `Styles/Typography.xaml` named text styles.
- `Styles/Motion.xaml` canonical durations and eases.
- `Styles/Aurora.xaml` decorative gradients (non-text chrome).
- `Styles/GalleryControls.xaml` control specimen styles only.

## CI and hosting

- **CI:** [.github/workflows/ci.yml](.github/workflows/ci.yml)
- **Pages:** [.github/workflows/deploy-pages.yml](.github/workflows/deploy-pages.yml) uses `WasmShellWebAppBasePath=/labs-aurora-gallery/` and `.nojekyll` for `_framework`.

## License

MIT. See `LICENSE`.
