
$(document).ready(function () {
    $("#organizationManu").show();
});

// ****************************** Index Page *****************************************

$(document).ready(function () {
    var table = $("#departmentTable").dataTable({
        ajax: {
            url: "/Departments/GetAllDepartment",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name",
                render: function (data, type, customer) {
                    return "<a href='/Departments/Edit/" + customer.Id + "'>" + customer.Name + "</a>";
                }
            },
            {
                data: "ShortName"
            },
            {
                data: "DepartmentCode"
            },
            {
                data: "Organization.Name"
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-department-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });



    $("#departmentTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this department?", function (result) {
            if (result) {
                $.ajax({
                    url: "/Departments/Delete/" + button.attr("data-department-id"),
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
            vm.OrganizationId = $("#OrganizationId").val;
            vm.Name = $("#Name").val;
            vm.ShortName = $("#ShortName").val;
            vm.DepartmentCode = $("#DepartmentCode").val;


            $.ajax({
                    url: "/Api/Departments",
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
