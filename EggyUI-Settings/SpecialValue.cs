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
using System.IO;

namespace EggyUI_Settings
{
    // 特殊值
    public static class SpecialValue
    {
        // 使用懒加载和线程安全的方式初始化静态字段
        private static readonly Lazy<int> _ntVersion = new(() => Environment.OSVersion.Version.Major);
        private static readonly Lazy<int> _buildVersion = new(() => Environment.OSVersion.Version.Build);
        private static readonly Lazy<string> _system32Path = new(() => 
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System)));
        private static readonly Lazy<string> _sysWOW64Path = new(() => 
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86)));
        private static readonly Lazy<string> _gpeditMsc32bit = new(() => 
            Path.Combine(_sysWOW64Path.Value, "gpedit.msc"));
        private static readonly Lazy<string> _gpeditMsc64bit = new(() => 
            Path.Combine(_system32Path.Value, "gpedit.msc"));
        private static readonly Lazy<string> _lusrMgrMsc32bit = new(() => 
            Path.Combine(_sysWOW64Path.Value, "lusrmgr.msc"));
        private static readonly Lazy<string> _lusrMgrMsc64bit = new(() => 
            Path.Combine(_system32Path.Value, "lusrmgr.msc"));

        // NT内核版本
        public static int NTVersion => _ntVersion.Value;

        // 系统内部版本
        public static int BuildVersion => _buildVersion.Value;

        // System32目录
        public static string System32Path => _system32Path.Value;

        // SysWOW64目录
        public static string SysWOW64Path => _sysWOW64Path.Value;

        // 32位组策略编辑器目录
        public static string GpeditMsc32bit => _gpeditMsc32bit.Value;
        
        // 64位组策略编辑器目录
        public static string GpeditMsc64bit => _gpeditMsc64bit.Value;

        // 32位本地用户和组目录
        public static string LusrMgrMsc32bit => _lusrMgrMsc32bit.Value;

        // 64位本地用户和组目录
        public static string LusrMgrMsc64bit => _lusrMgrMsc64bit.Value;

        /// <summary>
        /// 获取有效的管理工具路径（优先64位，其次32位）
        /// </summary>
        /// <param name="toolName">工具名称（如：gpedit.msc, lusrmgr.msc）</param>
        /// <returns>有效的工具路径或null</returns>
        public static string? GetValidToolPath(string toolName)
        {
            string? path64bit = null;
            string? path32bit = null;

            switch (toolName.ToLower())
            {
                case "gpedit.msc":
                    path64bit = GpeditMsc64bit;
                    path32bit = GpeditMsc32bit;
                    break;
                case "lusrmgr.msc":
                    path64bit = LusrMgrMsc64bit;
                    path32bit = LusrMgrMsc32bit;
                    break;
            }

            if (path64bit != null && File.Exists(path64bit))
                return path64bit;
            
            if (path32bit != null && File.Exists(path32bit))
                return path32bit;
            
            return null;
        }
    }
}
