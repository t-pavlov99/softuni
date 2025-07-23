using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    internal class Robot : IIdentifiable
    {
        public string Id { get; set; }
        public string Model { get; set; }

        public Robot(string id, string model)
        {
            Id = id;
            Model = model;
        }
    }
}
