namespace demo
{
    partial class FrmModBusRTU
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlPort = new System.Windows.Forms.Panel();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.txtData4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtData3 = new System.Windows.Forms.TextBox();
            this.txtData1 = new System.Windows.Forms.TextBox();
            this.txtData2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCoil1 = new System.Windows.Forms.CheckBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.txtWriteData4 = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Slave地址 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFuncCode = new System.Windows.Forms.TextBox();
            this.txtDataLength = new System.Windows.Forms.TextBox();
            this.txtWriteData3 = new System.Windows.Forms.TextBox();
            this.txtStartAddress = new System.Windows.Forms.TextBox();
            this.txtWriteData1 = new System.Windows.Forms.TextBox();
            this.txtWriteData2 = new System.Windows.Forms.TextBox();
            this.txtSlaveAddress = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbReadTime = new System.Windows.Forms.CheckBox();
            this.btnStartRead = new System.Windows.Forms.Button();
            this.cbCoil2 = new System.Windows.Forms.CheckBox();
            this.cbCoil3 = new System.Windows.Forms.CheckBox();
            this.cbCoil4 = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlPort);
            this.groupBox3.Controls.Add(this.btnDisConnect);
            this.groupBox3.Controls.Add(this.btnConnect);
            this.groupBox3.Controls.Add(this.cbParity);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbStopBits);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbDataBits);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbBaudRate);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbPortName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 311);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "串口连接";
            // 
            // pnlPort
            // 
            this.pnlPort.BackColor = System.Drawing.Color.Gray;
            this.pnlPort.Location = new System.Drawing.Point(309, 32);
            this.pnlPort.Name = "pnlPort";
            this.pnlPort.Size = new System.Drawing.Size(25, 23);
            this.pnlPort.TabIndex = 16;
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.Location = new System.Drawing.Point(187, 252);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(109, 36);
            this.btnDisConnect.TabIndex = 15;
            this.btnDisConnect.Text = "断开串口";
            this.btnDisConnect.UseVisualStyleBackColor = true;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(39, 252);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(109, 36);
            this.btnConnect.TabIndex = 15;
            this.btnConnect.Text = "连接串口";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(109, 204);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(164, 23);
            this.cbParity.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "校验位：";
            // 
            // cbStopBits
            // 
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Location = new System.Drawing.Point(109, 161);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(164, 23);
            this.cbStopBits.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "停止位：";
            // 
            // cbDataBits
            // 
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Location = new System.Drawing.Point(109, 118);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(164, 23);
            this.cbDataBits.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "数据位：";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Location = new System.Drawing.Point(109, 75);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(164, 23);
            this.cbBaudRate.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "波特率：";
            // 
            // cbPortName
            // 
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(109, 32);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(164, 23);
            this.cbPortName.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "串口号：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 578);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMsg);
            this.groupBox1.Controls.Add(this.txtData4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtData3);
            this.groupBox1.Controls.Add(this.txtData1);
            this.groupBox1.Controls.Add(this.txtData2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(363, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 311);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据展示";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(41, 68);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(480, 25);
            this.txtMsg.TabIndex = 1;
            // 
            // txtData4
            // 
            this.txtData4.Location = new System.Drawing.Point(130, 258);
            this.txtData4.Name = "txtData4";
            this.txtData4.Size = new System.Drawing.Size(256, 25);
            this.txtData4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "数据4：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "数据3：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "数据2：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 15);
            this.label13.TabIndex = 5;
            this.label13.Text = "读取的数据：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "数据1：";
            // 
            // txtData3
            // 
            this.txtData3.Location = new System.Drawing.Point(130, 209);
            this.txtData3.Name = "txtData3";
            this.txtData3.Size = new System.Drawing.Size(256, 25);
            this.txtData3.TabIndex = 6;
            // 
            // txtData1
            // 
            this.txtData1.Location = new System.Drawing.Point(130, 111);
            this.txtData1.Name = "txtData1";
            this.txtData1.Size = new System.Drawing.Size(256, 25);
            this.txtData1.TabIndex = 7;
            // 
            // txtData2
            // 
            this.txtData2.Location = new System.Drawing.Point(130, 160);
            this.txtData2.Name = "txtData2";
            this.txtData2.Size = new System.Drawing.Size(256, 25);
            this.txtData2.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCoil4);
            this.groupBox2.Controls.Add(this.cbCoil3);
            this.groupBox2.Controls.Add(this.cbCoil2);
            this.groupBox2.Controls.Add(this.cbCoil1);
            this.groupBox2.Controls.Add(this.btnWrite);
            this.groupBox2.Controls.Add(this.txtWriteData4);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Slave地址);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtFuncCode);
            this.groupBox2.Controls.Add(this.txtDataLength);
            this.groupBox2.Controls.Add(this.txtWriteData3);
            this.groupBox2.Controls.Add(this.txtStartAddress);
            this.groupBox2.Controls.Add(this.txtWriteData1);
            this.groupBox2.Controls.Add(this.txtWriteData2);
            this.groupBox2.Controls.Add(this.txtSlaveAddress);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(363, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 255);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送数据设置";
            // 
            // cbCoil1
            // 
            this.cbCoil1.AutoSize = true;
            this.cbCoil1.Location = new System.Drawing.Point(456, 41);
            this.cbCoil1.Name = "cbCoil1";
            this.cbCoil1.Size = new System.Drawing.Size(67, 19);
            this.cbCoil1.TabIndex = 14;
            this.cbCoil1.Text = "线圈1";
            this.cbCoil1.UseVisualStyleBackColor = true;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(338, 211);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(123, 38);
            this.btnWrite.TabIndex = 10;
            this.btnWrite.Text = "写入";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // txtWriteData4
            // 
            this.txtWriteData4.Location = new System.Drawing.Point(321, 172);
            this.txtWriteData4.Name = "txtWriteData4";
            this.txtWriteData4.Size = new System.Drawing.Size(100, 25);
            this.txtWriteData4.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(69, 208);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(123, 38);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(255, 180);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 15);
            this.label17.TabIndex = 2;
            this.label17.Text = "数据4：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "功能码：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(255, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 15);
            this.label16.TabIndex = 3;
            this.label16.Text = "数据3：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "数据长度";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(255, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 15);
            this.label15.TabIndex = 4;
            this.label15.Text = "数据2：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "起始地址";
            // 
            // Slave地址
            // 
            this.Slave地址.AutoSize = true;
            this.Slave地址.Location = new System.Drawing.Point(21, 38);
            this.Slave地址.Name = "Slave地址";
            this.Slave地址.Size = new System.Drawing.Size(77, 15);
            this.Slave地址.TabIndex = 5;
            this.Slave地址.Text = "Slave地址";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(255, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 15);
            this.label14.TabIndex = 5;
            this.label14.Text = "数据1：";
            // 
            // txtFuncCode
            // 
            this.txtFuncCode.Location = new System.Drawing.Point(104, 170);
            this.txtFuncCode.Name = "txtFuncCode";
            this.txtFuncCode.Size = new System.Drawing.Size(117, 25);
            this.txtFuncCode.TabIndex = 6;
            this.txtFuncCode.Text = "3";
            // 
            // txtDataLength
            // 
            this.txtDataLength.Location = new System.Drawing.Point(104, 125);
            this.txtDataLength.Name = "txtDataLength";
            this.txtDataLength.Size = new System.Drawing.Size(117, 25);
            this.txtDataLength.TabIndex = 6;
            this.txtDataLength.Text = "4";
            // 
            // txtWriteData3
            // 
            this.txtWriteData3.Location = new System.Drawing.Point(321, 125);
            this.txtWriteData3.Name = "txtWriteData3";
            this.txtWriteData3.Size = new System.Drawing.Size(100, 25);
            this.txtWriteData3.TabIndex = 6;
            // 
            // txtStartAddress
            // 
            this.txtStartAddress.Location = new System.Drawing.Point(104, 80);
            this.txtStartAddress.Name = "txtStartAddress";
            this.txtStartAddress.Size = new System.Drawing.Size(117, 25);
            this.txtStartAddress.TabIndex = 7;
            this.txtStartAddress.Text = "0";
            // 
            // txtWriteData1
            // 
            this.txtWriteData1.Location = new System.Drawing.Point(321, 35);
            this.txtWriteData1.Name = "txtWriteData1";
            this.txtWriteData1.Size = new System.Drawing.Size(100, 25);
            this.txtWriteData1.TabIndex = 7;
            // 
            // txtWriteData2
            // 
            this.txtWriteData2.Location = new System.Drawing.Point(321, 77);
            this.txtWriteData2.Name = "txtWriteData2";
            this.txtWriteData2.Size = new System.Drawing.Size(100, 25);
            this.txtWriteData2.TabIndex = 8;
            // 
            // txtSlaveAddress
            // 
            this.txtSlaveAddress.Location = new System.Drawing.Point(104, 35);
            this.txtSlaveAddress.Name = "txtSlaveAddress";
            this.txtSlaveAddress.Size = new System.Drawing.Size(117, 25);
            this.txtSlaveAddress.TabIndex = 8;
            this.txtSlaveAddress.Text = "1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbReadTime);
            this.groupBox4.Controls.Add(this.btnStartRead);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 255);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "实时读取";
            // 
            // cbReadTime
            // 
            this.cbReadTime.AutoSize = true;
            this.cbReadTime.Location = new System.Drawing.Point(99, 95);
            this.cbReadTime.Name = "cbReadTime";
            this.cbReadTime.Size = new System.Drawing.Size(119, 19);
            this.cbReadTime.TabIndex = 10;
            this.cbReadTime.Text = "是否实时读取";
            this.cbReadTime.UseVisualStyleBackColor = true;
            // 
            // btnStartRead
            // 
            this.btnStartRead.Location = new System.Drawing.Point(99, 157);
            this.btnStartRead.Name = "btnStartRead";
            this.btnStartRead.Size = new System.Drawing.Size(119, 38);
            this.btnStartRead.TabIndex = 9;
            this.btnStartRead.Tag = "0";
            this.btnStartRead.Text = "读取";
            this.btnStartRead.UseVisualStyleBackColor = true;
            this.btnStartRead.Click += new System.EventHandler(this.btnStartRead_Click);
            // 
            // cbCoil2
            // 
            this.cbCoil2.AutoSize = true;
            this.cbCoil2.Location = new System.Drawing.Point(456, 83);
            this.cbCoil2.Name = "cbCoil2";
            this.cbCoil2.Size = new System.Drawing.Size(67, 19);
            this.cbCoil2.TabIndex = 14;
            this.cbCoil2.Text = "线圈2";
            this.cbCoil2.UseVisualStyleBackColor = true;
            // 
            // cbCoil3
            // 
            this.cbCoil3.AutoSize = true;
            this.cbCoil3.Location = new System.Drawing.Point(456, 134);
            this.cbCoil3.Name = "cbCoil3";
            this.cbCoil3.Size = new System.Drawing.Size(67, 19);
            this.cbCoil3.TabIndex = 14;
            this.cbCoil3.Text = "线圈3";
            this.cbCoil3.UseVisualStyleBackColor = true;
            // 
            // cbCoil4
            // 
            this.cbCoil4.AutoSize = true;
            this.cbCoil4.Location = new System.Drawing.Point(456, 180);
            this.cbCoil4.Name = "cbCoil4";
            this.cbCoil4.Size = new System.Drawing.Size(67, 19);
            this.cbCoil4.TabIndex = 14;
            this.cbCoil4.Text = "线圈4";
            this.cbCoil4.UseVisualStyleBackColor = true;
            // 
            // FrmModBusRTU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 578);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmModBusRTU";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmModBusRTU_FormClosing);
            this.Load += new System.EventHandler(this.FrmModBusRTU_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnlPort;
        private System.Windows.Forms.Button btnDisConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox txtData4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtData3;
        private System.Windows.Forms.TextBox txtData1;
        private System.Windows.Forms.TextBox txtData2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbCoil1;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox txtWriteData4;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Slave地址;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtFuncCode;
        private System.Windows.Forms.TextBox txtDataLength;
        private System.Windows.Forms.TextBox txtWriteData3;
        private System.Windows.Forms.TextBox txtStartAddress;
        private System.Windows.Forms.TextBox txtWriteData1;
        private System.Windows.Forms.TextBox txtWriteData2;
        private System.Windows.Forms.TextBox txtSlaveAddress;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbReadTime;
        private System.Windows.Forms.Button btnStartRead;
        private System.Windows.Forms.CheckBox cbCoil4;
        private System.Windows.Forms.CheckBox cbCoil3;
        private System.Windows.Forms.CheckBox cbCoil2;
    }
}

