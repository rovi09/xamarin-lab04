using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageFlyout : ContentPage
    {
        public ListView ListView;

        public MainPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MainPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainPageFlyoutMenuItem> MenuItems { get; set; }

            public MainPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainPageFlyoutMenuItem>(new[]
                {
                    new MainPageFlyoutMenuItem { Id = 0, Title = "Hello Wordl", TargetType=typeof(HelloWorldPage) } ,
                    new MainPageFlyoutMenuItem { Id = 1, Title = "Xamarin Controls", TargetType=typeof(ControlsPage) },
                    new MainPageFlyoutMenuItem { Id = 2, Title = "My ToDos", TargetType=typeof(ToDosPage) },
                    new MainPageFlyoutMenuItem { Id = 2, Title = "Blogs", TargetType=typeof(BlogsPage) }
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