# C# 習作２：FLV→MP3ブッコ抜きプログラム 「幸魂（さちみたま）」

## ■要件
過去作成物を晒すプレイ。  
Microsoft Visual C# 2008 Express Editionで作ったもの。それだとなんなのでVisual C# 2013のプロジェクトにしました。  
このプログラムは、FLVファイルから音声部分をブッコ抜くプログラムです。  
複数のFLVファイルをドラッグ＆ドロップまたはFLVフルパス一覧情報ファイルで設定して、マルチスレッドでMP3に変換します。

技術的には、リストへのドラッグ＆ドロップ、変換の並列実行のためのマルチスレッド、非同期実行の終了時のイベント処理のためのdelegateを使っています。

## ■使用方法
.NET Framework（たぶん3.5以降）上で動作します。
注意：αバージョンNo.1版では、エラーケースを考慮していませんので、思わぬ例外が発生するかもしれません。
適宜直しておいてください。気が向いたら直します。

## ■使い方
起動して、リストビューにFLVファイルをドラッグ＆ドロップしてください。FLV欄にドロップしたファイル名（フルパス）が、MP3欄に出力するMP3ファイル名（フルパス）が表示されます。デフォルトの設定では、FLVファイルとおなじディレクトリにMP3ファイルが出力されます。
変換実行ボタンを押すと、変換が始まります。４Mバイトくらいなら一瞬で終わります。
FLVファイルの変換はマルチスレッドで実行します。複数のFLVファイルを変換するとき並行して変換処理が走ります。

変換し終わって次のFLVファイルを変換したいときは、メニューのファイルから「リストをクリア」を選択してリストを空にしてから、ドラッグ＆ドロップしてください。  
リストを選択してからDELキーを押すことでも消去は可能です。  
デフォルトでは、MP3ファイルが出力先にある場合は、上書きします。  

アプリケーションを終わる場合は、終了ボタンを押してください。変換中の場合は、終了できません。
何時まで経っても終了しない場合は、×マークを押して強制終了してください。

メニューのツールから設定が行えます。
書いてある通りなので、説明は割愛します。（気が向けば記述します）

## ■バージョン情報
### αバージョンNo.1　（2008/10/10リリース）
とりあえず動く版です。動作の保障はしません。自己判断で使用してください。
　・メニュー：ファイル→ログ出力は動作しません。
　・メニュー：ツール 「その他」タブのダブルクリックの設定は動作しません。
　・エラー周りはちゃんと実装されていません。変換結果が正常となっても、正しく変換されていないことが有ります。エラーとなった場合、エラーの原因は現状表示していません。
　・delegateによるマルチスレッドで変換処理を行っており、排他を行っているところがあります。もしかしたら不具合が出るかもしれません。（固まるとか、異常終了するとか）

## ■免責・お願い

本プログラムは、商用利用および個人利用、そして改造を自由に行ってくださってもかまいません。
ただし、C#の更なる発展のため、改造したソースは公開してください。
利用・改造の連絡は不要です。
なお、本プログラムの利用によりあなた、またはあなたの周囲に損害が発生しても、 当方は一切関知しません。

USE AT YOUR OWN RISK！

## ■履歴

αバージョンNo.1初版 ：2008/10/10：C#の勉強がてら、とりあえず動くかも知れないものを作った。まだ、実装していない機能があります。
