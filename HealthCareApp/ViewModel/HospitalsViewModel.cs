using HealthCareApp.Model;
using HealthCareApp.Services;
using HealthCareApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareApp.ViewModel
{
    public partial class HospitalsViewModel : BaseViewModel
    {
        HospitalService hospitalService;

        public ObservableCollection<Hospital> Hospitals { get; } = new();

        IConnectivity connectivity;
        IGeolocation geolocation;
        public HospitalsViewModel(HospitalService hospitalService, IConnectivity connectivity, IGeolocation geolocation)
        {
            Title = "Hospital Searcher";
            this.hospitalService = hospitalService;
            this.connectivity = connectivity;
            this.geolocation = geolocation;
        }

        async Task GetClosestHospitalAsync()
        {
            if (IsBusy || Hospitals.Count == 0)
                return;
            try
            {
                
                var location = await geolocation.GetLastKnownLocationAsync();
                if(location is null)
                {
                    location = await geolocation.GetLocationAsync(
                        new GeolocationRequest
                        {
                            DesiredAccuracy=GeolocationAccuracy.Medium,
                            Timeout = TimeSpan.FromSeconds(30)
                        });
                }
                if (location == null)
                    return;

                var first = Hospitals.OrderBy(h => 
                    location.CalculateDistance(h.Latitude, h.Longitude, DistanceUnits.Kilometers)
                    ).FirstOrDefault();

                if (first is null)
                    return;

                await Shell.Current.DisplayAlert("Closest Hospital",
                    $"{first.Name} in {first.Location}", "Ok");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get closest hospital: {ex.Message}", "Ok");
            }
        }
        async Task GoToDetailsAsync(Hospital hospital)
        {
            if (hospital is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(HospitalDetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {"Hospital", hospital }
                });
        }
        async Task GetHospitalAsync()
        {
            if (IsBusy)
                return;
            try
            {
                if(connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Error!", $"Check an internet connection!", "Ok");
                };
                IsBusy = true;
                var hospitals = await hospitalService.GetHospitals();

                if (Hospitals.Count != 0)
                    Hospitals.Clear();

                foreach (var hospital in hospitals)
                    Hospitals.Add(hospital);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get hospitals: {ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
