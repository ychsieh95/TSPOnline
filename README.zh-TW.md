<!-- markdownlint-disable MD041 -->
[English](README.md) | **繁體中文**

# TSPOnline

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4)
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
| 框架 | ASP.NET Core 8.0（Razor Pages，Runtime Compilation） |
| 資料存取 | [Dapper](https://github.com/DapperLib/Dapper) + SQLite（`TSPOnline/files/database/tsponline.db`） |
| 前端函式庫 | 透過 [LibMan](https://learn.microsoft.com/aspnet/core/client-side/libman/) 管理——jQuery、Bootstrap、Font Awesome 等 |
| 部署方式 | Docker／Docker Compose |

## 開發環境設置

### 前置需求

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### 設定檔

`TSPOnline/appsettings.json` 存放資料庫連線字串與 Google reCAPTCHA 金鑰，此檔案刻意不被版本控制追蹤（見 `.gitignore`），因此執行專案前需自行建立。可複製提供的範本並填入自己的數值：

```bash
cp TSPOnline/appsettings.example.json TSPOnline/appsettings.json
```

### 本機執行

```bash
cd TSPOnline
dotnet restore
dotnet run
```

預設會於 `https://localhost:5001` 與 `http://localhost:5000` 啟動，完整設定可參考 `Properties/launchSettings.json`。

## 專案結構

```text
TSPOnline/
├── Extensions/       # 擴充方法
├── HtmlGenerator/    # 自訂 HTML 產生器（如錯誤訊息提示）
├── Interfaces/       # 介面定義
├── Models/           # 資料模型與設定
├── Pages/            # Razor Pages，依資源類型分類（Monsters、Pets、Equipments…）
├── Repositorys/      # 資料存取層（Dapper）
├── files/database/   # SQLite 資料庫
└── wwwroot/          # 靜態資源（圖片、前端函式庫）
```

## 部署

### Docker

Build image：

```bash
docker build -t tsp-holey-cc -f Dockerfile .
```

Run container：

```bash
docker run -d -p 8200:8080 --name tsponline tsp-holey-cc
```

或使用 `docker-compose.yml` 啟動：

```bash
docker compose up -d
```

## 貢獻方式

歡迎提供遊戲資料、錯誤回報或任何建議，煩請直接給予 Pull Request，或來信至 [ychsieh95@gmail.com](mailto:ychsieh95@gmail.com)，感謝您的協助。

## References

* [吞食伊拉克](http://shota.ddns.net/)
* [DODO刷NPC大全集 - TS SOS](http://15963578.blogspot.tw/p/ctrlf.html)
* [吞食天地 On-Line - 巴哈姆特](https://forum.gamer.com.tw/A.php?bsn=5334)
