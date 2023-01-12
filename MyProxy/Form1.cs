using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace MyProxy
{
    public partial class frmMain : Form
    {
        AuthProxy LogonProxy;
        GameProxy WorldProxy;
        Timer timer;

        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogonProxy = new AuthProxy(txtAuthIP.Text, Convert.ToInt32(txtAuthPort.Text), "0.0.0.0", Convert.ToInt32(txtAuthPort.Text));
            LogonProxy.Start();
            WorldProxy = new GameProxy(txtGameIp.Text, Convert.ToInt32(txtGamePort.Text), "0.0.0.0", Convert.ToInt32(txtGamePort.Text), txtDir.Text, txtLogPath.Text);
            WorldProxy.Start();
            timer = new Timer();
            timer.Proxy = WorldProxy;
            timer.Start();

            Log.Logger += new EventLog(Log_Logger);
            Log.ExceptionLogger += new ExceptionLog(Log_ExceptionLogger);

            btnStartProxy.Enabled = false;
            btnStopProxy.Enabled = true;

        }

        void Log_ExceptionLogger(Exception ex)
        {         
            textBox1.Invoke((MethodInvoker)delegate
            {
                textBox1.AppendText(ex.Message);
            });          
        }

        void Log_Logger(string message)
        {            
            textBox1.Invoke((MethodInvoker)delegate
            {
                textBox1.AppendText(message);

                if (message.Contains("Bot parou") || message.Contains("Bot stop"))
                {
                    pnlStatus.BackColor = Color.Red;
                }
            });           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            int pos = cbxChar.SelectedIndex;

            cbxChar.Items.Clear();

            foreach (Client c in WorldProxy.ClientList)
            {
                if (c.MyChar != null)
                {
                    cbxChar.Items.Add(c.MyChar.UID);
                    c.MyChar.StopEvent += new StopBotDelegate(MyChar_StopEvent);
                }                
            }

            if (pos < cbxChar.Items.Count)
            {
                cbxChar.SelectedIndex = pos;
            }
            else if (cbxChar.Items.Count > 0)
            {
                cbxChar.SelectedIndex = 0;
            }
        }

        void MyChar_StopEvent()
        {
            pnlStatus.BackColor = Color.Red;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {                
                WorldProxy.ClientList[cbxChar.SelectedIndex].MyChar.Booting = true;
                pnlStatus.BackColor = Color.Green;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                WorldProxy.ClientList[cbxChar.SelectedIndex].MyChar.StopBot();                
                pnlStatus.BackColor = Color.Red;
            }
        }

        private void chkSniff_CheckedChanged(object sender, EventArgs e)
        {
            if (WorldProxy != null)
            {
                if (chkSniff.Checked)
                {
                    WorldProxy.Sniff = true;
                }
                else
                {
                    WorldProxy.Sniff = false;
                }
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (timer != null)
            {
                timer.Running = false;
                timer.Stop();
            }
        }        

        private void btnUpdateBot_Click(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                Client c = WorldProxy.ClientList[cbxChar.SelectedIndex];

                c.MyChar.AtkDelay = Convert.ToInt32(edtAtkD.Text);
                c.MyChar.XPAtkDelay = Convert.ToInt32(edtXPAtkD.Text);
                c.MyChar.MaxAtkWait = Convert.ToInt32(edtMaxAtkWait.Text);
                c.MyChar.JumpDelay = Convert.ToInt32(edtJumpD.Text);
                c.MyChar.XPJumpDelay = Convert.ToInt32(edtXPJumpD.Text);
                c.MyChar.MobFilter = edtMob.Text;                
                c.MyChar.PickPlus = chkPlus.Checked;
                c.MyChar.CanPickItens = chkPickItens.Checked;
                c.MyChar.ArrowID = UInt32.Parse(edtCompraItemID.Text);
                c.MyChar.NPCX = UInt16.Parse(edtNPCX.Text);
                c.MyChar.NPCY = UInt16.Parse(edtNPCY.Text);
                c.MyChar.UpdatePickListFilter(edtPickFilter.Text);
                if (edtPickQ.Text.Length > 0)
                {
                    c.MyChar.PickQuality = edtPickQ.Text[0];
                }
                c.MyChar.UseScatter = chkScatter.Checked;
                c.MyChar.NinjaFastMode = chkNinjaFast.Checked;
                c.MyChar.MoveMouse = chkMoveMouse.Checked;
                c.MyChar.PotionHP = UInt32.Parse(edtPotionHP.Text);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                Client c = WorldProxy.ClientList[cbxChar.SelectedIndex];

                c.MyChar.UseItemDelay = Convert.ToInt32(edtUseItemDelay.Text);                
            }
        }

        private void btnStartMiner_Click(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                WorldProxy.ClientList[cbxChar.SelectedIndex].MyChar.Mining = true;
                //pnlStatus.BackColor = Color.Green;
            }
        }

        private void btnStopMiner_Click(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                WorldProxy.ClientList[cbxChar.SelectedIndex].MyChar.Mining = false;
                //pnlStatus.BackColor = Color.Green;
            }
        }

        private void btnStopProxy_Click(object sender, EventArgs e)
        {
            btnStartProxy.Enabled = true;
            btnStopProxy.Enabled = false;
        }

        private void btnUseItem_Click(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                WorldProxy.ClientList[cbxChar.SelectedIndex].MyChar.UseItem(UInt32.Parse(edtItemID.Text));
            }
        }

        private void btnCompraItem_Click(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                WorldProxy.ClientList[cbxChar.SelectedIndex].MyChar.CompraItem(UInt32.Parse(edtCompraItemID.Text), UInt16.Parse(edtNPCX.Text), UInt16.Parse(edtNPCY.Text), true);
            }
        }

        private void btnMoverPara_Click(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                WorldProxy.ClientList[cbxChar.SelectedIndex].MyChar.MoverPara = new Location(UInt16.Parse(edtNPCX.Text), UInt16.Parse(edtNPCY.Text));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                WorldProxy.ClientList[cbxChar.SelectedIndex].MyChar.entraMina = new EntradaMina();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                WorldProxy.ClientList[cbxChar.SelectedIndex].MyChar.Revive();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                WorldProxy.ClientList[cbxChar.SelectedIndex].MyChar.GuardaItem(UInt32.Parse(edtItemID.Text), UInt16.Parse(edtNPCX.Text), UInt16.Parse(edtNPCY.Text), true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cbxChar.SelectedIndex >= 0)
            {
                WorldProxy.ClientList[cbxChar.SelectedIndex].MyChar.BlueMouse = true;             
            }
        }        
    }
}
