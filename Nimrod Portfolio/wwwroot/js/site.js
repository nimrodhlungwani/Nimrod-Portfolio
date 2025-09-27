var navHeight = null;

$(function () {
    try {
        /*=============NavBar=============*/
        const selectedLink = window.location.pathname.toLowerCase();
        navHeight = $("#menu-container").outerHeight();

        $(".navbar-nav .nav-link").each(function () {
            const currentLink = $(this).attr("href").toLowerCase();

            if (currentLink === selectedLink) {
                $(this).addClass("active");
            }
        });

        $(".floating-menu .ripple").each(function () {
            const currentLink = $(this).attr("href").toLowerCase();

            if (currentLink === selectedLink) {
                $(this).addClass("active");
            }
        });

        $(window).on("resize", function () {
            navHeight = $("#menu-container").outerHeight();
            handleScroll();
        });

        $(window).on("scroll", handleScroll);

        $("#scrollup").on("click", function (e) {
            e.preventDefault();
            $("html, body").animate({ scrollTop: 0 }, "slow");
        });

        /*=========Skills typing==========*/
        const selectTyped = document.querySelector('.typed');
        if (selectTyped) {
            let typed_strings = selectTyped.getAttribute('data-typed-items');
            typed_strings = typed_strings.split(',');
            new Typed('.typed', {
                strings: typed_strings,
                loop: true,
                typeSpeed: 100,
                backSpeed: 50,
                backDelay: 2000
            });
        }

        /*=========Scroll to top==========*/
        $(document).on('scroll', function () {

            if ($(window).scrollTop() > 100) {
                $('.scroll-top-wrapper').addClass('show');
            } else {
                $('.scroll-top-wrapper').removeClass('show');
            }
        });

        $('.scroll-top-wrapper').on('click', scrollToTop);

        /*=========Nav Animation Drop Down==========*/
        $(window).on("resize", function () {
            navHeight = $("#menu-container").outerHeight();
            handleScroll();
        });

        $(window).on("scroll", handleScroll);

        /*========Smooth Page Transition ===================*/
        $('a.nav-link, a.ripple').on('click', function (e) {
            const href = $(this).attr('href');
            if (href && href !== '#' && !href.startsWith('http') && !$(this).attr('target')) {
                e.preventDefault();
                $('main[role="main"]').addClass('fade-out');
                setTimeout(() => {
                    window.location.href = href;
                }, 400);
            }
        });

        $('main[role="main"]').removeClass('fade-out');

    } catch (e) {
        console.error("Smooth scroll error:", e);
    }
});

function scrollToTop() {
    verticalOffset = typeof (verticalOffset) != 'undefined' ? verticalOffset : 0;
    element = $('body');
    offset = element.offset();
    offsetTop = offset.top;
    $('html, body').animate({ scrollTop: offsetTop }, 500, 'linear');
}

function handleScroll() {
    if ($(window).scrollTop() > navHeight && $(window).outerWidth() >= 768) {
        $("#menu-container").addClass("scrolled");
        $('main[role="main"]').css('margin-top', navHeight + 'px');
    } else {
        $("#menu-container").removeClass("scrolled");
        $('main[role="main"]').css('margin-top', '0');

        navHeight = $("#menu-container").outerHeight();
    }
}