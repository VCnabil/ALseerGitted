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
    public partial class Form1 : Form
    {
        CanManager canManager;

        public Form1()
        {
            InitializeComponent();
            canManager = new CanManager();
            canManager.ListChannels();
            canManager.OpenChannel(0);
            canManager.SetBusParams();
            canManager.GoOnBus();

            canManager.SendTestCan();
        }
    }
}
