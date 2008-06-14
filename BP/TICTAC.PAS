Uses crt;
Const tf='C:\TICTAC.INP';
Var i,j,m,n,k:integer;
    A:array[1..4,1..5] of -1..1;{-1:den;1:trang;0:chua co quan co}
    Bcu,Bmoi:array[1..100] of byte;
    t,s,smoi:shortint;
{Xem co bao nhieu quan co giong nhau tren 1 hang, 1 cot, 1 duong cheo (phu
thuoc vao tham so ti, tj)}
Procedure Dem(var d:integer;i,j,t,ti,tj:integer);
Begin
 Inc(i,ti);
 Inc(j,tj);
 While (d<4)and(i>=1)and(i<=m)and(j>=1)and(j<=n)and(a[i,j]=t) do
  Begin
   Inc(d);
   Inc(i,ti);
   Inc(j,tj);
{   If (i>=1)and(i<=m)and(j>=1)and(j<=n) then}
  End
End;
{Kiem tra sau nuoc di cua dau thu co chien thang khong}
Function Kt(i,j:integer;t:shortint):boolean;
Var d,i1,j1:integer;
Begin
 d:=1;
 Dem(d,i,j,t,0,-1);
 Dem(d,i,j,t,0,1);
 If d<4 then
  Begin
   d:=1;
   Dem(d,i,j,t,-1,0);
   Dem(d,i,j,t,1,0);
   If d<4 then
    Begin
     d:=1;
     Dem(d,i,j,t,1,-1);
     Dem(d,i,j,t,-1,1);
     If d<4 then
      Begin
       d:=1;
       Dem(d,i,j,t,1,1);
       Dem(d,i,j,t,-1,-1);
       Kt:=d=4
      End
     Else Kt:=True;
    End
   Else Kt:=True;
  End
 Else Kt:=True
End;
{Dat 1 quan co len ban co theo yeu cau cua de bai}
Procedure Dat(j:integer;t:shortint;var i:integer);
Begin
 i:=m;
 While (a[i,j]=0)and(i>=1) do Dec(i);
 If (a[i,j]=0)and(i=1) then i:=1
 Else i:=i+1;
 a[i,j]:=t;
End;
{Lay noi dung tu tap tin va xu ly}
Procedure Nhap;
Var x,j,i,so:integer;
    f:text;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,m,n,k);
 t:=-1;
 For i:=1 to k do
  Begin
   Read(f,so);
   If odd(i) then Dat(so,1,x)
   Else Dat(so,-1,x);
   If kt(x,j,t) then
    Begin
     If odd(i) then t:=1
     Else t:=2;
     break
    End
   Else
    If i=m*n then
     Begin
      t:=0;
      break
     End
  End;
 s:=i;
 For i:=m downto 1 do
  Begin
   For j:=1 to n do Write(a[i,j]:3);
   Writeln
  End;
 Close(f)
End;
Procedure Try(i:integer);
Var j,x:integer;
Begin
 Inc(smoi);
 For j:=1 to n do
  If a[m,j]=0 then
   Begin
    If s>0 then break;
    Dat(j,i,x);
    Bmoi[smoi]:=j;
    If kt(x,j,i) then
     Begin
      s:=smoi;
      Bcu:=Bmoi;
      break
     End
    Else
     If i=1 then Try(-1)
     Else Try(1);
    Bmoi[smoi]:=0;
   End;
 Dec(smoi)
End;
{Chuong trinh chinh}
Begin
 Clrscr;
 Nhap;
 If t=-1 then
  Begin
   s:=0;
   smoi:=0;
   If odd(k) then Try(-1)
   Else Try(1);
  End;
 Writeln(t,' ',s);
 If (t=-1)and(s>0) then
  Begin
   For i:=1 to s do Write(Bcu[i],' ');
   Writeln;
   For i:=m downto 1 do
    Begin
     For j:=1 to n do Write(a[i,j]:3);
     Writeln
    End
  End;
 Readln
End.