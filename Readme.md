# Role Play Game

Dot Net Core Web API

## Packages

1. AutoMapper
    ```powershell
    dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
    ```
1. EntityFrameworkCore
    ```powershell
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```
1. Using EntityFrameworkCore
    1. Relationships
        1. One to One (Character / Weapon)
        1. One to Many (User / Character)
        1. Many to Many (Character / Skill)
    1. Joining entity & Fluent API
    1. Include entity with LINQ queries
    1. EF Scripts
    ```powershell
    dotnet ef migrations add InitialCreate
    dotnet ef dbContext list
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```
1. Using JWT Token
    ```powershell
    dotnet add package Microsoft.IdentityModel.Tokens
    dotnet add package System.IdentityModel.Tokens.Jwt
    dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
    ```
    > Use https://jwt.io/ to debug the token
## .Net Core commands
  ```powershell
    dotnet list packages
    dotnet add package <package-name> ## to update package individually
  ```
## Swagger UI

1. Use Swagger UI to test the application APIs
1. Path `/swagger/index.html`
1. Login and retrieve an API token and which can be used in **Authorize** - top right corner of the Swagger UI
1. This will add the authorization token for all consecutive requests