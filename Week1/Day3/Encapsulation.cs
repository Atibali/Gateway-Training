try
{
	var c1 = new BankAccount("Atibali", 1050);

    Console.WriteLine($"Owner: {c1.Owner}");
    Console.WriteLine($"Balance: {c1.Balance}");

    c1.Deposit(500);
    Console.WriteLine($"After Deposit: {c1.Balance}");

    c1.Withdraw(200);
    Console.WriteLine($"After Withdrawal: {c1.Balance}");
}
catch(Exception e)
{
	Console.WriteLine(e.Message);
}
public class BankAccount
{
	private decimal _balance;
	public string Owner {get;}
	public BankAccount(string owner, decimal initial)
	{
		Owner=owner;
		Balance=initial;
	}
	public decimal Balance
	{
		get=> _balance;
		private set
		{
			if(value<0)
				throw new ArgumentException("Balance Cannot be negative");
			_balance=value;
		}
	}

	public void Deposit(decimal amount)
	{
		if(amount<=0) throw new ArgumentException("Deposit must be Positive");
		Balance+=amount;
	}
	public void Withdraw(decimal amount )
	{
		if(amount>Balance) throw new InvalidOperationException("Insufficient Fund in Account");
		Balance-=amount;
	}
}