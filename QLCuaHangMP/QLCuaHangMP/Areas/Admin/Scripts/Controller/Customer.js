/// <reference path="../angular.min.js" />

var myapp = angular.module('AdminApp', ['angularUtils.directives.dirPagination']);
myapp.controller("QLSanPhamController", function ($rootScope, $scope, $window, $http) {
    $http.get("/QLSanPham/GetSanPham").then(function (d) {
        $scope.listSanPham = d.data;
    }, function (error) {
        alert('Failed');
    });
    //$scope.Delete = function (s) {

    //    $http({
    //        method: 'Post',
    //        url: "/QLSanPham/DeleteSanPham",
    //        datatype: 'Json',
    //        params: { id: s.MaSP }
    //    }).then(function (d) {
    //        alert('Lỗi');
    //        var vt = $scope.listSanPham.indexOf(s);
    //        $scope.listSanPham.splice(vt, l);
    //    }, function (error) {

    //        alert('Xóa thành công');
    //    });
    //};

    $scope.Add = function () {
        $scope.sanpham = null;
    };
    $scope.Edit = function (s) {
        $scope.sanpham = s;
        console.log(s)
    };

    $http({
        method: 'get',
        url: "/Home/GetDongSP"
    }).then(function Success(d) {
        $rootScope.listDongSP = d.data;
    }), function (error) {
        alert('Lấy dòng lỗi');
        };

    $http({
        method: 'get',
        url: "/Home/GetThuongHieu"
    }).then(function Success(d) {
        $rootScope.listThuongHieu = d.data;
    }), function (error) {
        alert('Lấy thương hiệu lỗi');
    };

    //$http.get("/Home/GetDongSP").then(function (d) {
    //    $scope.listDongSP = d.data;
    //}, function (error) {
    //    alert('Lấy dòng lỗi')
    //});

    $scope.SaveAdd = function () {
        $http({
            method: 'Post',
            url: '/Admin/QLSanPham/AddSanPham',
            data: JSON.stringify($scope.sanpham)
            /*params: { s: $scope.sanpham }*/
        }).then(function (d) {
            if (d.data == "") {
                $scope.listSanPham.push($scope.sanpham);
                $scope.sanpham = null;
                $window.location.reload();
                alert("Data Submitted....!");
            }
            else {
                alert(d.data);
            }
        }, function () {
            alert("Save new records Error");
        });
    }

    $scope.SaveEdit = function () {
        $http({
            method: 'Post',
            url: '/Admin/QLSanPham/EditSanPham',
            datatype: 'Json',
            data: $scope.sanpham 
        }).then(function (d) {
            if (d.data == "") {
                alert("Data Editted....!")
                $window.location.reload();
            }
            else {
                alert(d.data);
            }
        }, function () {
            alert("Edit records Error");
        });
    }

    $scope.Delete = function (sp) {

        $http({
            method: 'Post',
            url: "/QLSanPham/DeleteSanPham",
            datatype: 'Json',
            params: { id: sp.MaSP }
        }).then(function (d) {

            var vt = $scope.listSanPham.indexOf(sp);
            $scope.listSanPham.splice(vt, l);
            $window.location.reload();
        }, function (error) {

            alert(error);
        });
    }

    $scope.UploadFiles = function (file) {
        $scope.SelectedFiles = file;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/QLSanPham/Upload',
                data: { MaSP: $scope.sanpham.MaSP, files: $scope.SelectedFiles }
            }).then(function (d) {
                $scope.sanpham.Anh = d.data[0];
            }, function (error) { alert('lỗi'); });
        }
    };

    //phân trang
    $scope.maxSize = 3;
    $scope.totalCount = 0;
    $scope.pageIndex = 1;
    $scope.pageSize = 4;
    $scope.searchName = "";

    $scope.GetSanPhamList = function (index) {
        $http.get('/SanPham/GetSanPhamPT', {
            params: {
                pageIndex: index,
                pageSize: $scope.pageSize,
                productName: $scope.searchName
            }
        }).then(
            function (response) {

                $scope.listSanPham = response.data.SanPhams;
                $scope.totalCount = response.data.totalCount;
            },
            function (err) {
                alert(err);
            });
    }
    $scope.GetSanPhamList($scope.pageIndex);



    //$scope.SaveEdit = function (files) {
    //    $http({
    //        method: 'Post',
    //        url: '/Product/EditSanPham',
    //        datatype: 'Json',
    //        data: { l: $scope.sanpham }
    //    }).then(function (d) {
    //        if (d.data == "") {
    //            for (i = 0; i < $scope.SanPhams.length; i++) {
    //                if ($scope.SanPhams[i].MaSP == $scope.sanpham.MaSP) {
    //                    $scope.SanPhams[i].TenSP == $scope.sanpham.TenSP;
    //                    $scope.SanPhams[i].MaLoai == $scope.sanpham.MaLoai;
    //                    $scope.SanPhams[i].DonVi == $scope.sanpham.DonVi;
    //                    $scope.SanPhams[i].MoTa == $scope.sanpham.MoTa;
    //                    $scope.SanPhams[i].Anh == $scope.sanpham.Anh;
    //                }
    //            }
    //        }
    //    })
    //}
});
myapp.run(function ($rootScope, $window, $http) {
    $rootScope.Logout2 = function () {

        $http.get('/Admin/Login/Logout').then(
            function (response) {
                $window.location.reload();
            },
            function (err) {
                alert('lỗi');
            });
    };
})

