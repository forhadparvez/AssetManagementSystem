$("#operationManu").show();

$(document).ready(function () {
    var table = $("#assetEntryTable").dataTable({
        ajax: {
            url: "/AssetEntrys/GetAll",
            dataSrc: ""
        },
        columns: [
            {
                data: "AsetId",
                render: function (data, type, customer) {
                    return "<a href='/AssetEntrys/Edit/" + customer.Id + "'>" + customer.AssetId + "</a>";
                }
            },
            {
                data: "Name"
            },
            {
                data: "SerialNo"
            },
            {
                data: "Status"
            },
            {
                data: "Id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-branch-id=" + data + "><i class='fa fa-trash-o fa-2x' aria-hidden='true'></i></button>";
                }
            }
        ]

    });



    $("#assetEntryTable").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this Asset?", function (result) {
            if (result) {
                $.ajax({
                    url: "/AssetEntrys/Delete/" + button.attr("data-branch-id"),
                    method: "post",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});






// dropdown load ******************************
$(document.body).on("change", "#OrganizationId", function () {
    var orgId = $("#OrganizationId").val();
    if (orgId > 0) {
        $.ajax({
            type: "GET",
            url: "/AssetEntrys/GetBranchByOrgId",
            contentType: "application/json; charset=utf-8",
            data: { orgId: orgId },
            success: function (data) {
                var $el = $("#BranchId");
                $el.empty(); // remove old options
                $el.append($("<option></option>")
                        .attr("value", '').text('Please Select'));
                $.each(data, function (value, key) {

                    $el.append($('<option>', {
                        value: key.Id,
                        text: key.Name
                    }));
                });
            }
        });
    }
});



$(document.body).on("change", "#BranchId", function () {
    var branchId = $("#BranchId").val();
    if (branchId > 0) {
        $.ajax({
            type: "GET",
            url: "/AssetEntrys/GetAssetLocationByBranchId",
            contentType: "application/json; charset=utf-8",
            data: { branchId: branchId },
            success: function (data) {
                var $el = $("#AssetLocationId");
                $el.empty(); // remove old options
                $el.append($("<option></option>")
                        .attr("value", '').text('Please Select'));
                $.each(data, function (value, key) {

                    $el.append($('<option>', {
                        value: key.Id,
                        text: key.Name
                    }));
                });
            }
        });
    }
});


$(document.body).on("change", "#AssetTypeId", function () {
    var typeId = $("#AssetTypeId").val();
    if (typeId > 0) {
        $.ajax({
            type: "GET",
            url: "/AssetEntrys/GetGroupByTypeId",
            contentType: "application/json; charset=utf-8",
            data: { typeId: typeId },
            success: function (data) {
                var $el = $("#AssetGroupId");
                $el.empty(); // remove old options
                $el.append($("<option></option>")
                        .attr("value", '').text('Please Select'));
                $.each(data, function (value, key) {

                    $el.append($('<option>', {
                        value: key.Id,
                        text: key.Name
                    }));
                });
            }
        });
    }
});


$(document.body).on("change", "#AssetGroupId", function () {
    var groupId = $("#AssetGroupId").val();
    if (groupId > 0) {
        $.ajax({
            type: "GET",
            url: "/AssetEntrys/GetManufacturerByGroupId",
            contentType: "application/json; charset=utf-8",
            data: { groupId: groupId },
            success: function (data) {
                var $el = $("#AssetManufacurerId");
                $el.empty(); // remove old options
                $el.append($("<option></option>")
                        .attr("value", '').text('Please Select'));
                $.each(data, function (value, key) {

                    $el.append($('<option>', {
                        value: key.Id,
                        text: key.Name
                    }));
                });
            }
        });
    }
});

$(document.body).on("change", "#AssetManufacurerId", function () {
    var manuId = $("#AssetManufacurerId").val();
    if (manuId > 0) {
        $.ajax({
            type: "GET",
            url: "/AssetEntrys/GetAllModelByManufacturerId",
            contentType: "application/json; charset=utf-8",
            data: { manuId: manuId },
            success: function (data) {
                var $el = $("#AssetModelId");
                $el.empty(); // remove old options
                $el.append($("<option></option>")
                        .attr("value", '').text('Please Select'));
                $.each(data, function (value, key) {

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


// ********************* Tabs *******************************

$(document.body).on("click", "#financeLinkButton", function () {
    var assetId = $("#assetTableId").val();
    var url = "/AssetEntrys/NewFinance/"+assetId;
    $.get(url, function (responseData) {
        $("#financeMainBody").html(responseData);
    });
});


$(document.body).on("click", "#serviceLinkButton", function () {
    var assetId = $("#assetTableId").val();
    var url = "/AssetEntrys/NewService/" + assetId;
    $.get(url, function (responseData) {
        $("#serviceMainBody").html(responseData);
    });
});

$(document.body).on("click", "#noteLinkButton", function () {
    var assetId = $("#assetTableId").val();
    var url = "/AssetEntrys/NewNote/" + assetId;
    $.get(url, function (responseData) {
        $("#noteMainBody").html(responseData);
    });
});

$(document.body).on("click", "#attachmentLinkButton", function () {
    var assetId = $("#assetTableId").val();
    var url = "/AssetEntrys/NewAttechment/" + assetId;
    $.get(url, function (responseData) {
        $("#attachmentMainBody").html(responseData);
    });
});





// Save footer tab

// save finance
$(document.body).on("click", "#saveFinanceButton", function () {
    var financeVm = {};

    financeVm.AssetEntryId = $("#AssetEntryId").val();
    financeVm.VendorId = $("#VendorId").val();
    financeVm.ParchaseOrderNo = $("#ParchaseOrderNo").val();
    financeVm.ParchasePrice = $("#ParchasePrice").val();
    financeVm.PurchaseDate = $("#PurchaseDate").val();


    $.ajax({
        type: "GET",
        url: "/AssetEntrys/SaveFinanceApi/" ,
        contentType: "application/json; charset=utf-8",
        data: financeVm,
        success: function (data) {
            if (data > 0) {

                $("#VendorId").val("");
                $("#ParchaseOrderNo").val("");
                $("#ParchasePrice").val("");
                $("#PurchaseDate").val("");

                alert("Success");
            } else {
                alert("Fail");
            }
        }
    });
});


// save Service
$(document.body).on("click", "#saveServiceButton", function () {
    var serviceVm = {};

    serviceVm.AssetEntryId = $("#AssetEntryId").val();
    serviceVm.Description = $("#Description").val();
    serviceVm.ServiceDate = $("#ServiceDate").val();
    serviceVm.ServiceBy = $("#ServiceBy").val();
    serviceVm.ServiceingCostDecimal = $("#ServiceingCostDecimal").val();
    serviceVm.PartsCostDecimal = $("#PartsCostDecimal").val();
    serviceVm.TaxDecimal = $("#TaxDecimal").val();


    $.ajax({
        type: "GET",
        url: "/AssetEntrys/SaveServicApi/",
        contentType: "application/json; charset=utf-8",
        data: serviceVm,
        success: function (data) {
            if (data > 0) {

                $("#Description").val("");
                $("#ServiceDate").val("");
                $("#ServiceBy").val("");
                $("#ServiceingCostDecimal").val("");
                $("#PartsCostDecimal").val("");
                $("#TaxDecimal").val("");

                alert("Success");
            } else {
                alert("Fail");
            }
        }
    });
});


// save Note
$(document.body).on("click", "#saveNoteButton", function () {
    var noteVm = {};

    noteVm.AssetEntryId = $("#AssetEntryId").val();
    noteVm.Notes = $("#Notes").val();

    $.ajax({
        type: "GET",
        url: "/AssetEntrys/SaveNoteApi/",
        contentType: "application/json; charset=utf-8",
        data: noteVm,
        success: function (data) {
            if (data > 0) {

                $("#Notes").val("");

                alert("Success");
            } else {
                alert("Fail");
            }
        }
    });
});


// save Attchment
$(document.body).on("click", "#saveAttchmentButton", function () {
    var attchmentVm = {};

    attchmentVm.AssetEntryId = $("#AssetEntryId").val();
    attchmentVm.File = $("#File").val();

    $.ajax({
        type: "GET",
        url: "/AssetEntrys/AttechmentSaveApi/",
        contentType: "application/json; charset=utf-8",
        data: attchmentVm,
        success: function (data) {
            if (data > 0) {

                $("#File").val("");

                alert("Success");
            } else {
                alert("Fail");
            }
        }
    });
});