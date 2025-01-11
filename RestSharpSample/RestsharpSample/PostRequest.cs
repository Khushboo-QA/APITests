using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
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
    public class PostRequest
    {
        string CurrentDirextory = Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory);

        [Test]
        public void Post()
        {
            RestClient client = new RestClient(TestContext.Parameters.Get("baseUrl"));
            RestRequest request = new RestRequest("Books"); 
            request.AddBody(File.ReadAllText(string.Concat(CurrentDirextory, "/../../JsonFiles/PostJson.json")));
            RestResponse response = client.ExecutePost(request);
            response.IsSuccessStatusCode = true;
            var bodyContent = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            Assert.IsNotNull(bodyContent);
            Assert.That($"{bodyContent["pageCount"]}", Is.EqualTo("1"));
        }
    }
}
