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
    public event EventHandler<NewBalanceArgs> NewBalanceEvent = delegate { };

    public void OnNewBalance(float amount, string itemName)
    {
        _balanceModule.NewBalanceEvent += (s, args) =>
        {
            var newBalanceArgs = new NewBalanceArgs();
            Console.WriteLine($"Coin inserted - {amount}");
            while (_balanceModule.CurrentBalance < _database.Data[itemName])
            {
                newBalanceArgs.Amount = _database.Data[itemName] - _balanceModule.CurrentBalance;
                NewBalanceEvent.Invoke(this, newBalanceArgs);
            }
            if (_balanceModule.CurrentBalance > _database.Data[itemName])
            {
                var current = _balanceModule.CurrentBalance - _database.Data[itemName];
                newBalanceArgs.Amount = current;
                NewBalanceEvent.Invoke(this, newBalanceArgs);
                _balanceModule.CoinUnit.PayBack(current);
            }
            newBalanceArgs.Amount = 0;
            NewBalanceEvent.Invoke(this, newBalanceArgs);
            _balanceModule.CoinUnit.setOpenState(false);
            _dispenser.dispenseItem(itemName);
            _balanceModule.CurrentBalance = 0;
        };
    }

    public class NewBalanceArgs : EventArgs
    {
        public float Amount { get; set; }
    }

}
