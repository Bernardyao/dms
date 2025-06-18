# 🏠 DMS - 宿舍管理系统

## 📋 项目简介

DMS (Dormitory Management System) 是一个基于 C# WinForms 开发的现代化宿舍管理系统，提供完整的学生宿舍管理解决方案。

## ✨ 主要功能

### 🏠 宿舍管理
- 宿舍信息录入和维护
- 房间分配管理
- 床位使用情况查询
- 空床位检索功能

### 👥 学生管理
- 学生基本信息管理
- 学生入住登记
- 信息查询和修改
- 学生档案维护

### 🚪 进出管理
- 学生进出宿舍登记
- 访客登记管理
- 进出记录查询
- 安全监控功能

### 👑 系统管理
- 管理员账户管理
- 用户权限控制
- 密码修改功能
- 系统配置设置

## 🛠️ 技术栈

- **开发语言**: C# (.NET Framework 4.8)
- **UI框架**: Windows Forms
- **数据库**: SQL Server (LocalDB)
- **开发工具**: Visual Studio
- **版本控制**: Git

## 🎨 界面特色

- **现代化设计**: 扁平化UI，简洁美观
- **配色方案**: 专业的蓝色主调
- **响应式布局**: 适配不同屏幕尺寸
- **用户体验**: 直观操作，友好提示

## 🚀 快速开始

### 环境要求
- Windows 7/8/10/11
- .NET Framework 4.8+
- SQL Server LocalDB 或 SQL Server Express

### 安装步骤

1. **克隆项目**
   ```bash
   git clone https://github.com/Bernardyao/dms.git
   cd dms
   ```

2. **打开项目**
   - 使用 Visual Studio 打开 `dms.sln`
   - 或使用 VS Code 打开项目文件夹

3. **配置数据库**
   - 数据库文件位于 `DbFile/` 文件夹
   - 系统会自动连接到 LocalDB

4. **编译运行**
   ```bash
   # 使用 MSBuild 编译
   MSBuild dms.csproj /p:Configuration=Release
   
   # 或在 Visual Studio 中按 F5 运行
   ```

5. **登录系统**
   - 使用管理员账户登录
   - 开始使用宿舍管理功能

## 📂 项目结构

```
dms/
├── 📄 Program.cs              # 程序入口点
├── 📄 Form1.cs               # 主窗体逻辑
├── 📄 Form1.Designer.cs      # 主窗体设计
├── 📄 Login.cs               # 登录窗体
├── 📄 ConnectDB.cs           # 数据库连接
├── 📄 DataAccess.cs          # 数据访问层
├── 📄 App.config             # 应用配置
├── 📁 DbFile/                # 数据库文件
│   ├── dms.mdf               # 主数据库
│   └── dms_log.ldf           # 事务日志
├── 📁 Properties/            # 程序集属性
└── 📄 README.md              # 项目说明
```

## 🖼️ 界面截图

### 登录界面
- 安全的用户认证
- 权限级别控制

### 主界面
- 清晰的功能模块划分
- 现代化的UI设计

### 数据管理
- 直观的表格显示
- 强大的查询功能

## 🔧 配置说明

### 数据库配置
- 默认使用 SQL Server LocalDB
- 连接字符串在 `ConnectDB.cs` 中配置
- 支持自定义数据库连接

### 用户权限
- **管理员 (权限级别 2)**: 所有功能访问权限
- **普通用户 (权限级别 1)**: 基础查询功能
- **访客 (权限级别 0)**: 只读访问

## 🤝 贡献指南

欢迎提交 Issue 和 Pull Request！

1. Fork 本项目
2. 创建功能分支 (`git checkout -b feature/AmazingFeature`)
3. 提交更改 (`git commit -m 'Add some AmazingFeature'`)
4. 推送到分支 (`git push origin feature/AmazingFeature`)
5. 开启 Pull Request

## 📝 更新日志

### v1.0.0 (2025-06-19)
- ✨ 完整的宿舍管理功能
- 🎨 现代化UI设计
- 🔒 安全的用户认证
- 📊 数据查询和统计
- 🧹 代码优化和清理

## 📄 许可证

本项目采用 MIT 许可证 - 查看 [LICENSE](LICENSE) 文件了解详情

## 👨‍💻 作者

- **Bernardyao** - [GitHub](https://github.com/Bernardyao)

## 🙏 致谢

感谢所有为这个项目做出贡献的开发者！

## 📞 联系方式

如果你有任何问题或建议，请通过以下方式联系：

- 📧 Email: [bernardyao624@gmail.com]
- 🐛 Issues: [GitHub Issues](https://github.com/Bernardyao/dms/issues)

---

⭐ 如果这个项目对你有帮助，请给个 Star！
