﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
    /*loadRoles();*/
});

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": {
            "url": "/LeaveAllocations/GetAll",
            "dataSrc": "data" // Assuming the JSON data is wrapped in a "data" key
        },
        "columns": [
            { "data": "firstname", "width": "15%" },
            { "data": "lastname", "width": "15%" },
            { "data": "email", "width": "30%" },
            { "data": "role", "width": "15%" },
            
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/leaveAllocations/Details/${data}" class="btn btn-outline-info" style="cursor:pointer">
                                <i class="fas fa-eye"></i>
                            </a>
                        </div>
                    `;
                },
                "width": "10%"
            }
        ],
        "language": {
            "emptyTable": "No data found"
        },
        "width": "100%"
    });
}


//function loadRoles() {
//    $.ajax({
//        url: "/LeaveAllocations/GetAllRoles",
//        type: 'GET',
//        success: function (data) {
//            // Populate roles dropdown
//            $.each(data, function (index, item) {
//                $('#role').append('<option value="' + item + '">' + item + '</option>');
//            });
//        }
//    });
//}

    









function Delete(url) {
    swal.fire({
        title: 'Are you sure you want to Delete?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        buttons: true,
        dangerMode: true,
        showCancelButton: true,
        showCloseButton: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.warning(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}