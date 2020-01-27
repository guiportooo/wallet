using System;

namespace Wallet.Api.Domain
{
    public abstract class SpecifcMoney : Money
    {
        public Currency Currency { get; }

        protected SpecifcMoney(Currency currency)
        {
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public override SpecifcMoney Of(Currency currency)
            => currency.Equals(Currency)
                ? this
                : new Empty(currency);

        public abstract (Amount, Money) Take(decimal amount);
    }
}