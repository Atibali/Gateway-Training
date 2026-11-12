
// Import Playwright
const { test, expect } = require('@playwright/test');

// Login test
test('User login', async ({ page }) => {

    // Navigate to login page
    await page.goto('https://example.com/login');

    // Enter email
    await page.fill('#email', 'test@example.com');

    // Enter password
    await page.fill('#password', 'password123');

    // Click login button
    await page.click('button[type="submit"]');

    // Verify dashboard navigation
    await expect(page).toHaveURL(/dashboard/);

    console.log('Login successful!');
});
