using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicalGuitar.Models
{
    public partial class GuitarsResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("guitars")]
        public Guitar[] Guitars { get; set; }
    }
}
