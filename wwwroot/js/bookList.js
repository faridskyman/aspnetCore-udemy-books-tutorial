﻿var dataTable;

$(document).ready(function () {
    loadDataTables();
});

function loadDataTables() {
    dataTable = $("#DT_load").DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            { "data": "name", "width": "30%" },
            { "data": "author", "width": "30%" },
            { "data": "isbn", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/BookList/Upsert?id=${data}" 
                                class="btn btn-success text-white" style="cursor:pointer; width:100px">Edit</a>
                            <a class="btn btn-danger text-white" style="cursor:pointer; width:100px"
                            onClick="Delete('/api/book?id=' + ${data})">Delete</a>
                            </div>`;
                },
                "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found",
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "Once deleted the data is gone...",
        icon: "warning",
        dangerMode: true

    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
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