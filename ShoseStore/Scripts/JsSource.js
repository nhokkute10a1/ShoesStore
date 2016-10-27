/// <reference path="jquery.min.js" />
/// <reference path="jquery-1.10.2.intellisense.js" />
/// <reference path="jquery.form.js" />
/// <reference path="jquery.validate.js" />
//show menu doc
$(document).ready(function () {
    // sự kiện click sẽ làm cho cái này chạy
    $(".leadnu").click(function () {
        // và lưu giá trị vào bộ nhớ trình duyệt
        sessionStorage.loaiCuaLoai = 'leadnu'
        $("#nu").slideToggle("slow");
        $("#nam").slideUp("slow");
        $("#th").slideUp("slow");
    });
});

$(document).ready(function () {
    $(".leadnam").click(function () {
        sessionStorage.loaiCuaLoai = 'leadnam'
        $("#nam").slideToggle("slow");
        $("#nu").slideUp("slow");
        $("#th").slideUp("slow");
    });
});

$(document).ready(function () {
    $(".leadth").click(function () {
        sessionStorage.loaiCuaLoai = 'leadth'
        $("#th").slideToggle("slow");
        $("#nam").slideUp("slow");
        $("#nu").slideUp("slow");
    });
});
//truyen id giua menu ngang vs doc

// cai phan nay la phan chinh de thuc hien
function checkTonTaiVaHien(nameLoai, id) {
    // dựa vào giá trị của nameLoai thì sẽ thực thi khác nhau
    switch (nameLoai) {
        case 'leadnu':
            // cái dòng dưới là thực thi lệnh click
            $('.' + nameLoai).trigger('click');
            // dòng dưới kiểm tra xem loaiId có tồn tại ko
            if (sessionStorage.loaiId) {
                // nếu có thì xóa class target của thằng có loaiId tương ứng
                $(sessionStorage.loaiId).removeClass('target')
            }
            //console.log($('.loainu' + id))
            // cái này thêm class vào loại id mới
            $('.loainu' + id).addClass('target')
            // rùi lưu vào bộ nhớ
            sessionStorage.loaiId = '.loainu' + id;
            break;
        case 'leadnam':
            $('.' + nameLoai).trigger('click');
            if (sessionStorage.loaiId) {
                $(sessionStorage.loaiId).removeClass('target')
            }
            console.log($('.loainam' + id))
            $('.loainam' + id).addClass('target')
            sessionStorage.loaiId = '.loainam' + id;
            break;
        case 'leadth':
            $('.' + nameLoai).trigger('click');
            if (sessionStorage.loaiId) {
                $(sessionStorage.loaiId).removeClass('target')
            }
            console.log($('.loainsx' + id))
            $('.loainsx' + id).addClass('target')
            sessionStorage.loaiId = '.loainsx' + id;
            break;
        default:

    }
}

// xu ly doan loi trong khi dk va dang nhap
$(document).ready(function () {

    console.log(window.location.pathname.split('/')[3])
    if (sessionStorage.loaiCuaLoai) {
        var id = window.location.pathname.split('/')[3];
        console.log(sessionStorage.loaiCuaLoai)
        checkTonTaiVaHien(sessionStorage.loaiCuaLoai, id);
    }
        


    $('#loginForm').validate({
        rules: {
            TenDN: 'required',
            Matkhau: 'required'
        },
        messages: {
            TenDN: 'Phải nhập tên đăng nhập',
            Matkhau: 'Phải nhập mật khẩu'
        }
    });


    $('#formDangKy').validate({
        rules: {
            HoTenKH: 'required',
            TenDN: 'required',
            Matkhau: 'required',
            Matkhaunhaplai: 'required',
            Email: 'required',
            Diachi: 'required',
            Dienthoai: 'required',
            Ngaysinh: 'required',
            checkbox: 'required'
        },
        messages: {
            HoTenKH: 'Họ tên khách hàng không được để trống',
            TenDN: 'Phải nhập tên đăng nhập',
            Matkhau: 'Phải nhập mật khẩu',
            Matkhaunhaplai: 'Mật khẩu nhập lại không khớp',
            Email: 'Email không được để trống',
            Diachi: 'Phải nhập địa chỉ',
            Dienthoai: 'Điện thoại không được để trống',
            Ngaysinh: 'Phải nhập ngày sinh',
            checkbox: 'Chưa đồng ý điều khoản',
        }
    });

    $('#loginForm').submit(function () {
        $(this).ajaxSubmit({
            dataType: 'json',
            success: function (data) {
                if (data.result === 'success') {
                    alert('Chế đăng nhập thành công rồi nhé !!!!');
                    location.reload();
                } else {
                    alert(data.message);
                }
            }
        });
        return false;
    });

});