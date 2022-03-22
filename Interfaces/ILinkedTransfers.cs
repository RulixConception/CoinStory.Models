namespace CoinStory.Models.Interfaces
{
    public interface ILinkedTransfers
    {
        public ITransaction Withdrawal { get; }

        public ITransaction Deposit { get; }

        public int WithdrawalId { get; }

        public int DepositId { get; }
    }
}