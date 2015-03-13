$(document).ready(function () {
    $('.next').on('click', function () {
        var activeSlide = $('.carousel .active');
        var nextSlide = activeSlide.next();
        if (!nextSlide.hasClass('inactive')) {
            nextSlide = $('.carousel img').first();
        }
        activeSlide.removeClass('active');
        activeSlide.addClass('inactive');
        nextSlide.removeClass('inactive');
        nextSlide.addClass('active');
    });
    $('.prev').on('click', function () {
        var activeSlide = $('.carousel .active');
        var nextSlide = activeSlide.prev();
        if (!nextSlide.hasClass('inactive')) {
            nextSlide = $('.carousel img').last();
        }
        activeSlide.removeClass('active');
        activeSlide.addClass('inactive');
        nextSlide.removeClass('inactive');
        nextSlide.addClass('active');
    });
});



