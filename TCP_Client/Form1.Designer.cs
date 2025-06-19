namespace TCP_Client
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
            txtMessage = new TextBox();
            btnSend = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            txtNameUser = new TextBox();
            label3 = new Label();
            btnConnect = new Button();
            btnDisconnect = new Button();
            numPort = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            txtIPAddress = new TextBox();
            groupBox3 = new GroupBox();
            lbClientList = new ListBox();
            groupBox4 = new GroupBox();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            richTextBox1 = new RichTextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPort).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Enabled = false;
            txtMessage.Location = new Point(6, 22);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(583, 68);
            txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Enabled = false;
            btnSend.Location = new Point(598, 22);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(166, 68);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMessage);
            groupBox1.Controls.Add(btnSend);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(12, 425);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(770, 100);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Message";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtNameUser);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnConnect);
            groupBox2.Controls.Add(btnDisconnect);
            groupBox2.Controls.Add(numPort);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtIPAddress);
            groupBox2.Location = new Point(12, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(770, 75);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Connection info";
            // 
            // txtNameUser
            // 
            txtNameUser.Location = new Point(482, 37);
            txtNameUser.Name = "txtNameUser";
            txtNameUser.RightToLeft = RightToLeft.Yes;
            txtNameUser.Size = new Size(100, 23);
            txtNameUser.TabIndex = 8;
            txtNameUser.Text = "Serg";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(541, 19);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 7;
            label3.Text = "Name";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(598, 19);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(80, 50);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Enabled = false;
            btnDisconnect.Location = new Point(684, 19);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(80, 50);
            btnDisconnect.TabIndex = 5;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // numPort
            // 
            numPort.Location = new Point(168, 37);
            numPort.Maximum = new decimal(new int[] { 65000, 0, 0, 0 });
            numPort.Name = "numPort";
            numPort.Size = new Size(61, 23);
            numPort.TabIndex = 4;
            numPort.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 19);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 3;
            label2.Text = "Port";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 2;
            label1.Text = "Server IP";
            // 
            // txtIPAddress
            // 
            txtIPAddress.Location = new Point(6, 37);
            txtIPAddress.Name = "txtIPAddress";
            txtIPAddress.PlaceholderText = "Server IP";
            txtIPAddress.Size = new Size(132, 23);
            txtIPAddress.TabIndex = 1;
            txtIPAddress.Text = "127.0.0.1";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbClientList);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox3.Location = new Point(610, 96);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(172, 323);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Client list";
            // 
            // lbClientList
            // 
            lbClientList.FormattingEnabled = true;
            lbClientList.ItemHeight = 15;
            lbClientList.Location = new Point(6, 22);
            lbClientList.Name = "lbClientList";
            lbClientList.Size = new Size(160, 289);
            lbClientList.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tabControl);
            groupBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox4.Location = new Point(10, 96);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(594, 323);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Chats";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Enabled = false;
            tabControl.Location = new Point(8, 22);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(580, 289);
            tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Transparent;
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(572, 261);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General";
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(566, 255);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 537);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPort).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtMessage;
        private Button btnSend;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtIPAddress;
        private Label label1;
        private Button btnConnect;
        private Button btnDisconnect;
        private NumericUpDown numPort;
        private Label label2;
        private GroupBox groupBox3;
        private ListBox lbClientList;
        private GroupBox groupBox4;
        private TabControl tabControl;
        private TabPage tabPage1;
        private RichTextBox richTextBox1;
        private TextBox txtNameUser;
        private Label label3;
    }
}
