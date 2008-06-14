Uses crt;
Var d,n:byte;
    s:string[10];
    m:string[1];
    k:longint;
    c:integer;
Function NT(a:longint):boolean;
Var i:longint;
Begin
 nt:=false;
 If (a=2)or(a=3) then nt:=True
 Else
  If a>3 then
   If odd(a) then
    Begin
     i:=2;
     While (i<=a div 2)and(a mod i <>0) do
      If odd(i) then Inc(i,2)
      Else Inc(i);
     If a mod i<>0 then nt:=True
    End
End;
Procedure Try(a:byte);
Var i:byte;
Begin
 i:=1;
 Repeat
  Str(i,m);
  s:=s+m;
  Val(s,k,c);
  If nt(k) then
   If length(s)=n then
    Begin
     Inc(d);
     Write(s,' ')
    End
   Else Try(i);
  s:=copy(s,1,length(s)-1);
  Inc(i)
 Until i>9
End;
Begin
 Clrscr;
  s:='';
  d:=0;
  Write('N=');Readln(n);
  Try(1);writeln;
  Write(d);
 Readln
End.