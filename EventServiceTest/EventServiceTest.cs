using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using EventService;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EventService.DataContracts;
using System.IO.Compression;
using System.Text;
using System.Runtime.Serialization.Json;

namespace EventServiceTest
{
    [TestClass]
    public class EventServiceTest
    {
        [TestMethod]
        public void GetDataEndpointTest()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8733/EventService/"),
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("getdata/1").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("\"You entered: 1\"", result);
        }

        [TestMethod]
        public void CreateEventEndpointTest()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8733/EventService/"),
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content = GetHttpContent();
            var response = client.PostAsync("createevent", content).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("\"1\"", result);
        }

        private static HttpContent GetHttpContent()
        {
            Stream stream = new MemoryStream();
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, new Event());
            HttpContent content = new StreamContent(stream);
            return content;
        }

        //[TestMethod]
        //public void ReadEventEndpointTest()
        //{
        //    HttpClient client = new HttpClient
        //    {
        //        BaseAddress = new Uri("http://localhost:8733/EventService/"),
        //    };
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var response = client.GetAsync("readevent/1").Result;
        //    var result = response.Content.ReadAsStringAsync().Result;
        //    Assert.AreEqual("\"You entered: 1\"", result);
        //}

        [TestMethod]
        public void ReadEventDetailsEndpointTest()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8733/EventService/"),
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.ExpectContinue = false;
            var response = client.GetAsync("readeventdetails/1").Result;
            string responsestring = response.Content.ReadAsStringAsync().Result;
            MemoryStream s = new MemoryStream(Encoding.UTF8.GetBytes(responsestring));
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Event));
            Event e = deserializer.ReadObject(s) as Event;
            s.Close();
            Assert.IsInstanceOfType(e, typeof(Event));
        }

        [TestMethod]
        public void UpdateEventEndpointTest()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8733/EventService/"),
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PutAsync("updateevent", GetHttpContent()).Result;
        }

        [TestMethod]
        public void DeleteEventEndpointTest()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8733/EventService/"),
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.DeleteAsync("deleteevent").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("true", result);
        }

        [TestMethod]
        public void CreateEventTest()
        {
            IEventService service = new EventService.EventService();
            Event e = new Event();
            var response = service.CreateEvent(e);
            int.TryParse(response, out int createdEventID);
            Assert.IsInstanceOfType(createdEventID, typeof(int));
        }

        [TestMethod]
        public void ReadEventTest()
        {
            IEventService service = new EventService.EventService();
            string eventID = "1";
            Event response = service.ReadEventDetails(eventID);
            Assert.IsInstanceOfType(response, typeof(Event));
        }

        [TestMethod]
        public void UpdateEventTest()
        {
            IEventService service = new EventService.EventService();
            Event e = new Event();
            service.UpdateEvent(e);
        }

        [TestMethod]
        public void DeleteEventTest()
        {
            IEventService service = new EventService.EventService();
            string eventID = "1";
            bool response = service.DeleteEvent(eventID);
            Assert.AreEqual(true, response);
        }


    }
}
