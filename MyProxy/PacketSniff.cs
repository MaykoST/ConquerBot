using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace MyProxy
{
    public class PacketSniff
    {
        public static uint ServerPacketsCount = 0;
        public static uint ClientPacketsCount = 0;
        public static UInt32 SniffingStarted = Native.timeGetTime();
        public static bool Sniffing = true;
        public static Location monitor = new Location();
        public static String LogPath = "";

        public static void ServerPacket(byte[] Data, Boolean pFake)
        {
            try
            {
                ushort PacketLength = BitConverter.ToUInt16(Data, 0);
                if (ASCIIEncoding.ASCII.GetString(Data).Contains("TQServer") || ASCIIEncoding.ASCII.GetString(Data).Contains("TQClient"))
                    PacketLength += 8;
                if (PacketLength > Data.Length) PacketLength = (ushort)Data.Length;

                string DataStr = "";
                DataStr += "Packet Nr " + ServerPacketsCount + ". Server -> Client, Length : " + PacketLength + ", Type: " + BitConverter.ToInt16(Data, 2) + ", Fake: " + pFake + Environment.NewLine;


                for (int i = 0; i < Math.Ceiling((double)PacketLength / 16); i++)
                {
                    int t = 16;
                    if (((i + 1) * 16) > PacketLength)
                        t = PacketLength - (i * 16);
                    for (int a = 0; a < t; a++)
                    {
                        DataStr += Data[i * 16 + a].ToString("X2") + " ";
                    }
                    if (t < 16)
                        for (int a = t; a < 16; a++)
                            DataStr += "   ";
                    DataStr += "     ;";

                    for (int a = 0; a < t; a++)
                    {
                        DataStr += Convert.ToChar(Data[i * 16 + a]);
                    }
                    DataStr += Environment.NewLine;
                }
                DataStr.Replace(Convert.ToChar(0), '.');
                DataStr += Environment.NewLine;

                lock (monitor)
                {
                    //if (BitConverter.ToInt16(Data, 2) == 10010)
                    //{
                        StreamWriter SW = new StreamWriter(LogPath + "P" + SniffingStarted.ToString() + ".txt", true);
                        SW.WriteLine(DataStr);
                        SW.Flush();
                        SW.Close();
                    //}

                }
                ServerPacketsCount++;
            }
            catch (Exception Exc)
            {
                Console.WriteLine(Exc);
            }
        }
        public static void ClientPacket(byte[] Data, Boolean pFake)
        {
            try
            {
                ushort PacketLength = BitConverter.ToUInt16(Data, 0);
                if (ASCIIEncoding.ASCII.GetString(Data).Contains("TQServer") || ASCIIEncoding.ASCII.GetString(Data).Contains("TQClient"))
                    PacketLength += 8;
                if (PacketLength > Data.Length) PacketLength = (ushort)Data.Length;

                string DataStr = "";
                DataStr += "Packet Nr " + ClientPacketsCount + ". Client -> Server, Length : " + PacketLength + ", Type: " + BitConverter.ToInt16(Data, 2) + ", Fake: " + pFake + Environment.NewLine;


                for (int i = 0; i < Math.Ceiling((double)PacketLength / 16); i++)
                {
                    int t = 16;
                    if (((i + 1) * 16) > PacketLength)
                        t = PacketLength - (i * 16);
                    for (int a = 0; a < t; a++)
                    {
                        DataStr += Data[i * 16 + a].ToString("X2") + " ";
                    }
                    if (t < 16)
                        for (int a = t; a < 16; a++)
                            DataStr += "   ";
                    DataStr += "     ;";

                    for (int a = 0; a < t; a++)
                    {
                        DataStr += Convert.ToChar(Data[i * 16 + a]);
                    }
                    DataStr += Environment.NewLine;
                }
                DataStr.Replace(Convert.ToChar(0), '.');
                DataStr += Environment.NewLine;

                lock (monitor)
                {
                    StreamWriter SW = new StreamWriter(LogPath + "P" + SniffingStarted.ToString() + ".txt", true);
                    SW.WriteLine(DataStr);
                    SW.Flush();
                    SW.Close();

                }
                ClientPacketsCount++;
            }
            catch (Exception Exc)
            {
                Console.WriteLine(Exc);
            }
        }
    }
}
