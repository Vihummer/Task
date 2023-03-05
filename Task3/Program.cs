using Newtonsoft.Json;
using RestSharp;
using System;

namespace Task3
{
    class Program
    {
        private static string url = "https://reqres.in/api/users";

        static void Main(string[] args)
        {
            var client = new RestClient();
            var request = new RestRequest(url, Method.Post);
            request.AddBody(new
            {
                name = "morpheus",
                job = "leader"
            });
            var response = client.ExecutePost(request).Content;

            var myResponseObject = JsonConvert.DeserializeObject<Root>(response);
        }
    }

    public class Test
    {

    }

    class Root
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Id { get; set; }
        public string CreatedAt { get; set; }
    }
}
