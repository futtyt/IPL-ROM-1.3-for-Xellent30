# IPL-ROM 1.3 Patch for Xellent30

# 解説
IPL-ROM 1.3 Patch for Xellent30とは、Xellent30(s/PRO)を装着したX68000で利用するIPL-ROM 1.3へのパッチです。

このパッチを適用したIPL-ROM 1.3には以下の特徴があります。

【メリット】
* Xellent30の制御ツールであるch30.sysをSRAMに登録する必要がなくなる。
* デフォルトの動作CPUがMC68030になる。
* 起動画面表示中にXF2キー押下でMC68000へ、XF4キー押下でMC68030へ動作CPUを切替える。
* ソフトウェアリセット時はリセット前の動作CPUを維持する。
* SUPERでは内蔵SCSIも利用できる。(XVIは未確認)

【プラマイゼロ？】
* 拡張SRAMの開始アドレスは$FC0000固定となり、IPL-ROMのアクセス先が拡張SRAMとなる。(拡張SRAMを自由に使えなくなりますが、IPL-ROMへのアクセスが若干早くなります。)

【デメリット】
* XT30DRV.Xなど、Xellent30用のツールを利用できなくなる。
* 内蔵SASIを利用できなくなる。

https://youtu.be/Bep6caA0rm4  
0:00 電源ON 030  
0:35 リセットボタン押下 030  
1:10 ソフトウェアリセット 030  
1:45 XF1キー押しながらリセットボタン押下 030→000  
2:18 ソフトウェアリセット 000  
2:48 リセットボタン押下 000→030  

# 動作実績
以下の構成で動作することを確認しています。
* X68000 PRO + Xellent30PRO + W27C512 x 2
* X68000 SUPER + Xellent30s + W27E010 x 2

# 導入方法
1. 事前に以下のものを用意してください。
    * 各種ツール

        DB.X、dis.x、テキストマージツール、HAS.X、hlk.r、CV.X、bup.x

    * X68030のIPL-ROM $fe0000～$ffffff

        X68030実機にてDB.Xを起動して以下のコマンドを入力する。  
        ```-w IPLROM30Xel.DAT,fe0000 ffffff```

    * SCSI機の場合はX68030のROM30.DAT $fc0000～$fdffff

        X68030実機にてDB.Xを起動して以下のコマンドを入力する。  
        ```-w ROM30.DAT,fc0000 fdffff```

    * X68000のIPL-ROM $fe0000～$ffffff (6x12ドットフォント組込み用)

        X68000実機にてDB.Xを起動して以下のコマンドを入力する。  
        ```-w IPLROM.DAT,fe0000 ffffff```

    * UV-EPROM、EEPROM、FlashROM

        機種によって容量が異なります。  
        ACE、EXPERT、PROの場合は512Kbit(64K x 8bit、28pinDIP)  
        SUPER、XVIの場合は1Mbit(128K x 8bit、32pinDIP)  

        なお、SUPERのROMソケットは1MbitマスクROMを想定した28pinDIPですので、変換が必要です。  
        以下の図を参考にして結線してください。  
        ![1MbitROM](https://user-images.githubusercontent.com/79849812/109984038-bef76880-7d46-11eb-974c-343d74adccec.png)
        
        水色　：隣同士を結線する。</br>
        灰色　：どこにも結線しない。</br>
        その他：同じ色同士を結線する。</br>
        試作基板のKiCADデータをROM28toEPROM32フォルダに格納しました。

    * ROMライタ(TL866II Plusなど)
    * X68000本体(Xellent30を装着可能な機種に限る)とXellent30

1. ROMイメージの生成
    1. ソースコードを利用する場合
        1. dis.xを以下のオプションで実行してソースコードを生成する。
            ※0.0.5からdisのオプションが変わりましたので注意してください。
            ```
            dis -zfe0000,ff0038 -q -m680x0 --overwrite -h IPLROM30Xel.DAT IPLROM30Xel.DAT.s
            ```
        1. テキストマージツールで本パッチを適用する。
        1. 添付のMakefileでソースコードをコンパイル、リンク、変換する。
            Makefileを利用しない場合は以下のコマンドを実行する。
            ```
            hlk.r -b0xfe0000 -oIPLROM30Xel.DAT.x IPLROM30Xel.DAT.o
            CV.X /rn IPLROM30Xel.DAT.x IPLROM30Xel.DAT.r
            REN IPLROM30Xel.DAT.r IPLROM30Xel.DAT
            ```
    1. バイナリ差分を利用する場合
        1. バイナリ差分ファイルを適用する。

1. 6x12ドットフォントの組込み
    1. 同梱のxfontconvine.exeを利用してIPLROM30Xel.DATにIPLROM.DAT内の6x12ドットフォントを組込みます。

1. ROMイメージの書込みと装着
    1. SCSI機の場合はROM30.DATとIPLROM30Xel.DATを結合する。
    1. ファイルをevenとoddに分割する。</br>
        XgproであればROMイメージを読み込む際のオプション設定を変更することで省略可能です。</br>
        ![Xgpro_select_even](https://user-images.githubusercontent.com/79849812/110272224-031b8f00-800d-11eb-93f1-6bb20c9d2970.png)</br>
        even:「Load mode」を「Load a low byte of a WORD(2 bytes)」にする。</br>
        odd:「Load mode」を「Load a high byte of a WORD(2 bytes)」にする。
    1. ROMライタで焼く。
    1. X68000に装着する。
        evenとodd、ROMの向きに注意して装着する。</br>
        ROM切替え用のディップスイッチを切替える。

(編集中...)

# 今後の野^H^H願望
* 030SYSPatchのROMパッチ部分を取り込む。
* IPL-ROM1.5に取り込まれる。(ォ

# 免責事項
このソフトウェア、およびドキュメントによって生じたいかなる損害も補償されません。
