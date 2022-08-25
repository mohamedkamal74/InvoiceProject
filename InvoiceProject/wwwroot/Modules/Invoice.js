
let ddlCategoryId = document.getElementById("ddlCategoryId");

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