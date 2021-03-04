# IPL-ROM 1.3 Patch for Xellent30

# 解説
IPL-ROM 1.3 Patch for Xellent30とは、Xellent30(s/PRO)を装着したX68000で利用するIPL-ROM 1.3へのパッチです。

このパッチを適用したIPL-ROM 1.3には以下の特徴があります。
* Xellent30の制御ツールであるch30.sysをSRAMに登録する必要がなくなる。
* デフォルトの動作CPUがMC68030になる。
* MC68000への切替はXF1キーを押下しながら電源オンかリセットボタンを押下することにより可能。
* ソフトウェアリセット時はリセット前の動作CPUを維持する。
* 拡張SRAMの開始アドレスは$FC0000固定となり、IPL-ROMのアクセス先が拡張SRAMとなる。
* XT30DRV.Xなど、Xellent30用のツールを利用できなくなる。

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
事前に以下のものを用意してください。
* 各種ツール
  DB.X、dis.x、テキストマージツール、HAS.X、hlk.r、CV.X

* X68030のIPL-ROM $fe0000～$ffffff

  X68030実機にてDB.Xを起動して以下のコマンドを入力する。  
  -w IPLROM30Xel.DAT,fe0000 ffffff

* UV-EPROM、EEPROM、FlashROM

  機種によって容量が異なります。  
  ACE、EXPERT、PROの場合は512Kbit(64K x 8bit、28PinDIP)  
  SUPERの場合は1Mbit(128K x 8bit、32PinDIP)  
  XVIの場合は(調査中...)  

  なお、SUPERのROMソケットは1MbitマスクROMを想定した28PinDIPですので、変換基板が必要です。  
  変換基板の作り方(作成中...)

* ROMライタ(TL866II Plusなど)
* X68000本体(Xellent30を装着可能な機種に限る)とXellent30

(1) X68030のIPL-ROM $fe0000～$ffffffを以下の名前でファイル化する。

IPLROM30Xel.DAT

(2) dis.xを以下のオプションで実行してソースコードを生成する。

dis IPLROM30Xel.DAT IPLROM30Xel.DAT.s -zfe0000,ff0038 -q -m680x0

(3) テキストマージツールで本パッチを適用する。

(4) 以下のオプションでソースコードをコンパイル、リンク、変換する。  
HAS.X -w2 -oIPLROM30Xel.DAT.o IPLROM30Xel.DAT.s  
hlk.r -b0xfe0000 -oIPLROM30Xel.DAT.x IPLROM30Xel.DAT.o  
CV.X /rn IPLROM30Xel.DAT.x IPLROM30Xel.DAT.r  
REN IPLROM30Xel.DAT.r IPLROM30Xel.DAT  

(5)ファイルをevenとoddに分割する。

(6)ROMライタで焼く。

(7)X68000に装着する。

(編集中...)

# 今後の野^H^H願望
* 030SYSPatchのROMパッチ部分を取り込む。
* IPL-ROM1.5に取り込まれる。(ォ

# 免責事項
このソフトウェアによって生じたいかなる損害も補償されません。
