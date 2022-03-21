namespace CoinStory.Models.Interfaces
{
    /// <summary>
    /// Represents the state of a wallet on a specific date
    /// </summary>
    public interface IWalletBalanceSnapshot
    {
        DateTime Date { get; }

        decimal Amount { get; }

        decimal TotalCosts { get; }
    }
}