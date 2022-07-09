/// <reference path="../angular.min.js" />


var homeapp = angular.module("SanPhamApp", []);
homeapp.controller("LoginController", function ($rootScope, $window, $http) {
    $rootScope.Users = null;
    $rootScope.UN = "";
    $rootScope.PW = "";
    $rootScope.quyenad = "";
    $rootScope.quyenus = "";
    $rootScope.Logout = function () {
        $window.location.href = '/Admin/Login/Index';
    };

    $rootScope.Login = function (us, pw) {
        $http({
            method: 'post',
            url: '/Login/Login',
            params: { us: us, pw: pw },
        }).then(function success(d) {
            if (d.data == null) {
                $rootScope.UN = "";
                $rootScope.PW = "";
                alert("tài khoản người dùng không đúng");
            }
            else {
                $rootScope.Users = d.data;
                if (d.data.Role == "admin") {
                    $rootScope.quyenad = "";
                    $rootScope.quyenad = "KhongQuyen";
                }
                else {
                    $rootScope.quyenad = "KhongQuyen";
                    $rootScope.quyenus = "";
                }
                $window.location.href = '/Admin/QLSanPham/Index';
                /*alert("Đăng nhập thành công")*/
            }

        }, function error(e) { });
    }
});

homeapp.run(function ($rootScope, $window, $http) {
    $rootScope.Logout2 = function () {

        $http.get('/Admin/Login/Logout').then(
            function (response) {
                $window.location.reload();
            },
            function (err) {
                alert(err);
            });
    };
})