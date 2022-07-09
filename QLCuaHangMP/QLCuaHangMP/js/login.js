var USER = 'Trangthuy';
var PASS ='11';

var user="Admin";
var pas="111"

var inputusername = document.getElementById('username');
var inputpassword = document.getElementById('password');

var formloign = document.getElementById('form-loign');

if(formloign.attachEvent){
    formloign.attachEvent('submit',onFormSubmit);

}
else{
    formloign.addEventListener('submit', onFormSubmit);

}

function onFormSubmit(e){
    var username = inputusername.value;
    var password = inputpassword.value;

    if(username==USER && password==PASS){
        formloign.action = "beauty.html"
    }
   else if(username==user && password==pas){
        formloign.action = "home.html"
    }
    else{
        alert('Dang nhap that bai')
    }
}

