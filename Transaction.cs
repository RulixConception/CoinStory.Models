using CoinStory.Models.Enumerations;
using CoinStory.Models.Interfaces;

namespace CoinStory.Models
{
    /// <summary>
    /// Contains all data regarding an operation that involves some amount of coins
    /// </summary>
    public class Transaction : ITransaction
    {
        private DateTime _date;

        public int ID { get; set; }

        public string? Identifier { get; set; }

        public DateTime Date
        {
            get => _date;
            set => _date = value.Kind != DateTimeKind.Utc
                ? DateTime.SpecifyKind(value, DateTimeKind.Utc)
                : value;
        }

        public Platform Platform { get; set; }

        public virtual decimal AmountIn { get; set; }

        public Currency? CurrencyIn { get; set; }

        public virtual decimal AmountOut { get; set; }

        public Currency? CurrencyOut { get; set; }

        public virtual decimal UsdValueOut { get; set; }

        public virtual decimal Fee { get; set; }

        public Currency? FeeCurrency { get; set; }

        public virtual decimal UsdFeeValue { get; set; }

        public virtual decimal? CapitalChange { get; set; }

        public TransactionType Type { get; set; }

        public string? Metadata { get; set; }

        public string? Comments { get; set; }

        public bool Ignored { get; set; }

        public bool Merged { get; set; }

        public bool Manual { get; set; }

        public Transaction(string identifier, DateTime date, decimal amountIn, Currency? currencyIn, decimal amountOut, Currency? currencyOut, TransactionType type, Platform platform, decimal fee, Currency? feeCurrency, string comments) : this()
        {
            Identifier = identifier;
            Date = date;
            AmountIn = amountIn;
            CurrencyIn = currencyIn;
            AmountOut = amountOut;
            CurrencyOut = currencyOut;
            Type = type;
            Platform = platform;
            Fee = fee;
            FeeCurrency = feeCurrency;
            Metadata = comments;
        }

        public Transaction()
        {

        }

        public string ToCSV() => string.Join(",", new string[]
        {
            Date.ToShortDateString() + " " + Date.ToShortTimeString(),
            Platform.ToString(),
            AmountIn.ToString(".################"),
            CurrencyIn?.ToString() ?? "",
            AmountOut.ToString(".################"),
            CurrencyOut?.ToString() ?? "",
            Fee.ToString(".################"),
            FeeCurrency?.ToString() ?? "",
            Identifier,
            Type.ToString(),
            Metadata
        });

        public override bool Equals(object? obj)
        {
            if (obj is ITransaction txn)
            {
                if (Platform != txn.Platform || Type != txn.Type && Type != TransactionType.Transfer && txn.Type != TransactionType.Transfer)
                    return false;

                if (!string.IsNullOrEmpty(Identifier) && Identifier == txn.Identifier)
                    return true;

                return Date == txn.Date &&
                    CurrencyIn == txn.CurrencyIn &&
                    CurrencyOut == txn.CurrencyOut &&
                    AmountIn == txn.AmountIn &&
                    AmountOut == txn.AmountOut;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Identifier);
            hash.Add(Date);
            hash.Add(Platform);
            hash.Add(AmountIn);
            hash.Add(CurrencyIn);
            hash.Add(AmountOut);
            hash.Add(CurrencyOut);
            hash.Add(UsdValueOut);
            hash.Add(Fee);
            hash.Add(FeeCurrency);
            hash.Add(UsdFeeValue);
            hash.Add(CapitalChange);
            hash.Add(Type);
            hash.Add(Metadata);
            hash.Add(Comments);
            hash.Add(Ignored);
            hash.Add(Merged);
            hash.Add(Manual);

            return hash.ToHashCode();
        }

        public static bool operator ==(Transaction txn1, Transaction txn2) => txn1 is null ? txn2 is null : Equals(txn1, txn2);

        public static bool operator !=(Transaction txn1, Transaction txn2) => !(txn1 == txn2);
    }
}