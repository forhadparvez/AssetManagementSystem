$(document).ready(function () {
    $("#assetSetupManu").show();
});



$(document).ready(function () {
    var table = $("#assetTypeTable").dataTable({
        ajax: {
            url: "/AssetTypes/GetAllAssetType",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name",
                render: function (data, type, assetType) {
                    return "<a href='/AssetTypes/Edit/" + assetType.Id + "'>" + assetType.Name + "</a>";
                }
            },
            {
                data: "ShortName"
            },
            {
                data: "Location"
            },
            {
                data: "Code"
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-organization-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });



    $("#assetTypeTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this Asset Type?", function (result) {
            if (result) {
                $.ajax({
                    url: "/AssetTypes/Delete/" + button.attr("data-organization-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});
