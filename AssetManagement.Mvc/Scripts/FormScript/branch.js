$("#ogranizationManu").show();

$(document).ready(function () {
    var table = $("#branchTable").dataTable({
        ajax: {
            url: "/Branchs/GetAllBranch",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name",
                render: function (data, type, customer) {
                    return "<a href='/Branchs/Edit/" + customer.Id + "'>" + customer.Name + "</a>";
                }
            },
            {
                data: "ShortName"
            },
            {
                data: "BranchCode"
            },
            {
                data: "Organization.Name"
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-branch-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });



    $("#branchTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this branch?", function (result) {
            if (result) {
                $.ajax({
                    url: "/Branchs/Delete/" + button.attr("data-branch-id"),
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
var orgShortName = "";
$(document.body).on("change", "#OrganizationId", function () {
    organizationDropdown();
});


function organizationDropdown() {
    var orgnationId = $("#OrganizationId").val();
    if (orgnationId > 0) {
        $.ajax({
            type: "GET",
            url: "/Branchs/GetSingleOrganizationbyId",
            contentType: "application/json; charset=utf-8",
            data: { id: orgnationId },
            success: function (data) {
                orgShortName = "";
                orgShortName = data.ShortName;
                $("#BranchCode").val(orgShortName);

            }
        });
    }
}

$(document.body).on("change", "#ShortName", function () {
    var branchId = $("#Id").val();
    if (branchId > 0) {
        organizationDropdown();
        var orgShortName2 = $("#BranchCode").val();
        var shortName2 = $("#ShortName").val();
        $("#BranchCode").val(orgShortName2 + "_" + shortName2);

    } else {
        var shortName = $("#ShortName").val();
        $("#BranchCode").val("");
        $("#BranchCode").val(orgShortName + "_" + shortName);
    }

});

//**********************************************************************