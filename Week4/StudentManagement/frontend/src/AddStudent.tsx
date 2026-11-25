import { useState, type ChangeEvent, type FormEvent } from "react";
import { studentService } from "./services/studentService";
import type { CreateStudentDto, Student } from "./models/Student";
import axios from "axios";

interface AddStudentProps {
  onCreated: (student: Student) => void;
}

function AddStudent({ onCreated }: AddStudentProps) {
  const [form, setForm] = useState<CreateStudentDto>({
    name: "",
    email: "",
    course: "",
  });

  const [errors, setErrors] = useState<Record<string, string>>({});
  const [loading, setLoading] = useState(false);
  const [success, setSuccess] = useState("");

  const handleChange = (
    e: ChangeEvent<HTMLInputElement>
  ) => {
    setForm({
      ...form,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (
    e: FormEvent<HTMLFormElement>
  ) => {
    e.preventDefault();

    setErrors({});
    setSuccess("");

    try {
      setLoading(true);

      const student = await studentService.create(form);

      setSuccess("Student added successfully!");
      onCreated(student);

      setForm({
        name: "",
        email: "",
        course: "",
      });
    } catch (err) {
      if (axios.isAxiosError(err)) {
        const serverErrors = err.response?.data?.errors;

        if (serverErrors) {
          setErrors(serverErrors);
        } else {
          setErrors({
            general: err.response?.data?.message || "Failed to add student",
          });
        }
      } else {
        setErrors({
          general: "Something went wrong.",
        });
      }
    } finally {
      setLoading(false);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Add Student</h2>

      <label>
      Student name
      <input
        name="name"
        placeholder="Student Name"
        value={form.name}
        onChange={handleChange}
        required
      />
      </label>
      {errors.name && <p>{errors.name}</p>}

      <label>
      Email
      <input
        type="email"
        name="email"
        placeholder="Email"
        value={form.email}
        onChange={handleChange}
        required
      />
      </label>
      {errors.email && <p>{errors.email}</p>}

      <label>
      Course
      <input
        name="course"
        placeholder="Course"
        value={form.course}
        onChange={handleChange}
        required
      />
      </label>
      {errors.course && <p>{errors.course}</p>}

      {errors.general && <p>{errors.general}</p>}
      {success && <p>{success}</p>}

      <button disabled={loading}>
        {loading ? "Saving..." : "Add Student"}
      </button>
    </form>
  );
}

export default AddStudent;