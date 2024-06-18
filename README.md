# Проект ASP.NET Core з використанням MySQL та Entity Framework Core

##  Підготовка бази даних

```sql
CREATE DATABASE finance;

USE finance;

CREATE TABLE Users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    address VARCHAR(255)
);

CREATE TABLE Incomes (
    income_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    amount DECIMAL(10, 2) NOT NULL,
    date DATE NOT NULL,
    source VARCHAR(255),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

CREATE TABLE Expenses (
    expense_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    amount DECIMAL(10, 2) NOT NULL,
    date DATE NOT NULL,
    category_id INT,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);
```

## Встановлення інструментів для Database First

```powershell
dotnet add package Microsoft.EntityFrameworkCore --version 6.*
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.*
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.*

dotnet tool install --global dotnet-ef --version 7.0.15
```

## Створення проекту ASP.NET Core

```powershell
dotnet new webapp -o ormApp
cd ormApp
```

## Генерація моделей за допомогою Scaffold-DbContext
```
dotnet ef dbcontext scaffold "Server=localhost;Database=finance;User ID=svc_finance;Password=passw0rd;" Pomelo.EntityFrameworkCore.MySql -o Models

##  Запуск проекту
dotnet run
