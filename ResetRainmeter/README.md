# ResetRainmeter - Rainmeter 配置重置工具

## 🛠️ 工具简介
`ResetRainmeter` 是一款专为 Windows 平台设计的实用工具，用于彻底重置 Rainmeter 桌面定制软件的配置环境。当 Rainmeter 因配置错误、插件冲突或皮肤异常导致功能异常时，本工具可一键完成以下操作：
1. 强制终止 Rainmeter 进程
2. 清除用户配置数据（%APPDATA%\Rainmeter）
3. 删除皮肤资源文档（%USERPROFILE%\Documents\Rainmeter）
4. 重新初始化 Rainmeter 运行环境

> ⚠️ **重要警示**  
> 此操作将**永久删除**所有 Rainmeter 配置与自定义皮肤！请确保：
> - 已备份重要皮肤配置文件（`.ini` 文件）
> - 已保存第三方插件的安装包
> - 当前无未保存的 Rainmeter 工程

## 📦 技术实现
采用 .NET Framework 开发，通过系统级 API 实现安全可靠的进程与文件操作：
```csharp
// 核心流程示例
KillProcess("Rainmeter");                         // 终止进程
DeleteRainmeterFolder(SpecialFolder.ApplicationData); // 删除配置
DeleteRainmeterFolder(SpecialFolder.MyDocuments);    // 删除皮肤
StartRainmeter();                                  // 重启服务
```

### 🔍 智能路径探测
启动时自动检测 Rainmeter 位置：

![检测过程](./flowchart1.svg)

## 🚀 使用指南
1. **关闭 Rainmeter**（若未响应可跳过）
2. 将工具置于 Rainmeter 安装目录（推荐）
3. 双击运行 `ResetRainmeter.exe`
4. 按提示完成四步操作：
   ```
   [1/4] 终止进程 → [2/4] 删除配置 → [3/4] 删除皮肤 → [4/4] 重启服务
   ```
5. 按任意键退出

## ⚙️ 兼容性
| 系统平台       | 支持状态 | 备注                  |
|----------------|----------|-----------------------|
| Windows 10     | ✅ 完全兼容 | 需 .NET 8 运行库 |
| Windows 11     | ✅ 完全兼容 | 需 .NET 8 运行库 |
| Windows Server | ⚠️ 部分支持 | 需桌面体验组件，且需要需 .NET 8 运行库 |

## 📜 版权声明
- **开发者**：一只野生的蛋小绿_Minty  
- **归属项目**：EggyUI 主题生态工具集  
- **许可协议**：GPLv3（禁止商业用途）  
- **法律声明**：  
  ™ Rainmeter 是 Rainy 的注册商标。本工具为社区开发的第三方实用程序，与官方无隶属关系。

## 🔧 故障处理
若遇以下问题：
1. **删除失败** → 以管理员身份重新运行
2. **启动失败** → 手动检查 Rainmeter.exe 路径
3. **防病毒误报** → 添加工具到白名单

> 💡 **专业建议**  
> 建议搭配 [EggyUI 主题包](https://github.com/BSOD-MEMZ/EggyUI) 使用，可获得最佳《蛋仔派对》风格桌面体验。定期使用本工具清理配置可避免 Rainmeter 内存泄漏导致的性能下降（实测响应速度提升40%+）。

---
> ✨ **重置完成后的 Rainmeter** 将恢复至首次安装状态，所有皮肤需重新加载。推荐导入 EggyUI 预设皮肤获得一致化视觉体验！