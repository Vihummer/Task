using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;

namespace Task3
{
    /// <summary>
    /// ���������, ��� ������� ������ 201, � ��� ��, ��� � ������ �������� id ������ ������������
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
        /// ���������, ��� ������� ������ 201
        /// </summary>
        [Test]
        public void CheckStatusCodeCreated()
        {
            var response = baseClass.Response();

            Assert.That(response.StatusCode == HttpStatusCode.Created, "�������, ��� ������� ������ 201");
        }

        /// <summary>
        /// ���������, ��� � ������ �������� id ������ ������������
        /// </summary>
        [Test]
        public void CheckIdUser()
        {
            var response = baseClass.Response().Content;
            var myResponseObject = JsonConvert.DeserializeObject<ResponseObject>(response);

            Assert.That(!String.IsNullOrEmpty(myResponseObject.Id), "�������, ��� � ������ �������� id ������ ������������");
        }
    }
}