AS=HAS
LK=HLK
OBJ=IPLROM30Xel.DAT.o

IPLROM30Xel.DAT : IPLROM30Xel.DAT.r
	COMMAND ren IPLROM30Xel.DAT.r IPLROM30Xel.DAT

IPLROM30Xel.DAT.r : IPLROM30Xel.DAT.x
	CV /rn IPLROM30Xel.DAT.x IPLROM30Xel.DAT.r

IPLROM30Xel.DAT.x : $(OBJ)
	$(LK) -x -b0xfe0000 -oIPLROM30Xel.DAT.x -pIPLROM30Xel.DAT.map $(OBJ)

%.o : %.s
	$(AS) -u -w2 -o$*.o $<

