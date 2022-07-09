$(document).ready(function () {
    var amount = JSON.parse(`[${ sessionStorage.getItem('orders')}]`).length;
    
    $(".cart-amount").text(amount);
    $('.product .btn-buy').click(function(){
        var product =  $( this ).parent();
        var imgPro = product.find('.product-img').attr('src');
        var namePro = product.find('.product-name').text();
        var price = product.find('.product-price').text();
        var oldprice = product.find('.product-oldprice').text();
        var order = {
            'name': namePro,
            'price': price,
            'img': imgPro,
            'oldprice':oldprice
        };

        var currentProduct = window.sessionStorage.getItem('orders');
        var newOrder="";
        if(currentProduct!=null)
            newOrder = currentProduct + "," + JSON.stringify(order);
        else
            newOrder = JSON.stringify(order);
        window.sessionStorage.setItem('orders', newOrder);
        
        var current= Number($(".cart-amount").text());
        current+=1;
        $(".cart-amount").text(current);  
    });
});
$(document).ready(function(){
    var dataOrder = `[${sessionStorage.getItem('orders')}]`;
    var data = JSON.parse(dataOrder);
    $(".cart-amount").text(data.length);
    $('.cart-number').text(`(Có ${data.length} sản phẩm)`);
    var content = "";
    for(let i = 0; i< data.length; i++){
        var cartItem =   `<div  class=" order-detail">
        <div class="order-img">
            <img class="order-photo" src="${data[i].img}"/>
            
        </div>
            
        <div class="order-description">
            <label class="order-product-name">${data[i].name}</label>
            <label class="order-delete" >
                <input id='btn-xoa' type='button' value='Xóa' style='height: 32px;width: 40px; background-color: #EB5757; color:white;' />
            </label>
            <label class="order-later">Để mua sau</label>
        </div>
            
        <div class="order-price">
            <label class="item-old-price"><s>${data[i].oldprice}</s></label><br />
            <label class="item-price" style="color: red">${data[i].price}</label>
            
        </div>
            
        <div class="order-amount">
            <input class="btn-sub" type="button" value="-"/>
            <input class="txt-amount" type="text" value="1"/>
            <input class="btn-plus" type="button" value="+"/>
        </div>
        </div>`;
          content+=cartItem;
    }
    $("#content-left").html(content);
});

//var remove_cart = document.getElementsByClassName("btn-xoa");
//for (var i = 0; i < remove_cart.length; i++) {
//  var button = remove_cart[i]
//  button.addEventListener("click", function () {
//    var button_remove = event.target
//    button_remove.parentElement.parentElement.remove()
//  })
//}