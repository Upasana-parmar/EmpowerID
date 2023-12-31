﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": false,
    "progressBar": true,
    "positionClass": "toast-bottom-right",
    "preventDuplicates": false,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

function ShowMessage(msg, color, title) {

    if (msg instanceof Array) {
        var errorsHtml = "<ul>";
        $.each(msg, function (key, value) {
            errorsHtml += '<li>' + value + '</li>';
        });
        errorsHtml += "</ul>";

        msg = errorsHtml;
    }

    Command: toastr[color](msg, title);
}

