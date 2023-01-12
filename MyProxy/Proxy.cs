using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Collections.ObjectModel;

namespace MyProxy
{
    public delegate void ClientConnects(Client C);
    public delegate void ConnectionLost(Client C);
    public delegate void DataFromClient(Client C, byte[] Data);
    public delegate void DataFromServer(Client C, byte[] Data);

    public class Proxy
    {
        public int LocalPort { get; set; }
        public int RemotePort { get; set; }
        public string LocalAddr { get; set; }
        public string RemoteAddr { get; set; }
        public Socket ClientListener { get; set; }
        public int BufferSize { get; set; }

        public ClientConnects NewConnection { get; set; }
        public DataFromClient ClientData { get; set; }
        public DataFromServer ServerData { get; set; }
        public ConnectionLost DCFromClient { get; set; }
        public ConnectionLost DCFromServer { get; set; }

        public String ConquerPath { get; set; }

        public ObservableCollection<Client> ClientList { get; set; }
     
        public Proxy()
        {
            ClientList = new ObservableCollection<Client>();
            BufferSize = 8192;
        }

        public void Start()
        {
            ClientListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(LocalAddr), LocalPort);
            ClientListener.Bind(ipe);
            ClientListener.Listen(100);

            ClientListener.BeginAccept(new AsyncCallback(ListenForClients), new Client());
        }

        public void Stop()
        {
            ClientListener.BeginDisconnect(true, null, null);
        }

        private void ListenForClients(IAsyncResult Result)
        {
            Client cli = (Client)Result.AsyncState;
            try
            {
                cli.ClientSocket = ClientListener.EndAccept(Result);
                if (NewConnection != null)
                {
                    NewConnection.Invoke(cli);
                }
                cli.ClientSocket.BeginReceive(cli.ClientBuffer, 0, BufferSize, SocketFlags.None, new AsyncCallback(ReceiveFromClient), cli);
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
            finally
            {
                ClientListener.BeginAccept(new AsyncCallback(ListenForClients), new Client());
            }
        }

        public void ReceiveFromClient(IAsyncResult Result)
        {
            try
            {
                Client cli = (Client)Result.AsyncState;
                SocketError SE;
                int Length = cli.ClientSocket.EndReceive(Result, out SE);

                if (Length > 0 && SE == SocketError.Success)
                {
                    try
                    {
                        if (Length > 0)
                        {
                            byte[] data = new byte[Length];
                            Buffer.BlockCopy(cli.ClientBuffer, 0, data, 0, Length);

                            cli.ServerCrypto.Decrypt(data);

                            if (ClientData != null)
                            {
                                ClientData.Invoke(cli, data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Exception(ex);
                    }
                    finally
                    {
                        cli.ClientSocket.BeginReceive(cli.ClientBuffer, 0, BufferSize, SocketFlags.None, new AsyncCallback(ReceiveFromClient), cli);
                    }
                }
                else
                {
                    if (DCFromClient != null)
                    {
                        DCFromClient.Invoke(cli);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }

        public void SendToClient(Client pCli, Byte[] pData)
        {
            SendTo(pCli.ClientSocket, pCli.ClientSocket.LocalEndPoint, pCli.ServerCrypto, pData);
        }

        public void SendToServer(Client pCli, Byte[] pData)
        {
            SendTo(pCli.ServerSocket, pCli.ServerSocket.RemoteEndPoint, pCli.ClientCrypto, pData);
        }

        private void SendTo(Socket pSocket, EndPoint pEnd, GameCrypto pCrypto, byte[] pData)
        {
            if (pSocket.Connected)
            {
                try
                {
                    byte[] encData = new byte[pData.Length];

                    Buffer.BlockCopy(pData, 0, encData, 0, pData.Length);

                    pCrypto.Encrypt(encData);

                    pSocket.SendTo(encData, pEnd);
                }
                catch (Exception ex)
                {
                    Log.Exception(ex);
                }
            }
        }

        public bool ConnectToServer(Client pCli)
        {
            pCli.ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                pCli.ServerSocket.Connect(IPAddress.Parse(RemoteAddr), RemotePort);
                pCli.ServerSocket.BeginReceive(pCli.ServerBuffer, 0, BufferSize, SocketFlags.None, new AsyncCallback(ReceiveFromServer), pCli);
                return true;
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
            return false;
        }

        public void DisconnectFromServer(Client pCli)
        {
            pCli.ServerSocket.Disconnect(true);
            Log.Message("Disconect from server: " + DateTime.Now.ToShortTimeString());
        }

        public void DisconnectFromClient(Client pCli)
        {
            Log.Message("Disconect from client: " + DateTime.Now.ToShortTimeString());
            pCli.ClientSocket.Disconnect(true);
        }

        public void ReceiveFromServer(IAsyncResult Result)
        {
            try
            {
                Client cli = (Client)Result.AsyncState;
                SocketError SE;
                int Length = cli.ServerSocket.EndReceive(Result, out SE);

                if (Length > 0 && SE == SocketError.Success)
                {
                    if (Length > 0)
                    {
                        byte[] data = new byte[Length];
                        Buffer.BlockCopy(cli.ServerBuffer, 0, data, 0, Length);

                        cli.ClientCrypto.Decrypt(data);

                        if (ServerData != null)
                        {
                            ServerData.Invoke(cli, data);
                        }                        
                    }
                    cli.ServerSocket.BeginReceive(cli.ServerBuffer, 0, BufferSize, SocketFlags.None, new AsyncCallback(ReceiveFromServer), cli);
                }
                else
                {
                    if (DCFromServer != null)
                    {
                        DCFromServer.Invoke(cli);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        } 

    }

}
