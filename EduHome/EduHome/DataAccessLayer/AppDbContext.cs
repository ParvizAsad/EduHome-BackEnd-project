using Microsoft.EntityFrameworkCore;

namespace EduHome_Backend.DataAccessLayer
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
       


    }
    
}
