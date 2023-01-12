using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenSSL;

namespace MyProxy
{
    public delegate void ClientEvent(Client pCli);
    public delegate void CharacterEvent(Client pCli);

    public class GameProxy : Proxy
    {
        public Boolean Sniff { get; set; }
        public String LogPath { get; set; }
        public DMaps Maps { get; set; }

        public event ClientEvent ClientConnect;
        public event ClientEvent ClientDisconnect;
        public event CharacterEvent CharacterLogin;

        public GameProxy(String pRemoteAddr, int pRemotePort, string pLocalAddr, int pLocalPort, String pConquerPath, String pLogPath)
            : base()
        {
            RemoteAddr = pRemoteAddr;
            RemotePort = pRemotePort;
            LocalAddr = pLocalAddr;
            LocalPort = pLocalPort;
            ConquerPath = pConquerPath;

            NewConnection = new ClientConnects(ClientConn);
            ClientData = new DataFromClient(ClientRelay);
            ServerData = new DataFromServer(ServerRelay);
            DCFromClient = new ConnectionLost(ClientDC);
            DCFromServer = new ConnectionLost(ServerDC);

            Sniff = false;
            LogPath = pLogPath;
            PacketSniff.LogPath = pLogPath;

            //Load Maps
            Maps = new DMaps(ConquerPath);
            Maps.Load();
        }

        public void SetUpCrypto(Client pCli)
        {
            try
            {
                BigNumber RealClientPublicKey = BigNumber.FromHexString(pCli.ClientDataDHP.Client_PubKey);
                BigNumber RealServerPublicKey = BigNumber.FromHexString(pCli.ServerDataDHP.Server_PubKey);

                GameCrypto ClientCrypto = new GameCrypto(((GameCrypto)pCli.ClientCrypto).DH.ComputeKey(RealServerPublicKey));
                GameCrypto ServerCrypto = new GameCrypto(((GameCrypto)pCli.ServerCrypto).DH.ComputeKey(RealClientPublicKey));

                ClientCrypto.Blowfish.EncryptIV = pCli.ServerDataDHP.ClientIV;
                ClientCrypto.Blowfish.DecryptIV = pCli.ServerDataDHP.ServerIV;

                ServerCrypto.Blowfish.EncryptIV = pCli.ServerDataDHP.ServerIV;
                ServerCrypto.Blowfish.DecryptIV = pCli.ServerDataDHP.ClientIV;

                pCli.ClientCrypto = ClientCrypto;
                pCli.ServerCrypto = ServerCrypto;
                pCli.DHExchangeCompleted = true;
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }

        public void ClientConn(Client pCli)
        {
            try
            {
                ConnectToServer(pCli);

                lock (ClientList)
                {
                    ClientList.Add(pCli);
                }

                if (ClientConnect != null)
                {
                    ClientConnect(pCli);
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }

        private void ClientRelay(Client pCli, byte[] pData)
        {
            try
            {
                if (!pCli.DHExchangeCompleted && pData.Length > 36)
                {
                    pCli.ClientDataDHP = new ClientDHPacket(pData);
                    pCli.ClientDataDHP.Edit(pData, ((GameCrypto)pCli.ClientCrypto).DH.PublicKey.ToHexString());
                    SendToServer(pCli, pData);
                    SetUpCrypto(pCli);
                }
                else
                {
                    //Handle Client Packet
                    HandleClientProtocol(pCli, pData);
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }

        private void ServerRelay(Client pCli, byte[] pData)
        {
            try
            {
                if (!pCli.DHExchangeCompleted)
                {
                    pCli.ServerDataDHP = new ServerDHPacket(pData);

                    ((GameCrypto)pCli.ClientCrypto).DH = new DH(BigNumber.FromHexString(pCli.ServerDataDHP.P), BigNumber.FromHexString(pCli.ServerDataDHP.G));
                    ((GameCrypto)pCli.ServerCrypto).DH = new DH(BigNumber.FromHexString(pCli.ServerDataDHP.P), BigNumber.FromHexString(pCli.ServerDataDHP.G));

                    ((GameCrypto)pCli.ClientCrypto).DH.GenerateKeys();
                    ((GameCrypto)pCli.ServerCrypto).DH.GenerateKeys();

                    pCli.ServerDataDHP.Edit(pData, ((GameCrypto)pCli.ServerCrypto).DH.PublicKey.ToHexString());
                    SendToClient(pCli, pData);
                }
                else
                {
                    //Handle Server Packet
                    HandleServerProtocol(pCli, pData);
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }

        private void ClientDC(Client pCli)
        {
            lock (ClientList)
            {
                ClientList.Remove(pCli);
            }

            DisconnectFromServer(pCli);
            //TODO: Log

            if (ClientDisconnect != null)
            {
                ClientDisconnect(pCli);
            }
        }

        private void ServerDC(Client pCli)
        {
            lock (ClientList)
            {
                ClientList.Remove(pCli);
            }

            DisconnectFromClient(pCli);
            //TODO: Log
        }

        public void HandleClientPacket(Client pCli, byte[] pData, Boolean pFake)
        {

            UInt16 PacketLength = 0;
            UInt16 PacketID = 0;
            UInt32 LastTick;
            Boolean SendPacket = true;

            try
            {
                PacketLength = (UInt16)(BitConverter.ToUInt16(pData, 0) + 8);
                PacketID = BitConverter.ToUInt16(pData, 2);

                switch (PacketID)
                {
                    case 1022:
                        {

                            UInt32 uid = BitConverter.ToUInt32(pData, 8);
                            UInt32 targetUid = BitConverter.ToUInt32(pData, 12);
                            UInt32 tick = BitConverter.ToUInt32(pData, 16);
                            UInt32 time = BitConverter.ToUInt32(pData, 4);

                            if (pCli.MyChar.UID == uid)
                            {
                                lock (pCli.MyChar)
                                {
                                    //if (!pFake && pCli.MyChar.XPMode)
                                    //{
                                    //    SendPacket = false;
                                    //    Log.Message("Client attack ignored");
                                    //}
                                    //else
                                    //{
                                    /*
                                    Mob mob = (Mob)pCli.MyChar.VisibleMobs[targetUid];
                                    if (mob != null)
                                    {
                                        mob.LastAttack = DateTime.Now;
                                        mob.CanAttack = false;
                                        pCli.MyChar.LastMob = mob.UID;

                                        Attack atq = new Attack();
                                        atq.MobUID = targetUid;
                                        atq.Time = time;
                                        atq.SendTime = DateTime.Now;
                                        atq.PacketTick = tick;

                                        pCli.MyChar.LastAttack = atq;
                                        pCli.MyChar.LastAttackTime = DateTime.Now;
                                    }
                                    */
                                    //}
                                }

                            }

                            /*uint AttackType = BitConverter.ToUInt32(Data, 20);

                            if (AttackType == 24 && pCli.MyChar.SkillKill)
                            {
                                ushort SkillId = Convert.ToUInt16(((long)Data[24] & 0xFF) | (((long)Data[25] & 0xFF) << 8));
                                SkillId ^= (ushort)0x915d;
                                SkillId ^= (ushort)pCli.MyChar.UID;
                                SkillId = (ushort)(SkillId << 0x3 | SkillId >> 0xd);
                                SkillId -= 0xeb42;

                                pCli.MyChar.BotSkill = SkillId;
                            }
                            pCli.SendToServer(ThisData);*/
                            break;
                        }
                    case 1004:
                        {
                            /*
                            PacketReader BR = new PacketReader(ThisData, 0);
                            BR.ReadUInt16();
                            BR.ReadUInt16();
                            BR.ReadUInt32();
                            uint ChatType = BR.ReadUInt32();
                            uint MessageID = BR.ReadUInt32();
                            BR.ReadUInt64();
                            BR.ReadByte();
                            BR.ReadBytes(BR.ReadByte());
                            BR.ReadBytes(BR.ReadByte());
                            BR.ReadByte();
                            string Message = Encoding.ASCII.GetString(BR.ReadBytes(BR.ReadByte()));

                            if (Message[0] == '/')
                            {
                                string[] Cmd = Message.Split(' ');
                                if (Cmd[0] == "/sniff")
                                {
                                    PacketSniff.Sniffing = !PacketSniff.Sniffing;
                                    if (PacketSniff.Sniffing)
                                    {
                                        PacketSniff.SniffingStarted = Native.timeGetTime();
                                        PacketSniff.ClientPacketsCount = 0;
                                        PacketSniff.ServerPacketsCount = 0;
                                    }
                                    pCli.LocalMessage("Sniffing Packets: " + PacketSniff.Sniffing.ToString(), 2005);
                                }
                                else if (Cmd[0] == "/dc")
                                {
                                    pCli.CutUpConnWithServer();
                                    pCli.CutUpConnWithClient();
                                }
                            }
                            else
                                pCli.SendToServer(ThisData);*/
                            break;
                        }
                    case 2031:
                        {
                            break;
                        }
                    case 10010:
                        {
                            switch (pData[20])
                            {
                                case 146:
                                    {
                                        SendPacket = false;
                                        break;
                                    }
                                case 102:
                                    {
                                        //Ignore if boting, cause DC
                                        /*Packet Nr 750. Client -> Server, Length : 44, Type: 10010, Fake: False
                                        24 00 1A 27 8D C6 19 00 BD CA 19 00 00 00 00 00      ;$ 'Æ ½Ê     
                                        06 C9 FD 00 66 00 07 00 3B 01 AA 00 00 00 00 00      ;Éý f  ;ª     
                                        00 00 00 00 54 51 43 6C 69 65 6E 74                  ;    TQClient*/

                                        //Make target invalid for attack until respaw message
                                        lock (pCli.MyChar)
                                        {
                                            UInt32 uid = BitConverter.ToUInt32(pData, 8);

                                            Mob mob = (Mob)pCli.MyChar.VisibleMobs.FirstOrDefault(p => p.UID == uid);

                                            if (mob != null)
                                            {
                                                mob.Loc.Valid = false;
                                            }
                                        }
                                        break;
                                    }
                                case 137:
                                    {
                                        lock (pCli.MyChar)
                                        {
                                            /*if (pCli.MyChar.Loc.Valid && 
                                                (DateTime.Now > pCli.MyChar.Loc.LastJump.AddMilliseconds(700)) &&
                                                (DateTime.Now > pCli.MyChar.LastAttack.AddMilliseconds(200)))
                                            {*/
                                            pCli.MyChar.Loc.LastJump = DateTime.Now;
                                            pCli.MyChar.Loc.Valid = false;
                                            UInt32 secret = BitConverter.ToUInt32(pData, 32);

                                            //Dont allow jump when boting
                                            if (!pFake)
                                            {
                                                if (pCli.MyChar.Booting)
                                                {
                                                    Log.Message("Jump packet ignored");
                                                    SendPacket = false;
                                                }
                                                else
                                                {
                                                    //Block jump 1 second after attack if its not fake
                                                    /*
                                                    if (DateTime.Now < pCli.MyChar.LastAttackTime.AddMilliseconds(500))
                                                    {
                                                        Log.Message("Jump packet ignored");
                                                        SendPacket = false;

                                                        //Try repos the client
                                                        UInt32 lastTick = (UInt32)Environment.TickCount;
                                                        Packet pack = PacketFactory.PositionPacket(pCli.MyChar.UID, pCli.MyChar.Loc.X, pCli.MyChar.Loc.Y, pCli.MyChar.Loc.X, pCli.MyChar.Loc.Y, lastTick);
                                                        if (Sniff)
                                                        {
                                                            PacketSniff.ServerPacket(pack.Data, true);
                                                        }
                                                        SendToClient(pCli, pack.Data);
                                                    }*/
                                                }
                                            }

                                            /*
                                            if (secret == 0xFFFFFFFF)
                                            {
                                                Log.Message("Secret packet ignored");
                                                SendPacket = false;
                                            }
                                            else
                                            {
                                                if (!pFake)
                                                {
                                                    pCli.MyChar.Booting = false;
                                                }
                                            }*/
                                            /*}
                                            else
                                            {
                                                SendPacket = false;
                                                Log.Message("Ignored jump package");
                                            }*/
                                        }
                                        /*
                                        ushort NewX = BitConverter.ToUInt16(ThisData, 8 + Position);
                                        ushort NewY = BitConverter.ToUInt16(ThisData, 10 + Position);

                                        if (pCli.MyChar.Loc.AbleToJump(NewX, NewY, pCli.MyChar))
                                        {                                                                                        
                                            pCli.MyChar.Loc.Jump(NewX, NewY);                                            
                                            pCli.SendToServer(ThisData);
                                            pCli.MyChar.CheckEntities();
                                        }
                                        else
                                        {                                            
                                            pCli.SendToClient(Packets.GeneralData(pCli.MyChar.UID, 0, pCli.MyChar.Loc.X, pCli.MyChar.Loc.Y, 108).Get);
                                        }

                                        pCli.SendToServer(ThisData);
                                        */
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                            break;
                        }
                    case 10005:
                        {
                            UInt32 uid = BitConverter.ToUInt32(pData, 8);
                            UInt32 dir = (UInt32)(BitConverter.ToUInt16(pData, 4) % 8);

                            if (uid == pCli.MyChar.UID)
                            {
                                lock (pCli.MyChar)
                                {
                                    pCli.MyChar.Loc.LastMove = DateTime.Now;
                                    pCli.MyChar.Loc.Valid = false;

                                    if (!pFake)
                                    {
                                        pCli.MyChar.StopBot();
                                    }
                                }
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }

            if (SendPacket)
            {
                if (Sniff)
                {
                    PacketSniff.ClientPacket(pData, pFake);
                }
                lock (pCli.ClientLock)
                {
                    SendToServer(pCli, pData);
                }
            }
        }

        public void HandleClientProtocol(Client pCli, byte[] pData)
        {
            try
            {
                //Copy data to the protocol buffer
                if (pCli.ClientProtBuffer != null)
                {
                    Byte[] buff = new Byte[pCli.ClientProtBuffer.Length + pData.Length];
                    Buffer.BlockCopy(pCli.ClientProtBuffer, 0, buff, 0, pCli.ClientProtBuffer.Length);
                    Buffer.BlockCopy(pData, 0, buff, pCli.ClientProtBuffer.Length, pData.Length);

                    pCli.ClientProtBuffer = buff;
                }
                else
                {
                    pCli.ClientProtBuffer = new Byte[pData.Length];
                    Buffer.BlockCopy(pData, 0, pCli.ClientProtBuffer, 0, pData.Length);
                }

                int Position = 0;
                UInt16 PacketLength = 0;
                UInt16 PacketID = 0;
                Byte[] packet;

                while (Position < pCli.ClientProtBuffer.Length)
                {
                    try
                    {
                        PacketLength = (ushort)(BitConverter.ToUInt16(pCli.ClientProtBuffer, Position) + 8);
                        PacketID = BitConverter.ToUInt16(pCli.ClientProtBuffer, Position + 2);

                        if (PacketLength > (pCli.ClientProtBuffer.Length - Position))
                        {
                            break;
                        }

                        packet = new Byte[PacketLength];
                        Buffer.BlockCopy(pCli.ClientProtBuffer, Position, packet, 0, PacketLength);
                        Position += PacketLength;

                        //Handle packet
                        HandleClientPacket(pCli, packet, false);

                    }
                    catch (Exception ex)
                    {
                        Log.Exception(ex);
                        break;
                    }
                }

                //Recreate or resize protocol buffer
                if (Position >= pCli.ClientProtBuffer.Length)
                {
                    pCli.ClientProtBuffer = null;
                }
                else
                {
                    //Resize to keep data to the next read
                    Byte[] buff = new Byte[pCli.ClientProtBuffer.Length - Position];
                    Buffer.BlockCopy(pCli.ClientProtBuffer, Position, buff, 0, pCli.ClientProtBuffer.Length - Position);

                    pCli.ClientProtBuffer = buff;
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }

        }

        public void HandleServerPacket(Client pCli, Byte[] pData)
        {
            int liPosition = 0;
            UInt16 liPacketLength = 0;
            UInt16 liPacketID = 0;
            UInt32 liLastTick;
            Boolean lbSendPacket = true;

            try
            {
                liPacketLength = (UInt16)(BitConverter.ToUInt16(pData, liPosition) + 8);
                liPacketID = BitConverter.ToUInt16(pData, liPosition + 2);

                switch (liPacketID)
                {
                    case 1006:
                        {
                            pCli.MyChar = new MyCharacter(this, pCli);

                            lock (pCli.MyChar)
                            {
                                pCli.MyChar.UID = BitConverter.ToUInt32(pData, liPosition + 4);
                                pCli.MyChar.Job = pData[67];

                                Log.Message("Char Logged: " + pCli.MyChar.UID + " Job: " + pCli.MyChar.Job);

                                if (this.CharacterLogin != null)
                                {
                                    this.CharacterLogin(pCli);
                                }
                            }

                            break;
                        }
                    case 10005:
                        {
                            UInt32 uid = BitConverter.ToUInt32(pData, 8);
                            UInt32 dir = (UInt32)(BitConverter.ToUInt16(pData, 4) % 8);

                            if (uid == pCli.MyChar.UID)
                            {
                                lock (pCli.MyChar)
                                {
                                    pCli.MyChar.Move(dir);
                                }
                            }
                            else
                            {
                                lock (pCli.MyChar)
                                {
                                    Mob mob = pCli.MyChar.VisibleMobs.FirstOrDefault(p => p.UID == uid);

                                    if (mob != null)
                                    {
                                        mob.Move(dir);
                                    }
                                }
                            }

                            break;
                        }
                    case 1110:
                        {
                            /*Packet Nr 21. Server -> Client, Length : 24, Type: 1110, Fake: False
                            10 00 56 04 D5 07 00 00 DD 05 00 00 02 28 00 00      ; VÕ  Ý  (  
                            54 51 53 65 72 76 65 72                              ;TQServer*/
                            UInt16 mapa = BitConverter.ToUInt16(pData, 4);

                            lock (pCli.MyChar)
                            {
                                pCli.MyChar.Loc.MapaDinamico = mapa;

                                Log.Message("Mapa Dinamico: " + pCli.MyChar.Loc.MapaDinamico);
                            }
                            break;
                        }
                
                    case 10010:
                        {
                            byte PType = pData[20 + liPosition];
                            switch (PType)
                            {
                                case 74:
                                    {
                                        UInt16 map = (UInt16)BitConverter.ToUInt32(pData, 8);
                                        UInt16 mapDinamico = (UInt16)BitConverter.ToUInt32(pData, 4);
                                        UInt16 xCor = BitConverter.ToUInt16(pData, 24);
                                        UInt16 yCor = BitConverter.ToUInt16(pData, 26);

                                        lock (pCli.MyChar)
                                        {
                                            //Unload old map
                                            DMap dmp = ((DMap)pCli.MyChar.MapList.H_DMaps[pCli.MyChar.Loc.Map]);
                                            if (dmp != null)
                                            {
                                                dmp.Unload();
                                            }

                                            pCli.MyChar.Loc.Map = map;
                                            pCli.MyChar.Loc.MapaDinamico = mapDinamico;
                                            pCli.MyChar.Loc.X = xCor;
                                            pCli.MyChar.Loc.Y = yCor;
                                            if (pCli.MyChar.Loc.X == 0 && pCli.MyChar.Loc.Y == 0)
                                            {
                                                Log.Message("Bug maldito: 74");
                                            }
                                            pCli.MyChar.Loc.OldX = xCor;
                                            pCli.MyChar.Loc.OldY = yCor;
                                            pCli.MyChar.Loc.Valid = true;

                                            pCli.MyChar.VisibleMobs.Clear();
                                            pCli.MyChar.PickList.Clear();
                                            pCli.MyChar.NPCList.RemoveAll(p => p.Loc.Map >= 1500 && p.Loc.Map <= 1503);

                                            pCli.MyChar.ValidMap = true;
                                            pCli.MyChar.MoverPara = null;
                                            pCli.MyChar.PathList = null;

                                            Log.Message("Map: " + pCli.MyChar.Loc.Map);
                                            if (pCli.MyChar.Loc.Map != pCli.MyChar.Loc.MapaDinamico)
                                            {
                                                Log.Message("Mapa Dinamico: " + pCli.MyChar.Loc.MapaDinamico);
                                            }
                                        }

                                        break;
                                    }
                                case 86:
                                    {
                                        UInt32 uid = BitConverter.ToUInt32(pData, 4);

                                        if (uid == pCli.MyChar.UID)
                                        {
                                            UInt16 map = (UInt16)BitConverter.ToUInt32(pData, 8);
                                            UInt16 xCor = BitConverter.ToUInt16(pData, 24);
                                            UInt16 yCor = BitConverter.ToUInt16(pData, 26);

                                            lock (pCli.MyChar)
                                            {
                                                //Unload old map
                                                DMap dmp = ((DMap)pCli.MyChar.MapList.H_DMaps[pCli.MyChar.Loc.Map]);
                                                if (dmp != null)
                                                {
                                                    dmp.Unload();
                                                }

                                                pCli.MyChar.Loc.Map = map;
                                                pCli.MyChar.Loc.X = xCor;
                                                pCli.MyChar.Loc.Y = yCor;
                                                if (pCli.MyChar.Loc.X == 0 && pCli.MyChar.Loc.Y == 0)
                                                {
                                                    Log.Message("Bug maldito: 86");
                                                }
                                                pCli.MyChar.Loc.OldX = xCor;
                                                pCli.MyChar.Loc.OldY = yCor;
                                                pCli.MyChar.Loc.Valid = true;

                                                pCli.MyChar.VisibleMobs.Clear();
                                                pCli.MyChar.PickList.Clear();
                                                pCli.MyChar.NPCList.RemoveAll(p => p.Loc.Map >= 1500 && p.Loc.Map <= 1503);
                                                
                                                pCli.MyChar.ValidMap = true;
                                                pCli.MyChar.MoverPara = null;
                                                pCli.MyChar.PathList = null;

                                                Log.Message("Map: " + pCli.MyChar.Loc.Map);
                                            }
                                        }
                                        break;
                                    }
                                case 102:
                                    {
                                        break;
                                    }
                                case 103:
                                    {
                                        //Possible invulnerable mob dont know, the use skill fail and the server return that
                                        /*lock (pCli.MyChar)
                                        {
                                            if (pCli.MyChar.LastAttack != null)
                                            {
                                                Mob mob = (Mob) pCli.MyChar.VisibleMobs[pCli.MyChar.LastAttack.MobUID];
                                                pCli.MyChar.VisibleMobs.Remove(pCli.MyChar.LastAttack.MobUID);
                                                pCli.MyChar.LastAttackTime = DateTime.Now;
                                                pCli.MyChar.LastMob = 0;
                                                pCli.MyChar.ValidAttack = true;
                                                pCli.MyChar.LastAttack = null;

                                                if (mob != null)
                                                {
                                                    Log.Message("Mob: " + mob.UID + " - " + mob.Loc.getXY() + " do inferno");
                                                }
                                                else
                                                {
                                                    Log.Message("Mob do inferno nulo");
                                                }
                                            }
                                        }*/
                                        break;
                                    }
                                case 104:
                                    {
                                        //Possible location packet
                                        //Repos packet
                                        UInt32 uid = BitConverter.ToUInt32(pData, 4);
                                        UInt16 xCor = BitConverter.ToUInt16(pData, 24);
                                        UInt16 yCor = BitConverter.ToUInt16(pData, 26);

                                        lock (pCli.MyChar)
                                        {
                                            if (uid == pCli.MyChar.UID)
                                            {
                                                pCli.MyChar.UpdateLocation(xCor, yCor, false);
                                            }
                                            else
                                            {
                                                Mob mob = pCli.MyChar.VisibleMobs.FirstOrDefault(p => p.UID == uid);
                                                if (mob != null)
                                                {
                                                    mob.UpdateLocation(xCor, yCor, false);
                                                }
                                            }
                                        }

                                        break;
                                    }
                                case 108:
                                    {
                                        //Repos packet
                                        UInt32 uid = BitConverter.ToUInt32(pData, 4);
                                        UInt16 xCor = BitConverter.ToUInt16(pData, 24);
                                        UInt16 yCor = BitConverter.ToUInt16(pData, 26);

                                        lock (pCli.MyChar)
                                        {
                                            if (uid == pCli.MyChar.UID)
                                            {
                                                pCli.MyChar.UpdateLocation(xCor, yCor, false);
                                            }
                                            else
                                            {

                                                Mob mob = pCli.MyChar.VisibleMobs.FirstOrDefault(p => p.UID == uid);
                                                if (mob != null)
                                                {
                                                    mob.UpdateLocation(xCor, yCor, false);
                                                    Log.Message("Reposition packet para mob");
                                                }
                                            }
                                        }

                                        break;
                                    }
                                case 134:
                                    {
                                        //Repos packet
                                        UInt32 uid = BitConverter.ToUInt32(pData, 4);
                                        UInt16 xCor = BitConverter.ToUInt16(pData, 24);
                                        UInt16 yCor = BitConverter.ToUInt16(pData, 26);

                                        lock (pCli.MyChar)
                                        {
                                            if (uid == pCli.MyChar.UID)
                                            {
                                                //pCli.MyChar.UpdateLocation(xCor, yCor, false);
                                                //Log.Message("Pacote suspeito para mim: " + xCor + "," + yCor);
                                            }
                                            else
                                            {

                                                Mob mob = pCli.MyChar.VisibleMobs.FirstOrDefault(p => p.UID == uid);
                                                if (mob != null)
                                                {
                                                    //mob.UpdateLocation(xCor, yCor, false);
                                                    //Log.Message("Pacote suspeito para mob: " + mob.UID + "= " + mob.Loc.getXY() + " -> " + xCor + "," + yCor);
                                                }
                                            }
                                        }

                                        break;
                                    }
                                case 153:
                                    {
                                        UInt32 uid = BitConverter.ToUInt32(pData, 4);
                                        lock (pCli.MyChar)
                                        {
                                            pCli.MyChar.VisibleMobs.RemoveAll(p => p.UID == uid);
                                            pCli.MyChar.PickList.RemoveAll(p => p.VarID == uid);
                                        }
                                        break;
                                    }
                                case 156:
                                    {
                                        //Ninja step
                                        UInt32 uid = BitConverter.ToUInt32(pData, 4);
                                        UInt16 xCor = BitConverter.ToUInt16(pData, 24);
                                        UInt16 yCor = BitConverter.ToUInt16(pData, 26);

                                        lock (pCli.MyChar)
                                        {
                                            if (uid == pCli.MyChar.UID)
                                            {
                                                pCli.MyChar.UpdateLocation(xCor, yCor, false);

                                                if (pCli.MyChar.NinjaFastMode)
                                                {
                                                    //Experimental valida o ataque baseado no step
                                                    pCli.MyChar.LastMob = 0;
                                                    pCli.MyChar.ValidAttack = true;
                                                    pCli.MyChar.LastAttack = null;
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case 157:
                                    {
                                        //Possible location packet
                                        UInt32 uid = BitConverter.ToUInt32(pData, 4);
                                        UInt16 xCor = BitConverter.ToUInt16(pData, 24);
                                        UInt16 yCor = BitConverter.ToUInt16(pData, 26);

                                        lock (pCli.MyChar)
                                        {
                                            if (uid == pCli.MyChar.UID)
                                            {
                                                //pCli.MyChar.UpdateLocation(xCor, yCor, false);
                                                //Log.Message("Pacote 10010 - 157: (" + xCor + " , " + yCor + ")");
                                            }
                                            else
                                            {
                                                /*
                                                Mob mob = pCli.MyChar.VisibleMobs.FirstOrDefault(p => p.UID == uid);
                                                if (mob != null)
                                                {
                                                    mob.UpdateLocation(xCor, yCor, false);
                                                    Log.Message("Reposition packet para mob");
                                                }*/
                                                //Log.Message("Pacote 10010 - 157 MOB: (" + xCor + " , " + yCor + ")");
                                            }
                                        }

                                        break;
                                    }
                                case 137: //Jump
                                    {
                                        UInt32 uid = BitConverter.ToUInt32(pData, 4);
                                        UInt16 xCor = BitConverter.ToUInt16(pData, 8);
                                        UInt16 yCor = BitConverter.ToUInt16(pData, 10);
                                        UInt16 xCorOld = BitConverter.ToUInt16(pData, 24);
                                        UInt16 yCorOld = BitConverter.ToUInt16(pData, 26);

                                        if (uid == pCli.MyChar.UID)
                                        {
                                            lock (pCli.MyChar)
                                            {
                                                pCli.MyChar.UpdateLocation(xCor, yCor, true);
                                            }
                                        }
                                        else
                                        {
                                            lock (pCli.MyChar)
                                            {
                                                Mob mob = pCli.MyChar.VisibleMobs.FirstOrDefault(p => p.UID == uid);

                                                if (mob != null)
                                                {
                                                    mob.UpdateLocation(xCor, yCor, true);
                                                }
                                            }
                                        }

                                        break;
                                    }
                                case 135:
                                    {
                                        //Dont know, see on old proxy to turn target invisible
                                        UInt32 uid = BitConverter.ToUInt32(pData, 4);
                                        lock (pCli.MyChar)
                                        {
                                            if (pCli.MyChar.VisibleMobs.Exists(p => p.UID == uid))
                                            {
                                                pCli.MyChar.VisibleMobs.RemoveAll(p => p.UID == uid);
                                            }
                                        }
                                        break;
                                    }
                                case 99: //Mine
                                    {
                                        UInt32 uid = BitConverter.ToUInt32(pData, 4);

                                        if (uid == pCli.MyChar.UID)
                                        {
                                            lock (pCli.MyChar)
                                            {
                                                pCli.MyChar.LastMine = DateTime.Now;
                                            }
                                        }
                                        break;
                                    }
                            }
                            break;

                        }
                    case 1022:
                        {
                            UInt32 uid = BitConverter.ToUInt32(pData, 8);
                            UInt32 targetUid = BitConverter.ToUInt32(pData, 12);
                            UInt32 type = BitConverter.ToUInt32(pData, 20);
                            UInt16 pos24 = BitConverter.ToUInt16(pData, 24);
                            UInt32 tick = BitConverter.ToUInt32(pData, 16);

                            //Update mob before to prevent bot to attack that mob again
                            lock (pCli.MyChar)
                            {
                                if (pCli.MyChar.VisibleMobs.Exists(p => p.UID == targetUid))
                                {
                                    Mob mob = pCli.MyChar.VisibleMobs.First(p => p.UID == targetUid);
                                    if ((type == 0x0E)) //Kill
                                    {
                                        mob.Visible = false;
                                        mob.Loc.Valid = false;
                                        pCli.MyChar.VisibleMobs.RemoveAll(p => p.UID == targetUid);

                                        if (pCli.MyChar.UpdateAttack(targetUid))
                                        {
                                            Log.Message("Eliminado por morte: " + targetUid);
                                        }

                                        pCli.MyChar.MobCount++;

                                        if (pCli.MyChar.MobCount % 100 == 0)
                                        {
                                            Log.Message("Mob morto: " + mob.UID + " - Qtd: " + pCli.MyChar.MobCount);
                                        }
                                    }
                                    else
                                    {
                                        //Decrease mob HP
                                        if (type != 0x18/* && pos24 == 8001)*/)
                                        {
                                            mob.Damage(pos24);
                                            mob.Visible = true;
                                            mob.CanAttack = true;
                                            mob.LastAttack = DateTime.Now;
                                        }
                                    }
                                }

                                if (type != 0x0E && type != 0x18)
                                {
                                    if (uid == pCli.MyChar.UID)
                                    {
                                        UInt16 xCor = BitConverter.ToUInt16(pData, 16);
                                        UInt16 yCor = BitConverter.ToUInt16(pData, 18);

                                        pCli.MyChar.UpdateLocation(xCor, yCor, false);

                                        if (pCli.MyChar.UpdateAttack(targetUid))
                                        {
                                            pCli.MyChar.LastAttackTime = DateTime.Now;
                                        }
                                    }
                                    else
                                    {
                                        //Mob or player attack
                                        //If Mob, update location
                                    }
                                }
                            }

                            break;
                        }
                    case 1105: //Magic package
                        {
                            UInt32 uid = BitConverter.ToUInt32(pData, 4);
                            UInt32 targetCheck = BitConverter.ToUInt32(pData, 8);
                            UInt32 count = BitConverter.ToUInt32(pData, 16);
                            UInt16 xCor = BitConverter.ToUInt16(pData, 8);
                            UInt16 yCor = BitConverter.ToUInt16(pData, 10);
                            UInt16 skillID = BitConverter.ToUInt16(pData, 12);

                            if ((uid == pCli.MyChar.UID) && (targetCheck == uid))
                            {
                                //Ignore, xp skill magic packet
                            }
                            else
                            {
                                lock (pCli.MyChar)
                                {
                                    for (int i = 0; i < count; i++)
                                    {
                                        UInt32 targetUid = BitConverter.ToUInt32(pData, 20 + (32 * i));
                                        UInt16 damage = BitConverter.ToUInt16(pData, 24 + (32 * i));

                                        Mob mob = pCli.MyChar.VisibleMobs.FirstOrDefault(p => p.UID == targetUid);
                                        if (mob != null)
                                        {
                                            mob.Damage(damage);

                                            if (uid == pCli.MyChar.UID)
                                            {
                                                if (pCli.MyChar.UpdateAttack(targetUid))
                                                {
                                                    pCli.MyChar.LastAttackTime = DateTime.Now;
                                                }
                                            }
                                        }
                                    }


                                    if (uid == pCli.MyChar.UID)
                                    {
                                        if (skillID != 8001) //Scatter dont update coord
                                        {
                                            pCli.MyChar.UpdateLocation(xCor, yCor, false);
                                        }
                                    }
                                }
                            }

                            break;
                        }
                    case 2030:
                        {
                            uint NpcId = BitConverter.ToUInt32(pData, 4);
                            ushort NpcX = BitConverter.ToUInt16(pData, 8);
                            ushort NpcY = BitConverter.ToUInt16(pData, 10);

                            NPC npc = new NPC();
                            npc.UID = NpcId;
                            npc.Loc.X = NpcX;
                            npc.Loc.Y = NpcY;
                            npc.Loc.Map = pCli.MyChar.Loc.Map;

                            lock (pCli.MyChar)
                            {
                                pCli.MyChar.ProcessaNPC(npc);                                
                            }

                            break;
                        }
                    case 2032:
                        {
                            byte size = pData[13];
                            String message = ""; 
                            if (size > 0)
                            {
                                message = Encoding.ASCII.GetString(pData, 14, size);
                            }
                            byte ordem = pData[11];
                            UInt16 id = BitConverter.ToUInt16(pData, 10);

                            //Log.Message(message);

                            Message msg = new Message();
                            msg.Texto = message;
                            msg.ID = id;

                            lock (pCli.MyChar)
                            {
                                //foreach (Message tmp in pCli.MyChar.MessageList)
                                //{
                                //if (tmp.ID == msg.ID) //same message
                                //{
                                //    tmp.Texto += msg.Texto;
                                //    msg = null;
                                //    break;
                                //}
                                //}

                                if (msg != null)
                                {
                                    pCli.MyChar.MessageList.Add(msg);
                                }
                            }

                            break;
                        }
                    case 10014:
                        {
                            uint CharId = BitConverter.ToUInt32(pData, 8);
                            ushort CharX = BitConverter.ToUInt16(pData, 80);
                            ushort CharY = BitConverter.ToUInt16(pData, 82);
                            ushort CharHP = BitConverter.ToUInt16(pData, 74);

                            if (CharId <= 1000000)
                            {
                                Mob mob = new Mob();
                                mob.UID = CharId;
                                mob.Loc.X = CharX;
                                mob.Loc.Y = CharY;
                                mob.Loc.Map = pCli.MyChar.Loc.Map;
                                mob.Loc.Valid = true;
                                mob.HP = CharHP;
                                mob.Visible = true;

                                byte nameSize = pData[208];
                                mob.Name = Encoding.ASCII.GetString(pData, 209, nameSize);

                                //Log.Message("Mob: " + mob.UID + " Dist: " + MyMath.PointDistance(mob.Loc.X, mob.Loc.Y, pCli.MyChar.Loc.X, pCli.MyChar.Loc.Y));
                                //Log.Message("Mob: " + mob.UID + " - " + mob.Loc.getXY());

                                lock (pCli.MyChar)
                                {
                                    if (pCli.MyChar.VisibleMobs.Exists(p => p.UID == mob.UID))
                                    {
                                        Mob old = pCli.MyChar.VisibleMobs.FirstOrDefault(p => p.UID == mob.UID);
                                        old.HP = mob.HP;
                                        old.UpdateLocation(mob.Loc.X, mob.Loc.Y, false);
                                    }
                                    else
                                    {
                                        pCli.MyChar.VisibleMobs.Add(mob);
                                    }
                                }
                            }
                            break;
                        }
                    case 10017:
                        {
                            UInt32 uid = BitConverter.ToUInt32(pData, 4);

                            if (uid == pCli.MyChar.UID)
                            {
                                lock (pCli.MyChar)
                                {
                                    UInt32 count = BitConverter.ToUInt32(pData, 8);
                                    UInt32 status;
                                    UInt64 value;
                                    int desc = 0;
                                    for (int i = 1; i <= count; i++)
                                    {
                                        status = BitConverter.ToUInt32(pData, (12 * i) + desc);
                                        value = BitConverter.ToUInt64(pData, (12 * i) + 4 + desc);

                                        if (status == 0xFFFFFFFF)
                                        {
                                            desc = 8;
                                            continue;
                                        }

                                        if ((status == 0))
                                        {
                                            pCli.MyChar.HP = (UInt32)value;

                                            if (pCli.MyChar.HP == 0)
                                            {
                                                Log.Message("Dead: " + pCli.MyChar.UID + " - " + DateTime.Now.ToShortTimeString());

                                                pCli.MyChar.DeadTime = DateTime.Now;
                                            }

                                        }
                                        else if (status == 0x1B)
                                        {
                                            if (value >= 99)
                                            {
                                                Status sta = (Status)pCli.MyChar.Status[0x1B];
                                                if (sta != null)
                                                {
                                                    sta.Effect = true;
                                                    //Log.Message("Efeito habilitado");
                                                }
                                                else
                                                {
                                                    sta = new Status(value, true, false);
                                                    pCli.MyChar.Status.Add(0x1B, sta);
                                                    //Log.Message("Efeito habilitado");
                                                }
                                            }
                                        }
                                        else if (status == 0x1E)
                                        {
                                            if (value > 1)
                                            {
                                                Status sta = (Status)pCli.MyChar.Status[0x1B];
                                                if (sta != null)
                                                {
                                                    if (!sta.Skill)
                                                    {
                                                        Log.Message("Skill habilitado");
                                                    }

                                                    sta.Skill = true;                                                    
                                                }
                                                else
                                                {
                                                    sta = new Status(value, false, true);
                                                    pCli.MyChar.Status.Add(0x1B, sta);
                                                    Log.Message("Skill habilitado");
                                                }

                                                pCli.MyChar.XPMode = true;
                                            }
                                            else
                                            {
                                                Status sta = (Status)pCli.MyChar.Status[0x1B];
                                                if (sta != null)
                                                {
                                                    if (sta.Skill)
                                                    {
                                                        sta.Skill = false;
                                                        Log.Message("Skill removed");
                                                        
                                                    }
                                                }

                                                pCli.MyChar.XPMode = false;
                                            }
                                        }
                                    }
                                }
                            }


                            break;
                        }
                    case 1101:
                        {
                            UInt32 varID = BitConverter.ToUInt32(pData, 4);
                            UInt32 uid = BitConverter.ToUInt32(pData, 8);
                            UInt16 locX = BitConverter.ToUInt16(pData, 12);
                            UInt16 locY = BitConverter.ToUInt16(pData, 14);
                            UInt16 ope = BitConverter.ToUInt16(pData, 18);
                            UInt16 flag = BitConverter.ToUInt16(pData, 16);

                            Item pick = new Item();
                            pick.Loc.X = locX;
                            pick.Loc.Y = locY;
                            pick.Loc.Map = pCli.MyChar.Loc.Map;
                            pick.UID = uid;
                            pick.VarID = varID;
                            pick.Ignore = DateTime.Now;

                            lock (pCli.MyChar)
                            {
                                pCli.MyChar.ProcessaItem(pick, ope);
                            }

                            break;
                        }
                    case 1008: //ItemInfo
                        {
                            /*Packet Nr 44. Server -> Client, Length : 60, Type: 1008, Fake: False
                            34 00 F0 03 D0 15 3B 00 B5 2C 10 00 01 00 01 00      ;4 ðÐ; µ,   
                            01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00      ;               
                            00 00 00 00 00 00 00 00 03 00 00 00 00 00 00 00      ;               
                            00 00 00 00 54 51 53 65 72 76 65 72                  ;    TQServer*/

                            UInt32 varID = BitConverter.ToUInt32(pData, 4);
                            UInt32 uid = BitConverter.ToUInt32(pData, 8);
                            Byte location = pData[18];
                            Byte plus = pData[33];
                            Byte bless = pData[34];
                            UInt16 CurDur = BitConverter.ToUInt16(pData, 12);
                            UInt16 MaxDur = BitConverter.ToUInt16(pData, 14);

                            Item it = new Item();
                            it.VarID = varID;
                            it.UID = uid;
                            it.Location = location;
                            it.Plus = plus;
                            it.Bless = bless;
                            it.CurDur = CurDur;
                            it.MaxDur = MaxDur;

                            lock (pCli.MyChar)
                            {
                                pCli.MyChar.ItemStatus(it);
                            }

                            break;
                        }
                    case 1009: //Item usage
                        {
                            UInt32 varID = BitConverter.ToUInt32(pData, 4);
                            Byte ope = pData[12];

                            lock (pCli.MyChar)
                            {
                                pCli.MyChar.ProcessaUseItem(varID, ope);
                            }

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }

            if (lbSendPacket)
            {
                if (Sniff)
                {
                    PacketSniff.ServerPacket(pData, false);
                }
                lock (pCli.ServerLock)
                {
                    SendToClient(pCli, pData);
                }
            }
        }

        public void HandleServerProtocol(Client pCli, byte[] pData)
        {
            try
            {
                //Copy data to the protocol buffer
                if (pCli.ServerProtBuffer != null)
                {
                    Byte[] buff = new Byte[pCli.ServerProtBuffer.Length + pData.Length];
                    Buffer.BlockCopy(pCli.ServerProtBuffer, 0, buff, 0, pCli.ServerProtBuffer.Length);
                    Buffer.BlockCopy(pData, 0, buff, pCli.ServerProtBuffer.Length, pData.Length);

                    pCli.ServerProtBuffer = buff;
                }
                else
                {
                    pCli.ServerProtBuffer = new Byte[pData.Length];
                    Buffer.BlockCopy(pData, 0, pCli.ServerProtBuffer, 0, pData.Length);
                }

                int Position = 0;
                UInt16 PacketLength = 0;
                UInt16 PacketID = 0;
                Byte[] packet = null;

                while (Position < pCli.ServerProtBuffer.Length)
                {
                    try
                    {
                        if ((Position + 4) >= pCli.ServerProtBuffer.Length)
                        {
                            break;
                        }

                        PacketLength = (ushort)(BitConverter.ToUInt16(pCli.ServerProtBuffer, Position) + 8);
                        PacketID = BitConverter.ToUInt16(pCli.ServerProtBuffer, Position + 2);

                        if (PacketLength > (pCli.ServerProtBuffer.Length - Position))
                        {
                            break;
                        }

                        packet = new Byte[PacketLength];
                        Buffer.BlockCopy(pCli.ServerProtBuffer, Position, packet, 0, PacketLength);
                        Position += PacketLength;

                        //Handle packet
                        HandleServerPacket(pCli, packet);

                    }
                    catch (Exception ex)
                    {
                        Log.Message("Tamanho: " + PacketLength + " Array: " + packet.Length);
                        Log.Exception(ex);
                        break;
                    }
                }

                //Recreate or resize protocol buffer
                if (Position >= pCli.ServerProtBuffer.Length)
                {
                    pCli.ServerProtBuffer = null;
                }
                else
                {
                    //Resize to keep data to the next read
                    Byte[] buff = new Byte[pCli.ServerProtBuffer.Length - Position];
                    Buffer.BlockCopy(pCli.ServerProtBuffer, Position, buff, 0, pCli.ServerProtBuffer.Length - Position);

                    pCli.ServerProtBuffer = buff;
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }

        }
    }
}
