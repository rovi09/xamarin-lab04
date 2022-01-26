using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogsPage : ContentPage
    {
        public Lazy<BlogginDbContext> DbContext { get; set; }
            = new Lazy<BlogginDbContext>(() => new BlogginDbContext());

        public ObservableCollection<string> Items { get; set; }

       
        
        public BlogsPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>(
                DbContext.Value.Blogs.Select(blog => blog.Url)
                    );

            ItemsView.ItemsSource = Items;
        }
    }
}