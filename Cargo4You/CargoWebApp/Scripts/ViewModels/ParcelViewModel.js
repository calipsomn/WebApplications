$("#Weight").on("change paste keyup", function () {
    calculatePrice();
});
$("#Width").on("change paste keyup", function () {
    calculatePrice();
});
$("#Height").on("change paste keyup", function () {
    calculatePrice();
});
$("#Depth").on("change paste keyup", function () {
    calculatePrice();
});
function calculatePrice() {
    $.get("/Parcels/CalculateParcelPrice", { weight: $("#Weight").val(), width: $("#Width").val(), depth: $("#Depth").val(), height: $("#Height").val() },
     function (returnedData){
         $("#Price").val(returnedData)+'€';
     })
}