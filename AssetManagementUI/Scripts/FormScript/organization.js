$(document).ready(function() {
    $("#organizationManu").show();
});

// ****************************** Index Page *****************************************

$(document).ready(function () {
    var table = $("#organizationTable").dataTable({
        ajax: {
            url: "/Organizations/GetAllOrganization",
            dataSrc: ""
        },
        columns: [
            {
                data: "Name",
                render: function (data, type, customer) {
                    return "<a href='/Organizations/Edit/" + customer.Id + "'>" + customer.Name + "</a>";
                }
            },
            {
                data: "ShortName"
            },
            {
                data: "Location"
            },
            {
                data: "Description"
            },
            {
                data: "Id",
                render: function(data) {
                    return "<button class='btn-link js-delete' data-organization-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });
   


    $("#organizationTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this Organization?", function(result) {
            if (result) {
                $.ajax({
                    url: "/Organizations/Delete/" + button.attr("data-organization-id"),
                    method: "DELETE",
                    success: function() {
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

            vm.Name = $("#Name").val;
            vm.ShortName = $("ShortName").val;
            vm.Location = $("#Location").val;
            vm.Description = $("#Description").val;


            $.ajax({
                url: "/Api/Organizations",
                method: "POST",
                data: vm
        })
                .done(function() {
                    toastr.success("Success fully Save");
                })
                .fail(function() {
                    toastr.error("Save fail");
                });
            return false;
        }
    });
});

// ****************************** End Index Page *****************************************



