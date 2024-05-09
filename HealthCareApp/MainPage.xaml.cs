using HealthCareApp.View;

namespace HealthCareApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("GreetingPage");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var isInternet =
                Connectivity.Current.NetworkAccess == NetworkAccess.Internet;

            DisplayAlert("Is internet?", $"{isInternet}", "Ok");
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MedicineDetailsPage));
        }
    }

}
