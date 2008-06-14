{Qui hoach dong}
Uses crt;
Const fi='D:\INPUT.TXT';
      fo='D:\OUTPUT.TXT';
Var a:array[1..100,0..102] of integer;
    n:byte;
Procedure Input;
Var f:text;
    i,j:byte;
Begin
 ASsign(f,fi);Reset(f);
 Readln(f,n);
 For i:=1 to n do
  Begin
   A[i,0]:=-1;
   A[i,i+1]:=-1;
   For j:=1 to i do Read(f,a[i,j]);
   Readln(f);
  End;
 Close(f);
End;
Function Max(x,y:integer):integer;
Begin
 If A[x,y]>A[x,y-1] then
  Begin
   Max:=A[x,y];
   A[n-x,n+3-y]:=y
  End
 Else
  Begin
   Max:=A[x,y-1];
   A[n-x,n+3-y]:=y-1
  End;
End;
Procedure Tao;
Var i,j:byte;
Begin
 A[n,n+2]:=1;
 For i:=2 to n do
  For j:=1 to i do A[i,j]:=Max(i-1,j)+A[i,j];
 For i:=1 to n do    Begin
  For j:=1 to n+2 do Write(a[i,j]:3,' ');Writeln;End;
End;
Procedure Output;
Var f:text;
    i,k:byte;
    m:integer;
Begin
 Assign(f,fo);Rewrite(f);
 M:=A[n,1];
 k:=1;
 For i:=2 to n do
  If m<a[n,i] then
   Begin
    M:=a[n,i];
    k:=i;
   End;
 Writeln(f,m);
 Write('(',n,',',k,') ');
 k:=A[1,n+3-k];
 For i:=2 to n do
  Begin
   Write('(',n+1-i,',',k,') ');
   k:=A[i,n+3-k];
  End;
 Close(f);
End;
Begin
 Input;
 Tao;
 Output;
End.
{Vet can}
{Uses crt;
Const fi='D:\INPUT.TXT';
      fo='D:\OUTPUT.TXT';
Var a:array[1..100,1..100] of byte;
    t1,t2:integer;
    n:byte;
Procedure Input;
Var f:text;
    i,j:byte;
Begin
 ASsign(f,fi);Reset(f);
 Readln(f,n);
 For i:=1 to n do
  Begin
   For j:=1 to i do Read(f,a[i,j]);
   Readln(f);
  End;
 Close(f);
End;
Procedure Try(y,x:byte);
Begin
 If y>n then
  Begin
   If t1>t2 then t2:=t1;
  End
 Else Begin
 Inc(t1,A[y,x]);
 Try(y+1,x);
 Try(y+1,x+1);
 Dec(t1,A[y,x]); End;
End;
Procedure Output;
Var f:text;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,t2);
 Close(f);
End;
Begin
 Input;
 t1:=0;
 t2:=0;
 Try(1,1);
 Output;
End.
}