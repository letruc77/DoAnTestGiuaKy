CarShopApp.controller('LoginController', function ($scope, LoginService,$window) {
    // khai bao bien
    $scope.submitText = "Đăng ký";
    $scope.submitTextDN = "Đăng nhập";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.nguoidung = {
        TenNguoiDung: '',
        PassWord: '',
        Email: '',
        SoDienThoai: ''
    }

    //check form valid 
    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });

    //Save Data
    $scope.Dangky = function (data) {
        debugger;
        if ($scope.submitText == 'Đăng ký') {
            $scope.nguoidung = data;
            $scope.submitted = true;
            $scope.message = '';
            if ($scope.isFormValid) {
                $scope.submitText = 'Vui lòng chờ ...';
                LoginService.Register($scope.nguoidung).then(function (d) {
                    alert(d);
                    if (d == "Success") {
                        ClearForm();
                    }
                    $scope.submitText = "Đăng ký";
                });
            }
            else {
                $scope.message = "Vui lòng thêm đầy đủ các trường thông tin.";
            }
        }
    }


    // login
    // khai bao bien
    $scope.nguoidung = {
        PassWord: '',
        Email: ''
    }

    //check form valid 
    //$scope.$watch('f1.$valid', function (newValue) {
    //    $scope.isFormValid = newValue;
    //});

    //Save Data
    $scope.Dangnhap = function (data) {
        debugger;
        if ($scope.submitTextDN == 'Đăng nhập') {
            $scope.nguoidung = data;
            $scope.submitted = true;
            $scope.message = '';
            if ($scope.isFormValid) {
                $scope.submitTextDN = 'Vui lòng chờ ...';
                LoginService.Login($scope.nguoidung).then(function (respone) {
                    debugger;
                    if (respone != null) {
                        ClearForm();
                        alert("Bạn đã đăng nhập thành công!");
                        $window.location.href = "/Home/Index";
                    }
                    $scope.submitTextDN = "Đăng nhập";
                });
            }
            else {
                $scope.message = "Vui lòng thêm đầy đủ các trường thông tin.";
            }
        }
    }
    function ClearForm() {
        $scope.nguoidung = {};
        $scope.f1.$setPristine();
        $scope.submitted = false;
    }
})

    .factory('LoginService', function ($http, $q, $window) {
        var fac = {};
        fac.Register = function (data) {
            debugger;
            var defer = $q.defer();
            $http({
                url: '/Login/Register',
                method: 'POST',
                data: JSON.stringify(data),
                headers: { 'content-type': 'application/json' }
            })
        }
        fac.Login = function (data) {
            debugger;
            var defer = $q.defer();
            $http({
                url: '/Login/Login',
                method: 'POST',
                data: JSON.stringify(data),
                headers: { 'content-type': 'application/json' }
            })
            $window.location.href = "/Home/Index";
        }
        return fac;
    });