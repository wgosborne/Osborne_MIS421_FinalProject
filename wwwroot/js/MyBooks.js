
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
