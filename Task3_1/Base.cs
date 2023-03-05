using RestSharp;

namespace Task3
{
    /// <summary>
    /// Базовые настройки
    /// </summary>
    public class Base
    {
        private readonly string url = "https://reqres.in/";

        /// <summary>
        /// Создаем запрос и получаем тело ответа
        /// </summary>
        /// <returns> Возвращаем тело ответа </returns>
        public RestResponse Response()
        {
            var client = new RestClient(url);
            var request = new RestRequest("api/users", Method.Post);
            request.AddBody(new
            {
                name = "morpheus",
                job = "leader"
            });
            var response = client.ExecutePost(request);

            return response;
        }
    }
}
