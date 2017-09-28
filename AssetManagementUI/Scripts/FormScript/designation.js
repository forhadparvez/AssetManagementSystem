
$(document).ready(function () {
    $("#organizationManu").show();
});

// ****************************** Index Page *****************************************

$(document).ready(function () {
    var table = $("#designationTable").dataTable({
        ajax: {
            url: "/Designations/GetAllDesignation",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name",
                render: function (data, type, customer) {
                    return "<a href='/Designations/Edit/" + customer.Id + "'>" + customer.Name + "</a>";
                }
            },
            {
                data: "ShortName"
            },
            
            {
                data: "Department.Name"
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-branch-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });



    $("#designationTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this designation?", function (result) {
            if (result) {
                $.ajax({
                    url: "/Designations/Delete/" + button.attr("data-designation-id"),
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

            vm.DepartmentName = $("#DepartmentId").val;
            vm.Name = $("#Name").val;
            vm.ShortName = $("#ShortName").val;


            $.ajax({
                url: "/Api/Designations",
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
