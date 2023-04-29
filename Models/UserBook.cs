using System.ComponentModel.DataAnnotations.Schema;

namespace _521Final.Models
{
    public class UserBook
    {
        public int UserBookId { get; set; }

        //I think we should add these

        //public DateTime StartDate

        //public DateTime EndDate

        //public int UserRating (should probably be a double, need to change other things

        //public string UserReview

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Book")]
        public int? BookId { get; set; }
        public Book? Book { get; set; }

        // public List<Book> MyBooks { get; set; }
        //public List<Book> WishList { get; set; } // or we can just do one called Shelf
    }
}
