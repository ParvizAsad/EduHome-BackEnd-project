namespace EduHome.Models
{
    public class EventSpeaker
    {
        public int ID { get; set; }
        public int SpikerID { get; set; }
        public Speaker Speaker { get; set; }
        public int EventID { get; set; }
        public Event Event { get; set; }
    }
}
