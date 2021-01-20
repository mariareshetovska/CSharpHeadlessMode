using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHeadlessMode
{
    [TestFixture]
    public class RestSharpTest
    {
        private const string BASE_URL = "https://www.opencart.com/";
        RestClient client = new RestClient(BASE_URL);

        [Test]
        public void restGetFeaturesTest()
        {
            RestRequest request = new RestRequest("index.php?route=cms/feature", Method.GET);
            IRestResponse restResponse = client.Execute(request);
            string responseData = restResponse.Content;
            Assert.IsTrue(responseData.Contains("OpenCart Features"));
        }

        [Test]
        public void restPostLoginTest()
        {
            var body = new
            {
                Email = "csharptest12@gmail.com",
                Password = "c#147852"
            };
            
            RestRequest request = new RestRequest("LOGIN", Method.POST); 
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
