using MDLTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MDLTask.DataAccess
{
    public class MdlTaskDbContext : DbContext
    {
        public MdlTaskDbContext(DbContextOptions<MdlTaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<Content> Contents { get; set; } = null!;
    }
}
