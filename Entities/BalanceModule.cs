using Boundaries;

namespace Entities;
public class BalanceModule
{
    public void UpdateBalance(float amount)
    {
        var bla = new CoinUnit();
        bla.CoinInsertedEvent += (s, args) =>
        {
            Console.WriteLine($"Coin inserted - {amount}");
        };
        bla.onCoinInserted(amount);
    }
}
