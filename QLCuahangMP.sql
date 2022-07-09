---------THỦ TỤC LƯU PROCEDERE-------
--1. Thêm 1 bản ghi mới cho bảng LoaiSP
DROP PROC sp_ThemLoaiSP
--
create procedure sp_ThemLoaiSP
	@maloai nchar(10),
	@tenl nvarchar(50)
as
	if exists(select*from LoaiSP where MaLoai=@maloai)
	begin
		print N'Mã loại sản phẩm ' + @maloai + N'đã có ! Nhập mã loại khác'
		return
	end
	if exists(select*from LoaiSP where TenLoai=@tenl)
	begin
		print N'Tên loại hàng ' + @tenl + N'đã có ! Nhập Tên loại khác'
		return
	end
	else
	--xu ly them mau tin
	begin
		insert into LoaiSP values(@maloai,@tenl)
		print N'Loại sản phẩm đã được thêm'
	end
GO
--
exec sp_ThemLoaiSP'L10',N'........'
select * from LoaiSP

--2. Update LoaiSP
DROP PROC sp_SuaLoaiSP
--
create proc sp_SuaLoaiSP
	@maloai nchar(10),
	@tenloai nvarchar(50)
as
	declare @Malh nvarchar(50)
	if not exists(select MaLoai from LoaiSP where MaLoai=@maloai)
	begin
		set @Malh=N'Không tìm thấy mã loại hàng'+@maloai
		raiserror(@Malh,16,1)
		return
	end
	--xu ly update
	update LoaiSP
	set TenLoai=@tenloai where MaLoai=@maloai
GO
--
exec sp_SuaLoaiSP 'L10',N'Kem dưỡng'
exec sp_SuaLoaiSP 'LH11',N'......'
select*from LoaiSP

--3. Delete LoaiSP
DROP PROC sp_XoaLoaiSP
--
create proc sp_XoaLoaiSP
	@maloai char(10)
as
	declare @malh nvarchar(50)
	if not exists(select*from LoaiSP where MaLoai=@maloai)
	begin
		set @malh=N'Mã loại sp '+@maloai+N'Không tồn tại => không thể xóa'
		raiserror(@malh,16,1)
		return
	end
	if exists(select MaLoai from SanPham where MaLoai=@maloai)
	begin
		set @malh=N'Mã loại sp '+@maloai+N'tồn tại trong bảng SanPham nên không thể xóa'
		raiserror(@malh,16,1)
		return
	end
	else
	begin--xóa
		delete LoaiSP where MaLoai=@maloai
		print 'LoaiSP'+@maloai+N'Đã được xóa'
	end
GO
--
exec sp_XoaLoaiSP 'L11'
exec sp_XoaLoaiSP 'L10'
go

--tìm kiếm ThuongHieu theo mã
create proc sp_TimKiemTH(@maTH nchar(10))
as
begin
	if( not exists (select* from ThươngHieu th where th.MaTH=@maTH))
	begin 
	print N'Mã TH '+@maTH+ N'không tồn tại'
	return -1
	end
	if( exists (select* from ThươngHieu th where th.MaTH=@maTH))
	begin 
		select *from ThươngHieu
		where @maTH=MaTH		
	end
end
go
exec sp_TimKiemTH 'H01'
GO

-- Lấy ra danh sách sp theo loại
create proc DSSPtheoLoai
@maloai nchar(10)
as
begin
	if(not exists(select*from SanPham sp where sp.MaLoai=@maloai))
	begin
		print N'Mã loại '+@maloai+N'Chưa tồn tại'
		return -1
	end
	select*from SanPham sp where sp.MaLoai=@maloai
end
go
--
exec DSSPtheoLoai 'L01'


select*from Users where MaNV ='NV01' and Pas='123'

--phân trang
CREATE PROCEDURE [dbo].[GetSanPhams]
 (@PageIndex INT, @pageSize INT, @productName nvarchar(100))
AS
BEGIN
 DECLARE @RecordCount INT;
 SELECT * INTO #Results FROM SanPham
 where (TenSP='') or (TenSP like '%' +@productName+'%')
 select * from #Results ORDER BY MaSP OFFSET @PageSize * (@PageIndex -1)
 ROWS FETCH NEXT @PageSize ROW ONLY;
 SELECT count(*) as totalCount FROM SanPham;
 DROP TABLE #Results
END

exec GetSanPhams '1','5','Green'
--

create proc SanPhamBanChay
as
begin
	select* from SanPham where (MaSP in (select top 4 MaSP from CTDonHang
	where MaDH in(select MaDH from DonHang)
	group by MaSP order by sum (SoLuong) desc))
end
--Thực thi
exec SanPhamBanChay

select * from KhachHang where MaKH='KH02 ' and MatKhau='222'

select*from DonHang