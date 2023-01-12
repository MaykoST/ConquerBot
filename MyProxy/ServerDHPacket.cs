using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyProxy
{
    public class ServerDHPacket
    {
        public byte[] ServerIV;
        public byte[] ClientIV;
        public string P;
        public string G;
        public string Server_PubKey;
        int JunkLength;

        public ServerDHPacket(byte[] pPacket)
        {
            MemoryStream stream = new MemoryStream(pPacket);
            BinaryReader reader = new BinaryReader(stream);
            reader.ReadBytes(11);//JUNK
            reader.ReadUInt32();//Length - Like i care of it
            JunkLength = reader.ReadInt32();
            reader.ReadBytes(JunkLength);//JUNK
            ServerIV = reader.ReadBytes(reader.ReadInt32());
            ClientIV = reader.ReadBytes(reader.ReadInt32());
            P = Encoding.ASCII.GetString(reader.ReadBytes(reader.ReadInt32()));
            G = Encoding.ASCII.GetString(reader.ReadBytes(reader.ReadInt32()));
            Server_PubKey = Encoding.ASCII.GetString(reader.ReadBytes(reader.ReadInt32()));
            reader.Close();
            stream.Close();
        }
        public void Edit(byte[] pPacket, string pEditedPubKey)
        {
            MemoryStream stream = new MemoryStream(pPacket);
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Seek(55 + JunkLength + P.Length + G.Length, SeekOrigin.Current);
            writer.Write(Encoding.ASCII.GetBytes(pEditedPubKey));
            writer.Close();
            stream.Close();
        }
    }
}
