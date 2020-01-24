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

        public override decimal Withdrawl(Currency currency, decimal amount) 
            => ValidBefore.CompareTo(DateTime.Now) <= 0 
                ? 0 
                : amount;
    }
}