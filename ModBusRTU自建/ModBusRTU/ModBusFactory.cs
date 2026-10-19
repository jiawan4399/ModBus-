using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NModBusRTU
{
    public class ModBusFactory
    {
        public static ModBusRTUMaster CreateRTUMaster(SerialPort serialPort,int readTime , int writeTime)
        {
            if (serialPort == null)
                throw new ArgumentNullException(nameof(serialPort));
            if (readTime <= 0 || writeTime <= 0)
                throw new ArgumentOutOfRangeException("读写超时时间必须大于 0");
            SerialPortAdapter adapter = new SerialPortAdapter(serialPort);
            adapter.ReadTime = readTime;
            adapter.WriteTime = writeTime;
            return new ModBusRTUMaster(adapter);
        }
    }

    /// <summary>
    /// 串口适配器,主要是为了对SerialPort 二次封装
    /// </summary>
    class SerialPortAdapter : IStreamResource
    {
        private SerialPort _serialPort;
        public SerialPortAdapter(SerialPort sp)
        {
            _serialPort = sp;
        }
        public int ReadTime 
        {
            get 
            {
                return _serialPort.ReadTimeout; 
            }
            set 
            {
                _serialPort.ReadTimeout = value; 
            }
        }
        public int WriteTime
        {
            get
            {
                return _serialPort.WriteTimeout;
            }
            set
            {
                _serialPort.WriteTimeout = value;
            }
        }
        public int BytesToRead
        {
            get => _serialPort.BytesToRead;
        }
        public int Read(byte[] buffer, int offset, int count)
        {
            return _serialPort.Read(buffer, offset, count);
        }
        public void Write(byte[] buffer, int offset, int count)
        {
            _serialPort.Write(buffer, offset, count);
        }
        public void Dispose() 
        {
            if (_serialPort != null)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }
        public void DiscardBuffer() 
        {
            _serialPort.DiscardInBuffer();
        }

    }

    /// <summary>
    /// 作用：为了保证二次封装类一定拥有SerialPort核心内容
    /// 因为：ModBusRTUMaster类中需要用到SerialPort 中的核心内容
    /// </summary>
    public interface IStreamResource
    {
        // 读超时时间
        int ReadTime { get; set; }
        // 写超时时间
        int WriteTime { get; set; }
        // 可读字节数
        int BytesToRead { get; }
        // 读取数据
        int Read(byte[] buffer, int offset, int count);
        // 写入数据
        void Write(byte[] buffer, int offset, int count);
        // 释放资源
        void Dispose();
        // 清除缓冲区
        void DiscardBuffer();
    }
}
