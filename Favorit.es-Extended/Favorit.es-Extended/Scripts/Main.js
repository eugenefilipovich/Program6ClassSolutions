//$(document).ready(function () {
//    // a tags have an event associated with them , so we'll represent that with a parameter called event
//    $('body').on('click', '.photo a', function (event) {
//        // when we click on a <a> under an element with the class of photo, do this...

//        // we want to prevent the default behaviour of the <a> tag
//        event.preventDefault();

//        var theATag = $(this);
//        // for theATag object, we want the value of the attr href
//        var theATagsHREF = theATag.attr('href');
//        // make an AJAX request

//        $.get(theATagsHREF, function (data) {
//            if(data == "OK") {
//                // everyhing worked great, expected response was OK
//                theATag.children('div').addClass('heart');
//            }
//        });
//    });

//    $('body').on('click', '.favorite a', function (event) {
//        event.preventDefault();

//        var thePhotoToRemove = $(this);
//        var thePhotoToRemoveHREF = thePhotoToRemove.attr('href');

//        $.get(thePhotoToRemoveHREF, function (data) {
//            if (data == "OK") {
//                thePhotoToRemove.children('div').removeClass('heart');
//            }
//        });
//    });
//});

$(document).ready(function () {
    $('body').on('click', '.photo a, .favorite a', function (event) {
        // do an AJAX get request to the href. based on the response, either add or remove the heart class from the child div
        event.preventDefault();
        var theATag = $(this);

        var theATagsHREF = theATag.attr('href');
        $.get(theATagsHREF, function (data) {
            if (data == "favorited") {
                theATag.children('div').addClass('heart');
        }
        else if 
            (data == "unfavorited") {
                theATag.children('div').removeClass('heart');
        }
    });
    });
});

// Shorter way
//$('body').on('click', '.photo a, .favorite a', function (event) {
//    //do an AJAX get request to the HREF based on the response, either add or remove the heart class from the child div
//    event.preventDefault();

//    var thePhotoClicked = $(this);

//    $.get($(this).attr('href'), function (data) {
//        thePhotoClicked.children('div').toggleClass('heart');

//    });

//});