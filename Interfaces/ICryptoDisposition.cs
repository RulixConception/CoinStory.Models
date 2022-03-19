namespace CoinStory.Models.Interfaces
{
    public interface ICryptoDisposition
    {
        DateTime Date { get; set; }
        
        decimal CapitalGainOrLoss { get; set; }

        ITransaction? RelatedTransaction { get; set; }

        decimal ACB { get; set; }

        decimal AssetValueCad { get; set; }

        string ToCsv();
    }
}