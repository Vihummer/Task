using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;

namespace Task3
{
    /// <summary>
    /// ѕровер€ем, что получен статус 201, а так же, что в ответе вернулс€ id нового пользовател€
    /// </summary>
    public class Tests
    {
        Base baseClass;

        [OneTimeSetUp]
        [SetUp]
        public void Setup()
        {
            baseClass = new();
        }

        /// <summary>
        /// ѕровер€ем, что получен статус 201
        /// </summary>
        [Test]
        public void CheckStatusCodeCreated()
        {
            var response = baseClass.Response();

            Assert.That(response.StatusCode == HttpStatusCode.Created, "ќжидаем, что получен статус 201");
        }

        /// <summary>
        /// ѕровер€ем, что в ответе вернулс€ id нового пользовател€
        /// </summary>
        [Test]
        public void CheckIdUser()
        {
            var response = baseClass.Response().Content;
            var myResponseObject = JsonConvert.DeserializeObject<ResponseObject>(response);

            Assert.That(!String.IsNullOrEmpty(myResponseObject.Id), "ќжидаем, что в ответе вернулс€ id нового пользовател€");
        }
    }
}