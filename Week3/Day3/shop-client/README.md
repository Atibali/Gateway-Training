# ShopClient

This Angular client is a working product catalog using the ASP.NET Core Products API.
It demonstrates reactive forms, components and templates, dependency-injected
services, route parameters, `HttpClient`, an HTTP interceptor, and Angular Material.

## Run locally

1. Start `Week3/Day2/ProductsApi` with its `http` launch profile. It listens at
   `http://localhost:5024`; configure its SQL Server connection string before running.
2. From this folder, run `npm install` once and then `npm start`.
3. Open `http://localhost:4200`. The API allows this origin in the ASP.NET Core
   Development environment.

The client API URL in `src/app/core/product.service.ts` matches
`ProductsApi/Properties/launchSettings.json`.

## Where to look

| Angular concept | Example |
|---|---|
| Components and templates | `src/app/product-list/`, `src/app/product-details/` |
| Reactive forms and validation | `src/app/product-form/` |
| Services and dependency injection | `src/app/core/product.service.ts` |
| Routing and route parameters | `src/app/app.routes.ts`, product detail/edit components |
| `HttpClient` and interceptors | `src/app/core/`, registered in `src/app/app.config.ts` |
| Angular Material | Material form fields, cards, buttons, and spinner |

The interceptor logs HTTP failures and rethrows them. Each page can therefore show
a useful message without hiding the original request error.

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 21.2.30.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Vitest](https://vitest.dev/) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.
