using CoinStory.Models.Enumerations;

namespace CoinStory.Models.Interfaces
{
    public interface ICurrencyConverter
    {
        /// <summary>
        /// Converts from a currency to a different one
        /// </summary>
        /// <param name="date">Date when the conversion took place</param>
        /// <param name="amount">Amount to convert</param>
        /// <param name="from">Initial currency</param>
        /// <param name="to">Currency to convert into</param>
        /// <returns>Amount converted into the new currency</returns>
        decimal Convert(DateTime date, decimal amount, Currency from, Currency to);

        decimal GetPeriodMaximum(DateTime start, DateTime end, Currency currency);

        decimal GetPeriodMinimum(DateTime start, DateTime end, Currency currency);

        decimal GetPeriodAverage(DateTime start, DateTime end, Currency currency);

        void FetchFromDatabase();
    }
}