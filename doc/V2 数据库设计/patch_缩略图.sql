-- 添加商品缩略图

ALTER TABLE Goods
	ADD ImageThum VARCHAR(max)




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
		--,@GoodsCode varchar(50) -- 商品编码
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




-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	获取商品信息
-- =============================================
ALTER PROCEDURE [dbo].[uspGetGoodsInfos]
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
-- Create date: 2013-11-30
-- Description:	修改进货商品及进货记录信息
-- =============================================
ALTER PROCEDURE [dbo].[uspUpdatePurchaseGoods]
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
		,@GoodsImageThum varchar(max) -- 货品图片缩略图
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
				,[Goods].[ImageThum] = case when @GoodsImageThum is null then [Goods].[ImageThum] else @GoodsImageThum end
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


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	获取商品大图
-- =============================================
CREATE PROCEDURE [dbo].[uspGetGoodsImage]
	@GoodsId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--declare @sql as varchar(max);
	--set @sql = N'
	SELECT 
			[Goods].[Image] as GoodsImage
  FROM [Goods] 
  WHERE 
		[Goods].[Id] = @GoodsId
END

GO



-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	获取所有商品信息
-- =============================================
CREATE PROCEDURE [dbo].[uspGetAllGoodsInfos]
	
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
  FROM [Goods]
END
go