﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sinric.json
{
    internal class SinricValue
    {
        // misc fields
        [JsonExtensionData]
        public IDictionary<string, JToken> Fields { get; set; } = new Dictionary<string, JToken>();
    }
}