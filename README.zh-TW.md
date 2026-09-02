<!-- markdownlint-disable MD041 -->
[English](README.md) | **繁體中文**

# TSPOnline

![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4)
![License: CC BY-NC-SA 4.0](https://img.shields.io/badge/License-CC%20BY--NC--SA%204.0-lightgrey)

TSPOnline 是一個由社群維護的**吞食天地完美版**資源網站，收錄了怪物、寵物、裝備、材料、礦石、任務、地圖等遊戲內資料，供玩家查詢使用。

**[Live Demo](https://tsp.holey.cc)**

![Homepage](https://imgur.com/zhrT8Zo.png)

## 目錄

* [網站內容聲明](#網站內容聲明)
* [網站資料授權](#網站資料授權)
* [技術棧](#技術棧)
* [開發環境設置](#開發環境設置)
  * [前置需求](#前置需求)
  * [設定檔](#設定檔)
  * [資料庫](#資料庫)
  * [本機執行](#本機執行)
* [專案結構](#專案結構)
* [部署](#部署)
  * [Docker](#docker)
* [貢獻方式](#貢獻方式)
* [References](#references)

## 網站內容聲明

網站資料內容來源為 [References](#references) 中所列，並作部分修改（文字勘誤、潤飾）而成，不主張對原遊戲及其素材擁有任何權利。

若有侵權，還煩請給予 Pull Request 或來信至 [ychsieh95@gmail.com](mailto:ychsieh95@gmail.com) 聯繫告知，網站將立即下架該內容。

## 網站資料授權

除已明確標示出處之資料（如部分武將圖片）外，其餘內容皆以 **CC BY-NC-SA 4.0** 授權。

![CC BY-NC-SA 4.0](https://i.creativecommons.org/l/by-nc-sa/4.0/80x15.png)

完整授權範圍詳見網站所列。

## 技術棧

| 層級 | 技術 |
| --- | --- |
| 框架 | ASP.NET Core 10.0（Razor Pages，Runtime Compilation） |
| 資料存取 | [Dapper](https://github.com/DapperLib/Dapper) + SQLite（`files/database/tsponline.db`） |
| 前端函式庫 | 透過 [LibMan](https://learn.microsoft.com/aspnet/core/client-side/libman/) 管理——jQuery、Bootstrap、Bootstrap Toggle、Font Awesome |
| 部署方式 | Docker／Docker Compose |

## 開發環境設置

### 前置需求

* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* [Docker](https://docs.docker.com/get-docker/)——僅[部署](#部署)章節的容器流程需要

### 設定檔

版本庫內的 `appsettings.json` 僅包含本機 SQLite 連線設定，不含任何機密；`appsettings.example.json` 則保留一份相同結構的範例。

需要覆寫設定時，請使用環境變數，或依環境建立 `appsettings.{Environment}.json`——例如 `appsettings.Development.json`，當 `ASPNETCORE_ENVIRONMENT=Development`（啟動設定檔預設值）時 ASP.NET Core 會自動載入，且該檔案已被 Git 忽略。環境變數中的巢狀設定以兩個底線分隔，例如：

```bash
ConnectionStrings__DefaultConnection='Data Source=/data/tsponline.db' dotnet run
```

### 資料庫

不需要手動建立資料庫。應用程式啟動時會將設定中的 `Data Source` 解析為相對於 content root 的路徑、建立所需目錄，並在資料庫檔案尚未存在時，複製隨附的 `files/database/tsponline.seed.db`，讓網站一啟動就具備參考資料。接著會以 `CREATE TABLE IF NOT EXISTS` 套用 schema，因此即使沒有 seed，也會得到一個結構正確的空資料庫。

自動產生的執行期資料庫與 SQLite sidecar 檔案都不會提交至 Git，版本庫中只追蹤 seed。

### 本機執行

```bash
dotnet restore
dotnet run
```

預設會於 `https://localhost:5001` 與 `http://localhost:5000` 啟動，完整設定可參考 `Properties/launchSettings.json`。

## 專案結構

```text
├── Docker/           # Dockerfile 與 Compose 設定
├── Extensions/       # 擴充方法
├── HtmlGenerator/    # 自訂 HTML 產生器（如錯誤訊息提示）
├── Infrastructure/   # 啟動基礎設施（資料庫初始化與 schema）
├── Interfaces/       # Repository 介面定義
├── Models/           # 資料模型與設定
├── Pages/            # Razor Pages，依資源類型分類（Monsters、Pets、Equipments…）
├── Properties/       # 本機啟動設定檔
├── Repositorys/      # 資料存取層（Dapper）
├── files/database/   # 隨附的 seed 資料庫與自動產生的執行期資料庫
├── wwwroot/          # 靜態資源（圖片、LibMan 管理的前端函式庫）
├── Program.cs        # 進入點與請求管線設定
├── appsettings.json  # 預設設定（本機 SQLite 連線字串）
├── libman.json       # LibMan 前端函式庫清單
└── TSPOnline.csproj
```

## 部署

### Docker

於版本庫根目錄 build image：

```bash
docker build -t tsp-holey-cc -f Docker/Dockerfile .
```

Run container：

```bash
docker run -d -p 8080:8080 --name tsponline tsp-holey-cc
```

容器監聽 `8080` 埠。映像檔以 .NET 基底映像的非 root 使用者 `APP_UID` 執行（本專案使用的 .NET 10 Linux 映像預設為 `1654`），且發布內容歸該使用者所有，讓應用程式能安全建立執行期資料庫。

或使用內附的 `Docker/compose.yaml` 啟動；它會以版本庫根目錄為 build context，並將執行期資料庫保存在本機的 `files/database` 目錄：

```bash
docker compose -f Docker/compose.yaml up -d
```

請勿提交正式環境機密或執行期資料庫。若機密曾被提交，除了從目前設定移除外也必須立即輪替；加入 `.gitignore` 並不會從 Git 歷史中刪除既有內容。

## 貢獻方式

歡迎提供遊戲資料、錯誤回報或任何建議，煩請直接給予 Pull Request，或來信至 [ychsieh95@gmail.com](mailto:ychsieh95@gmail.com)，感謝您的協助。

## References

* [吞食伊拉克](http://shota.ddns.net/)
* [DODO刷NPC大全集 - TS SOS](http://15963578.blogspot.tw/p/ctrlf.html)
* [吞食天地 On-Line - 巴哈姆特](https://forum.gamer.com.tw/A.php?bsn=5334)
