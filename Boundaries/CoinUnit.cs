namespace Boundaries;
public class CoinUnit
{
    public EventHandler<CoinEventArgs> CoinInsertedEvent;

    public void onCoinInserted(float amount)
    {
        var args = new CoinEventArgs();
        args.Amount = amount;
        CoinInsertedEvent.Invoke(this, args);
    }
}

public class CoinEventArgs : EventArgs
{
    public float Amount { get; set; }
}
