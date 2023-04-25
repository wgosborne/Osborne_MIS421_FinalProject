using System.ComponentModel.DataAnnotations.Schema;

namespace _521Final.Models
{
    public class GenreBook
    {
        public int GenreBookId { get; set; }
        [ForeignKey("Genre")]

        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
        [ForeignKey ("Book")]

        public int? BookId { get; set; }
        public Book? Book { get; set; }


        /*public int MoviesActorsId { get; set; }
        [ForeignKey("Movies")]
        public int? MovieID { get; set; }
        public Movies? Movie { get; set; }
        [ForeignKey("Actors")]
        public int? ActorID { get; set; }
        public Actors? Actor { get; set; }*/
    }
}
