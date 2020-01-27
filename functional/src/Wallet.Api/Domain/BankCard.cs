using System;

namespace Wallet.Api.Domain
{
    public class BankCard : Money
    {
        public Month ValidBefore { get; }

        public BankCard(Month validBefore)
        {
            if (validBefore == null)
                throw new ArgumentNullException(nameof(validBefore));

            ValidBefore = validBefore;
        }

        public override Money On(Timestamp time) => CardOn(time);

        public BankCard CardOn(Timestamp time) => time.CompareTo(ValidBefore) >= 0
            ? new CardExpired(ValidBefore)
            : this;

        public override SpecifcMoney Of(Currency currency) => new SpecifCard(currency, this);

        public virtual (Amount, Money) Take(Currency currency, decimal amount)
            => (new Amount(currency, amount), (Money)this);
    }
}