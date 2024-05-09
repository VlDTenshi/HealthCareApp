namespace HealthCareApp.View;

public partial class ExercisesPage : ContentPage
{
	public ExercisesPage(ExercisesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}