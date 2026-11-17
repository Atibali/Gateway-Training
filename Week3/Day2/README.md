# Week 3 · Day 2

## Topics Covered

### CSS and layout practice
- Worked with selectors, classes, IDs, pseudo-classes, and pseudo-elements.
- Practiced the CSS box model, spacing, colors, fonts, and responsive units.
- Used Flexbox and CSS Grid for layout design.
- Added media queries to make pages adapt to smaller screens.
- Styled reusable cards, buttons, navigation bars, and page sections.

### ASP.NET Core API basics
- Built a simple API with controllers and route-based endpoints.
- Learned how to return JSON responses and handle status codes such as `200 OK`, `201 Created`, and `404 Not Found`.
- Created a CRUD-style product API using `Entity Framework Core` and SQL Server.
- Added Swagger for API documentation and testing.

### Front-end practice
- `css-practice.html` demonstrates core CSS styling and layout concepts.
- `style.css` contains examples for selectors, colors, spacing, buttons, Flexbox, Grid, and responsive design.

### Fruit API
- `FruitsApi` is a lightweight REST API that returns a static list of fruits.
- Endpoints include:
  - `GET /api/fruits`
  - `GET /api/fruits/{id}`

### Product API
- `ProductsApi` is a more complete example using a SQL Server database.
- It includes a `Product` model, database context, controller, and request DTO.
- Endpoints include:
  - `GET /api/products`
  - `GET /api/products/{id}`
  - `POST /api/products`
  - `PUT /api/products/{id}`
  - `DELETE /api/products/{id}`

## Files in this folder

- `css-practice.html` - HTML page used for CSS exercises and layout practice
- `style.css` - styling rules for the page and responsive layout examples
- `FruitsApi/` - basic ASP.NET Core API with hardcoded fruit data
- `ProductsApi/` - CRUD API connected to SQL Server through EF Core
- `EOD-Report-17-11-26-Atibali-Saiyed.pdf` - end-of-day progress report

## Running the examples

Run the Fruit API from the repository root:

```powershell
dotnet run --project .\Week3\Day2\FruitsApi\FruitsApi.csproj
```

Run the Product API from the repository root:

```powershell
dotnet run --project .\Week3\Day2\ProductsApi\ProductsApi.csproj
```

The Product API expects a local SQL Server instance with the connection string defined in `ProductsApi/appsettings.json`.
Open the Swagger UI in a browser after launching it, typically at:

```text
https://localhost:xxxx/swagger
```

## Learning outcome

By the end of Day 2, the focus was on combining front-end styling fundamentals with backend API development, creating a practical bridge between design and application logic.
