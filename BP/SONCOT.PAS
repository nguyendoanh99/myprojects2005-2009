Uses crt;
Const fi='C:\SONCOT.INP';
      fo='C:\SONCOT.OUT';
      maxn=3;
Var A:array[1..maxn,1..maxn] of integer;
    d,max,i,j,m,n:byte;
Procedure Input;
Var i,j:byte;
    f:text;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n,m);
 For i:=1 to n do
  Begin
   For j:=1 to m do Read(f,A[i,j]);
   Readln(f);
  End;
 Close(f);
End;
Procedure Output;
var f:text;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,d+m*n);
 Writeln(d+m*n);
 Close(f);
End;
Begin
 Clrscr;
 Input;
 For i:=1 to n do
  Begin
   Max:=A[i,1];
   For j:=2 to m do
    If Max<A[i,j] then Max:=A[i,j];
   Inc(d,max*2);
  End;
 For i:=1 to m do
  Begin
   Max:=A[1,i];
   For j:=2 to n do
    If Max<A[j,i] then Max:=A[j,i];
   Inc(d,max*2);
  End;
 Output;
 Readln;
End.