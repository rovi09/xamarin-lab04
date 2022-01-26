using System;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class App : Application
	{
		public App()
		{
			Button openHello = new Button { Text = "Go to Hello" };
			var openControls = new Button { Text = "Go to Controls" };

			var page = new ContentPage {
				Content = new StackLayout 
				{
					Orientation = StackOrientation.Vertical,
					Children = { 
						openHello,
						openControls,
					}
				}
			};

			openHello.Command = new Command(() => page.Navigation.PushAsync(new Views.HelloWorldPage() { Username = "Pablo" } ));
			openControls.Command = new Command(() => page.Navigation.PushAsync(new Views.ControlsPage()));

			View titleView = new StackLayout { 
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Children = { 
					new Label { Text = "Welcome to Xamarin" }
				}
			};

			NavigationPage.SetTitleView(page, titleView);

			//MainPage = new NavigationPage(page);
			MainPage = new Views.MainPage();

			// new HelloWorldPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}