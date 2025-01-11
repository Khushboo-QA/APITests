using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;


namespace UnitTestsAPI.Tests
{
    [TestClass] 
    public class PutRequest
    {
       
        [TestMethod] 
        public void PutMethod()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            // Get our file's parent directory
            var parentpath = Path.GetDirectoryName(currentDirectory);
            // Get the directory's own parent directory
            var secondpath = Path.GetDirectoryName(parentpath);
            string reqFile = string.Concat(secondpath, "\\Files\\PutData.json");
            string reqObject=File.ReadAllText(reqFile); 

            string url = "https://reqres.in/api/users/2";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "PUT";
            httpWebRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(reqObject);
            }

            string html;

            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
       
           
            var apiResponse = JsonConvert.DeserializeObject(html);
            Console.WriteLine(apiResponse);

            // Access the value of the 'name' field
            var jsonObject = JObject.Parse(html);
            string name = jsonObject["name"].ToString();
            Console.WriteLine(name);
        }
    }
}
