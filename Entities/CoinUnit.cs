namespace Entities;
public class CoinUnit
{
    public Boolean IsOpen = false;
    public event EventHandler<CoinEventArgs> CoinInsertedEvent = delegate { };

    public void CoinInserted(float amount)
    {
        var args = new CoinEventArgs();
        args.Amount = amount;
        CoinInsertedEvent.Invoke(this, args);
    }

    public void setOpenState(Boolean isOpen)
    {
        IsOpen = isOpen;
    }

    public void PayBack(float amount)
    {
        Console.WriteLine($"I have returned {amount} DKK");
    }
}

public class CoinEventArgs : EventArgs
{
    public float Amount { get; set; }
}
