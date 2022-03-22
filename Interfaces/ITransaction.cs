using CoinStory.Models.Enumerations;

namespace CoinStory.Models.Interfaces
{
    public interface ITransaction
    {
        int ID { get; set; }

        string? Identifier { get; set; }

        DateTime Date { get; set; }

        Platform Platform { get; set; }

        /// <summary>
        /// Amount sent/spent/debited
        /// </summary>
        decimal AmountIn { get; set; }

        Currency? CurrencyIn { get; set; }

        /// <summary>
        /// Amount received/gained/credited after paying fees
        /// </summary>
        decimal AmountOut { get; set; }

        Currency? CurrencyOut { get; set; }

        /// <summary>
        /// USD value of the amount received/gained/credited
        /// </summary>
        decimal UsdValueOut { get; set; }

        decimal Fee { get; set; }

        Currency? FeeCurrency { get; set; }

        /// <summary>
        /// USD value of the fees paid
        /// </summary>
        decimal UsdFeeValue { get; set; }

        /// <summary>
        /// Greater than 0 for capital gains, lesser than 0 for capital losses
        /// </summary>
        decimal? CapitalChange { get; set; }

        TransactionType Type { get; set; }

        string? Metadata { get; set; }

        string? Comments { get; set; }

        /// <summary>
        /// True if manually deleted
        /// </summary>
        bool Ignored { get; set; }

        /// <summary>
        /// True if it was automatically merged by an optimizer
        /// </summary>
        bool Merged { get; set; }

        /// <summary>
        /// True if it was manually added by the user
        /// </summary>
        bool Manual { get; set; }

        string ToCSV();
    }
}