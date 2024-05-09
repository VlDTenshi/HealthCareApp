namespace HealthCareApp.View;

public partial class ExerciseDetailsPage : ContentPage
{
	public ExerciseDetailsPage(ExerciseDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}