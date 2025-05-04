using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    internal class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public int? Weight { get; set; }
        public string? Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string weight = Weight?.ToString() ?? "n/a";
            sb.AppendLine($"{Model}:");
            sb.AppendLine(Engine.ToString());
            sb.AppendLine($"  Weight: {weight}");
            sb.Append($"  Color: {Color ?? "n/a"}");
            return sb.ToString();
        }
    }
}
