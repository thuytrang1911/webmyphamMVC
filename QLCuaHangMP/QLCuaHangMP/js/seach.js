$(document).ready(function(){
	$('#btn-search').on("click",function(){
		var value =$("#txt-search").val().toLowerCase();
		var data = [];
		var d = 0;
		var p = 15;
		var content = "<h2>SẢN PHẨM MUỐN TÌM</h2>";
		for(var i = 0;i < p; i++){
			$("#"+i).filter(function(){
				if($("#" +i+ " .product-name").text().toLowerCase().indexOf(value)>-1){
					var imglink = $("#"+i).find(".product-img").attr('src');
					var name=$("#"+i).find(".product-name").text();
					var oldprice = $("#"+i).find('.product-oldprice').text();
					var price=$("#"+i).find(".product-price").text();
					var order={
						'imglink':imglink,
						'name':name,
						'oldprice':oldprice,
						'price':price
					}
					$(data[d]=order);
					d++;
				}
			});
		}
		if(data.length>0){
			for(var i=0; i< data.length; i++)
			{
				var cartItem=`<div class="col-3 col-m-6 col-s-12">
                    <div id='0' class="product">
                        <img class="product-img" src="${data[i].imglink}"/>
                        <label class="product-name"><a href="#">${data[i].name}</a></label>
						Giá cũ: <label class="product-oldprice"><s >${data[i].oldprice}</s></label> <br />
                        Giá mới: <label class="product-price">${data[i].price}</label>
                        <!--<a href='ct.html' />-->
                        <input type='button' class ='btn-buy' value='CHỌN MUA' />
                        <input type='button' class ='btn-view' onclick="location='ct.html'" value='CHI TIẾT' />
                        
                    </div>
                </div>`
				content +=cartItem;
			}
		}
		else{
			content +="<h1>Không tìm thấy sản phẩm</h1>"
		}
		console.log(content);
		$("#search-re").html(content);
		document.getElementById("main").style.display="none";
		
	});
});