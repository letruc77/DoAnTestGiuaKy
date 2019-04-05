CarShopApp.controller('Admin_LoaiXe', function ($scope, $http, Admin_LoaiXeService) {
    //Default variable
    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.flag = false;
    $scope.ListLoaiXe = {};
    $scope.LoaiXe = {
        TenLoaiXe: ''
    }

    //check form valid 
    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });

    var initial_LoaiXe = function () {
        LoadListLoaiXe();
    }
    initial_LoaiXe();

    function LoadListLoaiXe() {
        //debugger;
        Admin_LoaiXeService.LoadListLoaiXe().then(function (success1) {
            //debugger;
            if (success1 != null) {
                $scope.ListLoaiXe = success1.data;
            }
            else {
                alert("Đã xảy ra lỗi khi load danh sách loại xe.");
            }
        });
    }
    //them loai xe
    $scope.ThemLoaiXe = function (data) {
        debugger;
        if ($scope.submitText == 'Save') {
            $scope.LoaiXe = data;

            $scope.submitted = true;
            $scope.message = '';
            if ($scope.isFormValid) {
                $scope.submitText = 'Vui lòng chờ ...';
                Admin_LoaiXeService.SaveLoaiXe($scope.LoaiXe).then(function (response) {
                    debugger;
                    if (response == "Success") {
                        ClearFormLoaiXe();
                        alert("Đã thêm loại xe thành công");
                    }
                    $scope.submitText = "Save";
                });
            }
            else {
                $scope.message = "Vui lòng thêm đầy đủ các trường thông tin.";
            }
        }
    }
    function ClearFormLoaiXe() {
        $scope.LoaiXe = {};
        $scope.f1.$setPristine();
        $scope.submitted = false;
    }
})
    .factory('Admin_LoaiXeService', function ($http, $q) {
        var fac = {};
        fac.LoadListLoaiXe = function () {
            return $http.get('/Products/InitalLoaiXe');
        }
        fac.SaveLoaiXe = function (data) {
            debugger;
            var defer = $q.defer();
            $http({
                url: '/Products/ThemLoaiXe',
                method: 'POST',
                data: JSON.stringify(data),
                headers: { 'content-type': 'application/json' }
            }).success(function (d) {
                defer.resolve(d);
            }).error(function (e) {
                alert("Đã xảy ra lỗi khi thêm loại xe!!!");
                defer.reject(e);
            });
            return defer.promise;
        }
        return fac;
    });