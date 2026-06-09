# Project Entity Framework Core

Учебный проект по изучению EF Core и работы с SQL Server

## Requirements (Требования)

- .NET 8
- SQL Server Express
- SQL Server Management Studio (optional)

## Database Configuration (Настройка базы данных)

By default the application uses a local SQL Server Express instance:

```csharp
Server=localhost\SQLEXPRESS;
Database=El_library;
Trusted_Connection=True;
TrustServerCertificate=True;
```

If your SQL Server instance has a different name, update the connection string in AppContext.cs.

## Running the Application (Запуск приложения)

1. Open the solution in Visual Studio.
2. Build the project.
3. Run Project_Entity_Framework_Core.

The database will be created automatically on startup using Entity Framework Core.