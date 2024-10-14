using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OCR
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this); // Load the XAML components
        }

        // public static void Main(string[] args)
        // {
        //     BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        // }

        private static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace(); // Log to console
        }
    }
}
