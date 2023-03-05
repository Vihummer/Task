using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace Task3_1
{
    public class Tests
    {
        private static string url = "https://reqres.in/";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var response = BaseMethod();
            Assert.That(!String.IsNullOrEmpty(response.Id));
        }

        [Test]
        public void Test2()
        {
            var client = new RestClient(url);
            var request = new RestRequest("api/users", Method.Post);
            request.AddBody(new
            {
                name = "morpheus",
                job = "leader"
            });
            var response = client.ExecutePost(request);
            Assert.That(response.StatusCode == HttpStatusCode.Created);
        }

        public Root BaseMethod()
        {
            var client = new RestClient(url);
            var request = new RestRequest("api/users", Method.Post);
            request.AddBody(new
            {
                name = "morpheus",
                job = "leader"
            });
            var response = client.ExecutePost(request).Content;

            var myResponseObject = JsonConvert.DeserializeObject<Root>(response);
            return myResponseObject;
        }
    }

    public class Root
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Id { get; set; }
        public string CreatedAt { get; set; }
    }
}