namespace HealthCareApp.View;

public partial class GreetingsPage : ContentPage
{
	public GreetingsPage()
	{
        InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("InformationPage");
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}