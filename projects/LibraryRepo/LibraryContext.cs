using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repo
{
    public class LibraryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
    }
}
