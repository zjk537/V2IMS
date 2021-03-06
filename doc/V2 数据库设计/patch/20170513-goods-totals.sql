USE [V2IMSDB]
GO
/****** Object:  StoredProcedure [dbo].[uspGetDashboardTotal]    Script Date: 05/13/2017 14:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		zjk
-- Create date: 2013-11-3
-- Description:	获取商品信息
-- =============================================
if (exists (select * from sys.objects where name = 'uspGetGoodses'))
    drop proc uspGetGoodses
go
Create PROCEDURE [dbo].[uspGetGoodses]
	@GoodsCategoryId int = null 
	--,@SupplierPhone varchar(20)
	,@GoodsName varchar(255) = null 
	,@GoodsCode varchar(50) = null 
	,@GoodsStatus int = null 
	,@GoodsSourceType int = null 
	,@GoodsPaid INT  = null  --商品是否已打款：1：已打款；2、未打款
	,@StartDate datetime = null --更新开始时间
	,@EndDate datetime = null --更新结束时间
	,@SalesStartDate datetime = null -- 售出开始时间
	,@SalesEndDate datetime = null -- 售出结束时间
	,@ConsignStartStartDate datetime=null--寄售开始的起始时间
	,@ConsignStartEndDate datetime=null--寄售开始的结束时间
	,@ConsignEndStartDate datetime=null--寄售结束的开始时间
	,@ConsignEndEndDate datetime=null--寄售结束的结束时间
AS
BEGIN
	declare @minDate datetime = '1900-1-1'
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--declare @sql AS varchar(max);
	--set @sql = N'
		SELECT 
			[Goods].[Id] AS GoodsId
			,[Goods].[CategoryId] AS GoodsCategoryId
			,[Goods].[SupplierId] AS GoodsSupplierId
			,[Goods].[Code] AS GoodsCode
			,[Goods].[OriginalCode] AS GoodsOriginalCode
			,[Goods].[SourceType] AS GoodsSourceType
			,[Goods].[Name] AS GoodsName
			,[Goods].[Status] AS GoodsStatus
			--,[Goods].[ImageThum] AS GoodsImageThum
			,[Goods].[Color] AS GoodsColor
			,[Goods].[Quality] AS GoodsQuality
			,[Goods].[Parts] AS GoodsParts
			,[Goods].[MarkPrice] AS GoodsMarkPrice
			,[Goods].[PrimePrice] AS GoodsPrimePrice
			,[Goods].[SalePrice] AS GoodsSalePrice
			,[Goods].[Prepay] AS GoodsPrepay
			,[Goods].[Discount] AS GoodsDiscount
			,[Goods].[Desc] AS GoodsDesc
			,[Goods].[Paid] AS GoodsPaid
			,[Goods].[CreatedDate] AS GoodsCreatedDate
			,[Goods].[SaledDate] AS GoodsSaledDate
			,[Goods].[ConsignStartDate] AS GoodsConsignStartDate
			,[Goods].[ConsignEndDate] AS GoodsConsignEndDate
			,[Goods].[UpdatedDate] AS GoodsUpdatedDate
			,[PurchaseRecord].[Id] AS PurchaseRecordId
			,[PurchaseRecord].[UserId] AS PurchaseRecordUserId
			,[PurchaseRecord].[PayType] AS PurchaseRecordPayType
			,[PurchaseRecord].[Remark] AS PurchaseRecordRemark
			,[PurchaseRecord].[Operator] AS PurchaseRecordOperator
			,ISNULL([SR].[Id],0) AS SaledRecordId
			,ISNULL([SR].[GoodsId],0) AS SaledRecordGoodsId
			,ISNULL([SR].[UserId],0) AS SaledRecordUserId
			,ISNULL([SR].[PayType],0) AS SaledRecordPayType
			,[SR].[Remark] AS SaledRecordRemark
			,[SR].[CustomerName] AS SaledRecordCustomerName
			,[SR].[CustomerPhone] AS SaledRecordCustomerPhone
			,[SR].[Operator] AS SaledRecordOperator
			,[SR].[PayCharge] AS SaledRecordPayCharge
			,[SR].[BatchId] AS SaledRecordBatchId
	FROM [Goods]
	LEFT JOIN [PurchaseRecord] 
	ON [Goods].[Id] = [PurchaseRecord].[GoodsId] 	
	LEFT JOIN (SELECT SRINFO.* FROM (SELECT MAX(Id)as MaxId FROM SaledRecord GROUP BY GoodsId) AS SRMAXIDs
				LEFT JOIN [SaledRecord] AS SRINFO
				ON SRMAXIDs.MaxId=SRINFO.Id			
	) AS SR 
	ON [Goods].[Id] = [SR].[GoodsId]
	WHERE 
		--AND [Supplier].[Phone] = CASE WHEN @SupplierPhone is NULL THEN [Supplier].[Phone] ELSE @SupplierPhone END
		[Goods].[CategoryId] = CASE WHEN @GoodsCategoryId is NULL THEN [Goods].[CategoryId] ELSE @GoodsCategoryId END		
		AND [Goods].[Name] LIKE '%' +  CASE WHEN @GoodsName is NULL THEN [Goods].[Name] ELSE @GoodsName END + '%'
		AND [Goods].[Code] LIKE '%' + CASE WHEN @GoodsCode is NULL THEN [Goods].[Code] ELSE @GoodsCode END + '%'
		AND [Goods].[Status] = CASE WHEN @GoodsStatus is NULL THEN [Goods].[Status] ELSE @GoodsStatus END
		AND [Goods].[Paid] = CASE WHEN @GoodsPaid is NULL THEN [Goods].[Paid] ELSE @GoodsPaid END
		AND [Goods].[SourceType] = CASE WHEN @GoodsSourceType is NULL THEN [Goods].[SourceType] ELSE @GoodsSourceType END
		--,@StartDate datetime = null --更新开始时间
		--,@EndDate datetime = null --更新结束时间
		AND [Goods].[UpdatedDate] >= CASE WHEN @StartDate is NULL THEN [Goods].[UpdatedDate] ELSE CONVERT(varchar(10),  @StartDate, 23) END
		AND [Goods].[UpdatedDate] <= CASE WHEN @EndDate is NULL THEN [Goods].[UpdatedDate] ELSE CONVERT(varchar(10),DATEADD(DAY, 1, @EndDate), 23) END
		--,@SalesStartDate datetime = null -- 售出开始时间
		--,@SalesEndDate datetime = null -- 售出结束时间
		AND ISNULL([Goods].[SaledDate],@minDate) >= CASE WHEN @SalesStartDate is NULL THEN ISNULL([Goods].[SaledDate],@minDate) ELSE CONVERT(varchar(10),  @SalesStartDate, 23) END
		AND ISNULL([Goods].[SaledDate],@minDate) <= CASE WHEN @SalesEndDate is NULL THEN ISNULL([Goods].[SaledDate],@minDate) ELSE CONVERT(varchar(10),DATEADD(DAY, 1, @SalesEndDate), 23) END
		
		--,@ConsignStartStartDate datetime=null--寄售开始的起始时间
		--,@ConsignStartEndDate datetime=null--寄售开始的结束时间
		--,@ConsignEndStartDate datetime=null--寄售结束的开始时间
		--,@ConsignEndEndDate datetime=null--寄售结束的结束时间
		--AND ISNULL([Goods].[ConsignEndDate],@minDate) >= CASE WHEN @ConsignEndStartDate is NULL THEN ISNULL([Goods].[ConsignEndDate],@minDate) ELSE CONVERT(varchar(10),  @StartDate, 23) END
		--AND ISNULL([Goods].[ConsignEndDate],@minDate) <= CASE WHEN @ConsignEndEndDate is NULL THEN ISNULL([Goods].[ConsignEndDate],@minDate) ELSE CONVERT(varchar(10),DATEADD(DAY, 1, @EndDate), 23) END
		
			
	
		ORDER BY [Goods].[UpdatedDate] DESC
END

GO
 --0"未知", 1"在库", 2"预定", 3"售出", 4"取回" 
 --1寄售,2进货
 --1打款,2未打款
 --待打款、超半年、库存
/****** Script for SelectTopNRows command from SSMS  ******/
if (exists (select * from sys.objects where name = 'uspGetDashboardTotal'))
    drop proc uspGetDashboardTotal
go

Create Proc [dbo].[uspGetDashboardTotal]
@TimeOutDaySpan int =180
,@StartDate datetime=null
,@EndDate datetime=null
as begin

SELECT 
sum(case when SourceType=2 and Status=3 and Paid=2 then 1 else 0 end) as JHWeiDaKuan
,sum(case when SourceType=2 and Status=1 and UpdatedDate<= DATEADD(day,-180, GETDATE()) then 1 else 0 end) as JHChaoQi
,sum(case when SourceType=2 and Status=1 then 1 else 0 end) as JHKuCun
,sum(case when SourceType=1 and Status=3 and Paid=2 then 1 else 0 end) as JSWeiDaKuan
,sum(case when SourceType=1 and Status=1 and ConsignEndDate<=GETDATE() then 1 else 0 end) as JSChaoQi
,sum(case when SourceType=1 and Status=1 then 1 else 0 end) as JSKuCun
,SUM(case when CreatedDate Between ISNULL(@StartDate,CreatedDate) and ISNULL(@StartDate,CreatedDate) then 1 else 0 end) as JinHuoLiang
,SUM(case when SaledDate Between ISNULL(@StartDate,SaledDate) and ISNULL(@StartDate,SaledDate) then 1 else 0 end) as XiaoShouLiang
FROM [V2IMSDB].[dbo].[Goods]

end