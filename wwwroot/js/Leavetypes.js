var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/LeaveTypes/GetAll"
        },
        "columns": [
            { "data": "name", "width": "40%" },
            { "data": "defaultDays", "width": "40%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/leaveTypes/Create/${data}" class="btn btn-warning text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                
                                <a onclick=Delete("/leaveTypes/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}


function Delete(url) {
    $.ajax({
        type: "DELETE",
        url: url,
        success: function (data) {
            if (data.success) {
                toastr.warning(data.message);
                dataTable.ajax.reload();
            } else {
                toastr.error(data.message);
            }
        },
        error: function (err) {
            toastr.error("An error occurred while trying to delete.");
        }
    });
}