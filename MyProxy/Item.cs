using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MyProxy
{
    public class Item
    {
        public UInt32 UID { get; set; }
        public String Name { get; set; }
        public UInt32 VarID { get; set; }
        public Location Loc { get; set; }
        public UInt16 PickTries { get; set; }
        public Byte Plus { get; set; }
        public Byte Bless { get; set; }
        public UInt16 MaxDur { get; set; }
        public UInt16 CurDur { get; set; }
        public Byte Location { get; set; }
        public DateTime Ignore { get; set; }

        public static UInt32 Meteor = 1088001;
        public static UInt32 Dragonball = 1088000;
        
        public Item()
        {
            Loc = new Location();
            PickTries = 0;
        }

        public Boolean IsItem()
        {
            if (UID >= 1000000 && UID <= 1072059)
            {
                return false;
            }
            else if (UID >= 1090000 && UID <= 1091020)
            {
                return false;                
            }
            else if (UID >= 300000 && UID <= 380015)
            {
                return false;
            }
            else if (UID >= 710001 && UID <= 790001)
            {
                return false;
            }
            if (UID > 601339)
            {
                return false;
            }          

            return true;
        }
               
        public Char Quality()
        {
            String bt = Convert.ToString(UID);
                    
            return bt[bt.Length - 1];
        }

        public String DescQuality()
        {
            String bt = Convert.ToString(UID);

            switch (bt[bt.Length - 1])
            {
                case '0': return "FIXED";
                case '3': return "CRAP";
                case '4': return "POOR";
                case '5': return "NORMAL";
                case '6': return "REFINED";
                case '7': return "UNIQUE";
                case '8': return "ELITE";
                case '9': return "SUPER";
                default: return "";
            }
        }                
    }

    public static class StaticItemList
    {
        public static Hashtable OreList;
        public static Hashtable GoldOreList;
        public static Hashtable SuperGems;
        public static Hashtable RefGems;
        public static Hashtable HPPots;

        static StaticItemList()
        {
            OreList = new Hashtable();
            GoldOreList = new Hashtable();
            SuperGems = new Hashtable();
            RefGems = new Hashtable();
            HPPots = new Hashtable();

            OreList.Add(1072010U, 1072010); //Ferro1
            OreList.Add(1072011U, 1072011);
            OreList.Add(1072012U, 1072012);
            OreList.Add(1072013U, 1072013);
            OreList.Add(1072014U, 1072014);
            OreList.Add(1072015U, 1072015);
            OreList.Add(1072016U, 1072016);
            OreList.Add(1072017U, 1072017);
            OreList.Add(1072018U, 1072018);
            OreList.Add(1072019U, 1072019); //Ferro9
            OreList.Add(1072020U, 1072020); //Cobre1
            OreList.Add(1072021U, 1072021);
            OreList.Add(1072022U, 1072022);
            OreList.Add(1072023U, 1072023);
            OreList.Add(1072024U, 1072024);
            OreList.Add(1072025U, 1072025);
            OreList.Add(1072026U, 1072026);
            OreList.Add(1072027U, 1072027);
            OreList.Add(1072028U, 1072028);
            OreList.Add(1072029U, 1072029); //Cobre9
            OreList.Add(1072031U, 1072031); //Euxenite
            OreList.Add(1072040U, 1072040); //Prata1
            OreList.Add(1072041U, 1072041);
            OreList.Add(1072042U, 1072042);
            OreList.Add(1072043U, 1072043);
            OreList.Add(1072044U, 1072044);
            OreList.Add(1072045U, 1072045);
            OreList.Add(1072046U, 1072046);
            OreList.Add(1072047U, 1072047);
            OreList.Add(1072048U, 1072048);
            OreList.Add(1072049U, 1072049); //Prata9   

            GoldOreList.Add(1072050U, 1072050); //Gold1
            GoldOreList.Add(1072051U, 1072051);
            GoldOreList.Add(1072052U, 1072052);
            GoldOreList.Add(1072053U, 1072053);
            GoldOreList.Add(1072054U, 1072054);
            GoldOreList.Add(1072055U, 1072055);
            GoldOreList.Add(1072056U, 1072056);
            GoldOreList.Add(1072057U, 1072057);
            GoldOreList.Add(1072058U, 1072058);
            GoldOreList.Add(1072059U, 1072059);

            SuperGems.Add(700003U, 700003);
            SuperGems.Add(700013U, 700013);
            SuperGems.Add(700023U, 700023);
            SuperGems.Add(700033U, 700033);
            SuperGems.Add(700053U, 700053);
            SuperGems.Add(700063U, 700063);
            SuperGems.Add(700073U, 700073);            
            SuperGems.Add(700103U, 700103);
            SuperGems.Add(700123U, 700123);

            //RefGems.Add(700002U, 700002);
            RefGems.Add(700012U, 700012);
            //RefGems.Add(700022U, 700022);
            //RefGems.Add(700032U, 700032);
            //RefGems.Add(700052U, 700052);
            //RefGems.Add(700062U, 700062);
            //RefGems.Add(700072U, 700072);            
            RefGems.Add(700102U, 700102);
            RefGems.Add(700122U, 700122);

            //HPPots
            HPPots.Add(1000000U, 1000000U);
            HPPots.Add(1000010U, 1000010U);
            HPPots.Add(1000020U, 1000020U);
            HPPots.Add(1000030U, 1000030U);
            HPPots.Add(1002000U, 1002000U);
            HPPots.Add(1002010U, 1002010U);
            HPPots.Add(1002020U, 1002020U);
            HPPots.Add(1002050U, 1002050U);
        }
        /*
         * 1060020 PortalCidadeDragão 0 0 0 0 0 0 0 0 0 0 200 13021 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 1 ItemComum Clique~para~ser~teleportado~para~Cidade~Dragão 6
            1060021 PortalCidadeDeserto 0 0 0 0 0 0 0 0 0 0 200 13022 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 1 ItemComum Clique~para~ser~teleportado~para~Cidade~Deserto 6
            1060022 PortalCidadeSímios 0 0 0 0 0 0 0 0 0 0 200 13023 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 1 ItemComum Clique~para~ser~teleportado~para~Montanha~Símios 6
            1060023 PortalCasteloFênix 0 0 0 0 0 0 0 0 0 0 200 13024 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 1 ItemComum Clique~para~ser~teleportado~para~Castelo~Fênix 6
            1060024 PortalIlhaPássaros 0 0 0 0 0 0 0 0 0 0 200 13025 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 1 ItemComum Clique~para~ser~teleportado~para~Ilha~dos~Pássaros 6
            1060102 PortalCidadePedra 0 0 0 0 0 0 0 0 0 0 200 301000 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ItemComum Teleporte~para~Cidade~Pedra~no~Deserto 5  
        */
        /*
        1090000 Prata 0 0 0 0 0 0 0 0 0 0 0 10001 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 ItemRaro Nada 5
        1090010 Prata 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 ItemRaro Nada 5
        1090020 Ouro 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 ItemRaro Nada 5
        1091000 MuitoOuro 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 ItemRaro Nada 5
        1091010 BarraDeOuro 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 ItemRaro Nada 5
        1091020 BarrasDeOuro 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 ItemRaro Nada 5
        */
        /*
         * 1000000 ErvaCurativa 0 0 0 0 0 0 0 0 0 0 5 0 0 0 0 0 0 70 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
           1000010 Resolutivo 0 0 0 0 0 0 0 0 0 0 18 0 0 0 0 0 0 100 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
           1000020 Analgésico 0 0 0 0 0 0 0 0 0 0 60 0 0 0 0 0 0 250 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1000030 Amrita 0 0 0 0 0 0 0 0 0 0 120 0 0 0 0 0 0 500 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1001000 Mercúrio 0 0 0 0 0 0 0 0 0 0 6 0 0 0 0 0 0 0 70 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1001010 Tônico 0 0 0 0 0 0 0 0 0 0 60 0 0 0 0 0 0 0 200 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1001020 CháCurativo 0 0 0 0 0 0 0 0 0 0 225 0 0 0 0 0 0 0 450 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1001030 PílulaCurativa 0 0 0 0 0 0 0 0 0 0 450 0 0 0 0 0 0 0 1000 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1001040 PílulaEspiritual 0 0 0 0 0 0 0 0 0 0 1000 0 0 0 0 0 0 0 2000 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1002000 Panacéia 0 0 0 0 0 0 0 0 0 0 240 0 0 0 0 0 0 800 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1002010 Ginseng 0 0 0 0 0 0 0 0 0 0 360 0 0 0 0 0 0 1200 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1002020 Baunilha 0 0 0 0 0 0 0 0 0 0 600 0 0 0 0 0 0 2000 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1002030 PílulaRefrescante 0 0 0 0 0 0 0 0 0 0 1500 0 0 0 0 0 0 0 3000 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1002040 PílulaEncantada 0 0 0 0 0 0 0 0 0 0 2300 0 0 0 0 0 0 0 4500 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
            1002050 Mil.Ginseng 0 0 0 0 0 0 0 0 0 0 1000 0 0 0 0 0 0 3000 0 1 1 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Droga Nada 5
        */
        /*
         * 700001 GemaFênix 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Gema Normal.~Adiciona~5%~de~ataque~mágico.~Pode~ser~composta~em~uma~refinada~com~Joalheiro~no~Mercado~(240,256). 5
           700002 GemaFênix 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 65 Gema Refinada.~Adiciona~10%~de~ataque.~Pode~ser~composta~em~uma~super~com~Joalheiro~no~Mercado~(240,256). 7
           700003 GemaFênix 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 1 975 Gema Super.~Adiciona~15%~de~ataque~mágico. 8
           700011 GemaDragão 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Gema Normal.~Adiciona~5%~de~ataque~físico.~Pode~ser~composta~em~uma~refinada~com~Joalheiro~no~Mercado~(240,256). 5
           700012 GemaDragão 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 65 Gema Refined.~Adiciona~10%~de~ataque~físico.~Pode~ser~composta~em~uma~super~com~Joalheiro~no~Mercado~(240,256). 7
           700013 GemaDragão 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 1 975 Gema Super.~Adiciona~15%~de~ataque~físico. 8
           700021 GemaFúria 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Gema Normal.~Adiciona~5%~de~precisão.~Pode~ser~composta~em~uma~refinada~com~Joalheiro~no~Mercado~(240,256). 5
           700022 GemaFúria 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 45 Gema Refined.~Adiciona~10%~de~precisão.~Pode~ser~composta~em~uma~super~com~Joalheiro~no~Mercado~(240,256).. 7
           700023 GemaFúria 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 1 675 Gema Super.~Adiciona~15%~de~precisão. 8
           700031 GemaArcoÍris 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Gema Normal.~Adiciona~10%~de~experiência.~Pode~ser~composta~em~uma~refinada~com~Joalheiro~no~Mercado~(240,256). 5
           700032 GemaArcoÍris 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 65 Gema Refined.~Adiciona~15%~de~experiência.~Pode~ser~composta~em~uma~super~com~Joalheiro~no~Mercado~(240,256). 7
           700033 GemaArcoÍris 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 1 975 Gema Super.~Adiciona~25%~de~experiência. 8
           700041 GemaKylin 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Gema Normal.~Adiciona~50%~de~durabilidade.~Pode~ser~composta~em~uma~refinada~com~Joalheiro~no~Mercado~(240,256). 5
           700042 GemaKylin 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 35 Gema Refined.~Adiciona~100%~de~durabilidade.~Pode~ser~composta~em~uma~super~com~Joalheiro~no~Mercado~(240,256). 7
           700043 GemaKylin 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 1 525 Gema Super.~Adiciona~200%~de~durabilidade. 8
           700051 GemaVioleta 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Gema Normal.~Adiciona~30%~de~habilidade~de~arma.~Pode~ser~composta~em~uma~refinada~com~Joalheiro~no~Mercado~(240,256). 5
           700052 GemaVioleta 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 45 Gema Refined.~Adiciona~50%~de~habilidade~de~arma.~Pode~ser~composta~em~uma~super~com~Joalheiro~no~Mercado~(240,256). 7
           700053 GemaVioleta 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 1 675 Gema Super.~Adiciona~100%~de~habilidade~de~arma. 8
           700061 GemaLua 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Gema Normal.~Adiciona~15%~de~experiência~mágica.~Pode~ser~composta~em~uma~refinada~com~Joalheiro~no~Mercado~(240,256). 5
           700062 GemaLua 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 45 Gema Refined.~Adiciona~30%~de~experiência~mágica.~Pode~ser~composta~em~uma~super~com~Joalheiro~no~Mercado~(240,256). 7
           700063 GemaLua 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 1 675 Gema Super.~Adiciona~50%~de~experiência~mágica. 8
           700071 GemaTartaruga 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Gema Normal.~Reduz~2%~dos~danos. 5
           700072 GemaTartaruga 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Gema Refined.~Reduz~4%~dos~danos. 5
           700073 GemaTartaruga 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 199 199 0 0 0 0 0 0 0 0 1 1000 0 0 0 780 Gema Super.~Reduz~6%~dos~danos. 8
           700101 GemaTrovão 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 198 198 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Gema Normal.~Pode~Apenas~ser~usada~no~Leque~Divino~para~aumentar~o~ataque~por~100~pontos.~Atualizável~com~a~ajuda~do~Joalheiro~no~Mercado. 5
           700102 GemaTrovão 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 198 198 0 0 0 0 0 0 0 0 1 1000 0 0 0 185 Gema Refined.~Pode~Apenas~ser~usada~no~Leque~Divino~para~aumentar~o~ataque~por~300~pontos.~Atualizável~com~a~ajuda~do~Joalheiro~no~Mercado. 8
           700103 GemaTrovão 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 198 198 0 0 0 0 0 0 0 0 1 1000 0 0 0 2775 Gema Super.~Pode~Apenas~ser~usada~no~Leque~Divino~para~aumentar~o~ataque~por~500~pontos. 9
           700121 GemaGlória 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 198 198 0 0 0 0 0 0 0 0 1 1000 0 0 0 0 Gema Normal.~Pode~apenas~ser~usado~na~Torre~Estelar~para~diminuir~o~ataque~por~100~pontos.~Atualizável~com~a~ajuda~do~Joalheiro~no~Mercado. 5
           700122 GemaGlória 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 198 198 0 0 0 0 0 0 0 0 1 1000 0 0 0 185 Gema Refined.~Pode~apenas~ser~usado~na~Torre~Estelar~para~diminuir~o~ataque~por~300~pontos.~Atualizável~com~a~ajuda~do~Joalheiro~no~Mercado. 8
           700123 GemaGlória 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 198 198 0 0 0 0 0 0 0 0 1 1000 0 0 0 2775 Gema Super.~Pode~apenas~ser~usado~na~Torre~Estelar~para~diminuir~o~ataque~por~500~pontos.. 9
        1072010 MinérioDeFerro1 0 0 0 0 0 0 0 0 0 0 62 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072011 MinérioDeFerro2 0 0 0 0 0 0 0 0 0 0 129 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072012 MinérioDeFerro3 0 0 0 0 0 0 0 0 0 0 196 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072013 MinérioDeFerro4 0 0 0 0 0 0 0 0 0 0 264 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072014 MinérioDeFerro5 0 0 0 0 0 0 0 0 0 0 326 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072015 MinérioDeFerro6 0 0 0 0 0 0 0 0 0 0 393 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072016 MinérioDeFerro7 0 0 0 0 0 0 0 0 0 0 456 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072017 MinérioDeFerro8 0 0 0 0 0 0 0 0 0 0 523 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072018 MinérioDeFerro9 0 0 0 0 0 0 0 0 0 0 590 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072019 MinérioDeFerro10 0 0 0 0 0 0 0 0 0 0 652 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072020 MinérioDeCobre1 0 0 0 0 0 0 0 0 0 0 129 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072021 MinérioDeCobre2 0 0 0 0 0 0 0 0 0 0 264 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072022 MinérioDeCobre3 0 0 0 0 0 0 0 0 0 0 393 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072023 MinérioDeCobre4 0 0 0 0 0 0 0 0 0 0 523 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072024 MinérioDeCobre5 0 0 0 0 0 0 0 0 0 0 652 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072025 MinérioDeCobre6 0 0 0 0 0 0 0 0 0 0 782 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072026 MinérioDeCobre7 0 0 0 0 0 0 0 0 0 0 916 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072027 MinérioDeCobre8 0 0 0 0 0 0 0 0 0 0 1046 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072028 MinérioDeCobre9 0 0 0 0 0 0 0 0 0 0 1176 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072029 MinérioDeCobre10 0 0 0 0 0 0 0 0 0 0 1310 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072031 MinérioEuxemita 0 0 0 0 0 0 0 0 0 0 0 1000 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072040 MinérioDePrata1 0 0 0 0 0 0 0 0 0 0 288 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072041 MinérioDePrata2 0 0 0 0 0 0 0 0 0 0 576 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072042 MinérioDePrata3 0 0 0 0 0 0 0 0 0 0 864 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072043 MinérioDePrata4 0 0 0 0 0 0 0 0 0 0 1152 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072044 MinérioDePrata5 0 0 0 0 0 0 0 0 0 0 1440 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072045 MinérioDePrata6 0 0 0 0 0 0 0 0 0 0 1728 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072046 MinérioDePrata7 0 0 0 0 0 0 0 0 0 0 2016 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072047 MinérioDePrata8 0 0 0 0 0 0 0 0 0 0 2304 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072048 MinérioDePrata9 0 0 0 0 0 0 0 0 0 0 2592 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072049 MinérioDePrata10 0 0 0 0 0 0 0 0 0 0 2880 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072050 MinérioDeOuro1 0 0 0 0 0 0 0 0 0 0 4320 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072051 MinérioDeOuro2 0 0 0 0 0 0 0 0 0 0 8640 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072052 MinérioDeOuro3 0 0 0 0 0 0 0 0 0 0 12960 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072053 MinérioDeOuro4 0 0 0 0 0 0 0 0 0 0 27360 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072054 MinérioDeOuro5 0 0 0 0 0 0 0 0 0 0 36960 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072055 MinérioDeOuro6 0 0 0 0 0 0 0 0 0 0 41280 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072056 MinérioDeOuro7 0 0 0 0 0 0 0 0 0 0 43200 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072057 MinérioDeOuro8 0 0 0 0 0 0 0 0 0 0 45120 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072058 MinérioDeOuro9 0 0 0 0 0 0 0 0 0 0 49440 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
        1072059 MinérioDeOuro10 0 0 0 0 0 0 0 0 0 0 59040 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 Minério Nada 5
     */
    }
}
