namespace Wallet.Api.Domain
{
    public class CardExpired : BankCard
    {
        public CardExpired(Month validBefore) : base(validBefore)
        {
        }

        public override Money On(Timestamp time) => this;

        public override SpecifcMoney Of(Currency currency) => new Empty(currency);

        public override (Amount, Money) Take(Currency currency, decimal amount) 
            => (Amount.Zero(currency), (Money) this);
    }
}