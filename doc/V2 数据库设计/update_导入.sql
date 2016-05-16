-- ----------------------------
-- Table structure for BatchInsertGoodsFullTemp
-- ----------------------------
DROP TABLE [dbo].[BatchInsertGoodsTemp]
GO
CREATE TABLE [dbo].[BatchInsertGoodsTemp] (
	[UserId] int,
	[GoodsOrder] INT,
	[CategoryName] varchar(100) NULL ,
	[GoodsCode] varchar(50) NULL ,
	[GoodsName] varchar(255) NULL ,
	[GoodsPrimePrice] varchar(50) NULL ,
	[PayTypeName] varchar(255) NULL ,
	[GoodsSaledCharge] VARCHAR(50) NULL,
	[GoodsUnSaledCharge] VARCHAR(50) NULL,
	[GoodsStatus] varchar(50) NULL ,
	[GoodsMarkPrice] varchar(50) NULL ,
	[GoodsConsignEndDate] varchar(50) NULL ,
	[GoodsSaledDate] varchar(50) NULL,
	[GoodsCharge] varchar(50) NULL,
	[GoodsPaySupplier] varchar(50) NULL,
	[SupplierName] varchar(200) NULL ,
	[SupplierPhone] varchar(50) NULL ,
	[SupplierBankName] varchar(200) NULL ,
	[SupplierBankCard] varchar(50) NULL 
)


GO

ALTER TABLE Supplier
	ALTER COLUMN [Name] VARCHAR(50) NULL;
GO

USE [V2IMSDB]
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateSaledGoods]    Script Date: 01/25/2014 14:07:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-30
-- Description:	修改进货商品及进货记录信息
-- =============================================
ALTER PROCEDURE [dbo].[uspUpdateSaledGoods]
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
        ,[SaledRecord].[GoodsId] = case when (@GoodsStatus is null and @GoodsStatus != 1)then [SaledRecord].[GoodsId] else -[SaledRecord].[GoodsId] end
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
-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	购进货品
-- =============================================
ALTER PROCEDURE [dbo].[uspAddPurchaseGoods]
		@PurchaseRecordUserId int
		,@PurchaseRecordPayType int
		,@PurchaseRecordRemark varchar(2048)
		,@PurchaseRecordOperator varchar(100)
		,@GoodsCategoryId int -- 所属分类Id
		,@GoodsSupplierId int -- 供应商Id
		,@GoodsCode varchar(50) -- 商品编码
		,@GoodsOriginalCode varchar(50) -- 原厂编码
		,@GoodsSourceType int -- 来源类型：寄售：1，进货自有：2
		,@GoodsName varchar(255) -- 商品名称
		--,@GoodsStatus int -- 货品状态：1、在库；2、预定；3、售出；4、取回；
		,@GoodsImage varchar(max) -- 货品图片
		,@GoodsImageThum varchar(max) -- 货品图片缩略图
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
	BEGIN TRANSACTION -- 开始事务
	DECLARE @GoodsOrder INT;
	SELECT @GoodsOrder = count(0)+1 
	FROM [Goods]
	WHERE
		[Goods].[CreatedDate] BETWEEN CONVERT(VARCHAR(100), GETDATE(),23) AND CONVERT(VARCHAR(100), DATEADD(DAY, 1, GETDATE()),23)

	--DECLARE @GoodsCode varchar(50);
IF @GoodsCode IS NULL
	BEGIN
		IF @GoodsSourceType = 1 -- 寄售商品
				SET @GoodsCode = 'JS' + CONVERT(VARCHAR(100), GETDATE(),112) + [dbo].[FunPadLeft](@GoodsOrder,'0',3);
		ELSE IF @GoodsSourceType = 2 -- 进货商品
				SET @GoodsCode = 'ZY' + CONVERT(VARCHAR(100), GETDATE(),112) + [dbo].[FunPadLeft](@GoodsOrder,'0',3);
	END

	
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
				,[ImageThum]
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
				,@GoodsImageThum
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
			,[Goods].[ImageThum] as GoodsImageThum
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
  FROM [Goods] 
  left join [PurchaseRecord] on [Goods].[Id] = [PurchaseRecord].[GoodsId]
  WHERE 
		[Goods].[Id] = @GoodsId;

    commit transaction; --所有語句都執行完成，提交事務
END

GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	从临时表中同步数据到正式表
-- =============================================
CREATE PROCEDURE [dbo].[uspSyncGoodses]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION -- 开始事务
		-- 同步 付款类型
		INSERT INTO [PayType]([Name],[BankCharge])
		SELECT
				DISTINCT [BatchInsertGoodsTemp].[PayTypeName]
				,0
    FROM
        [BatchInsertGoodsTemp]
    WHERE
				[BatchInsertGoodsTemp].[PayTypeName] NOT IN (
						SELECT [PayType].[Name] 
						FROM [PayType]
				) and [BatchInsertGoodsTemp].[PayTypeName] is not null
				and [BatchInsertGoodsTemp].[PayTypeName] <>'';
    if @@ERROR<>0
		begin
			rollback tran;
		end
	
		INSERT INTO [Category]([Name],[ParentId],[Status],[Order],[Desc])
		SELECT
				DISTINCT [BatchInsertGoodsTemp].[CategoryName]
				,0,1,0
				,'导入商品类型:'+[BatchInsertGoodsTemp].[CategoryName]
    FROM
        [BatchInsertGoodsTemp]
    WHERE
				[BatchInsertGoodsTemp].[CategoryName] NOT IN (
						SELECT [Category].[Name] 
						FROM [Category]
				)and [BatchInsertGoodsTemp].[CategoryName] is not null 
				and [BatchInsertGoodsTemp].[CategoryName] <>'';

    if @@ERROR <> 0
		begin
			rollback tran;
		end
	

		INSERT INTO [Supplier]([Phone],[Sex],[Name],[BankName],[BankCard],[IdCard],[Address])
		SELECT 
			  DISTINCT [BatchInsertGoodsTemp].[SupplierPhone] 
				,0
        ,[BatchInsertGoodsTemp].[SupplierName]
        ,[BatchInsertGoodsTemp].[SupplierBankName]
        ,[BatchInsertGoodsTemp].[SupplierBankCard]
				,'222'
				,'导入供应商:'+[BatchInsertGoodsTemp].[SupplierName]
    FROM
        [BatchInsertGoodsTemp]
    WHERE
				[BatchInsertGoodsTemp].[SupplierPhone] NOT IN(
					SELECT [Supplier].[Phone]
					FROM [Supplier]
				)and [BatchInsertGoodsTemp].[SupplierPhone] is not null 
				and [BatchInsertGoodsTemp].[SupplierPhone] <>'';
		if @@ERROR <> 0
			begin
				rollback tran;
			end

		INSERT INTO [Goods](
        [CategoryId]
        ,[SupplierId]
        ,[Code]
        ,[OriginalCode]
        ,[SourceType]
        ,[Name]
        ,[Status]
        --,[Image]
        --,[Color]
        --,[Quality]
        --,[Parts]
        ,[MarkPrice]
        ,[PrimePrice]
        --,[SalePrice]
        --,[Prepay]
        --,[Discount]
        ,[Desc]
        ,[Paid]
        --,[ConsignStartDate]
        ,[ConsignEndDate]
        --,[CreatedDate]
        --,[SaledDate]
        --,[UpdatedDate]
        --,[ImageThum]
    )
		 SELECT
				[Category].[Id]
				,[Supplier].[Id]
				,[BatchInsertGoodsTemp].[GoodsCode] 
				,'111'
				,Case Left([BatchInsertGoodsTemp].[GoodsCode],2) when 'JS' then 1 else 2 end
				,[BatchInsertGoodsTemp].[GoodsName]
				,1--1、在库；2、预定；3、售出；4、取回；
				,Convert(decimal(8,2),case when [BatchInsertGoodsTemp].[GoodsMarkPrice]=null or [BatchInsertGoodsTemp].[GoodsMarkPrice]='' then 0 else [BatchInsertGoodsTemp].[GoodsMarkPrice] end)
				,Convert(decimal(8,2),[BatchInsertGoodsTemp].[GoodsPrimePrice])
				,'导入商品:'+[BatchInsertGoodsTemp].[GoodsName]
				,1 -- 1未打款 2已打款
				,DATEADD(DAY,60,GETDATE())
    FROM
        [BatchInsertGoodsTemp]
		LEFT JOIN [Supplier] ON [BatchInsertGoodsTemp].[SupplierPhone] = [Supplier].[Phone]
		LEFT JOIN [Category] ON [BatchInsertGoodsTemp].[CategoryName] = [Category].[Name]
		WHERE
			[BatchInsertGoodsTemp].[GoodsCode] NOT IN(
				SELECT [Goods].[Code] 
				FROM [Goods]
			)
			and [BatchInsertGoodsTemp].[GoodsCode] <> '' and [BatchInsertGoodsTemp].[GoodsCode] is not null
			and [BatchInsertGoodsTemp].[GoodsName] <> '' and [BatchInsertGoodsTemp].[GoodsName] is not null
			and [BatchInsertGoodsTemp].[GoodsPrimePrice] <> '' and [BatchInsertGoodsTemp].[GoodsPrimePrice] is not null
	    ;
		if @@ERROR <> 0
			begin
				rollback tran;
			end

		INSERT INTO [PurchaseRecord]([UserId],[GoodsId],[PayType],[Remark],[Operator])
		SELECT 
			  [User].[Id]
				,[Goods].[Id]
        ,[PayType].[Id]
				,'导入商品:'+[Goods].[Name]
				,[User].[Name]
    FROM
        [BatchInsertGoodsTemp]
		LEFT JOIN [User] ON [BatchInsertGoodsTemp].[UserId] = [User].[Id]
		LEFT JOIN [Goods] ON [BatchInsertGoodsTemp].[GoodsCode] = [Goods].[Code]
		LEFT JOIN [PayType] ON [BatchInsertGoodsTemp].[PayTypeName] = [PayType].[Name]
		where 
		[BatchInsertGoodsTemp].[GoodsCode] NOT IN(
				SELECT g.[Code]
				FROM [PurchaseRecord] p
				inner join [Goods] g
				on p.Id=g.Id
			) and 
		[BatchInsertGoodsTemp].[GoodsCode] <> '' and [BatchInsertGoodsTemp].[GoodsCode] is not null
		and [BatchInsertGoodsTemp].[PayTypeName] <> '' and [BatchInsertGoodsTemp].[PayTypeName] is not null
		;
		if @@ERROR <> 0
			begin
				rollback tran;
			end
    commit transaction; --所有語句都執行完成，提交事務
END

GO

-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	清空临时表中批量导入的数据
-- =============================================
CREATE PROCEDURE [dbo].[uspClearGoodsTemp]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	TRUNCATE TABLE BatchInsertGoodsTemp;
END
GO