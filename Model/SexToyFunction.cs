using Buttplug.Client;
using Buttplug.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManakaIntiface.Model
{
    public class SexToyFunction
    {
        public ButtplugClientDevice device { get; set; }
        public uint id {  get; set; }
        public string name { get; set; }
        public double scalar { get; set; }
        public ActuatorType type { get; set; }
        public int stepCount { get; set; }


        public SexToyFunction(ButtplugClientDevice device ,uint id,string name, ActuatorType type, int stepCount)
        {
            this.device = device;
            this.id = id;
            this.name = name;
            //this.scalar = scalar;
            this.type = type;
            this.stepCount = stepCount;
        }

    }
}
