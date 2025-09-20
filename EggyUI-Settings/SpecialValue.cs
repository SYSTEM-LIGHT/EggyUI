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

namespace EggyUI_Settings
{
    // 特殊值
    public static class SpecialValue
    {
        // 使用懒加载和线程安全的方式初始化静态字段
        private static Lazy<int> NTVersion_Lazy => new(() => Environment.OSVersion.Version.Major);
        private static Lazy<int> BuildVersion_Lazy => new(() => Environment.OSVersion.Version.Build);
        private static Lazy<string> System32Path_Lazy => new(() =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System)));
        private static Lazy<string> SysWOW64Path_Lazy => new(() =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86)));

        // NT内核版本
        public static int NTVersion => NTVersion_Lazy.Value;

        // 系统内部版本
        public static int BuildVersion => BuildVersion_Lazy.Value;

        // System32目录
        public static string System32Path => System32Path_Lazy.Value;

        // SysWOW64目录
        public static string SysWOW64Path => SysWOW64Path_Lazy.Value;

        // 判断系统是否为Win11
        public static bool IsWin11 => !((NTVersion < 10) && (BuildVersion < 22000));

        // 判断系统是否为Win10或Win11
        public static bool IsWin10OrWin11 => !(NTVersion < 10);

        /// <summary>
        /// 获取有效的管理工具路径（优先64位，其次32位）
        /// </summary>
        /// <param name="toolName">工具名称（如：gpedit.msc, lusrmgr.msc）</param>
        /// <returns>有效的工具路径或null</returns>
        public static string? GetValidToolPath(string toolName)
        {
            string? path64bit = Path.Combine(System32Path, toolName);
            string? path32bit = Path.Combine(SysWOW64Path, toolName);

            if (path64bit is not null && File.Exists(path64bit))
            {
                return path64bit;
            }
            else if (path32bit is not null && File.Exists(path32bit))
            {
                return path32bit;
            }
            else
            {
                return null;
            }
        }
    }
}
