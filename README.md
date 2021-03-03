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

# 動作実績
以下の構成で動作することを確認しています。
* X68000 PRO + Xellent30PRO + W27C512*2
* X68000 SUPER + Xellent30s + W27E010*2

# 導入方法
事前に以下のものを用意してください。
* X68030のIPL-ROM $fe0000～$ffffff
* UV-EPROM、EEPROM、FlashROM
* ROMライタ
* X68000本体(Xellent30を装着可能な機種に限る)
* Xellent30
* dis.x、HAS.X、hlk.r、CV.X
(編集中...)

# 免責事項
このソフトウェアによって生じたいかなる損害も補償されません。
