# Movie-App-Antra-MVC

ASP.NET Core MVC MovieShop project created for **SEP Full Stack Assignment 1,2,3**.

This project demonstrates a **layered architecture** using:
- **ApplicationCore**
- **Infrastructure**
- **MVC**

The application currently shows test movie data on the home page using a reusable Razor partial view.

## Project Status

Assignment 1 completed.  
This version includes the required architecture, interfaces, service/repository implementations, controllers, and a working home page UI with movie cards.

## Architecture

The solution is divided into 3 projects:

### MovieShop.ApplicationCore
Contains the core contracts and models:
- Repository interfaces
- Service interfaces
- `MovieCardModel`

### MovieShop.Infrastructure
Contains implementation classes:
- Repository classes
- Service classes
- `MovieService` returns test movie data for the UI

### MovieShop.MVC
Presentation layer:
- Controllers
- Razor Views
- Shared Partial Views
- Bootstrap UI
- Static assets in `wwwroot`

Layered application structures are commonly used to separate UI, business logic/contracts, and implementation details, which is the pattern this assignment is asking you to demonstrate. [web:147][web:163]

## Assignment 1 Requirements Covered

- Created project architecture with:
  - `ApplicationCore`
  - `Infrastructure`
  - `MVC`

- Created repository interfaces in:
  - `ApplicationCore/Contracts/Repository`

- Created service interfaces in:
  - `ApplicationCore/Contracts/Services`

- Created repository implementation classes in:
  - `Infrastructure/Repository`

- Created service implementation classes in:
  - `Infrastructure/Services`

- Created `MovieService` to return test movie data

- Created `MovieCardModel` for Razor View usage

- Created reusable `_MovieCard.cshtml` partial view

- Displayed movie cards on the Home page

- Created the following controllers:
  - `MoviesController`
  - `UserController`
  - `AdminController`
  - `AccountController`
  - `CastController`

## Implemented Interfaces

### Repository Interfaces
- `IMovieRepository`
- `IUserRepository`
- `ICastRepository`
- `IPurchaseRepository`
- `IReportRepository`

### Service Interfaces
- `IMovieService`
- `IUserService`
- `IAccountService`
- `IGenreService`
- `IAdminService`
- `ICastService`

## Implemented Classes

### Repository Classes
- `MovieRepository`
- `UserRepository`
- `CastRepository`
- `PurchaseRepository`
- `ReportRepository`

### Service Classes
- `MovieService`
- `UserService`
- `AccountService`
- `GenreService`
- `AdminService`
- `CastService`

## Features

- ASP.NET Core MVC project structure
- Layered architecture
- Constructor-based dependency injection
- Razor Views
- Reusable partial view
- Bootstrap movie card UI
- Test movie list on home page

 

## Project Structure

```text
MovieShop
│── MovieShop.sln
│
├── MovieShop.ApplicationCore
│   ├── Contracts
│   │   ├── Repository
│   │   └── Services
│   └── Models
│
├── MovieShop.Infrastructure
│   ├── Repository
│   └── Services
│
└── MovieShop.MVC
    ├── Controllers
    ├── Views
    │   ├── Home
    │   ├── Movies
    │   ├── User
    │   ├── Admin
    │   ├── Account
    │   ├── Cast
    │   └── Shared
    └── wwwroot
```

## Technologies Used

- ASP.NET Core MVC
- C#
- Razor
- Bootstrap
- .NET CLI

## How to Run

### 1. Clone the repository

```bash
git clone https://github.com/farman-ai/Movie-App-Antra-MVC.git
cd Movie-App-Antra-MVC
```

### 2. Build the solution

```bash
dotnet build
```

### 3. Run the MVC project

```bash
dotnet run --project MovieShop.MVC
```

### 4. Open in browser

Open the localhost URL shown in the terminal.

## Notes

- This project currently uses **test movie data**.
- Database entities and EF Core implementation will be added in the next assignment.
- The home page demonstrates model binding and partial view reuse in ASP.NET Core MVC.

## Author

**Farman Haider**

## Repository

[Movie-App-Antra-MVC](https://github.com/farman-ai/Movie-App-Antra-MVC)
