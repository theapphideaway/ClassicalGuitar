using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicalGuitar.Models
{
    public partial class Guitar
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("guitar_name")]
        public string GuitarName { get; set; }

        [JsonProperty("guitar_description")]
        public string GuitarDescription { get; set; }

        [JsonProperty("body_type")]
        public string BodyType { get; set; }

        [JsonProperty("back_and_sides")]
        public string BackAndSides { get; set; }

        [JsonProperty("guitar_image")]
        public string GuitarImage { get; set; }

        [JsonProperty("guitar_top")]
        public string GuitarTop { get; set; }
    }

}
