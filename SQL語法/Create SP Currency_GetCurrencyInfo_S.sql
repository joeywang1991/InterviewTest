USE [master]
GO

CREATE PROCEDURE Currency_GetCurrencyInfo_S
	@Currency VARCHAR(10),
	@Language VARCHAR(5)
AS
BEGIN

	DECLARE @CurrencyID BIGINT

	SELECT @CurrencyID = CurrencyID
	FROM Currency_Info CI
	WHERE CurrencyName = @Currency

	SELECT 
		CI.CurrencyName AS 'CurrencyName'
		,NM.CurrencyCName AS 'CurrencyCName' 
		,EXCI.CurrencyName AS 'ExchangeCurrencyName' 
		,EXNM.CurrencyCName AS 'ExchangeCurrencyCName'
		,ExchangeRate AS 'ExchangeRate'
		,FORMAT(GETDATE(), EXNM.TimeFormat) AS 'UpdateTime'
	FROM dbo.Currency_ExchangeRate ER
	INNER JOIN dbo.Currency_Info CI 
	ON ER.CurrencyID = CI.CurrencyID
	INNER JOIN Currency_NameMapping NM 
	ON CI.CurrencyName = NM.CurrencyName AND NM.[Language] = @Language
	INNER JOIN dbo.Currency_Info EXCI 
	ON ER.ExchangeCurrencyID = EXCI.CurrencyID
	INNER JOIN Currency_NameMapping EXNM 
	ON EXCI.CurrencyName = EXNM.CurrencyName AND EXNM.[Language] = @Language
	WHERE (
		(@Currency = 'ALL' AND 1 = 1) OR
		(@Currency = 'Bitcoin' AND ER.ExchangeCurrencyID = @CurrencyID) OR
		(CI.CurrencyID = @CurrencyID)
	  )
	  AND EXNM.[Language] = @Language
	ORDER BY CurrencyName

END