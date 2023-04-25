using System.ComponentModel.DataAnnotations.Schema;

namespace _521Final.Models
{
    public class UserBook
    {
        public int UserBookId { get; set; }
        [ForeignKey("User")]

        public int? UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey("Book")]

        public int? BookId { get; set; }
        public Book? Book { get; set; }
    }
}
