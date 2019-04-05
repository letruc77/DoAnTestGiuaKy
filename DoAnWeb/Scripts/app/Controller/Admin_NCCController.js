CarShopApp.controller('Admin_NCC', function ($scope, Admin_NCCService, $http) {
    //Default variable
    $scope.submitText = "Lưu";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.NCC = {
        TenNCC : '',
        DiaChi: ''
    };
    $scope.ListNCC = {};
    //check form valid 
    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    //Save Data
    $scope.ThemNCC = function (data) {
        debugger;
        if ($scope.submitText == 'Lưu') {
            $scope.NCC = data;
            $scope.submitted = true;
            $scope.message = '';
            if ($scope.isFormValid) {
                $scope.submitText = 'Vui lòng chờ ...';
                    Admin_NCCService.SaveFormData($scope.NCC).then(function (d) {
                        debugger;
                        alert(d);
                        if (d == "Thêm thành công") {
                            ClearForm();
                        }
                        $scope.submitText = "Lưu";
                    });
            }
            else {
                $scope.message = "Vui lòng thêm đầy đủ các trường thông tin.";
            }
        }
    }
    function ClearForm() {
        $scope.NCC = {};
        $scope.f1.$setPristine();
        $scope.submitted = false;
    }
    var initial_NCC = function () {
        debugger;
        LoadListNCC();
    }
    initial_NCC();
    function LoadListNCC() {
        Admin_NCCService.LoadListNCC().then(function (response) {
            debugger;
            if (response != null) {
                $scope.ListNCC = response.data;
            }
            else {
                alert("Đã xảy ra lỗi khi load danh sách nhà cung cấp.");
            }
        });
    }
})
    .factory('Admin_NCCService', function ($http, $q) {
        var fac = {};
        fac.SaveFormData = function (data) {
            debugger;
            var defer = $q.defer();
            $http({
                url: '/Supplier/ThemNhaCungCap',
                method: 'POST',
                data: JSON.stringify(data),
                headers: { 'content-type': 'application/json' }
            }).success(function (d) {
                defer.resolve(d);
            }).error(function (e) {
                alert("Đã xảy ra lỗi khi thêm nhà cung cấp!!!");
                defer.reject(e);
            });
            return defer.promise;
        }
        fac.LoadListNCC = function () {
            debugger;
            return $http.get('/Supplier/LoadNCC');
        }
        return fac;
    });