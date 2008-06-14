Uses crt;
Const tf='C:\DAYSO1.INP';
      tg='C:\DAYSO1.OUT';
Type mang=array[1..300] of char;
Var A:mang;
    d:integer;
Procedure DocFile(Var a:mang;Var d:integer);
Var f:text;
Begin
 Assign(f,tf);Reset(f);
 d:=0;
 While not eof(f) do
  Begin
   Inc(d);
   Read(f,a[d]);
  End;
 Close(f);
End;
Procedure Ghi(a:mang;d:integer);
Var g:text;
    x,i,j,t:integer;
Begin
 Assign(g,tg);
 Rewrite(g);
 t:=1;
 i:=1;
 x:=0;
 Repeat
  Case a[i] of
  '=': Begin
        Writeln(g,t);
        Inc(x)
       End;
  '<':Begin
       Writeln(g,t);
       Inc(t);
       Inc(x);
      End;
  '>':Begin
       j:=i;
       While a[j]='>' do Inc(j);
       If j-i+1>t then t:=j-i+1;
       i:=j-1;
       For j:=t downto 2 do
        Begin
         Writeln(g,j);
         Inc(x)
        End;
       t:=1
      End
  End;
  Inc(i)
 Until i>d;
 if x=d then Writeln(g,t);
 Close(g)
End;
Begin
 Clrscr;
  DocFile(a,d);
  Ghi(a,d)
End.
>>>==<=<>>>>><<<<>>>>>