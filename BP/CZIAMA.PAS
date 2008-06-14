Uses crt;
Const tf='D:\CZIAMA.IN';
Var A:array[1..2000] of string[30];
    Doicu,Doimoi:array[1..26] of integer;
    i,n,scu,smoi:integer;
    dmoi,dcu:byte;
Procedure Input;
Var f:text;
    i:integer;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,n);
 For i:=1 to n do Readln(f,a[i]);
 Close(f)
End;
Procedure Thu(l:integer);
Var i:integer;
Begin
 For i:=1 to n do
  Begin
   If (dmoi=0)or((dmoi>0)and(A[i][1]=A[Doimoi[dmoi]][length(A[Doimoi[dmoi]])])) then
    Begin
     Inc(dmoi);
     Doimoi[dmoi]:=i;
     Inc(smoi,length(A[i]));
     If (smoi>scu)or((smoi=scu)and(dmoi<dcu)) then
      Begin
       scu:=smoi;
       dcu:=dmoi;
       Doicu:=Doimoi
      End
     Else Thu(i+1);
     Doimoi[dmoi]:=0;
     Dec(smoi,length(A[i]));
     Dec(dmoi)
    End
  End
End;
Begin
 Clrscr;
  Input;
  Fillchar(Doimoi,Sizeof(Doimoi),0);
  Fillchar(Doicu,Sizeof(Doicu),0);
  scu:=0;
  smoi:=0;
  dmoi:=0;
  dcu:=26;
  Thu(1);
  Write(scu);
  Writeln(dcu);
  For i:=1 to dcu do Write(doicu[i],' ');
 Readln
End.