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

        [ForeignKey("IdentityUser")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey("Book")]
        [Column("Id")]
        public int? BookId { get; set; }
        public Book? Book { get; set; }

     
    }
}
