using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

public class Book //will get filled in with Azure Books data, we can fill these fields w what they give us
{
	public int Id { get; set; }
	[Url]

	public string? HyperLink { get; set; } //Link to the book on the site, so they can click on it
	//public DateTime? StartDate { get; set; }

	//public DateTime? EndDate { get; set; }

	//public double? userRating { get; set; }
	public string? Title { get; set; }

	public string? Author { get; set; }

	public double? AvgRating { get; set; }

	public string? Genre { get; set; }

	public string? Summary { get; set; }

	/*public List<string> Reviews { get; set; }*/ //this may need its own class where we hold the review and who wrote it and the rate then get them here

	//public string? MyReview { get; set; }

	public byte[]? BookPhoto { get; set; }

    [ForeignKey("Genre")]
    public int? GenreId { get; set; }


    /*public List<Book> SimilarBooks { get; set; }*/
    public Book()
	{
		//this.Summary = 
	}
}
