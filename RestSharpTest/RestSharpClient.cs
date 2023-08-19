using FluentAssertions.Extensions;
using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpLib.Models.Request;
using RestSharpLib.Models.Response;
using RestSharpLib.RestSharp;
using RestSharpLib.Serializers;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestSharpTest
{
    [TestClass]
    public class RestSharpClient
    {
        [TestMethod]
        public async Task TestPetstListByStatus()
        {
            RestClientExample restClientExample = new RestClientExample();
            var result = await restClientExample.GetPetListByStatus();
            Assert.IsNotNull(result);
            Assert.IsTrue(result?.Count() > 0);
        }

        [TestMethod]
        public void TestSerialize()
        {
            string json = "{\"id\":7878787878915,\"petId\":0,\"quantity\":1,\"shipDate\":\"2023-08-19T00:45:19.046+0000\",\"status\":\"placed\",\"complete\":true}";

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // JSON 키를 대/소문자 구분 없이 처리하려면 이 옵션을 사용
                Converters = { new CustomDateTimeConverter() } // DateTime 형식 변환기 추가
            };

            OrderResponse myData = JsonSerializer.Deserialize<OrderResponse>(json, options);

            Console.WriteLine($"MyDateTime: {myData.ShipDate}");
        }
       

        [TestMethod]
        public async Task TestPetUpdate()
        {
            RestClientExample restClientExample = new RestClientExample();
            var result = await restClientExample.PostStoreOfOrder(new OrderRequest()
            {
                Id = 0,
                PetId = 0,
                Quantity = 1,
                ShipDate = DateTime.UtcNow,
                Status = "placed",
                Complete = true
            });
            Assert.IsNotNull(result);
            Assert.IsTrue(result?.Id > 7878787878887);
        }
    }



    public class MyData
    {
       
        public DateTime shipDate { get; set; }
    }
}