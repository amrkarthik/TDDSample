using System;
using System.Runtime.Serialization;

namespace EventService.DataContracts
{
    [DataContract]
    [Serializable]
    public class Event
    {
        [DataMember]
        public int EventID { get; set; }
        [DataMember]
        public string EventName { get; set; }
        [DataMember]
        public string Agenda { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public DateTime StartDateTime { get; set; }
        [DataMember]
        public DateTime EndDateTime { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string BookName { get; set; }
        [DataMember]
        public int[] ParticipantIDs { get; set; }
    }
}
