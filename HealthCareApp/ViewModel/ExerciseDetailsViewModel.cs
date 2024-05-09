using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareApp.ViewModel
{
    [QueryProperty("Exercise", "Exercise")]
    public partial class ExerciseDetailsViewModel : BaseViewModel
    {
        public ExerciseDetailsViewModel()
        {

        }
        [ObservableProperty]
        Exercise exercise;
    }
}
