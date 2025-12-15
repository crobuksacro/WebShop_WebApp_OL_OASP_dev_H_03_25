using System.ComponentModel.DataAnnotations;

namespace Ispit.Books.Models.Dbo
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author? Author { get; set; }
        public int? AuthorId { get; set; }
        public AspNetUser? AspNetUser { get; set; }
        public string? AspNetUserId { get; set; }
        public Publisher? Publisher { get; set; }
        public int? PublisherId { get; set; }

    }
}
