using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Threeuple;
internal class CustomThreeuple<T1, T2, T3> : CustomTuple<T1, T2>
{
    public T3 Item3 { get; set; }

    public CustomThreeuple(T1 item1, T2 item2, T3 item3) : base(item1, item2)
    {
        Item3 = item3;
    }

    public override string ToString()
    {
        return base.ToString() + " -> " + Item3.ToString();
    }
}

