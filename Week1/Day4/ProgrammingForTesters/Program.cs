Console.WriteLine("## LOGIN PAGE TESTING ##");

var tests = new LoginTests();
tests.TestValidLogin();
tests.TestInvalidEmail();
tests.TestEmptyEmail();
tests.TestEmptyPassword();
tests.TestInvalidPassword();