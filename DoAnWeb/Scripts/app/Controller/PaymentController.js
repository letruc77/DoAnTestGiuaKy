CarShopApp.controller('PaymentController', function ($scope, PaymentService) {
    // khai bao bien
    $scope.submitText = "Thanh Toán";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.order = {
        TenKhachHang: '',
        SoDienThoai: '',
        DiaChi: ''
    }

    //check form valid 
    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });

    //Save Data
    $scope.Payment = function (data) {
        debugger;
        if ($scope.submitText == 'Thanh Toán') {
            $scope.order = data;
            $scope.submitted = true;
            $scope.message = '';
            if ($scope.isFormValid) {
                $scope.submitText = 'Vui lòng chờ ...';
                PaymentService.Register($scope.order).then(function (d) {
                    alert(d);
                    if (d == "Success") {
                        ClearForm();
                    }
                    $scope.submitText = "Thanh Toán";
                });
            }
            else {
                $scope.message = "Vui lòng thêm đầy đủ các trường thông tin.";
            }
        }
    }
})
    .factory('PaymentService', function ($http, $q) {
        var fac = {};
        fac.Register = function (data) {
            debugger;
            var defer = $q.defer();
            $http({
                url: '/Cart/Payment',
                method: 'POST',
                data: JSON.stringify(data),
                headers: { 'content-type': 'application/json' }
            }).success(function (d) {
                debugger;
                defer.resolve(d);
            }).error(function (e) {
                debugger;
                alert("Đã xảy ra lỗi khi Thanh Toán!!!");
                defer.reject(e);
            });
            return defer.promise;
        }
        return fac;
    });