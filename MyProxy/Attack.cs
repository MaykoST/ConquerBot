using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProxy
{
    public class Attack
    {
        public UInt32 Time { get; set; }
        public UInt32 MobUID { get; set; }
        public DateTime SendTime { get; set; }
        public UInt32 PacketTick { get; set; }
        public Location Loc { get; set; }
    }
}
