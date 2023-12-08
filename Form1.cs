using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AlSeerGui
{
    public partial class Form1 : Form
    {
        CanManager canManager;
        bool isRunning = false;
        byte[] _data_FF34_local;
        byte[] _data_FF50_local;
        byte[] _data_FF52_local;
        byte[] _data_test_local;
        bool is_DisplayingLogMessages = false;
        bool is_TX_CAN_ON = true;
        bool ir_RX_CAN_ON = true;
        bool is_HEXformat = true;
        private  Queue<string> _queueMessages;
        const  int _maxSize=100;
        bool allowFF34 = false;
        bool allowFF50 = false;
        bool allowFF51 = false;
        int _cntSendIndex = 0;
        delegate void ProcessMessageDelegate();
        private ProcessMessageDelegate[] messageProcessors;
        public Form1()
        {
            InitializeComponent();
            
            canManager = new CanManager();
            canManager.ListChannels();
            canManager.OpenChannel(0);
            canManager.SetBusParams();
            canManager.GoOnBus();
            _queueMessages = new Queue<string>(_maxSize);
            // canManager.SendTestCan();
            messageProcessors = new ProcessMessageDelegate[] { Process_FF34, Process_FF50, Process_FF51 };

            _data_FF34_local = new byte[8];
            _data_FF50_local = new byte[8];
            _data_FF52_local = new byte[8];
            _data_test_local = new byte[8];


            timer_runCanSend.Interval = 500;
            timer_runCanSend.Tick += new EventHandler(TICK_SEND_TIMER);

            timer_runCanReceive.Interval = 100;
            timer_runCanReceive.Tick += new EventHandler(timer_runCanReceive_Tick);

            timer_Loop.Interval = 200;
            timer_Loop.Tick += new EventHandler(LOOPTICK);

            btn_Start.Click += new EventHandler(btn_Start_Click);
            btn_Stop.Click += new EventHandler(btn_Stop_Click);
            btn_clearDisplay.Click += new EventHandler(btn_clearDisplay_Click);
            checkBox_stopTXCAN.CheckedChanged += new EventHandler(checkBox_stopSendCan_CheckedChanged);
            checkBox_stopRX.CheckedChanged += new EventHandler(checkBox_stopRX_CheckedChanged);
            checkBox_DisplayReceivedCAN.CheckedChanged += new EventHandler(checkBox_DisplayReceivedCAN_CheckedChanged);
            checkBox_DisplayReceivedCAN.Checked = true;
            is_DisplayingLogMessages = true;

            checkBox_formatDecimal.Checked = true;
            checkBox_formatDecimal.Text = "Hex";
            is_HEXformat = true;
            checkBox_formatDecimal.CheckedChanged += new EventHandler(checkBox_formatDecimal_CheckedChanged);

            cb_Send_ff34.CheckedChanged += new EventHandler(cb_Send_ff34_CheckedChanged);
            cb_Send_ff50.CheckedChanged += new EventHandler(cb_Send_ff50_CheckedChanged);
            cb_Send_ff51.CheckedChanged += new EventHandler(cb_Send_ff51_CheckedChanged);
        }

        #region StartStopDispReceive

        void btn_Start_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                timer_runCanSend.Start();
            }
        }
        void btn_Stop_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                isRunning = false;
                timer_runCanSend.Stop();
            }
        }
        void checkBox_stopRX_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_stopRX.Checked)
            {
                ir_RX_CAN_ON = false;
            }
            else
            {
                ir_RX_CAN_ON = true;
            }
        }
        void checkBox_DisplayReceivedCAN_CheckedChanged(object sender, EventArgs e)
        {
            is_DisplayingLogMessages= checkBox_DisplayReceivedCAN.Checked;
   
        }
        void checkBox_formatDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_formatDecimal.Checked)
            {
                checkBox_formatDecimal.Text = "Hex";
                is_HEXformat = true;
            }
            else
            {
                checkBox_formatDecimal.Text = "Decimal";
                is_HEXformat = false;
            }
        }
        void checkBox_stopSendCan_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_stopTXCAN.Checked)
            {
                is_TX_CAN_ON = false;
            }
            else
            {
                is_TX_CAN_ON = true;
            }
        }

        #endregion

        void cb_Send_ff34_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Send_ff34.Checked)
            {
                allowFF34 = true;
            }
            else
            {
                allowFF34 = false;
            }
        }
        void cb_Send_ff50_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Send_ff50.Checked)
            {
                allowFF50 = true;
            }
            else
            {
                allowFF50 = false;
            }
        }
        void cb_Send_ff51_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Send_ff51.Checked)
            {
                allowFF51 = true;
            }
            else
            {
                allowFF51 = false;
            }
        }

 
        void btn_clearDisplay_Click(object sender, EventArgs e)
        {
            _queueMessages.Clear();
            UpdateDisplay();
        }

        private void EnqueueMessage(string message)
        {
            if(message.Length<8)return;
            if (_queueMessages.Count == _maxSize)
            {
                _queueMessages.Dequeue(); // Remove the oldest message
            }
            _queueMessages.Enqueue(message);

            
        }



        void LOOPTICK(object sender, EventArgs e)
        {
         
        }

        string canReceive()
        {
            return canManager.ReceiveMessageVALSEER(is_HEXformat);

        }

        void TICK_SEND_TIMER(object sender, EventArgs e)
        {
            if (ir_RX_CAN_ON) {
                string receivedMessage = "[RX] " + canReceive();
                EnqueueMessage(receivedMessage);
            }


            canSend();
            if (is_DisplayingLogMessages)
            {
                UpdateDisplay();
            }

        }
        void canSend()
        {
            const int maxIndex = 2; // Maximum index value
            bool messageSent = false;

            for (int i = 0; i <= maxIndex; i++)
            {
                _cntSendIndex++;
                if (_cntSendIndex > maxIndex) _cntSendIndex = 0;

                if ((_cntSendIndex == 0 && allowFF34) ||
                    (_cntSendIndex == 1 && allowFF50) ||
                    (_cntSendIndex == 2 && allowFF51))
                {
                    if (is_TX_CAN_ON)
                    {
                        sendMessageByIndex(_cntSendIndex);
                        messageSent = true;
                        break;
                    }
                }
            }

            if (!messageSent && is_TX_CAN_ON)
            {
                // Handle the case where no message was sent due to all types being disallowed
                // For example, you might want to log a message or perform some other action
            }
        }

   

        void sendMessageByIndex( int argindex) {

            if (!allowFF34 && !allowFF50 && !allowFF51) return;

            if (argindex >= messageProcessors.Length) argindex = 0;

            // Execute the delegate at the specified index
            messageProcessors[argindex]?.Invoke();

 
        }

        void Process_FF34() {
            canManager.SendMessage(uC_PGN_FF34_Clu.GET_PGN(), uC_PGN_FF34_Clu.GET_Data());
            CreateMessageAndLogIt(uC_PGN_FF34_Clu.GET_PGN(), uC_PGN_FF34_Clu.GET_Data());
        }
        void Process_FF50()
        {
            canManager.SendMessage(uC_PGN_FF50_hlm.GET_PGN(), uC_PGN_FF50_hlm.GET_Data());
            CreateMessageAndLogIt(uC_PGN_FF50_hlm.GET_PGN(), uC_PGN_FF50_hlm.GET_Data());
        }
        void Process_FF51()
        {
            canManager.SendMessage(uC_PGN_FF51_Lev.GET_PGN(), uC_PGN_FF51_Lev.GET_Data());
            CreateMessageAndLogIt(uC_PGN_FF51_Lev.GET_PGN(), uC_PGN_FF51_Lev.GET_Data());
        }
        string CreateMessageAndLogIt(int pgn, byte[] data)
        {

            string logMessage = " TX  ";
            string strpgn = "";
            if (is_HEXformat)
                strpgn = pgn.ToString("X8");
            else
                strpgn = pgn.ToString("D9");

            logMessage += strpgn;
            logMessage += " ";
            for (int i = 0; i < data.Length; i++)
            {
                if (is_HEXformat)
                    logMessage += data[i].ToString("X2") + " ";
                else
                    logMessage += data[i].ToString("D3") + " ";
            }
            EnqueueMessage(logMessage);
            return logMessage;
        }

         
        void timer_runCanReceive_Tick(object sender, EventArgs e)
        {
           
         

        }
  
        private void UpdateDisplay()
        {
            textBox_LogDisplay.Invoke((MethodInvoker)delegate {
                textBox_LogDisplay.Text = string.Join(Environment.NewLine, _queueMessages.ToArray());
                textBox_LogDisplay.SelectionStart = textBox_LogDisplay.Text.Length;
                textBox_LogDisplay.ScrollToCaret();
            });
        }
    }
}
/*
 * 
 *     
 
        canManager.SendMessage(uC_PGN_FF51_Lev.GET_PGN(), uC_PGN_FF51_Lev.GET_Data());
            LogMessage(uC_PGN_FF51_Lev.GET_PGN(), uC_PGN_FF51_Lev.GET_Data(),false);
              canManager.SendMessage(uC_PGN_FF34_Clu.GET_PGN(), uC_PGN_FF34_Clu.GET_Data());
            LogMessage(uC_PGN_FF34_Clu.GET_PGN(), uC_PGN_FF34_Clu.GET_Data(), false);
            canManager.SendMessage(uC_PGN_FF50_hlm.GET_PGN(), uC_PGN_FF50_hlm.GET_Data());
            LogMessage(uC_PGN_FF50_hlm.GET_PGN(), uC_PGN_FF50_hlm.GET_Data(), false);
 */