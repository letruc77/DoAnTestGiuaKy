var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        // tiếp tục mua hàng
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });

        $('#btnPlus').off('click').on('click', function () {
            var sl = parseFloat($('#txtSoLuong').val());
            sl++;
            $('#txtSoLuong').val(sl);
        });

        $('#btnReduce').off('click').on('click', function () {
            var sl = parseFloat($('#txtSoLuong').val());
            sl--;
            $('#txtSoLuong').val(sl);
        });


        //update giỏ hàng
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('#txtSoLuong');
            var cartList = [];
            $.each(listProduct, function (e, item) {
                cartList.push({
                    SoLuong: parseFloat($(item).val()),
                    SanPham: {
                        IdXe: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            });
        });

        // xóa giỏ hàng
        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            });
        });

        //xóa sản phẩm trong giỏ hàng
        $('#btnDelete').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/Delete',
                data: { id: $(this).data('id') },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            });
        });

        // thanh toán
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/Cart/Payment";
        });
    }
}
cart.init();