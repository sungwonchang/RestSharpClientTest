using RestSharp;
using RestSharp.Serializers.Json;
using RestSharpLib.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestSharpLib
{
    internal sealed class ClientFactory
    {
        private readonly static Lazy<RestClient> petStoreClient
            = new Lazy<RestClient>(() =>
        {
            var options = new JsonSerializerOptions() 
            { 
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                Converters = { new CustomDateTimeConverter() }
            };
            

            return new RestClient("https://petstore.swagger.io",
                configureSerialization: s => s.UseSystemTextJson(options));
        });

        public static RestClient PetStoreClient 
        { 
            get
            {
                return petStoreClient.Value;
            }
        }
    }
}
