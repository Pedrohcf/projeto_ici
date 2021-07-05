$(document).ready(function () {
    $(".alert-success").delay(1000).fadeOut(3000);
    $("#toast").delay(1000).fadeOut(4000);
});
//function addToast(text) {
//    if (text == null)
//        return;

//    var toast2 = $("#toast");
//    toast2.removeClass("show-toast");
//    toast2.addClass("show-toast");

//    var toast = document.getElementById("toast");
//    toast.children[0].textContent = text;
//    var novoToast = toast.cloneNode(true);
//    toast.parentNode.replaceChild(novoToast, toast);
//}
