import { useEffect, useState } from "react";
import { studentService } from "./services/studentService";
import type { Student } from "./models/Student";
import { authStorage } from "./auth/authStorage";
import AddStudent from "./AddStudent";

function StudentList() {
  const [students, setStudents] = useState<Student[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    let active = true;
    studentService.getAll()
      .then((data) => {
        if (active) setStudents(data);
      })
      .catch(() => {
        if (active) setError("Failed to load students.");
      })
      .finally(() => {
        if (active) setLoading(false);
      });

    return () => {
      active = false;
    };
  }, []);

  const role = authStorage.getUser()?.role;

  return (
    <main>
      <h2>Students</h2>
      {(role === "Admin" || role === "Teacher") && (
        <AddStudent onCreated={(student) => setStudents((current) => [student, ...current])} />
      )}

      {loading && <p>Loading students...</p>}
      {error && <p role="alert">{error}</p>}
      {!loading && !error && students.length === 0 && <p>No students yet.</p>}
      <ul className="student-list">
        {students.map((student) => (
          <li key={student._id}>
            <h3>{student.name}</h3>
            <p>{student.email}</p>
            <p>{student.course}</p>
          </li>
        ))}
      </ul>
    </main>
  );
}

export default StudentList;