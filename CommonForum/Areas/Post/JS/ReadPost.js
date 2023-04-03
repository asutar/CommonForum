

function ReadPost(Post_id) {
    debugger;
    _model = {
        "SRNO": Post_id
    }; 
    $.ajax({
        type: "POST",
        url: '../CreatePost/GetReadPOst',
        dataType: "JSON",
        data:{
            model: _model
        },
        success: function (result) {
            var Jsondata = result.data;
            if (Jsondata != null) {
                $('#hdnSRNO').val(Jsondata[0].SRNO);
                $('#Title').text(Jsondata[0].TITLE);
                $('#txtContent').html(Jsondata[0].POST);
                var CommentCount = ((Jsondata[0].COMMENT_COUNT == '' ? '0' : Jsondata[0].COMMENT_COUNT) || (Jsondata[0].COMMENT_COUNT == undefined ? '0' : Jsondata[0].COMMENT_COUNT) || (Jsondata[0].COMMENT_COUNT == "" ? '0' : Jsondata[0].COMMENT_COUNT))
                $('#spComments').html(CommentCount);
                var PostView = ((Jsondata[0].POST_VIEW == '' ? '0' : Jsondata[0].POST_VIEW) || (Jsondata[0].POST_VIEW == undefined ? '0' : Jsondata[0].POST_VIEW) || (Jsondata[0].POST_VIEW == "" ? '0' : Jsondata[0].POST_VIEW))
                $('#spView').html(PostView);
            }
            else {
            }
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
function GetComment(Post_id) {
    //debugger;
    _model = {
        "POST_ID": Post_id
    };

    $.ajax({
        type: "POST",
        url: '../CreatePost/GetComment',
        dataType: "JSON",
        data: {
            model: _model
        },
        success: function (result) {
            debugger
            var json = result.data;
            //$('#commenttable tr').remove();
            var tr1='';
            //var tr2;
            //var tr3;
            tr1 +="<div class='container mt-3'>";
            //tr1 +="<h2></h2>";
            //Append each row to html table
            for (var i = 0; i < json.length; i++) {
                tr1 +="<div class='media border p-3'>";
                tr1 +="<img src='https://www.w3schools.com/bootstrap4/img_avatar3.png' alt='John Doe' class='mr-3 mt-3 rounded-circle' style='width: 60px;'>";
                tr1 +="<div class='media-body'>";
                tr1 += " <h5>" + json[i].ADDED_BY +" <small><i>Posted on :" + json[i].ADDED_BY_DATETIME+"</i></small></h5>";
                tr1 += "<p>" + json[i].COMMENT +"</p>";
                tr1 +="</div>";
                tr1 += "</div>";
              
                //tr1 = $('<tr/>');
                //tr1.append("<td><b>" + json[i].ADDED_BY + "<b></td>");
                //tr1.append("</br>");
                //tr1.append("<td class='fst-italic fw-light'><b>  Posted On :</b>(" + json[i].ADDED_BY_DATETIME + ")</td>");
                //$('#commenttable').append(tr1);

                //tr2 = $('<tr/>');
                //tr2.append("<td  colspan='2'>----------------------</td>");
                //$('#commenttable').append(tr2);

                //tr3 = $('<tr/>');
                //tr3.append("<td  colspan='2'>" + json[i].COMMENT + "<br/><br/></td>");
                //$('#commenttable').append(tr3);
            }
            tr1 += "</div>";
           
            $('#commenttable').append(tr1);
        }
    });
}