using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareApp.Services
{
    public class HospitalService
    {
        HttpClient _httpClient;

        public HospitalService()
        {
            this._httpClient = new HttpClient();
        }

        List<Hospital> hospitalList = new();
        public async Task<List<Hospital>> GetHospitals()
        {
            if (hospitalList?.Count > 0)
                return hospitalList;

            var url = "https://github.com/VlDTenshi/HealthCareApp/blob/master/HealthCareApp/Resources/Raw/hospitaldata.json";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                hospitalList = await response.Content.ReadFromJsonAsync(HospitalContext.Default.ListHospital);
            }

            /*using var stream = await FileSystem.OpenAppPackageFileAsync("medicinedata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            medicineList = JsonSerializer.Deserialize<List<Medicine>>(contents);*/

            return hospitalList;
        }
    }
}
