namespace MyProxy
{
    partial class PrincipalForm
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
            this.btnIniciaProxy = new System.Windows.Forms.Button();
            this.btnPararProxy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiretorioJogo = new System.Windows.Forms.TextBox();
            this.txtIPServidorLogin = new System.Windows.Forms.TextBox();
            this.txtIPServidorJogo = new System.Windows.Forms.TextBox();
            this.txtPortaServidorLogin = new System.Windows.Forms.TextBox();
            this.txtPortaServidorJogo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpCharLogados = new System.Windows.Forms.GroupBox();
            this.lstCharLogados = new System.Windows.Forms.ListBox();
            this.btnControleChar = new System.Windows.Forms.Button();
            this.grpCharLogados.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIniciaProxy
            // 
            this.btnIniciaProxy.Location = new System.Drawing.Point(12, 12);
            this.btnIniciaProxy.Name = "btnIniciaProxy";
            this.btnIniciaProxy.Size = new System.Drawing.Size(131, 59);
            this.btnIniciaProxy.TabIndex = 0;
            this.btnIniciaProxy.Text = "Iniciar Proxy";
            this.btnIniciaProxy.UseVisualStyleBackColor = true;
            this.btnIniciaProxy.Click += new System.EventHandler(this.btnIniciaProxy_Click);
            // 
            // btnPararProxy
            // 
            this.btnPararProxy.Location = new System.Drawing.Point(149, 12);
            this.btnPararProxy.Name = "btnPararProxy";
            this.btnPararProxy.Size = new System.Drawing.Size(131, 59);
            this.btnPararProxy.TabIndex = 1;
            this.btnPararProxy.Text = "Para Proxy";
            this.btnPararProxy.UseVisualStyleBackColor = true;
            this.btnPararProxy.Click += new System.EventHandler(this.btnPararProxy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Diretório Conquest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP Servidor Jogo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP Servidor Login";
            // 
            // txtDiretorioJogo
            // 
            this.txtDiretorioJogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiretorioJogo.Location = new System.Drawing.Point(112, 87);
            this.txtDiretorioJogo.Name = "txtDiretorioJogo";
            this.txtDiretorioJogo.Size = new System.Drawing.Size(316, 20);
            this.txtDiretorioJogo.TabIndex = 5;
            this.txtDiretorioJogo.Text = "D:\\Instalacao\\Conquest\\";
            // 
            // txtIPServidorLogin
            // 
            this.txtIPServidorLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIPServidorLogin.Location = new System.Drawing.Point(112, 113);
            this.txtIPServidorLogin.Name = "txtIPServidorLogin";
            this.txtIPServidorLogin.Size = new System.Drawing.Size(316, 20);
            this.txtIPServidorLogin.TabIndex = 6;
            this.txtIPServidorLogin.Text = "187.17.71.196";
            // 
            // txtIPServidorJogo
            // 
            this.txtIPServidorJogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIPServidorJogo.Location = new System.Drawing.Point(112, 165);
            this.txtIPServidorJogo.Name = "txtIPServidorJogo";
            this.txtIPServidorJogo.Size = new System.Drawing.Size(316, 20);
            this.txtIPServidorJogo.TabIndex = 7;
            this.txtIPServidorJogo.Text = "187.17.71.206";
            // 
            // txtPortaServidorLogin
            // 
            this.txtPortaServidorLogin.Location = new System.Drawing.Point(112, 139);
            this.txtPortaServidorLogin.Name = "txtPortaServidorLogin";
            this.txtPortaServidorLogin.Size = new System.Drawing.Size(100, 20);
            this.txtPortaServidorLogin.TabIndex = 8;
            this.txtPortaServidorLogin.Text = "9958";
            this.txtPortaServidorLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPortaServidorJogo
            // 
            this.txtPortaServidorJogo.Location = new System.Drawing.Point(112, 191);
            this.txtPortaServidorJogo.Name = "txtPortaServidorJogo";
            this.txtPortaServidorJogo.Size = new System.Drawing.Size(100, 20);
            this.txtPortaServidorJogo.TabIndex = 9;
            this.txtPortaServidorJogo.Text = "5816";
            this.txtPortaServidorJogo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Porta Servidor Login";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Porta Servidor Jogo";
            // 
            // grpCharLogados
            // 
            this.grpCharLogados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCharLogados.Controls.Add(this.btnControleChar);
            this.grpCharLogados.Controls.Add(this.lstCharLogados);
            this.grpCharLogados.Location = new System.Drawing.Point(6, 217);
            this.grpCharLogados.Name = "grpCharLogados";
            this.grpCharLogados.Size = new System.Drawing.Size(422, 252);
            this.grpCharLogados.TabIndex = 12;
            this.grpCharLogados.TabStop = false;
            this.grpCharLogados.Text = "Char Logados";
            // 
            // lstCharLogados
            // 
            this.lstCharLogados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCharLogados.FormattingEnabled = true;
            this.lstCharLogados.Location = new System.Drawing.Point(6, 19);
            this.lstCharLogados.Name = "lstCharLogados";
            this.lstCharLogados.Size = new System.Drawing.Size(410, 173);
            this.lstCharLogados.TabIndex = 0;
            // 
            // btnControleChar
            // 
            this.btnControleChar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControleChar.Location = new System.Drawing.Point(6, 198);
            this.btnControleChar.Name = "btnControleChar";
            this.btnControleChar.Size = new System.Drawing.Size(410, 47);
            this.btnControleChar.TabIndex = 1;
            this.btnControleChar.Text = "Controlar o Char";
            this.btnControleChar.UseVisualStyleBackColor = true;
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 472);
            this.Controls.Add(this.grpCharLogados);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPortaServidorJogo);
            this.Controls.Add(this.txtPortaServidorLogin);
            this.Controls.Add(this.txtIPServidorJogo);
            this.Controls.Add(this.txtIPServidorLogin);
            this.Controls.Add(this.txtDiretorioJogo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPararProxy);
            this.Controls.Add(this.btnIniciaProxy);
            this.Name = "PrincipalForm";
            this.Text = "PrincipalForm";
            this.grpCharLogados.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciaProxy;
        private System.Windows.Forms.Button btnPararProxy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiretorioJogo;
        private System.Windows.Forms.TextBox txtIPServidorLogin;
        private System.Windows.Forms.TextBox txtIPServidorJogo;
        private System.Windows.Forms.TextBox txtPortaServidorLogin;
        private System.Windows.Forms.TextBox txtPortaServidorJogo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpCharLogados;
        private System.Windows.Forms.Button btnControleChar;
        private System.Windows.Forms.ListBox lstCharLogados;
    }
}