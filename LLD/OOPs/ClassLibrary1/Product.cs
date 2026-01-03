namespace ClassLibrary1;

public class Product
{
    public string Name { get; set; } =  string.Empty;
    private double _price;
    internal string Description { get; set; }  = string.Empty;
}

class User
{
    public string UserName { get; set; } = string.Empty;
}

public class Bank
{
    private double _amount;
    public double Amount
    {
        get
        {
            return _amount;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception("Amount value cannot be negative");
            }
            else
            {
                _amount = value;
            }
        }
    }

    public Guid AccountNumber { get; } //You cannot set the AccountNumber

    public Bank()
    {
        AccountNumber = Guid.NewGuid();
    }
}