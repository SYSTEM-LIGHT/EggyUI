# EggyUI 设置程序

EggyUI 设置程序是 **EggyUI 桌面美化主题包**的核心控制中心，作为项目仓库的重要组成部分，它为用户提供了一站式的主题配置体验。该程序采用 .NET 8 开发，融合了现代语法特性，专为管理 EggyUI 的各类美化组件而设计。

---

## 🛠️ 核心功能模块
1. **Rainmeter 皮肤管理**
   - **开机自启控制**：通过计划任务实现 Rainmeter 的自动启动
   - **快捷操作**：
     - 打开 Rainmeter 安装目录
     - 访问皮肤文件夹
     - 安装 `.rmskin` 格式的皮肤包
     - **一键重置**：自动结束进程 → 删除配置 → 重启服务
   - 智能路径检测（支持自定义安装路径）

2. **文件夹背景定制**
   - **可视化预览**：随机加载背景图片并实时展示
   - **功能开关**：启用/禁用文件夹背景美化
   - **素材管理**：直达背景图片目录
   - 支持常见图片格式（JPG/PNG）

3. **系统增强工具集成**
   - **开始菜单定制**：
     - StartAllBack 配置（Win11 专属）
     - Start11 配置（Win10/Win11 通用）
   - **系统工具直达**：
     - 控制面板
     - 个性化设置
     - 组策略编辑器（自动检测系统版本）
     - 本地用户和组（家庭版智能禁用）

4. **项目信息与支持**
   - **版本展示**：动态加载版本图片和说明文件
   - **社区链接**：
     - [官方 B 站主页](https://space.bilibili.com/3546563248916693)
     - [交流群入口](https://eggyui.neocities.org/support)
     - [项目官网](https://eggyui.neocities.org/)（[另一个官网](https://eggyui.mysxl.cn/)）
     - [开发者 B 站主页](https://space.bilibili.com/1591761987)

---

## ⚙️ 技术亮点
1. **现代化架构**
   - 采用 .NET 8 的 `new()` 类型推断语法
   - 使用 `Span<T>` 优化内存分配
   - 线程安全随机数生成器（替代传统 `Random` 类）

2. **健壮性设计**
   - **异常防御**：所有操作均包含 try-catch 保护
   - **路径自适应**：
     - 自动处理 `%USERPROFILE%` 环境变量
     - 支持 32/64 位系统路径检测（`System32`/`SysWOW64`）
   - **版本兼容**：智能禁用家庭版不可用功能

3. **高效资源管理**
   - 异步线程加载版本信息（避免 UI 阻塞）
   - 图片资源自动释放（防止内存泄漏）
   - XML 配置系统（`Settings.xml` 存储路径信息）

4. **部署优化**
   - 通过 `schtasks.exe` 管理计划任务（全版本 Windows 兼容）

---

## 📦 配置文件示例
```xml
<!-- Settings.xml -->
<Settings>
  <RainmeterPath>L:\EggyCore\Rainmeter</RainmeterPath>
  <RainmeterSkinPath>%USERPROFILE%\Documents\Rainmeter\Skins</RainmeterSkinPath>
  <FolderBackgroundPath>L:\EggyCore\FolderBackground</FolderBackgroundPath>
  <StartAllBackPath>C:\Program Files\StartAllBack</StartAllBackPath>
  <Start11Path>C:\Program Files (x86)\Stardock\Start11</Start11Path>
</Settings>
```

---

## 🌐 生态定位
作为 EggyUI 主题包的管理中枢，此程序完美体现了项目的核心原则：
- **非商业化**：永久免费，禁止任何商业用途
- **合法性**：所有素材均通过合法渠道获取或团队重绘
- **用户友好**：将复杂的系统美化配置简化为直观的图形操作
- **持续进化**：为未来独立安装包（不修改系统文件）奠定基础

> 💡 提示：该程序需配合 EggyUI 3.5 及以上版本使用，建议部署于纯净 Windows 系统以获得最佳体验。项目严格遵守粉丝创作准则，与微软无官方关联。