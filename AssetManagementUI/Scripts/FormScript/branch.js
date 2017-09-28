//$(document.body).on("click", "#createLink", function () {
//    var url = "/Branchs/Create";
//    $.get(url, function (responseData) {
//        $("#createMainBody").html(responseData);
//    });
//});


$(document).ready(function () {
    $("#organizationManu").show();
});

// ****************************** Index Page *****************************************

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
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});


$(document).ready(function () {
    var vm = {};

    var validator = $("#saveButton").click({
        submitHandler: function () {

            vm.OrganizationName = $("#OrganizationId").val;
            vm.Name = $("#Name").val;
            vm.ShortName = $("#ShortName").val;
            vm.BranchCode = $("#BranchCode").val;


            $.ajax({
                    url: "/Api/Branchs",
                    method: "POST",
                    data: vm
                })
                .done(function () {
                    toastr.success("Success fully Save");
                })
                .fail(function () {
                    toastr.error("Save fail");
                });
            return false;
        }
    });
});

// ****************************** End Index Page *****************************************


// organization dropdown and ShortName make Branch Code ******************************
var orgShortName = "";
$(document.body).on("change", "#Branch_OrganizationId", function() {
    organizationDropdown();
});


function organizationDropdown() {
    var orgnationId = $("#Branch_OrganizationId").val();
    if (orgnationId > 0) {
        $.ajax({
            type: "GET",
            url: "/Branchs/GetSingleOrganizationbyId",
            contentType: "application/json; charset=utf-8",
            data: { id: orgnationId },
            success: function (data) {
                orgShortName = "";
                orgShortName = data.ShortName;
                $("#Branch_BranchCode").val(orgShortName);

            }
        });
    }
}

$(document.body).on("change", "#Branch_ShortName", function () {
    var branchId = $("#Branch_Id").val();
    if (branchId > 0) {
        organizationDropdown();
        var orgShortName2 = $("#Branch_BranchCode").val();
        var shortName2 = $("#Branch_ShortName").val();
        $("#Branch_BranchCode").val(orgShortName2 + "_" + shortName2);

    } else {
        var shortName = $("#Branch_ShortName").val();
        $("#Branch_BranchCode").val("");
        $("#Branch_BranchCode").val(orgShortName + "_" + shortName);
    }
    
});

//**********************************************************************

