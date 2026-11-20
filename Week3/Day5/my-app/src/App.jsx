import { useEffect, useState } from "react";
import StudentCard from "./components/Greeting";
import Product from "./components/Product";
import CounterButton, { CounterDisplay } from "./components/CounterButton";
import Counter from "./components/Counter";
import BrowserCounter from "./components/BrowserTitle";
import Timer from "./components/Timer";
import Navbar from "./Navbar";
import { ThemeContext } from "./components/ThemeContext";
import {BrowserRouter,Routes,Route,Link,useParams} from "react-router-dom";
import { useForm } from "react-hook-form";
import {z} from "zod";
import {zodResolver} from "@hookform/resolvers/zod";
const studentSchema=z.object({
  name: z.string().min(3,"Name must have 3 Chars"),
  email: z.string().email("Invalid email"),

  age: z.number().min(18,"Must be at Least 18")
});
const name="Charusat University"
const year=2026;
function Home() {
  const [count, setCount] = useState(0);
  const students = ["Max", "Sara", "Alex"];
  const [theme, setTheme] = useState("light");

  return (
    <div>
      <div>
        <h1>Student Management System</h1>
        <StudentCard />
      </div>
      <div className="box">
        <h1>Students from {name}</h1>
        <p>Year: {year}</p>
      </div>
      <div>
        <Product name="Keyboard" price={1200} />
        <Product name="Mouse" price={200} />
      </div>
      <h3>Use State</h3>
      <Counter />
      <section>
        <h2>Lifting State Up</h2>
        <CounterDisplay count={count} />
        <CounterButton
          onIncrement={() => setCount((currentCount) => currentCount + 1)}
        />
      </section>
      <h3>useEffect</h3>
      <BrowserCounter />
      <Timer />
      <div>
        <ul>
          {students.map((student) => (
            <li key={student}>{student}</li>
          ))}
        </ul>
      </div>
      <ThemeContext.Provider value={{ theme, setTheme }}>
        <Navbar />
      </ThemeContext.Provider>
    </div>
  );
}
function Students() {
  const [students, setStudents] = useState([]);
  const [studentsError, setStudentsError] = useState(null);
  const [isLoadingStudents, setIsLoadingStudents] = useState(true);

  useEffect(() => {
    let ignore = false;

    getStudents()
      .then((studentList) => {
        if (!ignore) {
          setStudents(studentList);
        }
      })
      .catch((error) => {
        if (!ignore) {
          setStudentsError(
            error instanceof Error ? error.message : "Failed to fetch students"
          );
        }
      })
      .finally(() => {
        if (!ignore) {
          setIsLoadingStudents(false);
        }
      });

    return () => {
      ignore = true;
    };
  }, []);

  return (
    <section>
      <h1>Students</h1>
      {isLoadingStudents && <p>Loading students...</p>}
      {studentsError && <p role="alert">{studentsError}</p>}
      {!isLoadingStudents && !studentsError && (
        <ul>
          {students.map((student) => (
            <li key={student.id}>
              {student.firstName} {student.lastName} - {student.email}
            </li>
          ))}
        </ul>
      )}
    </section>
  );
}
function StudentDetails() {
  const { id } = useParams();

  return <h1>Student ID: {id}</h1>;
}
function FormPage() {
  const {register, handleSubmit, formState: {errors}}=useForm({
    resolver: zodResolver(studentSchema)
  });

  function onSubmit(data) {
    console.log(data);
  }
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input {...register("name")} placeholder="Student Name" />
      {errors.name && <p>{errors.name.message}</p>}

      <input {...register("email")} placeholder="Student email" />
      {errors.email && <p>{errors.email.message}</p>}

      <button type="submit">Submit</button>
    </form>
  );
}
async function getStudents() {
  const response=await fetch("https://dummyjson.com/users");

  if(!response.ok)
  {
    throw new Error("Failed to fetch Students");
  }
  const data=await response.json();
  console.log(data);
  return data.users;
}
function App(){
  return (
    <BrowserRouter>
      <nav>
        <Link to="/">Home</Link>
        <Link to="/students">Students</Link>
        <Link to="/form">Form</Link>
      </nav>

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/students" element={<Students />} />
        <Route path="/students/:id" element={<StudentDetails />} />
        <Route path="/form" element={<FormPage />} />
      </Routes>
    </BrowserRouter>
  );
}
export default App;