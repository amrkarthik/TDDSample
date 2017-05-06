using EventModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EventService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public partial class EventService : IEventService
    {
        public string CreateEvent(Event e)
        {
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

        public Event ReadEvent(string eventID)
        {
            return new Event();
        }

        public void UpdateEvent(string eventID)
        {
            
        }
    }
}
