namespace MyProxy
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartProxy = new System.Windows.Forms.Button();
            this.btnStopProxy = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbsBot = new System.Windows.Forms.TabPage();
            this.chkMoveMouse = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.edtPotionHP = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkScatter = new System.Windows.Forms.CheckBox();
            this.chkNinjaFast = new System.Windows.Forms.CheckBox();
            this.edtPickQ = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.edtPickFilter = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkPickItens = new System.Windows.Forms.CheckBox();
            this.btnMoverPara = new System.Windows.Forms.Button();
            this.btnCompraItem = new System.Windows.Forms.Button();
            this.edtCompraItemID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.edtNPCY = new System.Windows.Forms.TextBox();
            this.edtNPCX = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnUseItem = new System.Windows.Forms.Button();
            this.edtItemID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkPlus = new System.Windows.Forms.CheckBox();
            this.edtMob = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.edtMaxAtkWait = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnUpdateBot = new System.Windows.Forms.Button();
            this.edtXPJumpD = new System.Windows.Forms.TextBox();
            this.edtJumpD = new System.Windows.Forms.TextBox();
            this.edtXPAtkD = new System.Windows.Forms.TextBox();
            this.edtAtkD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbsMiner = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.edtUseItemDelay = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnStopMiner = new System.Windows.Forms.Button();
            this.btnStartMiner = new System.Windows.Forms.Button();
            this.tbsLog = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbsConfig = new System.Windows.Forms.TabPage();
            this.txtAuthPort = new System.Windows.Forms.TextBox();
            this.txtAuthIP = new System.Windows.Forms.TextBox();
            this.txtGamePort = new System.Windows.Forms.TextBox();
            this.txtGameIp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSniff = new System.Windows.Forms.CheckBox();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.tbsCommand = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxChar = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbsBot.SuspendLayout();
            this.tbsMiner.SuspendLayout();
            this.tbsLog.SuspendLayout();
            this.tbsConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartProxy
            // 
            this.btnStartProxy.Location = new System.Drawing.Point(4, 12);
            this.btnStartProxy.Name = "btnStartProxy";
            this.btnStartProxy.Size = new System.Drawing.Size(92, 53);
            this.btnStartProxy.TabIndex = 0;
            this.btnStartProxy.Text = "Start Proxy";
            this.btnStartProxy.UseVisualStyleBackColor = true;
            this.btnStartProxy.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStopProxy
            // 
            this.btnStopProxy.Location = new System.Drawing.Point(102, 12);
            this.btnStopProxy.Name = "btnStopProxy";
            this.btnStopProxy.Size = new System.Drawing.Size(91, 53);
            this.btnStopProxy.TabIndex = 1;
            this.btnStopProxy.Text = "Stop Proxy";
            this.btnStopProxy.UseVisualStyleBackColor = true;
            this.btnStopProxy.Click += new System.EventHandler(this.btnStopProxy_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbsBot);
            this.tabControl1.Controls.Add(this.tbsMiner);
            this.tabControl1.Controls.Add(this.tbsLog);
            this.tabControl1.Controls.Add(this.tbsConfig);
            this.tabControl1.Controls.Add(this.tbsCommand);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 71);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(557, 472);
            this.tabControl1.TabIndex = 19;
            // 
            // tbsBot
            // 
            this.tbsBot.Controls.Add(this.chkMoveMouse);
            this.tbsBot.Controls.Add(this.button5);
            this.tbsBot.Controls.Add(this.edtPotionHP);
            this.tbsBot.Controls.Add(this.label20);
            this.tbsBot.Controls.Add(this.button4);
            this.tbsBot.Controls.Add(this.button3);
            this.tbsBot.Controls.Add(this.button2);
            this.tbsBot.Controls.Add(this.chkScatter);
            this.tbsBot.Controls.Add(this.chkNinjaFast);
            this.tbsBot.Controls.Add(this.edtPickQ);
            this.tbsBot.Controls.Add(this.label19);
            this.tbsBot.Controls.Add(this.edtPickFilter);
            this.tbsBot.Controls.Add(this.label18);
            this.tbsBot.Controls.Add(this.chkPickItens);
            this.tbsBot.Controls.Add(this.btnMoverPara);
            this.tbsBot.Controls.Add(this.btnCompraItem);
            this.tbsBot.Controls.Add(this.edtCompraItemID);
            this.tbsBot.Controls.Add(this.label17);
            this.tbsBot.Controls.Add(this.edtNPCY);
            this.tbsBot.Controls.Add(this.edtNPCX);
            this.tbsBot.Controls.Add(this.label16);
            this.tbsBot.Controls.Add(this.btnUseItem);
            this.tbsBot.Controls.Add(this.edtItemID);
            this.tbsBot.Controls.Add(this.label15);
            this.tbsBot.Controls.Add(this.chkPlus);
            this.tbsBot.Controls.Add(this.edtMob);
            this.tbsBot.Controls.Add(this.label14);
            this.tbsBot.Controls.Add(this.edtMaxAtkWait);
            this.tbsBot.Controls.Add(this.label12);
            this.tbsBot.Controls.Add(this.btnUpdateBot);
            this.tbsBot.Controls.Add(this.edtXPJumpD);
            this.tbsBot.Controls.Add(this.edtJumpD);
            this.tbsBot.Controls.Add(this.edtXPAtkD);
            this.tbsBot.Controls.Add(this.edtAtkD);
            this.tbsBot.Controls.Add(this.label11);
            this.tbsBot.Controls.Add(this.label10);
            this.tbsBot.Controls.Add(this.label9);
            this.tbsBot.Controls.Add(this.label8);
            this.tbsBot.Controls.Add(this.pnlStatus);
            this.tbsBot.Controls.Add(this.btnStop);
            this.tbsBot.Controls.Add(this.btnStart);
            this.tbsBot.Location = new System.Drawing.Point(4, 34);
            this.tbsBot.Name = "tbsBot";
            this.tbsBot.Padding = new System.Windows.Forms.Padding(3);
            this.tbsBot.Size = new System.Drawing.Size(549, 434);
            this.tbsBot.TabIndex = 1;
            this.tbsBot.Text = "Bot";
            this.tbsBot.UseVisualStyleBackColor = true;
            // 
            // chkMoveMouse
            // 
            this.chkMoveMouse.AutoSize = true;
            this.chkMoveMouse.Location = new System.Drawing.Point(110, 296);
            this.chkMoveMouse.Name = "chkMoveMouse";
            this.chkMoveMouse.Size = new System.Drawing.Size(88, 17);
            this.chkMoveMouse.TabIndex = 57;
            this.chkMoveMouse.Text = "Move Mouse";
            this.chkMoveMouse.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(212, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 50);
            this.button5.TabIndex = 56;
            this.button5.Text = "Start BlueMouse";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // edtPotionHP
            // 
            this.edtPotionHP.Location = new System.Drawing.Point(110, 210);
            this.edtPotionHP.Name = "edtPotionHP";
            this.edtPotionHP.Size = new System.Drawing.Size(100, 20);
            this.edtPotionHP.TabIndex = 55;
            this.edtPotionHP.Text = "300";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(52, 213);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 13);
            this.label20.TabIndex = 54;
            this.label20.Text = "PotionHP";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(4, 325);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 51);
            this.button4.TabIndex = 52;
            this.button4.Text = "Guarda Item";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 382);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 44);
            this.button3.TabIndex = 51;
            this.button3.Text = "Revive";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 44);
            this.button2.TabIndex = 50;
            this.button2.Text = "Entra Mina";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // chkScatter
            // 
            this.chkScatter.AutoSize = true;
            this.chkScatter.Checked = true;
            this.chkScatter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScatter.Location = new System.Drawing.Point(110, 274);
            this.chkScatter.Name = "chkScatter";
            this.chkScatter.Size = new System.Drawing.Size(82, 17);
            this.chkScatter.TabIndex = 49;
            this.chkScatter.Text = "Use Scatter";
            this.chkScatter.UseVisualStyleBackColor = true;
            // 
            // chkNinjaFast
            // 
            this.chkNinjaFast.AutoSize = true;
            this.chkNinjaFast.Location = new System.Drawing.Point(110, 251);
            this.chkNinjaFast.Name = "chkNinjaFast";
            this.chkNinjaFast.Size = new System.Drawing.Size(103, 17);
            this.chkNinjaFast.TabIndex = 48;
            this.chkNinjaFast.Text = "Ninja Fast Mode";
            this.chkNinjaFast.UseVisualStyleBackColor = true;
            // 
            // edtPickQ
            // 
            this.edtPickQ.Location = new System.Drawing.Point(276, 133);
            this.edtPickQ.Name = "edtPickQ";
            this.edtPickQ.Size = new System.Drawing.Size(100, 20);
            this.edtPickQ.TabIndex = 46;
            this.edtPickQ.Text = "8";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(224, 136);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 13);
            this.label19.TabIndex = 45;
            this.label19.Text = "Pick Qu";
            // 
            // edtPickFilter
            // 
            this.edtPickFilter.Location = new System.Drawing.Point(276, 108);
            this.edtPickFilter.Name = "edtPickFilter";
            this.edtPickFilter.Size = new System.Drawing.Size(267, 20);
            this.edtPickFilter.TabIndex = 44;
            this.edtPickFilter.Text = "1088001,1088000,1091000,1091010,1091020";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(219, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 13);
            this.label18.TabIndex = 43;
            this.label18.Text = "PickFilter";
            // 
            // chkPickItens
            // 
            this.chkPickItens.AutoSize = true;
            this.chkPickItens.Checked = true;
            this.chkPickItens.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPickItens.Location = new System.Drawing.Point(377, 163);
            this.chkPickItens.Name = "chkPickItens";
            this.chkPickItens.Size = new System.Drawing.Size(70, 17);
            this.chkPickItens.TabIndex = 42;
            this.chkPickItens.Text = "PickItens";
            this.chkPickItens.UseVisualStyleBackColor = true;
            // 
            // btnMoverPara
            // 
            this.btnMoverPara.Location = new System.Drawing.Point(291, 322);
            this.btnMoverPara.Name = "btnMoverPara";
            this.btnMoverPara.Size = new System.Drawing.Size(124, 50);
            this.btnMoverPara.TabIndex = 41;
            this.btnMoverPara.Text = "Mover Para";
            this.btnMoverPara.UseVisualStyleBackColor = true;
            this.btnMoverPara.Click += new System.EventHandler(this.btnMoverPara_Click);
            // 
            // btnCompraItem
            // 
            this.btnCompraItem.Location = new System.Drawing.Point(417, 324);
            this.btnCompraItem.Name = "btnCompraItem";
            this.btnCompraItem.Size = new System.Drawing.Size(124, 48);
            this.btnCompraItem.TabIndex = 40;
            this.btnCompraItem.Text = "Compra Item";
            this.btnCompraItem.UseVisualStyleBackColor = true;
            this.btnCompraItem.Click += new System.EventHandler(this.btnCompraItem_Click);
            // 
            // edtCompraItemID
            // 
            this.edtCompraItemID.Location = new System.Drawing.Point(291, 297);
            this.edtCompraItemID.Name = "edtCompraItemID";
            this.edtCompraItemID.Size = new System.Drawing.Size(124, 20);
            this.edtCompraItemID.TabIndex = 39;
            this.edtCompraItemID.Text = "1050001";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(258, 300);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "Item";
            // 
            // edtNPCY
            // 
            this.edtNPCY.Location = new System.Drawing.Point(356, 271);
            this.edtNPCY.Name = "edtNPCY";
            this.edtNPCY.Size = new System.Drawing.Size(59, 20);
            this.edtNPCY.TabIndex = 37;
            this.edtNPCY.Text = "332";
            // 
            // edtNPCX
            // 
            this.edtNPCX.Location = new System.Drawing.Point(291, 271);
            this.edtNPCX.Name = "edtNPCX";
            this.edtNPCX.Size = new System.Drawing.Size(59, 20);
            this.edtNPCX.TabIndex = 36;
            this.edtNPCX.Text = "452";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(256, 274);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "NPC";
            // 
            // btnUseItem
            // 
            this.btnUseItem.Location = new System.Drawing.Point(421, 242);
            this.btnUseItem.Name = "btnUseItem";
            this.btnUseItem.Size = new System.Drawing.Size(120, 46);
            this.btnUseItem.TabIndex = 34;
            this.btnUseItem.Text = "Use Item";
            this.btnUseItem.UseVisualStyleBackColor = true;
            this.btnUseItem.Click += new System.EventHandler(this.btnUseItem_Click);
            // 
            // edtItemID
            // 
            this.edtItemID.Location = new System.Drawing.Point(291, 242);
            this.edtItemID.Name = "edtItemID";
            this.edtItemID.Size = new System.Drawing.Size(124, 20);
            this.edtItemID.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(256, 245);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Item";
            // 
            // chkPlus
            // 
            this.chkPlus.AutoSize = true;
            this.chkPlus.Location = new System.Drawing.Point(275, 163);
            this.chkPlus.Name = "chkPlus";
            this.chkPlus.Size = new System.Drawing.Size(96, 17);
            this.chkPlus.TabIndex = 31;
            this.chkPlus.Text = "Pick Plus Itens";
            this.chkPlus.UseVisualStyleBackColor = true;
            // 
            // edtMob
            // 
            this.edtMob.Location = new System.Drawing.Point(275, 81);
            this.edtMob.Name = "edtMob";
            this.edtMob.Size = new System.Drawing.Size(268, 20);
            this.edtMob.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(216, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Mob Filter";
            // 
            // edtMaxAtkWait
            // 
            this.edtMaxAtkWait.Location = new System.Drawing.Point(110, 133);
            this.edtMaxAtkWait.Name = "edtMaxAtkWait";
            this.edtMaxAtkWait.Size = new System.Drawing.Size(100, 20);
            this.edtMaxAtkWait.TabIndex = 4;
            this.edtMaxAtkWait.Text = "4000";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Max Attack Wait";
            // 
            // btnUpdateBot
            // 
            this.btnUpdateBot.Location = new System.Drawing.Point(106, 325);
            this.btnUpdateBot.Name = "btnUpdateBot";
            this.btnUpdateBot.Size = new System.Drawing.Size(100, 50);
            this.btnUpdateBot.TabIndex = 27;
            this.btnUpdateBot.Text = "Update Bot";
            this.btnUpdateBot.UseVisualStyleBackColor = true;
            this.btnUpdateBot.Click += new System.EventHandler(this.btnUpdateBot_Click);
            // 
            // edtXPJumpD
            // 
            this.edtXPJumpD.Location = new System.Drawing.Point(110, 186);
            this.edtXPJumpD.Name = "edtXPJumpD";
            this.edtXPJumpD.Size = new System.Drawing.Size(100, 20);
            this.edtXPJumpD.TabIndex = 6;
            this.edtXPJumpD.Text = "900";
            // 
            // edtJumpD
            // 
            this.edtJumpD.Location = new System.Drawing.Point(110, 160);
            this.edtJumpD.Name = "edtJumpD";
            this.edtJumpD.Size = new System.Drawing.Size(100, 20);
            this.edtJumpD.TabIndex = 5;
            this.edtJumpD.Text = "900";
            // 
            // edtXPAtkD
            // 
            this.edtXPAtkD.Location = new System.Drawing.Point(110, 107);
            this.edtXPAtkD.Name = "edtXPAtkD";
            this.edtXPAtkD.Size = new System.Drawing.Size(100, 20);
            this.edtXPAtkD.TabIndex = 3;
            this.edtXPAtkD.Text = "50";
            // 
            // edtAtkD
            // 
            this.edtAtkD.Location = new System.Drawing.Point(110, 81);
            this.edtAtkD.Name = "edtAtkD";
            this.edtAtkD.Size = new System.Drawing.Size(100, 20);
            this.edtAtkD.TabIndex = 2;
            this.edtAtkD.Text = "400";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "XP Jump Delay";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Jump Delay";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "XP Attack Delay";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Attack Delay";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.Red;
            this.pnlStatus.Location = new System.Drawing.Point(8, 245);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(96, 50);
            this.pnlStatus.TabIndex = 18;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(110, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(96, 50);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop Bot";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(8, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(96, 50);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Bot";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbsMiner
            // 
            this.tbsMiner.Controls.Add(this.button1);
            this.tbsMiner.Controls.Add(this.edtUseItemDelay);
            this.tbsMiner.Controls.Add(this.label13);
            this.tbsMiner.Controls.Add(this.btnStopMiner);
            this.tbsMiner.Controls.Add(this.btnStartMiner);
            this.tbsMiner.Location = new System.Drawing.Point(4, 34);
            this.tbsMiner.Name = "tbsMiner";
            this.tbsMiner.Padding = new System.Windows.Forms.Padding(3);
            this.tbsMiner.Size = new System.Drawing.Size(549, 434);
            this.tbsMiner.TabIndex = 2;
            this.tbsMiner.Text = "Miner";
            this.tbsMiner.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 28;
            this.button1.Text = "Update Bot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // edtUseItemDelay
            // 
            this.edtUseItemDelay.Location = new System.Drawing.Point(98, 75);
            this.edtUseItemDelay.Name = "edtUseItemDelay";
            this.edtUseItemDelay.Size = new System.Drawing.Size(100, 20);
            this.edtUseItemDelay.TabIndex = 4;
            this.edtUseItemDelay.Text = "2000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Use Item Delay";
            // 
            // btnStopMiner
            // 
            this.btnStopMiner.Location = new System.Drawing.Point(110, 6);
            this.btnStopMiner.Name = "btnStopMiner";
            this.btnStopMiner.Size = new System.Drawing.Size(96, 50);
            this.btnStopMiner.TabIndex = 1;
            this.btnStopMiner.Text = "Stop Miner";
            this.btnStopMiner.UseVisualStyleBackColor = true;
            this.btnStopMiner.Click += new System.EventHandler(this.btnStopMiner_Click);
            // 
            // btnStartMiner
            // 
            this.btnStartMiner.Location = new System.Drawing.Point(8, 6);
            this.btnStartMiner.Name = "btnStartMiner";
            this.btnStartMiner.Size = new System.Drawing.Size(96, 50);
            this.btnStartMiner.TabIndex = 0;
            this.btnStartMiner.Text = "Start Miner";
            this.btnStartMiner.UseVisualStyleBackColor = true;
            this.btnStartMiner.Click += new System.EventHandler(this.btnStartMiner_Click);
            // 
            // tbsLog
            // 
            this.tbsLog.Controls.Add(this.textBox1);
            this.tbsLog.Location = new System.Drawing.Point(4, 34);
            this.tbsLog.Name = "tbsLog";
            this.tbsLog.Padding = new System.Windows.Forms.Padding(3);
            this.tbsLog.Size = new System.Drawing.Size(549, 434);
            this.tbsLog.TabIndex = 3;
            this.tbsLog.Text = "Log";
            this.tbsLog.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(543, 428);
            this.textBox1.TabIndex = 4;
            // 
            // tbsConfig
            // 
            this.tbsConfig.Controls.Add(this.txtAuthPort);
            this.tbsConfig.Controls.Add(this.txtAuthIP);
            this.tbsConfig.Controls.Add(this.txtGamePort);
            this.tbsConfig.Controls.Add(this.txtGameIp);
            this.tbsConfig.Controls.Add(this.label7);
            this.tbsConfig.Controls.Add(this.label6);
            this.tbsConfig.Controls.Add(this.label5);
            this.tbsConfig.Controls.Add(this.label4);
            this.tbsConfig.Controls.Add(this.chkSniff);
            this.tbsConfig.Controls.Add(this.txtLogPath);
            this.tbsConfig.Controls.Add(this.label3);
            this.tbsConfig.Controls.Add(this.label1);
            this.tbsConfig.Controls.Add(this.txtDir);
            this.tbsConfig.Location = new System.Drawing.Point(4, 34);
            this.tbsConfig.Name = "tbsConfig";
            this.tbsConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tbsConfig.Size = new System.Drawing.Size(549, 434);
            this.tbsConfig.TabIndex = 4;
            this.tbsConfig.Text = "Config";
            this.tbsConfig.UseVisualStyleBackColor = true;
            // 
            // txtAuthPort
            // 
            this.txtAuthPort.Location = new System.Drawing.Point(323, 91);
            this.txtAuthPort.Name = "txtAuthPort";
            this.txtAuthPort.Size = new System.Drawing.Size(67, 20);
            this.txtAuthPort.TabIndex = 5;
            this.txtAuthPort.Text = "9958";
            // 
            // txtAuthIP
            // 
            this.txtAuthIP.Location = new System.Drawing.Point(93, 91);
            this.txtAuthIP.Name = "txtAuthIP";
            this.txtAuthIP.Size = new System.Drawing.Size(195, 20);
            this.txtAuthIP.TabIndex = 4;
            this.txtAuthIP.Text = "187.17.71.196";
            // 
            // txtGamePort
            // 
            this.txtGamePort.Location = new System.Drawing.Point(323, 65);
            this.txtGamePort.Name = "txtGamePort";
            this.txtGamePort.Size = new System.Drawing.Size(67, 20);
            this.txtGamePort.TabIndex = 3;
            this.txtGamePort.Text = "5816";
            // 
            // txtGameIp
            // 
            this.txtGameIp.Location = new System.Drawing.Point(93, 65);
            this.txtGameIp.Name = "txtGameIp";
            this.txtGameIp.Size = new System.Drawing.Size(195, 20);
            this.txtGameIp.TabIndex = 2;
            this.txtGameIp.Text = "187.17.71.206";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "AuthServer IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "GameServer IP";
            // 
            // chkSniff
            // 
            this.chkSniff.AutoSize = true;
            this.chkSniff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSniff.Location = new System.Drawing.Point(93, 117);
            this.chkSniff.Name = "chkSniff";
            this.chkSniff.Size = new System.Drawing.Size(93, 29);
            this.chkSniff.TabIndex = 6;
            this.chkSniff.Text = "Sniffer";
            this.chkSniff.UseVisualStyleBackColor = true;
            this.chkSniff.CheckedChanged += new System.EventHandler(this.chkSniff_CheckedChanged);
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(94, 39);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(447, 20);
            this.txtLogPath.TabIndex = 1;
            this.txtLogPath.Text = "D:\\Log\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Log Folder";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Conquer Folder";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(94, 12);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(447, 20);
            this.txtDir.TabIndex = 0;
            this.txtDir.Text = "D:\\Instalacao\\Conquest\\";
            // 
            // tbsCommand
            // 
            this.tbsCommand.Location = new System.Drawing.Point(4, 34);
            this.tbsCommand.Name = "tbsCommand";
            this.tbsCommand.Padding = new System.Windows.Forms.Padding(3);
            this.tbsCommand.Size = new System.Drawing.Size(549, 434);
            this.tbsCommand.TabIndex = 5;
            this.tbsCommand.Text = "Command";
            this.tbsCommand.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Current Character";
            // 
            // cbxChar
            // 
            this.cbxChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChar.FormattingEnabled = true;
            this.cbxChar.Location = new System.Drawing.Point(295, 29);
            this.cbxChar.Name = "cbxChar";
            this.cbxChar.Size = new System.Drawing.Size(169, 21);
            this.cbxChar.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(470, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(83, 53);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 543);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbxChar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnStopProxy);
            this.Controls.Add(this.btnStartProxy);
            this.Name = "frmMain";
            this.Text = "Editor de Imagens Avançado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tbsBot.ResumeLayout(false);
            this.tbsBot.PerformLayout();
            this.tbsMiner.ResumeLayout(false);
            this.tbsMiner.PerformLayout();
            this.tbsLog.ResumeLayout(false);
            this.tbsLog.PerformLayout();
            this.tbsConfig.ResumeLayout(false);
            this.tbsConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartProxy;
        private System.Windows.Forms.Button btnStopProxy;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbsBot;
        private System.Windows.Forms.TabPage tbsMiner;
        private System.Windows.Forms.TabPage tbsLog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tbsConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.TabPage tbsCommand;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStopMiner;
        private System.Windows.Forms.Button btnStartMiner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxChar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.CheckBox chkSniff;
        private System.Windows.Forms.TextBox txtAuthPort;
        private System.Windows.Forms.TextBox txtAuthIP;
        private System.Windows.Forms.TextBox txtGamePort;
        private System.Windows.Forms.TextBox txtGameIp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtXPJumpD;
        private System.Windows.Forms.TextBox edtJumpD;
        private System.Windows.Forms.TextBox edtXPAtkD;
        private System.Windows.Forms.TextBox edtAtkD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUpdateBot;
        private System.Windows.Forms.TextBox edtMaxAtkWait;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox edtUseItemDelay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox edtMob;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkPlus;
        private System.Windows.Forms.Button btnUseItem;
        private System.Windows.Forms.TextBox edtItemID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCompraItem;
        private System.Windows.Forms.TextBox edtCompraItemID;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox edtNPCY;
        private System.Windows.Forms.TextBox edtNPCX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnMoverPara;
        private System.Windows.Forms.CheckBox chkPickItens;
        private System.Windows.Forms.TextBox edtPickFilter;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox edtPickQ;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chkScatter;
        private System.Windows.Forms.CheckBox chkNinjaFast;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox edtPotionHP;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox chkMoveMouse;
    }
}

