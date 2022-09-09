var dataTable;

$(document).ready(function () {
    var status = "all"
    var url = window.location.search;
    if (url.includes("inprocess")) {
        status = "inprocess";
    }
    else if (url.includes("completed")) {
        status = "completed";
    }
    else if (url.includes("pending")) {
        status = "pending";
    }
    else if (url.includes("approved")) {
        status = "approved";
    }
    else { }
    loadDataTable(status)
})

function loadDataTable(status) {
    dataTable = $('#Table').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "name", "width": "25%" },
            { "data": "applicationUser.phoneNumber", "width": "15%" },
            { "data": "applicationUser.email", "width": "15%" },
            { "data": "orderStatus", "width": "15%" },
            { "data": "orderTotal", "width": "15%" },
            {
                "data": "id", "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/Admin/Order/Details?OrderId=${data}" class=" mx-2"> <i class="bi bi-pencil-square"></i></a>
                        </div>
                    `
                },"width": "10%" },
        ]
    });
}
