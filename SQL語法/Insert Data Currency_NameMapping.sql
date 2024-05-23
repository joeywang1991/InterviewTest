SELECT TOP (1000) *
  FROM [master].[dbo].[Currency_NameMapping]

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('USD', 'zh-tw', N'美元', 'yyyy/MM/dd HH:mm:ss', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('GBP','zh-tw', N'英鎊', 'yyyy/MM/dd HH:mm:ss', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('EUR','zh-tw', N'歐元', 'yyyy/MM/dd HH:mm:ss', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('Bitcoin','zh-tw', N'比特幣', 'yyyy/MM/dd HH:mm:ss', GETDATE(), GETDATE())

  --泰文
    INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('USD', 'th', N'ดอลล่าร์', 'dd/MM/yyyy HH:mm:ss', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('GBP','th', N'ปอนด์', 'dd/MM/yyyy HH:mm:ss', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('EUR','th', N'ยูโร', 'dd/MM/yyyy HH:mm:ss', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('Bitcoin','th', N'บิทคอยน์', 'dd/MM/yyyy HH:mm:ss', GETDATE(), GETDATE()) 	
 