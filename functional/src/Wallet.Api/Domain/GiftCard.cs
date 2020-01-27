using System;

namespace Wallet.Api.Domain
{
    public class GiftCard : Amount 
    {
        public Date ValidBefore { get; }

        public GiftCard(Currency currency, decimal amount, Date validBefore)
            : base(currency, amount)
        {
            if (validBefore == null)
                throw new ArgumentNullException(nameof(validBefore));

            ValidBefore = validBefore;
        }

        public override Money On(Timestamp time) =>
            time.CompareTo(ValidBefore) >= 0
                ? Zero(Currency)
                : this;
    }
}