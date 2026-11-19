const { defineConfig } = require("@playwright/test");

module.exports = defineConfig({
    testDir: "./tests",
    testMatch: "**/*.spec.js",
    use: {
        baseURL: process.env.API_BASE_URL || "http://127.0.0.1:3000"
    }
});
