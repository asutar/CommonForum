
function SignUp() {

    var DisplayName = $("#txtDisplayName").val();
    var Email = $("#txtEmail").val();
    var Password = $("#txtPassword").val();

    if (DisplayName == null || DisplayName == '' || DisplayName == undefined || DisplayName == "") {
       // alert("Please enter Display name!");
        toastr.error('Please enter Display name');
        return false;
    }
    
    if (Email == null || Email == '' || Email == undefined || Email == "") {
        //alert("Please enter email!");
        toastr.error('Please enter email');
        return false;
    } else {
        if (!isValidEmailAddress(Email)) {
            toastr.error('Please enter valid email');
            return false;
        }
    }

    if (Password == null || Password == '' || Password == undefined || Password == "") {
        //alert("Please enter password!");
        toastr.error('Please enter password');
        return false;
    }

    model = {
        "UserName": $("#txtDisplayName").val(),
        "Email": $("#txtEmail").val(),
        "Password": $("#txtPassword").val()
    };

    $.ajax({
        type: 'POST',
        url: '/Home/Signup',
        data: {
            _model: model
        },
        dataType: 'JSON',
        success: function (result) {
            //debugger;
            if (result.data == true) {
                $("#txtDisplayName").val(''),
                $("#txtEmail").val(''),
                $("#txtPassword").val('')
                toastr.success('Congratulations! your almost done');
                $('#message').html('<b>Please check your mail to verify mail id</b>');
            }
            else {

            }

        },
        error: function (xhr, textStatus, error) {

        }
    });
}

$("#txtDisplayName").click(function () {
            $('#message').html('');
        });
function isValidEmailAddress(emailAddress) {
    var pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;
    return pattern.test(emailAddress);
}