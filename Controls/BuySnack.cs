using Entities;

namespace Controls;
public class BuySnack
{
    BalanceModule _balanceModule;
    public BuySnack(BalanceModule balanceModule)
    {
        _balanceModule = balanceModule;
    }

    public void OnNewBalance(float amount)
    {
        _balanceModule.NewBalanceEvent += (s, args) =>
        {
            Console.WriteLine($"INVOKED Coin inserted - {amount}");
            Console.WriteLine("Luk indkast");
            Console.WriteLine("Dispenser vare");
        };
    }
}
