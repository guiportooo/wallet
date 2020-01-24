using System;

namespace Wallet.Api.Domain
{
    public class FixedMoney : Money
    {
        public Currency Currency { get; }
        public decimal Amount { get; private set; }

        protected FixedMoney(Currency currency, decimal amount)
        {
            if(amount <= 0)
                throw new ArgumentException("Negative amount.");

            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            Amount = amount;
        }

        public override decimal Withdrawl(Currency currency, decimal amount)
        {
            if (currency != Currency)
                return 0;

            var paid = Math.Min(Amount, amount);
            Amount -= paid;
            return paid;
        }
    }
}