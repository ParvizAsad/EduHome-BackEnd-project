using EduHome.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class EventDetail
    {
        public int ID { get; set; }

        public string Description { get; set; }
        public string ReplyText { get; set; }
        [ForeignKey(nameof(Event))]
        public int EventID { get; set; }
        public Event Event { get; set; }
    }
}
