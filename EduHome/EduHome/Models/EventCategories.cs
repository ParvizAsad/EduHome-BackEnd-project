namespace EduHome_Backend.Models
{
    public class EventCategories
    {
        public int ID { get; set; }
        public Event Event { get; set; }
        public int EventID { get; set; }
        public Categories Categories { get; set; }
        public int CategoryID { get; set; }
    }
}
