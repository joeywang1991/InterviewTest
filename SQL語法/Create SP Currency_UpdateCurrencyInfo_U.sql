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

	-- ��XCurrency_Info�ݭnInsert��Update���
	SELECT 
		CIL.CurrencyName AS 'CurrencyName'
		,CIL.Symbol AS 'Symbol'
		,CIL.[Description] AS 'Description'
		,CASE WHEN CI.CurrencyName IS NULL THEN 'Y' ELSE 'N' END AS 'IsNew'
	INTO #CIData
	FROM @CurrentInfoList CIL
	LEFT JOIN dbo.Currency_Info CI	--�ˮ� ��ƬO�_�s�b
	ON CIL.CurrencyName = CI.CurrencyName	

	-- �S����ƴN�s�W
    INSERT INTO dbo.Currency_Info(CurrencyName, Symbol, [Description], CreateTime, UpdateTime)
    SELECT D.CurrencyName, D.Symbol, D.[Description], GETDATE(), GETDATE()
    FROM #CIData D
	WHERE D.IsNew = 'Y'	

	-- ����ƴN��s	
	UPDATE dbo.Currency_Info 
	SET Symbol = D.Symbol,
		[Description] = D.[Description],
		UpdateTime = GETDATE()
	FROM dbo.Currency_Info CI
	INNER JOIN #CIData D  --�ˮ�Currency_Info�s�b��ƴN��s
	ON CI.CurrencyName = D.CurrencyName
	WHERE D.IsNew = 'N'


	-- ��XCurrency_ExchangeRate�ݭnInsert��Update���
	SELECT 
		CI.CurrencyID AS 'CurrencyID'
		,EXCI.CurrencyID AS 'ExchangeCurrencyID'
		,CIL.Rate AS 'ExchangeRate'
		,CASE WHEN CER.CurrencyID IS NULL AND CER.ExchangeCurrencyID IS NULL THEN 'Y' ELSE 'N' END AS 'IsNew'
	INTO #CEXData 
	FROM @CurrentInfoList CIL
	INNER JOIN dbo.Currency_Info CI		--���o��L���OID
	ON CIL.CurrencyName = CI.CurrencyName
	INNER JOIN dbo.Currency_Info EXCI	--���o��S��ID
	ON CIL.ExchangeCurrencyName = EXCI.CurrencyName
	LEFT JOIN Currency_ExchangeRate CER --�ˮ� ��ƬO�_�s�b
	ON CI.CurrencyID = CER.CurrencyID AND EXCI.CurrencyID = CER.ExchangeCurrencyID

	-- �S����ƴN�s�W
	INSERT INTO dbo.Currency_ExchangeRate(CurrencyID, ExchangeCurrencyID, ExchangeRate, CreateTime, UpdateTime)
	SELECT D.CurrencyID, D.ExchangeCurrencyID, D.ExchangeRate, GETDATE(), GETDATE()
	FROM #CEXData D
	WHERE D.IsNew = 'Y'	

	-- ����ƴN��s
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