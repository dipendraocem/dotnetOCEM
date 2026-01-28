# RazorApp — Students (Add, List, Delete)

This README describes how to run the app and the step-by-step process to add, list, and delete students. The instructions reference the code in this project so you can trace how each action works.

**Prerequisites**
- .NET 8 SDK installed
- Database server (MySQL by default) and a connection string in `appsettings.json` under `DefaultConnection`
- (Optional) `dotnet-ef` if you need to create migrations locally

**Run the app**
1. From the project root, run:

```bash
dotnet run
```
2. Open the browser at `https://localhost:5001` (or the URL shown in the console).

**Code map (where features live)**
- Model: `Models/Student.cs` — defines `Id`, `Name` (required) and `Email`.
- DbContext: `Data/AppDbContext.cs` — exposes `DbSet<Student> Students`.
- Startup: `Program.cs` — registers `AppDbContext` using the `DefaultConnection` in `appsettings.json`.
- List page: `Pages/Students.cshtml.cs` and `Pages/Students.cshtml` — `OnGet()` loads all students.
- Create page: `Pages/CreateStudent.cshtml.cs` and `Pages/CreateStudent.cshtml` — `OnPost()` adds a `Student` and saves changes.
- Delete page: `Pages/DeleteStudent.cshtml.cs` and `Pages/DeleteStudent.cshtml` — contains both a removal in `OnGet(int id)` and a safer `OnPost()` handler that deletes by `Student.Id`.

**Step-by-step: List students**
1. Start the app with `dotnet run`.
2. Navigate to the Students page (the project uses a Razor Page named `Students`). Typically the route is `/Students`.
3. The code that shows the list is in `Pages/Students.cshtml.cs` — the `OnGet()` method calls `_context.Students.ToList()` to populate the `Students` property which the Razor view renders.

**Step-by-step: Add a student**
1. Open the Create Student page in the browser — route `/CreateStudent` (implemented by `Pages/CreateStudent.cshtml`).
2. Fill the fields on the form: `Name` (required) and `Email`.
3. Submit the form. The handler is in `Pages/CreateStudent.cshtml.cs` — `OnPost()` checks `ModelState`, calls `_context.Students.Add(Student)`, then `_context.SaveChanges()`, and redirects to `Students`.
4. After redirecting, the `Students` page will list the newly added student.

**Step-by-step: Delete a student**
This project includes two deletion approaches in `Pages/DeleteStudent.cshtml.cs`:

- Immediate deletion (GET): `OnGet(int id)` finds the student by id and removes it, then saves and redirects. This means a GET request to `/DeleteStudent?id=123` will remove the record immediately. Use caution: deleting on GET is quick but can be unsafe (no confirmation).

- Confirmation (POST): `OnPost()` expects a bound `Student` (with `Student.Id`) and deletes that record after verifying it exists. This is the safer flow for a form-based confirmation.

To delete safely from the UI:
1. From the `Students` list, click a delete link/button that navigates to the delete confirmation page (or opens a small form with the `Student.Id`).
2. Confirm the deletion which should submit a POST to the `DeleteStudent` page; the `OnPost()` handler will call `_context.Students.Remove(...)` and `_context.SaveChanges()`.

**Database / Migrations (optional)**
If you haven't created a database schema yet, use EF Core migrations:

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Make sure the `DefaultConnection` string in `appsettings.json` points to your MySQL instance. `Program.cs` uses that connection to configure `AppDbContext`.

**Notes & pointers**
- Required field: `Name` is decorated with `[Required]` in `Models/Student.cs` — validation happens on submit.
- The main DB interaction happens through `AppDbContext.Students` (`Add`, `Find`, `Remove`, `SaveChanges`).
- If you want to change the DB provider (e.g., SQL Server), update `Program.cs` and connection configuration.
- Files to inspect for behavior details: `Pages/Students.cshtml.cs`, `Pages/CreateStudent.cshtml.cs`, `Pages/DeleteStudent.cshtml.cs`.

If you want, I can:
- Open the Razor `.cshtml` views and add example snippet screenshots or sample HTML forms.
- Add a small section with curl/Postman examples for the POST delete flow.

---

File: `README.md`

