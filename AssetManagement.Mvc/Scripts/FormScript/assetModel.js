$("#assetSetupManu").show();

$(document).ready(function () {
    var table = $("#assetModelTable").dataTable({
        ajax: {
            url: "/AssetModels/GetAllModel",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name",
                render: function (data, type, customer) {
                    return "<a href='/AssetModels/Edit/" + customer.Id + "'>" + customer.Name + "</a>";
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
                data: "AssetManufacurer.Name"
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



    $("#assetModelTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this Model?", function (result) {
            if (result) {
                $.ajax({
                    url: "/AssetModels/Delete/" + button.attr("data-branch-id"),
                    method: "post",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});



//  dropdown load ******************************
$(document.body).on("change", "#AssetGroupId", function () {
    var groupId = $("#AssetGroupId").val();
    if (groupId > 0) {
        $.ajax({
            type: "GET",
            url: "/AssetModels/GetManufacturerByGroupid",
            contentType: "application/json; charset=utf-8",
            data: { groupId: groupId },
            success: function (data) {
                var $el = $("#AssetManufacurerId");
                $el.empty(); // remove old options
                $el.append($("<option></option>")
                        .attr("value", '').text('Please Select'));
                $.each(data, function (value, key) {
                    //$el.append($("<option></option>")
                    //        .attr("value", value.Id).text(key.Name));

                    $el.append($('<option>', {
                        value: key.Id,
                        text: key.Name
                    }));
                });
            }
        });
    }
});
