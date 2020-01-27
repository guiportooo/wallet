namespace Wallet.Api.Domain
{
    public abstract class Money
    {
        public abstract Money On(Timestamp time);
        public abstract SpecifcMoney Of(Currency currency);
    }
}