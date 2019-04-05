CarShopApp.controller('Admin_Report', function ($scope, $http, Admin_ReportService) {
    //Default variable
    $scope.submitText = "Tìm kiếm";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.fileList = [];
    $scope.curFile;
    $scope.flag = false;
    $scope.ListThu = {};
    $scope.report = {
        TuNgay: '',
        DenNgay: ''
    }
    //check form valid 
    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    function LoadListReportThu() {
        Admin_ReportService.LoadListReportThu(report.TuNgay, report.DenNgay).then(function (success) {
            debugger;
            alert(success.data);
            if (success != null) {
                $scope.ListThu = success.data;
            }
            else {
                alert("Đã xảy ra lỗi khi load danh sách kho xe.");
            }
        });
    }
})
    .factory('Admin_ReportService', function ($http, $q) {
        var fac = {};
        fac.LoadListReportThu = function (data) {
            var defer = $q.defer();
            $http({
                url: '/Revenue/InitalThu',
                method: 'POST',
                data: JSON.stringify(data),
                headers: { 'content-type': 'application/json' }
            }).success(function (d) {
                defer.resolve(d);
            }).error(function (e) {
                alert("Đã xảy ra lỗi khi lấy danh sách hóa đơn thu!!!");
                defer.reject(e);
            });
            return defer.promise;
        }
        return fac;
    });