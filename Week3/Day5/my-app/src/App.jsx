import StudentCard from "./components/Greeting";
const name="Charusat University"
const year=2026;
function App(){
  return (
    <div>
      <h1>Student Management System</h1>
      <StudentCard />
      <div className="box">
        <h1>Students from {name}</h1>
        <p>Year: {year}</p>
      </div>
    </div>
  );
}
export default App;