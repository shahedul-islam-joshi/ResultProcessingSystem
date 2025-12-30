# Result Processing System 🎓

A robust **ASP.NET Core 8.0 MVC** application designed to manage student records and academic performance. This system serves as the core module for handling student registrations, profile management, and serves as the foundation for automated GPA calculation.

---

## 🚀 Key Features

* **Complete Student CRM**: Full Create, Read, Update, and Delete (CRUD) functionality.
* **Binary Image Storage**: Upload and store profile pictures directly in SQL Server as `byte[]` (VARBINARY).
* **Clean Architecture**: Implementation of the **Repository Pattern** to decouple data access from the controller.
* **Strongly Typed Views**: Utilizes dedicated **ViewModels** (`AddStudentRequest`, `EditStudentRequest`) for secure data handling and validation.
* **Responsive UI**: Styled with **Bootstrap 5**, featuring a modern dashboard, modal-based deletions, and mobile-friendly tables.
* **Async/Await Pipeline**: Fully asynchronous data flow for high-performance database operations.

---

## 🏗️ Project Architecture

The project follows a tiered MVC structure to ensure scalability:

| Layer | Responsibility |
| :--- | :--- |
| **Models.Domain** | Database entities (the `Student` class). |
| **Models.ViewModel** | Data Transfer Objects (DTOs) for form submissions and validation. |
| **Repository** | Data access logic (Interface + Implementation). |
| **Controllers** | Request handling and business workflow orchestration. |
| **Views** | Razor-based UI templates. |

---

## 🛠️ Technical Stack

* **Backend**: .NET 8.0 (C#)
* **Database**: Entity Framework Core / SQL Server
* **Frontend**: Razor Views, Bootstrap 5, jQuery Validation
* **Pattern**: Repository Pattern & Dependency Injection

---

## ⚙️ Setup & Installation

1.  **Clone the Repository**:
    ```bash
    git clone [https://github.com/your-username/ResultProcessingSystem.git](https://github.com/your-username/ResultProcessingSystem.git)
    ```

2.  **Database Configuration**:
    Update your `appsettings.json` with your local SQL connection string:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ResultSystemDb;Trusted_Connection=True;TrustServerCertificate=True"
    }
    ```

3.  **Dependency Injection**:
    Ensure the repository is registered in `Program.cs`:
    ```csharp
    builder.Services.AddScoped<IStudentRepo, StudentRepo>();
    ```

4.  **Run Migrations**:
    Open the Package Manager Console and run:
    ```powershell
    Add-Migration InitialCreate
    Update-Database
    ```

---

## 📊 Result & GPA Calculation (Module Preview)

The system is designed to calculate GPA based on the following standard academic weightage:

$$GPA = \frac{\sum (Course\ Credit \times Grade\ Point)}{\sum Total\ Credits}$$

### Grade Mapping Logic:
* **80% - 100%**: A+ (4.00)
* **75% - 79%**: A (3.75)
* **70% - 74%**: A- (3.50)
* *...and so on.*

---

## 📸 Interface Preview

* **Student List**: Displays thumbnails of students with quick action buttons.
* **Add Student**: Includes a file picker for `IFormFile` profile images.
* **Delete Confirmation**: A safety modal to prevent accidental data loss.

---

## 🤝 Contributing

1. Fork the project.
2. Create your Feature Branch (`git checkout -b feature/GpaCalculation`).
3. Commit your changes (`git commit -m 'Add GPA logic'`).
4. Push to the Branch (`git push origin feature/GpaCalculation`).
5. Open a Pull Request.