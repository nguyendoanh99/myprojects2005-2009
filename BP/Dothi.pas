Uses crt;
Const fi='D:\DOTHI.INP';
      fo='D:\DOTHI.OUT';
      maxn=100;
Var A:array[1..maxn,1..maxn] of integer;
    B:array[1..maxn,1..maxn] of byte;
    C:array[1..maxn] of byte;
    i,x,y,d,n:byte;
Procedure Input;
Var f:text;
    i,j:integer;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n);
 For i:=1 to n do
  Begin
   For j:=1 to n do
    Begin
     Read(f,a[i,j]);
     B[i,j]:=0;
     If (i<>j)and(a[i,j]=0) then a[i,j]:=maxint div 2;
    End;
   Readln(f);
  End;
 Close(f);
End;
Procedure Floyld;
Var k,i,j:integer;
Begin
 For k:=1 to n do
  For i:=1 to n do
   For j:=1 to n do
    If a[i,k]+a[k,j]<a[i,j] then
     Begin
      A[i,j]:=a[i,k]+a[k,j];
      B[i,j]:=k;
     End;
 For i:=1 to n do  Begin
  For j:=1 to n do Write(a[i,j]:6,' ');Writeln; End;
  Writeln;
 For i:=1 to n do  Begin
  For j:=1 to n do Write(b[i,j]:6,' ');Writeln; End;
End;
Function TimDuong(x,y:byte;var d:byte):boolean;
Var i,j:integer;
    ok:boolean;
Begin
 If a[x,y]=maxint div 2 then
  Begin
   TimDuong:=false;
   exit;
  End;
 c[1]:=x;
 c[2]:=y;
 d:=2;
 Repeat
  ok:=true;
  For i:=1 to d-1 do
   If b[c[i],c[i+1]]<>0 then
    Begin
     ok:=false;
     Inc(d);
     For j:=d downto i+2 do c[j]:=c[j-1];
     c[i+1]:=b[c[i],c[i+1]];
    End;
 Until ok;
 TimDuong:=true;
End;
Begin
 Clrscr;
 Input;
 Floyld;
 x:=1;
 y:=2;
 If TimDuong(x,y,d) then
  For i:=1 to d do Write(c[i],' ')
 Else Write('Khong co duong di');
End.