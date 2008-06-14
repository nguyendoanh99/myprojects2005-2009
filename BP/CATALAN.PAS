{$N+}
Uses crt;
Const fi='C:\CATALAN.INP';
      fo='C:\CATALAN.OUT';
      maxn=60;
Type Mang=array[0..maxn] of integer;
Var A:array[1..maxn,0..maxn div 2+2]             of extended; {Bien tao bang nhu hinh 2}
    B,C:Mang;
    t,i,n,d:integer;
    h:extended;
    k:boolean;
    f,g:text;
{Thuc hien buoc 1 cua cau tim thu tu tu dien}
Procedure Try(Var q:extended;x:integer);
Var i,j:integer;
Begin
 If d=n then
  Begin
   i:=1;
   While (i<=n)and(B[i]=C[i]) do Inc(i);
   If i>n then k:=True
   Else q:=q+A[n,x];
  End
 Else
  Begin
   Inc(d);
   If odd(d) then j:=x-1
   Else j:=x;
   For i:=1 to 2 do
    Begin
     If j<>0 then
      Begin
       If odd(d) then C[d]:=(j-1)*2+1
       Else C[d]:=(j-1)*2;
       Try(q,j);
       If k then exit;
      End;
     Inc(j);
    End;
   Dec(d);
  End;
End;
{Thuc hien buoc 1 cua cau tim day A}
Procedure Try1(ss:extended;
Var q:extended;x:integer);
Var i,j:integer;
Begin
 If d=n then
  Begin
   If ss>q+A[n,x] then q:=q+A[n,x]
   Else k:=True;
  End
 Else
  Begin
   Inc(d);
   If odd(d) then j:=x-1
   Else j:=x;
   For i:=1 to  2 do
    Begin
     If j<>0 then
      Begin
       If odd(d) then C[d]:=(j-1)*2+1
       Else C[d]:=(j-1)*2;
       Try1(ss,q,j);
       If k then Exit;
      End;
     Inc(j);
    End;
   Dec(d);
  End;
End;
{Tao bang nhu hinh 2}
Procedure Tao(n:integer);
Var i,j,d:integer;
    t:extended;
Begin
 Fillchar(A,sizeof(A),0);
 A[1,1]:=1;
 For i:=1 to n-1 do
  Begin
   If odd(i) then j:=0
   Else j:=1;
   d:=0;
   Repeat
    Inc(d);
    A[i+1,d]:=A[i,j]+A[i,j+1];
    Inc(j);
   Until A[i,j]=0;
  End;
End;
{Tim so Catalan}
Function Catalan(n:integer):extended;
Var i:integer;
    t:extended;
Begin
 i:=1;
 t:=0;
 While A[n,i]<>0 do
  Begin
   t:=t+sqr(A[n,i]);
   Inc(i);
  End;
 Catalan:=t;
End;
{Tim thu tu tu dien}
Function TimThuTu:extended;
Var q:extended;
    i:integer;
Begin
 {Buoc 1}
 q:=1;
 d:=1;
 Fillchar(C,sizeof(c),0);
 C[1]:=1;
 k:=false;
 Try(q,1);
 i:=n-1;
 {Buoc 2}
 While i>0 do
  Begin
   If B[2*n-i]>B[2*n-i-1] then
    q:=q+A[i,B[2*n-i] div 2];
   Dec(i);
  End;
 TimThuTu:=q;
End;
{Tim day A}
Procedure TimDay(p:extended);
Var q:extended;
    i,j,h:integer;
Begin
 {Buoc 1}
 q:=0;
 d:=1;
 Fillchar(C,sizeof(C),0);
 C[1]:=1;
 k:=false;
 Try1(p,q,1);
 {Buoc 2}
 i:=n-1;
 q:=q+1;
 While i>0 do
  Begin
   j:=C[2*n-i-1]-1;
   h:=0;
   If j<0 then
    Begin
     Inc(h);
     j:=j+2;
    End;
   If q=p then C[2*n-i]:=j;
   While (j<=i)and(h<2)and(q<p) do
    Begin
     If h=1 then q:=q+A[i,j div 2];
     If q<=p then C[2*n-i]:=j
     Else q:=q-A[i,j div 2];
     j:=j+2;
     Inc(h);
    End;
   Dec(i);
  End;
End;
Begin
 Clrscr;
  Assign(f,fi);Reset(f);
  Assign(g,fo);Rewrite(g);
  Readln(f,n);
  Tao(n);
  Writeln(g,Catalan(n):0:0);
  Read(f,t);
  While t<>0 do
   Begin
    Case t of
     1:Begin
        Readln(f,h);
        TimDay(h);
        Write(g,'1 ');
        For i:=0 to 2*n do
         Write(g,C[i],' ');
        Writeln(g);
       End;
     2:Begin
        For i:=0 to 2*n do Read(f,B[i]);
        Readln(f);
        Writeln(g,'2 ',TimThuTu:0:0);
       End;
    End;
    Read(f,t);
   End;
  Close(f);
  Close(g);
 Readln;
End.