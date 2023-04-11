
function SignIn() {


    var Email = $("#txtEmail").val();
    var Password = $("#txtPassword").val();

    if (Email == null || Email == '' || Email == undefined || Email == "") {
        toastr.error('Please enter email');
        return false;
    } else {
        if (!isValidEmailAddress(Email)) {
            toastr.error('Please enter valid email');
            return false;
        }
    }

    if (Password == null || Password == '' || Password == undefined || Password == "") {
        toastr.error('Please enter password');
        return false;
    }

    model = {
        "UserName": $("#txtEmail").val(),
        "Password": $("#txtPassword").val(),
    };

    $.ajax({
        type: 'POST',
        url: '/Home/Login',
        data: {
            _loginmodel: model
        },
        dataType: 'JSON',
        success: function (result) {
            //debugger;
            if (result.data.FLAG == 1) {
                    $("#txtEmail").val(''),
                    $("#txtPassword").val('')
                toastr.success('Congratulations! your In');
                window.location.href = '../Dashboard/Dashboard/Index';
            }
            else {
                $("#txtPassword").val('')
                toastr.error('User Name OR Password incorrect.');
                //window.location.href = '/Home/Login';
            }

        },
        error: function (xhr, textStatus, error) {

        }
    });
}
function isValidEmailAddress(emailAddress) {
    var pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;
    return pattern.test(emailAddress);
}
