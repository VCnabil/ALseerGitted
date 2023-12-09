using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlSeerGui
{
    public partial class UC_8byteDataDisplayer : UserControl
    {
        bool isHExFormat = true;
        string _myTitle;
        byte[] localData;
        public UC_8byteDataDisplayer()
        {
            InitializeComponent();
            _myTitle = "";
            localData = new byte[8];
            localData[0] = 0x00;
            localData[1] = 0x00;
            localData[2] = 0x00;
            localData[3] = 0x00;
            localData[4] = 0x00;
            localData[5] = 0x00;
            localData[6] = 0x00;
            localData[7] = 0x00;

            lbl_B0.Text = localData[0].ToString();
            lbl_B1.Text = localData[1].ToString();
            lbl_B2.Text = localData[2].ToString();
            lbl_B3.Text = localData[3].ToString();
            lbl_B4.Text = localData[4].ToString();
            lbl_B5.Text = localData[5].ToString();
            lbl_B6.Text = localData[6].ToString();
            lbl_B7.Text = localData[7].ToString();
            checkBox1.Checked = false;
            checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
        }

        public void SetTitle(string title)
        {
            _myTitle = title;
            lbl_title.Text = title;
        }
        public void UpdateData(byte[] data)
        {
            localData = data;
            if (isHExFormat)
            {
                lbl_B0.Text = "0x" + localData[0].ToString("X2");
                lbl_B1.Text = "0x" + localData[1].ToString("X2");
                lbl_B2.Text = "0x" + localData[2].ToString("X2");
                lbl_B3.Text = "0x" + localData[3].ToString("X2");
                lbl_B4.Text = "0x" + localData[4].ToString("X2");
                lbl_B5.Text = "0x" + localData[5].ToString("X2");
                lbl_B6.Text = "0x" + localData[6].ToString("X2");
                lbl_B7.Text = "0x" + localData[7].ToString("X2");
            }
            else
            {
                lbl_B0.Text = localData[0].ToString("D3");
                lbl_B1.Text = localData[1].ToString("D3");
                lbl_B2.Text = localData[2].ToString("D3");
                lbl_B3.Text = localData[3].ToString("D3");
                lbl_B4.Text = localData[4].ToString("D3");
                lbl_B5.Text = localData[5].ToString("D3");
                lbl_B6.Text = localData[6].ToString("D3");
                lbl_B7.Text = localData[7].ToString("D3");
            }
        }
        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                isHExFormat=true;
            }
            else
            {
                isHExFormat=false;
            }
        }
    }
}
