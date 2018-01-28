
$("#ogranizationManu").show();

$(document).ready(function () {
    var table = $("#organizationTable").dataTable({
        ajax: {
            url: "/Organizations/GetAllOrganization",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name",
                render: function (data, type, customer) {
                    return "<a href='/Organizations/Edit/" + customer.Id + "'>" + customer.Name + "</a>";
                }
            },
            {
                data: "ShortName"
            },
            {
                data: "Location"
            },
            {
                data: "Description"
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-organization-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });



    $("#organizationTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this Organization?", function (result) {
            if (result) {
                $.ajax({
                    url: "/Organizations/Delete/" + button.attr("data-organization-id"),
                    method: "post",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});