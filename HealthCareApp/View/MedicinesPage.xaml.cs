namespace HealthCareApp.View;

public partial class MedicinesPage : ContentPage
{
	public MedicinesPage(MedicinesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}