# dotnet-minimal-apis

Commands used to setup this solution

```
dotnet new classlib -n DotNetApis.Shared
dotnet new web -n DotNetApis.MinimalApi
dotnet new webapi -n DotNetApis.WebApi
dotnet new sln -n DotNetApis
dotnet sln add .\DotNetApis.Shared\DotNetApis.Shared.csproj
dotnet sln add .\DotNetApis.MinimalApi\DotNetApis.MinimalApi.csproj
dotnet sln add .\DotNetApis.WebApi\DotNetApis.WebApi.csproj
.\DotNetApis.MinimalApi.sln
```