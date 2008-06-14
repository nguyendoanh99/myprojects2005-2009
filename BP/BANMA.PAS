Uses crt;
Const Ai:array[1..8] of shortint=(-17,-15,-6,10,17,15,6,-10);
      tf='D:\BANCO.OU';
Var A:array[1..64,1..64] of 0..1;
Procedure KhoiTao;
Var i,j,c1,c2,d1,d2:byte;
    f:text;
Begin
 Fillchar(a,sizeof(a),0);
 {
 1  2  3  4  5  6  7  8
 9 10 11 12 13 14 15 16
17 18 19 20 21 22 23 24
25 26 27 28 29 30 31 32
33 34 35 36 37 38 39 40
41 42 43 44 45 46 47 48
49 50 51 52 53 54 55 56
57 58 59 60 61 62 63 64                                    }
 For i:=1 to 64 do
  Begin
   A[i,i]:=1;
   For j:=1 to 8 do
    Begin
     c1:=(i+ai[j]) mod 8;
     If c1=0 then c1:=8;
     c2:=i mod 8;
     If c2=0 then c2:=8;
     d1:=(i+ai[j]) div 8;
     If (i+ai[j])mod 8=0 then Dec(d1);
     d2:=i div 8;
     If i mod 8=0 then Dec(d2);
     If (i+ai[j]>0)and(((abs(c1-c2)=1)and(abs(d1-d2)=2))or((abs(c1-c2)=2)and(abs(d1-d2)=1))) then A[i,i+ai[j]]:=1
    End;
  End;
 Assign(f,tf);Rewrite(f);
 For i:=1 to 64 do
  Begin
   For j:=1 to 64 do Write(f,a[i,j]);
   Writeln(f)
  End;
 Close(f)
End;
Begin
 Clrscr;
  KhoiTao;
 Readln
End.
