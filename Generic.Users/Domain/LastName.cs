﻿using Generic.Shared.Domain;

namespace Generic.Users.Domain;

public class LastName : ValueObject
{
    public string Value { get; }

    internal LastName(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}