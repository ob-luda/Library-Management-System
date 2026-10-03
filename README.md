# Library Management System

An ASP.NET Core 8.0 MVC web application designed for managing library book catalogs, circulation history, and administrative authentication.

---

## 🌟 Key Features

### 🔐 1. Authentication & Security
* **Cookie-Based Authentication**: Secure cookie authentication scheme with sliding session expiration (8-hour duration).
* **Global Authorization Filter**: All endpoints require user authentication by default (`AuthorizeFilter`).
* **Session Management**: Dedicated login (`/Account/Login`) and logout routines with return URL redirection.
* **Anti-Forgery Security**: Anti-XSRF token validation (`[ValidateAntiForgeryToken]`) implemented on form submissions.

### 📊 2. Library Dashboard
* **Real-Time Catalog Metrics**:
  * Total book titles in system.
  * Number of titles currently available for checkout.
  * Number of titles on loan.
  * Tracked overdue entries.
* **System Activity Summaries**: Displays the most recently added book title and the most recent circulation loan activity.

### 📚 3. Book Catalog Management
* **Catalog Inventory Listing**: Complete overview of books sorted by catalog Call Number.
* **Book Properties Tracked**:
  * Call Number (e.g., Dewey Decimal / Library Classification)
  * Title & Author
  * Total Copy Count
  * Availability Status (`Available` vs `On-Loan`)
* **Add New Book**: Interactive form to add new books to the catalog with model validation and default availability assignment.

### 🔄 4. Circulation & Borrowing Log
* **Borrowing History Log**: Chronologically sorted list of borrowing records (most recent first).
* **Record Details**:
  * Book Title
  * Borrower Name
  * Issue Date (Borrowed Date)
  * Due Date
  * Return / Circulation Status (`BORROWED`, `RETURNED`)

### 💾 5. Data & Persistence
* **Entity Framework Core 8**: Database abstraction via `LibraryContext`.
* **In-Memory Database**: Seeded automatically at application startup with default book collections and circulation logs.
* **SQL Server Compatibility**: Pre-configured EF Core packages ready for SQL Server integration.

---

## 🛠️ Technology Stack

* **Framework**: .NET 8.0 / ASP.NET Core MVC
* **ORM**: Entity Framework Core 8.0 (`Microsoft.EntityFrameworkCore.InMemory`)
* **Authentication**: ASP.NET Core Cookie Authentication
* **Language**: C# 12

---

## 🔑 Demo Credentials

To access the administrative features of the application, use the following demo credentials:

* **Credential ID / Email**: `librarian@library.system`
* **Passphrase**: `archive123`

---

## 📂 Project Structure

```
C#/
└── LibraryMDB/
    ├── Controllers/
    │   ├── AccountController.cs    # Authentication & Session control
    │   ├── BooksController.cs      # Book catalog listing & creation
    │   ├── BorrowController.cs     # Borrowing history & circulation records
    │   └── HomeController.cs       # Dashboard analytics & home views
    ├── Data/
    │   └── LibraryContext.cs       # EF Core DbContext definition
    ├── Models/
    │   ├── Book.cs                 # Book entity schema
    │   ├── BorrowRecord.cs         # Circulation record schema
    │   ├── HomeIndexViewModel.cs   # Dashboard view model
    │   └── LoginViewModel.cs       # Authentication view model
    ├── Views/                      # Razor HTML Views
    ├── Program.cs                  # App bootstrapping, DI & data seeding
    └── LibraryManagement.csproj    # Project dependencies & configuration
```

---

## 🚀 Getting Started

### Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your system.

### Running the Application

1. Navigate to the project directory:
   ```bash
   cd LibraryMDB
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

3. Open your browser and navigate to `https://localhost:7049` or the port displayed in your terminal.
