using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    internal class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int minValue, int maxValue) 
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public override bool IsValid(object obj)
        {
            return (MinValue <= (int) obj) && (MaxValue >= (int)obj);
        }
    }
}
