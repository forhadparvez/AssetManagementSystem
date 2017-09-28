$(document).ready(function () {
    $("#assetSetupManu").show();
});


$(document).ready(function () {
    var table = $("#assetGroupTable").dataTable({
        ajax: {
            url: "/AssetGroups/GetAllAssetGroupWithType",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name",
                render: function (data, type, customer) {
                    return "<a href='/AssetGroups/Edit/" + customer.Id + "'>" + customer.Name + "</a>";
                }
            },
            {
                data: "ShortName"
            },
            {
                data: "GroupCode"
            },
            {
                data: "AssetType.Name"
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-branch-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });



    $("#assetGroupTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this Asset Group?", function (result) {
            if (result) {
                $.ajax({
                    url: "/AssetGroups/Delete/" + button.attr("data-branch-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});