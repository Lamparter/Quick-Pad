using QuickPad.Mvvm.Models;
using QuickPad.Mvvm.ViewModels;
using QuickPad.UI.Helpers;
using QuickPad.UI.Theme;
using System.ComponentModel;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace QuickPad.UI.Controls
{
    public sealed partial class StatusBar : UserControl
    {
        public IVisualThemeSelector VtSelector => VisualThemeSelector.Current;

        public WindowsSettingsViewModel Settings => App.Settings;

        public DocumentViewModel<StorageFile, IRandomAccessStream> ViewModel
        {
            get => DataContext as DocumentViewModel<StorageFile, IRandomAccessStream>;
            set
            {
                if (value == null || DataContext == value) return;

                if (DataContext is DocumentViewModel<StorageFile, IRandomAccessStream> documentViewModel)
                {
                    documentViewModel.PropertyChanged -= DocumentViewModelOnPropertyChanged;
                }

                DataContext = value;

                value.PropertyChanged += DocumentViewModelOnPropertyChanged;
            }
        }

        public DocumentModel<StorageFile, IRandomAccessStream> ViewModelDocument => ViewModel.Document;

        private void DocumentViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(DocumentViewModel<StorageFile, IRandomAccessStream>.CurrentLine):
                case nameof(DocumentViewModel<StorageFile, IRandomAccessStream>.CurrentColumn):
                    Bindings.Update();
                    break;
            }
        }

        public StatusBar()
        {
            this.InitializeComponent();

            Settings.PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(WindowsSettingsViewModel.StatusText):
                    Bindings.Update();
                    break;
            }
        }
    }
}