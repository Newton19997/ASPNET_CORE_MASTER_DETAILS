
    $(document).ready(function () {
        $('#POITable').on('change', 'select.search_type', function (e) {
            var selectedval = $(this).val();
            $(this).closest('td').next().html(selectedval);
        });
    });



    function deleteRow(row)
    {
        var i = row.parentNode.parentNode.rowIndex;
        document.getElementById('POITable').deleteRow(i);
    }
    function insRow()
    {
        var x = document.getElementById('POITable');
        var new_row = x.rows[1].cloneNode(true);
        var len = x.rows.length;
        //new_row.cells[0].innerHTML = len; //auto increment the srno
        var inp1 = new_row.cells[1].getElementsByTagName('select')[0];
       // inp1.id += len;
        //inp1.value = '';
        //new_row.cells[2].innerHTML = '';
        new_row.cells[2].getElementsByTagName('input')[0].value = "";
        new_row.cells[3].getElementsByTagName('input')[0].value = "";
        new_row.cells[4].getElementsByTagName('input')[0].value = "";
        x.appendChild(new_row);
}

function myFunction() {  
    var iss = row.parentNode.parentNode.rowIndex;

    var i = 1;
    var id = 0;
    var t = document.getElementById('POITable');

    $("#POITable tr").each(function () {
        var productId = $(t.rows[i].cells[1]).val();
        var productName = $(t.rows[i].cells[1]).text();
        var Qty = $(t.rows[i].cells[2]).text();
        var UnitPrice = $(t.rows[i].cells[3]).text();
        var DiscountPercentage = $(t.rows[i].cells[4]).text();
        //  alert(val1);

        var tr = '<tr>';
        var prod = '<td><input type="hidden" name="OrderDetails[' + id + '].ProductId" value="' + productId + '"/>' + productName + '</td>';
        var Qtyd = '<td><input type="hidden" name="OrderDetails[' + id + '].Qty" value="' + Qty + '" />' + Qty + '</td>';
        var UPd = '<td><input type="hidden" name="OrderDetails[' + id + '].UnitPrice" value="' + UnitPrice + '"/>' + UnitPrice + '</td>';
        var dpd = '<td><input type="hidden" name="OrderDetails[' + id + '].DiscountPercentage" value="' + DiscountPercentage + '"/>' + DiscountPercentage + '</td>';
        var btn = "<td>" + "<button type='button' onclick='productDelete(this);' class='btn btn-default btnDelete'>" + "DEL" + "</button>" + "</td>";

        tr += prod + Qtyd + UPd + dpd + btn + '</tr>';

        $("#tbOrderDetails").append(tr);

        i++;
        id++
    });
}
