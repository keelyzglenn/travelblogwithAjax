$(document).ready(function () {
    $('.new-suggestion').submit(function (event) {
        event.preventDefault();
        console.log("working!");
        $.ajax({
            url: 'Suggestion/Create',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                var resultReturn = result.destination;
                $('#suggestion-list').append("<p>"+resultReturn+"</p>");

            }
        });
    });

    $('.hello-ajax').click(function () {
        $.ajax({
            type: 'GET',
            url: '@Url.Action("HelloAjax")',
            success: function (result) {
                $('#result1').html(result);
            }
        });
    });
});