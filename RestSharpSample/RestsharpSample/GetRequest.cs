using RestSharp;
using System.Net;

namespace RestsharpSample
{
    public class GetRequest
    {
        
       
        [Test]
        public void Get()
        {
            RestClient client =new RestClient(TestContext.Parameters.Get("baseUrl"));
            RestRequest request = new RestRequest(TestContext.Parameters.Get("baseUrl"),Method.Get);
            RestResponse response = client.Execute(request);
            Assert.IsNotNull(response);
            response.IsSuccessStatusCode = true;

        }
    }
}