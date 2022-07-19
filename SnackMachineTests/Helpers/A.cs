namespace SnackMachineTests.Helpers
{
    public static class A
    {
        public static DispenserBuilder Dispenser => new DispenserBuilder();
        public static CoinUnitBuilder CoinUnit => new CoinUnitBuilder();
        public static BalanceModuleBuilder BalanceModule => new BalanceModuleBuilder();
        public static BuySnackBuilder BuySnack => new BuySnackBuilder();

    }
}
