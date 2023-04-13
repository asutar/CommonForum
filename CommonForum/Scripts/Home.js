$(document).ready(function () {
    LoadData();
});
function LoadData() {

    $("#tblPostDetails").DataTable().clear();
    $("#tblPostDetails").dataTable().fnDestroy();


    table = $('#tblPostDetails').DataTable({
        "proccessing": true,
        "serverSide": true,
        "scrollX": true,
        "scrollY": '50vh',
        scroller: true,
        "ajax": {
            url: '/Home/GetPostDetails',
            "data": function (d) {
                d.SRNO = "0";
            },
            type: 'POST'
        },
        "columns": [
            {
                "data": "TITLE", "width": "1000px",
                render: function (data, type, row) {
                    return '<div class="container mt-3" ><a onclick="GetPostData(' + row.SRNO + ');" href="#"><img border="0" alt="W3Schools" src="https://www.aspsnippets.com/Questions/Images/UserImage.png" width="80" height="80"><b>' + row.TITLE + '</b></a></br><b>Posted By :</b> ' + row.ADDED_BY + ' <b>Date:</b> ' + row.ADDED_DATE + ' <b>Answers:</b> ' + row.COMMENT_COUNT + ' <b>Views:</b> ' + row.POST_VIEW + ' in ' + row.TOPICS + '</div >';
                }
            },
        ],
        // "order": [[1, "desc"]]
    });


}

function LoadQuestionsData() {



    $("#tblQuestions").DataTable().clear();
    $("#tblQuestions").dataTable().fnDestroy();


    table = $('#tblQuestions').DataTable({
        "proccessing": true,
        "serverSide": true,
        "scrollX": true,
        "scrollY": '50vh',
        scroller: true,
        "ajax": {
            url: '/AskQuestion/GetQuestionDetails',
            "data": function (d) {
                d.SRNO = "0";
            },
            type: 'POST'
        },
        "columns": [
            {
                "data": "TITLE", "width": "1000px",
                render: function (data, type, row) {
                    return '<div class="container mt-3" ><a onclick="GetPostData(' + row.ASKED_QUESTIONS_ID + ');" href="#"><img border="0" alt="W3Schools" src="https://www.aspsnippets.com/Questions/Images/UserImage.png" width="80" height="80"><b>' + row.TITLE + '</b></a></br><b>Posted By :</b> ' + row.ADDED_BY + ' <b>Date:</b> ' + row.ADDED_BY_DATETIME + ' <b>Answers:</b> ' + row.ANSWER_COUNT + ' <b>Views:</b> ' + row.POST_VIEW + '  in ' + row.TOPICS + '</div >';
                }
            },
        ],
        // "order": [[1, "desc"]]
    });


}
function GetPostData(SRNO) {
    window.location.href = '/ReadPost/Index?id=' + SRNO;
}

function GetRedirectToQuestion() {
    window.location.href = '/AskQuestion/Index';
}
function GetQuestionData(SRNO) {
    window.location.href = '/ReadQuestion/Index?id=' + SRNO;
}