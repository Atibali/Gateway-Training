public class LoginPage
{
    private string _email="";
    private string _password="";

    private readonly string _validEmail = "tester@example.com";
    private readonly string _validPassword = "Password@123";

    public string ErrorMessage { get; private set; } = "";
    public bool IsLoggedIn { get; private set; }

    public void EnterEmail(string email)
    {
        _email = email;
    }

    public void EnterPassword(string password)
    {
        _password = password;
    }

    public void ClickLogin()
    {
        ErrorMessage = "";
        IsLoggedIn = false;
        if (string.IsNullOrEmpty(_email))
        {
            ErrorMessage = "Email is required";
            return;
        }
        if(!_email.Contains("@") || !_email.Contains("."))
        {
            ErrorMessage = "Email is invalid";
            return;
        }
         if (string.IsNullOrEmpty(_password))
        {
            ErrorMessage = "Password is required";
            return;
        }
        if (_email == _validEmail && _password == _validPassword)
        {
            IsLoggedIn = true;
            return;
        }
        ErrorMessage = "Invalid email or password";
    }
}