﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDosPage : ContentPage
    {
        public ObservableCollection<ToDoItem> ToDos { get; set; } = new ObservableCollection<ToDoItem>();

        public ToDoService Service { get; } = new ToDoService();

        public ToDosPage()
        {
            Title = "My To Dos";

            InitializeComponent();

            BindableLayout.SetItemsSource(ItemsContainer, ToDos);

            Root.Children.Add(new Button
            {
                Text = "Add",
                Command = new Command(() => AddItem()),
                //VerticalOptions = 
            });
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ToDoItem[] result = await Service.GetToDos();

            Debug.WriteLine(result);

            foreach (var item in result)
            {
                ToDos.Add(item);
            }
        }

        private void AddItem()
        {
            ToDos.Add(new ToDoItem { Title = DateTime.Now.ToString() });
        }
    }
    public class ToDoService
    {
        public async Task<ToDoItem[]> GetToDos()
        {
            var http = new HttpClient();

            http.BaseAddress = new Uri("https://024b-201-202-14-8.ngrok.io");

            string json = await http.GetStringAsync("/api/todos");

            var result = JsonConvert.DeserializeObject<ToDoItem[]>(json);

            return result;
        }
    }
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
    }
}