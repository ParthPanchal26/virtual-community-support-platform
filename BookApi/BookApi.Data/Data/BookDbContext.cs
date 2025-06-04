using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookApi.Entities.Models;

namespace BookApi.Data.Data {
    public class BookDbContext : IdentityDbContext<IdentityUser> {

        
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) {
        }

        public DbSet<Book> Books { get; set; }
    }
}
