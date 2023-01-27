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
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
  
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange600, Primary.Orange600, Primary.Orange400, Accent.Indigo400, TextShade.WHITE);
        }
        OleDbConnection baglantim = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb");
        bool durum = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Giriş Yapın";
           // this.AcceptButton = zeroitLollipopButton1;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
        
        private void zeroitLollipopButton1_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from Users", baglantim);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                if (kayitokuma["User_name"].ToString() == zeroitLollipopTextBox1.Text && kayitokuma["User_password"].ToString() == zeroitLollipopTextBox2.Text) 
                {
                    durum = true;
                    this.Hide();
                    Form2 frm2 = new Form2();
                    frm2.Show();
                    break;
                    
                }
              
            }
            if (durum == false)
            {
                baglantim.Close();
                MessageBox.Show("Kullanıcı Adı ve ya Şifrenizi Yanlış Girdiniz.", "Kargo2go", MessageBoxButtons.OKCancel);
            }


            baglantim.Close();
        }

        private void zeroitLollipopButton2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.Show();
        }
    }
}
