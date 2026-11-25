import jwt from "jsonwebtoken";
import type { Request, Response, NextFunction } from "express";
import type { UserRole } from "../models/User";

declare global {
  namespace Express {
    interface Request {
      user?: { id: string; role: UserRole };
    }
  }
}

export const authenticate = (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  const authHeader = req.headers.authorization;

  if (!authHeader?.startsWith("Bearer ")) {
    return res.status(401).json({ message: "Authentication required" });
  }

  const token = authHeader.slice("Bearer ".length);

  try {
    const secret = process.env.JWT_SECRET;
    if (!secret) {
      return res.status(500).json({ message: "JWT_SECRET is not configured" });
    }
    const decoded = jwt.verify(token, secret);
    if (
      typeof decoded === "string" ||
      typeof decoded.id !== "string" ||
      !["Admin", "Teacher", "Student"].includes(String(decoded.role))
    ) {
      return res.status(401).json({ message: "Invalid or expired token" });
    }
    req.user = { id: decoded.id, role: decoded.role as UserRole };
    next();
  } catch {
    return res.status(401).json({ message: "Invalid or expired token" });
  }
};