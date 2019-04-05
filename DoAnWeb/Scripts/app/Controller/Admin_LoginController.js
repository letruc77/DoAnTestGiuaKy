CarShopApp.controller('Admin_Login', function ($scope, Admin_LoginService, $location,$window) {
    //Default variable
    $scope.submitText = "Đăng nhập";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.nguoiDung = {
        TenNguoiDung: '',
        PassWord: ''
    };
    //check form valid 
    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    //Save Data
    $scope.DangNhap = function (data) {
        if ($scope.submitText == 'Đăng nhập') {
            $scope.NCC = data;
            $scope.submitted = true;
            $scope.message = '';
            if ($scope.isFormValid) {
                $scope.submitText = 'Vui lòng chờ ...';
                Admin_LoginService.DangNhap($scope.nguoiDung).then(function (response) {
                    if (response.data == "success") {
                        ClearForm();
                        var link = $location.path();
                        //link = link.remove("/#");
                        $window.location.href = 'http://localhost:54440/admin/admin/adminhome';
                        //$window.location.href = link + '/admin/admin/adminhome';
                    }
                    else {
                        alert(response.data);
                        return;
                    }
                    $scope.submitText = "Đăng nhập";
                    });
            }
            else {
                $scope.message = "Vui lòng thêm đầy đủ các trường thông tin.";
            }
        }
    }
    function ClearForm() {
        $scope.nguoiDung = {};
        $scope.f1.$setPristine();
        $scope.submitted = false;
    }
})
    .factory('Admin_LoginService', function ($http, $q) {
        var fac = {};
        fac.DangNhap = function (data) {
            return $http({
                url: '/AdminLogin/AdminLogin',
                method: 'POST',
                data: JSON.stringify(data),
                headers: { 'content-type': 'application/json' }
            })
        }
        return fac;
    });