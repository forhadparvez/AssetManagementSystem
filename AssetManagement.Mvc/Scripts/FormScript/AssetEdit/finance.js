
$(document.body).on("click", "#saveButton", function () {
    var financeVm = new {};

    financeVm.AssetEntryId = $("#AssetEntryId").val();
    financeVm.VendorId = $("#VendorId").val();
    financeVm.ParchaseOrderNo = $("#ParchaseOrderNo").val();
    financeVm.ParchasePrice = $("#ParchasePrice").val();
    financeVm.PurchaseDate = $("#PurchaseDate").val();


    $.ajax({
        type: "GET",
        url: "/AssetEntrys/SaveFinanceApi",
        contentType: "application/json; charset=utf-8",
        data: { financeVm: financeVm },
        success: function(data) {
            alert("Success");
        }
    });
});