Uses crt;
Const fi='D:\SAMAC.INP';
      fo='D:\SAMAC.OUT';
      maxn=100;
Var a:array[1..maxn,0..maxn] of integer;
    b,c:array[1..maxn,1..maxn] of integer;
    m,n:integer;
Procedure Input;
Var f:text;
    i,j:integer;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,m,n);
 For i:=1 to m do
  Begin
   A[i,0]:=maxint;
   A[i,n+1]:=maxint;
  End;
 For i:=1 to m do
  Begin
   For j:=1 to n do Read(f,a[i,j]);
   Readln(f);
  End;
 Close(f);
End;
Function Min(i,j:integer):integer;
Var min1:integer;
Begin
 Min1:=abs(a[i,j]-a[i-1,j-1])+b[i-1,j-1];
 c[i,j]:=j-1;
 If min1>abs(a[i,j]-a[i-1,j])+b[i-1,j] then
  Begin
   min1:=abs(a[i,j]-a[i-1,j])+b[i-1,j];
   c[i,j]:=j;
  End;
 If min1>abs(a[i,j]-a[i-1,j+1])+b[i-1,j+1] then
  Begin
   c[i,j]:=j+1;
   min1:=abs(a[i,j]-a[i-1,j+1])+b[i-1,j+1];
  End;
  Min:=min1;
End;
Procedure Tao;
Var i,j:integer;
Begin
 Fillchar(b,sizeof(b),0);
 For i:=2 to m do
  For j:=1 to n do b[i,j]:=min(i,j);
End;
Procedure Output;
Var f:text;
    min1,j,i,t:integer;
Begin
 Assign(f,fo);Rewrite(f);
 min1:=b[m,1];
 t:=1;
 For i:=2 to n do
  If min1>b[m,i] then
   Begin
    min1:=b[m,i];
    t:=i;
   End;
 Writeln(f,min1);
 a[1,0]:=t;
 For i:=1 to m-1 do
  Begin
   t:=c[m+1-i,t];
   a[i+1,0]:=t;
  End;
 For i:=m downto 1 do
   Write(f,'(',m+1-i,',',a[i,0],') ');
 Close(f);
End;
Begin
 Input;
 Tao;
 Output;
End.
