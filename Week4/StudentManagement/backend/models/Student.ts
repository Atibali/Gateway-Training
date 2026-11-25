import { model, Schema } from "mongoose";

const studentSchema = new Schema(
  {
    name: { type: String, required: true, trim: true },
    email: { type: String, required: true, unique: true, lowercase: true, trim: true },
    course: { type: String, required: true, trim: true },
  },
  { timestamps: true }
);

export const Student = model("Student", studentSchema);
