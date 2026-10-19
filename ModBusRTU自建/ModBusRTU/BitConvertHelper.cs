using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NModBusRTU
{
    public class BitConvertHelper
    {
        /// <summary>
        /// 将bool数组转换为byte数组
        /// </summary>
        /// <param name="boolArray"></param>
        /// <returns></returns>
        public static byte[] BoolArrayToByteArray(bool[] boolArray)
        {
            if (boolArray == null || boolArray.Length == 0) throw new ArgumentNullException("参数不能为空");
            int length = (boolArray.Length + 7) / 8;
            byte[] byteArray = new byte[length];
            // 将字节按位计算，需要给1个字节中的每个位都有一个编号
            // 唯一标识就是二进制的识别符，也就是索引
            // 索引 0 最右边的第一位
            // 索引 1 右边第二位
            // ......
            // 索引 7 最左边第一位，从右往左的最后一位

            // 因为需要求bool数组中，每个元素对应字节中第几个位，如果bool数组中位数不是8的倍数，高位补0
            for (int i = 0; i < boolArray.Length; i++)
            {
                // i 表示 bool 值在数组中的索引值
                if (boolArray[i])
                {
                    // 在哪个字节
                    int byteIndex = i / 8;
                    // 在字节的哪个位
                    int bitIndex = i % 8;
                    /// 1 << bitIndex 表示掩码
                    /// bitIndex = 0, 1 << 0 = 0000 0001
                    /// bitIndex = 1, 1 << 1 = 0000 0010
                    /// bitIndex = 2, 1 << 2 = 0000 0100
                    /// bitIndex = 3, 1 << 3 = 0000 1000
                    /// bitIndex = 4, 1 << 4 = 0001 0000
                    /// bitIndex = 5, 1 << 5 = 0010 0000
                    /// bitIndex = 6, 1 << 6 = 0100 0000
                    /// bitIndex = 7, 1 << 7 = 1000 0000
                    /// 找出字节中，哪个位置为1，将它变成1
                    byte mark = (byte)(1 << bitIndex);

                    /// 0001 0010 当前字节的二进制数值
                    /// 0000 0100 掩码
                    /// -------------- |
                    /// 0001 0000 结果
                    byteArray[byteIndex] |= mark;
                }
            }
            return byteArray;
        }

        /// <summary>
        /// 将byte数组转换为bool数组
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool[] ByteArrayToBoolArray(byte[] byteArray,int count)
        {
            if (byteArray == null || byteArray.Length == 0) throw new ArgumentNullException("参数不能为空");
            bool[] boolArray = new bool[count];
            for (int i = 0; i < count; i++)
            {
                int byteIndex = i / 8;
                int bitIndex = i % 8;
                boolArray[i] = (byteArray[byteIndex] & (1 << bitIndex)) != 0;
            }
            return boolArray;
        }
    }
}
