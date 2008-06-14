{IOI 2003 Du doan ve dan bo}
Uses crt;
Const fi='C:\DANBO.INP';
      fo='C:\DANBO.OUT';
      T:array[1..3] of char=('X','Y','Z');
      nmax=50;
      pmax=8;
Type M1=array[1..nmax,1..pmax] of byte;
     M2=array[1..3,1..pmax] of byte;
     M3=array[1..pmax] of byte;
     M4=array[1..nmax] of boolean;
     M5=array[1..2] of byte;
Var M_Db:M1;
    M_Dt:M2;
    M_Ut,M_Kc:M3;
    M_TH:M4;
    M_Gh:M5;
    i,j,tl,vt,d,n,p:byte;
Procedure Input(Var A:M1);
Var f:text;
    s:string;
    i,j,d:byte;
Begin
 Assign (f,fi);Reset(f);
 Readln(f,n,p);
 For i:=1 to n do
  Begin
   Readln(f,s);
   j:=0;
   d:=0;
   Repeat
    Inc(j);
    Case s[j] of
    'X':Begin
         Inc(d);
         A[i,d]:=1
        End;
    'Y':Begin
         Inc(d);
         A[i,d]:=2
        End;
    'Z':Begin
         Inc(d);
         A[i,d]:=3
        End
    End
   Until d=p
  End;
 Close(f)
End;
Procedure DemDTinh(n,p:byte;B:M1;Var A:M2);
Var i,j:byte;
Begin
 For i:=1 to n do
  For j:=1 to p do Inc(A[B[i,j],j])
End;
Procedure XetUTien(p:byte;B:M2;Var A:M3);
Var i,j,d:byte;
Begin
 For j:=1 to p do
  Begin
   d:=0;
   For i:=1 to 3 do
    If B[i,j]=0 then Inc(d);
   Case d of
   2:A[j]:=3;
   0:A[j]:=2;
   1:A[j]:=1
   End
  End
End;
Procedure TinhKCach(p:byte;B:M2;var A:M3);
Var i,j,max,kq:byte;
Begin
 For j:=1 to p do
  Begin
   kq:=B[1,j];
   max:=B[1,j];
   For i:=2 to 3 do
    Begin
     Inc(kq,B[i,j]);
     If max<B[i,j] then max:=B[i,j]
    End;
   A[j]:=abs(2*max-kq)
  End
End;
Procedure DatCHoi(p:byte;A:M3;B:M3;C:M2;Var v:byte;Var g:M5);
Var i,j,tmax:byte;
    L:array[1..2] of record
                      vt,kc:byte
                     End;
Begin
 L[1].vt:=0;
 L[1].kc:=nmax;
 L[2].vt:=0;
 L[2].kc:=nmax;
 For i:=1 to p do
  If A[i]<3 then
   With L[A[i]] do
    Begin
     If B[i]<kc then
      Begin
       kc:=B[i];
       vt:=i
      End
    End;
 If L[1].vt<>0 then
  With L[1] do
   Begin
    i:=1;
    While C[i,vt]=0 do Inc(i);
    Write('Q ',vt,' ',T[i],'   ');
    v:=vt;
    g[1]:=i;
    g[2]:=0;
   End
 Else
  With L[2] do
   Begin
    Write('Q ',vt);
    tmax:=1;
    For i:=2 to 3 do
     If C[tmax,vt]<C[i,vt] then tmax:=i;
    j:=0;
    For i:=1 to 3 do
     If i<>tmax then
      Begin
       Write(' ',T[i]);
       Inc(j);
       g[j]:=i;
      End;
    Write('   ');
    v:=vt
   End
End;
Procedure XuLy(tl,n,p,v:byte;A:M1;g:M5;var sc:byte;var B:M2;var E:M4);
Var i,j:byte;
Begin
 For i:=1 to n do
  If (E[i])and(((tl=1)and(not(A[i,v] in [g[1],g[2]])))
     or((tl=0)and((A[i,v] in [g[1],g[2]])))) then
   Begin
    Dec(sc);
    E[i]:=False;
    For j:=1 to p do Dec(B[A[i,j],j])
   End
End;
Begin
 Clrscr;
  Input(M_Db);
  For i:=1 to n do
  Begin
   For j:=1 to p do write(T[M_Db[i,j]],' ');
   Writeln
  End;

  DemDTinh(n,p,M_Db,M_Dt);
  Fillchar(M_TH,sizeof(M_TH),true);
  d:=n;
  Writeln;
  Repeat
{   Writeln('Dac tinh');
   For i:=1 to 3 do
    Begin
     For j:=1 to p do Write(M_Dt[i,j],' ');
     Writeln;
    End;
}
   XetUTien(p,M_Dt,M_Ut);
{   Writeln('Uu tien');
   For i:=1 to p do Write(M_Ut[i],' ');
}
   TinhKCach(p,M_Dt,M_Kc);
{   Writeln;
   Writeln('Khoang cach');
   For i:=1 to p do Write(M_Kc[i],' ');
   Writeln;

   For i:=1 to n do
    If M_Th[i] then Write('T ')
    Else Write('F ');

   Writeln;Writeln;
   Writeln('Dat cau hoi');}
   DatCHoi(p,M_Ut,M_Kc,M_Dt,vt,M_Gh);
   Readln(tl);
   XuLy(tl,n,p,vt,M_Db,M_Gh,d,M_Dt,M_Th)
  Until d=1;
  i:=1;
  While not M_Th[i] do Inc(i);
  Writeln('C ',i);
 Readln
End.