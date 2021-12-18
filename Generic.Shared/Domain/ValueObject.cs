namespace Generic.Shared.Domain;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((ValueObject)obj);
    }

    public bool Equals(ValueObject? other)
    {
        if (other == null || other.GetType() != GetType())
        {
            return false;
        }

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents().Select(x => x.GetHashCode()).Aggregate((x, y) => x ^ y);
    }

    public static bool operator ==(ValueObject? one, ValueObject? two)
    {
        if (one is null || two is null)
        {
            return false;
        }

        return one.Equals(two);
    }

    public static bool operator !=(ValueObject? one, ValueObject? two)
    {
        if (one is null || two is null)
        {
            return false;
        }

        return !one.Equals(two);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();
}