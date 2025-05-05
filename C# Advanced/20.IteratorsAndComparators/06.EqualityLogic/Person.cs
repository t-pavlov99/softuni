using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.EqualityLogic;

internal class Person : IEquatable<Person>, IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int CompareTo(Person? other)
    {
        if (other == null)
            return -1;

        int nameComparison = this.Name.CompareTo(other.Name);
        if (nameComparison != 0)
            return nameComparison;

        return this.Age.CompareTo(other.Age);
    }

    public bool Equals(Person? other)
    {
        return this.CompareTo(other) == 0;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Person)
        {
            return false;
        }
        return this.Equals(obj);
    }

    public override int GetHashCode()
    {
        int code = Age;
        if (code == 0)
            code = 150;
        foreach (char c in this.Name)
            code *= c;
        return code;
    }
}
