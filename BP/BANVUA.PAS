Uses crt;
Const Ai:array[1..8] of shortint=(-9,-8,-7,1,9,8,7,-1);
      tf='D:\BANCO.OU';
Var A:array[1..64,1..64] of 0..1;
Procedure KhoiTao;
Var i,j:byte;
    f:text;
Begin
 Fillchar(a,sizeof(a),0);
 For i:=1 to 64 do
  Begin
   A[i,i]:=1;
   For j:=1 to 8 do
    If ((i=1)and not(j in [1..3,7,8]))or((i=8)and not(j in [1..5]))
     or((i=57)and not(j in [1,5..8]))or((i=64)and not(j in [3..7]))
     or(not(i in [1,8])and(i div 9=0)and not (j in [1..3]))
     or(not(i in [8,64])and(i mod 8=0)and not(j in [3..5]))
     or(not(i in [64,57])and(i div 9=7)and not(j in [5..7]))
     or(not(i in [57,1])and(i mod 8=1)and not(j in [1,7,8])) then
        A[i,i+ai[j]]:=1
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
1 9 17 25 33 41 49 57