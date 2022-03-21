using CoinStory.Models.Enumerations;

namespace CoinStory.Models.Interfaces
{
    public interface IWallet : ICloneable
    {
        Currency Currency { get; }

        /// <summary>
        /// Average CAD cost paid per coin including all necessary fees to acquire them
        /// </summary>
        decimal AdjustedCostBase { get; }

        /// <summary>
        /// Total costs in CAD paid to purchase all the coins in this wallet (includes all fees)
        /// </summary>
        decimal TotalCosts { get; }

        decimal Amount { get; }

        IList<string> History { get; }

        IList<IWalletBalanceSnapshot> BalanceHistory { get; }

        /// <summary>
        /// Profit or loss in CAD that would occur if the entire wallet was sold
        /// </summary>
        decimal UnrealizedGains { get; }

        /// <summary>
        /// Lists all transactions that were applied to this wallet
        /// </summary>
        IList<ITransaction> AppliedTxns { get; }

        /// <summary>
        /// Finds the USD value of all the coins in the wallet at a specific date
        /// </summary>
        /// <param name="date">Date at which to find the USD value</param>
        decimal GetUsdValue(DateTime date);

        /// <summary>
        /// Finds the CAD value of all the coins in the wallet at a specific date
        /// </summary>
        /// <param name="date">Date at which to find the CAD value</param>
        decimal GetCadValue(DateTime date);

        /// <summary>
        /// Purchases some coins
        /// </summary>
        /// <param name="date">Date of the purchase</param>
        /// <param name="amount">Amount of coins purchased</param>
        /// <param name="cost">CAD cost to purchase the coins (including fees, 0 for mining payments)</param>
        /// <param name="refTransaction">Original transaction only used for debugging purposes</param>
        /// <param name="additionalCosts">Additionnal costs from previous fiat transactions where no gains or losses can be declared</param>
        void Purchase(DateTime date, decimal amount, decimal cost, ITransaction refTransaction, decimal additionalCosts = 0);

        /// <summary>
        /// Sells some coins and returns the capital gain/loss for the transaction
        /// </summary>
        /// <param name="date">Date of the sale</param>
        /// <param name="amount">Amount of coins sold</param>
        /// <param name="valueReceivedCad">Total CAD value received for the coins</param>
        /// <param name="refTransaction">Original transaction only used for debugging purposes</param>
        /// <returns>Capital gain or loss on the transaction</returns>
        decimal Sell(DateTime date, decimal amount, decimal valueReceivedCad, ITransaction refTransaction);

        /// <summary>
        /// Executes a transfer (usually from different platforms) but in the same currency
        /// </summary>
        /// <param name="amountIn">Amount sent</param>
        /// <param name="amountOut">Amount received (usually amount sent - fees)</param>
        /// <param name="valueIn">Total value (CAD) of the amount sent</param>
        /// <param name="valueOut">Total value (CAD) of the amount received</param>
        void Transfer(DateTime date, decimal amountIn, decimal amountOut, decimal valueIn, decimal valueOut);
    }
}
