using System;
using System.Windows.Forms;

namespace modul12_2311104053
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonHitung_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);

            int hasil = CariNilaiPangkat(a, b);
            labelHasil.Text = hasil.ToString();
        }

        public int CariNilaiPangkat(int a, int b)
        {
            if (b == 0) return 1;
            if (b < 0) return -1;
            if (b > 10 || a > 100) return -2;

            try
            {
                checked
                {
                    int result = 1;
                    for (int i = 0; i < b; i++)
                    {
                        result *= a;
                    }
                    return result;
                }
            }
            catch (OverflowException)
            {
                return -3;
            }
        }
    }
}
