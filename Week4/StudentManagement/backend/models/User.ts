import { model, Schema } from "mongoose";

export const userRoles = ["Admin", "Teacher", "Student"] as const;
export type UserRole = (typeof userRoles)[number];

const userSchema = new Schema(
  {
    name: { type: String, required: true, trim: true },
    email: { type: String, required: true, unique: true, lowercase: true, trim: true },
    password: { type: String, required: true, select: false },
    role: { type: String, enum: userRoles, default: "Student", required: true },
  },
  { timestamps: true }
);

export const User = model("User", userSchema);
