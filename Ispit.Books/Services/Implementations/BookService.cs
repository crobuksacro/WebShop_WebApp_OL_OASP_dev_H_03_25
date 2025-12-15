using Ispit.Books.Data;
using Ispit.Books.Models.Dbo;
using Ispit.Books.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ispit.Books.Services.Implementations
{
    public class BookService : IBookService
    {
        private UserManager<AspNetUser> userManager;
        private ApplicationDbContext _context;

        public BookService(UserManager<AspNetUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public void AddBook(Book book, ClaimsPrincipal user)
        {
            var applicationUser = userManager.GetUserAsync(user).Result;
            book.AspNetUserId = applicationUser.Id;
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();

        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }


        public Book GetBook(int id)
        {
            return _context.Books.Find(id);
        }


        public async Task<List<Author>> GetAuthors()
        {
            var dbo = await _context.Authors.ToListAsync();
            return dbo;
        }


        public async Task<List<Publisher>> GetPublishers()
        {
            var dbo = await _context.Publishers.ToListAsync();
            return dbo;
        }

    }
}
