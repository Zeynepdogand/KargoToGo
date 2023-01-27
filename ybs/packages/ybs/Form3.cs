using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ybs
{
    public partial class Form3 : MaterialForm
    {
        public Form3()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange600, Primary.Orange600, Primary.Orange400, Accent.Indigo400, TextShade.WHITE);
        }
        OleDbConnection baglantim = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb");


        private void Form3_Load(object sender, EventArgs e)
        {
          


        }

        private void zeroitLollipopButton1_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter eklekomutu = new OleDbDataAdapter("insert into Users (User_password,User_name) values ('" +
                zeroitLollipopTextBox4.Text + "','" + zeroitLollipopTextBox5.Text + "')", baglantim);
                DataSet Dshafiza = new DataSet();
                eklekomutu.Fill(Dshafiza);
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }
    }
}
