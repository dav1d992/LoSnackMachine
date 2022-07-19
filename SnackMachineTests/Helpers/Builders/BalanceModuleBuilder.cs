using Boundaries;
using Entities;

namespace SnackMachineTests.Helpers
{
    public class BalanceModuleBuilder
    {
        private CoinUnit _coinUnit = new CoinUnit();

        public BalanceModule Build()
        {
            return new BalanceModule(_coinUnit);
        }

        public BalanceModuleBuilder WithCoinUnit(CoinUnit coinUnit)
        {
            _coinUnit = coinUnit;
            return this;
        }
    }
}
