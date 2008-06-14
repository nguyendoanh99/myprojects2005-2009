Uses crt;
Const fo='C:\CATALAN1.OUT';
Var dem:longint;
    k,n:byte;
    A:array[0..120] of shortint;
    f:text;
Procedure Try(d:integer);
Var i:shortint;
Begin
 If d=2*n then
  Begin
   If A[d-1]=1 then
    Begin
     Inc(dem);
     For k:=0 to 2*n do Write(f,A[k]:3,' ');
     Writeln(f);
    End;
  End
 Else
  Begin
   i:=-1;
   A[d]:=A[d-1]+i;
   While (i<=1) do
    Begin
     A[d]:=A[d-1]+i;
     If (A[d]>=0)and(abs(A[d]-A[d-1])=1) then Try(d+1);
     Inc(i,2);
    End;
  End;
End;
Begin
 Clrscr;
  Write('n=');Readln(n);
  dem:=0;
  Assign(f,fo);Rewrite(f);
  Try(1);
  Writeln(dem);
  Close(f);
End.