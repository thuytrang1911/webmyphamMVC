function changeImage(id){
    let imagePath = document.getElementById(id).getAttribute('src');
    document.getElementById('img-main').setAttribute('src',imagePath);
}

$(window).on("load",function(){
	$(".button").click(function(){
		var color =$(this).val();
		$(".button").css("background-color","white");
		$(".button").css("color","#54b2e2");
		$(this).css("background-color","#54b2e2");
		$(this).css("color","white")
	})
});