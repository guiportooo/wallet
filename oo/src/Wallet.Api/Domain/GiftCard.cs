using System;

namespace Wallet.Api.Domain
{
    public class GiftCard : FixedMoney
    {
        public Date ValidBefore { get; }

        public GiftCard(Currency currency, decimal amount, Date validBefore)
            : base(currency, amount)
        {
            if (validBefore == null)
                throw new ArgumentNullException(nameof(validBefore));

            ValidBefore = validBefore;
        }

        public override decimal Withdrawl(Currency currency, decimal amount) 
            => ValidBefore.CompareTo(DateTime.Now) <= 0 
                ? 0 
                : base.Withdrawl(currency, amount);
    }
}