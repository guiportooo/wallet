using System.Collections.Generic;
using System.Linq;

namespace Wallet.Api.Domain
{
    public static class MoneyEnumerableExtensions
    {
        public static IEnumerable<Money> On(this IEnumerable<Money> monies, Timestamp time)
            => monies.Select(money => money.On(time));

        public static IEnumerable<SpecifcMoney> Of(this IEnumerable<Money> monies, Currency currency)
            => monies.Select(money => money.Of(currency));

        public static IEnumerable<(Amount, Money)> Take(this IEnumerable<SpecifcMoney> monies, decimal amount)
        {
            var rest = amount;
            foreach (var money in monies)
            {
                var current = money.Take(rest);
                yield return current;
                rest -= current.Item1.Value;
            }
        }
    }
}