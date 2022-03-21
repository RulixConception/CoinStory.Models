namespace CoinStory.Models.Interfaces
{
    public interface IDailySnapshot
    {
        DateTime Date { get; }

        decimal TotalFiatDepositsUsd { get; }

        decimal TotalMinedValueUsd { get; }

        decimal BTCHealth { get; }

        decimal ETHHealth { get; }

        bool HasError { get; }

        decimal UsdValue { get; }

        void SetRelativeHealth(decimal btcHealth, decimal ETHHealth);
    }
}