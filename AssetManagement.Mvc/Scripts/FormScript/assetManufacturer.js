$("#assetSetupManu").show();

//=====================start Index==========================
$(document).ready(function () {
    var table = $("#assetManufacturerTable").dataTable({
        ajax: {
            url: "/AssetManufacturers/GetAllManufacturer",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name",
                render: function (data, type, customer) {
                    return "<a href='/AssetManufacturers/Edit/" + customer.Id + "'>" + customer.Name + "</a>";
                }
            },
            {
                data: "ShortName"
            },
            {
                data: "Code"
            },
            {
                data: "AssetGroup.Name"
            },
            {
                data: "Description"
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-branch-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });



    $("#assetManufacturerTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this Manufacturer?", function (result) {
            if (result) {
                $.ajax({
                    url: "/AssetManufacturers/Delete/" + button.attr("data-branch-id"),
                    method: "post",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});