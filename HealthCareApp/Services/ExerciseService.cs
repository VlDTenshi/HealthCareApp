﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareApp.Services
{
    public class ExerciseService
    {
        HttpClient _httpClient;

        public ExerciseService()
        {
            this._httpClient = new HttpClient();
        }

        List<Exercise> exerciseList = new();
        public async Task<List<Exercise>> GetExercises()
        {
            if (exerciseList?.Count > 0)
                return exerciseList;

            //Online
            var url = "https://github.com/VlDTenshi/HealthCareApp/blob/master/HealthCareApp/Resources/Raw/exercisedata.json";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                exerciseList = await response.Content.ReadFromJsonAsync(ExerciseContext.Default.ListExercise);
            }

            //Offline
            /*using var stream = await FileSystem.OpenAppPackageFileAsync("medicinedata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            medicineList = JsonSerializer.Deserialize<List<Medicine>>(contents);*/

            return exerciseList;
        }
    }
}
