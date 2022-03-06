using EduHome_Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class BlogDetail
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Boş saxlanıla Bilməz!")]
        public string LeaveDescription { get; set; }
        [ForeignKey("Blog")]
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
