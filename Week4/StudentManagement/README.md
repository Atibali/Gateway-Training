# Student Management

A React and TypeScript frontend with an Express API, MongoDB Atlas storage, and role-based authentication.

## Requirements

- Node.js and npm
- A MongoDB Atlas cluster and database user

## Configure MongoDB Atlas

1. Copy the backend environment template:

   ```powershell
   Copy-Item backend\.env.example backend\.env
   ```

2. Open `backend\.env` and set:
   - `MONGODB_URI` to your Atlas connection string. The template leaves this blank for you to fill in.
   - `JWT_SECRET` to a long, random secret.
3. In Atlas, ensure the cluster is running, the database user has read/write access, and your current IP is allowed under **Security → Network Access**.

Use your MongoDB **database user** in the connection string, not your Atlas website login. Keep `backend\.env` private; do not commit or share its contents.

## Run the application

Open two PowerShell terminals in this project folder.

Backend terminal:

```powershell
cd backend
npm install
npm run dev
```

Frontend terminal:

```powershell
cd frontend
npm install
npm run dev
```

Open the frontend URL printed by Vite, usually `http://localhost:5173`. The frontend connects to `http://localhost:5000/api` by default.

## Create the first admin account

After configuring `backend\.env`, run this in the backend folder:

```powershell
npm run create-admin
```

Enter the admin name, email, and password when prompted. Then log in through the frontend.

## Student login

The login page accepts an email and password for an account that already exists in MongoDB. This project currently has no student self-registration or student-account creation command; `npm run create-admin` creates an admin account only. A student account must be provisioned before a student can log in.

Students can view the student list. Admins and teachers can add students, and only admins can delete them through the API.

## Checks

```powershell
cd frontend
npm run build
npm run lint
npm run test:coverage
cd ..\backend
npm run build
npm run test:coverage
```

The backend tests use Supertest to check Express responses without connecting to MongoDB. The frontend tests use React Testing Library and a mocked async login request. Both packages use Vitest; coverage output is printed in the terminal and saved as an HTML report under `coverage/`.
