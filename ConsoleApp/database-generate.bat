dotnet new tool-manifest
dotnet tool install dotnet-ef
dotnet ef dbcontext scaffold "Server=localhost;Database=OrdersDB;Trusted_Connection=True;" "Microsoft.EntityFrameworkCore.SqlServer" --context OrderDBContext --context-dir Database --output-dir Models
