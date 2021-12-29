using System;
using Xamarin.Forms;

namespace MobileApp
{
	public partial class App : Application
	{
		public App()
		{
			var label = new Label
			{
				Text = "Hello, World!",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
			};

			var button = new Button { Text = "Click me" };
			int i = 0;
			button.Clicked += (s, e) => {
				button.Text = "Hello, World! " + i++;
			};

			MainPage = new ContentPage
			{
				BackgroundColor = Color.Transparent,
				Content = new StackLayout
				{
					BackgroundColor = Color.Transparent,
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.Center,
					Children = { label, button }
				}
			};
		}
	}
}
