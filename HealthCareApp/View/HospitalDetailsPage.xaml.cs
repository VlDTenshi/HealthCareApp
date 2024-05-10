namespace HealthCareApp.View;

public partial class HospitalDetailsPage : ContentPage
{
	public HospitalDetailsPage(HospitalDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}