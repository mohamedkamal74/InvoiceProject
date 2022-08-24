
let ddlCategoryId = document.getElementById("ddlCategoryId");

//get or return product where category id

ShowProduct = () => {

    $.ajax({
        url: `/Home/GetProduct/${ddlCategoryId.value}`,
        method: 'GET',
        cache: false,
        success: (data) => {
            let product = '';
            for (x in data) {
                product += `<option value="${data[x].productId}">${data[x].productName}</option>`;
            }
            $("#ddlProduct").html(product);
        }
    });

}