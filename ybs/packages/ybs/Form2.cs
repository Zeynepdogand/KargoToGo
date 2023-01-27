using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
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
    public partial class Form2 : MaterialForm
    {
        public Form2()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange600, Primary.Orange600, Primary.Orange400, Accent.Indigo400, TextShade.WHITE);
        }
        OleDbConnection baglantim = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database2.accdb");

        private void kayitlariListele()
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("Select * from musteri", baglantim);
                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
        }
        private void subelerilistele()
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("Select * from sube_yonetim", baglantim);
                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridView2.DataSource = dshafiza.Tables[0];
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
        }
        private void TransferMerkezilistele()
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("Select * from transfermerkezi_yonetim", baglantim);
                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridView4.DataSource = dshafiza.Tables[0];
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
        }
        private void KonumlariGetir()
        {
            try
            {
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from sube_yonetim", baglantim);
                OleDbDataReader dr = selectsorgu.ExecuteReader();
                while (dr.Read())
                {
                    Btnlat.Text = Convert.ToString(dr["konumlat"]);
                    Btnlon.Text = Convert.ToString(dr["konumlon"]);
                    zeroitLollipopComboBox1.Items.Add(dr["Sube_adresi"]);
                   
                }
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
        }
        private void LojistikListele()
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("Select * from Araclar", baglantim);
                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridView3.DataSource = dshafiza.Tables[0];
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();

            }
        }
        private void zeroitLollipopComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zeroitLollipopComboBox1.Text == "Altınşehir/Bursa")
            { 
              Btnlat.Text = "40.22";
              Btnlon.Text = "28.92";
            }
            if (zeroitLollipopComboBox1.Text == "Görükle/Bursa")
            {
                Btnlat.Text = "40.23";
                Btnlon.Text = "28.84";
            }
            if (zeroitLollipopComboBox1.Text == "Kartal/İstanbul")
            {
                Btnlat.Text = "40.90437654";
                Btnlon.Text = "29.19280254";
            }
            if (zeroitLollipopComboBox1.Text == "İskenderun/Hatay")
            {
                Btnlat.Text = "36.57";
                Btnlon.Text = "36.16";
            }
            if (zeroitLollipopComboBox1.Text == "Adapazarı/Sakarya")
            {
                Btnlat.Text = "40.7496126";
                Btnlon.Text = "30.39256037";
            }
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            map.MinZoom = 5; // minimum zoom
            map.MaxZoom = 100; // maksimum zoom
             // default zoom  
            double Lat = Convert.ToDouble(Btnlat.Text);
            double Lon = Convert.ToDouble(Btnlon.Text);
            map.Position = new PointLatLng(Lat, Lon);
            PointLatLng nokta = new PointLatLng(Lat, Lon);
            GMapMarker marker = new GMarkerGoogle(nokta, GMarkerGoogleType.red_dot); // işaretçinin niteliğini belirleyen satır.

            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            map.Overlays.Add(markers);



            if (map.Overlays.Count > 1)
            {
                map.Overlays.RemoveAt(0);

            }



        }
        private void Form2_Load(object sender, EventArgs e)
        {
            kayitlariListele();
            TransferMerkezilistele();
            subelerilistele();
            KonumlariGetir();
            LojistikListele();

            // MAP

            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            map.MinZoom = 5; // minimum zoom
            map.MaxZoom = 100; // maksimum zoom
            // default zoom  
            Control.CheckForIllegalCrossThreadCalls = false;
        } 
     




        private void zeroitLollipopButton2_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter eklekomutu = new OleDbDataAdapter("insert into Araclar (AracKapasite) values ('"
                   + zeroitLollipopTextBox7.Text + "')", baglantim);
                DataSet Dshafiza = new DataSet();
                eklekomutu.Fill(Dshafiza);
                baglantim.Close();
                LojistikListele();
                
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();


            }
        }

        private void zeroitLollipopButton1_Click(object sender, EventArgs e)
        {
              try
            {
                baglantim.Open();
                OleDbDataAdapter eklekomutu = new OleDbDataAdapter("insert into musteri (Musteri_id,KullaniciAdi,Eposta,Faturasirasi) values ('" +
                zeroitLollipopTextBox2.Text + "','" + zeroitLollipopTextBox3.Text + "','" + zeroitLollipopTextBox4.Text + "', '" + zeroitLollipopTextBox5 + "')", baglantim);
                DataSet Dshafiza = new DataSet();
                eklekomutu.Fill(Dshafiza);
                baglantim.Close();
                kayitlariListele();
                
            }
            catch (Exception hatamsj)
           {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
        }

        private void zeroitLollipopButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter eklekomutu = new OleDbDataAdapter("insert into musteri (Musteri_id,KullaniciAdi,Eposta,Faturasirasi) values ('" +
                zeroitLollipopTextBox2.Text + "','" + zeroitLollipopTextBox3.Text + "','" + zeroitLollipopTextBox4.Text + "', '" + zeroitLollipopTextBox5 + "')", baglantim);
                DataSet Dshafiza = new DataSet();
                eklekomutu.Fill(Dshafiza);
                baglantim.Close();
                kayitlariListele();

            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
        }
    }
}
