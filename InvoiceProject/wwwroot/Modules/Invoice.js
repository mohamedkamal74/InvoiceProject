
let ddlCategoryId = document.getElementById("ddlCategoryId");
let ddlProduct = document.getElementById("ddlProduct");
let quntity = document.getElementById("quntity");
let price = document.getElementById("price");

//get or return product where category id

ShowProduct = () => {

    if ($('#ddlCategoryId').val() == "") {
        $("#ddlProduct").html(`<option value="">اختر نوع الفئة</option>`);
    }
    else {
        $.ajax({
            url: `/Home/GetProduct/${ddlCategoryId.value}`,
            method: 'GET',
            cache: false,
            success: (data) => {
                let product = '';
                product += `<option value="">اختر المنتج ......</option>`;
                for (x in data) {
                    product += `<option value="${data[x].productId}">${data[x].productName}</option>`;
                }
                $("#ddlProduct").html(product);
            }
        });
    }


}

ShowPrice = () => {

    $.ajax({
        url: `/Home/GetPriceProduct/${ddlProduct.value}`,
        method: 'GET',
        cache: false,
        success: (data) => {

            $("#price").val(data.price);
        }
    });

}

SaveProduct = () => {

    let objProduct = {
        CategoryId: ddlCategoryId.value,
        ProductId: ddlProduct.value,
        Price: price.value,
        Quantity: quntity.value,
        Total: price.value * quntity.value

    };

    let data = JSON.stringify(objProduct);

    $.ajax({


        url: '/api/APIInvoice',
        method: 'POST',
        contentType: 'application/json',
        data: data,
        cache: false,
        success: (data) => {
            alert("data saved ");

            ResetData();
            ShowTable();
        }

    });

}

ResetData = () => {
    ddlCategoryId.value = '';
    ddlProduct.value = '';
    quntity.value = 1;
    price.value = 0;
}


 ShowTable = () => {

    $.ajax({

        url: '/api/APIInvoice',
        method: 'GET',
        cache: false,
        success: (data) => {

            let Table = '';
            for (x in data) {

                Table += `
                 <tr>
                <td>#</td>
                <td>${data[x].category.categoryName}</td>
                <td>${data[x].product.productName}</td>
                <td>${data[x].price}</td>
                <td>${data[x].quantity}</td>
                <td>${data[x].total}</td>
                <td><a class="btn btn-danger" onclick="RemoveRow(${data[x].invoiceId})" style="color:#ffff"><i class="fa fa-trash"></i></a> </td>
              

                     </tr>

                         `;
            }
            $('#tablebody').html(Table);

        }



    });
}


RemoveRow = (id) => {

    $.ajax({

        url: `/api/APIInvoice/${id}`,
        method: 'DELETE',
        cache: false,
        success: () => {
            alert('data Deleted');
            ShowTable();
        }


    });
}



$(document).ready(() => {
    ShowTable();

});
