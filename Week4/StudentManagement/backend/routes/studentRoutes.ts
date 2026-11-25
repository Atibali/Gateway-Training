import { Router } from "express";
import { z } from "zod";
import { authenticate } from "../middleware/authMiddleware";
import { authorize } from "../middleware/roleMiddleware";
import { Student } from "../models/Student";

const router = Router();
const studentSchema = z.object({
  name: z.string().trim().min(1),
  email: z.string().trim().email(),
  course: z.string().trim().min(1),
});

router.use(authenticate);

router.get("/", async (_req, res) => {
  const students = await Student.find().sort({ createdAt: -1 });
  return res.json(students);
});

router.post("/", authorize("Admin", "Teacher"), async (req, res) => {
  const parsed = studentSchema.safeParse(req.body);
  if (!parsed.success) {
    const errors = Object.fromEntries(
      parsed.error.issues.map((issue) => [String(issue.path[0]), issue.message])
    );
    return res.status(400).json({ message: "Please correct the student details", errors });
  }

  const student = await Student.create(parsed.data);
  return res.status(201).json(student);
});

router.delete("/:id", authorize("Admin"), async (req, res) => {
  const student = await Student.findByIdAndDelete(req.params.id);
  if (!student) {
    return res.status(404).json({ message: "Student not found" });
  }
  return res.status(204).end();
});

export default router;
