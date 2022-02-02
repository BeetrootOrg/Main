dotnet new tool-manifest
dotnet tool install dotnet-ef
dotnet ef dbcontext scaffold "Server=localhost;Database=BookLibraryDB;Trusted_Connection=True;" "Microsoft.EntityFrameworkCore.SqlServer" --context BookLibraryDBContext --context-dir Database --output-dir Models
dotnet ef migrations add Initial
dotnet ef database update