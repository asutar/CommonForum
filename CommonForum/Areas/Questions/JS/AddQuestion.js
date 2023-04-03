function AskQuestion() {

    var Post = CKEDITOR.instances.txtStopperDetails.getData();
    var arrddlTopics = $('#ddltopics').val();
    var arrDepotCodeList = [];

    for (var i = 0; i < arrddlTopics.length; i++) {
        arrDepotCodeList.push({
            TOPICS_ID: arrddlTopics[i]
        });
    }

    model = {
        "TITLE": $("#txtTitle").val(),
        "STOPPER_DETAILS": Post,
        "TOPICS_ID": arrDepotCodeList
    };

    $.ajax({
        type: 'POST',
        url: '/Question/AskQuestion',
        data: {
            _model: model
        },
        dataType: 'JSON',
        success: function (result) {
            //debugger;
            if (result == true) {
                $('#ddltopics').empty();
                alert("Question Created Sucessfully!");
            }
            else {

            }

        },
        error: function (xhr, textStatus, error) {

        }
    });
}
function GetTopics() {
    var ddlId = '#ddltopics';
    _model = {
        "TOPICS_ID": 0,
    };

    $.ajax({
        type: 'POST',
        url: '/CreatePost/GetTopics',
        data: {
            model: _model
        },
        dataType: 'JSON',
        success: function (result) {
            $(ddlId).empty();
            //debugger;
            $.each(result.data, function (i, item) {

                $(ddlId).append($('<option data-RoleId = "' + item.TOPICS_ID + '"/>').val(item.TOPICS_ID).text(item.TOPIC));
            });

            $(ddlId).select2();
        },
        error: function (xhr, textStatus, error) {

        }
    });
}