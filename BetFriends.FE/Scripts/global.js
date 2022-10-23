var sendDataController = function (action, data, callback, msg) {
    console.log("URL: ", document.URL + action + data);
    $.ajax({

        url: document.URL + action,
        data: JSON.stringify(data),
        async: false,
        method: "POST",
       // contentType: "application/json",
       // dataType: "json",
        beforeSend: function () {

        },
        success: function (result) {
            callback(result);
        },
        error: function (result) {
            alert(JSON.stringify(result));
        }
    });
}