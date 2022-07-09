var formater = Intl.NumberFormat("vi", {
    style: 'currency',
    currency: 'VND',
    minimumFractionDigits: 0
});

function replaceDot(s){
	while(s.indexOf(".")>=0)
		s = s.replace(".", "");
	return s;
}

function Update_Total_Price(){
    var data = $('.item-price')
    var total_price=0
    for(var i=0;i<data.length;i++){
        var price = $(data[i]).text()
		
        var parent = $(data[i]).parent().parent()
        var amount = parent.find('.txt-amount').val()
        price = price.toString().replace(' đ','')
		
        price = replaceDot(price);
        total_price+= Number(price) * amount
    }
    console.log(total_price);
    $('.tmp-price').text(formater.format(total_price.toString()));
    $('.total-price').text(formater.format(total_price.toString()));
   
}

$(document).ready(function(){
    Update_Total_Price();
	console.log(formater);
    $('.btn-plus').click(function(){
        var parent = $(this).parent()
        $(parent).find('.txt-amount').val(parseInt($(parent).find('.txt-amount').val())+1)
        Update_Total_Price()
    })
    $('.btn-sub').click(function(){
        var parent = $(this).parent()
        if(Number($(parent).find('.txt-amount').val()) > 1) {

            $(parent).find('.txt-amount').val(parseInt($(parent).find('.txt-amount').val())-1)
        }
        Update_Total_Price()
    })
})