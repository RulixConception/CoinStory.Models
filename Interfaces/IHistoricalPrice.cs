using CoinStory.Models.Enumerations;

namespace CoinStory.Models.Interfaces
{
    /// <summary>
    /// Historical price point for a full day (UTC time & all prices are USD)
    /// </summary>
    public interface IHistoricalPrice
    {
        DateTime Date { get; set; }

        Currency Currency { get; set; }

        HistoricalDataSource Source { get; set; }

        decimal Open { get; set; }

        decimal High { get; set; }

        decimal Low { get; set; }

        decimal Close { get; set; }

        decimal Volume { get; set; }

        decimal MarketCap { get; set; }
    }
}