import { authStorage } from "./auth/authStorage";
import { Link, useNavigate } from "react-router-dom";

function Dashboard() {
  const user = authStorage.getUser();
  const navigate = useNavigate();

  const handleLogout = () => {
    authStorage.clearToken();
    navigate("/login", { replace: true });
  };

  return (
    <div>
      <h1>Student Management Dashboard</h1>

      <p>Welcome, {user?.name}</p>
      <p>Role: {user?.role}</p>

      <p>Role: {user?.role ?? "Unknown"}</p>
      <nav aria-label="Main navigation">
        <Link to="/students">View students</Link>
      </nav>
      <button onClick={handleLogout}>Logout</button>
    </div>
  );
}

export default Dashboard;