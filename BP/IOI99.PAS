Uses crt;
Const tf='D:\Flower.inp';
Var i,f,v,d:byte;
    A:array[1..10,1..10] of shortint;
    tcu,tmoi:integer;
    Ccu,Cmoi:array[1..10] of byte;
Procedure Input;
Var g:text;
    i,j:byte;
Begin
 Assign(g,tf);Reset(g);
 Readln(g,f,v);
 For i:=1 to f do
  Begin
   For j:=1 to v do Read(g,A[i,j]);
   Readln(g)
  End;
 Close(g)
End;
Procedure Try(i,j:byte);
Var h:byte;
Begin
 For h:=j to j+f-1 do
  Begin
   Inc(d);
   Ccu[d]:=h;
   Inc(tcu,a[i,h]);
   If i=f then
    Begin
     If tcu>tmoi then
      Begin
       tmoi:=tcu;
       cmoi:=ccu
      End
    End
   Else Try(i+1,h+1);
   Ccu[d]:=0;
   Dec(d);
   Dec(tcu,a[i,h])
  End
End;
Begin
 Clrscr;
 tmoi:=-32000;tcu:=0;
 d:=0;
 Fillchar(Ccu,Sizeof(ccu),0);
 Fillchar(Cmoi,Sizeof(cmoi),0);
 Input;
 Try(1,1);
 Writeln(tmoi);
 i:=1;
 While cmoi[i]<>0 do
  Begin
   Write(cmoi[i],' ');
   Inc(i)
  End;
 Readln
End.