const { test, expect } = require('@playwright/test');

test('Check user object data', async ({ page }) => {

    const user = {
        name: "Atibali",
        email: "atibali@example.com",
        role: "Tester"
    };

    expect(user.name).toBe("Atibali");
    expect(user.email).toContain("@");
    expect(user.role).toBe("Tester");

    console.log("User:", user);
});