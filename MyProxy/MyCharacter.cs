using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using Algorithms;
using System.Threading;

namespace MyProxy
{
    public class StatusEffect2
    {
        public static UInt64 NinjaXP = 0x800000000000;
    }
    public class StatusEffect
    {
        public static UInt32 Normal = 0x0;
        public static UInt32 BlueName = 0x1;
        public static UInt32 Poisoned = 0x2;
        public static UInt32 Gone = 0x4;
        public static UInt32 XPStart = 0x10;
        public static UInt32 SomeShit = 0x20;
        public static UInt32 TeamLeader = 0x40;
        public static UInt32 Accuracy = 0x80;
        public static UInt32 Shield = 0x100;
        public static UInt32 Stigma = 0x200;
        public static UInt32 Dead = 0x400;
        public static UInt32 Invisible = 0x400000;
        public static UInt32 RedName = 0x4000;
        public static UInt32 BlackName = 0x8000;
        public static UInt32 SuperMan = 0x40000;
        public static UInt32 Cyclone = 0x800000;
        public static UInt32 Fly = 0x8000000;
        public static UInt32 Pray = 0x40000000;
        public static UInt32 GetLuckyTime = 0x80000000;
    }

    public class Status
    {
        public UInt64 Code { get; set; }
        public Boolean Effect { get; set; }
        public Boolean Skill { get; set; }
        public Boolean Enabled { get; set; }

        public Status()
        {
            Skill = false;
            Effect = true;
            Enabled = true;
        }

        public Status(UInt64 pCode, Boolean pEffect, Boolean pSkill)
        {
            Code = pCode;
            Skill = pSkill;
            Effect = pEffect;
            Enabled = true;
        }
    }

    public delegate void StopBotDelegate();

    public class MyCharacter
    {
        public event StopBotDelegate StopEvent;

        public UInt32 UID { get; set; }
        public String Name { get; set; }

        public Location Loc { get; set; }
        public Location MoverPara { get; set; }
        public Location VoltarPara { get; set; }
        public ArrayList PathList { get; set; }

        public Byte Job { get; set; }
        public UInt32 HP { get; set; }

        public Hashtable Status { get; set; }
        public DateTime LastAttackTime { get; set; }
        public Attack LastAttack { get; set; }
        public Boolean ValidAttack { get; set; }
        public UInt32 LastMob { get; set; }

        public DateTime DeadTime { get; set; }

        public Boolean Booting { get; set; }
        public Boolean Mining { get; set; }
        public Boolean BlueMouse { get; set; }

        public DMaps MapList { get; set; }
        public List<Item> ItemList { get; set; }
        public List<Item> PickList { get; set; }
        public List<Item> IgnoreList { get; set; }
        public String LastDropName { get; set; }
        public List<Item> PickListFilter { get; set; }
        public Boolean PickPlus { get; set; }
        public Char PickQuality { get; set; }
        public List<Mob> VisibleMobs { get; set; }
        public List<NPC> NPCList { get; set; }

        public List<Item> BagList { get; set; }

        public UInt32 MobCount { get; set; }

        public GameProxy Proxy { get; set; }
        public Client MyClient { get; set; }

        public Int32 AtkDelay { get; set; }
        public Int32 XPAtkDelay { get; set; }
        public Int32 MaxAtkWait { get; set; }
        public Int32 JumpDelay { get; set; }
        public Int32 XPJumpDelay { get; set; }

        public Boolean XPMode { get; set; }

        public DateTime LastUseItem { get; set; }
        public Int32 UseItemDelay { get; set; }
        public DateTime LastMine { get; set; }

        public String MobFilter { get; set; }

        public UInt32 MinHP { get; set; }
        public UInt32 PotionHP { get; set; }

        public List<Item> EquipList { get; set; }
        public List<Item> DropList { get; set; }

        public DateTime LastXPTime { get; set; }

        public UInt16 MaxJumpRange { get; set; }

        public UInt32 ArrowID { get; set; }
        public UInt16 NPCX { get; set; }
        public UInt16 NPCY { get; set; }
        public UInt16 MaxArrowBuy { get; set; }
        public Boolean UseScatter { get; set; }

        public Boolean CanPickItens { get; set; }

        public Boolean NinjaFastMode { get; set; }

        public ArrayList MessageList { get; set; }

        public EntradaMina entraMina { get; set; }
        public int Delay { get; set; }
        public DateTime DelayStart { get; set; }

        public BlueMap BlueMapInicio { get; set; }
        public BlueMap BlueMapAtual { get; set; }
        public Dictionary<UInt16, BlueMap> BlueMapList { get; set; }

        public Boolean ValidMap { get; set; }

        public CompraAgulha compraAgulha { get; set; }

        public Boolean MoveMouse { get; set; }

        public MyCharacter(GameProxy pProxy, Client pClient)
        {
            Proxy = pProxy;
            MyClient = pClient;
            Loc = new Location();
            VisibleMobs = new List<Mob>();
            NPCList = new List<NPC>();
            Status = new Hashtable();
            PathList = new ArrayList();
            Booting = false;
            ValidAttack = true;
            MobCount = 0;

            AtkDelay = 400;
            XPAtkDelay = 50;
            MaxAtkWait = 4000;
            JumpDelay = 900;
            XPJumpDelay = 900;
            XPMode = false;

            UseItemDelay = 1500;

            PickList = new List<Item>();
            IgnoreList = new List<Item>();
            PickPlus = false;
            PickQuality = '8';

            BagList = new List<Item>();
            EquipList = new List<Item>();
            DropList = new List<Item>();
            MessageList = new ArrayList();

            MapList = new DMaps(Proxy.ConquerPath);
            MapList.Load();

            MobFilter = "";
            MinHP = 100;
            PotionHP = 150;
            LastDropName = "";

            MaxJumpRange = 15;
            MaxArrowBuy = 10;
            UseScatter = false;

            CanPickItens = true;
            NinjaFastMode = false;

            LoadItems();
            UpdatePickListFilter("1088001,1088000,1091000,1091010,1091020"); //Meteor, Dragonball 1090020
            //1090020 Ouro         

            this.BlueMapList = new Dictionary<UInt16, BlueMap>();

            //Cria a estrutura de mapas para a quest BlueMouse
            this.BlueMapInicio = new BlueMap(1025);
            BlueMap lEsquerda1 = new BlueMap(1500, this.BlueMapInicio);
            BlueMap lEsquerda2 = new BlueMap(1500, lEsquerda1);
            lEsquerda2.MapaAbaixo = new BlueMap(1502, lEsquerda2);
            lEsquerda2.MapaEsquerda = new BlueMap(1503, lEsquerda2);
            BlueMap lEsquerdaAbaixo = new BlueMap(1501, lEsquerda1);
            lEsquerdaAbaixo.MapaAbaixo = new BlueMap(1502, lEsquerdaAbaixo);
            lEsquerdaAbaixo.MapaEsquerda = new BlueMap(1503, lEsquerdaAbaixo);
            lEsquerda1.MapaEsquerda = lEsquerda2;
            lEsquerda1.MapaAbaixo = lEsquerdaAbaixo;
            this.BlueMapInicio.MapaEsquerda = lEsquerda1;

            BlueMap lAbaixo1 = new BlueMap(1501, this.BlueMapInicio);
            BlueMap lAbaixo2 = new BlueMap(1501, lAbaixo1);
            lAbaixo2.MapaAbaixo = new BlueMap(1502, lAbaixo2);
            lAbaixo2.MapaEsquerda = new BlueMap(1503, lAbaixo2);
            BlueMap lAbaixoEsquerda = new BlueMap(1500, lAbaixo1);
            lAbaixoEsquerda.MapaEsquerda = new BlueMap(1503, lAbaixoEsquerda);
            lAbaixoEsquerda.MapaAbaixo = new BlueMap(1502, lAbaixoEsquerda);
            lAbaixo1.MapaAbaixo = lAbaixo2;
            lAbaixo1.MapaEsquerda = lAbaixoEsquerda;
            this.BlueMapInicio.MapaAbaixo = lAbaixo1;

            this.BlueMapList.Add(1025, this.BlueMapInicio);
            this.BlueMapList.Add(2000, lEsquerda1);
            this.BlueMapList.Add(2002, lEsquerda2);
            this.BlueMapList.Add(2003, lEsquerdaAbaixo);
            this.BlueMapList.Add(2006, lEsquerda2.MapaEsquerda);
            this.BlueMapList.Add(2007, lEsquerda2.MapaAbaixo);
            this.BlueMapList.Add(2008, lEsquerdaAbaixo.MapaEsquerda);
            this.BlueMapList.Add(2009, lEsquerdaAbaixo.MapaAbaixo);
            this.BlueMapList.Add(2001, lAbaixo1);
            this.BlueMapList.Add(2004, lAbaixoEsquerda);
            this.BlueMapList.Add(2005, lAbaixo2);
            this.BlueMapList.Add(2010, lAbaixoEsquerda.MapaEsquerda);
            this.BlueMapList.Add(2011, lAbaixoEsquerda.MapaAbaixo);
            this.BlueMapList.Add(2012, lAbaixo2.MapaEsquerda);
            this.BlueMapList.Add(2013, lAbaixo2.MapaAbaixo);

            this.BlueMapAtual = null;
            this.ValidMap = true;
        }

        public void UpdatePickListFilter(String psFilter)
        {
            PickListFilter = new List<Item>();

            String[] list = psFilter.Split(',');
            UInt32 uid;
            foreach (String filter in list)
            {
                uid = Convert.ToUInt32(filter);

                Item item = this.ItemList.FirstOrDefault(p => p.UID == uid);

                if (item != null)
                {
                    PickListFilter.Add(item);
                }
                else
                {
                    Log.Message("Item do filtro não encontrado UID: " + uid);
                }
            }
        }

        public void LoadItems()
        {
            ItemList = new List<Item>();
            using (StreamReader stream = new StreamReader("itemtype2.txt", true))
            {
                String line = stream.ReadLine(); //Skip First line
                // Read and display lines from the file until the end of
                // the file is reached.                
                while ((line = stream.ReadLine()) != null)
                {
                    String[] tokens = line.Split(' ');

                    try
                    {
                        UInt32 id = Convert.ToUInt32(tokens[0]);
                        String name = tokens[1];

                        Item it = new Item();
                        it.UID = id;
                        it.Name = name;

                        ItemList.Add(it);
                    }
                    catch (Exception ex)
                    {
                        Log.Exception(ex);
                    }
                }
            }
        }

        private Boolean JumpInterval()
        {

            if (XPMode)
            {
                return Loc.LastJump.AddMilliseconds(XPJumpDelay) <= DateTime.Now;
            }
            else
            {
                return Loc.LastJump.AddMilliseconds(JumpDelay) <= DateTime.Now;
            }

        }

        public Boolean PickItens()
        {
            if (CanPickItens)
            {
                if (PickList.Count > 0)
                {
                    foreach (Item it in PickList)
                    {
                        if (it.PickTries >= 10)
                        {
                            PickList.Remove(it);
                        }

                        if (MyMath.PointDistance(this.Loc.X, this.Loc.Y, it.Loc.X, it.Loc.Y) == 0)
                        {
                            //PickItem
                            Packet pack = PacketFactory.PickItem(UID, it.VarID, it.Loc.X, it.Loc.Y);
                            Proxy.HandleClientPacket(MyClient, pack.Data, true);

                            PickList.Remove(it);
                            return true;
                        }
                        else if (MyMath.PointDistance(this.Loc.X, this.Loc.Y, it.Loc.X, it.Loc.Y) <= 10)
                        {
                            if (JumpInterval())
                            {
                                if (!Jump(it.Loc))
                                {
                                    it.PickTries++;
                                }
                                return true;
                            }
                        }
                        else
                        {
                            JumpNext2(it.Loc, 0, 0);
                            return true;
                        }


                    }
                }
            }

            return false;
        }

        public void Move(UInt32 pDir)
        {
            this.Loc.OldX = this.Loc.X;
            this.Loc.OldY = this.Loc.Y;

            this.Loc.LastMove = DateTime.Now;
            this.Loc.Valid = true;

            //0 South, 1 South East, 2 West, 3 North West, 4 North, 5 North East, 6 East, 7 South East
            switch (pDir)
            {
                case 0:
                    {   //South
                        Loc.Y++;
                        break;
                    }
                case 1:
                    {   //South - East
                        Loc.Y++;
                        Loc.X--;
                        break;
                    }
                case 2:
                    {   //West                                         
                        Loc.X--;
                        break;
                    }
                case 3:
                    {   //North - West
                        Loc.Y--;
                        Loc.X--;
                        break;
                    }
                case 4:
                    {   //North
                        Loc.Y--;
                        break;
                    }
                case 5:
                    {   //North - East
                        Loc.Y--;
                        Loc.X++;
                        break;
                    }
                case 6:
                    {   //East
                        Loc.X++;
                        break;
                    }
                case 7:
                    {   //South - East
                        Loc.Y++;
                        Loc.X++;
                        break;
                    }
            }
        }

        public void CheckEntities()
        {
            if (LastAttack != null)
            {
                if (DateTime.Now > LastAttack.SendTime.AddMilliseconds(MaxAtkWait))
                {
                    this.LastAttackTime = DateTime.Now;
                    this.LastMob = 0;
                    this.ValidAttack = true;

                    Mob mob = this.VisibleMobs.FirstOrDefault(p => p.UID == LastAttack.MobUID);
                    if (mob != null)
                    {
                        this.VisibleMobs.Remove(mob);
                        Log.Message("NO RESP: " + mob.UID + " - Coord: " + mob.Loc.getXY());
                    }
                    else
                    {
                        Log.Message("NO RESP: " + this.LastAttack.MobUID);
                    }

                    this.LastAttack = null;
                }
            }

            this.VisibleMobs.RemoveAll(p => p.Loc.Map != this.Loc.Map);
            this.VisibleMobs.RemoveAll(p => MyMath.InBox(Loc.X, Loc.Y, p.Loc.X, p.Loc.Y, 16) && !p.Visible && p.MarkDelete);

            var list = this.VisibleMobs.Where(p => MyMath.PointDistance(Loc.X, Loc.Y, p.Loc.X, p.Loc.Y) > 20).ToList();

            foreach (Mob mob in list)
            {
                mob.Visible = false;
            }

            this.PickList.RemoveAll(p => p.Loc.Map != this.Loc.Map);
            this.PickList.RemoveAll(p => !MyMath.InBox(this.Loc.X, this.Loc.Y, p.Loc.X, p.Loc.Y, 20));
        }

        public Mob FindNearestMob(UInt32 pInterval, UInt32 pNear, Boolean pIgnoreInvisible)
        {
            Mob result = null;
            UInt32 dist = 0;

            foreach (Mob mob in VisibleMobs)
            {
                if ((pInterval == 0) || (DateTime.Now >= mob.LastAttack.AddMilliseconds(pInterval)))
                {
                    dist = (UInt32)MyMath.PointDistance(Loc.X, Loc.Y, mob.Loc.X, mob.Loc.Y);
                    if ((mob.Loc.Map == Loc.Map) && (mob.Visible || (!pIgnoreInvisible && dist > MaxJumpRange)) && (dist < pNear) &&
                        !mob.Name.Contains("Guard") && !mob.Name.Contains("Boss") &&
                        !mob.Name.Contains("Rei") && !mob.Name.EndsWith("Re") && mob.Loc.Valid && mob.HP > 0)
                    {
                        if ((IsArcher() && mob.CanAttack) || (!IsArcher()))
                        {
                            if (MobFilter == "" || mob.Name.Contains(MobFilter))
                            {
                                result = mob;
                                pNear = dist;
                            }
                        }
                    }
                }
            }

            return result;
        }

        public bool AbleToJump(ushort pX, ushort pY)
        {
            if (MyMath.PointDistance(pX, pY, Loc.X, Loc.Y) < MaxJumpRange)
            {
                foreach (NPC npc in NPCList)
                {
                    if (npc.Loc.Map == this.Loc.Map && MyMath.PointDistance(pX, pY, npc.Loc.X, npc.Loc.Y) < 2)
                        return false;
                }

                if (this.Booting)
                {
                    foreach (Mob M in VisibleMobs)
                    {
                        if (M.Loc.Map == Loc.Map && (M.Loc.X == pX && M.Loc.Y == pY))
                        {
                            return false;
                        }
                    }
                }

                DMap DM = ((DMap)MapList.H_DMaps[Loc.Map]);
                if (DM != null)
                {
                    if (!DM.Loaded)
                    {
                        DM.Load();
                    }

                    DMapCell Cur = DM.GetCell(Loc.X, Loc.Y);
                    DMapCell New = DM.GetCell(pX, pY);

                    if (Cur != null && New != null)
                    {
                        if ((Math.Max(Cur.Height, New.Height) - Math.Min(Cur.Height, New.Height) <= 200) && DM.CanAccess(pX, pY))
                        {
                            //Se existir mais de 3 pontos proximos a esse ponto que não podem ser atingidos
                            //o sistema considera como um ponto ruim e não permite pular ali
                            //Mecanismo utilizado para evitar que o bot fique trancando em cantos
                            int liCount = 0;
                            for (int x = pX - 1; x <= (pX + 1); x++)
                            {
                                for (int y = pY - 1; y <= (pY + 1); y++)
                                {
                                    DMapCell Check = DM.GetCell((ushort)x, (ushort)y);

                                    if (Check != null)
                                    {
                                        if ((Math.Max(New.Height, Check.Height) - Math.Min(New.Height, Check.Height) <= 200) && DM.CanAccess((ushort)x, (ushort)y))
                                        {
                                            //Ok
                                        }
                                        else
                                        {
                                            liCount++;
                                        }
                                    }
                                    else
                                    {
                                        liCount++;
                                    }
                                }
                            }

                            if (liCount > 7) //Possivel canto, muro, etc, não pula
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Log.Message("Mapa não encontrado");
                    return true;
                }
            }

            return false;
        }

        public Boolean Jump(Location pLoc)
        {
            if (JumpInterval() && Loc.Valid)
            {
                if (AbleToJump(pLoc.X, pLoc.Y))
                {
                    Packet pack = PacketFactory.JumpPacket(UID, Loc.X, Loc.Y, pLoc);
                    Proxy.HandleClientPacket(MyClient, pack.Data, true);

                    UInt32 lastTick = (UInt32)Environment.TickCount;
                    pack = PacketFactory.PositionPacket(UID, Loc.X, Loc.Y, pLoc.X, pLoc.Y, lastTick);
                    if (Proxy.Sniff)
                    {
                        PacketSniff.ServerPacket(pack.Data, true);
                    }
                    Proxy.SendToClient(MyClient, pack.Data);

                    return true;
                }
                else
                {
                    //Log.Message("Invalid jump coord");
                }
            }

            return false;
        }

        public void UpdateXP()
        {
            if (IsNinja() || IsWarrior() || IsTrojan())
            {

                Status st = (Status)Status[0x1B];

                if (st != null && st.Effect && (DateTime.Now > LastXPTime.AddMilliseconds(AtkDelay)))
                {
                    //Have to implement an way to identify the type of char(ninja, trojan, wariro)
                    //Until i dont do that, use ninja
                    Skill skill = new Skill();
                    if (IsNinja())
                    {
                        skill.ID = 6011;
                    }
                    else if (IsWarrior())
                    {
                        skill.ID = 1025;
                    }
                    else if (IsTrojan())
                    {
                        skill.ID = 1110;
                    }
                    else
                    {
                        return;
                    }
                    Packet packet = PacketFactory.UseSkillPacket(skill, UID, UID, Loc.X, Loc.Y);
                    Proxy.HandleClientPacket(MyClient, packet.Data, true);
                    LastXPTime = DateTime.Now;
                    st.Effect = false;
                }
            }
        }

        public void Attack()
        {
            Mob mob = null;

            byte liAttackType = 2;
            bool lbSendLoc = true;
            int liAttackDist = 2;
            int liXpAttackDist = 12;
            int liJumpToMobDist = 1;
            int liSafeJump = 0;
            if (IsArcher())
            {
                liAttackType = 0x1C;
                lbSendLoc = false;
                liAttackDist = 10;
                liJumpToMobDist = 8;
                liSafeJump = 4;
            }
            if (IsWarrior())
            {
                liXpAttackDist = 2;
            }

            if (XPMode)
            {
                mob = FindNearestMob(150, 16, true);
            }
            else
            {
                mob = FindNearestMob(0, 16, true);
            }

            if (mob != null)
            {
                if (Loc.Valid)
                {
                    if (XPMode)
                    {
                        if (ValidAttack && (DateTime.Now > LastAttackTime.AddMilliseconds(XPAtkDelay)))
                        {
                            if (JumpInterval())
                            {
                                if (MyMath.PointDistance(Loc.X, Loc.Y, mob.Loc.X, mob.Loc.Y) <= liXpAttackDist)
                                {
                                    ValidAttack = false;
                                    mob.LastAttack = DateTime.Now;
                                    mob.CanAttack = false;
                                    LastMob = mob.UID;

                                    Attack atq = new Attack();
                                    atq.MobUID = mob.UID;
                                    atq.SendTime = DateTime.Now;
                                    atq.Loc = new Location(mob.Loc.X, mob.Loc.Y);

                                    LastAttack = atq;
                                    LastAttackTime = DateTime.Now;

                                    Packet packet = PacketFactory.AttackPacket(UID, mob.UID, Loc.X, Loc.Y, liAttackType, lbSendLoc);

                                    Proxy.HandleClientPacket(MyClient, packet.Data, true);
                                }
                                else
                                {
                                    //JumpNext(mob.Loc, liJumpToMobDist);                                    
                                    JumpNext2(mob.Loc, liJumpToMobDist, liSafeJump);
                                }
                            }
                        }
                    }
                    else
                    {
                        //if (ValidAttack)
                        //{
                        if ((DateTime.Now > LastAttackTime.AddMilliseconds(AtkDelay)))
                        {
                            if (MyMath.PointDistance(Loc.X, Loc.Y, mob.Loc.X, mob.Loc.Y) <= liAttackDist)
                            {
                                if (IsArcher() && UseScatter)
                                {
                                    ValidAttack = false;
                                    Skill sk = new Skill();
                                    sk.ID = 8001;
                                    Packet packet = PacketFactory.UseSkillPacket(sk, UID, mob.UID, mob.Loc.X, mob.Loc.Y);
                                    Proxy.HandleClientPacket(MyClient, packet.Data, true);

                                    mob.LastAttack = DateTime.Now;
                                    mob.CanAttack = false;
                                    LastMob = mob.UID;

                                    Attack atq = new Attack();
                                    atq.MobUID = mob.UID;
                                    atq.SendTime = DateTime.Now;
                                    atq.Loc = new Location(mob.Loc.X, mob.Loc.Y);

                                    LastAttack = atq;
                                    LastAttackTime = DateTime.Now;
                                }
                                else
                                {
                                    ValidAttack = false;
                                    mob.LastAttack = DateTime.Now;
                                    mob.CanAttack = false;
                                    LastMob = mob.UID;

                                    Attack atq = new Attack();
                                    atq.MobUID = mob.UID;
                                    atq.SendTime = DateTime.Now;
                                    atq.Loc = new Location(mob.Loc.X, mob.Loc.Y);

                                    LastAttack = atq;
                                    LastAttackTime = DateTime.Now;

                                    Packet packet = PacketFactory.AttackPacket(UID, mob.UID, Loc.X, Loc.Y, liAttackType, lbSendLoc);
                                    Proxy.HandleClientPacket(MyClient, packet.Data, true);
                                }
                            }
                            else
                            {
                                //JumpNext(mob.Loc, liJumpToMobDist);                                
                                JumpNext2(mob.Loc, liJumpToMobDist, liSafeJump);
                            }
                        }
                        /*}
                        else
                        {
                            //Caso for archer verifica se o mob não moveu
                            //Pois se o mob move o scatter não funciona
                            if (IsArcher())
                            {
                                if (LastAttack != null)
                                {
                                    Mob tmp = (Mob)this.VisibleMobs[LastAttack.MobUID];
                                    if (tmp != null)
                                    {
                                        if (tmp.Loc.X != LastAttack.Loc.X || tmp.Loc.Y != LastAttack.Loc.Y)
                                        {
                                            //Mob moveu, libera o ataque novamente
                                            this.LastAttackTime = DateTime.Now;
                                            this.LastMob = 0;
                                            this.ValidAttack = true;
                                            Log.Message("Liberado ataque pois mob: " + tmp.UID + " moveu");
                                            LastAttack = null;
                                        }                                        
                                    }
                                    else
                                    {
                                        //Se não esta na lista, esta morto ou foi removido
                                        //Então libera                                        
                                        this.LastAttackTime = DateTime.Now;
                                        this.LastMob = 0;
                                        this.ValidAttack = true;
                                        Log.Message("Liberado ataque pois mob: " + LastAttack.MobUID + " desapareceu");
                                        LastAttack = null;
                                    }
                                }
                                else
                                {
                                    Log.Message("Comportamento Estranho");
                                }
                            }
                        }*/
                    }

                }
            }
            else
            {
                mob = FindNearestMob(0, 200, false);

                if (mob != null)
                {

                    if (!mob.Visible)
                    {
                        mob.MarkDelete = true;
                    }

                    if (Loc.Valid)
                    {
                        if (XPMode)
                        {
                            if (ValidAttack && DateTime.Now > LastAttackTime.AddMilliseconds(XPAtkDelay))
                            {
                                //JumpNext(mob.Loc, liJumpToMobDist);
                                JumpNext2(mob.Loc, liJumpToMobDist, liSafeJump);
                            }
                        }
                        else
                        {
                            if (DateTime.Now > LastAttackTime.AddMilliseconds(AtkDelay))
                            {
                                //JumpNext(mob.Loc, liJumpToMobDist);
                                JumpNext2(mob.Loc, liJumpToMobDist, liSafeJump);
                            }
                        }
                    }
                }
                else
                {
                    JumpRandom();
                }
            }
        }

        public void JumpRandom()
        {
            //Random jump
            Location location = new Location();
            if (MyMath.ChanceSuccess(50))
            {
                UInt16 soma = ((UInt16)Constants.Rnd.Next(0, 18));
                location.X = ((UInt16)(Loc.X + soma));
            }

            if (MyMath.ChanceSuccess(50))
            {
                UInt16 soma = ((UInt16)Constants.Rnd.Next(0, 18));
                location.Y = ((UInt16)(Loc.Y + soma));
            }

            //JumpNext(location, 1);
            JumpNext2(location, 1, 0);
        }

        public Boolean DropOres()
        {
            if (this.BagList.Count > 20)
            {
                if (DateTime.Now > LastUseItem.AddMilliseconds(UseItemDelay))
                {
                    foreach (Item it in BagList)
                    {
                        if (StaticItemList.OreList.ContainsKey(it.UID)/* || StaticItemList.GoldOreList.ContainsKey(it.UID)*/)
                        {
                            LastUseItem = DateTime.Now;
                            Packet pack = PacketFactory.DropItem(it.VarID);

                            Proxy.HandleClientPacket(MyClient, pack.Data, true);

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public Boolean DropTrash()
        {
            if (DateTime.Now > LastUseItem.AddMilliseconds(UseItemDelay))
            {
                foreach (Item it in DropList)
                {
                    LastUseItem = DateTime.Now;
                    Packet pack = PacketFactory.DropItem(it.VarID);

                    Proxy.HandleClientPacket(MyClient, pack.Data, true);

                    this.DropList.RemoveAll(p => p.VarID == it.VarID);

                    LastDropName = it.Name;

                    return true;
                }
            }

            return false;
        }

        public Boolean CheckHP()
        {
            if (HP <= MinHP)
            {
                //Desconectar se Necessario
                //Usar scroll para cidade se for necessario
                //Esperar
            }

            return false;
        }

        public Boolean UseItem(UInt32 pItem)
        {
            if (DateTime.Now > LastUseItem.AddMilliseconds(UseItemDelay))
            {
                LastUseItem = DateTime.Now;
                Packet pack = PacketFactory.UseItem(pItem);

                Proxy.HandleClientPacket(MyClient, pack.Data, true);

                return true;
            }

            return false;
        }

        public void ProcessaUseItem(UInt32 pVarId, Byte pOpe)
        {
            if (pOpe == 3)
            {
                this.BagList.RemoveAll(p => p.VarID == pVarId);
            }
            else if (pOpe == 5)
            {
                this.BagList.RemoveAll(p => p.VarID == pVarId);
                this.DropList.RemoveAll(p => p.VarID == pVarId);
            }

            this.LastUseItem = DateTime.Now;
        }

        public Boolean CompraItem(UInt32 pItem, ushort pNpcX, ushort pNpcY, Boolean pbCompra)
        {
            //Localiza Npc verificando a distancia
            foreach (NPC npc in NPCList)
            {
                if (npc.Loc.Map == Loc.Map)
                {
                    if (MyMath.PointDistance(npc.Loc.X, npc.Loc.Y, pNpcX, pNpcY) <= 2)
                    {
                        if (MyMath.PointDistance(npc.Loc.X, npc.Loc.Y, this.Loc.X, this.Loc.Y) <= 8)
                        {
                            //Compra
                            LastUseItem = DateTime.Now;
                            Packet pack = PacketFactory.CompraItem(pItem, npc.UID, pbCompra);

                            Proxy.HandleClientPacket(MyClient, pack.Data, true);

                            return true;
                        }
                        else
                        {
                            Log.Message("Muito longe do NPC: (" + npc.Loc.X + "," + npc.Loc.Y + ")");
                        }
                    }
                }
            }

            //Caso chegar aqui não achou o NPC
            Log.Message("NPC não encontrado");

            return false;
        }

        public Boolean UsePotion()
        {
            if (HP <= PotionHP)
            {
                if (DateTime.Now > LastUseItem.AddMilliseconds(UseItemDelay))
                {
                    foreach (Item it in BagList)
                    {
                        //Check if it is an potion
                        if (StaticItemList.HPPots.Contains(it.UID))
                        {
                            LastUseItem = DateTime.Now;
                            Packet pack = PacketFactory.UseItem(it.VarID);

                            Proxy.HandleClientPacket(MyClient, pack.Data, true);

                            return true;
                        }
                    }

                    //Caso chegar aqui nao tem potion
                    //Desconecta
                    this.Proxy.DisconnectFromServer(this.MyClient);
                    this.Proxy.DisconnectFromClient(this.MyClient);
                }
            }

            return false;
        }

        public void UpdateDropList()
        {
            Boolean drop = false;

            foreach (Item it in BagList)
            {
                drop = false;

                if (it.IsItem() && it.Plus == 0 && (it.Quality() < PickQuality) &&
                    !PickListFilter.Exists(p => p.UID == it.UID))
                {
                    drop = true;
                }

                if (drop)
                {
                    this.DropList.RemoveAll(p => p.VarID == it.VarID);
                    this.DropList.Add(it);
                    Log.Message("Drop: " + it.Name);
                }
            }
        }

        public Boolean CheckDead(int pSeconds)
        {
            if (HP == 0)
            {
                if (DateTime.Now > DeadTime.AddSeconds(pSeconds))
                {
                    return true;
                }
            }

            return false;
        }

        public Boolean Revive()
        {
            if (CheckDead(30))
            {
                DeadTime = DateTime.Now;
                Packet pack = PacketFactory.RevivePacket(UID);

                Proxy.HandleClientPacket(MyClient, pack.Data, true);
                return true;
            }

            return false;
        }

        public void UpdateIgnoreList()
        {
            this.IgnoreList.RemoveAll(p => DateTime.Now > p.Ignore.AddMinutes(3));
        }

        public Boolean CheckIgnoreItem(Item pItem)
        {
            foreach (Item it in IgnoreList)
            {
                if (it.UID == pItem.UID && it.Loc.X == pItem.Loc.X && it.Loc.Y == pItem.Loc.Y)
                {
                    return true; //Ignore
                }
            }

            return false;
        }

        public void Step()
        {
            lock (this)
            {
                CheckEntities();

                if (Delay > 0)
                {
                    if (DateTime.Now > DelayStart.AddMilliseconds(this.Delay))
                    {
                        Delay = 0;
                    }
                    else
                    {
                        return;
                    }
                }

                //Movimentação
                if (this.MoverPara != null)
                {
                    if (MoverPara.Map == 0)
                    {
                        MoverPara.Map = this.Loc.Map;
                        MoverPara.MapaDinamico = this.Loc.MapaDinamico;
                    }

                    if (MoverPara.X == this.Loc.X && MoverPara.Y == this.Loc.Y)
                    {
                        MoverPara = null;
                        if (this.PathList != null)
                        {
                            this.PathList.Clear();
                        }
                        Log.Message("Chegou: " + this.Loc.getXY());
                        return;
                    }

                    if (MyMath.PointDistance(this.Loc.X, this.Loc.Y, MoverPara.X, MoverPara.Y) > MoverPara.Distance)
                    {
                        JumpNextPath(MoverPara, MoverPara.Distance, 0);
                        return;
                    }
                    else //Chegou no local
                    {
                        
                        MoverPara = null;
                        if (this.PathList != null)
                        {
                            this.PathList.Clear();
                        }
                        Log.Message("Chegou: " + this.Loc.getXY());
                        return;
                    }
                }
                else
                {
                    if (this.entraMina != null)
                    {
                        this.TentaEntrarMina();
                        return;
                    }
                    else if (this.compraAgulha != null)
                    {
                        this.TentaComprarAgulha();
                        return;
                    }
                }

                if (this.Booting && (this.Loc.Map != 1036) && this.Loc.Valid)
                {

                    //Verifica se esta morto
                    if (CheckDead(0))
                    {
                        //Se retornar verdadeiro, aguarda 3 segundos por garantia
                        //Caso estiver morto depois de 20 segundos, desconecta

                        if (CheckDead(10))
                        {
                            this.StopBot();
                            this.Proxy.DisconnectFromServer(this.MyClient);
                            this.Proxy.DisconnectFromClient(this.MyClient);
                        }

                        return;
                    }
                    //if (Revive())
                    //{
                    //    return;
                    //}

                    UpdateXP();

                    //Checkar life                    
                    if (UsePotion())
                    {
                        return;
                    }

                    //Verificar se existe players
                    //Se existir GM, usar scroll e parar o bot

                    UpdateIgnoreList();
                    if (PickItens())
                    {
                        return;
                    }

                    if (DropTrash())
                    {
                        return;
                    }

                    if (IsArcher())
                    {
                        //Evade mobs if is archer
                        if (Evade())
                        {
                            return;
                        }

                        //Verifica se existe flecha na bag
                        int liCount = 0;
                        foreach (Item it in this.BagList)
                        {
                            if (it.UID == this.ArrowID)
                            {
                                liCount++;
                            }
                        }

                        if (liCount < MaxArrowBuy)
                        {
                            //Caso não encontrou verifica se esta perto do NPC
                            //Se estiver compra                            
                            if (MyMath.PointDistance(NPCX, NPCY, this.Loc.X, this.Loc.Y) <= 8)
                            {
                                if (CompraItem(ArrowID, NPCX, NPCY, true))
                                {
                                    return;
                                }
                                else
                                {
                                    //Caso não consiga comprar deu algum problema, para o bot
                                    this.StopBot();
                                    return;
                                }
                            }
                            else
                            {
                                //Senão so vai comprar se o total for zero
                                if (liCount == 0)
                                {
                                    this.VoltarPara = new Location(this.Loc.X, this.Loc.Y, 2);
                                    this.MoverPara = new Location(NPCX, NPCY, 2);
                                    this.PathList = null;
                                    Log.Message("Movimento para comprar flechas");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (this.VoltarPara != null)
                            {
                                this.MoverPara = this.VoltarPara;
                                this.PathList = null;
                                this.VoltarPara = null;
                                Log.Message("Voltando");
                                return;
                            }
                        }
                    }

                    Attack();
                }
                else if (Mining && (Loc.Map != 1036))
                {
                    if (CheckDead(0))
                    {
                        if (Revive())
                        {
                            //Remover
                            //this.Mining = false;                            
                        }
                        return;
                    }

                    //Verifica se esta na cidade
                    if (this.Loc.Map == 1002)
                    {
                        //Se for dragonball desconecta ate testar melhor o bot
                        /*if (this.BagList.Exists(p => p.UID == Item.Dragonball))
                        {
                            this.Proxy.DisconnectFromServer(this.MyClient);
                            this.Proxy.DisconnectFromClient(this.MyClient);
                            return;
                        }*/

                        //Primeiro passo comprar scroll
                        if (!this.BagList.Exists(p => p.UID == 1060020))
                        {
                            if (MyMath.PointDistance(this.Loc.X, this.Loc.Y, 466, 329) > 4)
                            {
                                this.MoverPara = new Location(466, 329, 4);
                                this.PathList = null;
                                return;
                            }
                            else
                            {
                                this.CompraItem(1060020, 466, 328, true);
                                return;
                            }
                        }

                        //Segundo passo vende os ores
                        var oreList = this.BagList.Where(p => StaticItemList.OreList.Contains(p.UID) || StaticItemList.GoldOreList.Contains(p.UID)).ToList();
                        if (oreList.Count > 0)
                        {
                            if (MyMath.PointDistance(this.Loc.X, this.Loc.Y, 466, 329) > 4)
                            {
                                this.MoverPara = new Location(466, 329, 4);
                                this.PathList = null;
                                return;
                            }
                            else
                            {
                                Item it = oreList.FirstOrDefault();
                                if (it != null)
                                {
                                    this.CompraItem(it.VarID, 466, 328, false);
                                    this.BagList.Remove(it);
                                }
                                return;
                            }
                        }

                        //Terceiro passo guarda itens
                        var listGem = this.BagList.Where(p => p.Name.Contains("Gem")).ToList();
                        var listItem = this.BagList.Where(p => (p.IsItem() && p.Quality() == '9') || (p.UID >= 800014 && p.UID <= 800016)).ToList();
                        var listDBMet = this.BagList.Where(p => p.UID == Item.Dragonball || p.UID == Item.Meteor || p.UID == 730001 || p.UID == 723694 || p.UID == 723695).ToList();

                        if (listGem.Count > 0 || listItem.Count > 0 || listDBMet.Count > 0)
                        {
                            if (MyMath.PointDistance(this.Loc.X, this.Loc.Y, 409, 353) > 4)
                            {
                                this.MoverPara = new Location(409, 353, 4);
                                this.PathList = null;
                                return;
                            }
                            else
                            {
                                Item it = listDBMet.FirstOrDefault();

                                if (it != null)
                                {
                                    this.GuardaItem(it.VarID, 409, 352, true);

                                    //Por enquanto ate melhorar codigo, remove da bag
                                    this.BagList.Remove(it);
                                    return;
                                }

                                it = listItem.FirstOrDefault();

                                if (it != null)
                                {
                                    this.GuardaItem(it.VarID, 409, 352, true);
                                    //Por enquanto ate melhorar codigo, remove da bag
                                    this.BagList.Remove(it);

                                    return;
                                }

                                it = listGem.FirstOrDefault();

                                if (it != null)
                                {
                                    this.GuardaItem(it.VarID, 409, 352, true);
                                    //Por enquanto ate melhorar codigo, remove da bag
                                    this.BagList.Remove(it);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        //Verifica se existem itens bons
                        //Ou se a bag esta cheia
                        Boolean lbTeleportDC = false;
                        if (this.BagList.Count >= 40)
                        {
                            lbTeleportDC = true;
                        }
                        else
                        {
                            foreach (Item it in this.BagList)
                            {
                                if (!StaticItemList.OreList.Contains(it.UID))
                                {
                                    if ((it.IsItem() && it.Quality() == '9') || (it.UID >= 800014 && it.UID <= 800016))
                                    {
                                        lbTeleportDC = true;
                                        break;
                                    }

                                    if (StaticItemList.RefGems.Contains(it.UID))
                                    {
                                        //Disconect
                                        lbTeleportDC = true;
                                        break;
                                    }

                                    if (StaticItemList.SuperGems.Contains(it.UID))
                                    {
                                        //Disconect
                                        lbTeleportDC = true;
                                        break;
                                    }

                                    if (Item.Dragonball == it.UID)
                                    {
                                        //Disconect
                                        lbTeleportDC = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (lbTeleportDC)
                        {
                            //Procura scroll na bag
                            Item scroll = this.BagList.FirstOrDefault(p => p.UID == 1060020);
                            if (scroll == null)
                            {
                                this.Proxy.DisconnectFromServer(this.MyClient);
                                this.Proxy.DisconnectFromClient(this.MyClient);
                                return;
                            }
                            else
                            {
                                //Usa scroll
                                while (!this.UseItem(scroll.VarID)) 
                                {
                                    Thread.Sleep(100);
                                };
                                this.Aguarda(3000);
                                                                
                                return;
                            }
                        }
                    }

                    if (this.Loc.Map == 1002)
                    {
                        this.MoverPara = new Location(47, 396, 2);
                        this.PathList = null;
                        this.entraMina = new EntradaMina();
                        return;
                    }
                    else
                    {
                        if (this.Loc.X != 172 && this.Loc.Y != 107)
                        {
                            this.MoverPara = new Location(172, 107, 0);
                            return;
                        }
                    }

                    //First, drope ores
                    if (DropOres())
                    {
                        return;
                    }

                    if ((DateTime.Now > LastMine.AddMinutes(1)) && (DateTime.Now > LastUseItem.AddMilliseconds(UseItemDelay))) //If stop mine, send another one
                    {
                        LastMine = DateTime.Now;
                        Packet pack = PacketFactory.MiningPacket(UID);

                        Proxy.HandleClientPacket(MyClient, pack.Data, true);
                        Log.Message("Mineirando: " + this.UID + " - " + DateTime.Now.ToShortTimeString());
                    }

                }
                else if (BlueMouse && Loc.Map != 1036)
                {
                    if (CheckDead(0))
                    {
                        //Se retornar verdadeiro, aguarda 3 segundos por garantia
                        //Caso estiver morto depois de 20 segundos, desconecta

                        if (CheckDead(10))
                        {
                            this.StopBot();
                            this.Proxy.DisconnectFromServer(this.MyClient);
                            this.Proxy.DisconnectFromClient(this.MyClient);
                        }

                        return;
                    }

                    //Checkar life                    
                    if (UsePotion())
                    {
                        return;
                    }

                    //Passo 1 verifica se esta no mapa 1011
                    if (this.Loc.Map == 1011)
                    {
                        //Verifica se tem needle na bag
                        Item it = this.BagList.FirstOrDefault(p => p.UID == 722511 || p.UID == 722510);
                        if (it == null)
                        {
                            //Verifica se tem alguma gema normal primeiro, senao para o bot
                            if (!this.BagList.Exists(p => p.UID == 700001 || p.UID == 700011 || p.UID == 700021 || p.UID == 700031 || p.UID == 700041 || p.UID == 700051 || p.UID == 700061))
                            {
                                Log.Message("Voce não possui gens na bag, teleportando");                                
                                this.BlueMouse = false;

                                Item scroll = this.BagList.FirstOrDefault(p => p.UID == 1060020);
                                if (scroll != null)
                                {
                                    while (!this.UseItem(scroll.VarID))
                                    {
                                        Thread.Sleep(100);
                                    }
                                    return;
                                }
                                else
                                {
                                    Log.Message("Sem scroll, desconectando");
                                    //Caso nao tem scroll desconecta para evitar ser morto
                                    this.Proxy.DisconnectFromServer(this.MyClient);
                                    this.Proxy.DisconnectFromClient(this.MyClient);
                                }

                                return;
                            }

                            //Pega um need no NPC
                            if (MyMath.PointDistance(this.Loc.X, this.Loc.Y, 906, 546) > 5)
                            {
                                this.MoverPara = new Location(906, 546, 2);
                                this.PathList = null;
                                return;
                            }
                            else
                            {
                                //Fala com o NPC
                                this.compraAgulha = new CompraAgulha();
                                return;
                            }
                        }
                        else
                        {
                            //Move para mina
                            this.MoverPara = new Location(932, 562);
                            this.PathList = null;
                            this.entraMina = new EntradaMina();
                            return;
                        }
                    }
                    else
                    {
                        //Passo 1 verifica se existe um mapa corrente
                        this.BlueMapAtual = this.BlueMapList[this.Loc.MapaDinamico];

                        if (this.BlueMapAtual == null)
                        {                            
                            Log.Message("Inicie o Bot fora da Mina, Bot Parou.");
                            this.BlueMouse = false;
                            return;                            
                        }

                        Log.Message("Mapa Atual: " + this.BlueMapAtual.MapID);

                        //Verifica se tem agulha                        
                        Item it = this.BagList.FirstOrDefault(p => p.UID == 722511 || p.UID == 722510);
                        if (it == null)
                        {
                            //Verifica se tem alguma gema normal primeiro, senao para o bot
                            if (!this.BagList.Exists(p => p.UID == 700001 || p.UID == 700011 || p.UID == 700021 || p.UID == 700031 || p.UID == 700041 || p.UID == 700051 || p.UID == 700061))
                            {
                                Log.Message("Voce não possui gens na bag, teleportando");
                                this.BlueMouse = false;

                                Item scroll = this.BagList.FirstOrDefault(p => p.UID == 1060020);
                                if (scroll != null)
                                {                                   
                                    while (!this.UseItem(scroll.VarID))
                                    {
                                        Thread.Sleep(100);
                                    }
                                    return;
                                }
                                else
                                {
                                    Log.Message("Sem scroll, desconectando");
                                    //Caso nao tem scroll desconecta para evitar ser morto
                                    this.Proxy.DisconnectFromServer(this.MyClient);
                                    this.Proxy.DisconnectFromClient(this.MyClient);
                                }

                                return;
                            }
                            else
                            {
                                this.MoverPara = new Location(this.BlueMapAtual.Voltar.X, this.BlueMapAtual.Voltar.Y);
                                this.PathList = null;
                                return;
                            }                            
                        }

                        //Seta a ultima visita
                        this.BlueMapAtual.UltimaVisita = DateTime.Now;

                        //Passo 2 verifica se tem rato
                        if (this.BlueMapAtual.TemRato)
                        {
                            //Antes de movimentar verifica se achou o rato                            
                            NPC rato = this.NPCList.FirstOrDefault(p => p.Loc.Map == this.BlueMapAtual.MapID);
                            if (rato != null)
                            {
                                if (MyMath.PointDistance(this.Loc.X, this.Loc.Y, rato.Loc.X, rato.Loc.Y) > 5)
                                {
                                    this.MoverPara = new Location(rato.Loc.X, rato.Loc.Y, 3);
                                    this.PathList = null;
                                    return;
                                }
                                else
                                {
                                    //Fala com o rato
                                    this.MessageList.Clear();
                                    Packet packet = PacketFactory.Chat2031(rato.UID);
                                    Proxy.HandleClientPacket(MyClient, packet.Data, true);
                                    this.NPCList.Remove(rato);
                                    this.Aguarda(2000); //2 segundos para processar
                                    return;
                                }
                            }

                            //Senão tem rato, movimenta
                            if (!this.BlueMapAtual.Explorou)
                            {
                                int lDist1 = MyMath.PointDistance(this.Loc.X, this.Loc.Y, 59, 79);
                                int lDist2 = MyMath.PointDistance(this.Loc.X, this.Loc.Y, 91, 133);
                                int lDist3 = MyMath.PointDistance(this.Loc.X, this.Loc.Y, 116, 144);

                                if (lDist1 < lDist2) //Move para coordenada 1 ou 2
                                {
                                    if (lDist1 > 10)
                                    {
                                        //Move Ponto 1
                                        this.MoverPara = new Location(59, 79);
                                        this.PathList = null;
                                    }
                                    else
                                    {
                                        //Move Ponto 2
                                        this.MoverPara = new Location(91, 133);
                                        this.PathList = null;
                                    }

                                    return;
                                }
                                else if (lDist2 < lDist3) //Move para cordenada 2 ou 3
                                {
                                    if (lDist2 > 10)
                                    {
                                        this.MoverPara = new Location(91, 133);
                                        this.PathList = null;
                                    }
                                    else
                                    {
                                        this.MoverPara = new Location(116, 144);
                                        this.PathList = null;
                                        this.BlueMapAtual.Explorou = true;
                                    }

                                    return;
                                }
                            }
                        }

                        DateTime ldDataVoltar;
                        if (this.BlueMapAtual.MapaVoltar != null)
                        {
                            ldDataVoltar = this.BlueMapAtual.MapaVoltar.UltimaVisita;
                        }
                        else
                        {
                            ldDataVoltar = DateTime.Now;
                        }

                        //Passo 3 vai para esquerda ou direita ou volta
                        if ((this.BlueMapAtual.Esquerda != null) &&
                            (this.BlueMapAtual.MapaEsquerda.UltimaVisita < ldDataVoltar))
                        {
                            if ((this.BlueMapAtual.Abaixo == null) || (this.BlueMapAtual.MapaEsquerda.UltimaVisita <= this.BlueMapAtual.MapaAbaixo.UltimaVisita))
                            {
                                //Vai para esquerda
                                this.MoverPara = new Location(this.BlueMapAtual.Esquerda.X, this.BlueMapAtual.Esquerda.Y);
                                this.BlueMapAtual.MapaEsquerda.Explorou = false;
                                this.PathList = null;                                
                                return;
                            }
                        }

                        if ((this.BlueMapAtual.Abaixo != null) &&
                                 (this.BlueMapAtual.MapaAbaixo.UltimaVisita < ldDataVoltar))
                        {
                            if ((this.BlueMapAtual.Esquerda == null) || (this.BlueMapAtual.MapaAbaixo.UltimaVisita <= this.BlueMapAtual.MapaEsquerda.UltimaVisita))
                            {
                                //Vai para baixo
                                this.MoverPara = new Location(this.BlueMapAtual.Abaixo.X, this.BlueMapAtual.Abaixo.Y);
                                this.BlueMapAtual.MapaAbaixo.Explorou = false;
                                this.PathList = null;                                
                                return;
                            }
                        }

                        //Caso chegar aqui volta                            
                        this.MoverPara = new Location(this.BlueMapAtual.Voltar.X, this.BlueMapAtual.Voltar.Y);
                        this.BlueMapAtual.MapaVoltar.Explorou = false;
                        this.PathList = null;                        
                        return;
                    }
                }
            }
        }

        public Boolean IsWarrior()
        {
            return Job > 16 && Job < 26;
        }

        public Boolean IsTrojan()
        {
            return Job > 6 && Job < 16;
        }

        public Boolean IsArcher()
        {
            return Job > 39 && Job < 46;
        }

        public Boolean IsNinja()
        {
            return Job > 49 && Job < 56;
        }

        public Mob FindNearestMob(Location pLoc, int piDist)
        {
            foreach (Mob mob in VisibleMobs)
            {
                if (mob.Visible && mob.Loc.Valid)
                {
                    if (MyMath.PointDistance(mob.Loc.X, mob.Loc.Y, pLoc.X, pLoc.Y) <= piDist)
                    {
                        return mob;
                    }
                }
            }

            return null;
        }

        public Boolean JumpNextPath(Location pLoc, int piMinDist, int piSafeDist)
        {
            if (JumpInterval() && Loc.Valid)
            {
                if (this.PathList == null || this.PathList.Count == 0)
                {
                    DMap DM = ((DMap)MapList.H_DMaps[this.Loc.Map]);
                    if (DM != null)
                    {
                        if (!DM.Loaded)
                        {
                            DM.Load();
                        }

                        int width = 1024;
                        int height = 1024;

                        if ((width % 2) != 0)
                        {
                            width++;
                        }
                        if ((height % 2) != 0)
                        {
                            height++;
                        }
                        byte[,] matrix = new byte[width, height];

                        DMapCell Cur = DM.GetCell(this.Loc.X, this.Loc.Y);

                        for (ushort x = 0; x < width; x++)
                        {
                            for (ushort y = 0; y < height; y++)
                            {
                                if (x < DM.Width && y < DM.Height)
                                {
                                    DMapCell New = DM.GetCell(x, y);

                                    if (Cur != null && New != null)
                                    {
                                        if (DM.CanAccess(x, y))
                                        {
                                            int diff = Math.Max(Cur.Height, New.Height) - Math.Min(Cur.Height, New.Height);
                                            int cost = 1 + (diff / 50);

                                            matrix[x, y] = (byte)cost;
                                        }
                                        else
                                        {
                                            matrix[x, y] = 0;
                                        }
                                    }
                                    else
                                    {
                                        matrix[x, y] = 0;
                                    }
                                }
                                else
                                {
                                    matrix[x, y] = 0;
                                }
                            }
                        }

                        PathFinderFast path = new PathFinderFast(matrix);
                        path.SearchLimit = Int32.MaxValue; //Nao sei como eh infinito

                        List<PathFinderNode> result = path.FindPath(new System.Drawing.Point(this.Loc.X, this.Loc.Y), new System.Drawing.Point(pLoc.X, pLoc.Y));

                        if (result != null)
                        {
                            this.PathList = new ArrayList();
                            foreach (PathFinderNode node in result)
                            {
                                Location loc = new Location((ushort)node.X, (ushort)node.Y);
                                loc.Map = pLoc.Map;
                                loc.MapaDinamico = pLoc.MapaDinamico;

                                this.PathList.Add(loc);
                            }

                            this.PathList.Reverse();
                        }
                        else
                        {
                            Log.Message("Não encontrou o caminho");
                            this.MoverPara = null;
                            this.PathList = null;
                        }
                    }
                }
                else
                {
                    Location jumpLoc = null;
                    Hashtable invalid = new Hashtable();
                    foreach (Location loc in this.PathList)
                    {
                        if (loc.Valid)
                        {
                            if (MyMath.PointDistance(loc.X, loc.Y, this.Loc.X, this.Loc.Y) < MaxJumpRange)
                            {
                                jumpLoc = loc;
                                invalid.Add(loc, loc);
                            }
                        }
                    }

                    if (jumpLoc != null)
                    {
                        if (JumpNext2(jumpLoc, 0, 0))
                        {
                            //Log.Message("Pulou para: " + jumpLoc.getXY());
                            foreach (Location inv in invalid.Values)
                            {
                                inv.Valid = false;
                            }

                            return true;
                        }
                        else
                        {
                            jumpLoc.Valid = false;
                            jumpLoc = null;
                            Log.Message("Pulou mas nao validou: " + jumpLoc.getXY());
                        }
                    }
                    else
                    {
                        //Recalculate Path
                        if (this.PathList != null)
                        {
                            this.PathList.Clear();
                        }
                    }
                }
            }

            return false;
        }

        public Boolean JumpNext2(Location pLoc, int piMinDist, int piSafeDist)
        {
            if (JumpInterval() && Loc.Valid)
            {
                UInt16 lXStart = (UInt16)Math.Max(0, Loc.X - MaxJumpRange);
                UInt16 lXEnd = (UInt16)(Loc.X + MaxJumpRange);
                UInt16 lYStart = (UInt16)Math.Max(0, Loc.Y - MaxJumpRange);
                UInt16 lYEnd = (UInt16)(Loc.Y + MaxJumpRange);

                Hashtable lCoords = new Hashtable();

                for (UInt16 x = lXStart; x < lXEnd; x++)
                {
                    for (UInt16 y = lYStart; y < lYEnd; y++)
                    {
                        if (!(this.Loc.X == x && this.Loc.Y == y)) //Ignore current location
                        {
                            Location loc = new Location(x, y);
                            loc.Map = pLoc.Map;
                            loc.MapaDinamico = pLoc.MapaDinamico;

                            if (MyMath.PointDistance(pLoc.X, pLoc.Y, loc.X, loc.Y) >= piMinDist)
                            {
                                if (FindNearestMob(loc, piSafeDist) == null)
                                {
                                    if (AbleToJump(loc.X, loc.Y))
                                    {
                                        lCoords.Add(loc.getXY(), loc);
                                    }
                                }
                            }

                        }
                    }
                }

                while (lCoords.Values.Count > 0)
                {
                    //Calcula a menor distancia
                    Location lClose = null;
                    foreach (Location loc in lCoords.Values)
                    {
                        if (lClose == null)
                        {
                            lClose = loc;
                        }
                        else
                        {
                            int liDistAtu = MyMath.PointDistance(pLoc.X, pLoc.Y, lClose.X, lClose.Y);
                            int liDistNova = MyMath.PointDistance(pLoc.X, pLoc.Y, loc.X, loc.Y);
                            if (liDistNova < liDistAtu)
                            {
                                lClose = loc;
                            }
                            else if (liDistNova == liDistAtu)
                            {
                                //Caso for igual, o sistema randomiza para evitar 
                                //que o bot favoreça sempre uma direção
                                if (MyMath.ChanceSuccess(50))
                                {
                                    lClose = loc;
                                }
                            }
                        }
                    }

                    //Remove da lista
                    if (lClose != null)
                    {
                        lCoords.Remove(lClose.getXY());

                        if (Jump(lClose))
                        {
                            return true;

                        }
                    }
                    else
                    {
                        //Bug, abort
                        return false;
                    }
                }
            }

            return false;
        }

        public Boolean Evade()
        {
            int liMinDist = 3;
            int liSafeDist = 6;

            if (FindNearestMob(this.Loc, liMinDist) != null)
            {
                UInt16 lXStart = (UInt16)Math.Max(0, Loc.X - MaxJumpRange);
                UInt16 lXEnd = (UInt16)(Loc.X + MaxJumpRange);
                UInt16 lYStart = (UInt16)Math.Max(0, Loc.Y - MaxJumpRange);
                UInt16 lYEnd = (UInt16)(Loc.Y + MaxJumpRange);

                while (liSafeDist > 1)
                {
                    Hashtable lCoords = new Hashtable();

                    for (UInt16 x = lXStart; x < lXEnd; x++)
                    {
                        for (UInt16 y = lYStart; y < lYEnd; y++)
                        {
                            Location loc = new Location(x, y);

                            if (FindNearestMob(loc, liSafeDist) == null)
                            {
                                if (AbleToJump(loc.X, loc.Y))
                                {
                                    lCoords.Add(loc, loc);
                                }
                            }
                        }
                    }

                    while (lCoords.Values.Count > 0)
                    {
                        //Calcula o menor pulo
                        Location lClose = null;
                        foreach (Location loc in lCoords.Values)
                        {
                            if (lClose == null)
                            {
                                lClose = loc;
                            }
                            else
                            {
                                int liDistAtu = MyMath.PointDistance(this.Loc.X, this.Loc.Y, lClose.X, lClose.Y);
                                int liDistNova = MyMath.PointDistance(this.Loc.X, this.Loc.Y, loc.X, loc.Y);
                                if (liDistNova < liDistAtu)
                                {
                                    lClose = loc;
                                }
                                else if (liDistNova == liDistAtu)
                                {
                                    //Caso for igual, o sistema randomiza para evitar 
                                    //que o bot favoreça sempre uma direção
                                    if (MyMath.ChanceSuccess(50))
                                    {
                                        lClose = loc;
                                    }
                                }
                            }
                        }

                        //Remove da lista
                        if (lClose != null)
                        {
                            lCoords.Remove(lClose);

                            if (Jump(lClose))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            //Bug, abort
                            return false;
                        }
                    }

                    liSafeDist--;
                }
            }

            return false;
        }

        public void StopBot()
        {
            this.Booting = false;
            this.BlueMouse = false;
            this.MoverPara = null;
            this.PathList = null;

            if (StopEvent != null)
            {
                StopEvent();
            }
        }

        public Boolean UpdateLocation(UInt16 pX, UInt16 pY, Boolean pbJump)
        {
            if (this.Loc.X != pX || this.Loc.Y != pY)
            {
                this.Loc.OldX = this.Loc.X;
                this.Loc.OldY = this.Loc.Y;
            }

            if (pX > 0 && pY > 0)
            {
                this.Loc.X = pX;
                this.Loc.Y = pY;
                this.Loc.Valid = true;

                if (pbJump)
                {
                    this.Loc.LastJump = DateTime.Now;
                }

                return true;
            }

            return false;
        }

        public Boolean UpdateAttack(UInt32 pTarget)
        {
            if ((this.LastAttack != null) && (this.LastMob == pTarget))
            {
                this.LastMob = 0;
                this.ValidAttack = true;
                this.LastAttack = null;

                return true;
            }

            return false;
        }

        public Boolean TentaComprarAgulha()
        {
            if (!this.compraAgulha.ComandoCompra)
            {
                NPC lNpc = this.NPCList.FirstOrDefault(p => MyMath.PointDistance(this.Loc.X, this.Loc.Y, p.Loc.X, p.Loc.Y) <= 6);
                if (lNpc != null)
                {
                    this.MessageList.Clear();
                    Packet packet = PacketFactory.Chat2031(lNpc.UID);
                    Proxy.HandleClientPacket(MyClient, packet.Data, true);
                    this.compraAgulha.ComandoCompra = true;
                    this.compraAgulha.InicioConversa = DateTime.Now;
                    return true;
                }
                else
                {
                    Log.Message("Npc não encontrado");
                    this.compraAgulha = null;
                    return false;
                }
            }
            else
            {
                if (this.compraAgulha.InicioConversa.AddSeconds(6) < DateTime.Now)
                {
                    //Provavelmente alguem pegou o rato
                    //Entao aborta
                    this.compraAgulha = null;
                    return true;
                }

                if (this.compraAgulha.Pergunta == "") //Busca pergunta
                {
                    foreach (Message msg in this.MessageList)
                    {
                        if (msg.ID == 0x64FF)
                        {
                            this.compraAgulha.Pergunta = "Ja fez a pergunta";

                            this.MessageList.Clear();

                            //Envia pacote de pedido de respostas

                            Packet packet = PacketFactory.Chat2032(0x6500);
                            Proxy.HandleClientPacket(MyClient, packet.Data, true);

                            packet = PacketFactory.Chat2032(0x65FF);
                            Proxy.HandleClientPacket(MyClient, packet.Data, true);

                            return true;
                        }
                    }
                }
                else
                {
                    //Respostas
                    foreach (Message msg in this.MessageList)
                    {
                        //Verifica os gems
                        Boolean lbDourado = this.BagList.Exists(p => p.UID == 700021 || p.UID == 700051 || p.UID == 700061);

                        String lPalavra;
                        if (lbDourado)
                        {
                            lPalavra = "dourada";
                        }
                        else
                        {
                            lPalavra = "prateada";
                        }

                        if ((msg.Texto != "") && (msg.Texto.ToLower().Contains("quero")) && (msg.Texto.ToLower().Contains(lPalavra)))
                        {
                            //Encontrou
                            //Manda pacote

                            Log.Message("Resposta: " + ((msg.ID) & 0xFF));
                            Packet packet = PacketFactory.Chat2032((UInt16)(0x6500 + ((msg.ID) & 0xFF)));
                            Proxy.HandleClientPacket(MyClient, packet.Data, true);

                            packet = PacketFactory.Chat2032(0x65FF);
                            Proxy.HandleClientPacket(MyClient, packet.Data, true);
                            this.compraAgulha = null;

                            //Ja envia confirmacao junto
                            packet = PacketFactory.Chat2032(0x6500);
                            Proxy.HandleClientPacket(MyClient, packet.Data, true);

                            packet = PacketFactory.Chat2032(0x65FF);
                            Proxy.HandleClientPacket(MyClient, packet.Data, true);

                            //Adiciona um delay global para aguardar o teleport, 3 segundos
                            this.Aguarda(3000);

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public Boolean TentaEntrarMina()
        {
            if (!this.entraMina.ComandoEntrada)
            {
                var list = this.NPCList.Where(p => MyMath.PointDistance(this.Loc.X, this.Loc.Y, p.Loc.X, p.Loc.Y) < 5);
                foreach (NPC npc in list)
                {
                    this.MessageList.Clear();
                    Packet packet = PacketFactory.Chat2031(npc.UID);
                    Proxy.HandleClientPacket(MyClient, packet.Data, true);
                    this.entraMina.ComandoEntrada = true;
                    this.entraMina.InicioConversa = DateTime.Now;
                    return true;
                }
            }
            else
            {
                if (this.entraMina.InicioConversa.AddSeconds(6) < DateTime.Now)
                {
                    //Provavelmente alguem pegou o rato
                    //Entao aborta
                    this.entraMina = null;
                    return true;
                }

                if (this.entraMina.Pergunta == "") //Busca pergunta
                {
                    foreach (Message msg in this.MessageList)
                    {
                        if (msg.ID == 0x1FF)
                        {
                            this.entraMina.Pergunta = msg.Texto;

                            this.MessageList.Clear();

                            //Envia pacote de pedido de respostas

                            Packet packet = PacketFactory.Chat2032(0x6500);
                            Proxy.HandleClientPacket(MyClient, packet.Data, true);

                            packet = PacketFactory.Chat2032(0x65FF);
                            Proxy.HandleClientPacket(MyClient, packet.Data, true);

                            return true;
                        }
                    }
                }
                else
                {
                    //Respostas
                    foreach (Message msg in this.MessageList)
                    {
                        if ((msg.Texto != "") && (this.entraMina.Pergunta.ToLower().Contains(msg.Texto.ToLower())))
                        {
                            //Encontrou
                            //Manda pacote

                            Log.Message("Resposta: " + ((msg.ID) & 0xFF));
                            Packet packet = PacketFactory.Chat2032((UInt16)(0x6500 + ((msg.ID) & 0xFF)));
                            Proxy.HandleClientPacket(MyClient, packet.Data, true);

                            packet = PacketFactory.Chat2032(0x65FF);
                            Proxy.HandleClientPacket(MyClient, packet.Data, true);
                            this.entraMina = null;

                            //Adiciona um delay global para aguardar o teleport, 3 segundos
                            this.Aguarda(3000);

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Boolean GuardaItem(UInt32 pItem, ushort pNpcX, ushort pNpcY, Boolean pbGuardar)
        {
            //Localiza Npc verificando a distancia
            foreach (NPC npc in NPCList)
            {
                if (npc.Loc.Map == Loc.Map)
                {
                    if (MyMath.PointDistance(npc.Loc.X, npc.Loc.Y, pNpcX, pNpcY) <= 2)
                    {
                        if (MyMath.PointDistance(npc.Loc.X, npc.Loc.Y, this.Loc.X, this.Loc.Y) <= 8)
                        {
                            //Guarda
                            LastUseItem = DateTime.Now;

                            Packet pack = PacketFactory.BancoPacket(npc.UID, pbGuardar, pItem);
                            Proxy.HandleClientPacket(MyClient, pack.Data, true);

                            return true;
                        }
                        else
                        {
                            Log.Message("Muito longe do NPC: (" + npc.Loc.X + "," + npc.Loc.Y + ")");
                        }
                    }
                }
            }

            //Caso chegar aqui não achou o NPC
            Log.Message("NPC não encontrado");

            return false;
        }

        public void ProcessaItem(Item pItem, UInt16 pOpe)
        {
            if (pOpe == 1)
            {
                Item tmp = this.ItemList.FirstOrDefault(p => p.UID == pItem.UID);

                if (tmp == null)
                {
                    Log.Message("Item não encontrado UID: " + pItem.UID);
                }
                else
                {
                    pItem.Name = tmp.Name;
                }

                if (pItem.Name != this.LastDropName)
                {
                    if (!this.IgnoreList.Exists(p => p.VarID == pItem.VarID))
                    {
                        if (this.PickListFilter.Exists(p => p.UID == pItem.UID) ||
                            (pItem.Quality() >= this.PickQuality && pItem.IsItem()) ||
                            (this.PickPlus && pItem.IsItem()) ||
                            pItem.Name.Contains("Gema"))
                        {

                            this.PickList.Add(pItem);

                           //Log.Message("Drop: " + pItem.Name + " Q: " + pItem.DescQuality() + " Pos: (" + pItem.Loc.X + "," + pItem.Loc.Y + ")");
                        }
                    }
                }
                else
                {
                    //If same, add ignore list, not safe, but is the best i can do
                    this.IgnoreList.RemoveAll(p => p.VarID == pItem.VarID);
                    this.IgnoreList.Add(pItem);
                    this.LastDropName = "";
                }
            }
            else
            {
                this.PickList.RemoveAll(p => p.VarID == pItem.VarID);
                this.IgnoreList.RemoveAll(p => p.VarID == pItem.VarID);
            }
        }

        public void ItemStatus(Item pItem)
        {
            Item stat = this.ItemList.FirstOrDefault(p => p.UID == pItem.UID);

            if (stat != null)
            {
                pItem.Name = stat.Name;
            }

            this.BagList.RemoveAll(p => p.VarID == pItem.VarID);
            this.EquipList.RemoveAll(p => p.VarID == pItem.VarID);
            this.DropList.RemoveAll(p => p.VarID == pItem.VarID);

            if (pItem.Location == 0) //Bag
            {
                this.BagList.Add(pItem);

                if (!StaticItemList.OreList.ContainsKey(pItem.UID) && !StaticItemList.GoldOreList.ContainsKey(pItem.UID))
                {
                    Log.Message("Item na bag: " + pItem.UID + " - " + pItem.Name + " - " + String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now));
                }

                this.UpdateDropList();
            }
            else if (pItem.Location > 0 && pItem.Location <= 20)
            {
                this.EquipList.Add(pItem);
            }
        }

        public void ProcessaNPC(NPC pNpc)
        {
            NPC old = this.NPCList.FirstOrDefault(p => p.UID == pNpc.UID);

            if (old != null)
            {
                old.Loc.X = pNpc.Loc.X;
                old.Loc.Y = pNpc.Loc.Y;
                old.Loc.Map = this.Loc.Map;
            }
            else
            {
                this.NPCList.Add(pNpc);
            }
        }

        public void Aguarda(int pDelay)
        {
            this.DelayStart = DateTime.Now;
            this.Delay = pDelay;
        }
    }
}
