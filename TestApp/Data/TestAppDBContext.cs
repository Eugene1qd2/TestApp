using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Data
{
    public class TestAppDBContext:DbContext
    {
        public DbSet<СontactViewModel> Contacts { get; set; }

        public TestAppDBContext(DbContextOptions<TestAppDBContext> options):base(options)
        {
            
        }
    }
}
