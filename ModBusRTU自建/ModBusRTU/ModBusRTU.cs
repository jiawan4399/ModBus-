using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NModBusRTU
{
    public class ModBusRTU
    {
        #region 组装报文
        /// <summary>
        /// 组装8位报文
        /// </summary>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="funccode">功能码</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="numberOfRegistersOrCoils">寄存器或线圈数量</param>
        /// <returns>组装好的报文</returns>
        public static byte[] BuildRequest(byte slaveAddress, byte funccode,ushort startAddress, ushort numberOfRegistersOrCoils)
        {
            byte[] req = new byte[8];
            req[0] = slaveAddress;
            req[1] = funccode;
            req[2] = (byte)(startAddress >> 8);
            req[3] = (byte)(startAddress & 0xFF);
            req[4] = (byte)(numberOfRegistersOrCoils >> 8);
            req[5] = (byte)(numberOfRegistersOrCoils & 0xFF);
            // crc
            req[6] = CRC16(req)[0];
            req[7] = CRC16(req)[1];
            return req;
        }

        /// <summary>
        /// 组装8位线圈报文
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="funccode"></param>
        /// <param name="startAddress"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] BuildRequest05(byte slaveAddress, byte funccode, ushort startAddress, bool data)
        {
            byte[] req = new byte[8];
            req[0] = slaveAddress;
            req[1] = funccode;
            req[2] = (byte)(startAddress >> 8);
            req[3] = (byte)(startAddress & 0xFF);
            if (!data)
            {
                req[4] = 0x00;
                req[5] = 0x00;
            }
            else 
            {
                req[4] = 0xff;
                req[5] = 0x00;
            }
            // crc
            req[6] = CRC16(req)[0];
            req[7] = CRC16(req)[1];
            return req;
        }

        /// <summary>
        /// 组装多位报文
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="funccode"></param>
        /// <param name="startAddress"></param>
        /// <param name="numberOfRegisters"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] BuildRequest(byte slaveAddress, byte funccode, ushort startAddress, ushort numberOfRegisters,ushort[] data)
        {
            byte[] req = new byte[9 + data.Length * 2];
            req[0] = slaveAddress;
            req[1] = 0x10;
            req[2] = (byte)(startAddress >> 8);
            req[3] = (byte)(startAddress & 0xFF);
            req[4] = (byte)(numberOfRegisters >> 8);
            req[5] = (byte)(numberOfRegisters & 0xFF);
            req[6] = (byte)(data.Length * 2);
            for (int i = 0; i < data.Length; i++)
            {
                req[7 + i * 2] = (byte)(data[i] >> 8);
                req[8 + i * 2] = (byte)(data[i] & 0xFF);
            }
            // crc
            req[req.Length - 2] = CRC16(req)[0];
            req[req.Length - 1] = CRC16(req)[1];
            return req;
        }

        /// <summary>
        /// 组装多位线圈报文
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="funccode"></param>
        /// <param name="startAddress"></param>
        /// <param name="numberOfRegisters"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] BuildRequest0F(byte slaveAddress, byte funccode, ushort startAddress, ushort numberOfCoils, bool[] data)
        {
            if(data == null || data.Length == 0)
                throw new ArgumentException("线圈数据不能为空");
            int len = (numberOfCoils + 7) / 8;
            byte[] req = new byte[9 + len];
            req[0] = slaveAddress;
            req[1] = 0x0f;
            req[2] = (byte)(startAddress >> 8);
            req[3] = (byte)(startAddress & 0xFF);
            req[4] = (byte)(numberOfCoils >> 8);
            req[5] = (byte)(numberOfCoils & 0xFF);
            req[6] = (byte)len;
            byte[] bytes = BitConvertHelper.BoolArrayToByteArray(data);
            for (int i = 0; i < bytes.Length; i++)
            {
                req[7 + i] = bytes[i];
            }
            // crc
            req[req.Length - 2] = CRC16(req)[0];
            req[req.Length - 1] = CRC16(req)[1];
            return req;
        }
        #endregion

        #region 验证报文
        public static bool Validate0102Response(byte[] response, byte slaveAddress, ushort numberOfRegisters)
        {
            // 3.1：验证从站地址
            if (response[0] != slaveAddress)
            {
                throw new Exception("从站地址错误,响应报文的从站地址与发送报文的从站地址不一致");
            }
            // 3.2：验证功能码
            if (response[1] != 0x01 && response[1] != 0x02)
            {
                throw new Exception("功能码错误,不是0x01或0x02");
            }
            // 3.3：验证数据长度
            if (response.Length != 5 + (numberOfRegisters + 7) / 8)
            {
                throw new Exception("数据长度错误,响应报文的数据长度与发送报文的数据长度不一致");
            }
            // 3.4：验证crc
            byte[] crc = ModBusRTU.CRC16(response);
            if (crc[0] != response[response.Length - 2] || crc[1] != response[response.Length - 1])
            {
                throw new Exception("crc校验失败，响应报文不合法");
            }
            return true;
        }

        public static bool Validate0304Response(byte[] response, byte slaveAddress, ushort numberOfRegisters)
        {
            // 3.1：验证从站地址
            if (response[0] != slaveAddress)
            {
                throw new Exception("从站地址错误,响应报文的从站地址与发送报文的从站地址不一致");
            }
            // 3.2：验证功能码
            if (response[1] != 0x03 && response[1] != 0x04)
            {
                throw new Exception("功能码错误,不是0x03或0x04");
            }
            // 3.3：验证数据长度
            if (response.Length != 5 + 2 * numberOfRegisters)
            {
                throw new Exception("数据长度错误,响应报文的数据长度与发送报文的数据长度不一致");
            }
            // 3.4：验证crc
            byte[] crc = ModBusRTU.CRC16(response);
            if (crc[0] != response[response.Length - 2] || crc[1] != response[response.Length - 1])
            {
                throw new Exception("crc校验失败，响应报文不合法");
            }
            return true;
        }


        public static bool Validate0506Response(byte[] res,byte[] response)
        {
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] != response[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Validate100FResponse(byte[] response, byte slaveAddress, ushort numberOfRegisters)
        {
            // 3.1：验证从站地址
            if (response[0] != slaveAddress)
            {
                throw new Exception("从站地址错误,响应报文的从站地址与发送报文的从站地址不一致");
            }
            // 3.2：验证功能码
            if (response[1] != 0x10 && response[1] != 0x0f)
            {
                throw new Exception("功能码错误,不是0x10或0x0f");
            }
            // 3.3：验证寄存器或线圈数量
            if (response[4]*256 + response[5] != numberOfRegisters)
            {
                throw new Exception("寄存器或线圈数量错误,响应报文的寄存器或线圈数量与发送报文的寄存器或线圈数量不一致");
            }
            // 3.4：验证crc
            byte[] crc = ModBusRTU.CRC16(response);
            if (crc[0] != response[response.Length - 2] || crc[1] != response[response.Length - 1])
            {
                throw new Exception("crc校验失败，响应报文不合法");
            }
            return true;
        }
        #endregion

        #region CRC校验

        /// <summary>
        /// CRC校验
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] CRC16(byte[] data)
        {
            // 初始化返回值，CRC 底高码
            byte[] crc16 = new byte[2];
            // 1: 初始化CRC  0XFFFF
            int crc = 0xFFFF;
            for (int i = 0; i < data.Length - 2; i++)
            {
                // 将每一个字节与CRC进行异或运算
                crc = crc ^ data[i];
                // 当前字节8个位逐位处理
                for (int j = 0; j < 8; j++)
                {
                    // 临时变量，用于存储CRC的最低位
                    int tmp = 0;
                    // 最低位，1 or 0 1 表示需要异或多项式 0 不需要
                    tmp = crc & 0x0001;
                    // CRC右移一位 
                    crc = crc >> 1;

                    // 确保右移后最高位为0；不溢出
                    crc = crc & 0x7FFF;

                    // crc 最低位为1，则与0xA001进行异或运算
                    if (tmp == 1)
                    {
                        crc = crc ^ 0xA001;
                    }

                    // 保证crc 始终为16位 不溢出
                    crc = crc & 0xFFFF;
                }

            }
            crc16[0] = (byte)(crc & 0xFF); // CRC低字节
            crc16[1] = (byte)((crc >> 8) & 0xFF); // CRC高字节

            return crc16;
        }
        #endregion
    }
}
