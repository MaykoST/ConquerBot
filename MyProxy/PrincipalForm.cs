using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyProxy
{
    public partial class PrincipalForm : Form
    {
        public AuthProxy ProxyLogin { get; set; }
        public GameProxy ProxyJogo { get; set; }
        
        private Timer timer;

        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void btnIniciaProxy_Click(object sender, EventArgs e)
        {
            this.ProxyLogin = new AuthProxy(txtIPServidorLogin.Text, Convert.ToInt32(txtPortaServidorLogin.Text), "0.0.0.0", Convert.ToInt32(txtPortaServidorLogin.Text));
            this.ProxyLogin.Start();
            this.ProxyJogo = new GameProxy(txtIPServidorJogo.Text, Convert.ToInt32(txtPortaServidorJogo.Text), "0.0.0.0", Convert.ToInt32(txtPortaServidorJogo.Text), txtDiretorioJogo.Text, "D:\\Log\\");
            this.ProxyJogo.Start();
            timer = new Timer();
            timer.Proxy = this.ProxyJogo;
            timer.Start();

            this.ProxyJogo.CharacterLogin += new CharacterEvent(ProxyJogo_CharacterLogin);
        }

        void ProxyJogo_CharacterLogin(Client pCli)
        {
            lock (this.ProxyJogo.ClientList)
            {
                var query = from c in this.ProxyJogo.ClientList where c.MyChar != null select c.MyChar.UID + " - " + c.MyChar.Name;

                this.lstCharLogados.DataSource = query;                
            }
        }        

        private void btnPararProxy_Click(object sender, EventArgs e)
        {
            if (this.ProxyLogin != null)
            {
                this.ProxyLogin.Stop();
            }
            if (this.ProxyJogo != null)
            {
                this.ProxyJogo.Stop();
            }
        }
    }
}
