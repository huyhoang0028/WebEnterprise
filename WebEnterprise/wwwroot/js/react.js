/*$(function () {
    // handle the reaction form submission
    $('form').on('submit', function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            method: 'POST',
            data: $(this).serialize(),
            success: function (response) {
                // update the UI with the new number of reactions
                var count = response.reactions.length;
                $('.reactions-count').text(count);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error(errorThrown);
            }
        });
    });
});
*/
$(document).ready(function () {
    $('.reaction-button').click(function () {
        // Remove active class from all other reaction buttons
        $('.reaction-button').not(this).removeClass('active');

        // Toggle active class on the clicked button
        $(this).toggleClass('active');
    });
});

