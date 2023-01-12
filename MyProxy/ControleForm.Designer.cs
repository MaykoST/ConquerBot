namespace MyProxy
{
    partial class ControleForm
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
            this.pgcControle = new System.Windows.Forms.TabControl();
            this.tbsMatar = new System.Windows.Forms.TabPage();
            this.tbsJuntar = new System.Windows.Forms.TabPage();
            this.tbsMineiro = new System.Windows.Forms.TabPage();
            this.tbsAndar = new System.Windows.Forms.TabPage();
            this.lblCharName = new System.Windows.Forms.Label();
            this.tblBolsa = new System.Windows.Forms.TabPage();
            this.lblAcao = new System.Windows.Forms.Label();
            this.grpTempo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.grpEspecial = new System.Windows.Forms.GroupBox();
            this.chkNinjaRapido = new System.Windows.Forms.CheckBox();
            this.chkDifusao = new System.Windows.Forms.CheckBox();
            this.grpMonstro = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtFiltroMonstro = new System.Windows.Forms.TextBox();
            this.btnIniciarMatador = new System.Windows.Forms.Button();
            this.btnPararMatador = new System.Windows.Forms.Button();
            this.pgcControle.SuspendLayout();
            this.tbsMatar.SuspendLayout();
            this.grpTempo.SuspendLayout();
            this.grpEspecial.SuspendLayout();
            this.grpMonstro.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgcControle
            // 
            this.pgcControle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgcControle.Controls.Add(this.tbsMatar);
            this.pgcControle.Controls.Add(this.tbsJuntar);
            this.pgcControle.Controls.Add(this.tbsMineiro);
            this.pgcControle.Controls.Add(this.tbsAndar);
            this.pgcControle.Controls.Add(this.tblBolsa);
            this.pgcControle.ItemSize = new System.Drawing.Size(42, 18);
            this.pgcControle.Location = new System.Drawing.Point(2, 46);
            this.pgcControle.Name = "pgcControle";
            this.pgcControle.SelectedIndex = 0;
            this.pgcControle.Size = new System.Drawing.Size(689, 440);
            this.pgcControle.TabIndex = 0;
            // 
            // tbsMatar
            // 
            this.tbsMatar.Controls.Add(this.btnPararMatador);
            this.tbsMatar.Controls.Add(this.btnIniciarMatador);
            this.tbsMatar.Controls.Add(this.grpMonstro);
            this.tbsMatar.Controls.Add(this.grpEspecial);
            this.tbsMatar.Controls.Add(this.grpTempo);
            this.tbsMatar.Location = new System.Drawing.Point(4, 22);
            this.tbsMatar.Name = "tbsMatar";
            this.tbsMatar.Padding = new System.Windows.Forms.Padding(3);
            this.tbsMatar.Size = new System.Drawing.Size(681, 414);
            this.tbsMatar.TabIndex = 0;
            this.tbsMatar.Text = "Matar";
            this.tbsMatar.UseVisualStyleBackColor = true;
            // 
            // tbsJuntar
            // 
            this.tbsJuntar.Location = new System.Drawing.Point(4, 22);
            this.tbsJuntar.Name = "tbsJuntar";
            this.tbsJuntar.Padding = new System.Windows.Forms.Padding(3);
            this.tbsJuntar.Size = new System.Drawing.Size(677, 413);
            this.tbsJuntar.TabIndex = 1;
            this.tbsJuntar.Text = "Juntar";
            this.tbsJuntar.UseVisualStyleBackColor = true;
            // 
            // tbsMineiro
            // 
            this.tbsMineiro.Location = new System.Drawing.Point(4, 22);
            this.tbsMineiro.Name = "tbsMineiro";
            this.tbsMineiro.Padding = new System.Windows.Forms.Padding(3);
            this.tbsMineiro.Size = new System.Drawing.Size(677, 413);
            this.tbsMineiro.TabIndex = 2;
            this.tbsMineiro.Text = "Mineirar";
            this.tbsMineiro.UseVisualStyleBackColor = true;
            // 
            // tbsAndar
            // 
            this.tbsAndar.Location = new System.Drawing.Point(4, 22);
            this.tbsAndar.Name = "tbsAndar";
            this.tbsAndar.Padding = new System.Windows.Forms.Padding(3);
            this.tbsAndar.Size = new System.Drawing.Size(677, 413);
            this.tbsAndar.TabIndex = 3;
            this.tbsAndar.Text = "Andar";
            this.tbsAndar.UseVisualStyleBackColor = true;
            // 
            // lblCharName
            // 
            this.lblCharName.AutoSize = true;
            this.lblCharName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharName.Location = new System.Drawing.Point(12, 9);
            this.lblCharName.Name = "lblCharName";
            this.lblCharName.Size = new System.Drawing.Size(193, 24);
            this.lblCharName.TabIndex = 1;
            this.lblCharName.Text = "[NOME_DO_CHAR]";
            this.lblCharName.Click += new System.EventHandler(this.lblCharName_Click);
            // 
            // tblBolsa
            // 
            this.tblBolsa.Location = new System.Drawing.Point(4, 22);
            this.tblBolsa.Name = "tblBolsa";
            this.tblBolsa.Padding = new System.Windows.Forms.Padding(3);
            this.tblBolsa.Size = new System.Drawing.Size(677, 413);
            this.tblBolsa.TabIndex = 4;
            this.tblBolsa.Text = "Bolsa";
            this.tblBolsa.UseVisualStyleBackColor = true;
            // 
            // lblAcao
            // 
            this.lblAcao.AutoSize = true;
            this.lblAcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcao.Location = new System.Drawing.Point(250, 9);
            this.lblAcao.Name = "lblAcao";
            this.lblAcao.Size = new System.Drawing.Size(155, 24);
            this.lblAcao.TabIndex = 2;
            this.lblAcao.Text = "[BOT PARADO]";
            // 
            // grpTempo
            // 
            this.grpTempo.Controls.Add(this.textBox4);
            this.grpTempo.Controls.Add(this.textBox3);
            this.grpTempo.Controls.Add(this.textBox2);
            this.grpTempo.Controls.Add(this.textBox1);
            this.grpTempo.Controls.Add(this.label4);
            this.grpTempo.Controls.Add(this.label1);
            this.grpTempo.Controls.Add(this.label3);
            this.grpTempo.Controls.Add(this.label2);
            this.grpTempo.Location = new System.Drawing.Point(10, 6);
            this.grpTempo.Name = "grpTempo";
            this.grpTempo.Size = new System.Drawing.Size(216, 132);
            this.grpTempo.TabIndex = 3;
            this.grpTempo.TabStop = false;
            this.grpTempo.Text = "Atraso (ms)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ataque Normal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ataque XP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pulo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pulo XP";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "400";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(89, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "50";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(89, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "800";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(89, 97);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 9;
            this.textBox4.Text = "800";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpEspecial
            // 
            this.grpEspecial.Controls.Add(this.chkDifusao);
            this.grpEspecial.Controls.Add(this.chkNinjaRapido);
            this.grpEspecial.Location = new System.Drawing.Point(232, 6);
            this.grpEspecial.Name = "grpEspecial";
            this.grpEspecial.Size = new System.Drawing.Size(208, 132);
            this.grpEspecial.TabIndex = 4;
            this.grpEspecial.TabStop = false;
            this.grpEspecial.Text = "Especial";
            // 
            // chkNinjaRapido
            // 
            this.chkNinjaRapido.AutoSize = true;
            this.chkNinjaRapido.Location = new System.Drawing.Point(6, 22);
            this.chkNinjaRapido.Name = "chkNinjaRapido";
            this.chkNinjaRapido.Size = new System.Drawing.Size(164, 17);
            this.chkNinjaRapido.TabIndex = 0;
            this.chkNinjaRapido.Text = "Ninja Super Rapido (Instavel)";
            this.chkNinjaRapido.UseVisualStyleBackColor = true;
            // 
            // chkDifusao
            // 
            this.chkDifusao.AutoSize = true;
            this.chkDifusao.Location = new System.Drawing.Point(6, 48);
            this.chkDifusao.Name = "chkDifusao";
            this.chkDifusao.Size = new System.Drawing.Size(135, 17);
            this.chkDifusao.TabIndex = 1;
            this.chkDifusao.Text = "Usar Difusão (Archeiro)";
            this.chkDifusao.UseVisualStyleBackColor = true;
            // 
            // grpMonstro
            // 
            this.grpMonstro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMonstro.Controls.Add(this.edtFiltroMonstro);
            this.grpMonstro.Controls.Add(this.label5);
            this.grpMonstro.Location = new System.Drawing.Point(10, 144);
            this.grpMonstro.Name = "grpMonstro";
            this.grpMonstro.Size = new System.Drawing.Size(665, 68);
            this.grpMonstro.TabIndex = 5;
            this.grpMonstro.TabStop = false;
            this.grpMonstro.Text = "Monstros";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nome (Separado por vírgulas)";
            // 
            // edtFiltroMonstro
            // 
            this.edtFiltroMonstro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFiltroMonstro.Location = new System.Drawing.Point(9, 32);
            this.edtFiltroMonstro.Name = "edtFiltroMonstro";
            this.edtFiltroMonstro.Size = new System.Drawing.Size(646, 20);
            this.edtFiltroMonstro.TabIndex = 1;
            // 
            // btnIniciarMatador
            // 
            this.btnIniciarMatador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIniciarMatador.Location = new System.Drawing.Point(10, 335);
            this.btnIniciarMatador.Name = "btnIniciarMatador";
            this.btnIniciarMatador.Size = new System.Drawing.Size(138, 73);
            this.btnIniciarMatador.TabIndex = 6;
            this.btnIniciarMatador.Text = "Iniciar Matador";
            this.btnIniciarMatador.UseVisualStyleBackColor = true;
            // 
            // btnPararMatador
            // 
            this.btnPararMatador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPararMatador.Location = new System.Drawing.Point(154, 335);
            this.btnPararMatador.Name = "btnPararMatador";
            this.btnPararMatador.Size = new System.Drawing.Size(138, 73);
            this.btnPararMatador.TabIndex = 7;
            this.btnPararMatador.Text = "Parar Matador";
            this.btnPararMatador.UseVisualStyleBackColor = true;
            // 
            // ControleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 487);
            this.Controls.Add(this.lblAcao);
            this.Controls.Add(this.lblCharName);
            this.Controls.Add(this.pgcControle);
            this.Name = "ControleForm";
            this.Text = "Controle Remoto";
            this.pgcControle.ResumeLayout(false);
            this.tbsMatar.ResumeLayout(false);
            this.grpTempo.ResumeLayout(false);
            this.grpTempo.PerformLayout();
            this.grpEspecial.ResumeLayout(false);
            this.grpEspecial.PerformLayout();
            this.grpMonstro.ResumeLayout(false);
            this.grpMonstro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl pgcControle;
        private System.Windows.Forms.TabPage tbsMatar;
        private System.Windows.Forms.TabPage tbsJuntar;
        private System.Windows.Forms.TabPage tbsMineiro;
        private System.Windows.Forms.TabPage tbsAndar;
        private System.Windows.Forms.TabPage tblBolsa;
        private System.Windows.Forms.Label lblCharName;
        private System.Windows.Forms.GroupBox grpTempo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAcao;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpEspecial;
        private System.Windows.Forms.CheckBox chkDifusao;
        private System.Windows.Forms.CheckBox chkNinjaRapido;
        private System.Windows.Forms.GroupBox grpMonstro;
        private System.Windows.Forms.TextBox edtFiltroMonstro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPararMatador;
        private System.Windows.Forms.Button btnIniciarMatador;
    }
}