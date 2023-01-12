using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace MyProxy
{
    public class RawListener : Listener
    {
        public RawListener(int Port, IPEndPoint MapToIP) : this(IPAddress.Any, Port, MapToIP) { }
        public RawListener(IPAddress Address, int Port, IPEndPoint MapToIP)
            : base(Port, Address)
        {
            MapTo = MapToIP;
        }
        public RawListener(IPAddress Address, int Port, IPAddress MapToAddress, int MapToPort) : this(Address, Port, new IPEndPoint(MapToAddress, MapToPort)) { }
        private IPEndPoint MapTo
        {
            get
            {
                return m_MapTo;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                m_MapTo = value;
            }
        }
        public override void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket NewSocket = ListenSocket.EndAccept(ar);
                if (NewSocket != null)
                {
                    RawClient NewClient = new RawClient(NewSocket, new DestroyDelegate(this.RemoveClient), MapTo);
                    AddClient(NewClient);
                    NewClient.StartHandshake();
                }
            }
            catch { }
            try
            {
                //Restart Listening
                ListenSocket.BeginAccept(new AsyncCallback(this.OnAccept), ListenSocket);
            }
            catch
            {
                Dispose();
            }
        }
        public override string ToString()
        {
            return "PORTMAP service on " + Address.ToString() + ":" + Port.ToString();
        }
        public override string ConstructString
        {
            get
            {
                return "host:" + Address.ToString() + ";int:" + Port.ToString() + ";host:" + MapTo.Address.ToString() + ";int:" + MapTo.Port.ToString();
            }
        }
        private IPEndPoint m_MapTo;
    }
}
