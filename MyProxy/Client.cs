using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace MyProxy
{
    public class Client
    {
        public Socket ClientSocket { get; set; }
        public Socket ServerSocket { get; set; }
        public byte[] ClientBuffer { get; set; }
        public byte[] ClientProtBuffer { get; set; }
        public byte[] ServerBuffer { get; set; }
        public byte[] ServerProtBuffer { get; set; }

        public ServerDHPacket ServerDataDHP { get; set; }
        public ClientDHPacket ClientDataDHP { get; set; }

        public GameCrypto ClientCrypto { get; set; }
        public GameCrypto ServerCrypto { get; set; }

        public bool DHExchangeCompleted = false;

        public UInt32 LastServerTick { get; set; }

        //public PacketHandler ClientHandler { get; set; }
        //public PacketHandler ServerHandler { get; set; }

        public object ServerLock { get; set; }
        public object ClientLock { get; set; }

        public MyCharacter MyChar { get; set; }

        public int BufferSize { get; set; }

        public Client()
        {
            BufferSize = 8192;
            ClientBuffer = new byte[BufferSize];
            ServerBuffer = new byte[BufferSize];

            ServerLock = new object();
            ClientLock = new Object();


            ClientCrypto = new GameCrypto(Encoding.ASCII.GetBytes("DR654dt34trg4UI6"));
            ServerCrypto = new GameCrypto(Encoding.ASCII.GetBytes("DR654dt34trg4UI6"));

            ClientCrypto.Blowfish.EncryptIV = new byte[8];
            ClientCrypto.Blowfish.DecryptIV = new byte[8];
            ServerCrypto.Blowfish.EncryptIV = new byte[8];
            ServerCrypto.Blowfish.DecryptIV = new byte[8];

            //ClientHandler = new PacketHandler();
            //ServerHandler = new PacketHandler();
        }
    }
}
