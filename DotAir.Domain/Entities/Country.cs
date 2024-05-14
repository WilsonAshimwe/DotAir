using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotAir.Domain.Entities
{
    public class Country
    {
        [JsonPropertyName("cca2")]
        public string IsoCode { get; set; } = null!;
    }
}
