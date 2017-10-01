using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        bool isTypingNumber = false;

        enum Pheptoan { None, Cong, Tru, Nhan, Chia };
        Pheptoan pheptoan;

        double nho;

        private void Nhapso(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Nhapso(btn.Text);
        }

        private void Nhapso(string so)
        {
            if (isTypingNumber)
            {
                if (lblDisplay.Text == "0")
                    lblDisplay.Text = "";

                lblDisplay.Text += so;
            }
            else
            {
                lblDisplay.Text = so;
                isTypingNumber = true;
            }
        }
        private void Nhappheptoan(object sender, EventArgs e)
        {
            if(nho!=0)
            Tinhketqua();

            Button btn = (Button)sender;
           switch(btn.Text)
            {
                case "+": pheptoan = Pheptoan.Cong; break;
                case "-": pheptoan = Pheptoan.Tru; break;
                case "*": pheptoan = Pheptoan.Nhan; break;
                case "/": pheptoan = Pheptoan.Chia; break;
            }
            nho = double.Parse(lblDisplay.Text);

            isTypingNumber = false;
        }

        private void Tinhketqua()
        {
            // tinh toan dua tren: nho, pheptoan, lblDisplay.Text
            double tam = double.Parse(lblDisplay.Text);
            double ketqua = 0.0;
            switch(pheptoan)
            {
                case Pheptoan.Cong: ketqua = nho + tam; break;
                case Pheptoan.Tru: ketqua = nho - tam; break;
                case Pheptoan.Nhan: ketqua = nho * tam; break;
                case Pheptoan.Chia: ketqua = nho / tam; break;
            }

            // gan ket qua tinh duoc len lblDisplay
            lblDisplay.Text = ketqua.ToString();
        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            Tinhketqua();
            isTypingNumber = false;
            nho = 0;
            pheptoan = Pheptoan.None;
        }

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    Nhapso("" + e.KeyChar);
                    break;
                case '+': btnCong.PerformClick(); break;

                case '-':
                   btnTru.PerformClick(); break;
                case '*': btnNhan.PerformClick(); break;
                case '/': btnChia.PerformClick(); break;
                case '=': btnBang.PerformClick(); break;
                default: break;
            }
        }
         private void btncan_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (Math.Sqrt(Double.Parse(lblDisplay.Text))).ToString();
        }

        private void btndoidau_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (-1 * (double.Parse(lblDisplay.Text))).ToString();
        }

        private void btnphantram_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = ((double.Parse(lblDisplay.Text) / 100)).ToString();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "")
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            if (lblDisplay.Text == "")
                lblDisplay.Text = "0";
        }
        private void btnNho_Click(object sender, EventArgs e)
        {
            nho = 0;
            lblDisplay.Text = "0";
        }
         private void btnCham_Click(object sender, EventArgs e)
        {
              if (lblDisplay.Text.Contains("."))
            {
                if (lblDisplay.Text== "0.")
                {
                    lblDisplay.Text = "";
                    Nhapso("0.");
                }
                return;
            }
            lblDisplay.Text += ".";  
        }
      }
    }





            