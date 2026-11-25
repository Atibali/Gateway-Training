import "dotenv/config";
import cors from "cors";
import express from "express";
import { connectDatabase } from "./config/database";
import authRoutes from "./routes/authRoutes";
import studentRoutes from "./routes/studentRoutes";

async function startServer(): Promise<void> {
  if (!process.env.JWT_SECRET) {
    throw new Error("JWT_SECRET is missing. Add a long random secret to backend/.env.");
  }

  await connectDatabase();

  const app = express();
  app.use(cors({ origin: process.env.FRONTEND_ORIGIN || "http://localhost:5173" }));
  app.use(express.json());
  app.get("/api/health", (_req, res) => res.json({ status: "ok" }));
  app.use("/api/auth", authRoutes);
  app.use("/api/students", studentRoutes);
  app.use("/api", (_req, res) => res.status(404).json({ message: "API route not found" }));
  app.use((error: unknown, _req: express.Request, res: express.Response, _next: express.NextFunction) => {
    console.error("API request failed:", error);
    if (
      typeof error === "object" &&
      error !== null &&
      "code" in error &&
      error.code === 11000
    ) {
      return res.status(409).json({ message: "A student or user with that email already exists" });
    }
    return res.status(500).json({ message: "Internal server error" });
  });

  const port = Number(process.env.PORT) || 5000;
  app.listen(port, () => console.log(`API listening on port ${port}`));
}

startServer().catch((error: unknown) => {
  console.error("Could not start the API:", error);
  process.exitCode = 1;
});
