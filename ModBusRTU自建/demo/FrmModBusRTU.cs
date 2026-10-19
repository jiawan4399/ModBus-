using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NModBusRTU;

namespace demo
{
    public partial class FrmModBusRTU : Form
    {
        public FrmModBusRTU()
        {
            InitializeComponent();
        }
        #region 公共变量
        ModBusRTUMaster master = null;
        CancellationTokenSource cts = null;
        #endregion

        #region 窗体事件
        private void FrmModBusRTU_Load(object sender, EventArgs e)
        {
            BIndData();
        }

        private void FrmModBusRTU_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (master != null)
            {
                try
                {
                    master.Dispose();
                    master = null;
                }
                catch { }
            }
            if (cts != null)
            {
                try
                {
                    cts.Cancel();
                    cts.Dispose();
                    cts = null;
                }
                catch { }
            }
        }

        #endregion

        #region 连接和断开连接
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    SerialPort sp = new SerialPort();
                    Invoke(new Action(() =>
                    {
                        sp.PortName = cbPortName.Text.Trim();
                        sp.BaudRate = Convert.ToInt32(cbBaudRate.Text.Trim());
                        sp.DataBits = Convert.ToInt32(cbDataBits.Text.Trim());
                        sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cbStopBits.Text.Trim());
                        sp.Parity = (Parity)Enum.Parse(typeof(Parity), cbParity.Text.Trim());
                    }));
                    sp.Open();
                    master = ModBusFactory.CreateRTUMaster(sp, 1000,1000);
                    Invoke(new Action(() =>
                    {
                        btnConnect.Enabled = false;
                        btnDisConnect.Enabled = true;
                        pnlPort.BackColor = Color.Green;
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开串口失败" + ex.Message);
                    return;
                }
            });
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            if (master != null)
            {
                try
                {
                    master.Dispose();
                    master = null;
                    btnConnect.Enabled = true;
                    btnDisConnect.Enabled = false;
                    pnlPort.BackColor = Color.Gray;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("关闭串口失败" + ex.Message);
                    return;
                }
            }
            btnConnect.Enabled = true;
            btnDisConnect.Enabled = true;
            pnlPort.BackColor = Color.Gray;
        }
        #endregion

        #region 发送和读取数据
        private void btnWrite_Click(object sender, EventArgs e)
        {
            ushort funcCode = Convert.ToUInt16(txtFuncCode.Text.Trim(),16);
            byte slaveID = Convert.ToByte(txtSlaveAddress.Text.Trim());
            ushort startAddress = Convert.ToUInt16(txtStartAddress.Text.Trim());
            ushort length = Convert.ToUInt16(txtDataLength.Text.Trim());
            bool res = false;
            if (funcCode == 0x06)
            {
                res = master.WriteSinleRegister(slaveID, startAddress, Convert.ToUInt16(txtWriteData1.Text.Trim()));
            }
            else if (funcCode == 0x10)
            {
                ushort[] data = new ushort[] { Convert.ToUInt16(txtWriteData1.Text.Trim()), Convert.ToUInt16(txtWriteData2.Text.Trim()), Convert.ToUInt16(txtWriteData3.Text.Trim()), Convert.ToUInt16(txtWriteData4.Text.Trim()) };
                res = master.WriteMultipleRegisters(slaveID, startAddress, length, data);
            }
            else if (funcCode == 0x05)
            {
                res = master.WriteSinleCoil(slaveID, startAddress, cbCoil1.Checked);
            }
            else if (funcCode == 0x0F)
            {
                bool[] data = new bool[] { cbCoil1.Checked, cbCoil2.Checked, cbCoil3.Checked, cbCoil4.Checked };
                res = master.WriteMultipleCoils(slaveID, startAddress, length, data);
            }
            else
            {
                MessageBox.Show("功能码错误，写入失败");
                return;
            }
            if (res)
            {
                MessageBox.Show("写入成功");
            }
            else
            {
                MessageBox.Show("写入失败");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ushort funcCode = Convert.ToUInt16(txtFuncCode.Text.Trim());
            byte slaveID = Convert.ToByte(txtSlaveAddress.Text.Trim());
            ushort startAddress = Convert.ToUInt16(txtStartAddress.Text.Trim());
            ushort length = Convert.ToUInt16(txtDataLength.Text.Trim());
            if (funcCode == 0x03)
            {
                ushort[] data = master.ReadHoldingRegisters(slaveID, startAddress, length);
                ShowData(data);
            }
            else if (funcCode == 0x04)
            {
                ushort[] data = master.ReadInputRegisters(slaveID, startAddress, length);
                ShowData(data);
            }
            else if (funcCode == 0x01)
            {
                bool[] data = master.ReadHoldingCoils(slaveID, startAddress, length);
                ShowData(data);
            }
            else if (funcCode == 0x02)
            {
                bool[] data = master.ReadInputCoils(slaveID, startAddress, length);
                ShowData(data);
            }
            else 
            {
                MessageBox.Show("功能码错误");
            }
        }

        private void btnStartRead_Click(object sender, EventArgs e)
        {
            if (cbReadTime.Checked && !btnStartRead.Text.Equals("停止读取"))
            {
                cts = new CancellationTokenSource();
                Task.Run(async () =>
                {
                    while (!cts.IsCancellationRequested)
                    {
                        btnSend_Click(null, null);
                        await Task.Delay(1000, cts.Token);
                    }
                }, cts.Token);
                btnStartRead.Text = "停止读取";
            }
            else
            {
                if (cts != null) cts.Cancel();
                btnSend_Click(null, null);
                btnStartRead.Text = "读取";
                cbReadTime.Checked = false;
            }
        }
        #endregion

        #region 初始化串口数据绑定
        private void BIndData()
        {
            cbPortName.DataSource = SerialPort.GetPortNames();

            cbBaudRate.DataSource = new int[] { 2400, 4800, 9600, 19200, 38400, 57600, 115200 };
            cbBaudRate.SelectedIndex = 2;

            cbDataBits.DataSource = new int[] { 5, 6, 7, 8 };
            cbDataBits.SelectedIndex = 3;

            cbStopBits.DataSource = new string[] { "One", "Two", "OnePointFive" };

            cbStopBits.SelectedIndex = 0;

            cbParity.DataSource = new string[] { "None", "Odd", "Even" };
            cbParity.SelectedIndex = 0;
        }
        #endregion

        #region 公共方法
        private void ShowData(ushort[] data)
        {
            Task.Run(() =>
            {
                Invoke(new Action(() =>
                {
                    txtMsg.Text = string.Join(",", data);
                    txtData1.Text = data[0].ToString();
                    txtData2.Text = data[1].ToString();
                    txtData3.Text = data[2].ToString();
                    txtData4.Text = data[3].ToString();
                }));
            });
        }

        private void ShowData(bool[] data)
        {
            Task.Run(() =>
            {
                Invoke(new Action(() =>
                {
                    txtMsg.Text = string.Join(",", data);
                    txtData1.Text = data[0].ToString();
                    txtData2.Text = data[1].ToString();
                    txtData3.Text = data[2].ToString();
                    txtData4.Text = data[3].ToString();
                }));
            });
        }
        #endregion
    }
}
