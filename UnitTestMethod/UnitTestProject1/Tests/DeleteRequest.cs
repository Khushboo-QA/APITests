using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsAPI.Tests
{
    [TestClass] 
    public class DeleteRequest
    {
        [TestMethod]
        public void Delete()
        {
            string url = "https://reqres.in/api/unknown/2";

            // Create the HTTP request
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "DELETE"; // Specify the DELETE method

            // Get the response
            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string html = reader.ReadToEnd();
                Console.WriteLine("Response: " + html);
            }

        }
    }
}
