using Microsoft.Maui.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareApp.ViewModel
{
    [QueryProperty(nameof(Hospital),"Hospital")]
    public partial class HospitalDetailsViewModel : BaseViewModel
    {
        IMap map;
        public HospitalDetailsViewModel()
        {
            this.map = map;
        }
        [ObservableProperty]
        Hospital hospital;

        [RelayCommand]
        async Task OpenMap()
        {
            try
            {
                await map.OpenAsync(Hospital.Latitude, Hospital.Longitude,
                    new MapLaunchOptions
                    {
                        Name = Hospital.Name,
                        NavigationMode = NavigationMode.None
                    });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", $"Unable to open map: {ex.Message}", "Ok");
            }
        }
    }
}
