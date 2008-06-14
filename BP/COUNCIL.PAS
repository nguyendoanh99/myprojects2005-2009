{Ky thi chon hoc sinh gioi quoc gia
 Lop 12 THPT nam 2002-2003
 Bang A
 Dai dien}
Uses crt;
Const fi='C:\COUNCIL.INP';
      fo='C:\COUNCIL.OUT';
Var Mp:array[1..100] of byte;
    Mk:array[1..50,1..100] of byte;
    Mu:array[1..50] of byte;
    Mn:array[1..100] of boolean;
    MChon:array[1..50] of byte;
    Mu1:array[1..50] of byte;
    n,k,p,d:byte;
    kt:boolean;
Procedure Input;
Var f:text;
    i,j,a,b:byte;
    t:array[1..50] of byte;
Begin
 Fillchar(Mk,sizeof(Mk),false);
 Fillchar(t,sizeof(t),0);
 Assign(f,fi);Reset(f);
 Readln(f,n,p,k);
 For i:=1 to n do
  Begin
   Read(f,Mp[i],a);
   For j:=1 to a do
    Begin
     Read(f,b);
     Inc(t[b]);
     Mk[b,t[b]]:=i
    End;
   Readln(f)
  End;
 For i:=1 to p do Read(f,Mu[i]);
 Close(f)
End;
Procedure Try(a:byte);
Var i,j,x:byte;
Begin
 If not kt then
  Begin
   Inc(d);
   For i:=a to k do
    Begin
     j:=1;
     While (Mk[i,j]<>0)and(not kt) do
      Begin
       If (not Mn[Mk[i,j]])and(Mu1[Mp[Mk[i,j]]]<Mu[Mp[Mk[i,j]]]) then
        Begin
         MChon[d]:=Mk[i,j];
         Mn[Mk[i,j]]:=True;
         Inc(Mu1[Mp[Mk[i,j]]]);
         If a=k then
          Begin
           x:=1;
           While (x<=p)and(Mu1[x]<>0) do Inc(x);
           Kt:=x>p
          End
         Else Try(a+1);
         Mn[Mk[i,j]]:=False;
         Dec(Mu1[Mp[Mk[i,j]]])
        End;
       Inc(j)
      End
    End;
   Dec(d)
  End
End;
Procedure Output;
Var i:byte;
    f:text;
Begin
 Assign(f,fo);
 Rewrite(f);
 If kt then
  For i:=1 to k do Write(f,Mchon[i],' ')
 Else Write(f,-1);
 Close(f)
End;
Begin
 Clrscr;
  Input;
  d:=0;
  kt:=false;
  Fillchar(Mn,sizeof(Mn),false);
  Try(1);
  Output;
 Readln
End.