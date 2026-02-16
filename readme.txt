【概要】
このサンプルプログラムはDIコンテナの概念を考慮し、実装しています。
・dll作成のプロジェクト(PostgresDataAccess)
  Modelsクラスで各データベースの構成とインタフェースを定義しています。
  合わせて、各データベースの情報をAppDbContextにまとめています。
  Repositoriesクラスでは各データベースで実施したい処理とインタフェースを定義しています。
    GetAll：すべてのレコードを取得
    GetById(int id)：指定したレコード番号の情報を取得
    Add(Category category)：データの追加
    Update(Category category)：データの更新
    Delete(int id)：データの削除
  また、各データベースの処理はファクトリに集約しています。
  これによりDIコンテナに登録するのはファクトリだけでOKになっています（のはず）
・バックエンドのプロジェクト(Backend)
  上記のdllのプロジェクトを参照しデータを取得します。
  バックエンドの処理が実行されると、Program.csの流れで処理されますが、、、
    builder.Services.AddRepositories(builder.Configuration);
      ここで、ファクトリの処理が実行され、dllのプロジェクトにおける各リポジトリ（～Repository）がDIコンテナに登録されます。
    builder.Services.AddControllers();
      ここで、Controllersフォルダ配下に実装した処理に従ってデータを取得します。
      UsersController.csを例にすると、GetAllでUsersテーブルのすべてのレコードを取得します。
      確認するときは
        GetAllは「localhost:5000/api/users」で確認できます
        GetByIdは「localhost:5000/api/users/1」で1番目のレコードを確認できます
  データの取得処理はServicesフォルダ配下に実装しています。
  フロント側に渡すデータのかたちはDtosフォルダ配下に実装しています。
・dllプロジェクトのテストプロジェクト（PostgresDataAccess.Tests）
  dllの動作確認する際に仮想のデータベースを作成して動作確認できるシロモノです。
  仮想なので実際にデータベースを用意する必要がなく、動作確認できます。
  サンプルでは仮想の「TestDb」というデータベースを作成し、Usersテーブルに1件データ登録するテストをしています。
  「dotnet test」コマンドで確認できます。


【使用したコマンド解説】

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

【はまったポイント】
dllでデータベースの値を取得していますが、スキーマ名やカラム名を小文字にマッピングしています。
これは（データベースによるかもしれませんが）大文字・小文字をちゃんと判断しているらしく、
勢いで作成したデータベースはすべて小文字、dllの処理は先頭だけ大文字としてしまっていたため、スキーマやカラムが参照できないという動きになりました。
そのため、明示的にマッピングするつくりになっています。

★ここからフロント側
// API 通信のため
npm install axios

develop側で追加した文字列です
これはテスト用に追加した文言です