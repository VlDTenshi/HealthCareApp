using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthCareApp.Model
{
    public class Exercise
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
    }
    [JsonSerializable(typeof(List<Exercise>))]
    internal sealed partial class ExerciseContext : JsonSerializerContext
    {

    }
}
