using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Car.Shop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuFlyout : ContentPage
    {
        public ListView ListView;

        public MainMenuFlyout()
        {
           

            BindingContext = new MainMenuFlyoutViewModel();
           
        }

        class MainMenuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMenuFlyoutMenuItem> MenuItems { get; set; }
            
            public MainMenuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainMenuFlyoutMenuItem>(new[]
                {
                    new MainMenuFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new MainMenuFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new MainMenuFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new MainMenuFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new MainMenuFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}