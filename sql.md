SQL Server Instance Data:
- Server=localhost;
- Database=master;
- Trusted_Connection=True;

Example command to read out from table:
```bash
SELECT TOP (1000) [Id]
      ,[Code]
      ,[Name]
      ,[RegionImageUrl]
  FROM [NZWalksDb].[dbo].[Regions]
```

Example command to put into table:
```bash
Insert into Regions ([Id],[Code],[Name],[RegionImageUrl])
    values ('d164ca1d-deb7-4a77-86c5-fb9a7148c835', 'AKL', 'Auckland', 'some-image-url.jpg');
```
 