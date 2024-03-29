USE [master]
GO
/****** Object:  Database [CuoiKi]    Script Date: 1/9/2019 4:16:37 PM ******/
CREATE DATABASE [CuoiKi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CuoiKi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CuoiKi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CuoiKi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CuoiKi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CuoiKi] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CuoiKi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CuoiKi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CuoiKi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CuoiKi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CuoiKi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CuoiKi] SET ARITHABORT OFF 
GO
ALTER DATABASE [CuoiKi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CuoiKi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CuoiKi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CuoiKi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CuoiKi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CuoiKi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CuoiKi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CuoiKi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CuoiKi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CuoiKi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CuoiKi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CuoiKi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CuoiKi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CuoiKi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CuoiKi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CuoiKi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CuoiKi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CuoiKi] SET RECOVERY FULL 
GO
ALTER DATABASE [CuoiKi] SET  MULTI_USER 
GO
ALTER DATABASE [CuoiKi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CuoiKi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CuoiKi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CuoiKi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CuoiKi] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CuoiKi', N'ON'
GO
ALTER DATABASE [CuoiKi] SET QUERY_STORE = OFF
GO
USE [CuoiKi]
GO
/****** Object:  Table [dbo].[CauHoi]    Script Date: 1/9/2019 4:16:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHoi](
	[Mã câu hỏi] [int] NOT NULL,
	[Nội dung] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CauHoi] PRIMARY KEY CLUSTERED 
(
	[Mã câu hỏi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DapAn]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DapAn](
	[Mã câu hỏi] [int] NOT NULL,
	[Mã đáp án] [nchar](10) NOT NULL,
	[Nội dung đáp án] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DapAn1] PRIMARY KEY CLUSTERED 
(
	[Mã đáp án] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DapAnDung]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DapAnDung](
	[Mã câu hỏi] [int] NOT NULL,
	[Mã đáp án đúng] [nchar](10) NOT NULL,
 CONSTRAINT [PK_DapAnDung] PRIMARY KEY CLUSTERED 
(
	[Mã đáp án đúng] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhienThi]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhienThi](
	[Phiên Thi] [nchar](10) NOT NULL,
	[Mã Lớp] [nvarchar](50) NOT NULL,
	[Phòng Thi] [nchar](10) NULL,
	[Ngày Thi] [date] NULL,
	[Giờ Bắt Đầu] [time](7) NULL,
 CONSTRAINT [PK_PhienThi] PRIMARY KEY CLUSTERED 
(
	[Mã Lớp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SV]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SV](
	[MSSV] [nchar](10) NOT NULL,
	[Tên SV] [nvarchar](50) NOT NULL,
	[Mã Lớp] [nvarchar](50) NOT NULL,
	[Password] [nchar](10) NULL,
	[Điểm] [float] NULL,
	[Mã đề] [nchar](10) NULL,
 CONSTRAINT [PK_SV] PRIMARY KEY CLUSTERED 
(
	[MSSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (1, N'Bộ nhớ RAM và ROM là bộ nhớ gì ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (2, N'Phát biểu nào sau đây là sai ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (3, N'Dữ liệu là gì ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (4, N'Bit là gì ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (5, N'Hex là hệ đếm ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (6, N'Các thành phần : bộ nhớ chính , bộ xử lý trung ương , bộ phận nhập xuất , các loại hệ hành là :')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (7, N'Hệ thống các chương trình đẩm nhận chức năng là môi trường trung gian giữa người sử dụng và phần cứ của máy tính được gọi là ? ')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (8, N'Các loại hệ điều hành WinDows đều các khả năng tự động nhận biết các thiết bị phần cứng và tự động cài đặc cấu hình của các thiết bị dây là chức năng ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (9, N'Danh sách các mục chọn trong thực đơn được gọi ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (10, N'Hộp điều khiển việc phóng to, thu nhỏ , đóng của sổ được gọi là ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (11, N'Windows Explorer có thành phần :Explorer bar , Explorer view , Tool bar , menu bar . Còn lại là gì ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (12, N'Shortcut là biểu tượng đại diện cho chương trình hay một tập tin để khởi động một chương trình hay một tập tin . Vậy có mấy loại Shortcut ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (13, N'Để chạy một ứng dụng trong Windows , bạn là thế nào ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (14, N'Chương trình cho phép định nghĩa lại cấu hình hệ thống thay đổi môi trường làm cho phù hợp ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (15, N'Các kí tự sau đây kí tự nào không được dùng để nhập tên của tập tin , thư mục ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (16, N'Có mấy cách tạo một văn bản trong Work ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (17, N'Sử dụng Office Clipboard, bạn có thể lưu trữ tối đa bao nhiêu clipboard ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (18, N'Thao tác Shift + Enter có chức năng gì ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (19, N'Muốn xác định khoảng cách và vị trí kì tự ta vào ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (20, N'Phím nóng Shift+Ctrl + = có chức năng gì ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (21, N'Để gạch chân mỗi chữ nét đơn , ngoài việc vào Format/Fornt ta còn có thể sử dụng tổ hợp phím nào ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (22, N'Trong hộp thoại Format/Paragraph ngoài việc có thể hiệu chỉnh lề cho đoạn , khoảng cách cho đoạn , các dòng, còn dùng chức năng nào sau đây ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (23, N'Trong phần File/Page Setup mục gutter có chức năng là gì ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (24, N'Để thay đổi đơn vị đo cuat thước ta chọn ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (25, N'Trong trang Format/Bullets and Numbering nếu bạn muốn chọn thông số khác ta vào mục Customize . Trong này, phần Number Format dùng để ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (26, N'Trong Format/Drop Cap , phần Distance form text dùng để xác định khoảng cách?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (27, N'Trong hộp thoại File/ Page Setup khung Margins , mục Mirror Margins dùng để ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (28, N'Bạn có thể chú thích thuật ngữ cho một từ , 1 câu bằng Footnote. Như vậy Footnote có nghĩa là ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (29, N'Để di chuyển con trỏ trong bảng Table , ta dùng phím nóng . Vậy phím nóng Shift+Tab dùng để làm gì ?')
INSERT [dbo].[CauHoi] ([Mã câu hỏi], [Nội dung]) VALUES (30, N'Chọn cả bảng table ta nhấn hợp phím ?')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (1, N'1 a       ', N'Secondary memory')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (1, N'1 b       ', N' Receive memory')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (1, N'1 c       ', N'Primary memory ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (1, N'1 d       ', N'Random access memory')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (10, N'10 a      ', N'Dialog box ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (10, N'10 b      ', N'list box')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (10, N'10 c      ', N'Control box')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (10, N'10 d      ', N'Text box')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (11, N'11 a      ', N'Status bar  ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (11, N'11 b      ', N'Menu bar')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (11, N'11 c      ', N'Task bar')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (11, N'11 d      ', N'tất cả đều sai')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (12, N'12 a      ', N'1 loại    ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (12, N'12 b      ', N'3 loại')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (12, N'12 c      ', N'2 loại')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (12, N'12 d      ', N'4 loại')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (13, N'13 a      ', N'Vào Start -> Tìm tên ứng dụng cần chạy -> Nhấn vào biểu tượng ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (13, N'13 b      ', N'Nhấp đúp vào biểu tượng ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (13, N'13 c      ', N'a và b đều đúng')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (13, N'13 d      ', N'a và b đều sai')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (14, N'14 a      ', N'Display  ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (14, N'14 b      ', N'Sreen Saver')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (14, N'14 c      ', N'Control panel')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (14, N'14 d      ', N'Tất cả đều có thể')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (15, N'15 a      ', N'a/ @, 1, %  b/ c/  d/ ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (15, N'15 b      ', N'- (,)')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (15, N'15 c      ', N' ~, “, ? , @, #, $')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (15, N'15 d      ', N'*, /, \, <, >')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (16, N'16 a      ', N'2 cách')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (16, N'16 b      ', N'3 cách')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (16, N'16 c      ', N'4 cách')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (16, N'16 d      ', N'5 cách')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (17, N'17 a      ', N'10')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (17, N'17 b      ', N'12')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (17, N'17 c      ', N'16')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (17, N'17 d      ', N'20')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (18, N'18 a      ', N'Xuống hàng chưa kết thúc paragraph')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (18, N'18 b      ', N'Xuống một trang màn hình')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (18, N'18 c      ', N'Nhập dữ liệu theo hàng dọc')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (18, N'18 d      ', N'Tất cả đều sai')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (19, N'19 a      ', N'Format/Paragragh ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (19, N'19 b      ', N'Format/Style ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (19, N'19 c      ', N'Format/Font')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (19, N'19 d      ', N'Format/Object')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (2, N'2 a       ', N'Đơn vị điều khiển chứa CPU, điều khiển tất cả các hoạt động của máy.')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (2, N'2 b       ', N'CPU là bộ nhớ xử lý trung ương, thực hiện việc xử lý thông tin lưu trữ trong bộ nhớ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (2, N'2 c       ', N'ALU là đơn vị số học và luận lý và các thanh ghi cũ ng nằm trong CPU')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (2, N'2 d       ', N' Memory Cell là tập hợp các ô nhớ.')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (20, N'20 a      ', N'Bật hoặc tắt gạch dưới nét đôi ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (20, N'20 b      ', N'Bật hoặc tắt chỉ số dưới ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (20, N'20 c      ', N'Bật hoặc tắt chỉ số trên')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (20, N'20 d      ', N'Trả về dạng mặc định')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (21, N'21 a      ', N'Ctrl + Shift + D ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (21, N'21 b      ', N'Ctrl + Shift + W ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (21, N'21 c      ', N'Ctrl + Shift + A')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (21, N'21 d      ', N'Ctrl + Shift + K')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (22, N'22 a      ', N'Định dạng cột')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (22, N'22 b      ', N'Canh chỉnh Tab ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (22, N'22 c      ', N'Thay đổi font chữ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (22, N'22 d      ', N'Tất cả đều sai')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (23, N'23 a      ', N'Quy định khoảng cách từ mép đến trang in')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (23, N'23 b      ', N'Chia văn bản thành số đoạn theo ý muốn')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (23, N'23 c      ', N'Phần chừa trống để đóng thành tập')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (23, N'23 d      ', N'Quy định lề của trang in')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (24, N'24 a      ', N'Format/Tabs')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (24, N'24 b      ', N'Tools/Option/General ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (24, N'24 c      ', N'Format/Object')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (24, N'24 d      ', N'Tools/Option/View')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (25, N'25 a      ', N'Hiệu chỉnh ký hiệu của Number ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (25, N'25 b      ', N'Hiệu chỉnh ký hiệu của Bullets ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (25, N'25 c      ', N'Thêm văn bản ở trước, sau dấu hoa thị')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (25, N'25 d      ', N'Thay đổi font chữ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (26, N'26 a      ', N'Giữa ký tự Drop Cap với lề trái ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (26, N'26 b      ', N'Giữa ký tự Drop Cap với lề phải ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (26, N'26 c      ', N'Giữa ký tự Drop Cap với ký tự tiếp theo')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (26, N'26 d      ', N'Giữa ký tự Drop Cap với toàn văn bản')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (27, N'27 a      ', N'Đặt lề cho văn bản cân xứng ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (27, N'27 b      ', N'Đặt cho tiêu đề cân xứng với văn bản')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (27, N'27 c      ', N'Đặt lề cho các trang chẳn và lẻ đối xứng')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (27, N'27 d      ', N'Đặt lề cho các section đối xứng nhau')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (28, N'28 a      ', N'Chú thích được trình bày ở cuối từ cần chú thích')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (28, N'28 b      ', N'Chú thích được trình bày ở cuối trang')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (28, N'28 c      ', N'Chú thích được trình bày ở cuối văn bản')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (28, N'28 d      ', N'Chú thích được trình bà y ở cuối toàn bộ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (29, N'29 a      ', N'Di chuyển con trỏ đến ô liền trước ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (29, N'29 b      ', N'Di chuyển con trỏ đến hàng trên ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (29, N'29 c      ', N'Thêm một tab vào ô')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (29, N'29 d      ', N'Phím nóng trên không có chức năng gì')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (3, N'3 a       ', N'Là các số liệu hoặc là tà i liệu cho trước chưa được xử lý.')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (3, N'3 b       ', N'Là khái niệm có thể được phát sinh, lưu trữ , tìm kiếm, sao chép, biến đổi…')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (3, N'3 c       ', N' Là các thông tin được thể hiện dưới nhiều dạng khác nhau')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (3, N'3 d       ', N'Tất cả đều đúng.')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (30, N'30 a      ', N'Alt + Shift + 5 (5 trên bàn phím số) ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (30, N'30 b      ', N'Alt + 5 (5 trên phím số và tắt numlock) ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (30, N'30 c      ', N'a và b đều đúng')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (30, N'30 d      ', N'a và b đều sai')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (4, N'4 a       ', N'Là đơn vị nhỏ nhất của thông tin được sử dụng trong máy tính')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (4, N'4 b       ', N'là một phần tử nhỏ mang một trong 2 giá trị 0 và 1')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (4, N'4 c       ', N'Là một đơn vị đo thông tind')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (4, N'4 d       ', N'Tất cả đều đúng')
GO
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (5, N'5 a       ', N'hệ nhị phân   ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (5, N'5 b       ', N'Hệ bát phân')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (5, N'5 c       ', N'Hệ thập phân')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (5, N'5 d       ', N'Hệ thập lục phân')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (6, N'6 a       ', N' Phần cứng  ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (6, N'6 b       ', N'Phần mềm')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (6, N'6 c       ', N'Thiết bị lưu trữ  ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (6, N'6 d       ', N'Tất cả đều sai')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (7, N'7 a       ', N' Phần mềm  ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (7, N'7 b       ', N'hệ điều hành')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (7, N'7 c       ', N'Các loại trình dịch trung gian')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (7, N'7 d       ', N'Tất cả đều đúng')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (8, N'8 a       ', N' Plug and Play  ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (8, N'8 b       ', N' Windows Explorer')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (8, N'8 c       ', N'Desktop')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (8, N'8 d       ', N'Multimedia')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (9, N'9 a       ', N'Menu bar ')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (9, N'9 b       ', N'Menu pad')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (9, N'9 c       ', N'Menu options')
INSERT [dbo].[DapAn] ([Mã câu hỏi], [Mã đáp án], [Nội dung đáp án]) VALUES (9, N'9 d       ', N'Tất cả đều sai')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (1, N'1 c       ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (10, N'10 c      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (11, N'11 a      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (12, N'12 a      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (13, N'13 c      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (14, N'14 c      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (15, N'15 d      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (16, N'16 b      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (17, N'17 d      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (18, N'18 a      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (19, N'19 a      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (2, N'2 c       ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (20, N'20 c      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (21, N'21 b      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (22, N'22 d      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (23, N'23 c      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (24, N'24 b      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (25, N'25 d      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (26, N'26 d      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (27, N'27 c      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (28, N'28 b      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (29, N'29 a      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (3, N'3 d       ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (30, N'30 c      ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (4, N'4 d       ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (5, N'5 d       ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (6, N'6 a       ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (7, N'7 b       ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (8, N'8 a       ')
INSERT [dbo].[DapAnDung] ([Mã câu hỏi], [Mã đáp án đúng]) VALUES (9, N'9 a       ')
INSERT [dbo].[PhienThi] ([Phiên Thi], [Mã Lớp], [Phòng Thi], [Ngày Thi], [Giờ Bắt Đầu]) VALUES (N'4         ', N'15T1', N'C105      ', NULL, NULL)
INSERT [dbo].[PhienThi] ([Phiên Thi], [Mã Lớp], [Phòng Thi], [Ngày Thi], [Giờ Bắt Đầu]) VALUES (N'5         ', N'15T2', N'C102      ', NULL, NULL)
INSERT [dbo].[PhienThi] ([Phiên Thi], [Mã Lớp], [Phòng Thi], [Ngày Thi], [Giờ Bắt Đầu]) VALUES (N'6         ', N'15T3', N'C103      ', NULL, NULL)
INSERT [dbo].[PhienThi] ([Phiên Thi], [Mã Lớp], [Phòng Thi], [Ngày Thi], [Giờ Bắt Đầu]) VALUES (N'1         ', N'16T1', N'C102      ', NULL, NULL)
INSERT [dbo].[PhienThi] ([Phiên Thi], [Mã Lớp], [Phòng Thi], [Ngày Thi], [Giờ Bắt Đầu]) VALUES (N'2         ', N'16T2', N'C103      ', NULL, NULL)
INSERT [dbo].[PhienThi] ([Phiên Thi], [Mã Lớp], [Phòng Thi], [Ngày Thi], [Giờ Bắt Đầu]) VALUES (N'3         ', N'16T3', N'C104      ', NULL, NULL)
INSERT [dbo].[PhienThi] ([Phiên Thi], [Mã Lớp], [Phòng Thi], [Ngày Thi], [Giờ Bắt Đầu]) VALUES (N'7         ', N'16TCL1', N'C104      ', NULL, NULL)
INSERT [dbo].[PhienThi] ([Phiên Thi], [Mã Lớp], [Phòng Thi], [Ngày Thi], [Giờ Bắt Đầu]) VALUES (N'8         ', N'16TCL2', N'C105      ', NULL, NULL)
INSERT [dbo].[PhienThi] ([Phiên Thi], [Mã Lớp], [Phòng Thi], [Ngày Thi], [Giờ Bắt Đầu]) VALUES (N'9         ', N'16TCL3', N'C101      ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV001     ', N'Nguyễn Văn An', N'16T1', N'SV001     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV002     ', N'Nguyễn Thị Ba', N'16T1', N'SV002     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV003     ', N'Nguyễn Văn Li', N'16T1', N'SV003     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV004     ', N'Trần Bi', N'16T2', N'SV004     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV005     ', N'Lê Vi', N'16T2', N'SV005     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV006     ', N'Bùi Ti', N'16T2', N'SV006     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV007     ', N'Phan Nghi', N'16T3', N'SV007     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV008     ', N'Châu hi', N'16T3', N'SV008     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV009     ', N'Lê Nga', N'16T3', N'SV009     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV010     ', N'Trần Tống', N'15T1', N'SV010     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV011     ', N'Lê Phúc', N'15T1', N'SV011     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV012     ', N'Võ Thái', N'15T1', N'SV012     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV013     ', N'Võ Dương', N'15T2', N'SV013     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV014     ', N'Trần Trà', N'15T2', N'SV014     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV015     ', N'Trần My', N'15T2', N'SV015     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV016     ', N'Trần Hồng', N'14T1', N'SV016     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV017     ', N'Trần Ý', N'14T1', N'SV017     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV018     ', N'Lê Xinh', N'14T2', N'SV018     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV019     ', N'Lê Sa', N'14T2', N'SV019     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV020     ', N'Hư Trúc', N'14T3', N'SV020     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV021     ', N'Đoàn Dự', N'14T3', N'SV021     ', NULL, NULL)
INSERT [dbo].[SV] ([MSSV], [Tên SV], [Mã Lớp], [Password], [Điểm], [Mã đề]) VALUES (N'SV022     ', N'Trường Giang', N'16T1', N'SV022     ', NULL, NULL)
ALTER TABLE [dbo].[DapAn]  WITH CHECK ADD  CONSTRAINT [FK_DapAn1_CauHoi] FOREIGN KEY([Mã câu hỏi])
REFERENCES [dbo].[CauHoi] ([Mã câu hỏi])
GO
ALTER TABLE [dbo].[DapAn] CHECK CONSTRAINT [FK_DapAn1_CauHoi]
GO
ALTER TABLE [dbo].[DapAnDung]  WITH CHECK ADD  CONSTRAINT [FK_DapAnDung_CauHoi] FOREIGN KEY([Mã câu hỏi])
REFERENCES [dbo].[CauHoi] ([Mã câu hỏi])
GO
ALTER TABLE [dbo].[DapAnDung] CHECK CONSTRAINT [FK_DapAnDung_CauHoi]
GO
/****** Object:  StoredProcedure [dbo].[Get_Bai_Thi]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[Get_Bai_Thi]
@MaDT nchar(10) = null
AS
BEGIN 
	SELECT [Mã đề thi],h.[Mã câu hỏi], [Nội dung] FROM DeThi as d, CauHoi as h WHERE [Mã đề thi] = @MaDT AND d.[Mã câu hỏi] = h.[Mã câu hỏi]

END
GO
/****** Object:  StoredProcedure [dbo].[Get_BaiThi]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[Get_BaiThi]
AS
BEGIN 
	SELECT [Mã đề thi],h.[Mã câu hỏi], [Nội dung] FROM DeThi as d, CauHoi as h WHERE [Mã đề thi] = 133 AND d.[Mã câu hỏi] = h.[Mã câu hỏi]

END
GO
/****** Object:  StoredProcedure [dbo].[Get_CauHoi]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_CauHoi]
@Ma_DT char(10) = null
AS
BEGIN
	SELECT d.[Mã đề thi], d.[Mã câu hỏi], ch.[Nội dung] FROM DeThi as d ,CauHoi as ch WHERE d.[Mã đề thi] = 190 AND d.[Mã câu hỏi] = ch.[Mã câu hỏi]  
END
GO
/****** Object:  StoredProcedure [dbo].[Get_CH_DT]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_CH_DT]
@MaDT char(10) = null
AS
BEGIN
	SELECT d.[Mã đề thi], d.[Mã câu hỏi], ch.[Nội dung] FROM DeThi as d ,CauHoi as ch WHERE d.[Mã đề thi] = @MaDT AND d.[Mã câu hỏi] = ch.[Mã câu hỏi]  
END
GO
/****** Object:  StoredProcedure [dbo].[Get_DeThi]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_DeThi]
@Ma_DT int = null
AS
BEGIN
	SELECT d.[Mã đề thi], d.[Mã câu hỏi], ch.[Nội dung],da.[Mã đáp án],da.[Nội dung đáp án],dad.[Mã đáp án đúng] FROM DeThi as d ,CauHoi as ch,DapAn as da,DapAnDung as dad WHERE d.[Mã đề thi] = @Ma_DT AND d.[Mã câu hỏi] = ch.[Mã câu hỏi] AND ch.[Mã câu hỏi] = da.[Mã câu hỏi] AND da.[Mã câu hỏi] = dad.[Mã câu hỏi]
END
GO
/****** Object:  StoredProcedure [dbo].[Get_DT]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[Get_DT]
@MaDT nchar(10) = null
AS
BEGIN 
		SELECT [Mã đề thi],h.[Mã câu hỏi], [Nội dung],da.[Mã đáp án],da.[Nội dung đáp án] FROM DeThi as d, CauHoi as h,DapAn da WHERE [Mã đề thi] = @MaDT AND d.[Mã câu hỏi] = h.[Mã câu hỏi] AND h.[Mã câu hỏi] = da.[Mã câu hỏi]
END
GO
/****** Object:  StoredProcedure [dbo].[GetALLDeThi]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetALLDeThi]
AS 
SELECT c.[Mã câu hỏi], c.[Nội dung], d.[Mã đáp án], d.[Nội dung đáp án], dad.[Mã đáp án đúng]  FROM CauHoi c, DapAn d, DapAnDung dad
WHERE c.[Mã câu hỏi]=d.[Mã câu hỏi] AND c.[Mã câu hỏi] = dad.[Mã câu hỏi]
GO
/****** Object:  StoredProcedure [dbo].[GetAllStudent]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllStudent]
AS
	SELECT * FROM SV
GO
/****** Object:  StoredProcedure [dbo].[getAllSV]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAllSV]
AS
SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.Password  FROM SV s
GO
/****** Object:  StoredProcedure [dbo].[GetQuestion]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetQuestion]
	@id int = null
AS
BEGIN
	SELECT ch.[Nội dung],da.[Nội dung đáp án] FROM  CauHoi as ch,DapAn da WHERE ch.[Mã câu hỏi]=da.[Mã câu hỏi];
END
GO
/****** Object:  StoredProcedure [dbo].[Ghi_diem]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Ghi_diem]
@MSSV nchar(10) = null,
@diem float = null
AS
BEGIN
	INSERT INTO Diem(MSSV,Điểm) VALUES ('@MSSV', @diem);
END
GO
/****** Object:  StoredProcedure [dbo].[LoginAdmin]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoginAdmin]
AS
BEGIN
	SELECT * FROM admin;
END
GO
/****** Object:  StoredProcedure [dbo].[Luu_diem]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Luu_diem]
@mssv nchar(10) = null,
@mch char(10) =null,
@diem float = null
AS
BEGIN
	INSERT INTO Diem(MSSV,[Mã câu hỏi],Điểm) VALUES (@mssv,@mch, @diem);
END
GO
/****** Object:  StoredProcedure [dbo].[updateSV]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateSV]
@name nvarchar(50),
@maLop  nvarchar(50),
@pass nchar(10),
@id nchar(10)
AS
 UPDATE SV SET [Tên SV] = @name,[Mã Lớp] = @maLop, Password = @pass
 WHERE MSSV = @id
GO
/****** Object:  StoredProcedure [dbo].[XuatDiem]    Script Date: 1/9/2019 4:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[XuatDiem]
@maLop nchar(10)
AS
BEGIN
	SELECT s.MSSV, s.[Tên SV], s.[Mã Lớp], s.[Mã đề], s.Điểm FROM SV s  WHERE s.[Mã Lớp] = @maLop
END
GO
USE [master]
GO
ALTER DATABASE [CuoiKi] SET  READ_WRITE 
GO
