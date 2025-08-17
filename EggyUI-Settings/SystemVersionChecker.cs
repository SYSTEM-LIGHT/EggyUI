// 这个模块是用AI写的（AI太好用了，你们知道吗？）
// 这个模块的功能是检查系统是否为家庭版
// 这个模块的原理是通过查询Win32_OperatingSystem类的OperatingSystemSKU属性来判断系统是否为家庭版
// 这个模块的返回值是一个bool值，true表示系统为家庭版，false表示系统不为家庭版
// 这个模块的使用方法是：
//     SystemVersionChecker.IsHomeEdition()
// 这个模块的注意事项是：
//     1. 这个模块只能在Windows系统上运行
//     2. 这个模块需要管理员权限才能运行

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace EggyUI_Settings
{
    internal class SystemVersionChecker
    {
        public static bool IsHomeEdition()
        {
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject os in searcher.Get().Cast<ManagementObject>())
                {
                    int sku = Convert.ToInt32(os["OperatingSystemSKU"]);
                    return IsHomeSKU(sku);
                }
            }
            catch
            {
                // 处理异常
            }
            return false;
        }

        private static bool IsHomeSKU(int sku)
        {
            // 常见的家庭版SKU值
            int[] homeSkus = [
            2,   // Home Basic
            3,   // Home Premium
            5,   // Home Basic N
            26,  // Home Premium N
            11,  // Starter
            42,  // Starter N
            101, // Windows 10/11 Home
            98,  // Windows 10/11 Home N
            99,  // Windows 10/11 Home China
            100  // Windows 10/11 Home Single Language
        ];

            return Array.Exists(homeSkus, homeSku => homeSku == sku);
        }
    }
}
