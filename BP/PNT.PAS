Uses crt;
Var n,i,a,m:longint;
Function U(a:longint):longint;
Var d,i:longint;
Begin
 d:=0;
 For i:=1 to a div 2 do
  If a mod i=0 then Inc(d);
 u:=d
End;
Begin
 Clrscr;
 Write('N=');Readln(n);
  m:=0;
  For i:=1 to n do
   If u(i)>m then
    Begin
     m:=u(i);
     a:=i
    End;
  Write(a);
 Readln
End.