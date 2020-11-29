# Role Play Game

Dot Net Core Web API

## Packages

1. AutoMapper
    ```sh
    dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
    ```
1. EntityFrameworkCore
    ```sh
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```
1. Using EntityFrameworkCore
    ```sh
    dotnet ef migrations add InitialCreate
    dotnet ef dbContext list
    dotnet ef migrations add InitialCreate --context DataContext ## if more than two dbContext exists
    dotnet ef database update --context DbContext
    ```