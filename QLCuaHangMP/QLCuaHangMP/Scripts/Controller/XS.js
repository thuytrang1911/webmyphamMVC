////var myapp = angular.module("CustommerApp", []);

homeapp.controller("SanPhamControllers", function ($scope, $http) {
    $http.get('/SanPham/GetSanPham').then(function (d) {
        $scope.lsp = d.data;
    }, function (error) { alert('That bai'); });
    $scope.sortcolumn = "MaSP";
    $scope.reverse = true;
    $scope.dr = "Ascending";
    $scope.Chon = function (d) {
        if ($scope.dr == "Ascending") {
            $scope.reverse = false;
            $scope.dr = "Decreasing";
        } else {
            $scope.reverse = true;
            $scope.dr = "Ascending";
        }
    }
});