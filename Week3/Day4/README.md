# Week 3 Day 4 Ticket API

## Run locally

1. Copy `.env.example` to `.env`.
2. Set `MONGODB_URI` in `.env` to your MongoDB Atlas connection string. Replace the username and password placeholders; URL-encode any special characters in the credentials.
3. Install dependencies with `npm install`.
4. Start the API with `npm start`.

The server requires a reachable MongoDB database and will not use in-memory storage. It listens on port `3000` by default, or the port configured by `PORT`.

## API tests

Start the API with a configured MongoDB connection, then run `npx playwright test` from this directory. The Playwright API test creates a ticket, verifies it appears in the list, and retrieves it by ID. Set `API_BASE_URL` if the server is not at `http://127.0.0.1:3000`.

## React test example

`examples/react/TicketPage.test.jsx` is a sample Vitest and React Testing Library test for an assumed `TicketPage` component in the same folder. It expects accessible Title and Description fields and a Create ticket button, and checks the ticket list and POST request. This repository does not include that React page or the React/Vitest test dependencies, so the example is not run by Playwright.

## Endpoints

- `GET /` — health check
- `GET /api/tickets` — list tickets
- `GET /api/tickets/:id` — retrieve a ticket
- `POST /api/tickets` — create a ticket
