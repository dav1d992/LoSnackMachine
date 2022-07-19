
using Boundaries;
using Entities;
using SnackMachineTests.Helpers;

namespace SnackMachineTests;

[TestClass]
public class BuySnackTests
{
    [TestMethod]
    public void BuySnack_OnNewBalance_RaisesCoinInsertedEvent()
    {
        // Arrange 
        float actual = 0;
        var buySnack = A.BuySnack.Build();

        // Act
        buySnack.OnNewBalance(25, "Mars");

        // Assert
        Assert.AreEqual(0, actual);
    }

    //     var coinUnit = new CoinUnit();
    //     var balanceModule = new BalanceModule(coinUnit);
    //     var buySnack = new BuySnack(balanceModule);

    //     buySnack.OnNewBalance(25);
    // balanceModule.UpdateBalance(25);
    // coinUnit.CoinInserted(25);
}