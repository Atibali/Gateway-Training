import "dotenv/config";
import bcrypt from "bcrypt";
import { createInterface } from "node:readline/promises";
import { stdin as input, stdout as output } from "node:process";
import { connectDatabase } from "../config/database";
import { User } from "../models/User";

async function createAdmin(): Promise<void> {
  await connectDatabase();
  const prompt = createInterface({ input, output });
  try {
    const name = (await prompt.question("Admin name: ")).trim();
    const email = (await prompt.question("Admin email: ")).trim().toLowerCase();
    const password = await prompt.question("Admin password: ");
    if (!name || !email || password.length < 8) {
      throw new Error("Name and email are required; password must be at least 8 characters.");
    }

    const existingUser = await User.exists({ email });
    if (existingUser) {
      throw new Error("A user with that email already exists.");
    }
    const hashedPassword = await bcrypt.hash(password, 12);
    await User.create({ name, email, password: hashedPassword, role: "Admin" });
    console.log("Admin account created.");
  } finally {
    prompt.close();
  }
}

createAdmin().catch((error: unknown) => {
  console.error("Could not create admin:", error);
  process.exitCode = 1;
});
