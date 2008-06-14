Uses crt;
Const tf='D:\GCN.INP';
Var A:array[1..6] of Record
                      s:integer;
                      k:0..1
                     End;
    Mcu,Mmoi:array[1..6] of byte;
    Dtcu,Dtmoi:real;
    h,t,I:Integer;
Procedure Input;
Var f:text;
Begin
 Assign(f,tf);Reset(f);
 i:=0;
 While not eof(f) do
  Begin
   Inc(i);
   Readln(f,a[i].s);
   Write(a[i].s,'  ');
   A[i].k:=0
  End;
 Close(f)
End;
Procedure Try(x:byte;m:boolean);
Var j:byte;
Begin
 If not m then
  Begin
   For j:=x+1 to i do
    If A[j].k=0 then
    Begin
     Inc(t);
     Mmoi[t]:=j;
     Dtmoi:=dtmoi+A[Mmoi[t-1]].s*A[Mmoi[t]].s;
     A[j].k:=1;
     Try(j,True);
     A[j].k:=0;
     Dtmoi:=Dtmoi-A[Mmoi[t-1]].s*A[Mmoi[t]].s;
     Mmoi[t]:=0;
     Dec(t);
    End;
  End
 Else
  Begin
   If t=i then
    Begin
     If dtcu<dtmoi then
      Begin
       dtcu:=dtmoi;
       Mcu:=Mmoi
      End;
    End
   Else
    Begin
     j:=0;
     Repeat
      Inc(j)
     Until A[j].k=0;
     Inc(t);
     Mmoi[t]:=j;
     A[j].k:=1;
     Try(j,False);
     Mmoi[t]:=0;
     A[j].k:=0;
     Dec(t);
    End;
  End;
End;
Begin
 Clrscr;
  Dtcu:=0;
  Dtmoi:=0;
  Fillchar(Mcu,sizeof(Mcu),0);
  Fillchar(Mmoi,sizeof(Mmoi),0);
  Input;
  Mmoi[1]:=1;
  A[1].k:=1;
  t:=1;
  Try(1,False);
  Writeln;
  Writeln(dtcu:0:0);
  For h:=1 to i do
   Begin
    Write(Mcu[h],'   ');
    If not odd(h) then Writeln
   End;
 Readln
End.