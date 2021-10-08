using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamMCJ
{
    public partial class ChooseDB : Form
    {
        public ChooseDB()
        {
            InitializeComponent();
        }

        private void ButtonOracle_Click(object sender, EventArgs e)
        {
            //closes Login and open oDirectory
            Hide();
            OLogin login = new OLogin();
            login.ShowDialog();
            this.Close();
        }

        private void ButtonMongoDB_Click(object sender, EventArgs e)
        {
            //closes Login and open mDirectory
            Hide();
            MLogin login = new MLogin();
            login.ShowDialog();
            this.Close();
        }
    }
}
