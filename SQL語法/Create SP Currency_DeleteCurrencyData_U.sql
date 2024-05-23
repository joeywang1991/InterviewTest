USE [master]
GO

CREATE PROCEDURE Currency_DeleteCurrencyData_U
	@Currency	VARCHAR(10)
AS
BEGIN
	DECLARE @CurrencyID BIGINT

	SELECT @CurrencyID = CurrencyID
	FROM dbo.Currency_Info
	WHERE CurrencyName = @Currency

	DELETE dbo.Currency_Info
	WHERE CurrencyID = @CurrencyID AND CurrencyName <> 'Bitcoin'

	DELETE dbo.Currency_ExchangeRate
	WHERE CurrencyID = @CurrencyID

END