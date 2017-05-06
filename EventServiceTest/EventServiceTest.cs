using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using EventService;
using EventModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            Stream stream = new MemoryStream();
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, new Event());
            HttpContent content = new StreamContent(stream);
            var response = client.PostAsync("createevent",content).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("\"1\"", result);
        }

        [TestMethod]
        public void ReadEventEndpointTest()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8733/EventService/"),
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("readevent/1").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("\"You entered: 1\"", result);
        }

        [TestMethod]
        public void UpdateEventEndpointTest()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8733/EventService/"),
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("updateevent").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("\"You entered: 1\"", result);
        }

        [TestMethod]
        public void DeleteEventEndpointTest()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8733/EventService/"),
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("deleteevent").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("\"You entered: 1\"", result);
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
            Event response = service.ReadEvent(eventID);
            Assert.IsInstanceOfType(response, typeof(Event));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UpdateEventTest()
        {
            IEventService service = new EventService.EventService();
            string eventID = "1";
            service.UpdateEvent(eventID);
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
