using System;
using System.Collections.Generic;
using System.Text;

namespace TaoDuLieuDictionary
{
    class CFunctions
    {
        // Chuyển số num thành mảng các byte
        // count: chiều dài của mảng byte
        public static byte[] GetBytes(int num, int count)
        {
            byte[] result = new byte[count];
            for (int i = count - 1; i >= 0; --i)
            {
                result[i] = (byte) (num & 0xFF);
                num >>= 8;
            }
            return result;
        }
        // Chuyển một số được lưu trong mảng byte thành số kiểu int
        // arr[0]:  byte cao nhất
        // arr[arr.Length]: byte thấp nhất
        public static int GetInt(byte[] arr)
        {
            return GetInt(arr, 0, arr.Length);
        }
        public static int GetInt(byte[] arr, int index, int count)
        {
            int result = 0;

            for (int i = index; i < index + count; ++i)
            {
                result <<= 8;
                result |= arr[i];
            }
            return result;
        }
    }
}
