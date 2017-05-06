using EventService.DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;

namespace EventService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public partial class EventService : IEventService
    {
        public string CreateEvent(Event e)
        {
            create(new Event { Author = "aa", Date = DateTime.Now, StartDateTime = DateTime.Now, EndDateTime = DateTime.Now });
            return "1";
        }

        public bool DeleteEvent(string eventID)
        {
            return true;
        }

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string ReadEvent(string eventID)
        {
            try
            {
                var e = new Event { Author = "aa", Date = DateTime.Now, StartDateTime = DateTime.Now, EndDateTime = DateTime.Now };
                return Serialize<Event>(e);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Event ReadEventDetails(string eventID)
        {
            var e = new Event { Author = "aa", Date = DateTime.Now, StartDateTime = DateTime.Now, EndDateTime = DateTime.Now };
            return e;
        }

        private static string Serialize<T>(T e)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, e);
            byte[] content = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(content);
        }

        public void UpdateEvent(Event e)
        {
            update(e);
        }

        public bool RegisterForvent(string userID)
        {
            return true;
        }
    }
}
