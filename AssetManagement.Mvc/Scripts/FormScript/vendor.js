$("#parchageManu").show();

$(document).ready(function () {
    var table = $("#vendorTable").dataTable({
        ajax: {
            url: "/Vendors/GetAllVendor",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name",
                render: function (data, type, customer) {
                    return "<a href='/Vendors/Edit/" + customer.Id + "'>" + customer.Name + "</a>";
                }
            },
            {
                data: "ShortName"
            },
            {
                data: "ContactNo"
            },
            {
                data: "Email"
            },
            {
                data: "Address"
            },
            {
                data: "Comments"
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-organization-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });



    $("#vendorTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this Vendor?", function (result) {
            if (result) {
                $.ajax({
                    url: "/Vendors/Delete/" + button.attr("data-organization-id"),
                    method: "post",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});