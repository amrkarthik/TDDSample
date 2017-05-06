using System;

namespace EventModel
{
    [Serializable]
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Agenda { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Author { get; set; }
        public string BookName { get; set; }
        public int[] ParticipantIDs { get; set; }
    }
}
