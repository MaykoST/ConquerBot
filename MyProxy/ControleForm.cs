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
    public partial class ControleForm : Form
    {
        public MyCharacter MyChar { get; set; }

        public ControleForm(MyCharacter pChar)
        {
            InitializeComponent();

            this.MyChar = pChar;
        }

        private void lblCharName_Click(object sender, EventArgs e)
        {

        }
    }
}
