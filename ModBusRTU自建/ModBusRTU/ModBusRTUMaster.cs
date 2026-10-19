using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NModBusRTU
{
    public class ModBusRTUMaster
    {
        private IStreamResource _serialPort;
        public ModBusRTUMaster(IStreamResource serialPortAdapter)
        {
            _serialPort = serialPortAdapter;
        }

        #region 同步读取寄存器和线圈
        /// <summary>
        /// 同步读取保持寄存器
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">寄存器起始地址</param>
        /// <param name="numberOfRegisters">寄存器数量</param>
        /// <returns>ushort数组</returns>
        /// <exception cref="Exception"></exception>
        public ushort[] ReadHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfRegisters)
        {
            ushort[] result = new ushort[numberOfRegisters];
            // 1: 报文组装
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x03,startAddress, numberOfRegisters);
            // 2：将报文写入到串口,从串口读取数据
            byte[] response = null; // 接收设备响应的报文
            bool res = SendAndReceive(data, ref response);
            if (!res)
            {
                // 抛出错误，结束函数
                throw new Exception("设备无响应");
            }
            // 3：验证报文
            if (!ModBusRTU.Validate0304Response(response, slaveAddress, numberOfRegisters))
            {
                // 抛出错误，结束函数
                throw new Exception("报文验证失败");
            }
            // 4：截取数据区域
            byte[] dataArea = new byte[2 * numberOfRegisters];
            Array.Copy(response, 3, dataArea, 0, dataArea.Length);

            // 5：将数据区域转化为 ushort数组
            result = BytesToUshort(dataArea);
            return result;
        }

        /// <summary>
        /// 同步读取输入寄存器
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">寄存器起始地址</param>
        /// <param name="numberOfRegisters">寄存器数量</param>
        /// <returns>ushort数组</returns>
        /// <exception cref="Exception"></exception>
        public ushort[] ReadInputRegisters(byte slaveAddress, ushort startAddress, ushort numberOfRegisters)
        {
            ushort[] result = new ushort[numberOfRegisters];
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x04, startAddress, numberOfRegisters);
            byte[] response = null; // 接收设备响应的报文
            bool res = SendAndReceive(data, ref response);
            if (!res) throw new Exception("设备无响应");
            if (!ModBusRTU.Validate0304Response(response, slaveAddress, numberOfRegisters)) throw new Exception("报文验证失败");
            // 4：截取数据区域
            byte[] dataArea = new byte[2 * numberOfRegisters];
            Array.Copy(response, 3, dataArea, 0, dataArea.Length);

            // 5：将数据区域转化为 ushort数组
            result = BytesToUshort(dataArea);
            return result;
        }

        /// <summary>
        /// 同步读取输出线圈
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">线圈起始地址</param>
        /// <param name="numberOfCoils">线圈数量</param>
        /// <returns>bool数组</returns>
        /// <exception cref="Exception"></exception>
        public bool[] ReadHoldingCoils(byte slaveAddress, ushort startAddress, ushort numberOfCoils)
        {
            bool[] result = new bool[numberOfCoils];
            // 1: 报文组装
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x01, startAddress, numberOfCoils);
            // 2：将报文写入到串口,从串口 读取数据
            byte[] response = null; // 接收设备响应的报文
            bool res = SendAndReceive(data, ref response);
            if (!res) throw new Exception("设备无响应");
            // 3：验证报文
            if (!ModBusRTU.Validate0102Response(response, slaveAddress, numberOfCoils)) throw new Exception("报文验证失败");
            // 4：截取数据区域
            byte[] dataArea = new byte[(numberOfCoils + 7) / 8];
            Array.Copy(response, 3, dataArea, 0, dataArea.Length);

            // 5：将数据区域转化为 bool数组
            result = BitConvertHelper.ByteArrayToBoolArray(dataArea, numberOfCoils);
            return result;
        }

        /// <summary>
        /// 同步读取输入线圈
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">线圈起始地址</param>
        /// <param name="numberOfCoils">线圈数量</param>
        /// <returns>bool数组</returns>
        /// <exception cref="Exception"></exception>
        public bool[] ReadInputCoils(byte slaveAddress, ushort startAddress, ushort numberOfCoils)
        {
            bool[] result = new bool[numberOfCoils];
            // 1: 报文组装
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x02, startAddress, numberOfCoils);
            // 2：将报文写入到串口,从串口读取数据
            byte[] response = null; // 接收设备响应的报文
            bool res = SendAndReceive(data, ref response);
            if (!res) throw new Exception("设备无响应");
            // 3：验证报文
            if (!ModBusRTU.Validate0102Response(response, slaveAddress, numberOfCoils)) throw new Exception("报文验证失败");
            // 4：截取数据区域
            byte[] dataArea = new byte[(numberOfCoils + 7) / 8];
            Array.Copy(response, 3, dataArea, 0, dataArea.Length);

            // 5：将数据区域转化为 bool数组
            result = BitConvertHelper.ByteArrayToBoolArray(dataArea, numberOfCoils);
            return result;
        }
        #endregion

        #region 同步写入寄存器和线圈

        /// <summary>
        /// 同步写入单个寄存器
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">寄存器地址</param>
        /// <param name="Adddata">写入的数据</param>
        /// <returns>bool</returns>
        /// <exception cref="Exception"></exception>
        public bool WriteSinleRegister(byte slaveAddress, ushort startAddress, ushort Adddata)
        {
            // 1: 报文组装
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x06, startAddress, Adddata);
            // 2：将报文写入到串口,从串口读取数据
            byte[] response = null; // 接收设备响应的报文
            bool res = SendAndReceive(data, ref response);
            if (!res) throw new Exception("设备无响应");
            // 3：验证报文
            if (!ModBusRTU.Validate0506Response(data, response)) throw new Exception("报文验证失败");
            return true;
        }

        /// <summary>
        /// 同步写入多个寄存器
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">寄存器起始地址</param>
        /// <param name="numberOfRegisters">寄存器数量</param>
        /// <param name="Adddata">写入的数据</param>
        /// <returns>bool</returns>
        /// <exception cref="Exception"></exception>
        public bool WriteMultipleRegisters(byte slaveAddress, ushort startAddress, ushort numberOfRegisters, ushort[] Adddata)
        {
            // 1: 报文组装
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x10, startAddress, numberOfRegisters, Adddata);
            // 2：将报文写入到串口,从串口读取数据
            byte[] response = null; // 接收设备响应的报文
            bool res = SendAndReceive(data, ref response);
            if (!res) throw new Exception("设备无响应");
            // 3：验证报文
            if (!ModBusRTU.Validate100FResponse(response, slaveAddress, numberOfRegisters)) throw new Exception("报文验证失败");
            return true;
        }

        /// <summary>
        /// 同步写入单个线圈
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">线圈地址</param>
        /// <param name="Adddata">写入的bool值</param>
        /// <returns>bool</returns>
        /// <exception cref="Exception"></exception>
        public bool WriteSinleCoil(byte slaveAddress, ushort startAddress, bool Adddata)
        {
            // 1: 报文组装
            byte[] data = ModBusRTU.BuildRequest05(slaveAddress, 0x05, startAddress, Adddata);
            // 2：将报文写入到串口,从串口读取数据
            byte[] response = null; // 接收设备响应的报文
            bool res = SendAndReceive(data, ref response);
            if (!res) throw new Exception("设备无响应");
            // 3：验证报文
            if (!ModBusRTU.Validate0506Response(data, response)) throw new Exception("报文验证失败");
            return true;
        }

        /// <summary>
        /// 同步写入多个线圈
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">线圈起始地址</param>
        /// <param name="numberOfCoils">线圈数量</param>
        /// <param name="Adddata">写入的bool数组</param>
        /// <returns>bool</returns>
        /// <exception cref="Exception"></exception>
        public bool WriteMultipleCoils(byte slaveAddress, ushort startAddress, ushort numberOfCoils, bool[] Adddata)
        {
            // 1: 报文组装
            byte[] data = ModBusRTU.BuildRequest0F(slaveAddress, 0x0f, startAddress, numberOfCoils, Adddata);
            // 2：将报文写入到串口,从串口读取数据
            byte[] response = null; // 接收设备响应的报文
            bool res = SendAndReceive(data, ref response);
            if (!res) throw new Exception("设备无响应");
            // 3：验证报文
            if (!ModBusRTU.Validate100FResponse(response, slaveAddress, numberOfCoils)) throw new Exception("报文验证失败");
            return true;
        }
        #endregion

        #region 发送并接收
        /// <summary>
        /// 发送并接收
        /// </summary>
        /// <param name="data">发送的报文</param>
        /// <param name="response">接收的报文</param>
        /// <returns>发送与接收是否成功</returns>
        private bool SendAndReceive(byte[] data, ref byte[] response)
        {
            // 1：清空串口的缓存
            _serialPort.DiscardBuffer();
            // 2：发送报文
            _serialPort.Write(data, 0, data.Length);
            // 3：等待响应
            // 是否有响应
            bool isRes = false;
            while (DateTime.Now.Millisecond - _serialPort.ReadTime < 1000)
            {
                // 设备有响应
                if (_serialPort.BytesToRead > 0)
                {
                    isRes = true;
                    break;
                }
            }
            // 4：处理设备响应
            // 超过1秒没有响应
            if (!isRes)
            {
                response = new byte[4];
                return false;
            }
            // 设备有响应，读取响应数据
            byte[] result = new byte[_serialPort.BytesToRead];
            _serialPort.Read(result, 0, result.Length);
            response = result;
            return true;
        }
        #endregion

        #region 异步读取寄存器和线圈
        public async Task<ushort[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfRegisters)
        {
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x03, startAddress, numberOfRegisters);

            var (res, response) = await SendAndReceiveAsync(data);
            if (!res) throw new Exception("设备无响应");
            if (!ModBusRTU.Validate0304Response(response, slaveAddress, numberOfRegisters)) throw new Exception("报文验证失败");

            byte[] dataArea = new byte[2 * numberOfRegisters];
            Array.Copy(response, 4, dataArea, 0, dataArea.Length);
            return BytesToUshort(dataArea);
        }

        public async Task<ushort[]> ReadInputRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfRegisters)
        {
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x04, startAddress, numberOfRegisters);

            var (res, response) = await SendAndReceiveAsync(data);
            if (!res) throw new Exception("设备无响应");
            if (!ModBusRTU.Validate0304Response(response, slaveAddress, numberOfRegisters)) throw new Exception("报文验证失败");

            byte[] dataArea = new byte[2 * numberOfRegisters];
            Array.Copy(response, 4, dataArea, 0, dataArea.Length); // 修正了原代码中从3开始截取的错误
            return BytesToUshort(dataArea);
        }

        public async Task<bool[]> ReadHoldingCoilsAsync(byte slaveAddress, ushort startAddress, ushort numberOfCoils)
        {
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x01, startAddress, numberOfCoils);

            var (res, response) = await SendAndReceiveAsync(data);
            if (!res) throw new Exception("设备无响应");
            if (!ModBusRTU.Validate0102Response(response, slaveAddress, numberOfCoils)) throw new Exception("报文验证失败");

            byte[] dataArea = new byte[(numberOfCoils + 7) / 8];
            Array.Copy(response, 3, dataArea, 0, dataArea.Length);
            return BitConvertHelper.ByteArrayToBoolArray(dataArea, numberOfCoils);
        }

        public async Task<bool[]> ReadInputCoilsAsync(byte slaveAddress, ushort startAddress, ushort numberOfCoils)
        {
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x02, startAddress, numberOfCoils);

            var (res, response) = await SendAndReceiveAsync(data);
            if (!res) throw new Exception("设备无响应");
            if (!ModBusRTU.Validate0102Response(response, slaveAddress, numberOfCoils)) throw new Exception("报文验证失败");

            // 修正了原代码中 dataArea 长度计算错误 (线圈应该是 (num+7)/8，而不是 2*num)
            byte[] dataArea = new byte[(numberOfCoils + 7) / 8];
            Array.Copy(response, 3, dataArea, 0, dataArea.Length);
            return BitConvertHelper.ByteArrayToBoolArray(dataArea, numberOfCoils);
        }
        #endregion

        #region 异步写入寄存器和线圈
        public async Task<bool> WriteSinleRegisterAsync(byte slaveAddress, ushort startAddress, ushort Adddata)
        {
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x06, startAddress, Adddata);

            var (res, response) = await SendAndReceiveAsync(data);
            if (!res) throw new Exception("设备无响应");
            if (!ModBusRTU.Validate0506Response(data, response)) throw new Exception("报文验证失败");

            return true;
        }

        public async Task<bool> WriteMultipleRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfRegisters, ushort[] Adddata)
        {
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x10, startAddress, numberOfRegisters, Adddata);

            var (res, response) = await SendAndReceiveAsync(data);
            if (!res) throw new Exception("设备无响应");
            if (!ModBusRTU.Validate100FResponse(response, slaveAddress, numberOfRegisters)) throw new Exception("报文验证失败");

            return true;
        }

        public async Task<bool> WriteSinleCoilAsync(byte slaveAddress, ushort startAddress, bool Adddata)
        {
            byte[] data = ModBusRTU.BuildRequest05(slaveAddress, 0x05, startAddress, Adddata);

            var (res, response) = await SendAndReceiveAsync(data);
            if (!res) throw new Exception("设备无响应");
            if (!ModBusRTU.Validate0506Response(data, response)) throw new Exception("报文验证失败");

            return true;
        }

        /// <summary>
        /// 写入多个线圈 (建议参数改为 bool[] Adddata 更合理，这里保持原样)
        /// </summary>
        public async Task<bool> WriteMultipleCoilsAsync(byte slaveAddress, ushort startAddress, ushort numberOfCoils, ushort[] Adddata)
        {
            byte[] data = ModBusRTU.BuildRequest(slaveAddress, 0x0f, startAddress, numberOfCoils, Adddata);

            var (res, response) = await SendAndReceiveAsync(data);
            if (!res) throw new Exception("设备无响应");
            if (!ModBusRTU.Validate100FResponse(response, slaveAddress, numberOfCoils)) throw new Exception("报文验证失败");

            return true;
        }
        #endregion

        #region 异步发送并接收
        /// <summary>
        /// 异步发送并接收
        /// </summary>
        private async Task<(bool success, byte[] response)> SendAndReceiveAsync(byte[] data)
        {
            // 1：清空串口的缓存
            _serialPort.DiscardBuffer();

            // 2：发送报文
            _serialPort.Write(data, 0, data.Length);

            // 3：等待响应 (使用 Stopwatch 修复原代码 DateTime.Millisecond 跨秒计算的 Bug)
            int timeout = 1000; // 超时时间 1000ms
            var stopwatch = Stopwatch.StartNew();

            while (stopwatch.ElapsedMilliseconds < timeout)
            {
                if (_serialPort.BytesToRead > 0)
                {
                    // 设备有响应，读取数据
                    byte[] result = new byte[_serialPort.BytesToRead];
                    _serialPort.Read(result, 0, result.Length);
                    return (true, result);
                }

                // 异步等待 10 毫秒，避免 CPU 满载 (不阻塞 UI 线程)
                await Task.Delay(10);
            }

            // 超时未响应
            return (false, new byte[4]);
        }
        #endregion

        #region 将byte[] 转化为 ushort[]
        private ushort[] BytesToUshort(byte[] data)
        {
            if (data.Length % 2 != 0) return null;
            ushort[] res = new ushort[data.Length / 2];
            for (int i = 0; i < res.Length; i++)
            {
                byte hight = data[i * 2];
                byte low = data[i * 2 + 1];
                res[i] = (ushort)(hight * 256 + low);
            }
            return res;
        }
        #endregion

        #region 释放资源
        public void Dispose()
        {
            if (_serialPort != null)
            {
                _serialPort.Dispose();
                _serialPort = null;
            }
        }
        #endregion

    }
}
