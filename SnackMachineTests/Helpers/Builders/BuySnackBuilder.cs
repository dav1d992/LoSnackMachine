using Controls;
using Entities;

namespace SnackMachineTests.Helpers
{
    public class BuySnackBuilder
    {
        private BalanceModule _balanceModule = A.BalanceModule.Build();
        private Dispenser _dispenser = A.Dispenser.Build();

        public BuySnack Build()
        {
            return new BuySnack(_balanceModule, _dispenser);
        }
    }
}
