using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CustomComparator;

internal class OddEvenComparator : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (x % 2 == 0 && y % 2 == 1)
            return -1;
        if (x % 2 == 1 && y % 2 == 0)
            return 1;
        return x - y;
    }
}
