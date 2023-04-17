namespace _521Final.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string ReviewString { get; set; }

        public int Rating { get; set; }

        public DateTime DatePosted { get; set; }

        public string OP { get; set; }

        //we could also do something about whether it has likes or dislikes if we want
    }
}
