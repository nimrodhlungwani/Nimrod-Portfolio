$(function () {
    try {
        $(window).on("resize", function () {
            try {
                SetControlMinHeight(document.getElementsByTagName('main')[0], $(window).height() - document.getElementsByTagName('header')[0].offsetHeight - document.getElementsByTagName('footer')[0].offsetHeight);
            }
            catch (e) { }
        });

        SetControlMinHeight(document.getElementsByTagName('main')[0], $(window).height() - document.getElementsByTagName('header')[0].offsetHeight - document.getElementsByTagName('footer')[0].offsetHeight);
    } catch (e) { }
});

function SetControlMinHeight(control, minheight) {
    try {
        if (!isNaN(minheight))
            control.style.minHeight = minheight + "px";
    } catch (e) { }
}