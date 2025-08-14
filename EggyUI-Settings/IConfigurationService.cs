using System;

namespace EggyUI_Settings
{
    /// <summary>
    /// 配置服务接口，负责处理配置文件的读取和写入
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// 加载配置
        /// </summary>
        void LoadConfiguration();

        /// <summary>
        /// 创建默认配置
        /// </summary>
        void CreateDefaultConfig();

        /// <summary>
        /// 保存配置
        /// </summary>
        // 此方法暂时用不到，先注释掉
        // void SaveConfiguration();

        /// <summary>
        /// Rainmeter路径
        /// </summary>
        string RainmeterPath { get; set; }

        /// <summary>
        /// Rainmeter皮肤路径
        /// </summary>
        string RainmeterSkinPath { get; set; }

        /// <summary>
        /// 文件夹背景目录
        /// </summary>
        string FolderBackgroundPath { get; set; }

        /// <summary>
        /// StartAllBack路径
        /// </summary>
        string StartAllBackPath { get; set; }

        /// <summary>
        /// Start11路径
        /// </summary>
        string Start11Path { get; set; }
    }
}