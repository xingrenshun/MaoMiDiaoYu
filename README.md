# 星岛闯关之旅（幽谷猫钓鱼）

抖音小游戏《星岛闯关之旅》的 **Unity 工程源码**。单指操作的休闲垂钓闯关玩法：
白猫站在瀑布深潭边甩钩，钩取水下的鱼、水母、螃蟹、海星与带刺海胆，
收集四色宝石和钱袋，在限时内达到目标分数过关。

## 工程信息

| 项目 | 说明 |
| --- | --- |
| 引擎版本 | Unity 2022.3.48f1c1 |
| 脚本语言 | C#（Assets/Scripts） |
| 目标平台 | 抖音小游戏（tt-minigame / Stark SDK） |
| 主要插件 | TextMeshPro、OPS Obfuscator、ByteGame SDK |

## 目录结构

```
Assets/Scripts      玩法脚本（钓钩摆动、猎物收线、关卡目标、商店道具、排行榜）
Assets/Scenes       主菜单、关卡 Level1–10、商店、结算等场景
Assets/Textures     角色、鱼群、宝石、UI 贴图
Assets/Prefabs      鱼群/道具预制体
Assets/Fonts        TMP 中文字体资源
Assets/Sounds       背景音乐与音效
ProjectSettings     工程设置
Packages            依赖清单
game.json / project.config.json   抖音小游戏配置
```

## 玩法要点

- 钓钩左右摆动，点击屏幕甩出，命中目标自动收线
- 猎物越大、带刺越多，收线越慢（金币与分数越高）
- 每关限时约 60 秒，第 1 关 800 分、第 2 关 2050 分达标
- 商店每次随机上架三件道具：力量药水、宝石书、时钟、炸药
- 看广告领 500 金币，另有排行榜、侧边栏入口、音效开关

## 打开方式

1. 用 Unity Hub 添加本目录，使用 **2022.3.48f1c1** 打开
2. 首次打开会自动重建 `Library`（未纳入版本库）
3. 切换到抖音小游戏平台后通过 ByteGame 面板构建

## 版本库说明

本仓库只保存源码与必要资源，以下内容已通过 `.gitignore` 排除：
`Library/`、`Temp/`、`Build/`、`webgl/`、`tt-minigame/`、`wasm_symbols/`、
`webgl_package-*.zip`、`Logs/`、`obj/`、自动生成的 `.csproj` / `.sln`。

> 注：`Assets/Fonts/SIMHEI SDF.asset` 约 64 MB，超过 GitHub 50 MB 的建议上限但低于 100 MB 硬限制，
> 克隆时请留意仓库体积。
