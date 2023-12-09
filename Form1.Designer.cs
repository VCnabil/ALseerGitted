namespace AlSeerGui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.textBox_LogDisplay = new System.Windows.Forms.TextBox();
            this.checkBox_stopTXCAN = new System.Windows.Forms.CheckBox();
            this.checkBox_DisplayReceivedCAN = new System.Windows.Forms.CheckBox();
            this.btn_clearDisplay = new System.Windows.Forms.Button();
            this.timer_runCanSend = new System.Windows.Forms.Timer(this.components);
            this.timer_runCanReceive = new System.Windows.Forms.Timer(this.components);
            this.timer_Loop = new System.Windows.Forms.Timer(this.components);
            this.checkBox_formatDecimal = new System.Windows.Forms.CheckBox();
            this.cb_Send_ff50 = new System.Windows.Forms.CheckBox();
            this.cb_Send_ff51 = new System.Windows.Forms.CheckBox();
            this.cb_Send_ff34 = new System.Windows.Forms.CheckBox();
            this.checkBox_stopRX = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(30, 37);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(165, 55);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(30, 114);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(165, 55);
            this.btn_Stop.TabIndex = 4;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            // 
            // textBox_LogDisplay
            // 
            this.textBox_LogDisplay.Location = new System.Drawing.Point(30, 438);
            this.textBox_LogDisplay.Multiline = true;
            this.textBox_LogDisplay.Name = "textBox_LogDisplay";
            this.textBox_LogDisplay.ReadOnly = true;
            this.textBox_LogDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_LogDisplay.Size = new System.Drawing.Size(759, 743);
            this.textBox_LogDisplay.TabIndex = 5;
            this.textBox_LogDisplay.Text = "logger";
            // 
            // checkBox_stopTXCAN
            // 
            this.checkBox_stopTXCAN.AutoSize = true;
            this.checkBox_stopTXCAN.Location = new System.Drawing.Point(239, 378);
            this.checkBox_stopTXCAN.Name = "checkBox_stopTXCAN";
            this.checkBox_stopTXCAN.Size = new System.Drawing.Size(190, 33);
            this.checkBox_stopTXCAN.TabIndex = 6;
            this.checkBox_stopTXCAN.Text = "Stop TX CAN";
            this.checkBox_stopTXCAN.UseVisualStyleBackColor = true;
            // 
            // checkBox_DisplayReceivedCAN
            // 
            this.checkBox_DisplayReceivedCAN.AutoSize = true;
            this.checkBox_DisplayReceivedCAN.Location = new System.Drawing.Point(239, 37);
            this.checkBox_DisplayReceivedCAN.Name = "checkBox_DisplayReceivedCAN";
            this.checkBox_DisplayReceivedCAN.Size = new System.Drawing.Size(297, 33);
            this.checkBox_DisplayReceivedCAN.TabIndex = 7;
            this.checkBox_DisplayReceivedCAN.Text = "Display CAN Messages";
            this.checkBox_DisplayReceivedCAN.UseVisualStyleBackColor = true;
            // 
            // btn_clearDisplay
            // 
            this.btn_clearDisplay.Location = new System.Drawing.Point(30, 261);
            this.btn_clearDisplay.Name = "btn_clearDisplay";
            this.btn_clearDisplay.Size = new System.Drawing.Size(165, 55);
            this.btn_clearDisplay.TabIndex = 8;
            this.btn_clearDisplay.Text = "Clear Log";
            this.btn_clearDisplay.UseVisualStyleBackColor = true;
            // 
            // timer_Loop
            // 
            this.timer_Loop.Interval = 200;
            // 
            // checkBox_formatDecimal
            // 
            this.checkBox_formatDecimal.AutoSize = true;
            this.checkBox_formatDecimal.Location = new System.Drawing.Point(239, 76);
            this.checkBox_formatDecimal.Name = "checkBox_formatDecimal";
            this.checkBox_formatDecimal.Size = new System.Drawing.Size(87, 33);
            this.checkBox_formatDecimal.TabIndex = 9;
            this.checkBox_formatDecimal.Text = "Hex";
            this.checkBox_formatDecimal.UseVisualStyleBackColor = true;
            // 
            // cb_Send_ff50
            // 
            this.cb_Send_ff50.AutoSize = true;
            this.cb_Send_ff50.Location = new System.Drawing.Point(820, 36);
            this.cb_Send_ff50.Name = "cb_Send_ff50";
            this.cb_Send_ff50.Size = new System.Drawing.Size(101, 33);
            this.cb_Send_ff50.TabIndex = 10;
            this.cb_Send_ff50.Text = "FF50";
            this.cb_Send_ff50.UseVisualStyleBackColor = true;
            // 
            // cb_Send_ff51
            // 
            this.cb_Send_ff51.AutoSize = true;
            this.cb_Send_ff51.Location = new System.Drawing.Point(1589, 36);
            this.cb_Send_ff51.Name = "cb_Send_ff51";
            this.cb_Send_ff51.Size = new System.Drawing.Size(101, 33);
            this.cb_Send_ff51.TabIndex = 11;
            this.cb_Send_ff51.Text = "FF51";
            this.cb_Send_ff51.UseVisualStyleBackColor = true;
            // 
            // cb_Send_ff34
            // 
            this.cb_Send_ff34.AutoSize = true;
            this.cb_Send_ff34.Location = new System.Drawing.Point(820, 719);
            this.cb_Send_ff34.Name = "cb_Send_ff34";
            this.cb_Send_ff34.Size = new System.Drawing.Size(101, 33);
            this.cb_Send_ff34.TabIndex = 12;
            this.cb_Send_ff34.Text = "FF34";
            this.cb_Send_ff34.UseVisualStyleBackColor = true;
            // 
            // checkBox_stopRX
            // 
            this.checkBox_stopRX.AutoSize = true;
            this.checkBox_stopRX.Location = new System.Drawing.Point(30, 378);
            this.checkBox_stopRX.Name = "checkBox_stopRX";
            this.checkBox_stopRX.Size = new System.Drawing.Size(191, 33);
            this.checkBox_stopRX.TabIndex = 13;
            this.checkBox_stopRX.Text = "Stop RX CAN";
            this.checkBox_stopRX.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2322, 1196);
            this.Name = "Form1";
            this.Text = "Alseer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.TextBox textBox_LogDisplay;
        private System.Windows.Forms.CheckBox checkBox_stopTXCAN;
        private System.Windows.Forms.CheckBox checkBox_DisplayReceivedCAN;
        private System.Windows.Forms.Button btn_clearDisplay;
        private System.Windows.Forms.Timer timer_runCanSend;
        private System.Windows.Forms.Timer timer_runCanReceive;
        private System.Windows.Forms.Timer timer_Loop;
        private System.Windows.Forms.CheckBox checkBox_formatDecimal;
        private System.Windows.Forms.CheckBox cb_Send_ff50;
        private System.Windows.Forms.CheckBox cb_Send_ff51;
        private System.Windows.Forms.CheckBox cb_Send_ff34;
        private System.Windows.Forms.CheckBox checkBox_stopRX;
        private UC_8byteDataDisplayer uC_8_FF50;
        private UC_8byteDataDisplayer uC_8_FF51;
        private UC_8byteDataDisplayer uC_8_FF34;
    }
}

