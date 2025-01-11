using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace RestsharpSample
{
    public class PutRequest
    {
        string CurrentDirextory = Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory);

        [Test]
        public void Put()
        {
            RestClient client = new RestClient(TestContext.Parameters.Get("baseUrl"));
            RestRequest request = new RestRequest("Books/12");
            request.AddBody(File.ReadAllText(string.Concat(CurrentDirextory, "/../../JsonFiles/PutJson.json")));
            
            RestResponse response = client.ExecutePut(request);
            response.IsSuccessStatusCode = true;
            var bodyContent = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            Assert.That($"{bodyContent["title"]}", Is.EqualTo("TestTitle"));
        }
    }
}
