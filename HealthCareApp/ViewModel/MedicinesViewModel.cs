using HealthCareApp.Services;
using CommunityToolkit.Mvvm.Input;
using HealthCareApp.View;

namespace HealthCareApp.ViewModel
{
    public partial class MedicinesViewModel : BaseViewModel
    {
        MedicineService medicineService;
        public ObservableCollection<Medicine> Medicines { get; } = new();

        
        public MedicinesViewModel( MedicineService medicineService) 
        {
            Title = "Medicine Finder";
            this.medicineService = medicineService;
            
        }
        
        async Task GoToDetailsAsync(Medicine medicine)
        {
            if (medicine is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(MedicineDetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {"Medicine", medicine }
                });
        }
        async Task GetMedicineAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var medicines = await medicineService.GetMedicines();

                if (Medicines.Count != 0)
                    Medicines.Clear();

                foreach(var medicine in medicines)
                    Medicines.Add(medicine);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get medicines: {ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
