using Boundaries;

namespace Entities;

public class BalanceModule : IBalanceModule
{
    public event EventHandler<BalanceModuleEventArgs> NewBalanceEvent = delegate { };

    CoinUnit _coinUnit;

    public BalanceModule(CoinUnit coinUnit)
    {
        _coinUnit = coinUnit;
    }

    public void UpdateBalance(float amount)
    {
        _coinUnit.CoinInsertedEvent += (s, args) =>
        {
            Console.WriteLine($"Coin inserted - {amount}");
        };
        _coinUnit.CoinInserted(amount);

        var args = new BalanceModuleEventArgs();
        args.Amount = amount;
        NewBalanceEvent.Invoke(this, args);
    }
}

public class BalanceModuleEventArgs : EventArgs
{
    public float Amount { get; set; }
}
