function GetUserStauts(url)
{
    var status = false;

    $.ajax({
        type: 'GET',
        async: false,
        url: url,
        dataType: "json", 
        cache: false, 
        error: function (e) {
            alert(e);
        },
        success: function (result) {
            status = result;
        }
    });
   
    return status;

}