using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareApp.Services
{
    public class MedicineService
    {
        HttpClient _httpClient;

        public MedicineService()
        {
            _httpClient = new HttpClient();
        }

        List<Medicine> medicineList = new();
        public async Task<List<Medicine>> GetMedicines()
        {
            if(medicineList?.Count > 0)
                return medicineList;

            var url = ".json";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                medicineList = await response.Content.ReadFromJsonAsync<List<Medicine>>();
            }

            using var stream = await FileSystem.OpenAppPackageFileAsync("medicinedata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            medicineList = JsonSerializer.Deserialize<List<Medicine>>(contents);

            return medicineList;
        }
    }
}
