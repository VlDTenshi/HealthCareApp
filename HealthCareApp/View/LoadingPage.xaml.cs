namespace HealthCareApp.View;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
        InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		//Wait for 5 sec to navigate to another page
		await Task.Delay(10000);

		//Create new page sample
		var nextPage = new MainPage();

		//Go to the new page
		await Navigation.PushAsync(nextPage);

        //Delete current page from the stack pf navigation
        Navigation.RemovePage(this);
	}
}