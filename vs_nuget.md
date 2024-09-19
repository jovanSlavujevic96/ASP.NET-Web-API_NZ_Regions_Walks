Install packages
- Micorosft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

Open Nuget *Package Manager Console* and run:
```bash
# it reads the DB context and it's creating DB sets which are tables in SQL Server
$ Add-Migration "Name Of Migration" 

# it reads Migration and connects to the database, sees what's missing and create it
Update-Database
```
Add-Migration creates SQL tables and columns for us out of Models