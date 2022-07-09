const img = document.querySelectorAll('#img');
const btnFile = document.querySelectorAll('#picture');

$(btnFile).each(function (index, element) {
    // element == this
    element.addEventListener('change', function() {
        const file = this.files[0];
        if(file){
            const reader = new FileReader();
            reader.onload = function(){
                const result = reader.result;
                img[index].setAttribute('src', result);
            }
            reader.readAsDataURL(file);
        }
    })
    
});