import type { User } from "../services/authService";

const TOKEN_KEY = "accessToken";
const USER_KEY = "currentUser";

export const authStorage = {
  getToken: () => localStorage.getItem(TOKEN_KEY),

  setToken: (token: string) =>
    localStorage.setItem(TOKEN_KEY, token),

  getUser: (): User | null => {
    const user = localStorage.getItem(USER_KEY);
    if (!user) return null;

    try {
      return JSON.parse(user) as User;
    } catch {
      localStorage.removeItem(USER_KEY);
      return null;
    }
  },

  setUser: (user: User) =>
    localStorage.setItem(USER_KEY, JSON.stringify(user)),

  clearToken: () => {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(USER_KEY);
  },
};