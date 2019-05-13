using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinDoctors.Models
{
    public class Doctor
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("LastName")]
        public String LastName { get; set; }
        [JsonProperty("Speciality")]
        public String Speciality { get; set; }
        [JsonProperty("Salary")]
        public int Salary { get; set; }
        [JsonProperty("Hospital")]
        public int Hospital { get; set; }
    }
}
