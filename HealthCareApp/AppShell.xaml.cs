using HealthCareApp.View;

namespace HealthCareApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("GreetingPage", typeof(GreetingsPage));
            Routing.RegisterRoute("InformationPage", typeof(InformationPage));
            Routing.RegisterRoute(nameof(MedicineDetailsPage), typeof(MedicineDetailsPage));
            Routing.RegisterRoute(nameof(HospitalDetailsPage), typeof(HospitalDetailsPage));
            Routing.RegisterRoute(nameof(ExerciseDetailsPage), typeof(ExerciseDetailsPage));
            //Accept an event Navigated
            Navigated += OnNavigated;
        }

        private async void OnNavigated(object? sender, ShellNavigatedEventArgs e)
        {
            // Wait 5 sec after shell page loading
            await Task.Delay(10000);

            // Create a new page sample, which is needed to get
            var nextPage = new MainPage();

            //Go to another page
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

            //Delete an event to avoid going again
            Navigated -= OnNavigated;
        }
    }
}
