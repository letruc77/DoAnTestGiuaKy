USE [master]
GO
/****** Object:  Database [DoAnNganh]    Script Date: 04/16/2019 7:22:20 PM ******/
CREATE DATABASE [DoAnNganh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DoAnNganh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DoAnNganh.mdf' , SIZE = 10240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DoAnNganh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DoAnNganh_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DoAnNganh] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DoAnNganh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DoAnNganh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DoAnNganh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DoAnNganh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DoAnNganh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DoAnNganh] SET ARITHABORT OFF 
GO
ALTER DATABASE [DoAnNganh] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DoAnNganh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DoAnNganh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DoAnNganh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DoAnNganh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DoAnNganh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DoAnNganh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DoAnNganh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DoAnNganh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DoAnNganh] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DoAnNganh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DoAnNganh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DoAnNganh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DoAnNganh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DoAnNganh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DoAnNganh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DoAnNganh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DoAnNganh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DoAnNganh] SET  MULTI_USER 
GO
ALTER DATABASE [DoAnNganh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DoAnNganh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DoAnNganh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DoAnNganh] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DoAnNganh] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DoAnNganh]
GO
/****** Object:  Table [dbo].[CTGioHang]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTGioHang](
	[IdGioHang] [uniqueidentifier] NOT NULL,
	[IdMaXe] [uniqueidentifier] NOT NULL,
	[SoLuong] [int] NULL,
	[Gia] [float] NULL,
	[ThanhTien] [float] NULL,
	[TinhTrang] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_CTGioHang] PRIMARY KEY CLUSTERED 
(
	[IdGioHang] ASC,
	[IdMaXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHoaDonChi]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoaDonChi](
	[MaHoaDonChi] [uniqueidentifier] NOT NULL,
	[MaXe] [uniqueidentifier] NOT NULL,
	[ThanhTien] [float] NULL,
	[TinhTrang] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_CTHoaDonChi_1] PRIMARY KEY CLUSTERED 
(
	[MaHoaDonChi] ASC,
	[MaXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHoaDonThu]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoaDonThu](
	[MaHoaDonThu] [uniqueidentifier] NOT NULL,
	[MaXe] [uniqueidentifier] NOT NULL,
	[ThanhTien] [float] NULL,
	[TinhTrang] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_CTHoaDonThu_1] PRIMARY KEY CLUSTERED 
(
	[MaHoaDonThu] ASC,
	[MaXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[IdDanhMuc] [uniqueidentifier] NOT NULL,
	[TenDanhMuc] [nvarchar](50) NULL,
	[LoaiDanhMuc] [char](5) NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[IdDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[IdGioHang] [uniqueidentifier] NOT NULL,
	[IdKhachHang] [uniqueidentifier] NULL,
	[TinhTrang] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[TongSoLuong] [int] NULL,
	[TongThanhTien] [float] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_GioHang_1] PRIMARY KEY CLUSTERED 
(
	[IdGioHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonChi]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonChi](
	[IdPhieuChi] [uniqueidentifier] NOT NULL,
	[MaHoaDonChi] [nvarchar](20) NULL,
	[IdNhacungCap] [uniqueidentifier] NULL,
	[IdKhoXe] [uniqueidentifier] NULL,
	[NgayChi] [datetime] NULL,
	[TongSoLuong] [int] NULL,
	[TongTien] [float] NULL,
	[TinhTrang] [bit] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_HoaDonChi] PRIMARY KEY CLUSTERED 
(
	[IdPhieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonThu]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonThu](
	[IdPhieuThu] [uniqueidentifier] NOT NULL,
	[MaHoaDonThu] [nvarchar](20) NULL,
	[KhachHang] [uniqueidentifier] NULL,
	[NgayThu] [datetime] NULL,
	[TongSoLuong] [int] NULL,
	[TongTien] [float] NULL,
	[TinhTrang] [bit] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_HoaDonThu] PRIMARY KEY CLUSTERED 
(
	[IdPhieuThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoXe]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoXe](
	[IdKhoXe] [uniqueidentifier] NOT NULL,
	[TenKho] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[TinhTrang] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_KhoXe] PRIMARY KEY CLUSTERED 
(
	[IdKhoXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiXe]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiXe](
	[IdLoaiXe] [uniqueidentifier] NOT NULL,
	[TenLoaiXe] [nvarchar](50) NULL,
	[SoLuong] [int] NOT NULL,
	[MauXe] [varchar](10) NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_LoaiXe] PRIMARY KEY CLUSTERED 
(
	[IdLoaiXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[IdNguoiDung] [uniqueidentifier] NOT NULL,
	[TenNguoiDung] [nvarchar](500) NULL,
	[PassWord] [nvarchar](max) NULL,
	[Email] [varchar](100) NULL,
	[SoDienThoai] [char](10) NULL,
	[IsDeleted] [bit] NULL,
	[TinhTrang] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[IdNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[IdNhaCungCap] [uniqueidentifier] NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[IsDeleted] [bit] NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[IdNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[IdQuyen] [uniqueidentifier] NOT NULL,
	[IdnguoiDung] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NULL,
	[TinhTrang] [bit] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[IdQuyen] ASC,
	[IdnguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Xe]    Script Date: 04/16/2019 7:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Xe](
	[IdXe] [uniqueidentifier] NOT NULL,
	[TenXe] [nvarchar](500) NULL,
	[SoKhung] [char](10) NULL,
	[SoMay] [char](10) NULL,
	[IdNhaCungCap] [uniqueidentifier] NULL,
	[MaLoaiXe] [uniqueidentifier] NULL,
	[GiaVonXe] [float] NULL,
	[GiaNiemYetXe] [float] NULL,
	[IdKhoXe] [uniqueidentifier] NULL,
	[ChiTiet] [nvarchar](max) NULL,
	[Hinh1] [nvarchar](200) NULL,
	[Hinh2] [nvarchar](200) NULL,
	[Hinh3] [nvarchar](200) NULL,
	[SoLuotXem] [int] NULL,
	[TinhTrang] [nvarchar](50) NULL,
	[NgayNhap] [datetime] NULL,
	[NgayXuat] [datetime] NULL,
	[OfUser] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Xe] PRIMARY KEY CLUSTERED 
(
	[IdXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[CTGioHang] ([IdGioHang], [IdMaXe], [SoLuong], [Gia], [ThanhTien], [TinhTrang], [IsDeleted], [CreatedDate], [UpdatedDate]) VALUES (N'7401bdb5-3eca-417a-915c-980871244eba', N'0b809a21-0696-49c6-ac4b-9be10ae30dc6', 1, 200000000, 200000000, 0, 0, CAST(N'2019-02-18T19:54:50.720' AS DateTime), CAST(N'2019-02-18T19:54:50.720' AS DateTime))
INSERT [dbo].[CTGioHang] ([IdGioHang], [IdMaXe], [SoLuong], [Gia], [ThanhTien], [TinhTrang], [IsDeleted], [CreatedDate], [UpdatedDate]) VALUES (N'bda856c7-05b5-453a-a7ae-a7a7f6837043', N'0b809a21-0696-49c6-ac4b-9be10ae30dc6', 1, 200000000, 200000000, 0, 0, CAST(N'2019-02-18T20:00:21.783' AS DateTime), CAST(N'2019-02-18T20:00:21.783' AS DateTime))
INSERT [dbo].[CTGioHang] ([IdGioHang], [IdMaXe], [SoLuong], [Gia], [ThanhTien], [TinhTrang], [IsDeleted], [CreatedDate], [UpdatedDate]) VALUES (N'92a903c2-6cfd-48eb-9bd5-ec47b6faec27', N'0b809a21-0696-49c6-ac4b-9be10ae30dc6', 1, 200000000, 200000000, 0, 0, CAST(N'2019-02-18T20:25:04.057' AS DateTime), CAST(N'2019-02-18T20:25:04.057' AS DateTime))
INSERT [dbo].[GioHang] ([IdGioHang], [IdKhachHang], [TinhTrang], [IsDeleted], [TongSoLuong], [TongThanhTien], [CreatedDate], [UpdatedDate]) VALUES (N'7401bdb5-3eca-417a-915c-980871244eba', N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', 0, 0, 1, 200000000, CAST(N'2019-02-18T19:54:50.720' AS DateTime), CAST(N'2019-02-18T19:54:50.720' AS DateTime))
INSERT [dbo].[GioHang] ([IdGioHang], [IdKhachHang], [TinhTrang], [IsDeleted], [TongSoLuong], [TongThanhTien], [CreatedDate], [UpdatedDate]) VALUES (N'bda856c7-05b5-453a-a7ae-a7a7f6837043', N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', 0, 0, 1, 200000000, CAST(N'2019-02-18T20:00:21.783' AS DateTime), CAST(N'2019-02-18T20:00:21.783' AS DateTime))
INSERT [dbo].[GioHang] ([IdGioHang], [IdKhachHang], [TinhTrang], [IsDeleted], [TongSoLuong], [TongThanhTien], [CreatedDate], [UpdatedDate]) VALUES (N'92a903c2-6cfd-48eb-9bd5-ec47b6faec27', N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', 0, 0, 1, 200000000, CAST(N'2019-02-18T20:25:04.057' AS DateTime), CAST(N'2019-02-18T20:25:04.057' AS DateTime))
INSERT [dbo].[KhoXe] ([IdKhoXe], [TenKho], [DiaChi], [TinhTrang], [IsDeleted]) VALUES (N'acba9d50-0ac8-47b3-be54-b2ec5dd5686c', N'Kho số 2', N'Thành phố Hồ Chí Minh', 1, 0)
INSERT [dbo].[KhoXe] ([IdKhoXe], [TenKho], [DiaChi], [TinhTrang], [IsDeleted]) VALUES (N'8ecc9728-da53-4df3-a1d7-fc5e3eb0a4c6', N'Kho số 1', N'Thành phố Hồ Chí Minh', 1, 0)
INSERT [dbo].[LoaiXe] ([IdLoaiXe], [TenLoaiXe], [SoLuong], [MauXe], [IsDeleted], [IsActive], [CreatedDate], [UpdatedDate]) VALUES (N'89e51c6d-c3f2-4448-b819-100bf449f70f', N'Xe Sedan', 3, N'', 0, 1, CAST(N'2019-01-17T02:33:09.747' AS DateTime), CAST(N'2019-01-17T02:33:09.747' AS DateTime))
INSERT [dbo].[LoaiXe] ([IdLoaiXe], [TenLoaiXe], [SoLuong], [MauXe], [IsDeleted], [IsActive], [CreatedDate], [UpdatedDate]) VALUES (N'2b6615f3-cd02-42f3-8686-5ee8c60f1205', N'Xe Thể Thao', 1, N'', 0, 1, CAST(N'2019-01-17T02:07:20.517' AS DateTime), CAST(N'2019-01-17T02:07:20.520' AS DateTime))
INSERT [dbo].[LoaiXe] ([IdLoaiXe], [TenLoaiXe], [SoLuong], [MauXe], [IsDeleted], [IsActive], [CreatedDate], [UpdatedDate]) VALUES (N'add3799a-d4ef-450b-99f5-a5c6168fb034', N'Siêu Xe', 0, N'', 0, 1, CAST(N'2019-01-18T21:04:53.013' AS DateTime), CAST(N'2019-01-18T21:04:53.013' AS DateTime))
INSERT [dbo].[LoaiXe] ([IdLoaiXe], [TenLoaiXe], [SoLuong], [MauXe], [IsDeleted], [IsActive], [CreatedDate], [UpdatedDate]) VALUES (N'7cf74ff8-e977-412b-9d72-f9f93d9bcc89', N'Xe SUV', 1, N'', 0, 1, CAST(N'2019-01-17T02:31:06.533' AS DateTime), CAST(N'2019-01-17T02:31:06.533' AS DateTime))
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [TenNguoiDung], [PassWord], [Email], [SoDienThoai], [IsDeleted], [TinhTrang], [CreatedDate], [UpdatedDate]) VALUES (N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', N'admin', N'6C9CDCE9F6D927CEA4C621B33CA05013', N'admin@gmail.com', N'0999999999', 0, 1, CAST(N'2019-01-13T15:36:17.797' AS DateTime), CAST(N'2019-01-13T15:36:18.180' AS DateTime))
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [TenNguoiDung], [PassWord], [Email], [SoDienThoai], [IsDeleted], [TinhTrang], [CreatedDate], [UpdatedDate]) VALUES (N'ccd40c34-703e-41f0-9335-81b11c02f853', N'Lê Công Trúc', N'6C9CDCE9F6D927CEA4C621B33CA05013', N'letruc9394@gmail.com', N'0999999999', 0, 1, CAST(N'2019-01-27T09:04:45.410' AS DateTime), CAST(N'2019-01-27T09:04:45.410' AS DateTime))
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [TenNguoiDung], [PassWord], [Email], [SoDienThoai], [IsDeleted], [TinhTrang], [CreatedDate], [UpdatedDate]) VALUES (N'78d5e133-46c7-46e2-bf05-fb10e99acc13', N'Trần Hoàng Long', N'6C9CDCE9F6D927CEA4C621B33CA05013', N'long@gmail.com', N'0999999999', 0, 1, CAST(N'2019-01-27T09:31:45.263' AS DateTime), CAST(N'2019-01-27T09:31:45.263' AS DateTime))
INSERT [dbo].[NhaCungCap] ([IdNhaCungCap], [TenNCC], [DiaChi], [IsDeleted], [TinhTrang]) VALUES (N'f3409d77-8847-43ba-b408-2c51470b2fac', N'HONDA', N'Hà Nội', 0, 1)
INSERT [dbo].[NhaCungCap] ([IdNhaCungCap], [TenNCC], [DiaChi], [IsDeleted], [TinhTrang]) VALUES (N'c1ad0e06-1362-4f47-affa-77005ecc8bc0', N'Chervolet', N'Vũng Tàu', 0, 1)
INSERT [dbo].[NhaCungCap] ([IdNhaCungCap], [TenNCC], [DiaChi], [IsDeleted], [TinhTrang]) VALUES (N'646c8bae-ff19-4fed-9a80-90434df83180', N'Audi', N'Thành phố Hồ Chí Minh', 0, 1)
INSERT [dbo].[NhaCungCap] ([IdNhaCungCap], [TenNCC], [DiaChi], [IsDeleted], [TinhTrang]) VALUES (N'09c890a8-1dc4-41a8-b8a3-d4e03551dee7', N'NISSAN', N'Bình Dương', 0, 1)
INSERT [dbo].[NhaCungCap] ([IdNhaCungCap], [TenNCC], [DiaChi], [IsDeleted], [TinhTrang]) VALUES (N'8ccdc067-c264-4d2a-8b43-da6a9b0f8c22', N'Toyota', N'Thành phố Hồ Chí Minh', 0, 1)
INSERT [dbo].[NhaCungCap] ([IdNhaCungCap], [TenNCC], [DiaChi], [IsDeleted], [TinhTrang]) VALUES (N'de27a92f-681d-49f6-9b76-fd7addfaa083', N'Mazda', N'Đà Nẵng', 0, 1)
INSERT [dbo].[Xe] ([IdXe], [TenXe], [SoKhung], [SoMay], [IdNhaCungCap], [MaLoaiXe], [GiaVonXe], [GiaNiemYetXe], [IdKhoXe], [ChiTiet], [Hinh1], [Hinh2], [Hinh3], [SoLuotXem], [TinhTrang], [NgayNhap], [NgayXuat], [OfUser], [CreatedDate], [UpdatedDate], [IsDeleted], [CreatedBy], [UpdatedBy]) VALUES (N'24de8aba-2866-4573-84ef-0064c5d1ae56', N'Audi A8', N'sokhung123', N'somay123  ', N'646c8bae-ff19-4fed-9a80-90434df83180', N'2b6615f3-cd02-42f3-8686-5ee8c60f1205', 1200000, 1500000, N'8ecc9728-da53-4df3-a1d7-fc5e3eb0a4c6', N'Đây là chiếc xe thể thao mới nhất năm 2019 của Audi.', N'audi a5.jpg', N'audi a8.jpg', N'audi r8 2.jpg', 2, N'NEW', CAST(N'2019-01-25T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2019-01-18T12:35:54.163' AS DateTime), NULL, 0, NULL, N'2dad25d4-a75f-405c-b405-468d4f8e1d3a')
INSERT [dbo].[Xe] ([IdXe], [TenXe], [SoKhung], [SoMay], [IdNhaCungCap], [MaLoaiXe], [GiaVonXe], [GiaNiemYetXe], [IdKhoXe], [ChiTiet], [Hinh1], [Hinh2], [Hinh3], [SoLuotXem], [TinhTrang], [NgayNhap], [NgayXuat], [OfUser], [CreatedDate], [UpdatedDate], [IsDeleted], [CreatedBy], [UpdatedBy]) VALUES (N'1658636a-7fbc-4b2b-b5d6-1a3dca83a53e', N'BMW X5', N'SK27012019', N'SM27012019', N'f3409d77-8847-43ba-b408-2c51470b2fac', N'7cf74ff8-e977-412b-9d72-f9f93d9bcc89', 12000000000, 14000000000, N'8ecc9728-da53-4df3-a1d7-fc5e3eb0a4c6', N'Như đã biết, BMW X5 là chiếc SUV hạng sang cỡ trung do hãng xe BMW (Đức) sản xuất. Thế hệ đầu tiên của X5, với mã khung E53, ra đời vào năm 1999. Với vai trò là chiếc SUV đầu tiên của BMW, BMW X5 khi đó mang ổ đĩa cho tất cả các bánh như một chiếc sedan, với 2 cấu hình hộp số tay và tự động. Cấu trúc khung rời (unibody) của X5 cũng được dùng từ đây, trong khi đối thủ Mercedes-Benz M-Class vẫn còn loay hoay với cấu trúc khung xe tải nhẹ (light truck platform). Thế hệ thứ 2 ra đời năm 2006 trên thế giới (mã khung E70) với hệ dẫn động XDriver nổi tiếng thế giới được dùng cho đến tận ngày nay. BMW X5 thế hệ thứ 3 (F15) ra đời năm 2013 và đến nay hãng xe Đức đã chuẩn bị ra đời thế hệ X5 thứ 4 và bỏ qua giai đoạn nâng cấp giữa vòng đời (facelift) của thế hệ hiện tại. Đối thủ của BMW X5 trên thị trường là Audi Q7, Mercedes GLE Class, Porsche Cayenne, Volvo XC90, Land Rover Discovery, Lexus GX, Acura MDX...', N'cerato 2.jpg', N'cerato 3.jpg', N'cerato 4.jpg', 1, N'NEW', CAST(N'2019-01-27T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2019-01-27T00:14:04.247' AS DateTime), NULL, 0, N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', NULL)
INSERT [dbo].[Xe] ([IdXe], [TenXe], [SoKhung], [SoMay], [IdNhaCungCap], [MaLoaiXe], [GiaVonXe], [GiaNiemYetXe], [IdKhoXe], [ChiTiet], [Hinh1], [Hinh2], [Hinh3], [SoLuotXem], [TinhTrang], [NgayNhap], [NgayXuat], [OfUser], [CreatedDate], [UpdatedDate], [IsDeleted], [CreatedBy], [UpdatedBy]) VALUES (N'ff08e72c-eb8c-452a-8724-24a1d21ff322', N'Chevrolet Camaro', N'SK25012019', N'SM25012019', N'c1ad0e06-1362-4f47-affa-77005ecc8bc0', N'add3799a-d4ef-450b-99f5-a5c6168fb034', 200000000, 220000000, N'acba9d50-0ac8-47b3-be54-b2ec5dd5686c', N'Ở phiên bản lần này, Chevrolet mang đến cho Camaro một diện mạo mới mẻ hơn ở cả phần trước và sau xe. Cặp đèn pha độc đáo với dải LED uốn lượn tràn nhẹ vào góc lưới tản nhiệt. Riêng phiên bản SS đặc biệt hơn khi được trang bị thêm cặp đèn LED phía dưới cùng lỗ thông hơi trên nắp ca-pô.
Lưới tản nhiệt và hốc gió trước thiết kế mới giúp cải tiến khí động học, tăng khả năng vận hành của xe. Mâm xe hợp kim 5 chấu kích thước 20 inch. Biểu tượng Bowtie đen mờ được đặt ở trung tâm lưới tản nhiệt của Camaro RS, trong khi ở phiên bản SS cho vị trí đặt thấp hơn. 
Đèn hậu LED thiết kế theo phong cách 3 chiều, với màu ống kính khác nhau tùy từng phiên bản. Bên cạnh đó, cặp ống xả kép cùng những đường gân dập nổi chạy dọc phần thân và nắp ca-pô giúp chiếc xe trông thể thao và cơ bắp hơn.', N'bmw_x2.jpg', N'bmw3.jpg', N'bmw4.jpg', 4, N'NEW', CAST(N'2019-01-25T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2019-01-25T21:41:42.980' AS DateTime), NULL, 0, N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', N'2dad25d4-a75f-405c-b405-468d4f8e1d3a')
INSERT [dbo].[Xe] ([IdXe], [TenXe], [SoKhung], [SoMay], [IdNhaCungCap], [MaLoaiXe], [GiaVonXe], [GiaNiemYetXe], [IdKhoXe], [ChiTiet], [Hinh1], [Hinh2], [Hinh3], [SoLuotXem], [TinhTrang], [NgayNhap], [NgayXuat], [OfUser], [CreatedDate], [UpdatedDate], [IsDeleted], [CreatedBy], [UpdatedBy]) VALUES (N'8ae4b4c5-1222-470e-b13d-2939d2b5e0b8', N'Honda City', N'HONDA11111', N'SMHONDA111', N'f3409d77-8847-43ba-b408-2c51470b2fac', N'89e51c6d-c3f2-4448-b819-100bf449f70f', 2000000000, 2900000000, N'acba9d50-0ac8-47b3-be54-b2ec5dd5686c', N'Honda City 2018 với những cải tiến mới mẻ cho phiên bản thứ 4 đã nhanh chóng thu hút khách hàng với mức giá bán hấp dẫn trên thị trường. Sau màn ra mắt ấn tượng của Honda Civic Type R tại Vietnam Motor Show 2018 càng khẳng định sự phát tiển vượt bậc của hãng xe Honda trong thời gian gần đây. Vậy liệu mức giá bán dành cho các dòng xe này có sự thay đổi? Cùng chúng tôi cập nhật mức giá xe Honda City 2018 mới nhất tại đại lý và tham khảo thiết kế xe Honda City 2019', N'download.jpg', N'honda-insight-honda-city-2019-muaxegiatot-vn-1honda-insight-honda-city-2019-muaxegiatot-vn.jpg', N'maxresdefault.jpg', 0, N'NEW', CAST(N'2019-01-29T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2019-01-27T00:29:47.597' AS DateTime), NULL, 1, N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', NULL)
INSERT [dbo].[Xe] ([IdXe], [TenXe], [SoKhung], [SoMay], [IdNhaCungCap], [MaLoaiXe], [GiaVonXe], [GiaNiemYetXe], [IdKhoXe], [ChiTiet], [Hinh1], [Hinh2], [Hinh3], [SoLuotXem], [TinhTrang], [NgayNhap], [NgayXuat], [OfUser], [CreatedDate], [UpdatedDate], [IsDeleted], [CreatedBy], [UpdatedBy]) VALUES (N'0a2b5dcc-e8fc-49fe-858e-70e299539d40', N'Test', N'ádasd     ', N'ádasdas   ', N'f3409d77-8847-43ba-b408-2c51470b2fac', N'add3799a-d4ef-450b-99f5-a5c6168fb034', 10000000, 20000000, N'acba9d50-0ac8-47b3-be54-b2ec5dd5686c', N'ádasdadad', N'banner.jpg', N'banner1.jpg', N'banner2.jpg', 0, N'NEW', CAST(N'2019-04-07T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2019-04-07T11:26:04.103' AS DateTime), NULL, 0, N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', NULL)
INSERT [dbo].[Xe] ([IdXe], [TenXe], [SoKhung], [SoMay], [IdNhaCungCap], [MaLoaiXe], [GiaVonXe], [GiaNiemYetXe], [IdKhoXe], [ChiTiet], [Hinh1], [Hinh2], [Hinh3], [SoLuotXem], [TinhTrang], [NgayNhap], [NgayXuat], [OfUser], [CreatedDate], [UpdatedDate], [IsDeleted], [CreatedBy], [UpdatedBy]) VALUES (N'f3b86a15-6381-46cc-857a-83ff2ceb150f', N'TOYOTA V12', N'SKTOYOTA12', N'SMTOYOTA12', N'8ccdc067-c264-4d2a-8b43-da6a9b0f8c22', N'89e51c6d-c3f2-4448-b819-100bf449f70f', 1500000000, 1600000000, N'8ecc9728-da53-4df3-a1d7-fc5e3eb0a4c6', N'Xe Fortuner V12 đời là chiếc xe trên 1000 phân phối mới nhất của TOYOTA.
Phiên bản này đã được nâng cấp hoàn hảo hơn so với thế thệ TOYOTA11 của nó.
Đây chắc chắn sẽ là một trong những sự lựa chọn hoàn hảo cho những chiến đi xa của bạn và gia đinh.
Hãy đến với Leo Shop để được cảm nhận chất lượng hàng đầu Nhật Bản.', N'toyota fortuner 2.jpg', N'toyota fortuner 3.jpg', N'toyota fortuner.jpg', 25, N'NEW', CAST(N'2019-01-19T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2019-01-18T22:09:47.233' AS DateTime), NULL, 0, N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', NULL)
INSERT [dbo].[Xe] ([IdXe], [TenXe], [SoKhung], [SoMay], [IdNhaCungCap], [MaLoaiXe], [GiaVonXe], [GiaNiemYetXe], [IdKhoXe], [ChiTiet], [Hinh1], [Hinh2], [Hinh3], [SoLuotXem], [TinhTrang], [NgayNhap], [NgayXuat], [OfUser], [CreatedDate], [UpdatedDate], [IsDeleted], [CreatedBy], [UpdatedBy]) VALUES (N'0b809a21-0696-49c6-ac4b-9be10ae30dc6', N'Nissan 370Z', N'SK11122233', N'SM11122233', N'09c890a8-1dc4-41a8-b8a3-d4e03551dee7', N'2b6615f3-cd02-42f3-8686-5ee8c60f1205', 200000000, 200000000, N'acba9d50-0ac8-47b3-be54-b2ec5dd5686c', N'Nissan cho ra mắt phiên bản đặc biệt của Nissan 370Z Coupe Heritage 2018 tại Triển lãm ôtô quốc tế New York 2017. Đây là phiên bản di sản vinh danh 50 năm chiếc xe thể thao mang thương hiệu Nissan, kể từ khi nó ra mắt dưới nhãn hiệu Datsun.
Đã từ rất lâu những người đam mê dòng xe thể thao giá rẻ mới được chứng kiến mẫu 370Z mới được sản xuất. Hãng xe Nhật Bản tung ra mắt bản thử nghiệm 350Z vào tháng 11 năm 2008, sau đó là mẫu 370Z 2009, nhanh chóng thu hút được sự chú ý.', N'Nissan370Z_Coupe_Heritage_Edition2018102403.jpg', N'Nissan370Z_Coupe_Heritage_Edition2018102404.jpg', N'Nissan370Z_Coupe_Heritage_Edition2018102407.jpg', 77, N'NEW', CAST(N'2019-01-28T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2019-01-27T00:25:47.443' AS DateTime), NULL, 0, N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', NULL)
INSERT [dbo].[Xe] ([IdXe], [TenXe], [SoKhung], [SoMay], [IdNhaCungCap], [MaLoaiXe], [GiaVonXe], [GiaNiemYetXe], [IdKhoXe], [ChiTiet], [Hinh1], [Hinh2], [Hinh3], [SoLuotXem], [TinhTrang], [NgayNhap], [NgayXuat], [OfUser], [CreatedDate], [UpdatedDate], [IsDeleted], [CreatedBy], [UpdatedBy]) VALUES (N'a0989daa-f560-4051-9a0a-b25d3e0a57b6', N'Fortuner 2019', N'SK26012019', N'SM26012019', N'8ccdc067-c264-4d2a-8b43-da6a9b0f8c22', N'89e51c6d-c3f2-4448-b819-100bf449f70f', 10000000000, 13000000000, N'8ecc9728-da53-4df3-a1d7-fc5e3eb0a4c6', N'Chính thức xuất hiện tại Việt Nam vào tháng 2/2009, Fortuner là mẫu xe nhận được khá nhiều sự quan tâm của người dùng Việt Nam. Chính vì vậy mà mẫu SUV 7 chỗ này luôn nằm trong danh sách những mẫu xe bán chạy nhất thị trường Việt Nam. Toyota Fortuner 2019 được nhập khẩu nguyên chiếc từ Indonesia với 4 phiên bản có giá dao động từ 1,026 – 1,360 tỷ đồng.', N'toyota fortuner 2.jpg', N'toyota fortuner 3.jpg', N'toyota fortuner.jpg', 0, N'NEW', CAST(N'2019-01-26T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2019-01-26T22:37:38.390' AS DateTime), NULL, 0, N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', NULL)
INSERT [dbo].[Xe] ([IdXe], [TenXe], [SoKhung], [SoMay], [IdNhaCungCap], [MaLoaiXe], [GiaVonXe], [GiaNiemYetXe], [IdKhoXe], [ChiTiet], [Hinh1], [Hinh2], [Hinh3], [SoLuotXem], [TinhTrang], [NgayNhap], [NgayXuat], [OfUser], [CreatedDate], [UpdatedDate], [IsDeleted], [CreatedBy], [UpdatedBy]) VALUES (N'1aaa72ba-d200-44e6-8dd2-c5d46b334bfd', N'Honda Civic', N'SKCV270119', N'SMCV270119', N'f3409d77-8847-43ba-b408-2c51470b2fac', N'89e51c6d-c3f2-4448-b819-100bf449f70f', 200000000, 230000000, N'acba9d50-0ac8-47b3-be54-b2ec5dd5686c', N'Honda Civic 2018 với những cải tiến mới mẻ cho phiên bản thứ 4 đã nhanh chóng thu hút khách hàng với mức giá bán hấp dẫn trên thị trường. Sau màn ra mắt ấn tượng của Honda Civic Type R tại Vietnam Motor Show 2018 càng khẳng định sự phát tiển vượt bậc của hãng xe Honda trong thời gian gần đây. Vậy liệu mức giá bán dành cho các dòng xe này có sự thay đổi? Cùng chúng tôi cập nhật mức giá xe Honda City 2018 mới nhất tại đại lý và tham khảo thiết kế xe Honda City 2019', N'honda civic 4.jpg', N'honda civic 2016.jpg', N'honda civic.jpg', 32, N'NEW', CAST(N'2019-01-30T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2019-01-27T00:34:55.327' AS DateTime), NULL, 0, N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', NULL)
INSERT [dbo].[Xe] ([IdXe], [TenXe], [SoKhung], [SoMay], [IdNhaCungCap], [MaLoaiXe], [GiaVonXe], [GiaNiemYetXe], [IdKhoXe], [ChiTiet], [Hinh1], [Hinh2], [Hinh3], [SoLuotXem], [TinhTrang], [NgayNhap], [NgayXuat], [OfUser], [CreatedDate], [UpdatedDate], [IsDeleted], [CreatedBy], [UpdatedBy]) VALUES (N'c0eff49f-0dcd-40ea-aa53-d4555a43dbb2', N'Mazda 3', N'SoKhung456', N'Somay456  ', N'8ccdc067-c264-4d2a-8b43-da6a9b0f8c22', N'7cf74ff8-e977-412b-9d72-f9f93d9bcc89', 200000000, 220000000, N'8ecc9728-da53-4df3-a1d7-fc5e3eb0a4c6', N'Đây là chiếc SUV đẹp nhất Việt Nam, mới ra mắt vào đầu tháng 1/2019.
Bạn hãy tận hưởng vẻ đẹp của nó qua những hình ảnh sau đây.', N'mazda 3 2.jpg', N'mazda 3 3.jpg', N'mazda 3 4.jpg', 20, N'NEW', CAST(N'2019-01-19T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2019-01-18T17:25:40.813' AS DateTime), NULL, 0, NULL, NULL)
INSERT [dbo].[Xe] ([IdXe], [TenXe], [SoKhung], [SoMay], [IdNhaCungCap], [MaLoaiXe], [GiaVonXe], [GiaNiemYetXe], [IdKhoXe], [ChiTiet], [Hinh1], [Hinh2], [Hinh3], [SoLuotXem], [TinhTrang], [NgayNhap], [NgayXuat], [OfUser], [CreatedDate], [UpdatedDate], [IsDeleted], [CreatedBy], [UpdatedBy]) VALUES (N'57d7d8b6-b781-42c3-b1d5-d884d65e41b1', N'AUDI NEW 2019', N'SKAUDI1234', N'SMAUDI1234', N'646c8bae-ff19-4fed-9a80-90434df83180', N'add3799a-d4ef-450b-99f5-a5c6168fb034', 2000000000, 2500000000, N'acba9d50-0ac8-47b3-be54-b2ec5dd5686c', N'Đây là chiếc xe siêu sang của AUDI, chiếc xe dùng để tăng lên vẻ sang trọng cho hãng xe Đức này.
Bạn hãy cảm nhận nó để đón tết Kỷ Hợi 2019 nhé ...', N'audi a5.jpg', N'audi a8.jpg', N'audi.jpg', 2, N'NEW', CAST(N'2019-01-19T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2019-01-18T21:09:46.060' AS DateTime), NULL, 0, N'2dad25d4-a75f-405c-b405-468d4f8e1d3a', NULL)
ALTER TABLE [dbo].[CTGioHang] ADD  CONSTRAINT [DF_CTGioHang_IdCTGioHang]  DEFAULT (newid()) FOR [IdGioHang]
GO
ALTER TABLE [dbo].[DanhMuc] ADD  CONSTRAINT [DF_DanhMuc_IdDanhMuc]  DEFAULT (newid()) FOR [IdDanhMuc]
GO
ALTER TABLE [dbo].[GioHang] ADD  CONSTRAINT [DF_GioHang_IdGioHang]  DEFAULT (newid()) FOR [IdGioHang]
GO
ALTER TABLE [dbo].[HoaDonChi] ADD  CONSTRAINT [DF_HoaDonChi_IdPhieuChi]  DEFAULT (newid()) FOR [IdPhieuChi]
GO
ALTER TABLE [dbo].[HoaDonThu] ADD  CONSTRAINT [DF_HoaDonThu_IdPhieuThu]  DEFAULT (newid()) FOR [IdPhieuThu]
GO
ALTER TABLE [dbo].[KhoXe] ADD  CONSTRAINT [DF_KhoXe_IdKhoXe]  DEFAULT (newid()) FOR [IdKhoXe]
GO
ALTER TABLE [dbo].[LoaiXe] ADD  CONSTRAINT [DF_LoaiXe_IdLoaiXe]  DEFAULT (newid()) FOR [IdLoaiXe]
GO
ALTER TABLE [dbo].[NguoiDung] ADD  CONSTRAINT [DF_NguoiDung_IdNguoiDung]  DEFAULT (newid()) FOR [IdNguoiDung]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  CONSTRAINT [DF_NhaCungCap_IdNhaCungCap]  DEFAULT (newid()) FOR [IdNhaCungCap]
GO
ALTER TABLE [dbo].[Xe] ADD  CONSTRAINT [DF_Xe_IdXe]  DEFAULT (newid()) FOR [IdXe]
GO
ALTER TABLE [dbo].[CTGioHang]  WITH CHECK ADD  CONSTRAINT [FK_CTGioHang_GioHang] FOREIGN KEY([IdGioHang])
REFERENCES [dbo].[GioHang] ([IdGioHang])
GO
ALTER TABLE [dbo].[CTGioHang] CHECK CONSTRAINT [FK_CTGioHang_GioHang]
GO
ALTER TABLE [dbo].[CTGioHang]  WITH CHECK ADD  CONSTRAINT [FK_CTGioHang_Xe] FOREIGN KEY([IdMaXe])
REFERENCES [dbo].[Xe] ([IdXe])
GO
ALTER TABLE [dbo].[CTGioHang] CHECK CONSTRAINT [FK_CTGioHang_Xe]
GO
ALTER TABLE [dbo].[CTHoaDonChi]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonChi_HoaDonChi] FOREIGN KEY([MaHoaDonChi])
REFERENCES [dbo].[HoaDonChi] ([IdPhieuChi])
GO
ALTER TABLE [dbo].[CTHoaDonChi] CHECK CONSTRAINT [FK_CTHoaDonChi_HoaDonChi]
GO
ALTER TABLE [dbo].[CTHoaDonChi]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonChi_Xe] FOREIGN KEY([MaXe])
REFERENCES [dbo].[Xe] ([IdXe])
GO
ALTER TABLE [dbo].[CTHoaDonChi] CHECK CONSTRAINT [FK_CTHoaDonChi_Xe]
GO
ALTER TABLE [dbo].[CTHoaDonThu]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonThu_HoaDonThu] FOREIGN KEY([MaHoaDonThu])
REFERENCES [dbo].[HoaDonThu] ([IdPhieuThu])
GO
ALTER TABLE [dbo].[CTHoaDonThu] CHECK CONSTRAINT [FK_CTHoaDonThu_HoaDonThu]
GO
ALTER TABLE [dbo].[CTHoaDonThu]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDonThu_Xe] FOREIGN KEY([MaXe])
REFERENCES [dbo].[Xe] ([IdXe])
GO
ALTER TABLE [dbo].[CTHoaDonThu] CHECK CONSTRAINT [FK_CTHoaDonThu_Xe]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_NguoiDung] FOREIGN KEY([IdKhachHang])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_NguoiDung]
GO
ALTER TABLE [dbo].[HoaDonChi]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChi_NguoiDung] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[HoaDonChi] CHECK CONSTRAINT [FK_HoaDonChi_NguoiDung]
GO
ALTER TABLE [dbo].[HoaDonChi]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChi_NhaCungCap] FOREIGN KEY([IdNhacungCap])
REFERENCES [dbo].[NhaCungCap] ([IdNhaCungCap])
GO
ALTER TABLE [dbo].[HoaDonChi] CHECK CONSTRAINT [FK_HoaDonChi_NhaCungCap]
GO
ALTER TABLE [dbo].[HoaDonThu]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonThu_NguoiDung] FOREIGN KEY([KhachHang])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[HoaDonThu] CHECK CONSTRAINT [FK_HoaDonThu_NguoiDung]
GO
ALTER TABLE [dbo].[Quyen]  WITH CHECK ADD  CONSTRAINT [FK_Quyen_NguoiDung] FOREIGN KEY([IdnguoiDung])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[Quyen] CHECK CONSTRAINT [FK_Quyen_NguoiDung]
GO
ALTER TABLE [dbo].[Xe]  WITH CHECK ADD  CONSTRAINT [FK_Xe_KhoXe] FOREIGN KEY([IdKhoXe])
REFERENCES [dbo].[KhoXe] ([IdKhoXe])
GO
ALTER TABLE [dbo].[Xe] CHECK CONSTRAINT [FK_Xe_KhoXe]
GO
ALTER TABLE [dbo].[Xe]  WITH CHECK ADD  CONSTRAINT [FK_Xe_LoaiXe] FOREIGN KEY([MaLoaiXe])
REFERENCES [dbo].[LoaiXe] ([IdLoaiXe])
GO
ALTER TABLE [dbo].[Xe] CHECK CONSTRAINT [FK_Xe_LoaiXe]
GO
ALTER TABLE [dbo].[Xe]  WITH CHECK ADD  CONSTRAINT [FK_Xe_NguoiDung] FOREIGN KEY([OfUser])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[Xe] CHECK CONSTRAINT [FK_Xe_NguoiDung]
GO
ALTER TABLE [dbo].[Xe]  WITH CHECK ADD  CONSTRAINT [FK_Xe_NhaCungCap] FOREIGN KEY([IdNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([IdNhaCungCap])
GO
ALTER TABLE [dbo].[Xe] CHECK CONSTRAINT [FK_Xe_NhaCungCap]
GO
USE [master]
GO
ALTER DATABASE [DoAnNganh] SET  READ_WRITE 
GO
