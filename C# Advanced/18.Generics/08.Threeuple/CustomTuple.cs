﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Threeuple;

internal class CustomTuple<T1, T2>
{
    public T1 Item1 { get; set; }
    public T2 Item2 { get; set; }

    public CustomTuple()
    {
    }
    public CustomTuple(T1 item1, T2 item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }
    public override string ToString()
    {
        return $"{Item1.ToString()} -> {Item2.ToString()}";
    }

}
