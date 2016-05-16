/*
Navicat SQL Server Data Transfer

Source Server         : V2IMSDB
Source Server Version : 105000
Source Host           : .:1433
Source Database       : V2IMSDB
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 105000
File Encoding         : 65001

Date: 2013-12-29 23:01:15
*/


-- ----------------------------
-- Table structure for Category
-- ----------------------------
DROP TABLE [dbo].[Category]
GO
CREATE TABLE [dbo].[Category] (
[Id] int NOT NULL IDENTITY(1,1) ,
[ParentId] int NOT NULL ,
[Status] int NOT NULL ,
[Order] int NULL ,
[Name] varchar(100) NULL ,
[Desc] varchar(500) NULL ,
[CreatedDate] datetime NOT NULL DEFAULT (getdate()) ,
[UpdatedDate] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Category', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品分类表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品分类表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Category', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品分类Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品分类Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Category', 
'COLUMN', N'ParentId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品分类 父级Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'ParentId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品分类 父级Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'ParentId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Category', 
'COLUMN', N'Status')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品分类状态:1、可用 2、停用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'Status'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品分类状态:1、可用 2、停用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'Status'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Category', 
'COLUMN', N'Order')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品分类排序'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'Order'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品分类排序'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'Order'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Category', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品分类名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品分类名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Category', 
'COLUMN', N'Desc')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品分类描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'Desc'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品分类描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'Desc'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Category', 
'COLUMN', N'CreatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Category'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
GO

-- ----------------------------
-- Table structure for Goods
-- ----------------------------
DROP TABLE [dbo].[Goods]
GO
CREATE TABLE [dbo].[Goods] (
[Id] int NOT NULL IDENTITY(1,1) ,
[CategoryId] int NOT NULL ,
[SupplierId] int NOT NULL ,
[Code] varchar(50) NOT NULL ,
[OriginalCode] varchar(50) NOT NULL ,
[SourceType] int NOT NULL ,
[Name] varchar(255) NOT NULL ,
[Status] int NOT NULL ,
[Image] varchar(MAX) NULL ,
[Color] varchar(100) NULL ,
[Quality] varchar(100) NULL ,
[Parts] varchar(100) NULL ,
[MarkPrice] decimal(8,2) NULL ,
[PrimePrice] decimal(8,2) NULL ,
[SalePrice] decimal(8,2) NULL ,
[Prepay] decimal(8,2) NULL ,
[Discount] decimal(8,2) NULL ,
[Desc] varchar(1024) NULL ,
[Paid] int NULL ,
[ConsignStartDate] datetime NULL DEFAULT (getdate()) ,
[ConsignEndDate] datetime NULL ,
[CreatedDate] datetime NOT NULL DEFAULT (getdate()) ,
[SaledDate] datetime NULL ,
[UpdatedDate] datetime NULL 
)

GO

IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'库存表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'库存表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'货品Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'货品Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'CategoryId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所属分类Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'CategoryId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所属分类Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'CategoryId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'SupplierId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'供应商Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'SupplierId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'供应商Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'SupplierId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Code')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品编码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Code'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品编码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Code'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'OriginalCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'原厂编码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'OriginalCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'原厂编码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'OriginalCode'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'SourceType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'来源类型：寄售：1，进货自有：2'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'SourceType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'来源类型：寄售：1，进货自有：2'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'SourceType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Status')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'货品状态：1、在库；2、预定；3、售出；4、取回；'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Status'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'货品状态：1、在库；2、预定；3、售出；4、取回；'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Status'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Image')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'货品图片'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Image'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'货品图片'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Image'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Color')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'货品颜色'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Color'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'货品颜色'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Color'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Quality')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'货品成色'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Quality'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'货品成色'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Quality'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Parts')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'货品配件'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Parts'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'货品配件'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Parts'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'MarkPrice')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'货品标价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'MarkPrice'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'货品标价'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'MarkPrice'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'PrimePrice')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'进货价格'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'PrimePrice'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'进货价格'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'PrimePrice'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'SalePrice')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'售出价格'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'SalePrice'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'售出价格'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'SalePrice'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Prepay')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'预付款'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Prepay'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'预付款'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Prepay'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Discount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'折扣金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Discount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'折扣金额'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Discount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Desc')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'货品描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Desc'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'货品描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Desc'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'CreatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'SaledDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'售出时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'SaledDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'售出时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'SaledDate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'UpdatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最近一次更新时间，进出货记录的更新也算在这个字段里'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'UpdatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最近一次更新时间，进出货记录的更新也算在这个字段里'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'UpdatedDate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'Paid')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'商品是否已打款：1：已打款；2、未打款'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Paid'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'商品是否已打款：1：已打款；2、未打款'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'Paid'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'ConsignStartDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'寄售开始时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'ConsignStartDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'寄售开始时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'ConsignStartDate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Goods', 
'COLUMN', N'ConsignEndDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'寄售结束时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'ConsignEndDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'寄售结束时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Goods'
, @level2type = 'COLUMN', @level2name = N'ConsignEndDate'
GO

-- ----------------------------
-- Table structure for OperateLog
-- ----------------------------
DROP TABLE [dbo].[OperateLog]
GO
CREATE TABLE [dbo].[OperateLog] (
[Id] int NOT NULL IDENTITY(1,1) ,
[UserId] int NOT NULL ,
[ShopId] int NOT NULL ,
[Type] int NULL ,
[Desc] varchar(1024) NULL ,
[Operator] varchar(100) NULL ,
[CreatedDate] datetime NOT NULL DEFAULT (getdate()) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperateLog', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作日志表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作日志表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperateLog', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'日志Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'日志Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperateLog', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'当前用户Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'当前用户Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'UserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperateLog', 
'COLUMN', N'ShopId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户所在店铺Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'ShopId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户所在店铺Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'ShopId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperateLog', 
'COLUMN', N'Type')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作类型：1、新增；2、修改；3、删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'Type'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作类型：1、新增；2、修改；3、删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'Type'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperateLog', 
'COLUMN', N'Desc')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'Desc'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'Desc'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperateLog', 
'COLUMN', N'Operator')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作用户'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'Operator'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作用户'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'Operator'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperateLog', 
'COLUMN', N'CreatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperateLog'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
GO

-- ----------------------------
-- Table structure for PayType
-- ----------------------------
DROP TABLE [dbo].[PayType]
GO
CREATE TABLE [dbo].[PayType] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(255) NULL ,
[BankCharge] DECIMAL(8,2),
[CreatedDate] datetime NOT NULL DEFAULT (getdate()) ,
[UpdatedDate] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'PayType', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'付款类型表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PayType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'付款类型表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PayType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'PayType', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PayType'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PayType'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'PayType', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'付款方式名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PayType'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'付款方式名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PayType'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'PayType', 
'COLUMN', N'BankCharge')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'付款方式银行扣率'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PayType'
, @level2type = 'COLUMN', @level2name = N'BankCharge'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'付款方式银行扣率'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PayType'
, @level2type = 'COLUMN', @level2name = N'BankCharge'
GO
-- ----------------------------
-- Table structure for PurchaseRecord
-- ----------------------------
DROP TABLE [dbo].[PurchaseRecord]
GO
CREATE TABLE [dbo].[PurchaseRecord] (
[Id] int NOT NULL IDENTITY(1,1) ,
[UserId] int NOT NULL ,
[GoodsId] int NOT NULL ,
[PayType] int NOT NULL ,
[Remark] varchar(2048) NULL ,
[Operator] varchar(100) NULL ,
[CreatedDate] datetime NOT NULL DEFAULT (getdate()) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'PurchaseRecord', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'进货记录表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'进货记录表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'PurchaseRecord', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'进货Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'进货Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'PurchaseRecord', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'当前用户Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'当前用户Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'UserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'PurchaseRecord', 
'COLUMN', N'GoodsId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'货品Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'GoodsId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'货品Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'GoodsId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'PurchaseRecord', 
'COLUMN', N'PayType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'付款方式：1、现金；2、汇款；3、信用卡；4、网银转帐；'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'PayType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'付款方式：1、现金；2、汇款；3、信用卡；4、网银转帐；'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'PayType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'PurchaseRecord', 
'COLUMN', N'Operator')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'经手人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'Operator'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'经手人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'Operator'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'PurchaseRecord', 
'COLUMN', N'CreatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'进货时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'进货时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'PurchaseRecord'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
GO

-- ----------------------------
-- Table structure for Role
-- ----------------------------
DROP TABLE [dbo].[Role]
GO
CREATE TABLE [dbo].[Role] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(100) NULL ,
[Desc] varchar(500) NULL ,
[CreatedDate] datetime NOT NULL DEFAULT (getdate()) ,
[UpdatedDate] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Role', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'系统角色表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'系统角色表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Role', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Role', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Role', 
'COLUMN', N'Desc')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'Desc'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'Desc'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Role', 
'COLUMN', N'CreatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
GO

-- ----------------------------
-- Table structure for RoleColumn
-- ----------------------------
DROP TABLE [dbo].[RoleColumn]
GO
CREATE TABLE [dbo].[RoleColumn] (
[Id] int NOT NULL IDENTITY(1,1) ,
[RoleId] int NULL ,
[ColumnIds] nvarchar(1024) NULL ,
[UpdatedDate] datetime NULL DEFAULT (getdate()) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'RoleColumn', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关系Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RoleColumn'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关系Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RoleColumn'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'RoleColumn', 
'COLUMN', N'RoleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RoleColumn'
, @level2type = 'COLUMN', @level2name = N'RoleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RoleColumn'
, @level2type = 'COLUMN', @level2name = N'RoleId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'RoleColumn', 
'COLUMN', N'ColumnIds')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色有权限的列，以'',''分隔'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RoleColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnIds'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色有权限的列，以'',''分隔'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RoleColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnIds'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'RoleColumn', 
'COLUMN', N'UpdatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'权限最近一次更新时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RoleColumn'
, @level2type = 'COLUMN', @level2name = N'UpdatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'权限最近一次更新时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RoleColumn'
, @level2type = 'COLUMN', @level2name = N'UpdatedDate'
GO

-- ----------------------------
-- Table structure for SaledRecord
-- ----------------------------
DROP TABLE [dbo].[SaledRecord]
GO
CREATE TABLE [dbo].[SaledRecord] (
[Id] int NOT NULL IDENTITY(1,1) ,
[UserId] int NOT NULL ,
[GoodsId] int NOT NULL ,
[PayType] int NULL ,
[CustomerName] varchar(100) NULL ,
[CustomerPhone] varchar(50) NULL,
[Remark] varchar(2048) NULL ,
[Operator] varchar(100) NULL ,
[CreatedDate] datetime NOT NULL DEFAULT (getdate()) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SaledRecord', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'销售记录'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'销售记录'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SaledRecord', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'销售记录Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'销售记录Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SaledRecord', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'当前登录用户名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'当前登录用户名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'UserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SaledRecord', 
'COLUMN', N'GoodsId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'货品Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'GoodsId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'货品Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'GoodsId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SaledRecord', 
'COLUMN', N'PayType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'付款方式：1、现金；2、汇款；3、信用卡；4、网银转帐；'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'PayType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'付款方式：1、现金；2、汇款；3、信用卡；4、网银转帐；'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'PayType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SaledRecord', 
'COLUMN', N'Operator')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'经手人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'Operator'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'经手人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'Operator'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SaledRecord', 
'COLUMN', N'CreatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'售出时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'售出时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SaledRecord', 
'COLUMN', N'CustomerName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'顾客姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'CustomerName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'顾客姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'CustomerName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SaledRecord', 
'COLUMN', N'CustomerPhone')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'顾客联系方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'CustomerPhone'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'顾客联系方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'CustomerPhone'
GO

-- ----------------------------
-- Table structure for Shop
-- ----------------------------
DROP TABLE [dbo].[Shop]
GO
CREATE TABLE [dbo].[Shop] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(100) NULL ,
[Phone] varchar(20) NULL ,
[Address] varchar(200) NULL ,
[Desc] varchar(500) NULL ,
[CreatedDate] datetime NOT NULL DEFAULT (getdate()) ,
[UpdatedDate] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Shop', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'店铺表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'店铺表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Shop', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'店铺Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'店铺Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Shop', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'店铺名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'店铺名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Shop', 
'COLUMN', N'Phone')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'Phone'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'Phone'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Shop', 
'COLUMN', N'Address')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'店铺地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'Address'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'店铺地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'Address'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Shop', 
'COLUMN', N'Desc')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'店铺描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'Desc'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'店铺描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'Desc'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Shop', 
'COLUMN', N'CreatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Shop'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
GO

-- ----------------------------
-- Table structure for Supplier
-- ----------------------------
DROP TABLE [dbo].[Supplier]
GO
CREATE TABLE [dbo].[Supplier] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(10) NOT NULL ,
[Sex] int NULL ,
[Phone] varchar(50) NULL ,
[BankName] varchar(200) NULL ,
[BankCard] varchar(50) NULL ,
[IdCard] varchar(50) NULL ,
[Address] varchar(200) NULL ,
[CreatedDate] datetime NOT NULL DEFAULT (getdate()) ,
[UpdatedDate] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Supplier', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'供应商'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'供应商'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Supplier', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'供应商Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'供应商Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Supplier', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'供应商名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'供应商名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Supplier', 
'COLUMN', N'Sex')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'供应商性别：0、未知；1、男;2、女;'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'Sex'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'供应商性别：0、未知；1、男;2、女;'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'Sex'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Supplier', 
'COLUMN', N'Phone')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'Phone'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'Phone'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Supplier', 
'COLUMN', N'BankName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'开户行名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'BankName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'开户行名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'BankName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Supplier', 
'COLUMN', N'BankCard')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'银行卡号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'BankCard'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'银行卡号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'BankCard'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Supplier', 
'COLUMN', N'IdCard')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'身份证号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'IdCard'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'身份证号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'IdCard'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Supplier', 
'COLUMN', N'Address')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'通信地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'Address'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'通信地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'Address'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Supplier', 
'COLUMN', N'CreatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Supplier'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
GO

-- ----------------------------
-- Table structure for TableColumn
-- ----------------------------
DROP TABLE [dbo].[TableColumn]
GO
CREATE TABLE [dbo].[TableColumn] (
[Id] int NOT NULL IDENTITY(1,1) ,
[TableName] varchar(50) NULL ,
[TableDesc] varchar(100) NULL ,
[ColumnName] varchar(50) NOT NULL ,
[ColumnCaption] varchar(50) NULL ,
[ColumnDesc] varchar(100) NULL ,
[ColumnDataType] varchar(50) NULL ,
[ColumnType] int NOT NULL DEFAULT ((1)) ,
[CreatedDate] datetime NULL DEFAULT (getdate()) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TableColumn', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'列Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'列Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TableColumn', 
'COLUMN', N'TableName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'表名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'TableName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'表名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'TableName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TableColumn', 
'COLUMN', N'TableDesc')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'表描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'TableDesc'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'表描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'TableDesc'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TableColumn', 
'COLUMN', N'ColumnName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'列名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'列名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TableColumn', 
'COLUMN', N'ColumnCaption')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'列标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnCaption'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'列标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnCaption'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TableColumn', 
'COLUMN', N'ColumnDesc')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'列描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnDesc'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'列描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnDesc'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TableColumn', 
'COLUMN', N'ColumnDataType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'列数据类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnDataType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'列数据类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnDataType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TableColumn', 
'COLUMN', N'ColumnType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'列类型：1、普通列；2、权限列'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'列类型：1、普通列；2、权限列'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'ColumnType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TableColumn', 
'COLUMN', N'CreatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'列添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'列添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TableColumn'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
GO

-- ----------------------------
-- Table structure for User
-- ----------------------------
DROP TABLE [dbo].[User]
GO
CREATE TABLE [dbo].[User] (
[Id] int NOT NULL IDENTITY(1,1) ,
[RoleId] int NOT NULL ,
[ShopId] int NOT NULL ,
[Name] varchar(100) NOT NULL ,
[RealName] varchar(100) NULL ,
[Pwd] varchar(50) NOT NULL ,
[Sex] int NULL ,
[Phone] varchar(50) NULL ,
[CreatedDate] datetime NOT NULL DEFAULT (getdate()) ,
[UpdatedDate] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'系统用户'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'系统用户'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'RoleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'RoleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'RoleId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'ShopId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所在商铺Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'ShopId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所在商铺Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'ShopId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户登录名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户登录名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'RealName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户真实姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'RealName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户真实姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'RealName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'Pwd')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'登录密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Pwd'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'登录密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Pwd'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'Sex')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'性别：1、男;2、女;'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Sex'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'性别：1、男;2、女;'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Sex'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'Phone')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Phone'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'联系电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Phone'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'CreatedDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'CreatedDate'
GO
-- ----------------------------
-- Procedure structure for uspAddCategory
-- ----------------------------
DROP PROCEDURE [dbo].[uspAddCategory]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-10-27
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[uspAddCategory]
	@CategoryParentId int 
	,@CategoryStatus int
	,@CategoryName varchar(100)
	,@CategoryDesc varchar(500)
AS
BEGIN
	
	SET NOCOUNT ON;
	IF @CategoryParentId is NULL
			set @CategoryParentId = 0;
	IF @CategoryStatus is NULL
			set @CategoryStatus = 1;
	-- 查找最大的排序号
	declare @CategoryOrder int;
	select 
		@CategoryOrder = max([Order])+1
	from Category
	where 
		ParentId = @CategoryParentId;
	if @CategoryOrder is null
			set @CategoryOrder = 1;
    -- Insert statements for procedure here
	INSERT INTO [Category]
           ([ParentId]
           ,[Status]
           ,[Order]
           ,[Name]
           ,[Desc])
     VALUES
           (
			@CategoryParentId
			,@CategoryStatus
			,@CategoryOrder
			,@CategoryName
			,@CategoryDesc);
END


GO

-- ----------------------------
-- Procedure structure for uspAddOperateLog
-- ----------------------------
DROP PROCEDURE [dbo].[uspAddOperateLog]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	记录用户操作日志
-- =============================================
CREATE PROCEDURE [dbo].[uspAddOperateLog]
	@OperateLogUserId int -- 当前用户Id
	,@OperateLogShopId int -- 用户所在店铺Id
	,@OperateLogType int -- 操作类型：1、新增；2、修改；3、删除
	,@OperateLogDesc varchar(1024) -- 操作描述
	,@OperateLogOperator varchar(100) -- 操作用户
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   INSERT INTO [OperateLog](
        [UserId]
        ,[ShopId]
        ,[Type]
        ,[Desc]
        ,[Operator]
    ) VALUES (
        @OperateLogUserId
        ,@OperateLogShopId
        ,@OperateLogType
        ,@OperateLogDesc
        ,@OperateLogOperator
    )
END



GO

-- ----------------------------
-- Procedure structure for uspAddPayType
-- ----------------------------
DROP PROCEDURE [dbo].[uspAddPayType]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	新增付款类型
-- =============================================
CREATE PROCEDURE [dbo].[uspAddPayType]
	@PayTypeName  varchar(255) -- 付款方式名称
	,@PayTypeBankCharge DECIMAL(8,2) -- 银行手续费
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [PayType](
				[Name]
				,[BankCharge]
    ) VALUES (
				@PayTypeName
				,@PayTypeBankCharge
    );
END
GO

-- ----------------------------
-- Procedure structure for uspAddPurchaseGoods
-- ----------------------------
DROP PROCEDURE [dbo].[uspAddPurchaseGoods]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	购进货品
-- =============================================
CREATE PROCEDURE [dbo].[uspAddPurchaseGoods]
		@PurchaseRecordUserId int
		,@PurchaseRecordPayType int
		,@PurchaseRecordRemark varchar(2048)
		,@PurchaseRecordOperator varchar(100)
		,@GoodsCategoryId int -- 所属分类Id
		,@GoodsSupplierId int -- 供应商Id
		--,@GoodsCode varchar(50) -- 商品编码
		,@GoodsOriginalCode varchar(50) -- 原厂编码
		,@GoodsSourceType int -- 来源类型：寄售：1，进货自有：2
		,@GoodsName varchar(255) -- 商品名称
		--,@GoodsStatus int -- 货品状态：1、在库；2、预定；3、售出；4、取回；
		,@GoodsImage varchar(max) -- 货品图片
		,@GoodsColor varchar(100) -- 货品颜色
		,@GoodsQuality varchar(100) -- 货品成色
		,@GoodsParts varchar(100) -- 货品配件
		,@GoodsMarkPrice decimal(8, 2) -- 货品标价
		,@GoodsPrimePrice decimal(8, 2) -- 进货价格
		,@GoodsPaid INT --商品是否已打款：1：已打款；2、未打款
		--,@GoodsSalePrice decimal(8, 2) -- 售出价格
		--,@GoodsPrepay decimal(8, 2) -- 预付款
		--,@GoodsDiscount decimal(8, 2) -- 折扣金额
		,@GoodsDesc varchar(1024) -- 货品描述
		,@GoodsConsignStartDate datetime -- 寄售开始时间
		,@GoodsConsignEndDate datetime -- 寄售结束时间
		--,@GoodsCreatedDate datetime -- 创建时间
		--,@GoodsSaledDate datetime -- 售出时间
		--,@GoodsUpdatedDate datetime -- 最近一次更新时间，进出货记录的更新也算在这个字段里
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @GoodsOrder INT;
	SELECT @GoodsOrder = count(0)+1 
	FROM [Goods]
	WHERE
		[Goods].[CreatedDate] BETWEEN CONVERT(VARCHAR(100), GETDATE(),23) AND CONVERT(VARCHAR(100), DATEADD(DAY, 1, GETDATE()),23)

	DECLARE @GoodsCode varchar(50);
	IF @GoodsSourceType = 1 -- 寄售商品
		BEGIN
			SET @GoodsCode = 'JS' + CONVERT(VARCHAR(100), GETDATE(),112) + [dbo].[FunPadLeft](@GoodsOrder,'0',3);
		END
	ELSE IF @GoodsSourceType = 2 -- 进货商品
		BEGIN
			SET @GoodsCode = 'ZY' + CONVERT(VARCHAR(100), GETDATE(),112) + [dbo].[FunPadLeft](@GoodsOrder,'0',3);
		END

	BEGIN TRANSACTION -- 开始事务
	declare @GoodsId int;
	INSERT INTO [Goods](
        [CategoryId]
        ,[SupplierId]
        ,[Code]
        ,[OriginalCode]
        ,[SourceType]
        ,[Name]
        ,[Status]
        ,[Image]
        ,[Color]
        ,[Quality]
        ,[Parts]
        ,[MarkPrice]
        ,[PrimePrice]
        --,[SalePrice]
        --,[Prepay]
        --,[Discount]
        ,[Desc]
				,[Paid]
				,[ConsignStartDate]
				,[ConsignEndDate]
    ) VALUES (
        @GoodsCategoryId
        ,@GoodsSupplierId
        ,@GoodsCode
        ,@GoodsOriginalCode
        ,@GoodsSourceType
        ,@GoodsName
        ,1
        ,@GoodsImage
        ,@GoodsColor
        ,@GoodsQuality
        ,@GoodsParts
        ,@GoodsMarkPrice
        ,@GoodsPrimePrice
        --,@GoodsSalePrice
        --,@GoodsPrepay
        --,@GoodsDiscount
        ,@GoodsDesc
        --,@GoodsCreatedDate
        --,@GoodsSaledDate
        --,@GoodsUpdatedDate
				,case WHEN @GoodsPaid IS NULL THEN 1 ELSE @GoodsPaid END
				,@GoodsConsignStartDate
				,@GoodsConsignEndDate
    )
    if @@ERROR<>0
		begin
			rollback tran;
		end
	-- 获取当前插入货品的Id
    SELECT @GoodsId = SCOPE_IDENTITY(); 
    
    -- 增加进货记录
    INSERT INTO [PurchaseRecord](
        [UserId]
        ,[GoodsId]
        ,[PayType]
        ,[Remark]
        ,[Operator]
    ) VALUES (
        @PurchaseRecordUserId
        ,@GoodsId
        ,@PurchaseRecordPayType
        ,@PurchaseRecordRemark
        ,@PurchaseRecordOperator
    )
    if @@ERROR <> 0
		begin
			rollback tran;
		end
	
		SELECT 
			[Goods].[Id] as GoodsId
			,[Goods].[CategoryId] as GoodsCategoryId
			,[Goods].[SupplierId] as GoodsSupplierId
			,[Goods].[Code] as GoodsCode
			,[Goods].[OriginalCode] as GoodsOriginalCode
			,[Goods].[SourceType] as GoodsSourceType
			,[Goods].[Name] as GoodsName
			,[Goods].[Status] as GoodsStatus
			,[Goods].[Image] as GoodsImage
			,[Goods].[Color] as GoodsColor
			,[Goods].[Quality] as GoodsQuality
			,[Goods].[Parts] as GoodsParts
			,[Goods].[MarkPrice] as GoodsMarkPrice
			,[Goods].[PrimePrice] as GoodsPrimePrice
			,ISNULL([Goods].[SalePrice],[Goods].[MarkPrice]) as GoodsSalePrice
			,[Goods].[Prepay] as GoodsPrepay
			,[Goods].[Discount] as GoodsDiscount
			,[Goods].[Desc] as GoodsDesc
			,[Goods].[Paid] as GoodsPaid
			,[Goods].[CreatedDate] as GoodsCreatedDate
			,[Goods].[SaledDate] as GoodsSaledDate
			,[Goods].[ConsignStartDate] as GoodsConsignStartData
			,[Goods].[ConsignEndDate] as GoodsConsignEndDate
			,[Goods].[UpdatedDate] as GoodsUpdatedDate
			,[PurchaseRecord].[Id] as PurchaseRecordId
			,[PurchaseRecord].[UserId] as PurchaseRecordUserId
			,[PurchaseRecord].[PayType] as PurchaseRecordPayType
			,[PurchaseRecord].[Remark] as PurchaseRecordRemark
			,[PurchaseRecord].[Operator] as PurchaseRecordOperator
  FROM [Goods] 
  left join [PurchaseRecord] on [Goods].[Id] = [PurchaseRecord].[GoodsId]
  WHERE 
		[Goods].[Id] = @GoodsId;

    commit transaction; --所有語句都執行完成，提交事務
END



GO

-- ----------------------------
-- Procedure structure for uspAddRole
-- ----------------------------
DROP PROCEDURE [dbo].[uspAddRole]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	新增用户角色
-- =============================================
CREATE PROCEDURE [dbo].[uspAddRole] 
	@RoleName varchar(100) -- 角色名称
 ,@RoleDesc varchar(500) -- 角色描述
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [Role](
        [Name]
        ,[Desc]
    ) VALUES (
        @RoleName
        ,@RoleDesc
    )
END



GO

-- ----------------------------
-- Procedure structure for uspAddSaledGoods
-- ----------------------------
DROP PROCEDURE [dbo].[uspAddSaledGoods]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	货品预定或售出
-- =============================================
CREATE PROCEDURE [dbo].[uspAddSaledGoods] 
		@SaledRecordUserId int -- 当前登录用户名
		,@SaledRecordPayType int -- 付款方式：1、现金；2、汇款；3、信用卡；4、网银转帐；
		,@SaledRecordRemark varchar(2048) -- 
		,@SaledRecordOperator varchar(100) -- 经手人
		,@SaledRecordCustomerName varchar(100) -- 顾客姓名
    ,@SaledRecordCustomerPhone varchar(50) -- 顾客联系方式
		,@GoodsId int -- 货品Id
		,@GoodsStatus int -- 货品状态：1、在库；2、预定；3、售出；4、取回；
		,@GoodsSalePrice decimal(8, 2) -- 售出价格
		,@GoodsPrepay decimal(8, 2) -- 预付款
		,@GoodsDiscount decimal(8, 2) -- 折扣金额
		,@GoodsPaid INT = 2 --商品是否已打款：1：已打款；2、未打款
		,@GoodsSaledDate datetime -- 售出时间
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	begin tran
		-- 取回的商品，salePrice 一定是进货价格的负数
		IF @GoodsStatus = 4 
			BEGIN
				SELECT @GoodsSalePrice = (-[Goods].[SalePrice]) 
				FROM [Goods]
				WHERE
					[Goods].[Id] = @GoodsId;
			END
		-- 更新商品状态
		update Goods set 
			[Goods].[Status] = case when @GoodsStatus is null then [Goods].[Status] else @GoodsStatus end
			,[Goods].[SalePrice] = case when @GoodsSalePrice is null then [Goods].[SalePrice] else @GoodsSalePrice end
			,[Goods].[Prepay] = case when @GoodsPrepay is null then [Goods].[Prepay] else @GoodsPrepay end
			,[Goods].[Discount] = case when @GoodsDiscount is null then [Goods].[Discount] else @GoodsDiscount end
			,[Goods].[SaledDate] = case when [Goods].[SaledDate] is null then GETDATE() else [Goods].[SaledDate] end
			,[Goods].[Paid] = CASE WHEN @GoodsPaid is NULL THEN [Goods].[Paid] ELSE @GoodsPaid end
			,[Goods].[UpdatedDate] = GETDATE()
		where 
			[Goods].[Id] = @GoodsId;
		
		if @@ERROR <>0
			begin 
				rollback tran;
			end
		
		
		 -- 添加货品销售记录
		INSERT INTO [SaledRecord](
        [UserId]
        ,[GoodsId]
        ,[PayType]
        ,[Remark]
				,[CustomerName]
        ,[CustomerPhone]
        ,[Operator]
    ) VALUES (
        @SaledRecordUserId
        ,@GoodsId
        ,@SaledRecordPayType
        ,@SaledRecordRemark
				,@SaledRecordCustomerName
        ,@SaledRecordCustomerPhone
        ,@SaledRecordOperator
    )
		if @@ERROR <> 0
			begin
				rollback tran;
			end
	commit tran;
	
END



GO

-- ----------------------------
-- Procedure structure for uspAddShop
-- ----------------------------
DROP PROCEDURE [dbo].[uspAddShop]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	新增店铺
-- =============================================
CREATE PROCEDURE [dbo].[uspAddShop] 
        @ShopName varchar(100) -- 店铺名称
        ,@ShopPhone varchar(20) -- 联系电话
        ,@ShopAddress varchar(200) -- 店铺地址
        ,@ShopDesc varchar(500) -- 店铺描述
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO [Shop](
		[Name]
		,[Phone]
		,[Address]
		,[Desc]
	) VALUES (
		@ShopName
		,@ShopPhone
		,@ShopAddress
		,@ShopDesc
	)
END



GO

-- ----------------------------
-- Procedure structure for uspAddSupplier
-- ----------------------------
DROP PROCEDURE [dbo].[uspAddSupplier]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	新增供货商
-- =============================================
CREATE PROCEDURE [dbo].[uspAddSupplier] 
	@SupplierName varchar(10)
	,@SupplierSex int
	,@SupplierPhone varchar(50)
	,@SupplierBankName varchar(200)
	,@SupplierBankCard varchar(50)
	,@SupplierIdCard varchar(50)
	,@SupplierAddress varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if exists (select Id from Supplier where [Phone] = @SupplierPhone)
		begin
			UPDATE [Supplier]
			SET
				[Supplier].[Name] = case when @SupplierName is null then [Supplier].[Name] else @SupplierName end
				,[Supplier].[Sex] = case when @SupplierSex is null then [Supplier].[Sex] else @SupplierSex end
				,[Supplier].[BankName] = case when @SupplierBankName is null then [Supplier].[BankName] else @SupplierBankName end
				,[Supplier].[BankCard] = case when @SupplierBankCard is null then [Supplier].[BankCard] else @SupplierBankCard end
				,[Supplier].[IdCard] = case when @SupplierIdCard is null then [Supplier].[IdCard] else @SupplierIdCard end
				,[Supplier].[Address] = case when @SupplierAddress is null then [Supplier].[Address] else @SupplierAddress end
				,[Supplier].[UpdatedDate] = GETDATE()
			WHERE
				[Phone] = @SupplierPhone;
		end
	else 
		begin 
		INSERT INTO [Supplier](
			[Name]
			,[Sex]
			,[Phone]
			,[BankName]
			,[BankCard]
			,[IdCard]
			,[Address]
		) VALUES (
			@SupplierName
			,@SupplierSex
			,@SupplierPhone
			,@SupplierBankName
			,@SupplierBankCard
			,@SupplierIdCard
			,@SupplierAddress
		)
		end
		
END



GO

-- ----------------------------
-- Procedure structure for uspAddUser
-- ----------------------------
DROP PROCEDURE [dbo].[uspAddUser]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	新增用户
-- =============================================
CREATE PROCEDURE [dbo].[uspAddUser] 
		@UserRoleId int -- 角色Id
		,@UserShopId int -- 所在商铺Id
		,@UserName varchar(100) -- 用户登录名
		,@UserRealName varchar(100) -- 用户真实姓名
		,@UserPwd varchar(50) -- 登录密码
		,@UserSex int -- 性别：1、男;2、女;
		,@UserPhone varchar(50) -- 联系电话
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		INSERT INTO [User](
        [RoleId]
        ,[ShopId]
        ,[Name]
        ,[RealName]
        ,[Pwd]
        ,[Sex]
        ,[Phone]
    ) VALUES (
        @UserRoleId
        ,@UserShopId
        ,@UserName
        ,@UserRealName
        ,@UserPwd
        ,@UserSex
        ,@UserPhone
    )
END



GO

-- ----------------------------
-- Procedure structure for uspGetCategories
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetCategories]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	获取商品分类 默认可用
-- =============================================
CREATE PROCEDURE [dbo].[uspGetCategories]
	@CategoryStatus  int = 0 --0:全部 1:可用 2：停用
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 SELECT 
        [Category].[Id] as CategoryId
        ,[Category].[ParentId] as CategoryParentId
        ,[Category].[Status] as CategoryStatus
        ,[Category].[Order] as CategoryOrder
        ,[Category].[Name] as CategoryName
        ,[Category].[Desc] as CategoryDesc
        ,[Category].[CreatedDate] as CategoryCreatedDate
        ,[Category].[UpdatedDate] as CategoryUpdatedDate
    FROM
        [Category]
    WHERE
	[Category].[Status] = case when @CategoryStatus = 0 then [Category].[Status] else @CategoryStatus end;
END



GO

-- ----------------------------
-- Procedure structure for uspGetGoodses
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetGoodses]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	获取商品信息
-- =============================================
CREATE PROCEDURE [dbo].[uspGetGoodses]
	@GoodsCategoryId int
	--,@SupplierPhone varchar(20)
	,@GoodsName varchar(255)
	,@GoodsCode varchar(50)
	,@GoodsStatus int
	,@GoodsSourceType int
	,@GoodsPaid INT  --商品是否已打款：1：已打款；2、未打款
	,@StartPurchaseDate datetime
	,@EndPurchaseDate datetime
	,@StartSaledDate datetime
	,@EndSaledDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--declare @sql as varchar(max);
	--set @sql = N'
		SELECT 
			[Goods].[Id] as GoodsId
			,[Goods].[CategoryId] as GoodsCategoryId
			,[Goods].[SupplierId] as GoodsSupplierId
			,[Goods].[Code] as GoodsCode
			,[Goods].[OriginalCode] as GoodsOriginalCode
			,[Goods].[SourceType] as GoodsSourceType
			,[Goods].[Name] as GoodsName
			,[Goods].[Status] as GoodsStatus
			,[Goods].[Image] as GoodsImage
			,[Goods].[Color] as GoodsColor
			,[Goods].[Quality] as GoodsQuality
			,[Goods].[Parts] as GoodsParts
			,[Goods].[MarkPrice] as GoodsMarkPrice
			,[Goods].[PrimePrice] as GoodsPrimePrice
			,[Goods].[SalePrice] as GoodsSalePrice
			,[Goods].[Prepay] as GoodsPrepay
			,[Goods].[Discount] as GoodsDiscount
			,[Goods].[Desc] as GoodsDesc
			,[Goods].[Paid] as GoodsPaid
			,[Goods].[CreatedDate] as GoodsCreatedDate
			,[Goods].[SaledDate] as GoodsSaledDate
			,[Goods].[ConsignStartDate] as GoodsConsignStartData
			,[Goods].[ConsignEndDate] as GoodsConsignEndDate
			,[Goods].[UpdatedDate] as GoodsUpdatedDate
			,[PurchaseRecord].[Id] as PurchaseRecordId
			,[PurchaseRecord].[UserId] as PurchaseRecordUserId
			,[PurchaseRecord].[PayType] as PurchaseRecordPayType
			,[PurchaseRecord].[Remark] as PurchaseRecordRemark
			,[PurchaseRecord].[Operator] as PurchaseRecordOperator
			,ISNULL([SaledRecord].[Id],0) as SaledRecordId
			,ISNULL([SaledRecord].[GoodsId],0) as SaledRecordGoodsId
			,ISNULL([SaledRecord].[UserId],0) as SaledRecordUserId
			,ISNULL([SaledRecord].[PayType],0) as SaledRecordPayType
			,[SaledRecord].[Remark] as SaledRecordRemark
			,[SaledRecord].[CustomerName] as SaledRecordCustomerName
      ,[SaledRecord].[CustomerPhone] as SaledRecordCustomerPhone
			,[SaledRecord].[Operator] as SaledRecordOperator
  FROM [Goods] 
  left join [PurchaseRecord] on [Goods].[Id] = [PurchaseRecord].[GoodsId] 
  left join [SaledRecord] on [Goods].[Id] = [SaledRecord].[GoodsId]
  WHERE 
		[Goods].[CategoryId] = CASE WHEN @GoodsCategoryId is NULL THEN [Goods].[CategoryId] ELSE @GoodsCategoryId END
		--AND [Supplier].[Phone] = CASE WHEN @SupplierPhone is NULL THEN [Supplier].[Phone] ELSE @SupplierPhone END
		AND [Goods].[Name] LIKE '%' +  CASE WHEN @GoodsName is NULL THEN [Goods].[Name] ELSE @GoodsName END + '%'
		AND [Goods].[Code] LIKE '%' + CASE WHEN @GoodsCode is NULL THEN [Goods].[Code] ELSE @GoodsCode END + '%'
		AND [Goods].[Status] = CASE WHEN @GoodsStatus is NULL THEN [Goods].[Status] ELSE @GoodsStatus END
		--AND [Goods].[Paid] = CASE WHEN @GoodsPaid is NULL THEN [Goods].[Paid] ELSE @GoodsPaid END
		AND [Goods].[SourceType] = CASE WHEN @GoodsSourceType is NULL THEN [Goods].[SourceType] ELSE @GoodsSourceType END
		AND ([Goods].[CreatedDate] >= CASE WHEN @StartPurchaseDate is NULL THEN [Goods].[CreatedDate] ELSE CONVERT(varchar(100),  @StartPurchaseDate, 23) END
				AND [Goods].[CreatedDate] <= CASE WHEN @EndPurchaseDate is NULL THEN [Goods].[CreatedDate] ELSE CONVERT(varchar(100),DATEADD(DAY, 1, @EndPurchaseDate), 23) END)
		OR ([Goods].[SaledDate] >= CASE WHEN @StartSaledDate is NULL THEN [Goods].[SaledDate] ELSE CONVERT(varchar(100), @StartSaledDate, 23) END
				AND [Goods].[SaledDate] <= CASE WHEN @EndSaledDate is NULL THEN [Goods].[SaledDate] ELSE CONVERT(varchar(100),DATEADD(DAY, 1, @EndSaledDate), 23) END)
		ORDER BY [Goods].[CreatedDate] DESC
END

GO
-- ----------------------------
-- Procedure structure for uspGetGoodsInfos
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetGoodsInfos]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	获取商品信息
-- =============================================
CREATE PROCEDURE [dbo].[uspGetGoodsInfos]
	@GoodsCategoryId int
	--,@SupplierPhone varchar(20)
	,@GoodsName varchar(255)
	,@GoodsCode varchar(50)
	,@GoodsStatus int
	,@GoodsSourceType int
	,@GoodsPaid INT  --商品是否已打款：1：已打款；2、未打款
	,@StartPurchaseDate datetime
	,@EndPurchaseDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--declare @sql as varchar(max);
	--set @sql = N'
		SELECT 
			[Goods].[Id] as GoodsId
			,[Goods].[CategoryId] as GoodsCategoryId
			,[Goods].[SupplierId] as GoodsSupplierId
			,[Goods].[Code] as GoodsCode
			,[Goods].[OriginalCode] as GoodsOriginalCode
			,[Goods].[SourceType] as GoodsSourceType
			,[Goods].[Name] as GoodsName
			,[Goods].[Status] as GoodsStatus
			,[Goods].[Image] as GoodsImage
			,[Goods].[Color] as GoodsColor
			,[Goods].[Quality] as GoodsQuality
			,[Goods].[Parts] as GoodsParts
			,[Goods].[MarkPrice] as GoodsMarkPrice
			,[Goods].[PrimePrice] as GoodsPrimePrice
			,[Goods].[SalePrice] as GoodsSalePrice
			,[Goods].[Prepay] as GoodsPrepay
			,[Goods].[Discount] as GoodsDiscount
			,[Goods].[Desc] as GoodsDesc
			,[Goods].[Paid] as GoodsPaid
			,[Goods].[CreatedDate] as GoodsCreatedDate
			,[Goods].[SaledDate] as GoodsSaledDate
			,[Goods].[ConsignStartDate] as GoodsConsignStartData
			,[Goods].[ConsignEndDate] as GoodsConsignEndDate
			,[Goods].[UpdatedDate] as GoodsUpdatedDate
  FROM [Goods]
  WHERE 
		[Goods].[CategoryId] = CASE WHEN @GoodsCategoryId is NULL THEN [Goods].[CategoryId] ELSE @GoodsCategoryId END
		--AND [Supplier].[Phone] = CASE WHEN @SupplierPhone is NULL THEN [Supplier].[Phone] ELSE @SupplierPhone END
		AND [Goods].[Name] LIKE '%' +  CASE WHEN @GoodsName is NULL THEN [Goods].[Name] ELSE @GoodsName END + '%'
		AND [Goods].[Code] LIKE '%' + CASE WHEN @GoodsCode is NULL THEN [Goods].[Code] ELSE @GoodsCode END + '%'
		-- 1在库，2预定的可以被查出来,3、售出 4、取回
		AND [Goods].[Status] <= CASE WHEN @GoodsStatus is NULL THEN 2 ELSE 4 END
		AND [Goods].[Status] = CASE WHEN @GoodsStatus IS NULL THEN [Goods].[Status] ELSE @GoodsStatus END
		AND [Goods].[Paid] = CASE WHEN @GoodsPaid is NULL THEN [Goods].[Paid] ELSE @GoodsPaid END
		AND [Goods].[SourceType] = CASE WHEN @GoodsSourceType is NULL THEN [Goods].[SourceType] ELSE @GoodsSourceType END
		AND ([Goods].[CreatedDate] >= CASE WHEN @StartPurchaseDate is NULL THEN [Goods].[CreatedDate] ELSE CONVERT(varchar(100), DATEADD(DAY, -1, @StartPurchaseDate) , 23) END
				AND [Goods].[CreatedDate] <= CASE WHEN @EndPurchaseDate is NULL THEN [Goods].[CreatedDate] ELSE CONVERT(varchar(100),DATEADD(DAY, 1, @EndPurchaseDate), 23) END)
		ORDER BY [Goods].[CreatedDate] DESC
	
END

GO

-- ----------------------------
-- Procedure structure for uspGetOperateLogs
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetOperateLogs]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	获取用户操作日志
-- =============================================
CREATE PROCEDURE [dbo].[uspGetOperateLogs]
	@OperateLogUserId int = NULL-- 当前用户Id
	,@OperateLogShopId int = NULL-- 用户所在店铺Id
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 SELECT 
        [OperateLog].[Id] as OperateLogId
        ,[OperateLog].[UserId] as OperateLogUserId
        ,[OperateLog].[ShopId] as OperateLogShopId
        ,[OperateLog].[Type] as OperateLogType
        ,[OperateLog].[Desc] as OperateLogDesc
        ,[OperateLog].[Operator] as OperateLogOperator
        ,[OperateLog].[CreatedDate] as OperateLogCreatedDate
    FROM
        [OperateLog]
    WHERE
			[OperateLog].[UserId] = case when @OperateLogUserId is null then [OperateLog].[UserId] else @OperateLogUserId end
       AND [OperateLog].[ShopId] = case when @OperateLogShopId is null then [OperateLog].[ShopId] else @OperateLogShopId end
        
END



GO

-- ----------------------------
-- Procedure structure for uspGetPayTypes
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetPayTypes]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	获取付款类型
-- =============================================
CREATE PROCEDURE [dbo].[uspGetPayTypes]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 SELECT 
        [PayType].[Id] as PayTypeId
        ,[PayType].[Name] as PayTypeName
				,[PayType].[BankCharge] AS PayTypeBankCharge
        ,[PayType].[CreatedDate] as PayTypeCreatedDate
        ,[PayType].[UpdatedDate] as PayTypeUpdatedDate
    FROM
        [PayType];
END

GO

-- ----------------------------
-- Procedure structure for uspGetRoleColumns
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetRoleColumns]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-12-26
-- Description:	获取角色拥有的权限
-- =============================================
CREATE PROCEDURE [dbo].[uspGetRoleColumns]
	@RoleColumnRoleId int -- 角色Id
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
			[RoleColumn].[Id] as RoleColumnId
			,[RoleColumn].[RoleId] as RoleColumnRoleId
			,[RoleColumn].[ColumnIds] as RoleColumnColumnIds
			,[RoleColumn].[UpdatedDate] as RoleColumnUpdatedDate
	FROM
			[RoleColumn]
	WHERE
			[RoleColumn].[RoleId] = case when @RoleColumnRoleId is null then [RoleColumn].[RoleId] else @RoleColumnRoleId end
END



GO

-- ----------------------------
-- Procedure structure for uspGetRoles
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetRoles]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-12-09
-- Description:	获取店铺列表
-- =============================================
CREATE PROCEDURE [dbo].[uspGetRoles] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
        [Role].[Id] as RoleId
        ,[Role].[Name] as RoleName
        ,[Role].[Desc] as RoleDesc
				,[RoleColumn].[ColumnIds] as RoleColumnIds
        ,[Role].[CreatedDate] as RoleCreatedDate
        ,[Role].[UpdatedDate] as RoleUpdatedDate
    FROM
        [Role]
				LEFT JOIN [RoleColumn] ON [Role].[Id] = [RoleColumn].[RoleId]
END



GO

-- ----------------------------
-- Procedure structure for uspGetShops
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetShops]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-04
-- Description:	获取店铺列表
-- =============================================
CREATE PROCEDURE [dbo].[uspGetShops] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
        [Shop].[Id] as ShopId
        ,[Shop].[Name] as ShopName
        ,[Shop].[Phone] as ShopPhone
        ,[Shop].[Address] as ShopAddress
        ,[Shop].[Desc] as ShopDesc
        ,[Shop].[CreatedDate] as ShopCreatedDate
        ,[Shop].[UpdatedDate] as ShopUpdatedDate
    FROM
        [Shop]
END



GO

-- ----------------------------
-- Procedure structure for uspGetSuppliers
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetSuppliers]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-04
-- Description:	获取供应商信息
-- =============================================
CREATE PROCEDURE [dbo].[uspGetSuppliers] 
	@SupplierPhone varchar(50) = NULL-- 联系电话
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
        [Supplier].[Id] as SupplierId
        ,[Supplier].[Name] as SupplierName
        ,[Supplier].[Sex] as SupplierSex
        ,[Supplier].[Phone] as SupplierPhone
        ,[Supplier].[BankName] as SupplierBankName
        ,[Supplier].[BankCard] as SupplierBankCard
        ,[Supplier].[IdCard] as SupplierIdCard
        ,[Supplier].[Address] as SupplierAddress
        ,[Supplier].[CreatedDate] as SupplierCreatedDate
        ,[Supplier].[UpdatedDate] as SupplierUpdatedDate
    FROM
        [Supplier]
    WHERE
				[Supplier].[Phone] like '%'+ case when @SupplierPhone is null then [Supplier].[Phone] else @SupplierPhone end +'%'
END



GO

-- ----------------------------
-- Procedure structure for uspGetTableColumns
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetTableColumns]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-12-26
-- Description:	获取所有受权限控制的列
-- =============================================
CREATE PROCEDURE [dbo].[uspGetTableColumns]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT 
        [TableColumn].[Id] as TableColumnId
        ,[TableColumn].[TableName] as TableColumnTableName
        --,[TableColumn].[TableDesc] as TableColumnTableDesc
        ,[TableColumn].[ColumnName] as TableColumnColumnName
        ,[TableColumn].[ColumnCaption] as TableColumnColumnCaption
        ,[TableColumn].[ColumnDesc] as TableColumnColumnDesc
        --,[TableColumn].[ColumnType] as TableColumnColumnType
        --,[TableColumn].[ColumnStatus] as TableColumnColumnStatus
        --,[TableColumn].[CreatedDate] as TableColumnCreatedDate
    FROM
        [TableColumn]
		WHERE
				[TableColumn].[ColumnType] = 2; -- 2与权限相关的列
END


GO

-- ----------------------------
-- Procedure structure for uspGetWarningGoodsMsg
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetWarningGoodsMsg]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2014-1-3
-- Description:	获取商品预警信息
-- =============================================
CREATE PROCEDURE [dbo].[uspGetWarningGoodsMsg]
	@WarningType int--1:售出预警 2、寄售预警
	,@WarningDays int -- 预警时间：寄售商品快到期提前多少天预警；售出商品后多少天预警
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--declare @sql as varchar(max);
	--set @sql = N'
		SET @WarningType = CASE WHEN @WarningType IS NULL THEN 2 ELSE @WarningType END;
		SET @WarningDays = CASE WHEN @WarningDays IS NULL THEN 7 ELSE @WarningDays END;

		SELECT 
		COUNT(0) as GoodsCount
		,CASE WHEN @WarningType = 1 THEN MAX([Goods].[SaledDate]) ELSE MAX([Goods].[ConsignEndDate]) end as MaxDate
		,CASE WHEN @WarningType = 1 THEN MIN([Goods].[SaledDate]) ELSE MIN([Goods].[ConsignEndDate]) end as MinDate
			
  FROM [Goods]
  WHERE 
		-- 售出未付款预警
		-- 1在库，2预定,3、售出 4、取回
		[Goods].[Status] = CASE WHEN @WarningType = 1 THEN 3 ELSE 1 END
		--1:未打款 2：已打款
		AND [Goods].[Paid] = CASE WHEN @WarningType = 1 THEN 1 ELSE [Goods].[Paid] END
		AND GETDATE() >= CASE WHEN @WarningType = 1 THEN CONVERT(varchar(100),DATEADD(DAY, -@WarningDays, [Goods].[SaledDate]), 23) ELSE GETDATE() END 

		-- 寄售到期 预警
		AND LEFT([Goods].[Code],2) = CASE WHEN @WarningType = 2 THEN 'JS' ELSE LEFT([Goods].[Code],2) END
		AND GETDATE() >= CASE WHEN @WarningType = 2 THEN CONVERT(varchar(100),DATEADD(DAY, -@WarningDays, [Goods].[ConsignEndDate]), 23) ELSE GETDATE() END 
		AND GETDATE() <= CASE WHEN @WarningType = 2 THEN CONVERT(varchar(100),DATEADD(DAY, 1, [Goods].[ConsignEndDate]),23) ELSE GETDATE() END
		--ORDER BY  
		--	CASE WHEN @WarningType = 2 THEN [Goods].[ConsignEndDate] ELSE [Goods].[SaledDate] END
	
END

GO

-- ----------------------------
-- Procedure structure for uspGetWarningGoods
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetWarningGoods]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2014-1-2
-- Description:	获取商品预警信息
-- =============================================
CREATE PROCEDURE [dbo].[uspGetWarningGoods]
	@WarningType int--1:售出预警 2、寄售预警
	,@WarningDays int -- 预警时间：寄售商品快到期提前多少天预警；售出商品后多少天预警
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--declare @sql as varchar(max);
	--set @sql = N'
		SET @WarningType = CASE WHEN @WarningType IS NULL THEN 2 ELSE @WarningType END;
		SET @WarningDays = CASE WHEN @WarningDays IS NULL THEN 7 ELSE @WarningDays END;

		SELECT 
			[Goods].[Id] as GoodsId
			,[Goods].[CategoryId] as GoodsCategoryId
			,[Goods].[SupplierId] as GoodsSupplierId
			,[Goods].[Code] as GoodsCode
			,[Goods].[OriginalCode] as GoodsOriginalCode
			,[Goods].[SourceType] as GoodsSourceType
			,[Goods].[Name] as GoodsName
			,[Goods].[Status] as GoodsStatus
			,[Goods].[Image] as GoodsImage
			,[Goods].[Color] as GoodsColor
			,[Goods].[Quality] as GoodsQuality
			,[Goods].[Parts] as GoodsParts
			,[Goods].[MarkPrice] as GoodsMarkPrice
			,[Goods].[PrimePrice] as GoodsPrimePrice
			,[Goods].[SalePrice] as GoodsSalePrice
			,[Goods].[Prepay] as GoodsPrepay
			,[Goods].[Discount] as GoodsDiscount
			,[Goods].[Desc] as GoodsDesc
			,[Goods].[Paid] as GoodsPaid
			,[Goods].[CreatedDate] as GoodsCreatedDate
			,[Goods].[SaledDate] as GoodsSaledDate
			,[Goods].[ConsignStartDate] as GoodsConsignStartData
			,[Goods].[ConsignEndDate] as GoodsConsignEndDate
			,[Goods].[UpdatedDate] as GoodsUpdatedDate
			,[PurchaseRecord].[Id] as PurchaseRecordId
			,[PurchaseRecord].[UserId] as PurchaseRecordUserId
			,[PurchaseRecord].[PayType] as PurchaseRecordPayType
			,[PurchaseRecord].[Remark] as PurchaseRecordRemark
			,[PurchaseRecord].[Operator] as PurchaseRecordOperator
			,ISNULL([SaledRecord].[Id],0) as SaledRecordId
			,ISNULL([SaledRecord].[GoodsId],0) as SaledRecordGoodsId
			,ISNULL([SaledRecord].[UserId],0) as SaledRecordUserId
			,ISNULL([SaledRecord].[PayType],0) as SaledRecordPayType
			,[SaledRecord].[Remark] as SaledRecordRemark
			,[SaledRecord].[CustomerName] as SaledRecordCustomerName
      ,[SaledRecord].[CustomerPhone] as SaledRecordCustomerPhone
			,[SaledRecord].[Operator] as SaledRecordOperator
  FROM [Goods]
			left join [PurchaseRecord] on [Goods].[Id] = [PurchaseRecord].[GoodsId] 
			left join [SaledRecord] on [Goods].[Id] = [SaledRecord].[GoodsId]
  WHERE 
		-- 售出未付款预警
		-- 1在库，2预定,3、售出 4、取回
		[Goods].[Status] = CASE WHEN @WarningType = 1 THEN 3 ELSE 1 END
		--1:未打款 2：已打款
		AND [Goods].[Paid] = CASE WHEN @WarningType = 1 THEN 1 ELSE [Goods].[Paid] END
		AND GETDATE() >= CASE WHEN @WarningType = 1 THEN CONVERT(varchar(100),DATEADD(DAY, -@WarningDays, [Goods].[SaledDate]), 23) ELSE GETDATE() END 

		-- 寄售到期 预警
		AND LEFT([Goods].[Code],2) = CASE WHEN @WarningType = 2 THEN 'JS' ELSE LEFT([Goods].[Code],2) END
		AND GETDATE() >= CASE WHEN @WarningType = 2 THEN CONVERT(varchar(100),DATEADD(DAY, -@WarningDays, [Goods].[ConsignEndDate]), 23) ELSE GETDATE() END 
		AND GETDATE() <= CASE WHEN @WarningType = 2 THEN CONVERT(varchar(100),DATEADD(DAY, 1, [Goods].[ConsignEndDate]),23) ELSE GETDATE() END
		ORDER BY  
			CASE WHEN @WarningType = 2 THEN [Goods].[ConsignEndDate] ELSE [Goods].[SaledDate] END
	
END

GO

-- ----------------------------
-- Procedure structure for uspGetUserByName
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetUserByName]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-04
-- Description:	获取用户信息
-- =============================================
CREATE PROCEDURE [dbo].[uspGetUserByName]
	@UserName varchar(100)
	,@UserPwd	varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
        [User].[Id] as UserId
        ,[User].[RoleId] as UserRoleId
        ,[User].[ShopId] as UserShopId
        ,[User].[Name] as UserName
        ,[User].[RealName] as UserRealName
        ,[User].[Pwd] as UserPwd
        ,[User].[Sex] as UserSex
        ,[User].[Phone] as UserPhone
        ,[User].[CreatedDate] as UserCreatedDate
        ,[User].[UpdatedDate] as UserUpdatedDate
    FROM
        [User]
    WHERE
			[User].[Name] = @UserName And [User].[Pwd] = @UserPwd;
END



GO

-- ----------------------------
-- Procedure structure for uspGetUsers
-- ----------------------------
DROP PROCEDURE [dbo].[uspGetUsers]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-04
-- Description:	获取用户信息
-- =============================================
CREATE PROCEDURE [dbo].[uspGetUsers]
	--@UserId int -- 用户Id
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
        [User].[Id] as UserId
        ,[User].[RoleId] as UserRoleId
        ,[User].[ShopId] as UserShopId
        ,[User].[Name] as UserName
        ,[User].[RealName] as UserRealName
        ,[User].[Pwd] as UserPwd
        ,[User].[Sex] as UserSex
        ,[User].[Phone] as UserPhone
        ,[User].[CreatedDate] as UserCreatedDate
        ,[User].[UpdatedDate] as UserUpdatedDate
    FROM
        [User]
    WHERE
				[User].[RoleId] != 1;--系统管理员角色
END



GO

-- ----------------------------
-- Procedure structure for uspUpdateCategory
-- ----------------------------
DROP PROCEDURE [dbo].[uspUpdateCategory]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	更新商品类别信息
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateCategory] 
	@CategoryId int
        ,@CategoryParentId int
        ,@CategoryStatus int
        ,@CategoryName varchar(100)
        ,@CategoryDesc varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [Category]
    SET
        [Category].[ParentId] = case when @CategoryParentId is null then [Category].[ParentId] else @CategoryParentId end
        ,[Category].[Status] = case when @CategoryStatus is null then [Category].[Status] else @CategoryStatus end
        ,[Category].[Name] = case when @CategoryName is null then [Category].[Name] else @CategoryName end
        ,[Category].[Desc] = case when @CategoryDesc is null then [Category].[Desc] else @CategoryDesc end
        ,[Category].[UpdatedDate] = GETDATE()
	 WHERE Id = @CategoryId
END



GO

-- ----------------------------
-- Procedure structure for uspUpdatePayType
-- ----------------------------
DROP PROCEDURE [dbo].[uspUpdatePayType]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	更新付款类型
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdatePayType]
	@PayTypeId int -- Id
	,@PayTypeName varchar(255) -- 付款方式名称
	,@PayTypeBankCharge DECIMAL(8,2) -- 银行手续费
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 UPDATE [PayType]
    SET
        [PayType].[Name] = case when @PayTypeName is null then [PayType].[Name] else @PayTypeName end
				,[PayType].[BankCharge] = CASE WHEN @PayTypeBankCharge is null THEN [PayType].[BankCharge] ELSE @PayTypeBankCharge END
				,[PayType].[UpdatedDate] = GETDATE()
        
    WHERE
        [PayType].[Id]=@PayTypeId
END

GO

-- ----------------------------
-- Procedure structure for uspUpdatePurchaseGoods
-- ----------------------------
DROP PROCEDURE [dbo].[uspUpdatePurchaseGoods]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-30
-- Description:	修改进货商品及进货记录信息
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdatePurchaseGoods]
    @PurchaseRecordUserId int -- 当前用户Id
    ,@PurchaseRecordPayType int -- 付款方式：1、现金；2、汇款；3、信用卡；4、网银转帐；
    ,@PurchaseRecordRemark varchar(2048) -- 
    ,@PurchaseRecordOperator varchar(100) -- 经手人
	
		,@GoodsId int -- 货品Id
    ,@GoodsCategoryId int -- 所属分类Id
    ,@GoodsSupplierId int -- 供应商Id
    --,@GoodsCode varchar(50) -- 商品编码
    ,@GoodsOriginalCode varchar(50) -- 原厂编码
    ,@GoodsSourceType int -- 来源类型：寄售：1，进货自有：2
    ,@GoodsName varchar(255) -- 商品名称
    ,@GoodsStatus int -- 货品状态：1、在库；2、预定；3、售出；4、取回；
    ,@GoodsImage varchar(max) -- 货品图片
    ,@GoodsColor varchar(100) -- 货品颜色
    ,@GoodsQuality varchar(100) -- 货品成色
    ,@GoodsParts varchar(100) -- 货品配件
    ,@GoodsMarkPrice decimal(8, 2) -- 货品标价
    ,@GoodsPrimePrice decimal(8, 2) -- 进货价格
    ,@GoodsSalePrice decimal(8, 2) -- 售出价格
    ,@GoodsPrepay decimal(8, 2) -- 预付款
    ,@GoodsDiscount decimal(8, 2) -- 折扣金额
		,@GoodsPaid INT --商品是否已打款：1：已打款；2、未打款
    ,@GoodsDesc varchar(1024) -- 货品描述
    --,@GoodsCreatedDate datetime -- 创建时间
    ,@GoodsSaledDate datetime -- 售出时间
    ,@GoodsConsignStartDate datetime -- 寄售开始时间
		,@GoodsConsignEndDate datetime -- 寄售结束时间
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRANSACTION -- 开始事务
	UPDATE [Goods]
    SET
        [Goods].[CategoryId] = case when @GoodsCategoryId is null then [Goods].[CategoryId] else @GoodsCategoryId end
        ,[Goods].[SupplierId] = case when @GoodsSupplierId is null then [Goods].[SupplierId] else @GoodsSupplierId end
        --,[Goods].[Code] = case when @GoodsCode is null then [Goods].[Code] else @GoodsCode end
        ,[Goods].[OriginalCode] = case when @GoodsOriginalCode is null then [Goods].[OriginalCode] else @GoodsOriginalCode end
        ,[Goods].[SourceType] = case when @GoodsSourceType is null then [Goods].[SourceType] else @GoodsSourceType end
        ,[Goods].[Name] = case when @GoodsName is null then [Goods].[Name] else @GoodsName end
        ,[Goods].[Status] = case when @GoodsStatus is null then [Goods].[Status] else @GoodsStatus end
        ,[Goods].[Image] = case when @GoodsImage is null then [Goods].[Image] else @GoodsImage end
        ,[Goods].[Color] = case when @GoodsColor is null then [Goods].[Color] else @GoodsColor end
        ,[Goods].[Quality] = case when @GoodsQuality is null then [Goods].[Quality] else @GoodsQuality end
        ,[Goods].[Parts] = case when @GoodsParts is null then [Goods].[Parts] else @GoodsParts end
        ,[Goods].[MarkPrice] = case when @GoodsMarkPrice is null then [Goods].[MarkPrice] else @GoodsMarkPrice end
        ,[Goods].[PrimePrice] = case when @GoodsPrimePrice is null then [Goods].[PrimePrice] else @GoodsPrimePrice end
        ,[Goods].[SalePrice] = case when @GoodsSalePrice is null then [Goods].[SalePrice] else @GoodsSalePrice end
        ,[Goods].[Prepay] = case when @GoodsPrepay is null then [Goods].[Prepay] else @GoodsPrepay end
        ,[Goods].[Discount] = case when @GoodsDiscount is null then [Goods].[Discount] else @GoodsDiscount end
        ,[Goods].[Paid] = case when @GoodsPaid is null then [Goods].[Paid] else @GoodsPaid end
				,[Goods].[Desc] = case when @GoodsDesc is null then [Goods].[Desc] else @GoodsDesc end
        --,[Goods].[CreatedDate] = case when @GoodsCreatedDate is null then [Goods].[CreatedDate] else @GoodsCreatedDate end
        ,[Goods].[SaledDate] = case when @GoodsSaledDate is null then [Goods].[SaledDate] else @GoodsSaledDate end
				,[Goods].[ConsignStartDate] = case when @GoodsConsignStartDate is null then [Goods].[ConsignStartDate] else @GoodsConsignStartDate end
				,[Goods].[ConsignEndDate] = case when @GoodsConsignEndDate is null then [Goods].[ConsignEndDate] else @GoodsConsignEndDate end
        ,[Goods].[UpdatedDate] = GETDATE()
    WHERE
		[Goods].[Id] = @GoodsId;
	if @@ERROR<>0
		begin
			rollback tran;
		end
	
	UPDATE [PurchaseRecord]
    SET
        [PurchaseRecord].[UserId] = case when @PurchaseRecordUserId is null then [PurchaseRecord].[UserId] else @PurchaseRecordUserId end
        ,[PurchaseRecord].[PayType] = case when @PurchaseRecordPayType is null then [PurchaseRecord].[PayType] else @PurchaseRecordPayType end
        ,[PurchaseRecord].[Remark] = case when @PurchaseRecordRemark is null then [PurchaseRecord].[Remark] else @PurchaseRecordRemark end
        ,[PurchaseRecord].[Operator] = case when @PurchaseRecordOperator is null then [PurchaseRecord].[Operator] else @PurchaseRecordOperator end
    WHERE
        [PurchaseRecord].[GoodsId] = @GoodsId;
	
	if @@ERROR<>0
		begin
			rollback tran;
		end
		
	commit transaction; --所有語句都執行完成，提交事務
END




GO

-- ----------------------------
-- Procedure structure for uspUpdateRole
-- ----------------------------
DROP PROCEDURE [dbo].[uspUpdateRole]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	新增用户角色
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateRole] 
	@RoleId int -- 角色Id
	,@RoleName varchar(100) -- 角色名称
	,@RoleDesc varchar(500) -- 角色描述
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [Role]
    SET
			[Role].[Name] = case when @RoleName is null then [Role].[Name] else @RoleName end
			,[Role].[Desc] = case when @RoleDesc is null then [Role].[Desc] else @RoleDesc end
			,[Role].[UpdatedDate] = GETDATE()
    WHERE
			[Role].[Id] = @RoleId
END



GO

-- ----------------------------
-- Procedure structure for uspUpdateRoleColumns
-- ----------------------------
DROP PROCEDURE [dbo].[uspUpdateRoleColumns]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-12-26
-- Description:	更新角色拥有的权限
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateRoleColumns]
	@RoleColumnRoleId int -- 角色Id
	,@RoleColumnColumnIds nvarchar(1024) -- 角色有权限的列，以','分隔
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF EXISTS (SELECT [RoleId] FROM [RoleColumn] WHERE [RoleColumn].[RoleId] = @RoleColumnRoleId)
		BEGIN
			UPDATE [RoleColumn]
    SET
        [RoleColumn].[ColumnIds] = case when @RoleColumnColumnIds is null then [RoleColumn].[ColumnIds] else @RoleColumnColumnIds end
        ,[RoleColumn].[UpdatedDate] = GETDATE()
    WHERE
        [RoleColumn].[RoleId] = @RoleColumnRoleId
		END
	ELSE
		BEGIN
			INSERT INTO [RoleColumn](
        [RoleId]
        ,[ColumnIds]
    ) VALUES (
				@RoleColumnRoleId
        ,@RoleColumnColumnIds
    );
		END
	END



GO

-- ----------------------------
-- Procedure structure for uspUpdateSaledGoods
-- ----------------------------
DROP PROCEDURE [dbo].[uspUpdateSaledGoods]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-30
-- Description:	修改进货商品及进货记录信息
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateSaledGoods]
    @GoodsId int -- 货品Id
		,@GoodsStatus int -- 货品状态：1、在库；2、预定；3、售出；4、取回；
		,@GoodsSalePrice decimal(8, 2) -- 售出价格
		,@GoodsPrepay decimal(8, 2) -- 预付款
		,@GoodsDiscount decimal(8, 2) -- 折扣金额
		,@GoodsPaid INT --商品是否已打款：1：已打款；2、未打款
		,@GoodsSaledDate datetime -- 售出时间
		,@SaledRecordUserId int -- 当前登录用户名
		,@SaledRecordPayType int -- 付款方式：1、现金；2、汇款；3、信用卡；4、网银转帐；
		,@SaledRecordRemark varchar(2048) -- 
		,@SaledRecordCustomerName varchar(100) -- 顾客姓名
    ,@SaledRecordCustomerPhone varchar(50) -- 顾客联系方式
		,@SaledRecordOperator varchar(100) -- 经手人
		
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRANSACTION -- 开始事务
	UPDATE [Goods]
    SET
        [Goods].[Status] = case when @GoodsStatus is null then [Goods].[Status] else @GoodsStatus end
        ,[Goods].[SalePrice] = case when @GoodsSalePrice is null then [Goods].[SalePrice] else @GoodsSalePrice end
        ,[Goods].[Prepay] = case when @GoodsPrepay is null then [Goods].[Prepay] else @GoodsPrepay end
        ,[Goods].[Discount] = case when @GoodsDiscount is null then [Goods].[Discount] else @GoodsDiscount end
				,[Goods].[Paid] = case when @GoodsPaid is null then [Goods].[Paid] else @GoodsPaid end
        ,[Goods].[SaledDate] = case when @GoodsSaledDate is null then [Goods].[SaledDate] else @GoodsSaledDate end
		WHERE
				[Goods].[Id] = @GoodsId;
	if @@ERROR<>0
		begin
			rollback tran;
		end
	
	UPDATE [SaledRecord]
    SET
        [SaledRecord].[UserId] = case when @SaledRecordUserId is null then [SaledRecord].[UserId] else @SaledRecordUserId end
        ,[SaledRecord].[PayType] = case when @SaledRecordPayType is null then [SaledRecord].[PayType] else @SaledRecordPayType end
        ,[SaledRecord].[Remark] = case when @SaledRecordRemark is null then [SaledRecord].[Remark] else @SaledRecordRemark end
        ,[SaledRecord].[CustomerName] = case when @SaledRecordCustomerName is null then [SaledRecord].[CustomerName] else @SaledRecordCustomerName end
        ,[SaledRecord].[CustomerPhone] = case when @SaledRecordCustomerPhone is null then [SaledRecord].[CustomerPhone] else @SaledRecordCustomerPhone end
				,[SaledRecord].[Operator] = case when @SaledRecordOperator is null then [SaledRecord].[Operator] else @SaledRecordOperator end
    WHERE
        [SaledRecord].[GoodsId] = @GoodsId;
	
	if @@ERROR<>0
		begin
			rollback tran;
		end
		
	commit transaction; --所有語句都執行完成，提交事務
END




GO

-- ----------------------------
-- Procedure structure for uspUpdateShop
-- ----------------------------
DROP PROCEDURE [dbo].[uspUpdateShop]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	更新店铺信息
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateShop]
	@ShopId int -- 店铺Id
	,@ShopName varchar(100) -- 店铺名称
	,@ShopPhone varchar(20) -- 联系电话
	,@ShopAddress varchar(200) -- 店铺地址
	,@ShopDesc varchar(500) -- 店铺描述
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		UPDATE [Shop]
		SET
				[Shop].[Name] = case when @ShopName is null then [Shop].[Name] else @ShopName end
				,[Shop].[Phone] = case when @ShopPhone is null then [Shop].[Phone] else @ShopPhone end
				,[Shop].[Address] = case when @ShopAddress is null then [Shop].[Address] else @ShopAddress end
				,[Shop].[Desc] = case when @ShopDesc is null then [Shop].[Desc] else @ShopDesc end
				,[Shop].[UpdatedDate] = GETDATE()
		WHERE
				[Shop].[Id] = @ShopId
END



GO

-- ----------------------------
-- Procedure structure for uspUpdateSupplier
-- ----------------------------
DROP PROCEDURE [dbo].[uspUpdateSupplier]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	更新供应商信息
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateSupplier] 
	@SupplierId int
    ,@SupplierName varchar(10)
    ,@SupplierSex int
    ,@SupplierPhone varchar(50)
    ,@SupplierBankName varchar(200)
    ,@SupplierBankCard varchar(50)
    ,@SupplierIdCard varchar(50)
    ,@SupplierAddress varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [Supplier]
    SET
        [Supplier].[Name] = case when @SupplierName is null then [Supplier].[Name] else @SupplierName end
        ,[Supplier].[Sex] = case when @SupplierSex is null then [Supplier].[Sex] else @SupplierSex end
        ,[Supplier].[Phone] = case when @SupplierPhone is null then [Supplier].[Phone] else @SupplierPhone end
        ,[Supplier].[BankName] = case when @SupplierBankName is null then [Supplier].[BankName] else @SupplierBankName end
        ,[Supplier].[BankCard] = case when @SupplierBankCard is null then [Supplier].[BankCard] else @SupplierBankCard end
        ,[Supplier].[IdCard] = case when @SupplierIdCard is null then [Supplier].[IdCard] else @SupplierIdCard end
        ,[Supplier].[Address] = case when @SupplierAddress is null then [Supplier].[Address] else @SupplierAddress end
        ,[Supplier].[UpdatedDate] = GETDATE()
    WHERE
		[Supplier].[Id] = @SupplierId;
END



GO

-- ----------------------------
-- Procedure structure for uspUpdateUser
-- ----------------------------
DROP PROCEDURE [dbo].[uspUpdateUser]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	修改用户信息
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateUser]
	@UserId int -- 用户Id
	,@UserRoleId int -- 角色Id
	,@UserShopId int -- 所在商铺Id
	,@UserName varchar(100) -- 用户登录名
	,@UserPwd	varchar(50) --用户密码
	,@UserRealName varchar(100) -- 用户真实姓名
	,@UserSex int -- 性别：1、男;2、女;
	,@UserPhone varchar(50) -- 联系电话
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [User]
    SET
        [User].[RoleId] = case when @UserRoleId is null then [User].[RoleId] else @UserRoleId end
        ,[User].[ShopId] = case when @UserShopId is null then [User].[ShopId] else @UserShopId end
        ,[User].[Name] = case when @UserName is null then [User].[Name] else @UserName end
				,[User].[Pwd] = case when @UserPwd is null then [User].[Pwd] else @UserPwd end
        ,[User].[RealName] = case when @UserRealName is null then [User].[RealName] else @UserRealName end
        ,[User].[Sex] = case when @UserSex is null then [User].[Sex] else @UserSex end
        ,[User].[Phone] = case when @UserPhone is null then [User].[Phone] else @UserPhone end
        ,[User].[UpdatedDate] = GETDATE()
    WHERE
				[User].[Id] = @UserId;
END



GO

-- ----------------------------
-- Procedure structure for uspValidateUserName
-- ----------------------------
DROP PROCEDURE [dbo].[uspValidateUserName]
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-12-30
-- Description:	新增用户
-- =============================================
CREATE PROCEDURE [dbo].[uspValidateUserName]
		@UserId int -- 用户Id
		,@UserName varchar(100) -- 用户登录名
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		SELECT [User].[Id] AS UserId 
		FROM [User] 
		WHERE 
			[User].[Id] != CASE WHEN @UserId IS NULL THEN [User].[Id] ELSE @UserId END
			AND [User].[Name] = @UserName;
END



GO

-- ----------------------------
-- Function structure for FunMD5Encrypy
-- ----------------------------
DROP FUNCTION [dbo].[FunMD5Encrypy]
GO


create function [dbo].[FunMD5Encrypy]  
(
 @Str varchar(max)
)  
returns varchar(max)  
as begin
	declare @Bin varbinary(max);
	select @bin = hashbytes('MD5',convert(NVARCHAR,@Str));
	return cast(N'' as xml).value('xs:base64Binary(xs:hexBinary(sql:variable("@Bin")))', 'varchar(max)');
end


GO

-- ----------------------------
-- Function structure for FunPadLeft
-- ----------------------------
DROP FUNCTION [dbo].[FunPadLeft]
GO


CREATE function [dbo].[FunPadLeft]
(
	@num varchar(16),
	@paddingChar char(1),
	@totalWidth int
)
returns varchar(16) 
as
begin
	declare @curStr varchar(16)
	select @curStr = isnull(replicate(@paddingChar,@totalWidth - len(isnull(@num ,0))), '') + @num
	return @curStr
end


GO

-- ----------------------------
-- Indexes structure for table Category
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Category
-- ----------------------------
ALTER TABLE [dbo].[Category] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table Goods
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Goods
-- ----------------------------
ALTER TABLE [dbo].[Goods] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table OperateLog
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table OperateLog
-- ----------------------------
ALTER TABLE [dbo].[OperateLog] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table PayType
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table PayType
-- ----------------------------
ALTER TABLE [dbo].[PayType] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table PurchaseRecord
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table PurchaseRecord
-- ----------------------------
ALTER TABLE [dbo].[PurchaseRecord] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table Role
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Role
-- ----------------------------
ALTER TABLE [dbo].[Role] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table RoleColumn
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table RoleColumn
-- ----------------------------
ALTER TABLE [dbo].[RoleColumn] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table SaledRecord
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SaledRecord
-- ----------------------------
ALTER TABLE [dbo].[SaledRecord] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table Shop
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Shop
-- ----------------------------
ALTER TABLE [dbo].[Shop] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table Supplier
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Supplier
-- ----------------------------
ALTER TABLE [dbo].[Supplier] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table TableColumn
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table TableColumn
-- ----------------------------
ALTER TABLE [dbo].[TableColumn] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table User
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table User
-- ----------------------------
ALTER TABLE [dbo].[User] ADD PRIMARY KEY ([Id])
GO
