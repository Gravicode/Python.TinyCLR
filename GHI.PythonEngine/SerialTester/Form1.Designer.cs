
namespace SerialTester
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CmbPort = new System.Windows.Forms.ComboBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtMessage = new System.Windows.Forms.TextBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtResponse = new System.Windows.Forms.RichTextBox();
            this.TxtBaudRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TxtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM PORT :";
            // 
            // CmbPort
            // 
            this.CmbPort.FormattingEnabled = true;
            this.CmbPort.Location = new System.Drawing.Point(90, 6);
            this.CmbPort.Name = "CmbPort";
            this.CmbPort.Size = new System.Drawing.Size(121, 23);
            this.CmbPort.TabIndex = 1;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(217, 6);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(61, 26);
            this.BtnConnect.TabIndex = 2;
            this.BtnConnect.Text = "&Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "MESSAGE :";
            // 
            // TxtMessage
            // 
            this.TxtMessage.Location = new System.Drawing.Point(90, 65);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.Size = new System.Drawing.Size(333, 114);
            this.TxtMessage.TabIndex = 4;
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(362, 185);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(61, 26);
            this.BtnSend.TabIndex = 5;
            this.BtnSend.Text = "&Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "RESPONSE:";
            // 
            // TxtResponse
            // 
            this.TxtResponse.Location = new System.Drawing.Point(90, 216);
            this.TxtResponse.Name = "TxtResponse";
            this.TxtResponse.Size = new System.Drawing.Size(333, 182);
            this.TxtResponse.TabIndex = 7;
            this.TxtResponse.Text = "";
            // 
            // TxtBaudRate
            // 
            this.TxtBaudRate.Location = new System.Drawing.Point(90, 36);
            this.TxtBaudRate.Name = "TxtBaudRate";
            this.TxtBaudRate.Size = new System.Drawing.Size(121, 23);
            this.TxtBaudRate.TabIndex = 8;
            this.TxtBaudRate.Text = "9600";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "BAUDRATE:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TxtStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 441);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(812, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TxtStatus
            // 
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.Size = new System.Drawing.Size(57, 17);
            this.TxtStatus.Text = "Welcome";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(362, 404);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(61, 26);
            this.BtnClear.TabIndex = 11;
            this.BtnClear.Text = "&Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Location = new System.Drawing.Point(284, 6);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(76, 26);
            this.BtnDisconnect.TabIndex = 12;
            this.BtnDisconnect.Text = "&Disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 463);
            this.Controls.Add(this.BtnDisconnect);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtBaudRate);
            this.Controls.Add(this.TxtResponse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.CmbPort);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Serial Test";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbPort;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox TxtResponse;
        private System.Windows.Forms.RichTextBox TxtResponse1;
        private System.Windows.Forms.TextBox TxtBaudRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TxtStatus;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnDisconnect;
    }
}

