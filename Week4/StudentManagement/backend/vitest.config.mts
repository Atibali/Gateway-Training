import { defineConfig } from "vitest/config";

export default defineConfig({
  test: {
    coverage: {
      include: ["app.ts", "routes/**/*.ts"],
      reporter: ["text", "html"],
    },
  },
});
