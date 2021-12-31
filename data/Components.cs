using System;
using System.Collections.Generic;

namespace Task_2.data
{
    public class Components
    {
        public String type { get; set; }
        public String ID { get; set; }
        public Component component { get; set; }
         public Dictionary <String,dynamic> netlist { get; set; }
    }
}