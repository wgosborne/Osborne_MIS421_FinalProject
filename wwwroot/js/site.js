//SearchApi

function apiSearch() {
    var params = {
        "q": $("#query").val(), //instead of #query we will attatch it to the name of the search box
        "count": "50",
        "offset": "0",
        "mkt": "en-us"
    };

    $.ajax({
        url: 'https://api.cognitive.microsoft.com/bing/v7.0/books/search?' + $.param(params),
        beforeSend: function (xhrObj) {
            xhrObj.setRequestHeader("Ocp-Apim-Subscription-Key", "37fb1779ae8842aa8c8f457bb20ab011"); //replace this with the key
        },
        type: "GET",
    })
        .done(function (data) {
            len = data.webPages.value.length;
            for (i = 0; i < len; i++) {
                results += "<p><a href='" + data.webPages.value[i].url + "'>" + data.webPages.value[i].name + "</a>: " + data.webPages.value[i].snippet + "</p>";
            }

            $('#searchResults').html(results);
            $('#searchResults').dialog();
        })
        .fail(function () {
            alert("error");
        });
}

function search() {
    //calls api search method
    //let searchVal = $('#query').value;
    $('#searchResults').css("visibility", "visible");
    apiSearch();
}

