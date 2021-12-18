namespace Generic.Shared.Domain;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public bool Equals(ValueObject? other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((ValueObject)obj);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}