using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace RestsharpSample
{
    public class DeleteRequest
    {
        [Test]
        public void Delete()
        {
            RestClient client = new RestClient(TestContext.Parameters.Get("baseUrl"));
            RestRequest request = new RestRequest("Books/12", Method.Delete);
            RestResponse response = client.Delete(request);
            response.IsSuccessStatusCode = true;
            var bodyContent = response.Content;
            Assert.That(bodyContent == string.Empty);
            
        }
    }
}
