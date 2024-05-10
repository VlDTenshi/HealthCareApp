using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthCareApp.Model
{
    public class Hospital
    {
        public string Name { get; set; }
        public string Image {  get; set; }
        public string Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    [JsonSerializable(typeof(List<Hospital>))]
    internal sealed partial class HospitalContext : JsonSerializerContext
    {

    }
}
