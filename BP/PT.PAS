Uses crt;
Var d:longint;
    A:array[1..10] of record
                        a,t:byte
                       End;
    kq,t:integer;
Function Nt(a:integer):boolean;
Var i:integer;
Begin
 nt:=False;
 If (a=2)or(a=3) then nt:=true
 Else
  Begin
   i:=3;
   While (i<=a div 2)and(a mod i<>0) do
    inc(i,2);
   If i>a div 2 then nt:=True
  End
End;
Procedure f(x,k,m:integer);
Var i,j:integer;
Begin
 i:=m;
 While (i<=x)and(kq+i<=x) do
  Begin
   If (kq+i<=x)and nt(i) then
    If a[t].t<k then
     Begin
      If a[t].a=i then Inc(a[t].t)
       Else
        Begin
         Inc(t);
         a[t].a:=i;a[t].t:=1
        End;
      Inc(kq,i);
      If kq<x then f(x,k,i)
      Else
       If kq=x then
       Begin
        Inc(d);
        For j:=1 to t do write(a[j].a,'*',a[j].t,' + ');
        writeln
       End;
      Dec(kq,i);Dec(a[t].t);
      If a[t].t=0 then
       Begin
        a[t].a:=0;
        Dec(t)
       End
     End
    Else
     Begin
      If a[t].a=i then
       Begin
        If odd(i) then inc(i,2)
        Else inc(i);
        While not nt(i) do
         If odd(i) then inc(i,2)
         Else inc(i)
      End;
      Inc(t);
      A[t].a:=i;A[t].t:=1;
      Inc(kq,i);
      If kq<x then f(x,k,i)
      Else
       If kq=x then
       Begin
        Inc(d);
        For j:=1 to t do write(a[j].a,'*',a[j].t,' + ');
        writeln
       End;
      Dec(kq,i);Dec(a[t].t);
      If a[t].t=0 then
       Begin
        a[t].a:=0;
        Dec(t)
       End
     End;
     If odd(i) then inc(i,2)
     Else inc(i)
   End
End;
Begin
 Clrscr;
  d:=0;
  t:=0;
  kq:=0;
  f(12,3,2);
  Write(d);
 Readln
End.