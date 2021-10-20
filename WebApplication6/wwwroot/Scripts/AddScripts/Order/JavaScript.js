


//for chack empty
var proid = $("#productId").val();
var proName = $("#productId option:selected").text();
var UPrice = $("#UnitPrice").val();
var Qt = $("#Qty").val();
var DPercentage = $("#DiscountPercentage").val();

function checkEmptyInput() {
    var isEmpty = false;
    if (proName == "Select Product.........") {
        alert("Please Select Product")
        isEmpty = true;
    }
    if (UPrice == "") {
        alert("Please Entry UnitPrice")
        isEmpty = true;
    }
    if (Qt == "") {
        alert("Please Entry Qty")
        isEmpty = true;
    }
    return isEmpty;
}


var rIndex, table = document.getElementById("tbEditOrderDetails");

var id = 0;

$("#AddButton").click(() => {
    var productId = $("#productId").val();
    var productName = $("#productId option:selected").text();
    var UnitPrice = $("#UnitPrice").val();
    var Qty = $("#Qty").val();
    var DiscountPercentage = $("#DiscountPercentage").val();

   /// if (!checkEmptyInput()) {

        var tr = '<tr>';
        var prod = '<td><input type="hidden"  name="OrderDetails[' + id + '].ProductId" value="' + productId + '"/>' + productName + '</td>';
        var Qtyd = '<td><input type="hidden" name="OrderDetails[' + id + '].Qty" value="' + Qty + '" />' + Qty + '</td>';
        var UPd = '<td><input type="hidden" name="OrderDetails[' + id + '].UnitPrice" value="' + UnitPrice + '"/>' + UnitPrice + '</td>';
        var dpd = '<td><input type="hidden" name="OrderDetails[' + id + '].DiscountPercentage" value="' + DiscountPercentage + '"/>' + DiscountPercentage + '</td>';

        tr += prod + Qtyd + UPd + dpd + '</tr>';

        $("#tbEditOrderDetails").append(tr);
        id++;
        selectedRowToInput();
   //}
});

function selectedRowToInput() {
    
    for (var i = 0; i < table.rows.length; i++)
    {
        table.rows[i].onclick = function () {
            //get select row index
            rIndex = this.rowIndex;
            console.log(rIndex);
            var currentRow = $(this).closest("tr"); 
            var col0 = currentRow.find("td:eq(0)").text();           
            //this.rIndex.cells["tbProductId"].val;
            var col1 = currentRow.find("td:eq(1)").text();
            var col2 = currentRow.find("td:eq(2)").text();
                //this.rIndex.cells["tbUnitPrice"].innerHTML;
            var col3 = currentRow.find("td:eq(3)").text();
                //this.rIndex.cells["tbDiscountPercentage"].innerHTML;

            var c0 = col0.trim();
            var tc0 = document.getElementById('productId');
            tc0.val = c0;
           // $("#productId").text() == c0;
          // $("#productId").val();
          //$("#productId option:selected").text();
            var c1 = col1.trim();
            var tc1 = document.getElementById("UnitPrice");
            tc1.val  = c1;
          //  $("#UnitPrice").val() == c1;
            var c2 = col2.trim();
            var tc2 = document.getElementById('Qty');
            tc2.val = c2;
           // $("#Qty").val() == c2;
            var c3 = col3.trim();
            var tc3 = document.getElementById('DiscountPercentage');
            tc3.val  = c3;
           // $("#DiscountPercentage").val() == c3;

        }
    }
}
selectedRowToInput();

function editHtmlTableSelectRow() {
    //if (!checkEmptyInput()) {
        table.rows[rIndex].cells[0].innerHTML = $("#productId option:selected").text();
        table.rows[rIndex].cells[1].innerHTML = $("#Qty").val();
        table.rows[rIndex].cells[2].innerHTML = $("#UnitPrice").val();
        table.rows[rIndex].cells[3].innerHTML = $("#DiscountPercentage").val();
   // }
}

function removedSelectRow() {
    table.deleteRow(rIndex);
    //$("#productId option:selected").text() ="Select Product.........";
    //$("#Qty").val() = "";
    //$("#UnitPrice").val() = "";
    //$("#DiscountPercentage").val() = "";
}
