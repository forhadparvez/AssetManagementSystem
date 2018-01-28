$("#hrManu").show();

$(document).ready(function () {
    var table = $("#employeeTable").dataTable({
        ajax: {
            url: "/Employees/GetAllEmployee",
            dataSrc: ""
        },
        columns: [
            {
                data: "Code",
                render: function (data, type, customer) {
                    return "<a href='/Employees/Edit/" + customer.Id + "'>" + customer.Code + "</a>";
                }
            },
            {
                data: "Organization.Name"
            },
            {
                data: "Branch.Name"
            },
            {
                data: "Department"
            },
            {
                data: "Designation"
            },
            {
                data: "FirstName"
            },
            {
                data: "LastName"
            },
            {
                data: "ContactNo"
            }, {
                data: "Email"
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-organization-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });



    $("#employeeTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this Organization?", function (result) {
            if (result) {
                $.ajax({
                    url: "/Employees/Delete/" + button.attr("data-organization-id"),
                    method: "post",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});

// load dropdown ******************************
$(document.body).on("change", "#OrganizationId", function () {
    var orgId = $("#OrganizationId").val();
    if (orgId > 0) {
        $.ajax({
            type: "GET",
            url: "/Employees/GetBranchByOrgId",
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