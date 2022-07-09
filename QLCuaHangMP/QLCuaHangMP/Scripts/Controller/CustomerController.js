/// <reference path="../angular.min.js" />
var homeapp = angular.module("CustommerApp", ['angularUtils.directives.dirPagination']);

//lấy menu
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

// Lấy về tất cả thương hiệu
homeapp.controller("ThuongHieuController", function ($scope, $http) { 
    $http.get("/ThuongHieu/GetThuongHieu").then(function (d) {
        $scope.ThuongHieus = d.data;
    }, function (error) {
        alert('Failed');
    });
});

//lấy về tất cả sp lên Home
homeapp.controller("SanPhamControllers",
    function ($rootScope, $scope, $http) {
        $scope.CTSP = function (a) {
            localStorage.setItem("MaSP", a);
            location.href = '/CTSanPham/Index';
        };

        $http.get('/SanPham/GetSanPham').then(function Success(d) {
            $rootScope.lsp = d.data;
        },
        function (error) {
            alert('That bai');
            });

        //phân trang
        $rootScope.maxSize = 3;
        $rootScope.totalCount = 0;
        $rootScope.pageIndex = 1;
        $rootScope.pageSize = 8;
        $rootScope.searchName = "";

        $scope.GetSanPhamList = function (index) {
            $http.get('/SanPham/GetSanPhamPT', {
                params: {
                    pageIndex: index,
                    pageSize: $rootScope.pageSize,
                    productName: $rootScope.searchName
                }
            }).then(
                function (response) {

                    $scope.listSanPham = response.data.SanPhams;
                    $rootScope.totalCount = response.data.totalCount;
                },
                function (err) {
                    alert(err);
                });
        }
        $scope.GetSanPhamList($scope.pageIndex);

       //lấy giỏ hàng
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

            location.href = '/GioHang/Index';
        };
        //khi nhấn thì đảo chiều sắp xếp
        $http.get('/SanPham/GetSanPham').then(function (d) {
            $scope.lsp = d.data;
        }, function (error) { alert('That bai'); });
        $rootScope.sortcolumn = "MaSP";
        $rootScope.sortcolumn = "TenSP";
        $rootScope.sortcolumn = "GiaBan";
        $rootScope.reverse = true;
        $rootScope.dr = "Ascending";
        $rootScope.Chon = function (d) {
            if ($rootScope.dr == "Ascending") {
                $rootScope.reverse = false;
                $rootScope.dr = "Decreasing";
            } else {
                $rootScope.reverse = true;
                $rootScope.dr = "Ascending";
            }
        };

        //lấy sp bán chạy
        $http({
            method: "get",
            url: "/SanPham/GetDSSPBanChay"
        }).then(function Success(d) {
            $scope.SPBanChay = d.data;
        },

        function error(e) {
            alert("Lấy sản phẩm lỗi");
        });
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


homeapp.controller("CTSanPhamController", function ($scope, $http) {
    //alert("có vào");
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
//homeapp.controller("LoginController", function ($rootScope, $scope, $http) {
//    $rootScope.close = "";
//    $rootScope.Khach = null;

//    $rootScope.login = 0;
//    $rootScope.remember = false;
//    $rootScope.userName = "";
//    $rootScope.Logout = function () {
//        $http.get('/Home/Logout').then(function (d) {
//            $rootScope.Log = "Login";

//        }, function () { });
//    };
//    $rootScope.Login = function (un, pw, rp) {
//        $http({
//            url: '/Home/Login',
//            method: 'get',
//            params: {
//                us: un,
//                pw: pw,
//                rp: rp
//            }
//        }).then(function success(d) {
//            if (d.data.login == "0") {//đăng nhập k thành công
//                alert('Tài khoản không dúng yêu cầu nhập lại');
//            }
//            else {//đăng nhập thành công đóng giao diện đăng nhập,...
//                alert('Đăng nhập thàng công');
//            }
//        }, function error(e) { });
//    }
//});

//đăng kí
homeapp.controller("DangKiController", function ($rootScope, $scope, $http, $window) {
    $http({
        method: "get",
        url: "/Home/LayDSKH"
    }).then(function Success(d) {
        $scope.KhachHangs = d.data;
    },
        function error(e) {
            alert("Lấy lỗi");
        });

    $scope.Add = function () {
        $scope.khachhang = null;
    };

    $scope.Save = function () {
        $http({
            method: 'post',
            url: '/Home/Signup',
            data: JSON.stringify($scope.khachhang)
        }).then(function (d) {
            if (d.data == "") {
                $scope.KhachHangs.push($scope.khachhang);
                $scope.khachhang = null;
                alert("Đăng kí  thành công")
                $window.location.href = "/Home/Index";
            }
            else {
                alert("Đăng kí  thành công")
                $window.location.href = "/Home/Index";
            }
        }, function () {
            alert("Thêm lỗi");
        });
    }
});



//đăng nhập
homeapp.controller("LoginController", function ($rootScope, $scope, $http) {
    $rootScope.close = "";
    $rootScope.Khach = null;

    $rootScope.login = 0;
    $rootScope.image = "";
    $rootScope.login_state = "Đăng nhập";
    if (sessionStorage.getItem("username") == null) {
        $rootScope.login_state = "Đăng nhập";
    } else {
        $rootScope.login_state = "Đăng xuất";
    }
    $rootScope.userName = sessionStorage.getItem("username");
    $rootScope.remember = false;

    $rootScope.Logout = function () {
        $http.get('/Home/Logout').then(function (d) {
            $rootScope.Log = "Login";
            $rootScope.login_state = "Đăng nhập";
            $rootScope.Log = "Login";
            sessionStorage.removeItem("username");
        }, function () { });
    };

    //đăng ký
    $rootScope.Signup = function () {
        $scope.KhachHang.MaKH = Math.floor(Math.random() * 101);
        console.log($scope.KhachHang)
        $http({
            method: 'post',
            url: '/Home/Signup',
            data: $scope.KhachHang 
        }).then(function (res) {
            if (res.data) {
                alert('Đăng ký thất bại')
            }
            else {
                alert('Đăng ký thành công')
            }
        }, function () {
            alert('Thất bại')
        })
    }

    $rootScope.Login = function (un, pw, rp) {
        $http.get('/Home/Login', {
            params: {
                us: un,
                pas: pw,
                rp: rp
            }
        }).then(function success(d) {
            
            if (d.data.login == 0) {//đăng nhập k thành công
                $rootScope.close = '';
                $rootScope.login = d.data.login;
                console.log($rootScope.login)
                alert('Tài khoản không dúng yêu cầu nhập lại');
            }
            else {//đăng nhập thành công đóng giao diện đăng nhập,...
                $rootScope.login = d.data.login;
                $rootScope.userName = d.data.Khach.UserName;//lưu username vào session
                sessionStorage.setItem("username", d.data.Khach.UserName);
                $rootScope.login_state = "Đăng xuất";
                $rootScope.close = "modal";
                alert('Đăng nhập thàng công');
            }
        }, function error(e) { });
    };
});



//giỏ hàng
homeapp.controller("CartController", function ($window, $scope, $rootScope, $http) {
    $rootScope.DangNhap = "";
    $rootScope.DatHang = "";
    $rootScope.SoLuong = 0;
    $rootScope.Log = "Login";
    $rootScope.TinhTong = function () {
        $rootScope.TT = 0
        $rootScope.dsDonHang.forEach((item) => {
            $rootScope.TT += item.Gia * item.SoLuong
            //$rootScope.SoLuong += item.SoLuong
        })
    }
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

    $rootScope.Delete = function (masp) {
        $http({
            metohd: 'get',
            url: '/GioHang/XoaSP',
            params: { masp: masp }
        }).then(
            function (d) {
                location.reload();
            }, function () {
                alert("Customer lỗi");
            })
    };

    $rootScope.KiemTraDangNhap = function () {
       
        $http.get('/DatHang/ReadCustomer').then(
            function (d) {
                if (d.data.login == "1") {
                    $rootScope.DangNhap = "";
                    $rootScope.KhachHang = d.data.Khach;
                    console.log($rootScope.Khach);
                    $http.get('/GioHang/GetCart').then(function (d) {
                        $rootScope.dsDonHang = d.data.dsDonHang;
                        $rootScope.SoLuong = d.data.SoLuong;
                        $rootScope.ThanhTien = d.data.ThanhTien;
                        $window.location.href = '/DatHang/Index';

                    }, function (e) { });
                }
                else {
                    $rootScope.DangNhap= '#Login';

                }
            }, function() {
                alert("Bạn chưa đăng nhập")
            });
    };

}, function() { alert("Lỗi") });


//đặt hàng
homeapp.controller("DatHangController", function ($rootScope, $scope, $http, $window) {
    $rootScope.KhachHang = null;
    $http.get('/DatHang/GetCustomer').then(function (d) {
        $rootScope.KhachHang = d.data.khach;
    }, function () {
        alert("Customer Lỗi")
    })
    $scope.ContinueShopping = function () {
        $window.history.back();// quay lại trang trc
    }
    $http({
        method: 'get',
        datatype: 'json',
        url: '/GioHang/GetCart',
    }).then(function success(d) {
        $rootScope.dsDonHang = d.data.dsDonHang;
        $rootScope.SL = d.data.SoLuong;
        $rootScope.TT = d.data.ThanhTien;
    }, function error(e) { alert("Gio Hang loi"); });
    $rootScope.TinhTong = function () {
        $rootScope.TT = 0
        $rootScope.dsDonHang.forEach((item) => {
            $rootScope.TT += item.Gia * item.SoLuong
            //$rootScope.SoLuong += item.SoLuong
        })
    }
    $rootScope.DatHang = function () {
        $http({
            method: 'Post',
            datatype: 'Json',
            url: 'DatHang/DatHang',
            params: {
                khachhang: JSON.stringify($rootScope.KhachHang),
                tong: JSON.stringify($rootScope.TT),
                dsdonhang: JSON.stringify($rootScope.dsDonHang)
            }
        }).then(function (d) { alert("thanh cong"); }, function () { });
    };
});