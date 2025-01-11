using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using static UnitTestProject1.Files.GetResponse;

namespace UnitTestsAPI.Tests
{
    [TestClass]
    public class GetRequest
    {
        [TestMethod]
        public void GetMethod()
        {
            string html;
            string url = "https://reqres.in/api/users/2";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var resp = JsonConvert.DeserializeObject<Rootobject>(html);
            Assert.IsTrue(resp.data.id.Equals(2));
        }
    }
}
