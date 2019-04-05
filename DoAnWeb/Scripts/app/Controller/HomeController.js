CarShopApp.controller('HomeController', function ($scope, $http, HomeService) {
    $scope.ListXeNew = {};
    $scope.ListXeBest = {};
    $scope.SingleXe = '';
    var initial_Xe = function () {
        LoadXeNew();
        LoadXeBest();
    }
    initial_Xe();
    function LoadXeNew() {
        HomeService.LoadXeNew().then(function (success) {
            //debugger;
            if (success != null) {
                $scope.ListXeNew = success.data;
            }
            else {
                alert("Đã xảy ra lỗi khi load danh sách xe mới nhất.");
            }
        });
    }
    function LoadXeBest() {
        HomeService.LoadXeBest().then(function (success) {
            //debugger;
            if (success != null) {
                $scope.ListXeBest = success.data;
            }
            else {
                alert("Đã xảy ra lỗi khi load danh sách xe mới bán chạy nhất.");
            }
        });
    }
    function LoadXeBest() {
        HomeService.LoadXeBest().then(function (success) {
            //debugger;
            if (success != null) {
                $scope.ListXeBest = success.data;
            }
            else {
                alert("Đã xảy ra lỗi khi load danh sách xe mới bán chạy nhất.");
            }
        });
    }
    $scope.LoadChiTietXe = function (data) {
        debugger;
        HomeService.LoadChiTietXe(data).then(function (success) {
            debugger;
            if (success != null) {
                //$scope.SingleXe = success.data;
                //window.location.href = window.location.href + 'Home/Single/' + data;
            }
            else {
                alert("Đã xảy ra lỗi khi load chi tiết xe.");
            }
        });
        //window.location.href = window.location.href + 'Home/Single/' + data;
    }
})
    .factory('HomeService', function ($http, $q) {
        var fac = {};
        fac.LoadXeNew = function () {
            return $http.get('/Home/LoadListXeNew');
        }
        fac.LoadXeBest = function () {
            return $http.get('/Home/LoadListXeBest');
        }
        fac.LoadChiTietXe = function (data) {
            debugger;
            return $http({
                url: '/Home/Single',
                method: "GET",
                params: { data: data }
            });
        }
        return fac;
    });