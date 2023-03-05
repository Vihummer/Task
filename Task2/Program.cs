using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        private static string url = "https://reqres.in/api/users?page=2";

        static void Main(string[] args)
        {
            var client = new RestClient();
            var restRequest = new RestRequest(url, Method.Get);
            RestResponse restResponse = client.Get(restRequest);

            var myResponseObject = JsonConvert.DeserializeObject<Root>(restResponse.Content);

            var valueData = myResponseObject.Data;

            foreach (var item in valueData)
            {
                if (item.First_name == "George" && item.Last_name == "Edwards")
                {
                    Console.WriteLine(item.Email);
                }
                continue;
            }
        }
    }

    public class Datum
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Avatar { get; set; }
    }

    public class Root
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<Datum> Data { get; set; }
        public Support Support { get; set; }
    }

    public class Support
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }
}
