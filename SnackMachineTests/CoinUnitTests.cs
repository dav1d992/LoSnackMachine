using Entities;

namespace SnackMachineTests;

[TestClass]
public class CoinUnitTests
{
    [TestMethod]
    public void CoinUnit_OnCoinInserted_RaisesCoinInsertedEvent()
    {
        // Arrange 
        float actual = 0;
        var coinUnit = new CoinUnit();

        // Act
        coinUnit.CoinInsertedEvent += delegate (object? sender, CoinEventArgs e)
        {
            actual = e.Amount;
        };
        coinUnit.CoinInserted(25);

        // Assert
        Assert.AreEqual(25, actual);
    }
}