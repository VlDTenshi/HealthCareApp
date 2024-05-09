using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareApp.ViewModel
{
    [QueryProperty("Medicine", "Medicine")]
    public partial class MedicineDetailsViewModel : BaseViewModel
    {
        public MedicineDetailsViewModel() 
        {

        }
        [ObservableProperty]
        Medicine medicine;
    }
    
}
