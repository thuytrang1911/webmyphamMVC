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

homeapp.controller("MenuControllers",
    function ($scope, $rootScope, $http) {
        $http({
            method: 'get',
            url: '/Home/GetThuongHieu'
        }).then(function Success(d) {

            $rootScope.listThuongHieu = d.data;
        },
            function Error() {
                alert("Lấy thương hiệu lỗi");
            });

        $scope.SelectThuongHieu = function (t) {
            localStorage.setItem("MaTH", t);
        }
    });

homeapp.controller("ThuongHieuController", function ($scope, $http) {
    // Lấy về tất cả thương hiệu
    $http.get("/ThuongHieu/GetThuongHieu").then(function (d) {
        $scope.ThuongHieus = d.data;
    }, function (error) {
        alert('Failed');
    });
});

//lấy về tất cả sp lên Home
homeapp.controller("SanPhamControllers",
    function ($rootScope, $scope, $http) {
        $http.get('/SanPham/GetSanPham').then(function Success(d) {
            $rootScope.lsp = d.data;
        },
            function (error) {
                alert('That bai');
            });

        $scope.CTSP = function (a) {
            localStorage.setItem("MaSP", a);
        };
        $rootScope.AddCart = function (s) {
            $http({
                method: 'post',
                datatype: 'json',
                url: '/GioHang/AddCart',
                data: { sp: s }
            }).then(function (d) {
                $http({
                    method: 'get',
                    datatype: 'json',
                    url: '/GioHang/GetCart',

                }).then(function success(d) {
                    $rootScope.dsDonHang = d.data.dsDonHang;
                    //alert(d.data.dsDonHang)
                    $rootScope.SL = d.data.SoLuong;
                    $rootScope.TT = d.data.ThanhTien;
                    if ($rootScope.dsDonHang.length > 0) {
                        $scope.Het = "false";
                    }
                    else { $scope.Het = "true"; }
                    console.log("So Luong:"); console.log($rootScope.SL);
                    console.log("Thanh Tien:"); console.log($rootScope.TT);
                }, function error(e) { alert("Gio Hang loi"); });
            }, function () { alert("Lỗi"); });
        };


    });

//lấy về ds sp theo dòng
homeapp.controller("SanPhamController", function ($scope, $rootScope, $http) {

    var madong = localStorage.getItem("MaDong");
    $http({
        method: "get",
        url: "/SanPham/GetSanPhamDong",
        params: { MaDongSP: madong }//localStorage.getItem("MaLoai") }
    }).then(function Success(d) {
        $scope.listSanPham = d.data;
    }, function error(e) {
        alert("Lấy dòng sản phẩm lỗi");
    });
    $scope.CTSP = function (a) {
        localStorage.setItem("MaSP", a);
    }
});

//lấy về dssp thoe th
homeapp.controller("THController", function ($scope, $rootScope, $http) {

    var math = localStorage.getItem("MaTH");
    $http({
        method: "get",
        url: "/SanPham/GetSanPhamTH",
        params: { MaTH: math }
    }).then(function Success(d) {
        $scope.listSanPham = d.data;
    }, function error(e) {
        alert("Lấy thuong hiệu lỗi");
    });
    $scope.CTSP = function (a) {
        localStorage.setItem("MaSP", a);
    }
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
    alert("có vào");
    $http({
        method: "get",
        url: "/CTSanPham/GetSanPham",
        params: { MaSP: localStorage.getItem("MaSP") }
    }).then(function Success(d) {
        $scope.s = d.data;
    }, function error() {
        alert("Lấy ct lỗi")
    });

});

//đăng nhập
homeapp.controller("LoginController", function ($rootScope, $scope, $http) {
    $rootScope.close = "";
    $rootScope.Khach = null;

    $rootScope.login = 0;
    $rootScope.remember = false;
    $rootScope.userName = "";
    $rootScope.Logout = function () {
        $http.get('/Home/Logout').then(function (d) {
            $rootScope.Log = "Login";

        }, function () { });
    };
    $rootScope.Login = function (un, pw, rp) {
        $http({
            url: '/Home/Login',
            method: 'get',
            params: {
                us: un,
                pw: pw,
                rp: rp
            }
        }).then(function success(d) {
            if (d.data.login == "0") {//đăng nhập k thành công
                alert('Tài khoản không dúng yêu cầu nhập lại');
            }
            else {//đăng nhập thành công đóng giao diện đăng nhập,...
                alert('Đăng nhập thàng công');
            }
        }, function error(e) { });
    }
});

//đăng nhập
//homeapp.controller("LoginController", function ($rootScope, $scope, $http) {
//    $rootScope.close = "";
//    $rootScope.Khach = null;

//    $rootScope.login = 0;
//    $rootScope.image = "";
//    $rootScope.login_state = "Đăng nhập";
//    if (sessionStorage.getItem("username") == null){
//        $rootScope.login_state = "Đăng nhập";
//    } else {
//        $rootScope.login_state = "Đăng xuất";
//    }
//    $rootScope.userName = sessionStorage.getItem("username");
//    $rootScope.remember = false;
//    $rootScope.Logout = function () {
//        $http.get('/Home/Logout').then(function (d) {
//            $rootScope.Log = "Login";

//        }, function () { });
//    };
//    $rootScope.Login = function (un, pw, rp) {
//        $http.get('/Home/Login', {
//            params: {
//                us: un,
//                pw: pw,
//                rp: rp
//            }
//        }).then(function success(d) {
//            if (d.data.login == "0") {//đăng nhập k thành công
//                $rootScope.close = '';
//                $rootScope.login = d.data.login;
//                alert('Tài khoản không dúng yêu cầu nhập lại');
//            }
//            else {//đăng nhập thành công đóng giao diện đăng nhập,...
//                $rootScope.login = d.data.login;
//                $rootScope.userName = d.data.Khach.UserName;//lưu username vào session
//                $rootScope.login_state = "Đăng xuất";
//                $rootScope.close = "modal";
//                alert('Đăng nhập thàng công');
//            }
//        }, function error(e) { });


//giỏ hàng
homeapp.controller("CartController", function ($window, $scope, $rootScope, $http) {
    $rootScope.DangNhap = "#Login";
    $rootScope.DatHang = "";
    $rootScope.SoLuong = 0;
    $rootScope.Log = "Login";

    $rootScope.KhachHang = null;

    // Lấy về các sản phẩm trong giỏ hàng lên giao diện
    $http({
        method: 'get',
        datatype: 'json',
        url: '/GioHang/GetCart',

    }).then(function Success(d) {
        $rootScope.dsDonHang = d.data.dsDonHang;
        $rootScope.SL = d.data.SoLuong;
        $rootScope.TT = d.data.ThanhTien;
        if ($rootScope.dsDonHang.lenght > 0) {
            $scope.Het = "false";
        }
        else { $scope.Het = "true"; }
        console.log("So Luong:"); console.log($rootScope.SL);
        console.log("Thanh Tien:"); console.log($rootScope.TT);
    }, function error(e) {
        alert('Gio hang loi');
    });
    $scope.ContinueShopping = function () {
        $window.history.back();// quay lại trang trc
    };
    $rootScope.KiemTraDangNhap = function () {
        $http.get('/DatHang/GetCustomer').then(
            function (d) {
                if (d.data.login == "1") {
                    $rootScope.DangNhap = "";
                    $rootScope.KhachHang = d.data.Khach;
                    console.log(JSON.stringify($rootScope.Khach));
                    $http.get('/GioHang/GetCart').then(function (d) {
                        $rootScope.dsDonHang = d.data.DSDonHang;
                        $rootScope.SoLuong = d.data.SoLuong;
                        $rootScope.ThanhTien = d.data.ThanhTien;
                        $window.location.href = '/DatHang/Index';

                    }, function (e) { });
                }
                else {
                    $rootScope.DangNhap = '#Login';

                }
            }, function error(e) {
                alert("Lỗi")
            });
    }

}, function error(e) { alert("Lỗi") });

//đặt hàng
homeapp.controller("DatHangController", function ($scope, $rootScope, $http) {
    $rootScope.KhachHang = null;
    $http.get('/DatHang/GetCustomer').then(function (d) {
        $rootScope.KhachHang = d.data.khach;
    }, function () {
        alert("Customer Lỗi")
    });

    //console.log("Khach: "); console.log($rootScope.Customer);
    //$rootScope.DatHang = function () {
    //    $rootScope.DonHang.Khach = $rootScope.Khach;
    //    $rootScope.DonHang.TongTien = $rootScope.Tong;
    //    $rootScope.DonHang.LctDonHang = $rootScope.dsDonHang;
    //    $http({
    //        method: 'POST',
    //        datatype: 'json',
    //        url: '/DatHang/DatHang',
    //        data: JSON.stringify($rootScope.DonHang)
    //    }).then(function (d) {
    //    }, function () { })
    //}
});