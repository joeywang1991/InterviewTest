SELECT TOP (1000) *
  FROM [master].[dbo].[Currency_NameMapping]

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('USD', 'zh-tw', N'美元', 'yyyy/mm/dd hh:mm:ss.mmm', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('GBP','zh-tw', N'英鎊', 'yyyy/mm/dd hh:mm:ss.mmm', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('EUR','zh-tw', N'歐元', 'yyyy/mm/dd hh:mm:ss.mmm', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('Bitcoin','zh-tw', N'比特幣', 'yyyy/mm/dd hh:mm:ss.mmm', GETDATE(), GETDATE())

  --泰文
    INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('USD', 'th', N'ดอลล่าร์', 'dd/mm/yyyy hh:mm:ss.mmm', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('GBP','th', N'ปอนด์', 'dd/mm/yyyy hh:mm:ss.mmm', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('EUR','th', N'ยูโร', 'dd/mm/yyyy hh:mm:ss.mmm', GETDATE(), GETDATE())

  INSERT INTO Currency_NameMapping(CurrencyName, [Language], CurrencyCName, TimeFormat, Createtime, UpdateTime)
  VALUES('Bitcoin','th', N'บิทคอยน์', 'dd/mm/yyyy hh:mm:ss.mmm', GETDATE(), GETDATE()) 	
 