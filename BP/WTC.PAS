Uses crt;
Const fi='C:\WTC.INP';
      fo='C:\WTC.OUT';
      maxn=10;
Var A:array[2..maxn] of integer;
    B1,B2:array[1..maxn] of integer;
    t,k1,k,i,d1,d2,m1,m2:integer;
Procedure Input;
Var i:integer;
    f:text;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,k);
 For i:=2 to k-1 do Read(f,A[i]);
 Close(f);
End;
Procedure Try(m:integer);
Var t1,i:integer;
Begin
 If m=1 then
  Begin
   If d1>d2 then
    Begin
     d2:=d1;
     m2:=m1;
     B2:=B1;
    End;
  End
 Else
  For i:=m downto 2 do
   Begin
    If k1-((t+15) div 10)>i then
     Begin
      t1:=t;
      Dec(k1,(t+15) div 10);
      t:=((t+15) mod 10)+1;
      Inc(d1,A[i]);
      Inc(m1);
      B1[m1]:=i;
      Try(i-1);
      t:=t1;
      Inc(k1,(t+15) div 10);
      Dec(d1,A[i]);
      B1[m1]:=0;
      Dec(m1);
     End;
   End;
End;
Procedure Output;
Var f:text;
    i:integer;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,d2);
 For i:=1 to m2 do
  Begin
   Write(f,B2[i],' ');
  End;
 Close(f);
End;
Begin
 Clrscr;
  Input;
  i:=k-1;
  m2:=1;
  m1:=0;
  d1:=0;
  d2:=0;
  While i>=m2 do
   Begin
    If k-((i+15) div 10)>i then
     Begin
      k1:=k-(i div 10);
      t:=i mod 10;
      Try(i);
     End;
    Dec(i);
   End;
  OutPut;
 Readln
End.