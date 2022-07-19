using Entities;

namespace Entities;

public class BalanceModule : IBalanceModule
{
    public event EventHandler<BalanceModuleEventArgs> NewBalanceEvent = delegate { };

    public CoinUnit CoinUnit;

    public BalanceModule(CoinUnit coinUnit)
    {
        CoinUnit = coinUnit;
    }

    public float CurrentBalance = 0;

    public void UpdateBalance(float amount)
    {
        CoinUnit.CoinInsertedEvent += (s, args) =>
        {
            Console.WriteLine($"Coin inserted: {amount} DKK");
            CurrentBalance += amount;
        };
        if (CoinUnit.IsOpen)
        {
            CoinUnit.CoinInserted(amount);
        }

        var args = new BalanceModuleEventArgs();
        args.Amount = amount;
        NewBalanceEvent.Invoke(this, args);
    }
}

public class BalanceModuleEventArgs : EventArgs
{
    public float Amount { get; set; }
}
