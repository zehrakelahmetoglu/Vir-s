using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Antivirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Bilgisayarda çalışan TÜM işlemleri alıyoruz
            Process[] tumSurecler = Process.GetProcesses();
            bool bulundumu = false;

            foreach (Process p in tumSurecler)
            {
                // 2. Virüsün adını burada kontrol et (Örn: SakaVirusu)
                // Kendi ismini (SakaSavunma) kapatmamak için kontrol ekliyoruz
                if (p.ProcessName == "Virüs")
                {
                    p.Kill(); // Sadece virüsü öldür
                    bulundumu = true;
                }
            }

            if (bulundumu)
    {
                MessageBox.Show("Virüs başarıyla imha edildi, klavye açıldı!");
            }
    else
            {
                MessageBox.Show("Virüs bulunamadı! Lütfen virüsün adının 'Virüs' olduğundan emin ol.");
            }
        }
    }
}
