using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggyUI_Settings
{
    // 特殊值
    readonly struct SpecialValue
    {
        // NT内核版本
        public static int NTVersion = Environment.OSVersion.Version.Major;

        // 系统内部版本
        public static int BuildVersion = Environment.OSVersion.Version.Build;

        // System32目录（Environment.SpecialFolder.System是System32目录）
        public static string System32Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System));

        // SysWOW64目录（Environment.SpecialFolder.SystemX86是SysWOW64目录）
        public static string SysWOW64Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86));

        // 32位组策略编辑器
        public static string GpeditMsc32bit = Path.Combine(SysWOW64Path, "gpedit.msc");
        
        // 64位组策略编辑器
        public static string GpeditMsc64bit = Path.Combine(System32Path, "gpedit.msc");

        // 32位本地用户和组
        public static string LusrMgrMsc32bit = Path.Combine(SysWOW64Path, "lusrmgr.msc");

        // 64位本地用户和组
        public static string LusrMgrMsc64bit = Path.Combine(System32Path, "lusrmgr.msc");
    }
}
