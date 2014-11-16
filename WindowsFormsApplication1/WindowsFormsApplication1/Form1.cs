using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string []address = new string [1];
        string[] check = new string[1];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //폴더경로 검색 후 지정
        {
            FolderBrowserDialog folderBrowse = new FolderBrowserDialog();

            if (folderBrowse.ShowDialog() == DialogResult.OK)
            {
                check[0]=textBox1.Text = folderBrowse.SelectedPath;
            }

        }

        private void Confirm(object sender, EventArgs e) //확인시 배열에 경로저장 (발전 필요)
        {
            address[0] = check[0]; //folderBrowse.SelectedPath;
        }
    }
}
