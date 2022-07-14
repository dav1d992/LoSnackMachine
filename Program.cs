// See https://aka.ms/new-console-template for more information
using Controls;
using Entities;
using Boundaries;

var coinUnit = new CoinUnit();
var balanceModule = new BalanceModule(coinUnit);
var buySnack = new BuySnack(balanceModule);

buySnack.OnNewBalance(25);
balanceModule.UpdateBalance(25);
coinUnit.CoinInserted(25);
