using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace MyProxy
{
    public abstract class Listener : IDisposable
    {
        public Listener(int Port, IPAddress Address)
        {
            this.Port = Port;
            this.Address = Address;
        }
        protected int Port
        {
            get
            {
                return m_Port;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException();
                m_Port = value;
                Restart();
            }
        }
        protected IPAddress Address
        {
            get
            {
                return m_Address;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                m_Address = value;
                Restart();
            }
        }
        protected Socket ListenSocket
        {
            get
            {
                return m_ListenSocket;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                m_ListenSocket = value;
            }
        }
        protected ArrayList Clients
        {
            get
            {
                return m_Clients;
            }
        }
        public bool IsDisposed
        {
            get
            {
                return m_IsDisposed;
            }
        }
        public void Start()
        {
            try
            {
                ListenSocket = new Socket(Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                ListenSocket.Bind(new IPEndPoint(Address, Port));
                ListenSocket.Listen(50);
                ListenSocket.BeginAccept(new AsyncCallback(this.OnAccept), ListenSocket);
            }
            catch
            {
                ListenSocket = null;
                throw new SocketException();
            }
        }
        protected void Restart()
        {
            //If we weren't listening, do nothing
            if (ListenSocket == null)
                return;
            ListenSocket.Close();
            Start();
        }
        protected void AddClient(Client client)
        {
            if (Clients.IndexOf(client) == -1)
                Clients.Add(client);
        }
        protected void RemoveClient(Client client)
        {
            Clients.Remove(client);
        }
        public int GetClientCount()
        {
            return Clients.Count;
        }
        public Client GetClientAt(int Index)
        {
            if (Index < 0 || Index >= GetClientCount())
                return null;
            return (Client)Clients[Index];
        }
        public bool Listening
        {
            get
            {
                return ListenSocket != null;
            }
        }
        public void Dispose()
        {
            if (IsDisposed)
                return;
            while (Clients.Count > 0)
            {
                ((Client)Clients[0]).Dispose();
            }
            try
            {
                ListenSocket.Shutdown(SocketShutdown.Both);
            }
            catch { }
            if (ListenSocket != null)
                ListenSocket.Close();
            m_IsDisposed = true;
        }

        ~Listener()
        {
            Dispose();
        }        
        
        public abstract void OnAccept(IAsyncResult ar);
        public override abstract string ToString();
        public abstract string ConstructString { get; }
        private int m_Port;
        private IPAddress m_Address;
        private Socket m_ListenSocket;
        private ArrayList m_Clients = new ArrayList();
        private bool m_IsDisposed = false;
    }

}
