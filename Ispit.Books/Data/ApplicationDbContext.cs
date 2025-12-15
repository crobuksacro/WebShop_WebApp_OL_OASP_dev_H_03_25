using Ispit.Books.Models.Dbo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Books.Data
{
    public class ApplicationDbContext : IdentityDbContext<AspNetUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>().HasData(
                 new Author { Id = 1, FirstName = "Pero", LastName = "Peric" },
                 new Author { Id = 2, FirstName = "Ana", LastName = "Anic" },
                 new Author { Id = 3, FirstName = "Marko", LastName = "Markic" },
                 new Author { Id = 4, FirstName = "Ivana", LastName = "Ivanic" },
                 new Author { Id = 5, FirstName = "Luka", LastName = "Lukic" }
             );

            builder.Entity<Publisher>().HasData(
                 new Publisher { Id = 1, Name = "VBZ" },
                 new Publisher { Id = 2, Name = "Algoritam" },
                 new Publisher { Id = 3, Name = "Znanje" }
             );



            base.OnModelCreating(builder);
        }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
