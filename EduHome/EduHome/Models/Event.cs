using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome_Backend.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string EventImage { get; set; }
      
        [NotMapped]
        public IFormFile Photo { get; set; }
       
        public DateTime EventDate { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
      
        public bool IsDeleted { get; set; }

        public ICollection<EventCategories> EventCategories { get; set; }
        public ICollection<EventSpeaker> EventSpeaker { get; set; }
    }
}
