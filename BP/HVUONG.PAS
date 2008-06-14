Uses crt;
Const fi='C:\HV.INP';
      fo='C:\HV.OUT';
      max=100;
Var t,d1,d2,m,n:byte;
    A1,A2:array[1..100] of byte;
Procedure HV(Var a,b:byte);
Var t:byte;
Begin
 t:=a;
 a:=b;
 b:=t;
End;
Procedure Input;
Var f:text;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,m,n);
 Close(f);
End;
Procedure Try(a,b:byte);
Var i,j:byte;
Begin
 If (a mod b=0)or(b mod a=0) then
  Begin
   If a mod b=0 then
    For t:=1 to a div b do
     Begin
      Inc(d1);
      A1[d1]:=b;
     End
   Else
    For t:=1 to b div a do
     Begin
      Inc(d1);
      A1[d1]:=a;
     End;
   If d1<d2 then
    Begin
     d2:=d1;
     A2:=A1;
    End;
   If a mod b=0 then Dec(d1,a div b)
   Else Dec(d1,b div a)
  End
 Else
  Begin
   For i:=1 to 2 do
    Begin
     HV(a,b);
     For j:=1 to a div 2 do
      If b mod j=0 then
       Begin
        For t:=1 to b div j do
         Begin
          Inc(d1);
          A1[d1]:=j;
         End;
        If d1<d2 then Try(a-j,b);
        Dec(d1,b div j);
       End
      Else
       If b mod (a-j)=0 then
        Begin
         For t:=1 to b div (a-j) do
          Begin
           Inc(d1);
           A1[d1]:=a-j;
          End;
         If d1<d2 then Try(j,b);
         Dec(d1,b div (a-j));
        End;
    End;
  End;
End;
Procedure Output;
Var f:text;
    i:byte;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,d2);
 Writeln(d2);
 For i:=1 to d2 do
  Begin
   Write(f,A2[i],' ');
   Write(A2[i],' ');
  End;
 Close(f);
End;
Begin
 Clrscr;
  Input;
  If m>n then d2:=m+1
  Else d2:=n+1;
  d1:=0;
  Try(m,n);
  Output;
 Readln
End.