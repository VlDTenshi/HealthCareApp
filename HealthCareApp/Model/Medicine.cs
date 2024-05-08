using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareApp.Model
{
    public class Medicine
    {
        // Medicine name
        public string Name { get; set; }

        // Dosage description
        public string DosageDescription { get; set; }

        // Composition of the medicine (active and auxiliary components)
        public string Composition { get; set; }

        // Instructions for use
        public string UsageInstructions { get; set; }

        // Side effects
        public string SideEffects { get; set; }

        // Contraindications
        public string Contraindications { get; set; }

        // Form of release
        public string Form { get; set; }

        // Manufacturer
        public string Manufacturer { get; set; }

        // Expiry date
        public DateTime? ExpiryDate { get; set; }

        // Special instructions
        public string SpecialInstructions { get; set; }

        //Image
        public string Image {  get; set; } 
    }
}
