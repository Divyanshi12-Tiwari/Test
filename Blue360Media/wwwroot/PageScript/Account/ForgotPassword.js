$('.forgotpassword').click(function () {
    if ($('#emailInput').val() == null || $('#emailInput').val() == "") {
        Swal.fire('', "Please Enter Email", 'error');
        $('#emailInput').focus();
        return false;
    }
    else {
        StartProcessing();
        $.ajax({
            url: '/Account/GetForgotPassword',
            method: 'GET',
            data: {
                'emailID': $('#emailInput').val(),
            },
            success: function (response) {
                StopProcessing();
                if (response == true) {
                  
                    $('#emailInput').val(' ');
                   /* window.location.href = "/Account/SignIn";*/
                    Swal.fire('', "Your Password is send on your email.", 'success');
                }
                else {
                    Swal.fire('', "Some error occurred", 'error');
                }
            }
        })
    }
})