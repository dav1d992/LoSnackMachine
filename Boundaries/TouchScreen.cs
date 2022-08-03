using Controls;
namespace Boundaries;

public class TouchScreen : ITouchScreen
{
    BuySnack _buySnack;
    public TouchScreen(BuySnack buySnack)
    {
        _buySnack = buySnack;
    }

    public void ShowBalance(float balance)
    {
        Console.WriteLine($"Current balance is {balance}");
    }

    public void ShowPrice(string itemName, float price)
    {
        Console.WriteLine($"One {itemName} costs {_buySnack.PriceOfItem(itemName)} DKK");
        _buySnack.NewBalanceEvent += (s, args) =>
        {
            Console.WriteLine($"Remaining: {args.Amount} DKK");
        };
    }

    public void SelectItem(string itemName)
    {
        ShowPrice(itemName, _buySnack.PriceOfItem(itemName));
    }
}
