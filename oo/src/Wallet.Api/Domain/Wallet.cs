using System.Collections.Generic;

namespace Wallet.Api.Domain
{
    public class Wallet
    {
        private IEnumerable<Money> Content { get; } = new List<Money>();

        public void Charge(Currency currency, decimal amount)
        {
            var remaining = amount;

            using var money = Content.GetEnumerator();
            
            while (money.MoveNext() && remaining > 0)
            {
                var paid = money.Current.Withdrawl(currency, remaining);
                remaining -= paid;
            }
        }
    }
}