using QuickPad.Mvvm.Commands;
using QuickPad.UI.Helpers;
using QuickPad.UI.Theme;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace QuickPad.UI.Controls.Settings
{
    public sealed partial class Advanced : Page
    {
        public IVisualThemeSelector VtSelector => VisualThemeSelector.Current;

        public WindowsSettingsViewModel Settings { get; } = App.Settings;

        public QuickPadCommands<StorageFile, IRandomAccessStream> Commands => App.Commands;

        public Advanced()
        {
            this.InitializeComponent();
            DataContext = Settings;
        }
    }
}