namespace Wallet.Api.Domain
{
    public abstract class Money
    {
        public abstract decimal Withdrawl(Currency currency, decimal amount);
    }
}