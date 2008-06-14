Uses crt;
Const tf='C:\MATKHAU.INP';
      tg='C:\MATKHAU.OUT';
Type cs=record
         so:integer;
         mu:byte;
        End;
     Mang=array[1..100] of cs;
Var k:integer;
    a:array[1..100] of integer;
Procedure PhanTich(a:integer;Var T:mang);
Var d,i:integer;

Begin
 Fillchar(t,sizeof(t),0);
 d:=0;
 For i:=2 to a do
  If a mod i=0 then
   Begin
    Inc(d);
    T[d].so:=i;
    While a mod i=0 do
     Begin
      Inc(T[d].mu);
      a:=a div i
     End
   End
End;
Procedure DocFile;
Var f:text;
    i:integer;
Begin
 Assign(f,tf);
 Reset(f);
 Readln(f,k);
 For i:=1 to k do
  Read(f,a[i]);
 Close(f);
End;
Function Xuly:longint;
Var i,j,l:integer;
    M,T:mang;
    tam,kq:longint;
Begin
 Fillchar(M,sizeof(m),0);
 For i:=1 to k do
  Begin
   PhanTich(a[i],t);
   j:=1;
   While T[j].so<>0 do
    Begin
     l:=1;
     While (M[l].so<>T[j].so)and(M[l].so<>0) do Inc(l);
     If (M[l].so=0) then M[l]:=T[j]
     Else
      If M[l].mu<T[j].mu then M[l].mu:=T[j].mu;
     Inc(j)
    End
  End;
 kq:=1;
 i:=1;
 While M[i].so<>0 do
  Begin
   tam:=1;
   For j:=1 to M[i].mu do tam:=tam*M[i].so;
   kq:=kq*tam;
   Inc(i)
  End;
 Xuly:=kq
End;
Procedure GhiFile(a:longint);
Var g:text;
Begin
 Assign(g,tg);Rewrite(g);
 Write(g,a);
 Close(g);
End;
Begin
 Clrscr;
  DocFile;
  GhiFile(xuly);
 Readln
End.
