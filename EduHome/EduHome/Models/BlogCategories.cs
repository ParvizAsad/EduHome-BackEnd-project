namespace EduHome.Models
{
    public class BlogCategories
    {
        public int Id { get; set; }
        public Blog Blog { get; set; }
        public int BlogID { get; set; }
        public Categories Categories { get; set; }
        public int CategoriesID { get; set; }
    }
}
