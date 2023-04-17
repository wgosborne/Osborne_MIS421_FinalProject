
//Carousel and next button
$(document).ready(function () {
    var carousel = $('.carousel-container');
    var books = $('.book');
    var bookWidth = books.outerWidth(true);
    var bookCount = books.length;
    var currentPosition = 0;

    $('.next-button').click(function () {
        if (currentPosition < bookCount - 1) {
            currentPosition++;
            carousel.animate({
                left: -currentPosition * bookWidth
            }, 500);
        }
    });
});

//rendering the book meta data into the box, probably gotta pass in the currBook UNCOMMENT THIS OUT ONCE WE HAVE THE BOOKS
function RenderBookMetaData() {

    //Select the HTML element where we want to render the book information
    const bookData = document.querySelector('#BookMetaData');

    //Creating an HTML template with placeholders for the book properties, gonna need to add a try catch to see if they've rated/finished it
    const html = `
      <p>Date Started: ${book.DateStarted}          Date Finished: ${book.DateFinished}</p>
      <p>Your Rating: ${book.Rating}          Average Rating: ${book.AvRating}</p>
      <p>Similar Reads: ${book.Similar}</p>
      <p>Your Review: ${book.MyReview}</p>
    `;

    //Setting the HTML
    bookData.innerHTML = html;
}
