CarShopApp.controller('Admin_Products', function ($scope, $http, Admin_ProductsService) {
    //Default variable
    $scope.submitText = "Save";
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.SelectedFileForUpload = null;
    $scope.Xe = {
        SoKhung: '',
        SoMay: '',
        MaLoaiXe: '',
        ChiTiet: '',
        IdKhoXe: '',
        NgayNhap: '',
        IdNhaCungCap: '',
        GiaVon: '',
        GiaNiemYet: '',
        Hinh1: '',
        Hinh2: '',
        Hinh3:''
    }
    $scope.fileList = [];
    $scope.curFile;
    $scope.ImageProperty = {
        file: ''
    }
    $scope.flag = false;
    $scope.ListLoaiXeIndex = {};
    $scope.ListLoaiXe = {};
    $scope.ListKhoXe = {};
    $scope.ListNCC = {};
    $scope.ListXe = {};
    $scope.LoaiXe = {
        TenLoaiXe: ''
    }
    $scope.KhoXe = {
        TenKho: '',
        DiaChi : ''
    }
    //check form valid 
    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    $scope.checkFile = function (file) {
        if ($scope.SelectedFileForUpload != null) {
            if (file.type == 'image/png' || file.type == 'image/jpg' || file.type == 'image/jpeg' || file.type == 'image/gif') {
                $scope.message = '';
            }
            else
            {
                $scope.message = 'File cần upload phải là file hình';
            }
        }
        return $scope.message;
    }
    

    $scope.setFile = function (element) {
        //debugger;
        $scope.fileList = [];
        // get the files
        var files = element.files;
        for (var i = 0; i < files.length; i++) {
            $scope.ImageProperty.file = files[i];

            $scope.fileList.push($scope.ImageProperty);
            $scope.ImageProperty = {};
            $scope.$apply();
        }
        $scope.flag = true;
    }
    $scope.UploadFile = function () {
        debugger;
        for (var i = 0; i < $scope.fileList.length; i++) {

            $scope.UploadFileIndividual($scope.fileList[i].file,
                $scope.fileList[i].file.name,
                $scope.fileList[i].file.type,
                $scope.fileList[i].file.size,
                i);
        }

    }
    $scope.UploadFileIndividual = function (fileToUpload, name, type, size, index) {
        debugger;
        var reqObj = new XMLHttpRequest();
        reqObj.open("POST", "/Products/UploadFiles", true);

        reqObj.setRequestHeader("Content-Type", "multipart/form-data");
        reqObj.setRequestHeader('X-File-Name', name);
        reqObj.setRequestHeader('X-File-Type', type);
        reqObj.setRequestHeader('X-File-Size', size);

        reqObj.send(fileToUpload);

    }
    //Save Data
    $scope.ThemXe = function (data) {
        debugger;
        if ($scope.submitText == 'Save') {
            $scope.Xe = data;
            $scope.Xe.Hinh1 = $scope.fileList[0].file.name;
            $scope.Xe.Hinh2 = $scope.fileList[1].file.name;
            $scope.Xe.Hinh3 = $scope.fileList[2].file.name;
            $scope.submitted = true;
            $scope.message = '';
            var lenghtHinh = $scope.fileList.length;
            if (lenghtHinh < 3) {
                $scope.message = "Vui lòng chọn đủ 3 hình!";
                return;
            }
            $scope.message = $scope.checkFile($scope.Xe.Hinh1);
            if ($scope.message != '')
                return $scope.message;
            $scope.message = $scope.checkFile($scope.Xe.Hinh1);
            if ($scope.message != '')
                return $scope.message;
            $scope.message = $scope.checkFile($scope.Xe.Hinh1);
            if ($scope.message != '')
                return $scope.message;
            if ($scope.isFormValid) {
                $scope.UploadFile();
                $scope.submitText = 'Vui lòng chờ ...';
                if ($scope.flag == true) {
                    Admin_ProductsService.SaveFormData($scope.Xe).then(function (response) {
                        //alert(response);
                        debugger;
                        if (response == "Bạn đã thêm xe thành công.") {
                            ClearFormXe();
                            alert("Thêm xe thành công");
                            //$window.location.href = 'http://localhost:54440/Admin/Products/Index';
                        }
                        $scope.submitText = "Save";
                    });
                }
            }
            else {
                $scope.message = "Vui lòng thêm đầy đủ các trường thông tin.";
            }
        }
    }
    function ClearFormXe() {
        debugger;
        $scope.Xe = {};
        $scope.Xe.TenXe = '';
        $scope.f1.$setPristine();
        $scope.submitted = false;
    }
    
    function LoadListKhoXe() {
        Admin_ProductsService.LoadListKhoXe().then(function (success) {
            if (success != null) {
                $scope.ListKhoXe = success.data;
            }
            else {
                alert("Đã xảy ra lỗi khi load danh sách kho xe.");
            }
        });
    }
    function LoadListLoaiXe() {
        Admin_ProductsService.LoadListLoaiXe().then(function (success1) {
            if (success1 != null) {
                $scope.ListLoaiXe = success1.data;
            }
            else {
                alert("Đã xảy ra lỗi khi load danh sách loại xe.");
            }
        });
    }
    function LoadListNCC() {
        Admin_ProductsService.LoadListNCC().then(function (response) {
            if (response != null) {
                $scope.ListNCC = response.data;
            }
            else {
                alert("Đã xảy ra lỗi khi load danh sách nhà cung cấp.");
            }
        });
    }
    function LoadListXe() {
        Admin_ProductsService.LoadListXe().then(function (response) {
            if (response != null) {
                $scope.ListXe = response.data;
            }
            else {
                alert("Đã xảy ra lỗi khi load danh sách xe.");
            }
        });
    }

    var initial = function () {
        //debugger;
        LoadListKhoXe();
        LoadListNCC();
        LoadListXe();
        LoadListLoaiXe();
    }
    initial();

    //them loai xe
    $scope.ThemLoaiXe = function (data) {
        debugger;
        if ($scope.submitText == 'Save') {
            $scope.LoaiXe = data;

            $scope.submitted = true;
            $scope.message = '';
            if ($scope.isFormValid) {
                $scope.submitText = 'Vui lòng chờ ...';
                Admin_ProductsService.SaveLoaiXe($scope.LoaiXe).then(function (response) {
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
    //phần thêm kho xe
    $scope.ThemKhoXe = function (data) {
        debugger;
        if ($scope.submitText == 'Save') {
            $scope.KhoXe = data;
            $scope.submitted = true;
            $scope.message = '';
            if ($scope.isFormValid) {
                $scope.submitText = 'Vui lòng chờ ...';
                Admin_ProductsService.SaveKhoXe($scope.KhoXe).then(function (response) {
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
    .factory('Admin_ProductsService', function ($http,$q) {
        var fac = {};
        fac.SaveFormData = function (data) {
            debugger;
            var defer = $q.defer();
            $http({
                url: '/Products/ThemXe',
                method: 'POST',
                data: JSON.stringify(data),
                headers: { 'content-type': 'application/json' }
            }).success(function (d) {
                defer.resolve(d);
            }).error(function (e) {
                alert("Đã xảy ra lỗi khi thêm xe!!!");
                defer.reject(e);
                });
            return defer.promise;
        }
        fac.LoadListKhoXe = function () {
            return $http.get('/Products/InitalKhoXe');
        }
        fac.LoadListLoaiXe = function () {
            return $http.get('/Products/InitalLoaiXe');
        }
        fac.LoadListNCC = function () {
            return $http.get('/Supplier/InitalNCC_New');
        }
        fac.LoadListXe = function () {
            return $http.get('/Products/DanhSachXe');
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