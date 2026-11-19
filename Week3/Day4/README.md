# Week 3 Day 4 Ticket API

## Run locally

1. Copy `.env.example` to `.env`.
2. Set `MONGODB_URI` in `.env` to your MongoDB Atlas connection string. Replace the username and password placeholders; URL-encode any special characters in the credentials.
3. Install dependencies with `npm install`.
4. Start the API with `npm start`.

The server requires a reachable MongoDB database and will not use in-memory storage. It listens on port `3000` by default, or the port configured by `PORT`.

## Endpoints

- `GET /` — health check
- `GET /api/tickets` — list tickets
- `GET /api/tickets/:id` — retrieve a ticket
- `POST /api/tickets` — create a ticket
