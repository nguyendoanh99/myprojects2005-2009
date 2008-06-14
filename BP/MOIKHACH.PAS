Uses crt;
Const tf='D:\GUEST.IN';
      nn=1001;
Var A:array[1..nn] of Record
                      ti,vi:Integer
                     End;
    i:Integer;
    n:integer;
    vcu,vmoi,mcu,mmoi:integer;
    Acu,Amoi:array[1..nn] of integer;
Procedure Input;
Var f:text;
    i:integer;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,n);
 For i:=1 to n do Readln(f,a[i].ti,a[i].vi);
 Close(f)
End;
Function Kt(j:integer):boolean;
Var i:integer;
Begin
 If mmoi>0 then
  Begin
   i:=1;
   While (Amoi[i]<>j)and(i<mmoi) do Inc(i);
   Kt:=Amoi[i]=j
  End
 Else Kt:=False
End;
Procedure Try(j:integer);
Var i:integer;
Begin
 For i:=j to n do
  If not kt(a[i].ti) then
   Begin
    Inc(mmoi);
    Amoi[mmoi]:=i;
    Inc(vmoi,a[i].vi);
    If vmoi>vcu then
     Begin
      mcu:=mmoi;
      vcu:=vmoi;
      Acu:=Amoi
     End;
    Try(i+1);
    Amoi[mmoi]:=0;
    Dec(vmoi,a[i].vi);
    Dec(mmoi)
   End
End;
Begin
 Clrscr;
  Input;
  vcu:=-1;
  vmoi:=0;
  mmoi:=0;
  Fillchar(Amoi,sizeof(amoi),0);
  Try(1);
  Writeln(mcu,' ',vcu);
  For i:=1 to mcu do Writeln(Acu[i]);
 Readln
End.