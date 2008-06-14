Uses crt;
Const tf='D:\DICHO-03.IN';
Var i,z,n:byte;
    T:array[2..5] of byte;
    g:array[1..4,0..5] of byte;
    k:array[1..4,0..5] of byte;
    H:array[1..4] of integer;
    Acu,Amoi:array[1..5] of byte;
    sphut,cl,shcu,shmoi:integer;
Function Tinh(i,Sp:byte):integer;
Var l,j:byte;
    v:integer;
Begin
 j:=0;
 l:=0;
 v:=0;
 While l<Sp do
  Begin
   Inc(j);
   Inc(l,g[i,j]);
   If l<=sp then Inc(v,g[i,j]*k[i,j])
   Else Inc(v,(l-sp)*k[i,j])
  End;
 Tinh:=v
End;
Procedure Input;
Var f:text;
    a,i,j:byte;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,n,sphut);
 For j:=2 to n do Read(f,t[j]);
 For i:=1 to n do
  Begin
   Read(f,a);
   h[i]:=0;
   For j:=1 to a do
    Begin
     Read(f,g[i,j]);
     Inc(h[i],g[i,j])
    End;
   Readln(f)
  End;
 For i:=1 to n do
  Begin
   Read(f,a);
   For j:=1 to a do Read(f,k[i,j]);
   Readln(f)
  End;
 Close(f)
End;
Procedure Thu(cho:byte);
Var i,j:byte;
    q,m:integer;
Begin
 If cl>=h[cho] then m:=h[cho]
 Else m:=cl;
 For j:=0 to m do
  Begin
   Dec(cl,j);
   Amoi[z]:=j;
   q:=tinh(cho,j);
   Inc(shmoi,q);
   Dec(cl,t[cho+1]);
   If cl<=0 then
    Begin
     If shmoi>shcu then
      Begin
       shcu:=shmoi;
       Acu:=Amoi
      End
    End
   Else
    If cho+1<=n then
     Begin
      Inc(z);
      Thu(cho+1);
      Dec(z)
     End;
   Inc(cl,t[cho+1]+j);
   Amoi[z]:=0;
   Dec(shmoi,q);
  End;
End;
Begin
 Clrscr;
  Input;
  cl:=sphut;
  Fillchar(Acu,sizeof(acu),0);
  Fillchar(Amoi,sizeof(amoi),0);
  shcu:=0;
  shmoi:=0;
  Z:=1;
  Thu(1);
  For i:=1 to n do Write(acu[i],' ');
  Writeln;
  Writeln(shcu);
 Readln
End.