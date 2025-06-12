# Apartments Allocation Helper

Apartments Allocation Helper is a Windows desktop application that helps property managers track apartment projects and unit occupation. It is built with WPF on top of .NET Framework 4.6.1 and uses Entity Framework Core for data access.

## Features
- User login screen.
- Manage projects and towers.
- Import client data from an Access database.
- Assign and cancel apartment occupation for clients.
- View clients and generate detailed reports:
  - Clients with occupied apartments
  - Clients without occupation
  - Empty apartments
- Built in manual page and Windows setup project for creating an installer.

## Repository layout
- **ApartmentsAllocationHelper** – main WPF application source.
- **ApartmentHelperSetup** – Visual Studio setup project for packaging the app.
- **ApartmentsAllocationHelper.sln** – Visual Studio solution file that contains both projects.

## Building
1. Open `ApartmentsAllocationHelper.sln` with Visual Studio 2017 or later.
2. Restore NuGet packages when prompted.
3. Update the database connection string in `Properties/Settings.settings` to match your SQL Server instance.
4. Build the solution to produce the application binaries.
5. (Optional) Build the `ApartmentHelperSetup` project if you need an installer.

## Requirements
- .NET Framework 4.6.1
- SQL Server database named `ApartmentDeliveryDb` or a custom connection string

## Running
Run the built `ApartmentsAllocationHelper.exe` from the `bin` directory or start debugging from Visual Studio. Log in using credentials stored in your database, then start managing projects, towers and client occupation records.

