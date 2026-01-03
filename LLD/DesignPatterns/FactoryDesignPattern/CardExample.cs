namespace FactoryDesignPattern;

public interface ICreditCard
{
    string GetCardType();
    int GetCreditLimit();
    int GetAnnualCharge();
}

class MoneyBack : ICreditCard
{
    public string GetCardType()
    {
        return "MoneyBack";
    }
    public int GetCreditLimit()
    {
        return 15000;
    }
    public int GetAnnualCharge()
    {
        return 500;
    }
}

public class Titanium : ICreditCard
{
    public string GetCardType()
    {
        return "Titanium Edge";
    }
    public int GetCreditLimit()
    {
        return 25000;
    }
    public int GetAnnualCharge()
    {
        return 1500;
    }
}

public class Platinum : ICreditCard
{
    public string GetCardType()
    {
        return "Platinum Plus";
    }
    public int GetCreditLimit()
    {
        return 35000;
    }
    public int GetAnnualCharge()
    {
        return 2000;
    }
}

public abstract class CreditCardFactory
{
    protected abstract ICreditCard MakeProduct();

    public ICreditCard CreateProduct()
    {
        return this.MakeProduct();
    }
}

public class MoneyBackFactory : CreditCardFactory
{
    protected override ICreditCard MakeProduct()
    {
        return new MoneyBack();
    }
}

public class TitaniumFactory : CreditCardFactory
{
    protected override ICreditCard MakeProduct()
    {
        return new Titanium();
    }
}

public class PlatinumFactory : CreditCardFactory
{
    protected override ICreditCard MakeProduct()
    {
        return new Platinum();
    }
}