
var id = 0;
$("#AddButton").click(() => {
    var productId = $("#productId").val();
    var productName = $("#productId option:selected").text();
    var UnitPrice = $("#UnitPrice").val();
    var Qty = $("#Qty").val();
    var DiscountPercentage = $("#DiscountPercentage").val();
   

    var tr = '<tr>';   
    var prod = '<td><input type="hidden" name="OrderDetails1[' + id +'].ProductId" value="'+productId+'"/>' + productName+'</td>';
    var Qtyd = '<td><input type="hidden" name="OrderDetails1[' + id + '].Qty" value="'+ Qty+'" />' + Qty+'</td>';
    var UPd = '<td><input type="hidden" name="OrderDetails1[' + id + '].UnitPrice" value="'+ UnitPrice + '"/>' + UnitPrice+'</td>';
    var dpd = '<td><input type="hidden" name="OrderDetails1[' + id + '].DiscountPercentage" value="'+ DiscountPercentage+'"/>' + DiscountPercentage + '</td>';
    var btn = "<td>" + "<button type='button' onclick='productDelete(this);' class='btn btn-default btnDelete'>" + "DEL" + "</button>" + "</td>";

    tr += prod + Qtyd + UPd + dpd + btn + '</tr>';

    $("#tbOrderDetails").append(tr);
    id++;
    AddTable();
});

$("#tbOrderDetails").on('click', '.btnDelete', function () {
    $(this).closest('tr').remove(); 
    AddTable();

    /*check par
    var table = document.getElementById('tbOrderDetails');
    var rowLength = table.rows.length;
    for (var i = 0; i < rowLength; i += 1) {
        var row = table.rows[i];
        var productId = $(table.rows[i].cells[0]).find('input[type="hidden"]').val();
        var productName = $(table.rows[i].cells[0]).text();
        var Qty = $(table.rows[i].cells[1]).text();
        var UnitPrice = $(table.rows[i].cells[2]).text();
        var DiscountPercentage = $(table.rows[i].cells[3]).text();
    }
    */

});



function AddTable() {
    var i = 0;
    var id1 = 0;
    var t = document.getElementById('tbOrderDetails');
    var t1 = document.getElementById('tbOrderDetailss');

    $('#tbOrderDetailss tr').empty();
    
    $("#tbOrderDetails tr").each(function () {
        var productId = $(t.rows[i].cells[0]).find('input[type="hidden"]').val();
        var productName = $(t.rows[i].cells[0]).text();
        var Qty = $(t.rows[i].cells[1]).text();
        var UnitPrice = $(t.rows[i].cells[2]).text();
        var DiscountPercentage = $(t.rows[i].cells[3]).text();
        //  alert(val1);

        var tr = '<tr>';
        var prod = '<td><input type="hidden" name="OrderDetails[' + id1 + '].ProductId" value="' + productId + '"/>' + productName + '</td>';
        var Qtyd = '<td><input type="hidden" name="OrderDetails[' + id1 + '].Qty" value="' + Qty + '" />' + Qty + '</td>';
        var UPd = '<td><input type="hidden" name="OrderDetails[' + id1 + '].UnitPrice" value="' + UnitPrice + '"/>' + UnitPrice + '</td>';
        var dpd = '<td><input type="hidden" name="OrderDetails[' + id1 + '].DiscountPercentage" value="' + DiscountPercentage + '"/>' + DiscountPercentage + '</td>';
        var btn = "<td>" + "<button type='button' onclick='productDelete(this);' class='btn btn-default btnDelete'>" + "DEL" + "</button>" + "</td>";

        tr += prod + Qtyd + UPd + dpd + btn + '</tr>';

        $("#tbOrderDetailss").append(tr);

        i++;
        id1++;
    });
 
}




//tr += prod + Qtyd + UPd + dpd + "<td>" +
//    "<button type='button' onclick='productDelete(this);' class='btn btn-default'>" + "DEL"
//    +
//    "</button>" +
//    "</td>" + '</tr>';
// var proid = '<td class="hide"><input type="hidden" name="OrderDetails[' + id + '].ProductId" value="' + productId + '"/>' + productId + '</td>';