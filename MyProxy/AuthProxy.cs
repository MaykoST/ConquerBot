using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProxy
{
    public class AuthProxy : Proxy
    {
        public AuthProxy(String pRemoteAddr, int pRemotePort, string pLocalAddr, int pLocalPort)
            : base()
        {
            RemoteAddr = pRemoteAddr;
            RemotePort = pRemotePort;
            LocalAddr = pLocalAddr;
            LocalPort = pLocalPort;

            NewConnection = new ClientConnects(ClientConn);
            ClientData = new DataFromClient(ClientRelay);
            ServerData = new DataFromServer(ServerRelay);
            DCFromClient = new ConnectionLost(ClientDC);
            DCFromServer = new ConnectionLost(ServerDC);
        }

        public void ClientConn(Client pCli)
        {            
            if (!ConnectToServer(pCli))
            {
                DisconnectFromServer(pCli);
                Console.WriteLine("Cannot connect to {0}:{1}", RemoteAddr, RemotePort);
                return;
            }
        }

        private void ClientRelay(Client pCli, byte[] pData)
        {
            try
            {
                SendToServer(pCli, pData);
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
                SendToClient(pCli, pData);
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }

        private void ClientDC(Client pCli)
        {
            DisconnectFromServer(pCli);
        }
        private void ServerDC(Client pCli)
        {
            DisconnectFromClient(pCli);
        }
    }

}
