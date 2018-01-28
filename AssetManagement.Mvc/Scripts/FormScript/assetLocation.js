$("#ogranizationManu").show();

$(document).ready(function () {
    var table = $("#assetLocationTable").dataTable({
        ajax: {
            url: "/AssetLocations/GetAllAssetLocation",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name",
                render: function (data, type, customer) {
                    return "<a href='/AssetLocations/Edit/" + customer.Id + "'>" + customer.Name + "</a>";
                }
            },
            {
                data: "ShortName"
            },
            {
                data: "Organization.Name"
            },
            {
                data: "Branch.Name"
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-branch-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });



    $("#assetLocationTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this branch?", function (result) {
            if (result) {
                $.ajax({
                    url: "/AssetLocations/Delete/" + button.attr("data-branch-id"),
                    method: "post",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});


// organization dropdown and ShortName make Branch Code ******************************
$(document.body).on("change", "#OrganizationId", function() {
    var orgId = $("#OrganizationId").val();
    if (orgId>0) {
        $.ajax({
            type: "GET",
            url: "/AssetLocations/GetBranchByOrgId",
            contentType: "application/json; charset=utf-8",
            data: { orgId: orgId },
            success: function (data) {
                var $el = $("#BranchId");
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

//**********************************************************************

// code auto generate

$(document.body).on("change", "#OrganizationId", function() {
    var orgId = $("#OrganizationId").val();
    if (orgId > 0) {
        $.ajax({
            type: "GET",
            url: "/AssetLocations/GetSingleOrgById",
            contentType: "application/json; charset=utf-8",
            data: { orgId: orgId },
            success: function (data) {

                console.log(data);
                $("#LocationCode").val("");
                $("#LocationCode").val(data.ShortName);
            }
        });
    }
    
});

$(document.body).on("change", "#BranchId", function () {
    var branchId = $("#BranchId").val();
    if (branchId > 0) {
        $.ajax({
            type: "GET",
            url: "/AssetLocations/GetSingleBranchById",
            contentType: "application/json; charset=utf-8",
            data: { branchId: branchId },
            success: function (data) {

                console.log(data);
                var orgShortName=$("#LocationCode").val();
                $("#LocationCode").val(orgShortName+"_"+data.ShortName);
            }
        });
    }

});


