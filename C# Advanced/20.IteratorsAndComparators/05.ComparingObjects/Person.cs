using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ComparingObjects;

internal class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }
    public int CompareTo(Person? other)
    {
        if (other == null)
            return -1;

        int nameComparison = this.Name.CompareTo(other.Name);
        if (nameComparison != 0)
            return nameComparison;

        int ageComparison = this.Age.CompareTo(other.Age);
        if (ageComparison != 0)
            return ageComparison;

        return this.Town.CompareTo(other.Town);
    }
}
