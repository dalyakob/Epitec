using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevTraining.IntegrationTests.Endpoints
{
    public static class JsonSerializerHelper
    {
        public static JsonSerializerOptions SerializationOptions => new JsonSerializerOptions { IgnoreNullValues = true };
        public static JsonSerializerOptions DeserializationOptions => new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    }
}
