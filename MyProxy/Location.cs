using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProxy
{
    public class Location
    {
        public UInt16 X { get; set; }
        public UInt16 Y { get; set; }
        public UInt16 OldX { get; set; }
        public UInt16 OldY { get; set; }
        public UInt16 Map { get; set; }            
        public UInt16 MapaDinamico { get; set; }
        public DateTime LastJump { get; set; }
        public DateTime LastMove { get; set; }
        public Boolean Valid { get; set; }
        public UInt16 Distance { get; set; }

        public Location()
        {
            Valid = true;
        }

        public Location(UInt16 piX, UInt16 piY)
        {
            X = piX;
            Y = piY;
            Valid = true;
        }

        public Location(UInt16 piX, UInt16 piY, UInt16 pDistance)
        {
            X = piX;
            Y = piY;
            Distance = pDistance;
            Valid = true;
        }

        public String getXY()
        {
            return X + "," + Y;
        }
    }
}
