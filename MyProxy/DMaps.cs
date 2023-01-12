using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace MyProxy
{
    public class DMaps
    {
        public ArrayList MapsNeeded { get; set; }
        public Hashtable H_DMaps { get; set; }
        public String ConquerPath { get; set; }

        public DMaps(String pPath)
        {
            MapsNeeded = new ArrayList() { 1000, 1001, 1002, 1036, 1037, 1039, 1011, 1015, 1020, 1010, 1076 };
            H_DMaps = new Hashtable();
            ConquerPath = pPath;
        }

        public void Load()
        {
            FileStream FS = new FileStream(ConquerPath + @"ini\GameMap.dat", FileMode.Open);
            BinaryReader BR = new BinaryReader(FS);

            UInt32 MapCount = BR.ReadUInt32();
            for (uint i = 0; i < MapCount; i++)
            {
                UInt16 MapID = (UInt16)BR.ReadUInt32();
                string Path = Encoding.ASCII.GetString(BR.ReadBytes(BR.ReadInt32()));
                if (!H_DMaps.Contains(MapID))
                {
                    DMap D = new DMap(MapID, ConquerPath + Path);
                    H_DMaps.Add(MapID, D);
                }
                BR.ReadInt32();
            }
            BR.Close();
            FS.Close();
        }
    }
    public class DMapCell
    {
        public Boolean NoAccess { get; set; }

        public Int16 SurfaceType { get; set; }

        public Int16 Height { get; set; }

        public DMapCell(Boolean pNoAccess, Int16 pSurfaceType, Int16 pHeight)
        {
            NoAccess = pNoAccess;
            SurfaceType = pSurfaceType;
            Height = pHeight;
        }
    }
    public class DMap
    {

        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
        private DMapCell[,] Cells;
        public UInt16 MapID { get; set; }
        public String Path { get; set; }

        public Boolean Loaded { get; set; }

        public DMap(UInt16 pMapID, String pPath)
        {
            MapID = pMapID;
            Path = pPath;
            Loaded = false;
        }

        public void Load()
        {
            if (File.Exists(Path))
            {
                FileStream FS = new FileStream(Path, FileMode.Open);
                BinaryReader BR = new BinaryReader(FS);
                BR.ReadBytes(268);
                Width = BR.ReadInt32();
                Height = BR.ReadInt32();
                Cells = new DMapCell[Width, Height];

                Byte[] cell_data = BR.ReadBytes(((6 * Width) + 4) * Height);
                int offset = 0;

                for (int y = 0; y < Width; y++)
                {
                    for (int x = 0; x < Height; x++)
                    {
                        Boolean noAccess = BitConverter.ToBoolean(cell_data, offset) != false;
                        offset += 2;
                        Int16 surfaceType = BitConverter.ToInt16(cell_data, offset);
                        offset += 2;
                        Int16 height = BitConverter.ToInt16(cell_data, offset);
                        offset += 2;
                        Cells[x, y] = new DMapCell(noAccess, surfaceType, height);
                    }
                    offset += 4;
                }
                BR.Close();
                FS.Close();

                Loaded = true;
            }
        }

        public void Unload()
        {
            Cells = null;
            Loaded = false;
        }

        public DMapCell GetCell(ushort X, ushort Y)
        {
            if (X < this.Width && Y < this.Height)
            {
                return Cells[X, Y];
            }
            else
            {
                return null;
            }            
        }

        public Boolean CanAccess(ushort pX, ushort pY)
        {
            //Funcao para incluir as pontes bugadas que tem um misterio
            if (MapID == 1002)
            {
                if (MyMath.Inside(144, 542, 195, 544, pX, pY))
                {
                    return true;
                }
                else if (MyMath.Inside(603, 676, 642, 678, pX, pY))
                {
                    return true;
                }                
                else if (pX >= 645 && pY <= 675 && pX <= 650 && pY >= 670)
                {
                    return false;
                }
                else if (pX == 244 && pY == 534)
                {
                    return false;
                }
            }

            DMapCell cell = GetCell(pX, pY);

            if (cell != null)
            {
                return !cell.NoAccess;
            }
            else
            {
                return false;
            }
        }
    }
}
