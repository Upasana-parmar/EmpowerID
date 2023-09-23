$("#AddEmployee").validate({
    rules: {
        Email: {
            required: true,
            email: true
        }
    },
    submitHandler: function (form) {
        event.preventDefault();
        $(form).ajaxSubmit((e) => {
            ShowMessage(e.message, e.color, "");            
            if (e.isSuccess) {
                setTimeout(function () {
                    location.href = e.url;
                },1000);
            }
        });
    }
});


$("#btnCancle").click(function () {
    location.href = "/";
});
