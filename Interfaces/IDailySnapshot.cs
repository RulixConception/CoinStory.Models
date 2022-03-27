namespace CoinStory.Models.Interfaces
{
    public interface IDailySnapshot
    {
        DateTime Date { get; }

        decimal TotalFiatDepositsCad { get; }

        decimal TotalMinedValueCad { get; }

        decimal BTCHealth { get; }

        decimal ETHHealth { get; }

        bool HasError { get; }

        decimal UsdValue { get; }

        void SetRelativeHealth(decimal btcHealth, decimal ETHHealth);
    }
}