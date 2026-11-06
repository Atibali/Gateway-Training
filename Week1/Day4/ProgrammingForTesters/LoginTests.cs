public class LoginTests
{
    public void TestValidLogin()
    {
        // Arrange
        var loginPage = new LoginPage();

        // Act
        loginPage.EnterEmail("tester@example.com");
        loginPage.EnterPassword("Password@123");
        loginPage.ClickLogin();

        // Assert
        if (loginPage.IsLoggedIn)
            Console.WriteLine("PASS: Valid login");
        else
            Console.WriteLine("FAIL: Valid login");
    }

    public void TestInvalidEmail()
    {
        // Arrange
        var loginPage = new LoginPage();

        // Act
        loginPage.EnterEmail("invalidemail");
        loginPage.EnterPassword("Password@123");
        loginPage.ClickLogin();

        // Assert
        if (loginPage.ErrorMessage == "Email is invalid")
            Console.WriteLine("PASS: Invalid email");
        else
            Console.WriteLine("FAIL: Invalid email");
    }

    public void TestEmptyEmail()
    {
        // Arrange
        var loginPage = new LoginPage();

        // Act
        loginPage.EnterEmail("");
        loginPage.EnterPassword("Password@123");
        loginPage.ClickLogin();

        // Assert
        if (loginPage.ErrorMessage == "Email is required")
            Console.WriteLine("PASS: Empty email");
        else
            Console.WriteLine("FAIL: Empty email");
    }

    public void TestEmptyPassword()
    {
        // Arrange
        var loginPage = new LoginPage();

        // Act
        loginPage.EnterEmail("tester@example.com");
        loginPage.EnterPassword("");
        loginPage.ClickLogin();

        // Assert
        if (loginPage.ErrorMessage == "Password is required")
            Console.WriteLine("PASS: Empty password");
        else
            Console.WriteLine("FAIL: Empty password");
    }

    public void TestInvalidPassword()
    {
        // Arrange
        var loginPage = new LoginPage();

        // Act
        loginPage.EnterEmail("tester@example.com");
        loginPage.EnterPassword("WrongPassword");
        loginPage.ClickLogin();

        if (loginPage.ErrorMessage == "Invalid email or password")
            Console.WriteLine("PASS: Invalid password rejected");
        else
            Console.WriteLine("FAIL: Invalid password test");
    }
}