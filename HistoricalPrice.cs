using CoinStory.Models.Enumerations;
using CoinStory.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinStory.Models
{
    /// <summary>
    /// Contains all historical USD pricing information for a single UTC day and its source
    /// </summary>
    public class HistoricalPrice : IHistoricalPrice
    {
        public DateTime Date { get; set; }

        public Currency Currency { get; set; }

        public HistoricalDataSource Source { get; set; }

        [Column(TypeName = "decimal(38,10)")]
        public decimal Open { get; set; }

        [Column(TypeName = "decimal(38,10)")]
        public decimal High { get; set; }

        [Column(TypeName = "decimal(38,10)")]
        public decimal Low { get; set; }

        [Column(TypeName = "decimal(38,10)")]
        public decimal Close { get; set; }

        [Column(TypeName = "decimal(38,10)")]
        public decimal Volume { get; set; }

        [Column(TypeName = "decimal(38,10)")]
        public decimal MarketCap { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is HistoricalPrice t)
                if (Date.Year == t.Date.Year && Date.Month == t.Date.Month && Date.Day == t.Date.Day && Currency == t.Currency)
                    return true;
                else
                    return false;

            return base.Equals(obj);
        }

        public override int GetHashCode() => HashCode.Combine(Date, Currency);

        public static bool operator ==(HistoricalPrice price1, HistoricalPrice price2) => price1 is null ? price2 is null : Equals(price1, price2);

        public static bool operator !=(HistoricalPrice price1, HistoricalPrice price2) => !(price1 == price2);
    }
}