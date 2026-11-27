import { afterEach, describe, expect, it, vi } from "vitest";
import { cleanup, render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { MemoryRouter, Route, Routes } from "react-router-dom";
import Login from "./Login";
import { authStorage } from "../auth/authStorage";
import { authService } from "../services/authService";

afterEach(() => {
  cleanup();
  authStorage.clearToken();
  vi.restoreAllMocks();
});

describe("Login", () => {
  it("submits credentials and navigates after a successful login", async () => {
    const user = userEvent.setup();
    vi.spyOn(authService, "login").mockResolvedValue({
      token: "test-token",
      user: { id: "user-1", name: "A Student", email: "student@example.com", role: "Student" },
    });

    render(
      <MemoryRouter initialEntries={["/login"]}>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/dashboard" element={<h1>Dashboard</h1>} />
        </Routes>
      </MemoryRouter>,
    );

    await user.type(screen.getByLabelText("Email"), "student@example.com");
    await user.type(screen.getByLabelText("Password"), "password123");
    await user.click(screen.getByRole("button", { name: "Login" }));

    expect(await screen.findByRole("heading", { name: "Dashboard" })).toBeInTheDocument();
    expect(authService.login).toHaveBeenCalledWith({
      email: "student@example.com",
      password: "password123",
    });
    expect(authStorage.getToken()).toBe("test-token");
  });

  it("shows a helpful message when the login request fails", async () => {
    const user = userEvent.setup();
    vi.spyOn(authService, "login").mockRejectedValue(new Error("Unauthorized"));

    render(
      <MemoryRouter>
        <Login />
      </MemoryRouter>,
    );

    await user.type(screen.getByLabelText("Email"), "student@example.com");
    await user.type(screen.getByLabelText("Password"), "wrong-password");
    await user.click(screen.getByRole("button", { name: "Login" }));

    expect(await screen.findByText("Invalid email or password.")).toBeInTheDocument();
  });
});
