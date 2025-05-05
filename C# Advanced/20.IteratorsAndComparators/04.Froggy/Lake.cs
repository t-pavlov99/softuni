using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Froggy;

internal class Lake : IEnumerable<int>
{
    private int[] _stones;

    public Lake(int[] stones)
    {
        this._stones = stones;
    }

    public Lake(string stones)
    {
        this._stones = stones.Split(", ").Select(int.Parse).ToArray();
    }

    public IEnumerator<int> GetEnumerator()
    {
        int firstEnd = _stones.Length - 2 + _stones.Length % 2;
        for (int i = 0; i <= firstEnd; i += 2)
            yield return _stones[i];
        for (int i = _stones.Length - 1 - _stones.Length % 2 ; i >= 1; i -= 2)
            yield return _stones[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(", ", _stones);
    }
}
