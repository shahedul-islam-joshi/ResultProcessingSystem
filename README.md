# Result Processing System

A robust ASP.NET Core MVC application designed to manage student records with a focus on clean architecture and performance.

## ?? Key Features

* **Async CRUD Operations**: Fully asynchronous data handling using Entity Framework Core to ensure high scalability and non-blocking UI.
* **Repository Pattern**: Implements a clean separation of concerns between the data access layer and business logic, making the code testable and maintainable.
* **Dynamic Image Handling**: Supports uploading and displaying student profile pictures stored as byte arrays (BLOB) in SQL Server.
* **Strict Form Validation**:
    * **Server-Side**: Using \ModelState\ and Data Annotations to protect database integrity.
    * **Client-Side**: Real-time validation using jQuery Unobtrusive Validation for a better user experience.
* **Responsive UI**: Built with Bootstrap 5, featuring interactive Modals for delete confirmations and a clean dashboard for student listings.

## ??? Tech Stack
* **Framework**: ASP.NET Core 9.0 MVC
* **Database**: SQL Server (LocalDB)
* **ORM**: Entity Framework Core
* **Frontend**: Bootstrap 5, Razor Views, jQuery

## ?? How to Run

1.  **Clone the repository**:
    \\\ash
    git clone https://github.com/shahedul-islam-joshi/ResultProcessingSystem.git
    \\\
2.  **Configure Database**:
    Update the \DefaultConnection\ string in \ppsettings.json\ to point to your local SQL Server instance.
3.  **Apply Migrations**:
    Open the Package Manager Console and run:
    \\\powershell
    Update-Database
    \\\
4.  **Launch**:
    Press \F5\ in Visual Studio or run \dotnet run\ in the terminal.
