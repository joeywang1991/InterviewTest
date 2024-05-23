USE [master]
GO

CREATE TYPE CurrentInfoType AS TABLE
(
    [CurrencyName] VARCHAR(10),
    [Symbol] VARCHAR(10),
	[Rate] DECIMAL(18, 6),
	[Description] NVARCHAR(100),
	[ExchangeCurrencyName] VARCHAR(10)
);
GO

CREATE PROCEDURE Currency_UpdateCurrencyInfo_U
    @CurrentInfoList CurrentInfoType READONLY
AS
BEGIN

	-- 找出Currency_Info需要Insert或Update資料
	SELECT 
		CIL.CurrencyName AS 'CurrencyName'
		,CIL.Symbol AS 'Symbol'
		,CIL.[Description] AS 'Description'
		,CASE WHEN CI.CurrencyName IS NULL THEN 'Y' ELSE 'N' END AS 'IsNew'
	INTO #CIData
	FROM @CurrentInfoList CIL
	LEFT JOIN dbo.Currency_Info CI	--檢核 資料是否存在
	ON CIL.CurrencyName = CI.CurrencyName	

	-- 沒有資料就新增
    INSERT INTO dbo.Currency_Info(CurrencyName, Symbol, [Description], CreateTime, UpdateTime)
    SELECT D.CurrencyName, D.Symbol, D.[Description], GETDATE(), GETDATE()
    FROM #CIData D
	WHERE D.IsNew = 'Y'	

	-- 有資料就更新	
	UPDATE dbo.Currency_Info 
	SET Symbol = D.Symbol,
		[Description] = D.[Description],
		UpdateTime = GETDATE()
	FROM dbo.Currency_Info CI
	INNER JOIN #CIData D  --檢核Currency_Info存在資料就更新
	ON CI.CurrencyName = D.CurrencyName
	WHERE D.IsNew = 'N'


	-- 找出Currency_ExchangeRate需要Insert或Update資料
	SELECT 
		CI.CurrencyID AS 'CurrencyID'
		,EXCI.CurrencyID AS 'ExchangeCurrencyID'
		,CIL.Rate AS 'ExchangeRate'
		,CASE WHEN CER.CurrencyID IS NULL AND CER.ExchangeCurrencyID IS NULL THEN 'Y' ELSE 'N' END AS 'IsNew'
	INTO #CEXData 
	FROM @CurrentInfoList CIL
	INNER JOIN dbo.Currency_Info CI		--取得其他幣別ID
	ON CIL.CurrencyName = CI.CurrencyName
	INNER JOIN dbo.Currency_Info EXCI	--取得比特幣ID
	ON CIL.ExchangeCurrencyName = EXCI.CurrencyName
	LEFT JOIN Currency_ExchangeRate CER --檢核 資料是否存在
	ON CI.CurrencyID = CER.CurrencyID AND EXCI.CurrencyID = CER.ExchangeCurrencyID

	-- 沒有資料就新增
	INSERT INTO dbo.Currency_ExchangeRate(CurrencyID, ExchangeCurrencyID, ExchangeRate, CreateTime, UpdateTime)
	SELECT D.CurrencyID, D.ExchangeCurrencyID, D.ExchangeRate, GETDATE(), GETDATE()
	FROM #CEXData D
	WHERE D.IsNew = 'Y'	

	-- 有資料就更新
	UPDATE dbo.Currency_ExchangeRate
	SET ExchangeRate = D.ExchangeRate,
		UpdateTime = GETDATE()
	FROM dbo.Currency_ExchangeRate CER
	INNER JOIN #CEXData D
	ON CER.CurrencyID = D.CurrencyID AND CER.ExchangeCurrencyID = D.ExchangeCurrencyID
	WHERE D.IsNew = 'Y'

	DROP TABLE #CIData
	DROP TABLE #CEXData
END