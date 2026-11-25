import { Navigate, Outlet } from "react-router-dom";
import { authStorage } from "./authStorage";
import type { UserRole } from "../services/authService";

interface RoleRouteProps {
  allowedRoles: UserRole[];
}

function RoleRoute({ allowedRoles }: RoleRouteProps) {
  const user = authStorage.getUser();

  if (!user) {
    return <Navigate to="/login" replace />;
  }

  if (!allowedRoles.includes(user.role)) {
    return <Navigate to="/dashboard" replace />;
  }

  return <Outlet />;
}

export default RoleRoute;