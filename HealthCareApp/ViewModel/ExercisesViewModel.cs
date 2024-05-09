using HealthCareApp.Services;
using HealthCareApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareApp.ViewModel
{
    public partial class ExercisesViewModel : BaseViewModel
    {
        ExerciseService exerciseService;
        public ObservableCollection<Exercise> Exercises { get; } = new();


        public ExercisesViewModel(ExerciseService exerciseService)
        {
            Title = "Medicine Finder";
            this.exerciseService = exerciseService;

        }
        [ObservableProperty]
        bool isRefreshing;

        async Task GoToDetailsAsync(Exercise exercise)
        {
            if (exercise is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ExerciseDetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {"Exercise", exercise }
                });
        }
        async Task GetExercisesAsync()
        {
            
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var exercises = await exerciseService.GetExercises();

                if (Exercises.Count != 0)
                    Exercises.Clear();

                foreach (var exercise in exercises)
                    Exercises.Add(exercise);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get exercises: {ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
