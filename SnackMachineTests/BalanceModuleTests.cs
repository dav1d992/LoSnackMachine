using Boundaries;
using Entities;
using SnackMachineTests.Helpers;

namespace SnackMachineTests;

[TestClass]
public class BalanceModuleTests
{
    [TestMethod]
    public void BalanceModule_OnCoinInserted_RaisesCoinInsertedEvent()
    {
        // Arrange 
        float actual = 0;
        var balanceModule = A.BalanceModule.Build();

        // Act
        balanceModule.NewBalanceEvent += delegate (object? sender, BalanceModuleEventArgs e)
        {
            actual = e.Amount;
        };
        balanceModule.UpdateBalance(25);

        // Assert
        Assert.AreEqual(25, actual);
    }
}