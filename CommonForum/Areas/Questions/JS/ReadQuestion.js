

function ReadQuestion(Post_id) {
    //debugger;
    _model = {
        "ASKED_QUESTIONS_ID": Post_id
    };
    $.ajax({
        type: "POST",
        url: '../Question/GetQuestionDetails',
        dataType: "JSON",
        data: {
            SRNO: Post_id
        },
        success: function (result) {
            var Jsondata = result.data;
            if (Jsondata != null) {
                $('#hdnSRNO').val(Jsondata[0].ASKED_QUESTIONS_ID);
                $('#Title').text(Jsondata[0].TITLE);
                $('#txtContent').html(Jsondata[0].STOPPER_DETAILS);
                var CommentCount = ((Jsondata[0].ANSWER_COUNT == '' ? '0' : Jsondata[0].ANSWER_COUNT) || (Jsondata[0].ANSWER_COUNT == undefined ? '0' : Jsondata[0].ANSWER_COUNT) || (Jsondata[0].ANSWER_COUNT == "" ? '0' : Jsondata[0].ANSWER_COUNT))
                $('#spComments').html(CommentCount);
                var PostView = ((Jsondata[0].POST_VIEW == '' ? '0' : Jsondata[0].POST_VIEW) || (Jsondata[0].POST_VIEW == undefined ? '0' : Jsondata[0].POST_VIEW) || (Jsondata[0].POST_VIEW == "" ? '0' : Jsondata[0].POST_VIEW))
                $('#spView').html(PostView);
            }
            else {
            }
        }
    });
}

function PostAnswer() {

    var Post = CKEDITOR.instances.txtComment.getData();

    model = {
        "ASKED_QUESTIONS_ID": $('#hdnASKED_QUESTIONS_ID').val(),
        "ANSWER": Post,
        "USER_NAME": ""
    };

    $.ajax({
        type: 'POST',
        url: '../Question/PostAnswer',
        data: {
            _model: model
        },
        dataType: 'JSON',
        success: function (result) {
            //debugger;
            if (result == true) {
                CKEDITOR.instances.txtComment.setData('');
                alert("Question Created Sucessfully!");
                var ASKED_QUESTIONS_ID = $('#hdnASKED_QUESTIONS_ID').val();
                GetAnswer(ASKED_QUESTIONS_ID);
            }
            else {

            }

        },
        error: function (xhr, textStatus, error) {

        }
    });
}

function Postcomment() {
    _model = {
        "POST_ID": $('#hdnSRNO').val(),
        "COMMENT": $('#txtComment').val()
    };
    $.ajax({
        type: "POST",
        url: '../CreatePost/PostComment',
        dataType: "JSON",
        data: {
            model: _model
        },
        success: function (result) {
            //  var Jsondata = result.data;
            $('#txtComment').val('');
            var POSTID = $('#hdnSRNO').val();
            GetComment(POSTID);
        }
    });
}
function GetAnswer(Post_id) {
    //debugger;
    _model = {
        "ASKED_QUESTIONS_ID": Post_id
    };

    $.ajax({
        type: "POST",
        url: '/Answers/Answer/GetAnswers',
        dataType: "JSON",
        data: {
            model: _model
        },
        success: function (result) {
            debugger
            var json = result.data;
            //$('#commenttable tr').remove();
            $('#commenttable').empty();
            var tr1 = '';
            //var tr2;
            //var tr3;
            tr1 += "";
            tr1 += "";
            tr1 += "";
            tr1 += "";

           
            //tr1 +="<h2></h2>";
            //Append each row to html table
            for (var i = 0; i < json.length; i++) {
                tr1 += "<div class='container border py-3 my-3'>";
                if (i == 0) {
                    tr1 += "<h5>Answer : 1</h5>";
                } else {
                    var j = i + 1;
                    tr1 += "<h4>Answer : " + j +"</h4>";
                }
                tr1 += "</div>";

                tr1 += "<div class='media border p-3'>";
                tr1 += "<img src='https://www.w3schools.com/bootstrap4/img_avatar3.png' alt='John Doe' class='mr-3 mt-3 rounded-circle' style='width: 60px;'>";
                tr1 += "<div class='media-body'>";
                tr1 += " <h5>" + json[i].USER_NAME + " <small><i>Posted on :" + json[i].ADDED_DATETIME + "</i></small></h5>";
                tr1 += "<p>" + json[i].ANSWER + "</p>";
                tr1 += "</div>";
                tr1 += "</div>";
            }
            tr1 += "</div>";

            $('#commenttable').append(tr1);
        }
    });
}