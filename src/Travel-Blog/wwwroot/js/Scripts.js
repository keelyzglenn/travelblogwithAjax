$(document).ready(function () {
    $('.new-suggestion').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: 'Suggestion/Create',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {

                var resultReturn = result.destination;
                $('#suggestion-list').append("<p>"+resultReturn+"</p>");

            }
        });
    });

    $('.search-bar').submit(function (event) {
        event.preventDefault();
        console.log("working!")
        $.ajax({
            url: 'Suggestion/Search',
            type: 'GET',
            data: $(this).serialize(),
            dataType: 'json',
            success: function (result) {
                console.log(result);
                var stringResult = "";
                for (var i=0; i < result.length; i++)
                {
                    console.log(result[i].destination);
                    stringResult += "<p>" + result[i].destination + "</p>";
                }
                $("#search-result").html(stringResult);
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