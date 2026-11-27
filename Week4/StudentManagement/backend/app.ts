import cors from "cors";
import express from "express";
import authRoutes from "./routes/authRoutes";
import studentRoutes from "./routes/studentRoutes";

export function createApp() {
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
  return app;
}
