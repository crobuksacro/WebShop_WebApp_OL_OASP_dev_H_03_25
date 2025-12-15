using Ispit.Books.Models.Dbo;
using System.Security.Claims;

namespace Ispit.Books.Services.Interfaces
{
    public interface IBookService
    {
        void AddBook(Book book, ClaimsPrincipal user);
        void DeleteBook(int id);
        List<Book> GetAllBooks();
        Book GetBook(int id);
        void UpdateBook(Book book);
        Task<List<Author>> GetAuthors();
        Task<List<Publisher>> GetPublishers();
    }
}