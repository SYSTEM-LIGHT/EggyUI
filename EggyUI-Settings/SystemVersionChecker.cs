/*
 * ============================================================================
 * EggyUI - Windows 桌面美化主题包
 * 基于网易《蛋仔派对》UI风格的粉丝二次创作，非官方、非商业项目
 * ============================================================================
 *  
 * 作者: 冷落的小情绪 (SYSTEM-LIGHT)
 * 贡献者: EggyUI 开发团队 (https://github.com/SYSTEM-LIGHT/EggyUI)
 * 
 * 版权所有 (c) 2024-2025 EggyUI 开发团队
 * 
 * 许可协议:
 * 本项目为粉丝创作，严禁用于任何商业用途。
 * 所有素材均为合法获取或自主重绘，未使用任何游戏解包内容。
 * 
 * 免责声明:
 * 1. 本软件与微软、网易无关，Windows 和《蛋仔派对》分别为其所属公司的注册商标。
 * 2. 使用者需自行承担因使用本软件可能带来的风险。
 * 3. 禁止对本软件进行商业性使用、分发或集成至商业产品中。
 * 
 * ============================================================================
 */

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
