using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses;
public class Family
{
    private List<Person> members = new List<Person>();
    public void AddMember(Person member)
    {
        members.Add(member);
    }

    public Person GetOldestMember()
    {
        return members.OrderByDescending(m => m.Age).FirstOrDefault();
    }
}
