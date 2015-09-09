var width = $('.previews').width() / 3;
$('.previews').bxSlider({
    pager: false,
    slideWidth: width,
    minSlides: 3,
    maxSlides: 3,
    slideMargin: 10,
    easing: 'ease-in-out-circ'
});