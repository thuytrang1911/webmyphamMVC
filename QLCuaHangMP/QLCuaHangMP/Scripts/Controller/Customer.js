/// <reference path="../angular.min.js" />

var myapp = angular.module('AdminApp', []);
myapp.controller("QLSanPhamController", function ($rootScope, $scope, $window, $http) {
    $http.get("/QLSanPham/GetSanPham").then(function (d) {
        $scope.listSanPham = d.data;
    }, function (error) {
        alert('Failed');
    });
    $scope.Delete = function (s) {

        $http({
            method: 'Post',
            url: "/QLSanPham/DeleteSanPham",
            datatype: 'Json',
            params: { id: s.MaSP }
        }).then(function (d) {
            alert('OK');
            var vt = $scope.listSanPham.indexOf(s);
            $scope.listSanPham.splice(vt, l);
        }, function (error) {

            alert(error);
        });
    }
});
