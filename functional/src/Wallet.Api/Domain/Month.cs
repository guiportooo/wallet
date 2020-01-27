using System;

namespace Wallet.Api.Domain
{
    public class Month : IEquatable<Month>, IComparable<DateTime>
    {
        private Date Value { get; }

        public Month(int year, int month)
        {
            Value = new Date(year, month, 1);
        }

        public bool Equals(Month other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Value, other.Value);
        }

        public int CompareTo(DateTime other) =>
            Value.CompareTo(other);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Month && Equals((Month) obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }

        public static bool operator ==(Month a, Month b) =>
            ReferenceEquals(a, null) && ReferenceEquals(b, null) ||
            !ReferenceEquals(a, null) && a.Equals(b);

        public static bool operator !=(Month a, Month b) => !(a == b);
    }
}