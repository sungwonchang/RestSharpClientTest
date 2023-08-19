using RestSharp;
using RestSharpLib.Models;
using RestSharpLib.Models.Request;
using RestSharpLib.Models.Response;
using RestSharpLib.Serializers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestSharpLib.RestSharp
{
    public class RestClientExample
    {
        

        private readonly RestClient _petClient;

        public RestClientExample()
        {
            _petClient = ClientFactory.PetStoreClient;
        }

        //get
        //https://petstore.swagger.io/v2/pet/findByStatus?status=available
        public async Task<PetResult> GetPetListByStatus()
        {
            var request = new RestRequest("/v2/pet/findByStatus");
            request.AddQueryParameter("status", "available");

            var response = await _petClient.ExecuteGetAsync<PetResult>(request);
            if (!response.IsSuccessful)
            {
                //Logic for handling unsuccessful response
            }
            return response.Data;
        }

        public async Task<OrderResponse> PostStoreOfOrder(OrderRequest order)
        {
            var request = new RestRequest("/v2/store/order");
            //request.AddUrlSegment("id", 1);
            
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(order); 

            var response = await _petClient.ExecutePostAsync<OrderResponse>(request);


            if (!response.IsSuccessful)
            {
                //Logic for handling unsuccessful response
            }
            return response.Data;
        }



    }
}
