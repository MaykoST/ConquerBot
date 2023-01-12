using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProxy
{
    public class BlueMap
    {        
        public UInt16 MapID { get; set; }
        public Location Voltar { get; set; }
        public Location Esquerda { get; set; }
        public Location Abaixo { get; set; }
        public Boolean TemRato { get; set; }

        public BlueMap MapaVoltar { get; set; }
        public BlueMap MapaEsquerda { get; set; }
        public BlueMap MapaAbaixo { get; set; }

        public DateTime UltimaVisita { get; set; }
        public Boolean Explorou { get; set; }

        public BlueMap(UInt16 pMapID, BlueMap pVoltar)
            : this(pMapID)
        {
            this.MapaVoltar = pVoltar;
        }

        public BlueMap(UInt16 pMapID)
        {
            this.MapID = pMapID;
            this.TemRato = true;
            this.UltimaVisita = DateTime.Now;
            this.Explorou = false;

            if (this.MapID == 1025)
            {
                this.Voltar = new Location(27, 65);
                this.Abaixo = new Location(168, 111);
                this.Esquerda = new Location(113, 160);
                this.TemRato = false;
            }
            else if (this.MapID == 1500)
            {
                //Voltar(073, 013), Abaixo(168,111), Esquerda (113, 160)
                this.Voltar = new Location(73, 13);
                this.Abaixo = new Location(168, 111);
                this.Esquerda = new Location(113, 160);                
            }
            else if (this.MapID == 1501)
            {
                //Voltar(013, 078), Abaixo(168,111), Esquerda (113, 160)
                this.Voltar = new Location(13, 78);
                this.Abaixo = new Location(168, 111);
                this.Esquerda = new Location(113, 160);
            }
            else if (this.MapID == 1502)
            {
                //Voltar(013, 078), null, null
                this.Voltar = new Location(13, 78);
                this.Abaixo = null;
                this.Esquerda = null;
            }
            else if (this.MapID == 1503)
            {
                //Voltar(073, 013), null, null
                this.Voltar = new Location(73, 13);
                this.Abaixo = null;
                this.Esquerda = null;
            }
        }
    }
}
