using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// Реализовать метод отправки GET запроса https://reqres.in/api/users?page=2
    /// В ответ на запрос возвращается список пользователей
    /// Десериализовать ответ и вывести в консоль email пользователя по имени George Edwards
    /// </summary>
    class Program
    {
        private static readonly string url = "https://reqres.in/";

        static void Main(string[] args)
        {
            var client = new RestClient(url);
            var restRequest = new RestRequest("api/users?page=2", Method.Get);
            RestResponse restResponse = client.Get(restRequest);

            var myResponseObject = JsonConvert.DeserializeObject<Response>(restResponse.Content);
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

    public class Data
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Avatar { get; set; }
    }

    public class Response
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<Data> Data { get; set; }
        public Support Support { get; set; }
    }

    public class Support
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }
}
