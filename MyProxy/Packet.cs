using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProxy
{
    class Packet
    {
        public Byte[] Data { get; set; }

        public UInt16 Length { get { return (UInt16)Data.Length; } }
        public UInt16 Type { get { return BitConverter.ToUInt16(Data, 2); } }

        public Packet() { }
        public Packet(Byte[] pData)
        {
            Data = pData;
        }

        public void ZeroFill()
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = 0;
            }
        }

        public void WriteByte(Byte pVal, UInt16 pPos)
        {
            Data[pPos] = pVal;
        }

        public void WriteUInt16(UInt16 pVal, UInt16 pPos)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(pVal), 0, Data, pPos, 2);
        }

        public void WriteUInt32(UInt32 pVal, UInt16 pPos)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(pVal), 0, Data, pPos, 4);
        }

        public void WriteString(String pVal, UInt16 pPos)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] arr = encoding.GetBytes(pVal);

            Buffer.BlockCopy(arr, 0, Data, pPos, arr.Length);
        }

        public void WriteTick(UInt16 pPos)
        {
            Buffer.BlockCopy(BitConverter.GetBytes((UInt32) (Environment.TickCount)), 0, Data, pPos, 4);
        }
    }
   
    class PacketFactory
    {
        public static String ClientPacket = "TQClient";
        public static String ServerPacket = "TQServer";

        public static UInt32 Jump = 137;

        public static Packet FakeSkillPacket(Skill pSkill, UInt32 pUID, UInt32 pTarget, UInt16 pX, UInt16 pY)
        {
            /*Packet Nr 21. Server -> Client, Length : 40, PacketType: 1022
                20 00 FE 03 00 00 00 00 8D C6 19 00 8D C6 19 00      ;  þ    Æ Æ 
                F4 02 66 02 18 00 00 00 7B 17 00 00 00 00 00 00      ;ôf   {      
                54 51 53 65 72 76 65 72                              ;TQServer*/
            /*  20 00 FE 03 00 00 00 00 8D C6 19 00 8D C6 19 00      ;  þ    Æ Æ 
                CA 02 79 02 18 00 00 00 7B 17 00 00 00 00 00 00      ;Êy   {      
                54 51 53 65 72 76 65 72                              ;TQServer*/

            Packet pack = new Packet(new Byte[40]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(1022, 2);            
            pack.WriteUInt32(0, 4);
            pack.WriteUInt32(pUID, 8);
            pack.WriteUInt32(pTarget, 12);
            pack.WriteUInt16(pX, 16);
            pack.WriteUInt16(pY, 18);
            pack.WriteUInt32(24, 20);
            pack.WriteUInt16(pSkill.ID, 24);
            pack.WriteByte(0, 26);
            pack.WriteByte(0, 27);
            pack.WriteUInt32(0, 28);
            pack.WriteString(ServerPacket, 32);

            return pack;

        }

        public static Packet PickItem(UInt32 pUID, UInt32 pItem, UInt16 pX, UInt16 pY)
        {
            /*Packet Nr 1. Client -> Server, Length : 28, Type: 1101, Fake: False
            14 00 4D 04 23 D9 0C 00 9A A0 14 79 F5 02 E1 02      ; M#Ù  yõá
            00 00 03 00 54 51 43 6C 69 65 6E 74                  ;   TQClient*/

            Packet pack = new Packet(new Byte[32]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(1101, 2);
            pack.WriteUInt32(pItem, 4);
            pack.WriteUInt32(0x79149AA0, 8); //Dont know
            pack.WriteUInt16(pX, 12);
            pack.WriteUInt16(pY, 14);
            pack.WriteUInt16(0, 16); //Fixed
            pack.WriteByte(0x3, 18); //Remove to others
            pack.WriteByte(0, 19); //Fixed
            pack.WriteUInt32(0, 20); //Dont know
            pack.WriteString(ClientPacket, 24);
            
            return pack;

        }

        public static Packet CompraItem(UInt32 pItem, UInt32 pNPC, Boolean pbCompra)
        {
            Packet pack = new Packet(new Byte[36]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(1009, 2);
            pack.WriteUInt32(pNPC, 4);
            pack.WriteUInt32(pItem, 8);
            if (pbCompra)
            {
                pack.WriteUInt32(0x1, 12);
            }
            else
            {
                pack.WriteUInt32(0x2, 12);
            }
            pack.WriteTick(16);
            pack.WriteUInt32(0, 20);
            pack.WriteUInt32(0, 24);
            pack.WriteString(ClientPacket, 28);

            return pack;
        }

        public static Packet UseItem(UInt32 pItem)
        {
            /*Packet Nr 0. Client -> Server, Length : 36, Type: 1009, Fake: False
              1C 00 F1 03 17 5A 49 00 00 00 00 00 04 00 00 00      ; ñZI        
              C2 A8 4D 00 00 00 00 00 00 00 00 00 54 51 43 6C      ;Â¨M         TQCl
              69 65 6E 74  */

            Packet pack = new Packet(new Byte[36]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(1009, 2);
            pack.WriteUInt32(pItem, 4);
            pack.WriteUInt32(0, 8);
            pack.WriteUInt32(0x4, 12);
            pack.WriteTick(16);
            pack.WriteUInt32(0, 20);
            pack.WriteUInt32(0, 24);
            pack.WriteString(ClientPacket, 28);

            return pack;
        }

        public static Packet DropItem(UInt32 pItem)
        {
            /*Packet Nr 18. Client -> Server, Length : 36, Type: 1009, Fake: False
            1C 00 F1 03 8F 81 3A 00 01 00 00 00 25 00 00 00      ; ñ:    %   
            EC C3 52 01 00 00 00 00 00 00 00 00 54 51 43 6C      ;ìÃR        TQCl
            69 65 6E 74                                          ;ient*/

            Packet pack = new Packet(new Byte[88]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(1009, 2);
            pack.WriteUInt32(pItem, 4);
            pack.WriteUInt32((UInt32) (Constants.Rnd.Next(0, 9)), 8);
            pack.WriteUInt32(0x25, 12);
            pack.WriteTick(16);            
            pack.WriteString(ClientPacket, 80);

            return pack;
        }

        public static Packet AttackPacket(UInt32 pUID, UInt32 pTarget, UInt16 pX, UInt16 pY, Byte pAttackType, Boolean pSendLoc)
        {
            /*20 00 FE 03 31 08 3E 03 8D C6 19 00 7B 31 06 00      ;  þ1>Æ {1 
            1C 03 3D 02 02 00 00 00 00 00 00 00 00 00 00 00      ;=           
            54 51 43 6C 69 65 6E 74                              ;TQClient*/

            Packet pack = new Packet(new Byte[48]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(1022, 2);
            UInt32 time = Native.timeGetTime();
            pack.WriteUInt32(time, 4);
            pack.WriteUInt32(pUID, 8);
            pack.WriteUInt32(pTarget, 12);
            if (pSendLoc)
            {
                pack.WriteUInt16(pX, 16);
                pack.WriteUInt16(pY, 18);
            }
            else
            {
                pack.WriteUInt16(0, 16);
                pack.WriteUInt16(0, 18);
            }
            pack.WriteUInt32(pAttackType, 20);
            pack.WriteUInt32(0, 24);  //Dont know           
            pack.WriteUInt32(0, 28);  //Dont know
            pack.WriteUInt32(0, 32);  //Dont know
            pack.WriteUInt32(0, 36);  //Dont know
            pack.WriteString(ClientPacket, 40);

            return pack;
        }

        public static Packet UseSkillPacket(Skill pSkill, UInt32 pUID, UInt32 pTarget, UInt16 pX, UInt16 pY)
        {
            /*Packet Nr 0. Client -> Server, Length : 48, Type: 1022, Fake: False
            28 00 FE 03 F0 2B 55 01 21 AD 1A 00 6B 85 74 18      ;( þð+U!­ kt
            54 91 EC 48 18 00 00 00 2C 5D 21 C7 00 00 00 00      ;TìH   ,]!Ç    
            00 00 00 00 00 00 00 00 54 51 43 6C 69 65 6E 74      ;        TQClient
            */ 
            Packet pack = new Packet(new Byte[48]);
            pack.ZeroFill();

            #region Encrypting
            pTarget += 0x746F4AE6;
            pTarget ^= pUID;
            pTarget ^= 0x5F2D2463;
            pTarget = ((pTarget << 13) | (pTarget >> 19));

            ulong _X = pX + 0xffff22ee;
            _X -= 0xffff0000;
            _X = ((_X << 15) | (_X >> 1));
            _X ^= 0x2ed6;
            _X ^= pUID;
            pX = (ushort)_X;

            ulong _Y = pY + 0xffff8922;
            _Y -= 0xffff0000;
            _Y = ((_Y << 11) | (_Y >> 5));
            _Y ^= 0xb99b;
            _Y ^= pUID;
            pY = (ushort)_Y;
            ushort SkillId = pSkill.ID;
            SkillId += 0xeb42;
            SkillId = (ushort)(SkillId << 13 | SkillId >> 0x3);
            SkillId = (ushort)(SkillId ^ pUID);
            SkillId ^= 0x915d;
            #endregion

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(1022, 2);            
            UInt32 time = Native.timeGetTime();
            pack.WriteUInt32(time, 4);            
            pack.WriteUInt32(pUID, 8);
            pack.WriteUInt32(pTarget, 12);
            pack.WriteUInt16(pX, 16);
            pack.WriteUInt16(pY, 18);
            pack.WriteUInt32(24, 20);
            pack.WriteUInt16(SkillId, 24);
            pack.WriteByte((byte)(pSkill.Level ^ 33), 26);
            pack.WriteByte((byte)((time & 0xff) ^ 55), 27);
            pack.WriteUInt32(0, 28);
            pack.WriteUInt32(0, 32);
            pack.WriteUInt32(0, 36);
            pack.WriteString(ClientPacket, 40);

            return pack;
        }

        public static Packet MovePacket(UInt32 pUID, Byte pDirection, Byte pSpeed, UInt32 pMap)
        {
            Packet pack = new Packet(new Byte[32]);
            pack.ZeroFill();

            //0 South, 1 South East, 2 West, 3 North West, 4 North, 5 North East, 6 East, 7 South East
            pack.WriteUInt16((UInt16) (pack.Length - 8), 0);
            pack.WriteUInt16(10005, 2);
            pack.WriteUInt32((UInt32) (pDirection + (8 * Constants.Rnd.Next(7))), 4);
            pack.WriteUInt32(pUID, 8);
            pack.WriteUInt16(1, 12); //Dont know
            pack.WriteUInt16(0, 14); //Dont know
            pack.WriteTick(16);
            pack.WriteUInt16((UInt16) pMap, 20); //Dont know
            pack.WriteUInt16(0, 22); //Dont know
            pack.WriteString(ClientPacket, 24);

            return pack;
        }

        public static Packet PositionPacket(UInt32 pUID, UInt16 pXFrom, UInt16 pYFrom, UInt16 pXTo, UInt16 pYTo, UInt32 pLastTick)
        {
            /*24 00 1A 27 96 BB 19 00 DA 02 85 01 00 00 00 00      ;$ '» Ú    
            B1 8A 2B 08 6C 00 00 00 DA 02 85 01 00 00 00 00      ;±+l   Ú    
            00 00 00 00 54 51 53 65 72 76 65 72                  ;    TQServer*/
            /*24 00 1A 27 96 BB 19 00 C9 02 41 01 00 00 00 00      ;$ '» ÉA    
            C4 03 6D 08 6C 00 00 00 C9 02 41 01 00 00 00 00      ;Äml   ÉA    
            00 00 00 00 54 51 53 65 72 76 65 72                  ;    TQServer*/

            Packet pack = new Packet(new Byte[45]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(10010, 2);
            pack.WriteUInt32(pUID, 4);
            pack.WriteUInt16(pXFrom, 8);
            pack.WriteUInt16(pYFrom, 10);
            pack.WriteUInt32(0, 12);
            pack.WriteUInt32(pLastTick, 16);
            pack.WriteUInt32(108, 20);            
            pack.WriteUInt16(pXTo, 24);
            pack.WriteUInt16(pYTo, 26);
            pack.WriteUInt32(0, 28);
            pack.WriteUInt32(0, 32);
            pack.WriteByte(0, 36);
            pack.WriteString(ServerPacket, 37);
            return pack;
        }

        public static Packet JumpPacket(UInt32 pUID, UInt16 pXFrom, UInt16 pYFrom, Location pLoc)
        {
            Packet pack = new Packet(new Byte[45]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(10010, 2);
            pack.WriteUInt32(pUID, 4);
            pack.WriteUInt16(pLoc.X, 8);
            pack.WriteUInt16(pLoc.Y, 10);
            pack.WriteUInt32(0, 12); //Dont know
            pack.WriteTick(16);
            pack.WriteUInt32(Jump, 20);
            pack.WriteUInt16(pXFrom, 24);
            pack.WriteUInt16(pYFrom, 26);
            if ((pLoc.MapaDinamico != pLoc.Map) && (pLoc.MapaDinamico > 0))
            {
                pack.WriteUInt16((UInt16)pLoc.MapaDinamico, 28); //Dont know
                pack.WriteUInt32(0xFFFFFFFF, 32); //Dont know            
            }
            else
            {
                pack.WriteUInt16((UInt16)pLoc.Map, 28); //Dont know
                pack.WriteUInt32(0xFFFFFFFF, 32); //Dont know            
                //pack.WriteUInt32(0, 32); //Dont know            
            }            
            
            pack.WriteString(ClientPacket, 37);
            return pack;
        }

        public static Packet MiningPacket(UInt32 pUID)
        {                        
            Packet pack = new Packet(new Byte[45]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(10010, 2);
            pack.WriteUInt32(pUID, 4);
            pack.WriteUInt32(0, 8);
            pack.WriteUInt32(0, 12);
            pack.WriteTick(16);
            pack.WriteUInt16(99, 20); //Mine
            pack.WriteUInt16((UInt16) Constants.Rnd.Next(0, 7), 22); //Mine            
            pack.WriteString(ClientPacket, 37);
            return pack;
        }

        public static Packet RevivePacket(UInt32 pUID)
        {           
            Packet pack = new Packet(new Byte[45]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(10010, 2);
            pack.WriteUInt32(pUID, 4);
            pack.WriteUInt32(0, 8);
            pack.WriteUInt32(0, 12);
            pack.WriteTick(16);
            pack.WriteUInt32(0x5E, 20); //Revive            
            pack.WriteString(ClientPacket, 37);
            return pack;
        }

        public static Packet BancoPacket(UInt32 pNpcID, Boolean pbGuardar, UInt32 pItem)
        {
            /*Packet Nr 1. Client -> Server, Length : 84, Type: 1102, Fake: False
            4C 00 4E 04 1C 27 00 00 02 0A 00 00 00 00 00 00      ;L N'        
            3B 7B F4 00 00 00 00 00 00 00 00 00 00 00 00 00      ;;{ô             
            00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00      ;                
            00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00      ;                
            00 00 00 00 00 00 00 00 00 00 00 00 54 51 43 6C      ;            TQCl
            69 65 6E 74                                          ;ient*/

            Packet pack = new Packet(new Byte[84]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(1102, 2);
            pack.WriteUInt32(pNpcID, 4);
            if (pbGuardar)
            {
                pack.WriteByte(0x01, 8);
                pack.WriteByte(0x0A, 9);
            }
            else
            {
                pack.WriteByte(0x02, 8);
                pack.WriteByte(0x0A, 9);
            }
            pack.WriteUInt32(pItem, 16);         
            pack.WriteString(ClientPacket, 76);
            return pack;
        }

        public static Packet GeneralData(UInt32 pUID, UInt32 pValue1, UInt16 pValue2, UInt16 pValue3, UInt16 pType, UInt32 pMap)
        {            
            Packet pack = new Packet(new Byte[45]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(10010, 2);
            pack.WriteUInt32(pUID, 4);
            pack.WriteUInt32(pValue1, 8);
            pack.WriteUInt32(0, 12);
            pack.WriteTick(16);
            pack.WriteUInt32(pType, 20);
            pack.WriteUInt16(pValue2, 24);
            pack.WriteUInt16(pValue3, 26);
            pack.WriteUInt16((UInt16) pMap, 28); //Dont know
            pack.WriteUInt16(0, 30); //Dont know
            pack.WriteUInt16(0, 32); //Dont know
            pack.WriteUInt16(0, 34); //Dont know
            pack.WriteByte(0, 36); //Dont know 
            pack.WriteString(ServerPacket, 37);            
            return pack;
        }

        public static Packet Chat2031(UInt32 pNpcID)
        {
            /*Packet Nr 0. Client -> Server, Length : 24, Type: 2031, Fake: False
            10 00 EF 07 C5 10 00 00 00 00 00 00 00 00 00 00      ; ïÅ          
            54 51 43 6C 69 65 6E 74                              ;TQClient*/
            Packet pack = new Packet(new Byte[24]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(2031, 2);
            pack.WriteUInt32(pNpcID, 4);
            pack.WriteUInt32(0, 8);
            pack.WriteUInt32(0, 12);
            pack.WriteString(ClientPacket, 16);            

            return pack;
        } 
       
        public static Packet Chat2032(UInt16 pID)
        {
            /*Packet Nr 2. Client -> Server, Length : 24, Type: 2032, Fake: False
            10 00 F0 07 00 00 00 00 00 00 00 65 00 00 00 00      ; ð       e    
            54 51 43 6C 69 65 6E 74                              ;TQClient*/
            Packet pack = new Packet(new Byte[24]);
            pack.ZeroFill();

            pack.WriteUInt16((UInt16)(pack.Length - 8), 0);
            pack.WriteUInt16(2032, 2);
            pack.WriteUInt32(0, 4);
            pack.WriteUInt16(0, 8);
            pack.WriteUInt16(pID, 10);
            pack.WriteString(ClientPacket, 16);

            return pack;
        } 
    }
}
