using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProxy
{
    public class NPC
    {
        public UInt32 UID { get; set; }        
        public Location Loc { get; set; }

        public NPC()
        {
            Loc = new Location();
        }
    }
}
