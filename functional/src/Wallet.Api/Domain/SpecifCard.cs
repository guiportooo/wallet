using System;

namespace Wallet.Api.Domain
{
    public class SpecifCard : SpecifcMoney
    {
        public BankCard Card { get; }
        
        public SpecifCard(Currency currency, BankCard card) : base(currency) 
            => Card = card ?? throw new ArgumentNullException(nameof(card));

        public override Money On(Timestamp time)
        {
            return new SpecifCard(Currency, Card.CardOn(time));
        }

        public override (Amount, Money) Take(decimal amount)
        {
            return Card.Take(Currency, amount);
        }
    }
}