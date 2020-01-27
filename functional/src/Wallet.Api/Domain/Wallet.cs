using System.Collections.Generic;
using System.Linq;

namespace Wallet.Api.Domain
{
    public class Wallet
    {
        private IEnumerable<Money> Content { get; set; } = new List<Money>();

        public Amount Charge(Currency currency, Amount toCharge)
        {
            var split = Content
                .On(Timestamp.Now)
                .Of(currency)
                .Take(toCharge.Value)
                .ToList();

            Content = split.Select(x => x.Item2).ToList();
            var total = split.Sum(x => x.Item1.Value);
            return new Amount(toCharge.Currency, total);
        }
    }
}