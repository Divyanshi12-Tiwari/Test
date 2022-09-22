


$('.LoginButton').click(function () {
    if ($('#email').val() == "" || $('#email').val() == null) {
        Swal.fire('', "Please Enter User Id.", 'error');
        $('#email').focus();
        return false;
    }
    else if ($('#password').val() == "" || $('#password').val() == null) {
        Swal.fire('', "Please Enter Password.", 'error');
        $('#password').focus();
        return false;
    }
    StartProcessing();
    $.ajax({
        url: '/Account/Authenticate',
        method: 'GET',
        data: {
            'UserId': $('#email').val(),
            'Password': $('#password').val()
        },
        success: function (response) {
            if (response == true) {
                window.location.href = "/state/list"
            }
            else {
                StopProcessing();
                Swal.fire('Login failed', "Incorrect email id or password.", 'error');
            }
        }
    })
});


function login() {
   /* debugger;*/
    if ($('#txt_userid').val() == "" || $('#txt_userid').val() == null) {
        alert("Please Enter User Id");
        Swal.fire('Login failed', "Please Enter User Id", 'error');
        $('#txt_userid').focus();
        return false;
    }
    else if ($('#txt_password').val() == "" || $('#txt_password').val() == null) {
        alert("Please Enter Password");
        Swal.fire('Login failed', "Please Enter Password", 'error');
        $('#txt_password').focus();
        return false;
    }
    /*StartProcessing();*/
    $.ajax({
        url: '/Account/Authenticate',
        method: 'GET',
        data: {
            'UserId': $('#txt_userid').val(),
            'Password': $('#txt_password').val()
        },
        success: function (response) {
           /* StopProcessing();*/
            //$.each(response, function (index, item) {
            //    $('#txt_StateCode').append('<option value="' + item.value + '">' + item.text + '</option>');
            //});
            if (response == true) {
                window.location.href = "/state/list"
            }
        }
    })
}