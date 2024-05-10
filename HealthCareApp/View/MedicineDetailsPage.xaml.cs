namespace HealthCareApp.View;

public partial class MedicineDetailsPage : ContentPage
{
	public MedicineDetailsPage(MedicineDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}