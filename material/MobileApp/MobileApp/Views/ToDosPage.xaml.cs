using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDosPage : ContentPage
    {
        public ObservableCollection<object> ToDos { get; set; } = new ObservableCollection<object>();

        public ToDosPage()
        {
            Title = "My To Dos";

            InitializeComponent();

            ToDos.Add("Buy cookies");
            ToDos.Add("test 2");

            BindableLayout.SetItemsSource(ItemsContainer, ToDos);

            Root.Children.Add(new Button { 
                Text = "Add", 
                Command = new Command(() => AddItem()),
                //VerticalOptions = 
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ToDos.Add(DateTime.Now);
        }

        private void AddItem()
        {
            ToDos.Add(DateTime.Now);
        }
    }
}