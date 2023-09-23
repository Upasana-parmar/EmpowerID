$(".delete").click(function (e) {
    var id = parseInt($(this).attr("data-id"));
    let text = "Are you sure you want to delete?";
    if (confirm(text) == true) {
        $.ajax({
            type: 'POST',
            url: 'employee/delete/' + id,
            dataType: 'json',
            success: function (result) {
                ShowMessage(e.message, e.color, "");
                setTimeout(function () {
                    location.href = e.url;
                }, 1000);
            }
        });
    }
});

function Search(input) {
    var value = $(input).val();
    if(value.length > 3)
    location.href = "/home/" + value;
}