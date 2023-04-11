

$(document).ready(function () {
    LoadData();
});
function GetRedirectToAddQuestion() {
    window.location.href = '/Questions/Question/AddQuestion';
}
function LoadData() {



    $("#tblQuestions").DataTable().clear();
    $("#tblQuestions").dataTable().fnDestroy();


    table = $('#tblQuestions').DataTable({
        "proccessing": true,
        "serverSide": true,
        "scrollX": true,
        "scrollY": '50vh',
        scroller: true,
        "ajax": {
            url: '/Question/GetQuestionDetails',
            "data": function (d) {
                d.SRNO = "0";
            },
            type: 'POST'
        },
        "columns": [
            {
                "data": "TITLE", "width": "1100px",
                render: function (data, type, row) {
                    return '<div class="container mt-3" ><a onclick="GetPostData(' + row.ASKED_QUESTIONS_ID + ');" href="#"><img border="0" alt="W3Schools" src="https://www.aspsnippets.com/Questions/Images/UserImage.png" width="80" height="80"><b>' + row.TITLE + '</b></a></br><b>Posted By :</b> Amar <b>Replies:</b> 1 <b>Answers:</b> ' + row.ANSWER_COUNT +' <b>Views:</b> ' + row.POST_VIEW +'  in ASP.Net MVC</div >';
                }
            },
        ],
        // "order": [[1, "desc"]]
    });


}

function GetPostData(ASKED_QUESTIONS_ID) {
    window.location.href = '/Questions/Question/ReadQuestion?id=' + ASKED_QUESTIONS_ID;
}
