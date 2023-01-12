using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyProxy
{
    public class ClientDHPacket
    {
        public string Client_PubKey;
        int JunkLength;

        public ClientDHPacket(byte[] pPacket)
        {
            MemoryStream stream = new MemoryStream(pPacket);
            BinaryReader reader = new BinaryReader(stream);

            reader.ReadBytes(7);//JUNK
            reader.ReadUInt32();//Length
            JunkLength = reader.ReadInt32();
            reader.ReadBytes(JunkLength);
            Client_PubKey = Encoding.ASCII.GetString(reader.ReadBytes(reader.ReadInt32()));
            reader.Close();
            stream.Close();
        }

        public void Edit(byte[] pPacket, string pNewKey)
        {
            MemoryStream stream = new MemoryStream(pPacket);
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Seek(19 + JunkLength, SeekOrigin.Current);
            writer.Write(Encoding.ASCII.GetBytes(pNewKey));
        }
    }
}
