using Entities;
using Persistence;

namespace Controls;
public class BuySnack
{
    BalanceModule _balanceModule;
    Dispenser _dispenser;
    SnackDatabase _database = new SnackDatabase(new Dictionary<string, int>(){
            {"Mars", 10},
            {"Cola", 16},
            {"Redbull", 16},
            {"Chips", 20},
            {"Winegums", 18},
            {"Musli bar", 8},
            {"Gum", 3},
            {"Fanta", 16},
        });

    public BuySnack(BalanceModule balanceModule, Dispenser dispenser)
    {
        _balanceModule = balanceModule;
        _dispenser = dispenser;
    }

    public float PriceOfItem(string itemName)
    {
        if (_database.Data[itemName] < 0)
        {
            Console.WriteLine("Snack Machine does not contain that item");
            return 0;
        }
        else
        {
            Console.WriteLine($"Chosen item costs {_database.Data[itemName]}");
            _balanceModule.CoinUnit.setOpenState(true);
            return _database.Data[itemName];
        }
    }

    public void OnNewBalance(float amount, string itemName)
    {
        _balanceModule.NewBalanceEvent += (s, args) =>
        {

            Console.WriteLine($"Coin inserted - {amount}");
            while (_balanceModule.CurrentBalance < _database.Data[itemName])
            {
                // trigger some event to let Touchschreen know
                // show balance
            }
            if (_balanceModule.CurrentBalance > _database.Data[itemName])
            {
                // you will get money in return
                // _balanceModule.CurrentBalance - _database.Data[itemName]
                // show balance
            }
            else
            {
                // Luk indkast 
                _balanceModule.CoinUnit.setOpenState(false);
                _dispenser.dispenseItem(itemName);
                _balanceModule.CurrentBalance = 0;
                // show balance
            }
        };
    }

}
