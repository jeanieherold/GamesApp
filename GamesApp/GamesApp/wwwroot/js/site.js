// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {

    var cardwidth = $('.faces img').width();
    $('.faces').css({ 'height': cardwidth + 'px' });

    let wrapper = document.querySelector(".wrapper");
    let parentCard = document.querySelector(".memory-card");

    let cards = gsap.utils.toArray(".memory-card > .faces");

    cards.forEach(function (card, index) {

        let animation = gsap.timeline()
        animation.to(card, { rotationY: 180 })
        animation.progress(1)

        card.animation = animation
        card.addEventListener("click", function () {
            card.animation.reversed(!card.animation.reversed())
        });
    });


    gsap.set(wrapper, { autoAlpha: 1 });
    gsap.from(".memory-card", { opacity: 0, stagger: 0.2 });
});

