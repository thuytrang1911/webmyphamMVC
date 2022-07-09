/// <reference path="../angular.min.js" />
var homeapp = angular.module("CustommerApp", ['angularUtils.directives.dirPagination']);

homeapp.controller("MenuController",
    function ($scope, $rootScope, $http) {
        $http({
            method: 'get',
            url: '/Home/GetDongSP'
        }).then(function Success(d) {

            $rootScope.listDongSP = d.data;
        },
            function Error() {
                alert("Lấy dòng sản phẩm lỗi");
            });

        $scope.SelectDongSP = function (l) {
            localStorage.setItem("MaDong", l);
        }
    });
homeapp.controller("SanPhamController", function ($scope, $rootScope, $http) {

    var madong = localStorage.getItem("MaDong");
    $http({
        method: "get",
        url: "/SanPham/GetSanPhamDong",
        params: { MaDongSP: madong }//localStorage.getItem("MaLoai") }
    }).then(function Success(d) {
        $scope.listSanPham = d.data;
    }, function error(e) {
        alert("Lấy sản phẩm lỗi");
    });

});

//homeapp.controller("SanPhamController", [ '$scope', '$http', '$window', function ($scope, $http, $window) {
//    $scope.SanPhams = [];
//    $scope.MaSP = "";
//    $scope.TenSP = "";
//    $scope.MaDongSP = "";
//    $scope.DungLuong = "";
//    $scope.MoTa = "";
//    $scope.Anh = "";
//    $scope.MauSac = "";
//    $scope.MuiHuong = "";
//    $scope.KieuDang = "";
//    $scope.GetSanpham = function () {
//        $scope.SanPhams = [];
//        $http.get("/SanPham/GetSanPham")
//    }
//    //$http({
//    //    method: "get",
//    //    url: "/SanPham/GetSanpham",
//    .then(function Success(d) {
//        $scope.SanPhams = d.data.sp;
//    }, function error() { })
//}]);

homeapp.controller("DongSPController", function ($scope, $http) {
    // Lấy về tất cả dòng sản phẩm
    $http.get("/DongSP/GetDongSP").then(function (d) {
        $scope.DongSPs = d.data;
    }, function (error) {
        alert('Failed');
    });
});

//phân trang
//homeapp.controller("SanPhamController", function ($scope, $http) {
//    $scope.sortcolumn = "MaDongSP";
//    $scope.reverse = true;
//    $scope.dr = "Ascending";

//    $scope.maxSize = 3;
//    $scope.totalCount = 0;
//    $scope.pageIndex = 1;
//    $scope.pageSize = 5;
//    $scope.searchName = "";

//    $scope.Chon = function (d)
//    {
//        if ($rootScope.dr == "Ascending") {
//            $scope.reverse = false;
//            $scope.dr = "Ascending";
//        }
//        else {
//            $scope.reverse = true;
//            $scope.dr = "Ascending";
//        }
//    }
//    $scope.GetSanpham = function (index) {
//        var MaDongSP = localStorage.getItem("MaDongSP");
//        if (MaDongSP == undefined) {
//            MaDongSP = "";
//        }
//        $rootScope.pageIndex = index;
//        $http({
//            method: 'get',
//            url: '/SanPham/GetSanPhamDong',
//            params: { maloai: MaDongSP, pageIndex: $rootScope.pageIndex, pageSize: $rootScope.pageSize }
//        }).then(function Success(d) {
//            $scope.listSanPham = d.data;
//            $rootScope.totalCount = $scope.listSanPham.totalCount;
//        }, function error(e) {
//            alert("Lấy sản phẩm phân trang lỗi");
//        });
//    }
//    $scope.GetSanpham(pageIndex)
//    $scope.SelectDongSP = function (l) {
//        localStorage.setItem("MaDongSP", l);
//        $scope.GetSanpham($rootScope.pageIndex);
//    }
//    $scope.SelectSanPham = function (pid) {
//        localStorage.setItem("MaDongSP", pid);
//    }
//});
//-------------------------------------------------------------

homeapp.controller("CTSanPhamController", function ($scope, $http) {

    $http({
        method: "post",
        url: "/ChiTietSP/GetSanPham",
        params: { MaSP: localStorage.getItem("MaSP") }
    }).then(function Success(d) {
        $scope.listSanPham = d.data;
    }, function error() {

    });

});
