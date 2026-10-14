using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBoxOrnek_SecimSirasi
{
    public partial class Form1 : Form
    {
        // Kullanıcının tıklama sırasını kronolojik olarak tutan liste
        List<object> secimSirasi = new List<object>();

        public Form1()
        {
            InitializeComponent();

            // Tasarımda unutulma ihtimaline karşı olayı kod ile bağlıyoruz
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        // listBox1 üzerinde seçim her değiştiğinde (tıklandığında veya seçim kaldırıldığında) çalışır
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Yeni seçilen elemanları tıklama sırasına göre listeye ekle
            foreach (var item in listBox1.SelectedItems)
            {
                if (!secimSirasi.Contains(item))
                {
                    secimSirasi.Add(item);
                }
            }

            // seçimi iptal edilen elemanları hafıza listesinden çıkar
            for (int i = secimSirasi.Count - 1; i >= 0; i--)
            {
                if (!listBox1.SelectedItems.Contains(secimSirasi[i]))
                {
                    secimSirasi.RemoveAt(i);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // doğrudan SelectedItems yerine, kullanıcının gerçek tıklama sırasını aktar
            foreach (var eleman in secimSirasi)
            {
                listBox2.Items.Add(eleman);
            }

            secimSirasi.Clear();
            listBox1.ClearSelected();
        }
    }
}