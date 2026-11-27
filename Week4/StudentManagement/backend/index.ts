import "dotenv/config";
import { connectDatabase } from "./config/database";
import { createApp } from "./app";

async function startServer(): Promise<void> {
  if (!process.env.JWT_SECRET) {
    throw new Error("JWT_SECRET is missing. Add a long random secret to backend/.env.");
  }

  await connectDatabase();

  const port = Number(process.env.PORT) || 5000;
  createApp().listen(port, () => console.log(`API listening on port ${port}`));
}

startServer().catch((error: unknown) => {
  console.error("Could not start the API:", error);
  process.exitCode = 1;
});
