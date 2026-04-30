using System.Collections.Generic;
using LabsAuroraGallery.Design;
using LabsAuroraGallery.Motion;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;

namespace LabsAuroraGallery;

public sealed partial class MainPage : Page
{
    private bool _lightPalette;

    private readonly DispatcherQueue _dispatcher = DispatcherQueue.GetForCurrentThread();

    private static readonly (string Title, string Initials, string BrushKey)[] s_avatarToneKeys =
    [
        ("Jordan Lee", "JL", "AvatarTone0Brush"),
        ("Sam Rivera", "SR", "AvatarTone1Brush"),
        ("Priya Patel", "PP", "AvatarTone2Brush"),
        ("Noah Kim", "NK", "AvatarTone3Brush"),
        ("Casey Jordan", "CJ", "AvatarTone4Brush"),
    ];

    public MainPage()
    {
        InitializeComponent();

        Loaded += (_, _) =>
        {
            RefreshBindings();
            ShowSection(0);
        };

        ActualThemeChanged += (_, _) =>
        {
            RefreshBindings();
            ResetMotionTransform();
        };

        ReducedMotion.Changed += (_, _) =>
            _dispatcher.TryEnqueue(RefreshBindings);
    }

    private void RefreshBindings()
    {
        var resources = Application.Current!.Resources;

        SwatchGrid.ItemsSource = new List<SwatchItem>(SwatchCatalog.Resolve(resources));
        AvatarList.ItemsSource = BuildAvatarSpecs(resources);

        ReducedMotionHintText.Text =
            ReducedMotion.IsReducedMotion
                ? "Reduced motion prefers instant transitions."
                : "Motion timings follow Tokens until the OS clamps them.";
    }

    private static List<AvatarRowSpec> BuildAvatarSpecs(ResourceDictionary lookup)
    {
        var rows = new List<AvatarRowSpec>();
        foreach (var (title, initials, brushKey) in s_avatarToneKeys)
        {
            if (!lookup.ContainsKey(brushKey) || lookup[brushKey] is not SolidColorBrush tone)
            {
                continue;
            }

            rows.Add(new AvatarRowSpec
            {
                Title = title,
                ShortLabel = initials,
                ToneBrushKey = brushKey,
                Tint = new SolidColorBrush(tone.Color),
            });
        }

        return rows;
    }

    private void OnSectionNavChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ListBox lb)
        {
            ShowSection(Math.Max(lb.SelectedIndex, 0));
        }
    }

    private void ShowSection(int index)
    {
        SectionTypography.Visibility = index == 0 ? Visibility.Visible : Visibility.Collapsed;
        SectionColor.Visibility = index == 1 ? Visibility.Visible : Visibility.Collapsed;
        SectionSpacing.Visibility = index == 2 ? Visibility.Visible : Visibility.Collapsed;
        SectionMotion.Visibility = index == 3 ? Visibility.Visible : Visibility.Collapsed;
        SectionControls.Visibility = index == 4 ? Visibility.Visible : Visibility.Collapsed;
    }

    private void ToggleTheme_Click(object sender, RoutedEventArgs e)
    {
        _lightPalette = !_lightPalette;
        Application.Current!.RequestedTheme = _lightPalette
            ? ApplicationTheme.Light
            : ApplicationTheme.Dark;
    }

    private void Anim120_Click(object sender, RoutedEventArgs e) =>
        RestartStory(MotionPop120Story);

    private void Anim200_Click(object sender, RoutedEventArgs e) =>
        RestartStory(MotionPop200Story);

    private void Anim320_Click(object sender, RoutedEventArgs e) =>
        RestartStory(MotionPop320Story);

    private void RestartStory(Storyboard storyboard)
    {
        MotionPop120Story.Stop();
        MotionPop200Story.Stop();
        MotionPop320Story.Stop();

        MotionCardTranslate.Y = 0;

        storyboard.Begin();
    }

    private void MotionPop_Completed(object? sender, object e)
    {
        MotionCardTranslate.Y = 0;
        MotionPop120Story.Stop();
        MotionPop200Story.Stop();
        MotionPop320Story.Stop();
    }

    private void ResetMotionTransform()
    {
        MotionCardTranslate.Y = 0;
        MotionPop120Story.Stop();
        MotionPop200Story.Stop();
        MotionPop320Story.Stop();
    }

    private async void ShowDialogStub_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new ContentDialog
        {
            Title = "Dialog stub",
            PrimaryButtonText = "Close",
            DefaultButton = ContentDialogButton.Primary,
            XamlRoot = XamlRoot,
        };

        if (Application.Current.Resources["SurfaceElevatedBrush"] is Brush surface)
        {
            dialog.Background = surface;
        }

        if (Application.Current.Resources["BorderBrush"] is Brush edge)
        {
            dialog.BorderBrush = edge;
        }

        var body = new TextBlock
        {
            Text =
                "This dialog inherits surface and border brushes from Tokens. No extra chrome colors are introduced here.",
            TextWrapping = TextWrapping.Wrap,
            Style = (Style)Application.Current.Resources["BodyText"],
        };

        dialog.Content = body;

        await dialog.ShowAsync();
    }
}
