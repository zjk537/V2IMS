-- 现场写sql 实现更新走以前售出逻辑扣除手续费的数据，将以前扣除的手续费还原到商品售价中
-- 此补丁 少处理一种情况：
-- 如果一个商品 付款多次且每次都有扣手续费，只能统计出最后一次付款的手续费
USE V2IMSDB
GO

ALTER TABLE SaledRecord
	ADD PayCharge DECIMAL(8,2) NULL
GO

ALTER TABLE SaledRecord
	ADD BatchId VARCHAR(50) NULL
GO

IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SaledRecord', 
'COLUMN', N'PayCharge')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'银行收取的手续费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'PayCharge'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'银行收取的手续费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'PayCharge'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SaledRecord', 
'COLUMN', N'BatchId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'售出商品批次Id:2014022501'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'BatchId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'售出商品批次Id:2014022501'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SaledRecord'
, @level2type = 'COLUMN', @level2name = N'BatchId'
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	从临时表中同步数据到正式表
-- UPDATE: 供应商手机号码重复时，导入数据重复
-- =============================================
ALTER PROCEDURE [dbo].[uspSyncGoodses]
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
		SELECT [SupplierPhone] 
				,0
        ,[SupplierName]
        ,[SupplierBankName]
        ,[SupplierBankCard]
				,'222'
				,'导入供应商:'+[SupplierName]
		FROM (SELECT 
						DISTINCT [BatchInsertGoodsTemp].[SupplierPhone]
						,[BatchInsertGoodsTemp].[SupplierName]
						,[BatchInsertGoodsTemp].[SupplierBankName]
						,[BatchInsertGoodsTemp].[SupplierBankCard]
				FROM
					[BatchInsertGoodsTemp]
				WHERE
					[BatchInsertGoodsTemp].[SupplierPhone] NOT IN(SELECT [Supplier].[Phone] FROM [Supplier]) 
				AND [BatchInsertGoodsTemp].[SupplierPhone] IS NOT NULL
				AND [BatchInsertGoodsTemp].[SupplierPhone] <> '') TempSupplier
		
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
        ,[UpdatedDate]
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
				,1 -- 1：已打款；2、未打款
				,DATEADD(DAY,60,GETDATE())
				,GETDATE()
    FROM
        [BatchInsertGoodsTemp]
		LEFT JOIN [Supplier] ON [BatchInsertGoodsTemp].[SupplierPhone] = [Supplier].[Phone]
		LEFT JOIN [Category] ON [BatchInsertGoodsTemp].[CategoryName] = [Category].[Name]
		WHERE
			[BatchInsertGoodsTemp].[GoodsCode] NOT IN(SELECT [Goods].[Code] FROM [Goods])
			AND [BatchInsertGoodsTemp].[GoodsCode] <> '' AND [BatchInsertGoodsTemp].[GoodsCode] IS NOT NULL
			AND [BatchInsertGoodsTemp].[GoodsName] <> '' AND [BatchInsertGoodsTemp].[GoodsName] IS NOT NULL
			AND [BatchInsertGoodsTemp].[GoodsPrimePrice] <> '' AND [BatchInsertGoodsTemp].[GoodsPrimePrice] IS NOT NULL;
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
			[BatchInsertGoodsTemp].[GoodsCode] IN(
					SELECT [Goods].[Code] FROM [Goods]
					WHERE
						[Goods].[Id] NOT IN(SELECT [PurchaseRecord].[GoodsId] FROM [PurchaseRecord])
				) 
		AND	[BatchInsertGoodsTemp].[GoodsCode] <> '' AND [BatchInsertGoodsTemp].[GoodsCode] IS NOT NULL
		AND [BatchInsertGoodsTemp].[PayTypeName] <> '' AND [BatchInsertGoodsTemp].[PayTypeName] IS NOT NULL;
		if @@ERROR <> 0
			begin
				rollback tran;
			end
    commit transaction; --所有語句都執行完成，提交事務
END

GO




-- =============================================
-- Author:		zjk
-- Create date: 2014-1-2
-- Description:	获取商品预警信息
-- =============================================
ALTER PROCEDURE [dbo].[uspGetWarningGoods]
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
			,ISNULL([SR].[Id],0) as SaledRecordId
			,ISNULL([SR].[GoodsId],0) as SaledRecordGoodsId
			,ISNULL([SR].[UserId],0) as SaledRecordUserId
			,ISNULL([SR].[PayType],0) as SaledRecordPayType
			,[SR].[Remark] as SaledRecordRemark
			,[SR].[CustomerName] as SaledRecordCustomerName
      ,[SR].[CustomerPhone] as SaledRecordCustomerPhone
			,[SR].[Operator] as SaledRecordOperator
			,[SR].[PayCharge] as SaledRecordPayCharge
			,[SR].[BatchId] as SaledRecordBatchId
  FROM [Goods]
			left join [PurchaseRecord] on [Goods].[Id] = [PurchaseRecord].[GoodsId] 
			--left join [SaledRecord] on [Goods].[Id] = [SaledRecord].[GoodsId]
			LEFT JOIN (SELECT *	FROM [SaledRecord] 
									WHERE [SaledRecord].[Id] IN (
										SELECT MAX(Id) FROM SaledRecord GROUP BY GoodsId
								)
			) as SR ON [Goods].[Id] = [SR].[GoodsId]
  WHERE 
		-- 售出未付款预警
		-- 1在库，2预定,3、售出 4、取回
		[Goods].[Status] = 3 --CASE WHEN @WarningType = 1 THEN 3 ELSE 1 END
		--1:未打款 2：已打款
		AND [Goods].[Paid] = 1 -- CASE WHEN @WarningType = 1 THEN 1 ELSE [Goods].[Paid] END
		--AND GETDATE() >= CASE WHEN @WarningType = 1 THEN CONVERT(varchar(100),DATEADD(DAY, -@WarningDays, [Goods].[SaledDate]), 23) ELSE GETDATE() END 

		-- 寄售到期 预警
		AND LEFT([Goods].[Code],2) = CASE WHEN @WarningType = 2 THEN 'JS' ELSE LEFT([Goods].[Code],2) END
		AND GETDATE() >= CASE WHEN @WarningType = 2 THEN CONVERT(varchar(100),DATEADD(DAY, -@WarningDays, [Goods].[ConsignEndDate]), 23) ELSE GETDATE() END 
		AND GETDATE() <= CASE WHEN @WarningType = 2 THEN CONVERT(varchar(100),DATEADD(DAY, 1, [Goods].[ConsignEndDate]),23) ELSE GETDATE() END
		ORDER BY  
			CASE WHEN @WarningType = 2 THEN [Goods].[ConsignEndDate] ELSE [Goods].[SaledDate] END
	
END

GO




-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	获取商品信息
-- =============================================
ALTER PROCEDURE [dbo].[uspGetGoodses]
	@GoodsCategoryId int
	--,@SupplierPhone varchar(20)
	,@GoodsName varchar(255)
	,@GoodsCode varchar(50)
	,@GoodsStatus int
	,@GoodsSourceType int
	,@GoodsPaid INT  --商品是否已打款：1：已打款；2、未打款
	,@StartDate datetime
	,@EndDate datetime
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
			,ISNULL([SR].[Id],0) as SaledRecordId
			,ISNULL([SR].[GoodsId],0) as SaledRecordGoodsId
			,ISNULL([SR].[UserId],0) as SaledRecordUserId
			,ISNULL([SR].[PayType],0) as SaledRecordPayType
			,[SR].[Remark] as SaledRecordRemark
			,[SR].[CustomerName] as SaledRecordCustomerName
      ,[SR].[CustomerPhone] as SaledRecordCustomerPhone
			,[SR].[Operator] as SaledRecordOperator
			,[SR].[PayCharge] as SaledRecordPayCharge
			,[SR].[BatchId] as SaledRecordBatchId
  FROM [Goods]
			left join [PurchaseRecord] on [Goods].[Id] = [PurchaseRecord].[GoodsId] 
			--left join [SaledRecord] on [Goods].[Id] = [SaledRecord].[GoodsId]
			LEFT JOIN (SELECT *	FROM [SaledRecord] 
									WHERE [SaledRecord].[Id] IN (
										SELECT MAX(Id) FROM SaledRecord GROUP BY GoodsId
								)
			) as SR ON [Goods].[Id] = [SR].[GoodsId]
  WHERE 
		[Goods].[CategoryId] = CASE WHEN @GoodsCategoryId is NULL THEN [Goods].[CategoryId] ELSE @GoodsCategoryId END
		--AND [Supplier].[Phone] = CASE WHEN @SupplierPhone is NULL THEN [Supplier].[Phone] ELSE @SupplierPhone END
		AND [Goods].[Name] LIKE '%' +  CASE WHEN @GoodsName is NULL THEN [Goods].[Name] ELSE @GoodsName END + '%'
		AND [Goods].[Code] LIKE '%' + CASE WHEN @GoodsCode is NULL THEN [Goods].[Code] ELSE @GoodsCode END + '%'
		AND [Goods].[Status] = CASE WHEN @GoodsStatus is NULL THEN [Goods].[Status] ELSE @GoodsStatus END
		--AND [Goods].[Paid] = CASE WHEN @GoodsPaid is NULL THEN [Goods].[Paid] ELSE @GoodsPaid END
		AND [Goods].[SourceType] = CASE WHEN @GoodsSourceType is NULL THEN [Goods].[SourceType] ELSE @GoodsSourceType END
		AND ([Goods].[UpdatedDate] >= CASE WHEN @StartDate is NULL THEN [Goods].[UpdatedDate] ELSE CONVERT(varchar(100),  @StartDate, 23) END
				AND [Goods].[UpdatedDate] <= CASE WHEN @EndDate is NULL THEN [Goods].[UpdatedDate] ELSE CONVERT(varchar(100),DATEADD(DAY, 1, @EndDate), 23) END)
		ORDER BY [Goods].[UpdatedDate] DESC
END

GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	货品预定或售出
-- =============================================
ALTER PROCEDURE [dbo].[uspAddSaledGoods] 
		@SaledRecordUserId int -- 当前登录用户名
		,@SaledRecordPayType int -- 付款方式：1、现金；2、汇款；3、信用卡；4、网银转帐；
		,@SaledRecordRemark varchar(2048) -- 
		,@SaledRecordOperator varchar(100) -- 经手人
		,@SaledRecordCustomerName varchar(100) -- 顾客姓名
    ,@SaledRecordCustomerPhone varchar(50) -- 顾客联系方式
		,@SaledRecordPayCharge DECIMAL(8,2) -- 银行手续费
		,@SaledRecordBatchId VARCHAR(50) -- 售出批次Id
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
				,[PayCharge]
				,[BatchId]
    ) VALUES (
        @SaledRecordUserId
        ,@GoodsId
        ,@SaledRecordPayType
        ,@SaledRecordRemark
				,@SaledRecordCustomerName
        ,@SaledRecordCustomerPhone
        ,@SaledRecordOperator
				,@SaledRecordPayCharge
				,@SaledRecordBatchId
    )
		if @@ERROR <> 0
			begin
				rollback tran;
			end
	commit tran;
	
END

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
		,@SaledRecordPayCharge DECIMAL(8,2) -- 银行手续费
		,@SaledRecordBatchId VARCHAR(50) -- 售出批次Id
		
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
				,[Goods].[UpdatedDate] = GETDATE()
		WHERE
				[Goods].[Id] = @GoodsId;
	if @@ERROR<>0
		begin
			rollback tran;
		end
	
	IF EXISTS (SELECT Id FROM [SaledRecord] WHERE [SaledRecord].[BatchId] = @SaledRecordBatchId)
		BEGIN
			SET @SaledRecordBatchId = @SaledRecordBatchId + '-1';
		END
	-- 添加货品销售记录
		INSERT INTO [SaledRecord](
        [UserId]
        ,[GoodsId]
        ,[PayType]
        ,[Remark]
				,[CustomerName]
        ,[CustomerPhone]
        ,[Operator]
				,[PayCharge]
				,[BatchId]
    ) VALUES (
        @SaledRecordUserId
        ,@GoodsId
        ,@SaledRecordPayType
        ,@SaledRecordRemark
				,@SaledRecordCustomerName
        ,@SaledRecordCustomerPhone
        ,@SaledRecordOperator
				,@SaledRecordPayCharge
				,@SaledRecordBatchId
    )
	/*UPDATE [SaledRecord]
    SET
        [SaledRecord].[UserId] = case when @SaledRecordUserId is null then [SaledRecord].[UserId] else @SaledRecordUserId end
        ,[SaledRecord].[PayType] = case when @SaledRecordPayType is null then [SaledRecord].[PayType] else @SaledRecordPayType end
        ,[SaledRecord].[Remark] = case when @SaledRecordRemark is null then [SaledRecord].[Remark] else @SaledRecordRemark end
        ,[SaledRecord].[CustomerName] = case when @SaledRecordCustomerName is null then [SaledRecord].[CustomerName] else @SaledRecordCustomerName end
        ,[SaledRecord].[CustomerPhone] = case when @SaledRecordCustomerPhone is null then [SaledRecord].[CustomerPhone] else @SaledRecordCustomerPhone end
				,[SaledRecord].[Operator] = case when @SaledRecordOperator is null then [SaledRecord].[Operator] else @SaledRecordOperator end
				,[SaledRecord].[PayCharge] = case when @SaledRecordPayCharge is null then [SaledRecord].[PayCharge] else @SaledRecordPayCharge end
				,[SaledRecord].[BatchId] = case when @SaledRecordBatchId is null then [SaledRecord].[BatchId] else @SaledRecordBatchId end
    WHERE
        [SaledRecord].[GoodsId] = @GoodsId;
	*/
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
				,[UpdatedDate]
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
				,GETDATE()
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