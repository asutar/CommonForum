/* globals Chart:false, feather:false */

//(function () {
//  'use strict'

//  feather.replace({ 'aria-hidden': 'true' })

//  // Graphs
//  //var ctx = document.getElementById('myChart')
//  //// eslint-disable-next-line no-unused-vars
//  //var myChart = new Chart(ctx, {
//  //  type: 'line',
//  //  data: {
//  //    labels: [
//  //      'Sunday',
//  //      'Monday',
//  //      'Tuesday',
//  //      'Wednesday',
//  //      'Thursday',
//  //      'Friday',
//  //      'Saturday'
//  //    ],
//  //    datasets: [{
//  //      data: [
//  //        15339,
//  //        21345,
//  //        18483,
//  //        24003,
//  //        23489,
//  //        24092,
//  //        12034
//  //      ],
//  //      lineTension: 0,
//  //      backgroundColor: 'transparent',
//  //      borderColor: '#007bff',
//  //      borderWidth: 4,
//  //      pointBackgroundColor: '#007bff'
//  //    }]
//  //  },
//  //  options: {
//  //    scales: {
//  //      yAxes: [{
//  //        ticks: {
//  //          beginAtZero: false
//  //        }
//  //      }]
//  //    },
//  //    legend: {
//  //      display: false
//  //    }
//  //  }
//  //})
//})()

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
            url: '/CreatePost/GetPostDetails',
            "data": function (d) {
                d.SRNO = "0";
            },
            type: 'POST'
        },
        "columns": [
            {
                "data": "TITLE", "width": "800px",
                render: function (data, type, row) {
                    return '<div class="container mt-3" ><a onclick="GetPostData(' + row.SRNO + ');" href="#"><img border="0" alt="W3Schools" src="https://www.aspsnippets.com/Questions/Images/UserImage.png" width="80" height="80"><b>' + row.TITLE + '</b></a></br><b>Posted By :</b> Amar <b>Replies:</b> 1 <b>Answers:</b> ' + row.COMMENT_COUNT + ' <b>Views:</b> ' + row.POST_VIEW + ' in ASP.Net MVC</div >';
                }
            },
        ],
        "buttons": [
            {
                text: 'My button',
                action: function (e, dt, node, config) {
                    alert('Button activated');
                }
            }
        ],
        // "order": [[1, "desc"]]
    });


}
function GetPostData(SRNO) {
    window.location.href = '/Post/CreatePost/PostRead?id=' + SRNO;
}
function GetRedirectToPost() {
    window.location.href = '/Post/CreatePost/Index';
}