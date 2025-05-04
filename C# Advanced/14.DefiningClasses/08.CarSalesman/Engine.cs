using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    public class Engine
    {
        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get ; set; }
        public string? Efficiency { get; set; }

        public override string ToString()
        {
            string displacement = Displacement?.ToString() ?? "n/a";
            string efficiency = Efficiency ?? "n/a";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {Model}:");
            sb.AppendLine($"    Power: {Power}");
            sb.AppendLine($"    Displacement: {displacement}");
            sb.Append($"    Efficiency: {efficiency}");
            return sb.ToString();
        }
    }
}
