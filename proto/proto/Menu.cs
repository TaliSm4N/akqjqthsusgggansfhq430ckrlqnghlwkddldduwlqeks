using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace proto
{

    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Form dlg = new Settiong_Form();

            this.Opacity = 0;
            dlg.ShowDialog();
            this.Opacity = 1;
        }

        private void End_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
