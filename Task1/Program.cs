using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Task1
{
    class Program
    {
        private static string url = "https://swapi.dev/api/people/1/";

        static void Main(string[] args)
        {
            var client = new RestClient();
            var restRequest = new RestRequest(url, Method.Get);
            RestResponse restResponse = client.Get(restRequest);

            var myResponseObject = JsonConvert.DeserializeObject<Root>(restResponse.Content);

            var valueFilms = myResponseObject.Films;

            foreach (var item in valueFilms)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }

    public class Root
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string Hair_color { get; set; }
        public string Skin_color { get; set; }
        public string Eye_color { get; set; }
        public string Birth_year { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public List<string> Films { get; set; }
        public List<object> Species { get; set; }
        public List<string> Vehicles { get; set; }
        public List<string> Starships { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }
}
