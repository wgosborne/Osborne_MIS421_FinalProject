using System.ComponentModel.DataAnnotations.Schema;

namespace _521Final.Models
{
    public class UserBook
    {
        public int UserBookId { get; set; }

        //I think we should add these

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public double? UserRating { get; set; }

        public string? UserReview { get; set; }

        [ForeignKey("ApplicationUser")]
        //public int? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey("Book")]
        public int? BookId { get; set; }
        public Book? Book { get; set; }

        // public List<Book> MyBooks { get; set; }
        //public List<Book> WishList { get; set; } // or we can just do one called Shelf
    }
}
