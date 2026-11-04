using System;

class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message){

    }
}

class CustomException
{
    static void Main()
    {
        try
        {
            int balance=5000;
            int withdraw=1600;
            if(withdraw>balance)
            {
                throw new InsufficientBalanceException("Balance is Insufficient");
            }
            else{
                balance=balance-withdraw;
                Console.WriteLine("Withdrawl Done of Rupees: "+withdraw);
                Console.WriteLine("Updated Balance is: "+balance);
            }
        }
        catch(InsufficientBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}