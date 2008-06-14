Uses crt;
Const A:array[1..9,1..9] of 0..1=((0,1,0,1,0,0,0,0,0),
                                  (1,0,1,1,1,0,1,0,1),
                                  (0,1,0,1,1,1,0,0,0),
                                  (1,1,1,0,1,0,1,0,1),
                                  (0,1,1,1,0,1,1,1,0),
                                  (0,0,1,0,1,0,0,1,1),
                                  (0,1,1,1,1,0,0,1,0),
                                  (0,0,0,0,1,1,1,0,1),
                                  (0,1,0,1,0,1,0,1,0));
Var St:array[1..50] of byte;
    d,j:byte;
Function kt:boolean;
Var i,j:byte;
Begin
 kt:=true;
 i:=0;
 Repeat
  Repeat
  Until
 Until (i>9)and(A[i,j]=1);
End;
Procedure Try(m:byte);
Var i:byte;
Begin
 For i:=1 to 9 do
  If A[m,i]=1 then
   Begin
    A[m,i]:=0;
    A[i,m]:=0;
    Inc(d);
    St[d]:=i;
    If not kt then
     Begin
      Try(i);
      A[m,i]:=1;
      A[i,m]:=1;
      St[d]:=0;
      Dec(d);
     End
    Else
     Begin
      For j:=1 to d do Write(st[j],' ');
      Writeln;
     End;
   End;
End;
Begin
 Clrscr;
  fillchar(a,sizeof(a),0);
  st[1]:=9;
  d:=1;
  Try(9);
 Readln
End.