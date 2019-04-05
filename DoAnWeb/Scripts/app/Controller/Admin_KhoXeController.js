CarShopApp.controller('Admin_KhoXe', function ($scope, $http, Admin_KhoXeService) {
    //Default variable
    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.fileList = [];
    $scope.curFile;
    $scope.flag = false;
    $scope.ListKhoXe = {};
    $scope.KhoXe = {
        TenKho: '',
        DiaChi: ''
    }
    //check form valid 
    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    var initial_KhoXe = function () {
        LoadListKhoXe();
    }
    initial_KhoXe();
    function LoadListKhoXe() {
        Admin_KhoXeService.LoadListKhoXe().then(function (success) {
            if (success != null) {
                $scope.ListKhoXe = success.data;
            }
            else {
                alert("Đã xảy ra lỗi khi load danh sách kho xe.");
            }
        });
    }
    //phần thêm kho xe
    $scope.ThemKhoXe = function (data) {
        debugger;
        if ($scope.submitText == 'Save') {
            $scope.KhoXe = data;
            $scope.submitted = true;
            $scope.message = '';
            if ($scope.isFormValid) {
                $scope.submitText = 'Vui lòng chờ ...';
                Admin_KhoXeService.SaveKhoXe($scope.KhoXe).then(function (response) {
                    debugger;
                    if (response == "Success") {
                        ClearFormKhoXe();
                        alert("Đã thêm kho xe thành công");
                    }
                    $scope.submitText = "Save";
                });
            }
            else {
                $scope.message = "Vui lòng thêm đầy đủ các trường thông tin.";
            }
        }
    }
    function ClearFormKhoXe() {
        $scope.KhoXe = {};
        $scope.f1.$setPristine();
        $scope.submitted = false;
    }
})
    .factory('Admin_KhoXeService', function ($http, $q) {
        var fac = {};
        fac.LoadListKhoXe = function () {
            return $http.get('/Products/InitalKhoXe');
        }
        fac.SaveKhoXe = function (data) {
            debugger;
            var defer = $q.defer();
            $http({
                url: '/Products/ThemKhoXe',
                method: 'POST',
                data: JSON.stringify(data),
                headers: { 'content-type': 'application/json' }
            }).success(function (d) {
                defer.resolve(d);
            }).error(function (e) {
                alert("Đã xảy ra lỗi khi thêm kho xe!!!");
                defer.reject(e);
            });
            return defer.promise;
        }
        return fac;
    });