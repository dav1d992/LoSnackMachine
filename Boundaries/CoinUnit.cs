namespace Boundaries;
public class CoinUnit
{
    public event EventHandler<CoinEventArgs> CoinInsertedEvent = delegate { };

    public void CoinInserted(float amount)
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
