使用したコマンド解説

// dll作成のプロジェクトを作成するコマンド
dotnet new classlib -n PostgresDataAccess

// .NET プロジェクトに PostgreSQL 用の Entity Framework Core プロバイダーを追加するためのコマンド
// Entity Framework Core（EF Core）で PostgreSQL を使うための公式プロバイダー
// UseNpgsqlが使えるようになる
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

// Entity Framework Core の開発支援ツールをプロジェクトに追加する
dotnet add package Microsoft.EntityFrameworkCore.Design

// テスト用プロジェクトを作成する
dotnet new xunit -n PostgresDataAccess.Tests

// Entity Framework Core のインメモリデータベースプロバイダーを追加する
// メモリ上だけで動作するデータベースを追加
dotnet add package Microsoft.EntityFrameworkCore.InMemory

// .NET のテストプロジェクトを動かすための基盤パッケージを追加する
dotnet add package Microsoft.NET.Test.Sdk

// xUnit テストフレームワーク本体を追加
dotnet add package xunit

// xUnit テストを Visual Studio や .NET CLI で実行・検出できるようにするためのランナーを追加する
dotnet add package xunit.runner.visualstudio
