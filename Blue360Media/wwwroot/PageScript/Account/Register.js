

$(document).ready(function () {
    StartProcessing();
    $.ajax({
        url: '/Account/GetUserRole',
        method: 'GET',
        data: {},
        success: function (response) {
            StopProcessing();
            $.each(response, function (index, item) {
                $('#userrole').append('<option value="' + item.value + '">' + item.text + '</option>');
            });
        }
    })
}) 




$('.Register').click(function () {
    debugger;
    if ($('#firstname').val() == "" || $('#firstname').val() == null) {
        Swal.fire('', "Please Enter First Name.", 'error');
        $('#firstname').focus();
        return false;
    }

    else if ($('#lastname').val() == "" || $('#lastname').val() == null) {
        Swal.fire('', "Please Enter Last Name.", 'error');
        $('#lastname').focus();
        return false;
    }


    else if ($('#email').val() == "" || $('#email').val() == null) {
        Swal.fire('', "Please Enter Email.", 'error');
        $('#email').focus();
        return false;
    }
    else if ($('#password').val() == "" || $('#password').val() == null) {
        Swal.fire('', "Please Enter Password.", 'error');
        $('#password').focus();
        return false;
    }
    else if ($('#cpassword').val() == "" || $('#cpassword').val() == null) {
        Swal.fire('', "Please Enter Confirm Password.", 'error');
        $('#cpassword').focus();
        return false;
    }
    else if ($('#email').val() != null || $('#email').val() != "") {

        var email = $('#email').val();
        var regex = new RegExp('[a-z0-9]+@[a-z]+\.[a-z]{2,3}');
        if (email != "" && email != null) {
            if (regex.test(email)) {
                  if ($('#password').val() != null || $('#password').val() != "") {
                      var password = $('#password').val();
                    var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
                    if (password != "" && password != null) {
                        if (strongRegex.test(password)) {
                           if ($('#cpassword').val() != "" || $('#cpassword').val() != null) {
                                var password = $('#password').val();
                                var cpassword = $('#cpassword').val();
                                if (password != "" && cpassword != "") {
                                    if (password == cpassword) {
                                         if ($('#email').val() != "" || $('#email').val() != null) {
                                            StartProcessing();
                                            $.ajax({
                                                url: '/Account/SaveUserDetail',
                                                method: 'GET',
                                                data: {
                                                    'FirstName': $('#firstname').val(),
                                                    'LastName': $('#lastname').val(),
                                                    'RoleId': $('#userrole').val(),
                                                    'Email': $('#email').val(),
                                                    'Password': $('#password').val()
                                                },
                                                success: function (response) {
                                                    StopProcessing();
                                                    if (response == true) {
                                                        Swal.fire({
                                                            title: 'User Registered Successfully.....',
                                                            showClass: {
                                                                popup: 'animate__animated animate__fadeInDown'
                                                            },
                                                            hideClass: {
                                                                popup: 'animate__animated animate__fadeOutUp'
                                                            }
                                                        })
                                                        $('#firstname').val(' ');
                                                        $('#lastname').val(' ');
                                                        $('#email').val(' ');
                                                        $('#password').val(' ');
                                                        $('#cpassword').val(' ');
                                                        $('#userrole').val('0');
                                                    }
                                                    else {
                                                        /*  Swal.fire('', "Some error occurred.", 'error');*/
                                                        Swal.fire('', "This Email Already Exist", 'error');
                                                        $('#email').val(' ');
                                                        $('#email').focus();
                                                        return false;
                                                    }
                                                }
                                            })
                                        }
                                    }
                                    else {
                                        /*  $('#password_match').text('Password and Confirm Password is not matched.');*/
                                        Swal.fire('', 'Password and Confirm Password is not matched.', 'error');
                                        return false;
                                    }
                                }
                            }
                        }
                        else {
                            /*  $('#password_msg').text('Please Enter Strong Password');*/
                            Swal.fire('', 'Please Enter Strong Password', 'error');
                            $('#password').val();
                            return false;
                        }
                    }
                }
            }
            else {
                Swal.fire('', 'Please Enter Valid Email', 'error');
                $('#email').focus();
                $('#email').val(' ');
                return false;
            }
        }
    }
    //else if ($('#password').val() != null || $('#password').val() != "")
    //{
    //    var password = $(obj).val();
    //    var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
    //    if (password != "" && password != null) {
    //        if (strongRegex.test(password)) {
    //           /* return true;*/
    //        }
    //        else {
    //            /*  $('#password_msg').text('Please Enter Strong Password');*/
    //            Swal.fire('', 'Please Enter Strong Password', 'error');
    //            $('#password').val();
    //            return false;
    //        }
    //    }
    //}
    //else if ($('#cpassword').val()!="" || $('#cpassword').val()!= null) 
    //{
    //    var password = $('#password').val();
    //    var cpassword = $('#cpassword').val();
    //    if (password != "" && cpassword != "") {
    //        if (password == cpassword) {
    //            /* $('#password_match').text(' ');*/
    //          /*  return true;*/
    //        }
    //        else {
    //            /*  $('#password_match').text('Password and Confirm Password is not matched.');*/
    //            Swal.fire('', 'Password and Confirm Password is not matched.', 'error');
    //            return false;
    //        }
    //    }
    //}

    



    //else if ($('#email').val() != "" || $('#email').val() != null) {
    //    StartProcessing();
    //    $.ajax({
    //        url: '/Account/SaveUserDetail',
    //        method: 'GET',
    //        data: {
    //            'FirstName': $('#firstname').val(),
    //            'LastName': $('#lastname').val(),
    //            'RoleId': $('#userrole').val(),
    //            'Email': $('#email').val(),
    //            'Password': $('#password').val()
    //        },
    //        success: function (response) {
    //            StopProcessing();
    //            if (response == true) {
    //                Swal.fire({
    //                    title: 'User Registered Successfully.....',
    //                    showClass: {
    //                        popup: 'animate__animated animate__fadeInDown'
    //                    },
    //                    hideClass: {
    //                        popup: 'animate__animated animate__fadeOutUp'
    //                    }
    //                })
    //                $('#firstname').val(' ');
    //                $('#lastname').val(' ');
    //                $('#email').val(' ');
    //                $('#password').val(' ');
    //                $('#cpassword').val(' ');
    //                $('#userrole').val('0');
    //            }
    //            else {
    //                /*  Swal.fire('', "Some error occurred.", 'error');*/
    //                Swal.fire('', "This Email Already Exist", 'error');
    //                $('#email').val(' ');
    //                $('#email').focus();
    //                return false;
    //            }
    //        }
    //    })
    //}
})


function CheckPasswordStrength(obj) {
    debugger;
    var password = $(obj).val();
    var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
    if (password != "" && password != null) {
        if (strongRegex.test(password)) {
            /*$('#password_msg').text(' ');*/
        }
        else {
            /*  $('#password_msg').text('Please Enter Strong Password');*/
            Swal.fire('', 'Please Enter Strong Password', 'error');
            $('#password').val();
            return false;
        }
    }
}

function MatchPassword() {
    debugger;
    var password = $('#password').val();
    var cpassword = $('#cpassword').val();
    if (password != "" && cpassword != "") {
        if (password == cpassword) {
           /* $('#password_match').text(' ');*/
        }
        else {
            /*  $('#password_match').text('Password and Confirm Password is not matched.');*/
            Swal.fire('', 'Password and Confirm Password is not matched.', 'error');
            return false;
        }
    }
}