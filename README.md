# .NET6 and the power of Minimal APIs

Small setup where the differences between a regular Web API and the .NET6 Minimal API is visible.

## Setup

Project consist of three projects.

* DotNetApis.Shared
  *Library consist of the shared logic which isn't required to setup either a Web API or Minimal API. It consist of services, models, filters and custom exceptions.*

* DotNetApis.WebApi
  *Web application where setup of controllers is setup in it's own class.*

* DotNetApis.MinimalApi
  *Web application with the setup of endpoints in the main program of the application.*

### Swagger

Both web applications have Swagger integrated. And are accesible via the following URLs.

* DotNetApis.WebApi
  * https://localhost:7001/swagger/inex.html
  * http://localhost:5001/swagger/inex.html

* DotNetApis.MinimalApi
  * https://localhost:7002/swagger/inex.html
  * http://localhost:5002/swagger/inex.html

### Commands

The following commands are executed in order to get this current setup.

* Generate the projects.
  ```
  dotnet new classlib -n DotNetApis.Shared
  dotnet new webapi -n DotNetApis.WebApi
  dotnet new web -n DotNetApis.MinimalApi
  ```

* Generate the solution and link the projects to it.
  ```
  dotnet new sln -n DotNetApis
  dotnet sln add .\DotNetApis.Shared\DotNetApis.Shared.csproj
  dotnet sln add .\DotNetApis.MinimalApi\DotNetApis.MinimalApi.csproj
  dotnet sln add .\DotNetApis.WebApi\DotNetApis.WebApi.csproj
  ```

* Open the solution
  ```
  .\DotNetApis.MinimalApi.sln
  ```

## How to run

To start one (or both) of the web applications, execute the following commands.

* DotNetApis.WebApi
  ```
  dotnet run -c Debug --project .\DotNetApis.WebApi\
  ```

* DotNetApis.MinimalApi
  ```
  dotnet run -c Debug --project .\DotNetApis.MinimalApi\
  ```