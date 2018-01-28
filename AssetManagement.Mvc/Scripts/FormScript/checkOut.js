var checkOutDto = {
    AssetIds: []
};

$(document.body).on("click", "#assignButton", function () {
    var assetName = $("#AssetEntryId option:selected").text();
    var assetId = $("#AssetEntryId").val();
    $("#assetList").append("<li class='list-group-item'>" + assetName+ "</li>");
    checkOutDto.AssetIds.push(assetId);
});


$(document.body).on("click", "#saveButton", function () {

    checkOutDto.EmployeeId = $("#EmployeeId").val();
    checkOutDto.EntryDate = $("#EntryDate").val();
    checkOutDto.ReturnDate = $("#ReturnDate").val();
    checkOutDto.AssetLocationId = $("#AssetLocationId").val();
    checkOutDto.Commants = $("#Commants").val();


        $.ajax({
            type: "Post",
            url: "/CheckOuts/Save/",
            data: checkOutDto,
            success: function (data) {
                alert(data);
            }
        });
});