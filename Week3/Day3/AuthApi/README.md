# Auth API Practice

This practice project is an ASP.NET Core API with ASP.NET Core Identity, SQLite, JWT authentication, and role-based authorization.

## Requirements

- .NET 11 SDK
- Postman
- Windows PowerShell

## Configure the JWT signing key

The API requires `Jwt__Key`, a secret containing at least 32 bytes. Keep it out of source control. The following PowerShell snippet creates and saves a random user-level key if one does not already exist, then loads it into the current terminal:

```powershell
$userKey = [Environment]::GetEnvironmentVariable("Jwt__Key", "User")
if ([string]::IsNullOrWhiteSpace($userKey)) {
    $bytes = New-Object byte[] 32
    $rng = [Security.Cryptography.RandomNumberGenerator]::Create()
    try {
        $rng.GetBytes($bytes)
    } finally {
        $rng.Dispose()
    }

    $userKey = [Convert]::ToBase64String($bytes)
    [Environment]::SetEnvironmentVariable("Jwt__Key", $userKey, "User")
}
$env:Jwt__Key = $userKey
```

From the repository root, run the API from the same PowerShell terminal so it receives the key:

```powershell
cd Week3\Day3\AuthApi
dotnet run
```

The HTTP launch profile listens at `http://localhost:5185`.

## Database and roles

On startup, the app creates `authapi.db` and the Identity schema if needed, then ensures the `User` and `Admin` roles exist. The database connection string is in `AuthApi/appsettings.json`.

Public registration always assigns the `User` role. It does not accept a role from the request; this prevents users from granting themselves Admin access.

## Create an Admin account for the demo

Admin seeding is optional and only runs in the Development environment. In the same PowerShell terminal, set both values before starting the API:

```powershell
$env:SeedAdmin__Email = "admin@example.com"
$env:SeedAdmin__Password = "YourPractice123!"
dotnet run
```

Choose a password with at least 8 characters and at least one non-alphanumeric character. The seed creates the account if it does not exist and assigns it the `Admin` role. If the email already belongs to a user, it adds the role without changing that user's password.

Do not configure only one of the two `SeedAdmin` values. If neither is configured, no Admin account is created. The Admin role itself is still created.

## Test with Postman

### Register a regular user

- Method: `POST`
- URL: `http://localhost:5185/api/account/register`
- Header: `Content-Type: application/json`
- Body: **raw** → **JSON**

```json
{
  "email": "user@example.com",
  "password": "Practice123!",
  "fullName": "Practice User"
}
```

Expected response: **200 OK**. The password must satisfy the Identity password rules.

### Log in

- Method: `POST`
- URL: `http://localhost:5185/api/account/login`
- Header: `Content-Type: application/json`
- Body: **raw** → **JSON**

```json
{
  "email": "user@example.com",
  "password": "Practice123!"
}
```

Expected response: **200 OK**, with a JWT in the `token` property. The token expires after one hour.

### Test the Admin-only endpoint

- Method: `GET`
- URL: `http://localhost:5185/api/account/admin-demo`
- In Postman's **Authorization** tab, choose **Bearer Token** and paste the JWT.

Expected results:

| Request | Expected status |
| --- | --- |
| No token | `401 Unauthorized` |
| Token for a regular `User` | `403 Forbidden` |
| Token for the seeded `Admin` | `200 OK` |

To get an Admin token, log in with the `SeedAdmin__Email` and `SeedAdmin__Password` values used when starting the API.

## Troubleshooting

- **JWT signing key error:** Set `Jwt__Key` in the same terminal that runs `dotnet run`.
- **401 after login:** Log in again and use the `token` value as a Bearer token; tokens expire after one hour.
- **Admin endpoint returns 403:** The token is valid, but the account does not have the `Admin` role. Start the Development app with both `SeedAdmin` values set, then log in again to get a token containing the role.
