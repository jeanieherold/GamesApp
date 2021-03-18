//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your Javascript code.

//$(document).ready(function () {

//    var sessionUsername;

//    fetch('/players')
//        .then(res => {
//            console.log(res);
//            if (!res.ok) {
//                throw Error("Not OK");
//            }
//            return res.json();
//        })
//        .then(data => {
//            console.log(data[0].userName);
//            sessionUsername = data[0].userName;
//            sessionStorage.setItem("username", sessionUsername);
//        })   
//        .catch (error => {
//            console.log(error)
//        });

//    if (window.sessionStorage && window.sessionStorage.getItem(sessionUsername)) {
//        $('#playerUsername').html(sessionUsername);
//    }

//});


