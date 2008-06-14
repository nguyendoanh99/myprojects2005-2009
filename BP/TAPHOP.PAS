Uses crt;
Const tf='D:\KQ.OU';
Var i,n,d:integer;
    B,A:array[1..100] of integer;
    f:text;
Procedure Try(m:integer);
Var i,j:integer;
Begin
 For i:=m to n do
  Begin
   Inc(d);
   B[d]:=a[i];
   For j:=1 to d do Write(f,b[j],' ');
   Writeln(f);
   Try(i+1);
   B[d]:=0;
   Dec(d)
  End
End;
Begin
 Clrscr;
  Write('n=');Readln(n);
  For i:=1 to n do
   Begin
    Write('a[',i,']=');Readln(a[i])
   End;
  Assign(f,tf);Rewrite(f);
  Try(1);
  Close(f);
End.