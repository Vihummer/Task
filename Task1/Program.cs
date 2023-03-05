using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Task1
{
    /// <summary>
    /// Реализовать метод отправки GET запроса https://swapi.dev/api/people/1/
    /// В ответ на запрос возвращается информация по герою Звездных войн:
    /// Десериализовать ответ в объект и вывести в консоль список ссылок на фильмы(ключ ‘films’)
    /// </summary>
    class Program
    {
        private static readonly string url = "https://swapi.dev/";

        static void Main(string[] args)
        {
            var client = new RestClient(url);
            var restRequest = new RestRequest("api/people/1/", Method.Get);
            RestResponse restResponse = client.Get(restRequest);

            var myResponseObject = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            var valueFilms = myResponseObject.Films;

            foreach (var item in valueFilms)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }

    public class Response
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
