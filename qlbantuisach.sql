-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 29, 2017 at 04:58 PM
-- Server version: 5.7.14
-- PHP Version: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `qlbantuisach`
--

-- --------------------------------------------------------

--
-- Table structure for table `chitietdondathang`
--

CREATE TABLE `chitietdondathang` (
  `ID_CTDDH` int(11) NOT NULL,
  `MaDonDatHang` varchar(25) COLLATE utf8_unicode_ci NOT NULL,
  `MaSanPham` int(11) NOT NULL,
  `SoLuong` int(3) UNSIGNED NOT NULL DEFAULT '0',
  `DonGia` decimal(18,0) UNSIGNED NOT NULL,
  `ThanhTien` decimal(18,0) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `chitietdondathang`
--

INSERT INTO `chitietdondathang` (`ID_CTDDH`, `MaDonDatHang`, `MaSanPham`, `SoLuong`, `DonGia`, `ThanhTien`) VALUES
(1, '1484547856311', 1, 3, '210000', '600000'),
(2, '1484590077460', 4, 1, '1230000', '1230000'),
(3, '1484590382273', 1, 3, '635000', '1905000'),
(4, '1484590382273', 6, 2, '600000', '1200000'),
(5, '1484635052547', 1, 2, '635000', '1270000'),
(6, '1484635052547', 3, 2, '757000', '1514000'),
(7, '1484723579457', 1, 1, '635000', '635000'),
(8, '1484723579457', 2, 1, '355000', '355000'),
(9, '1484723579457', 3, 1, '757000', '757000');

-- --------------------------------------------------------

--
-- Table structure for table `dondathang`
--

CREATE TABLE `dondathang` (
  `MaDonDatHang` varchar(25) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `NgayDatHang` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `NgayGiao` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `DaThanhToan` tinyint(1) NOT NULL DEFAULT '0',
  `TinhTrangGiao` tinyint(1) NOT NULL DEFAULT '0',
  `TaiKhoan` varchar(25) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `dondathang`
--

INSERT INTO `dondathang` (`MaDonDatHang`, `NgayDatHang`, `NgayGiao`, `DaThanhToan`, `TinhTrangGiao`, `TaiKhoan`) VALUES
('1484547856311', '2017-01-16', '2017-01-19', 0, 0, 'thuydoan123'),
('1484548646858', '2017-01-16', '2017-01-20', 0, 0, 'thuydoan123'),
('1484572630231', '2017-01-16', '2017-01-20', 0, 0, 'uakaongoc'),
('1484578557899', '2017-01-17', '2017-01-18', 0, 0, 'uakaongoc'),
('1484579287007', '2017-02-13', '2017-05-16', 0, 0, 'uakaongoc'),
('1484581683342', '2017-01-18', '2017-01-26', 0, 0, 'uakaongoc'),
('1484583329206', '2017-01-16', '2017-01-19', 0, 0, 'uakaongoc'),
('1484585547034', '2017-01-16', '2017-01-21', 0, 0, 'uakaongoc'),
('1484587762278', '2017-01-17', '2017-02-06', 0, 0, 'uakaongoc'),
('1484589238292', '2017-01-17', '2017-01-27', 0, 0, 'thuydoan123'),
('1484590077460', '2017-01-17', '2017-01-23', 0, 0, 'thuydoan123'),
('1484590382273', '2017-01-17', '2017-01-30', 0, 0, 'uakaongoc'),
('1484635052547', '2017-01-17', '2017-01-18', 0, 0, 'thuydoan123'),
('1484723579457', '2017-01-18', '2017-01-22', 0, 0, 'thuydoan123'),
('16/01/2017 ', '2017-01-16', '2017-01-20', 0, 0, 'thuydoan123');

-- --------------------------------------------------------

--
-- Table structure for table `khachhang`
--

CREATE TABLE `khachhang` (
  `MaKhachHang` int(11) NOT NULL,
  `HoKhachHang` varchar(100) CHARACTER SET utf8 NOT NULL,
  `TenKhachHang` varchar(50) CHARACTER SET utf8 NOT NULL,
  `NgaySinh` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `TaiKhoan` varchar(50) CHARACTER SET utf8 NOT NULL,
  `MatKhau` varchar(50) CHARACTER SET utf8 NOT NULL,
  `Email` varchar(100) CHARACTER SET utf8 NOT NULL,
  `SoDienThoai` varchar(20) CHARACTER SET utf8 NOT NULL,
  `DiaChi` varchar(100) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `khachhang`
--

INSERT INTO `khachhang` (`MaKhachHang`, `HoKhachHang`, `TenKhachHang`, `NgaySinh`, `TaiKhoan`, `MatKhau`, `Email`, `SoDienThoai`, `DiaChi`) VALUES
(1, 'doan', 'thuy', '1994-02-05', 'kaoladeath', '123456', 'abc@gamil.com', '0908123124', 'asdfldfs'),
(2, 'hai', 'bang', '1994-02-05', 'haibang', '123456', 'abc@gamil.com', '0908123124', 'asdfldfs'),
(4, 'nguyen', 'hoang', '2017-06-02', 'abc', '123456', 'abca@gmail.com', '0908120311', 'abc'),
(5, 'nguyen', 'hai', '2015-12-16', 'nguyenhai', '123456', 'abca@gmail.com', '0908120311', 'abc'),
(6, '', '', '2017-01-26', '', '', '', '', ''),
(7, 'a', 'f', '1990-01-10', 'abc123', '123456', 'abc@gmail.com', '1414325435', 'sfdsfsd'),
(8, 'Ho', 'Hai', '1996-01-02', 'Tài kho?n ?ã t?n t?i !!!', 'M?t kh?u ph?i t? 6 ??n 12 kí t? !!!', '??a ch? emil ?ã t?n t?i !!!', '12312412', '1424124'),
(9, 'fsdf', 'sdfsdf', '1995-02-01', 'abc', '1234', 'abc@gmail.com', '12343534', 'dsfsdf'),
(10, 'd', 'a', '2017-02-02', 'abc', '1234', 'abc@gmail.com', '535', '1112rrff'),
(11, 'Pham', 'B?ng B?ng', '1967-06-14', 'banggia123', '123456', 'banggia123@gmail.com', '14235235', 'dsgfjfgjfgj'),
(12, 'abc', 'abc', '2013-06-05', 'abc123', '123456', 'abc123@gmail.comm', '123456', 'dfsdgfdhd'),
(13, 'Doan', 'Thu Thuy', '1994-09-04', 'thuydoan123', 'e10adc3949ba59abbe56e057f20f883e', 'Thuydoan123@gmail.com', '124143', 'dsfsdfds'),
(14, 'Pham', 'H?i B?ng', '1991-01-15', 'kaoladeath', '123456', 'thuydoankg@gmail.com', '123456789', 'TPHCM'),
(15, 'Phan', 'B?ng Tâm', '2007-01-11', 'uakaongoc', 'e10adc3949ba59abbe56e057f20f883e', 'bangtam@gmail.com', '21152543636', 'TPHCM');

-- --------------------------------------------------------

--
-- Table structure for table `loaisanpham`
--

CREATE TABLE `loaisanpham` (
  `MaLoai` int(11) NOT NULL,
  `TenLoai` varchar(100) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `loaisanpham`
--

INSERT INTO `loaisanpham` (`MaLoai`, `TenLoai`) VALUES
(1, 'TÚI ĐEO CHÉO - TÚI XÁCH'),
(2, 'BALO'),
(3, 'CẶP CÔNG SỞ'),
(4, 'TÚI DU LỊCH'),
(5, 'VALI');

-- --------------------------------------------------------

--
-- Table structure for table `nhasanxuat`
--

CREATE TABLE `nhasanxuat` (
  `MaNhaSanXuat` int(11) NOT NULL,
  `TenNhaSanXuat` varchar(100) CHARACTER SET utf8 NOT NULL,
  `DiaChi` varchar(150) CHARACTER SET utf8 NOT NULL,
  `SDT` varchar(20) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `nhasanxuat`
--

INSERT INTO `nhasanxuat` (`MaNhaSanXuat`, `TenNhaSanXuat`, `DiaChi`, `SDT`) VALUES
(1, 'LATA', '690 CMT8, P.05, Tân Bình', ' 090 65 64 798 '),
(2, 'TUCANO', '', ''),
(3, 'SIMPLECARRY', '', ''),
(4, 'ADIDAS', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `sanpham`
--

CREATE TABLE `sanpham` (
  `MaSanPham` int(11) NOT NULL,
  `MaLoai` int(11) NOT NULL,
  `MaNhaSanXuat` int(11) NOT NULL,
  `TenSanPham` varchar(100) CHARACTER SET utf8 NOT NULL,
  `GiaBan` decimal(18,0) UNSIGNED NOT NULL,
  `MoTa` text CHARACTER SET utf8 NOT NULL,
  `AnhBia` varchar(250) CHARACTER SET utf8 NOT NULL,
  `NgayCapNhap` varchar(25) COLLATE utf8_unicode_ci NOT NULL,
  `SoLuongTon` int(3) UNSIGNED NOT NULL DEFAULT '0',
  `GioiTinh` bit(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `sanpham`
--

INSERT INTO `sanpham` (`MaSanPham`, `MaLoai`, `MaNhaSanXuat`, `TenSanPham`, `GiaBan`, `MoTa`, `AnhBia`, `NgayCapNhap`, `SoLuongTon`, `GioiTinh`) VALUES
(1, 1, 1, 'Cặp công sở LATA CA13 ( màu nâu )', '635000', 'Cặp công sở LATA CA13 ( nâu )là một sản phẩm được sản xuất độc quyền bở thương hiệu túi xách LATA- Chất liệu:Da tổng hợp cao cấp: Không bong tróc, không thấm nước sử dụng càng lâu da sẽ đẹp. Lót nhung giúp bảo vệ tốt hơn vật dung bênh trong túi-. Da tổng hợp , lót nhung bênh trong túi và phụ kiện điêu đươc sản xuất hoàn toàn tại Việt Nam                                                                  - Hình dáng: Hình chử nhạt , rất phù hợp với đeo đi làm, đi chơi, đi dạo phố ….*  LATA bảo hành suốt thời gian sử dụng. với những sản phẩm có in logo LATA dập chìm trên túi .- Kích thước: Rộng:45,5cm x Cao 30,5cmx Đáy rộng tối đa 7.cm.- Nặng: 1,1kg- Mặt trước có nắp gập đơn giản, cùng logo dập chìm làm cho túi  sang trong, đăng cấp hơn..- Tính năng: Có nhiều ngăn giúp bạn có thể dể dàn sắp xếp vật dụng.kích thước phù hợp với máy tính 15inch- Túi gồm 1 ngăn chính,1 ngăn đựng laptop và 4 túi phụ bênh trong và sâu túiTHÔNG TIN BẢO HÀNG:bảo hành suốt thời gian sử dụng. nguyên phụ liệu bị hư hỏng, lỗi kĩ thuật của nhà sản xuất. như dây kéo đường chỉ, móc khóa...trong thời', 'images/Sanpham/lata13.jpg', '2016-12-16 00:00:00', 10, b'1'),
(2, 1, 1, 'Túi đeo chéo LaTa HL00 (Bò nhạt)', '355000', 'Chất liệu:Da tổng hợp cao cấp: Không bong tróc, không thấm nước sử dụng càng lâu da sẽ đẹp. Lót nhung giúp bảo vệ tốt hơn vật dung bênh trong túi.                                                                  - Hình dáng: Hình hộp, rất phù hợp với đeo đi du lịch, đi dạo phố, đi làm….- Kích thước: Rộng: 31cm x Cao23cmx Đáy rộng tối đa 7.cm.- Nặng:650g- Tính năng: Có nhiều ngăn giúp bạn có thể dể dàn sắp xếp vật dụng.Bạn có thể vừa đeo chéo, hay xách tây được.- Mặt trước với khóa trang trí đồng cổ , cùng logo dập chìm tạo cho túi một vẽ dể thương và sang trong hơn..- Túi gồm 1 ngăn chính và 3 túi phụ bênh trong và sâu túi  .     LATA bảo hành suốt thời gian sử dụng', 'images/Sanpham/lataHL00.jpg', '2016-12-16 00:00:00', 10, b'1'),
(3, 1, 1, 'Cặp công sở LATA CA14 (Bò nhạt)', '757000', 'Cặp công sở LATA CA14 là một sản phẩm được sản xuất độc quyền bở thương hiệu túi xách LATA - Chất liệu:Da tổng hợp cao cấp: Không bong tróc, không thấm nước sử dụng càng lâu da sẽ đẹp. Lót nhung giúp bảo vệ tốt hơn vật dung bênh trong túi -. Da tổng hợp , lót nhung bênh trong túi và phụ kiện điêu đươc sản xuất hoàn toàn tại Việt Nam                                                                  - Hình dáng: Hình chử nhạt , rất phù hợp với đeo đi làm, đi chơi, đi dạo phố …. *  LATA bảo hành suốt thời gian sử dụng. với những sản phẩm có in logo LATA dập chìm trên túi . - Kích thước: Cao28 cmx ngan 40 Đáy rộng tối đa 6.cm. - Nặng: 1,1kg - Mặt trước với chi tiếc phối màu đơn giản , cùng logo dập chìm làm cho túi  sang trong, đăng cấp - Tính năng: Có nhiều ngăn giúp bạn có thể dể dàn sắp xếp vật dụng.kích thước phù hợp với máy tính 14inch - Túi gồm 1 ngăn chính,1 ngăn đựng laptop và 2 túi phụ bênh trong . THÔNG TIN BẢO HÀNG: bảo hành suốt thời gian sử dụng. nguyên phụ liệu bị hư hỏng, lỗi kĩ thuật của nhà sản xuất. như dây kéo đường chỉ, móc khóa... trong thời gian sử dụng hoàn toàn miễn phi và sẻ bảo hành nhanh', 'images/Sanpham/lataCA14.jpg', '2016-12-16 00:00:00', 10, b'1'),
(4, 2, 2, 'Tucano WOBK_MB15_F (M) Pink', '1230000', 'Hàng Chính Hãng.\r\nNhập khẩu và phân phối chính hãng.\r\nKích thước : 43 x 32 x 13 Cm\r\nTrọng lượng : 0.8 Kg \r\nTúi dành cho laptop 15\'\' \r\nTúi được trang bị hệ thống sáng tạo Anti-Shock: padding tiêu chuẩn.\r\nChống lại chấn động và va đập.\r\nTúi kéo ra cung cấp đủ không gian cho các phụ kiện,\r\nngăn truy cập nhanh trước và sau bao gồm. \r\nĐệm dây đeo vai có thể tháo rời dễ dàng-grip,\r\nsốc thiết kế hấp thụ, ngăn ngừa clip xoay xoắn và snap-móc bao gồm.\r\nXử lý có thể được giấu đi trong khe.\r\nNgăn đa Fit cho iPad \r\nKéo ra các phụ kiện túi ', 'images/Sanpham/tucano1.jpg', '2016-12-16 00:00:00', 10, b'0'),
(5, 2, 2, 'Tucano BDRV_B (S) Navy', '540000', 'xternal Size (cm)24 x 30 x 5,2\r\nSuggested device size (cm)19,5 x 26,5 x 3\r\nDesigned foriPad 3rd gen., iPad 2, iPad, Galaxy Tab 2 10", Galaxy Tab 10", Tablet Universale 10\'\', Tablet Universale 7\'\', Galaxy Note 10.1\'\'\r\nMaterialpolyester\r\nTHÔNG SỐ KĨ THUẬT\r\nExternal Size (cm)24 x 30 x 5,2\r\nSuggested device size (cm)19,5 x 26,5 x 3\r\nDesigned foriPad 3rd gen., iPad 2, iPad, Galaxy Tab 2 10", Galaxy Tab 10", Tablet Universale 10\'\', Tablet Universale 7\'\', Galaxy Note 10.1\'\'\r\nMaterialpolyester', 'images/Sanpham/tucano2.jpg', '2016-12-16 00:00:00', 11, b'0'),
(6, 2, 3, 'Balo Simplecarry E-City (M) Blue', '600000', 'Balo Simplecarry E-City (M) Blue được ưa chuộng nhất của dòng Simplecarry bởi sự tinh tế trên từng sản phẩm. Kết hợp giữa tông màu xanh tươi tắn, trẻ trung cùng điếm nhấn là logo dập nổi với ký hiệu màu trắng nổi bật, sắc nét. Sự phối hợp màu sắc với những điểm nhấn đã gây ấn tượng về sự chắc chắn cho người dùng từ cái nhìn đầu tiên.\r\n \r\nBalo Simplecarry E-City được thiết kế với 1 ngăn chính cùng 3 ngăn phụ đi cùng. Ngăn chính với diện tích rộng rãi cho phép mang theo vật dụng cá nhân kèm theo 1 ngăn riêng biệt chuyên dụng dành cho laptop lên đến 15.6inch được lót lớp mút PE chống sốc. Bổ sung thêm 2 ngăn nhỏ với đầu khóa kéo, đính logo thương hiệu và phía dưới trang trí bằng simili cao cấp.\r\n \r\nChất lượng sản phẩm được ưu tiên hàng đầu với sự kĩ càng trong khâu chọn lọc chất liệu của sản phẩm. Với chất liệu vải 1000 Two Tone Kodura phủ PU hỗ trợ chống thấm tối ưu cùng với lớp lót P200D WR/PU trượt nước giúp làm tăng sự an toàn cho đồ đạc bên trong khi di chuyển dưới mưa. Chiếc balo có kích thước 41 x 30 x 13 Cm thích hợp cho các đối tượng học sinh-sinh viên, nhân viên văn phòng giúp bảo vệ chiếc laptop thân yêu khỏi các tác nhân bên ngoài. Với thiết kế gọn nhẹ trọng lượng balo chỉ có chưa đến 0,7kg nhưng nó có thể tải trọng lên đến 25kg. \r\n \r\nThiết kế quai đeo được may bằng kỹ thuật gấp mép dây viền, thiết kế ôm sát hai vai giúp tạo cảm giác chắc chắn khi mang. Mặt sau có đệm mút dày giúp người đeo không bị đau lưng và vai. Không những thế mà việc điều chỉnh độ dài dây đeo vô cùng linh hoạt và tiện lợi với thiết kế cut-out quai đeo thành quai xách.\r\n \r\nĐiều khác biệt so với các sản phẩm khác đó là phần lưng có lớp lưới Air Mesh thoát hơi nhanh. Tăng thêm vẻ đẹp cho chiếc balo bằng việc thêu tên thương hiệu trên quai đeo, cách điệu với simili và vải phản quang trên 2 quai đeo giúp an toàn khi di chuyển trong đêm. Và với sản phẩm này khách hàng sẽ nhận được chế độ bào hành miễn phí lên đến 1 năm.', 'images/Sanpham/simplecarry1.jpg', '2016-12-16 00:00:00', 12, b'0'),
(7, 2, 3, 'Simplecarry B2B04 (M) Brown', '550000', 'Đựng vừa laptop: 15.6\'\'\r\nMàu sắc: Đỏ\r\nKích thước: 41 x 29 x 11.5 cm\r\nCân nặng: 0.81 kg\r\nTải trọng tối đa: 25 kg\r\nChất liệu vải: Polyester trượt nước\r\nSố ngăn: 2 ngăn chính, 3 ngăn phụ\r\nMặt trước: 1 ngăn phụ với đầu khóa kéo nằm ngang, đính logo thương hiệu SimpleCarry\r\nNgăn trong: Ngăn dắt viết, điện thoại, ngăn đựng laptop riêng biệt với lớp mút PE chống sốc, ngăn lưới đựng adapter, 2 túi hông đựng bình nước ...\r\nQuai đeo: Được may bằng kỹ thuật gấp mép dây viền, thiết kế ôm rất sát hai vai, chắc chắn, việc nới dài – thu ngắn dây ', 'images/Sanpham/simplecarry2.jpg', '2016-12-16 00:00:00', 11, b'0');

-- --------------------------------------------------------

--
-- Table structure for table `taikhoanadmin`
--

CREATE TABLE `taikhoanadmin` (
  `MaTaiKhoan` int(11) NOT NULL,
  `TenTaiKhoan` varchar(25) COLLATE utf8_unicode_ci NOT NULL,
  `MatKhau` varchar(25) COLLATE utf8_unicode_ci NOT NULL,
  `DiaChi` varchar(250) COLLATE utf8_unicode_ci NOT NULL,
  `SDT` varchar(25) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `taikhoanadmin`
--

INSERT INTO `taikhoanadmin` (`MaTaiKhoan`, `TenTaiKhoan`, `MatKhau`, `DiaChi`, `SDT`) VALUES
(1, 'admin', '123456', 'TPHCM', '123456789');

-- --------------------------------------------------------

--
-- Table structure for table `vaitro`
--

CREATE TABLE `vaitro` (
  `IDRole` int(11) NOT NULL,
  `TenVaiTro` varchar(150) CHARACTER SET utf8 NOT NULL,
  `MieuTa` varchar(150) CHARACTER SET utf8 NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `vaitro`
--

INSERT INTO `vaitro` (`IDRole`, `TenVaiTro`, `MieuTa`) VALUES
(1, 'Admin', 'Admin hệ thống'),
(2, 'User', 'User thường');

-- --------------------------------------------------------

--
-- Table structure for table `vaitronguoidung`
--

CREATE TABLE `vaitronguoidung` (
  `IDUser` int(11) NOT NULL,
  `IDRole` int(11) NOT NULL,
  `MaKhachHang` int(11) NOT NULL,
  `NgayTao` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `chitietdondathang`
--
ALTER TABLE `chitietdondathang`
  ADD PRIMARY KEY (`ID_CTDDH`);

--
-- Indexes for table `dondathang`
--
ALTER TABLE `dondathang`
  ADD PRIMARY KEY (`MaDonDatHang`);

--
-- Indexes for table `khachhang`
--
ALTER TABLE `khachhang`
  ADD PRIMARY KEY (`MaKhachHang`);

--
-- Indexes for table `loaisanpham`
--
ALTER TABLE `loaisanpham`
  ADD PRIMARY KEY (`MaLoai`);

--
-- Indexes for table `nhasanxuat`
--
ALTER TABLE `nhasanxuat`
  ADD PRIMARY KEY (`MaNhaSanXuat`);

--
-- Indexes for table `sanpham`
--
ALTER TABLE `sanpham`
  ADD PRIMARY KEY (`MaSanPham`);

--
-- Indexes for table `taikhoanadmin`
--
ALTER TABLE `taikhoanadmin`
  ADD PRIMARY KEY (`MaTaiKhoan`);

--
-- Indexes for table `vaitro`
--
ALTER TABLE `vaitro`
  ADD PRIMARY KEY (`IDRole`);

--
-- Indexes for table `vaitronguoidung`
--
ALTER TABLE `vaitronguoidung`
  ADD PRIMARY KEY (`IDUser`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `chitietdondathang`
--
ALTER TABLE `chitietdondathang`
  MODIFY `ID_CTDDH` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT for table `khachhang`
--
ALTER TABLE `khachhang`
  MODIFY `MaKhachHang` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `loaisanpham`
--
ALTER TABLE `loaisanpham`
  MODIFY `MaLoai` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `nhasanxuat`
--
ALTER TABLE `nhasanxuat`
  MODIFY `MaNhaSanXuat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `sanpham`
--
ALTER TABLE `sanpham`
  MODIFY `MaSanPham` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `taikhoanadmin`
--
ALTER TABLE `taikhoanadmin`
  MODIFY `MaTaiKhoan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `vaitro`
--
ALTER TABLE `vaitro`
  MODIFY `IDRole` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `vaitronguoidung`
--
ALTER TABLE `vaitronguoidung`
  MODIFY `IDUser` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
