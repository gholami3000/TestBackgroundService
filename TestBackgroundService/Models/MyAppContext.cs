using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TestBackgroundService.Models
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }
        public virtual DbSet<Request> Request { get; set; }
    }
}
