Uses crt;
Const tf='D:\VALY.INP';
Var i,kl,t,tcu,tmoi,n,w:integer;
    A,C:array[1..5] of integer;
    Vcu,Vmoi:array[0..10] of integer;
Procedure Input;
Var f:text;
    i:integer;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,n,w);
 For i:=1 to n do Readln(f,a[i],c[i]);
 Close(f)
End;
Procedure Try(j:integer);
Var i:byte;
Begin
 For i:=j+1 to n do
  Begin
   If kl+A[i]<=W then
    Begin
     Inc(kl,A[i]);
     Inc(tmoi,C[i]);
     Inc(t);
     Vmoi[t]:=i;
     If tmoi>tcu then
      Begin
       tcu:=tmoi;
       Vcu:=Vmoi
      End;
     Try(i);
     Dec(kl,A[i]);
     Dec(tmoi,C[i]);
     Dec(Vmoi[t]);
     Dec(t)
    End
  End
End;
Begin
 Clrscr;
  Input;
  tcu:=0;
  tmoi:=0;
  t:=0;
  kl:=0;
  Fillchar(Vcu,sizeof(vcu),0);
  Fillchar(Vmoi,sizeof(vmoi),0);
  Try(1);
  Writeln(tcu);
  i:=1;
  While Vcu[i]<>0 do
   Begin
    Writeln(Vcu[i]);
    Inc(i)
   End;
 Readln
End.