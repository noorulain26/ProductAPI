# Product Management REST API 

A simple, secure, and clean Product API built with **ASP.NET Core (.NET 8/9)**. This project is created using **Clean Architecture** to keep the code neat, professional, and easy to maintain.

---

##  Project Structure (Folders)

The project is divided into 4 clear layers. Each layer has its own job:

### 1.  ProductAPI.Domain
This is the core layer. It only contains our database blueprints and is completely independent.
- **Entities/** (e.g., `Product.cs`) - Contains our Product database model.

### 2.  ProductAPI.Application
This is the "Brain" of the application. It contains all our business logic and data checks.
- **Interfaces/** (e.g., `IMyDbContext`, `IProductService`) - Contracts to connect different layers.
- **Dtos/** (e.g., `ProductCreatedto`, `ProductResponseDto`, `LoginDto`) - Clean boxes used to carry data in and out.
- **Validators/** (e.g., `ProductCreateValidator`) - Built with FluentValidation to check if user input is correct.
- **Mappings/** (e.g., `ProductMapping`) - Simple C# Extension Methods to convert DTOs into real Products easily.
- **Services/** (e.g., `ProductService`) - The main worker class that handles the core product logic.

### 3.  ProductAPI.Infrastructure
This layer handles the actual database connection and storage.
- **Data/** (e.g., `MyDbContext`) - Contains Entity Framework Core (EF Core) settings to talk to SQL Server.

### 4.  ProductAPI.WebAPI (Presentation)
This is the outside world layer that handles the HTTP network requests.
- **Controllers/** (`ProductController`, `AuthController`) - Managers that receive input data from the client (Postman/Frontend).
- **Middleware/** (`GlobalExceptionMiddleware`) - Our global security guard that catches any application crash and turns it into a beautiful error response.

---

##  Key Features Inside

- **JWT Token Security:** Secure login system. No one can create a product unless they log in first .
- **Global Error Handling:** A smart background middleware that catches all validation errors and system crashes automatically.
- **Input Validation:** Powered by **FluentValidation** to block bad data (like empty names or negative prices).
- **Manual Mapping:** Super-fast conversion using native C# extension methods without installing heavy libraries.
- **Live Database Migrations:** Easy table setup inside **SQL Server** using EF Core.

---

## How to Run and Test This Project Locally

Follow these simple steps to run this project on your computer:

### 1. Clone the Project
```bash
git clone https://github.com
```

### 2. Set Up Your Database Connection
Open `appsettings.json` inside the `ProductAPI.WebAPI` project and type your local SQL Server details:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ProductMarketDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Create the Database Tables
Open **Package Manager Console** in Visual Studio, select `ProductAPI.Infrastructure` in the default project drop-down, and run this single command:
```powershell
Update-Database
```

### 4. Run and Test on Postman
1. Press the **Green Play Button** in Visual Studio.
2. Open **Postman App**.
3. Send a `POST` request to `/api/Auth/login` with Username: `admin` and Password: `password123` to get your secure **JWT Token**.
4. Copy that token, go to your `/api/Product` endpoint, paste it into the **Bearer Token** section under the *Authorization* tab.
5. Send your product details in the body, and see the beautiful **`201 Created`** success status! 
