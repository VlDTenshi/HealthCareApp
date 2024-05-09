namespace HealthCareApp.View;

public partial class HospitalsPage : ContentPage
{
	public HospitalsPage(HospitalsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}