Uses crt;
Const fi='C:\ADDPATH.INP';
      fo='C:\ADDPATH.OUT';
      maxn=200;
Type Mang=array[1..maxn,1..maxn] of boolean;
     Mang1=array[1..maxn] of Record
                                x,y:integer;
                             End;
Var A:Mang;
    B:Mang1;
    dinht,canh,dinh,M_Treo:array[1..2] of integer;
    M_Dinh:array[1..maxn] of boolean;
    n,dem,i:integer;
Procedure Input;
Var f:text;
    x,y:integer;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n);
 While not eof(f) do
  Begin
   Readln(f,x,y);
   A[x,y]:=True;
   A[y,x]:=True;
  End;
 Close(f);
End;
Procedure Duyet(d,t:integer);
Var k,i:integer;
Begin
 k:=0;
 Inc(dinh[t]);
 M_Dinh[d]:=True;
 For i:=1 to n do
  If A[d,i] then
   Begin
    Inc(k);
    Inc(canh[t]);
   End;
 If k=1 then
  Begin
   Inc(dinht[t]);
   If dinht[t]<=2 then M_Treo[dinht[t]]:=d;
  End;
 For i:=1 to n do
  If (A[d,i])and(not M_Dinh[i]) then Duyet(i,t);
 M_Dinh[d]:=False;
End;
Procedure DanhDau(d:integer);
Var i:integer;
Begin
 M_Dinh[d]:=True;
 For i:=1 to n do
  If (A[d,i])and(not M_Dinh[i]) then DanhDau(i);
End;
Function ThucHien:boolean;
Var i:integer;
    k:array[1..2] of boolean;
    T:array[1..2] of integer;
Begin
 For T[1]:=1 to n-1 do
  If not M_Dinh[T[1]] then
   Begin
    For T[2]:=T[1]+1 to n do
     If A[T[1],T[2]] then
      Begin
       A[T[1],T[2]]:=False;
       A[T[2],T[1]]:=False;
       k[1]:=True;
       For i:=1 to 2 do
        If k[1] then
         Begin
          canh[i]:=0;
          dinht[i]:=0;
          dinh[i]:=0;
          Duyet(T[i],i);
          If dinh[i]>=3 then
           Begin
            canh[i]:=canh[i] div 2;
            If (dinht[i]=2)and(dinh[i]-canh[i]=1) then
             Begin
              Inc(dem);
              b[dem].x:=M_Treo[1];
              b[dem].y:=M_Treo[2];
             End;
            If ((dinht[i]=2)and(dinh[i]-canh[i]=1))or((dinht[i]=0)and(dinh[i]=canh[i])) then
             Begin
              DanhDau(T[i]);
              k[i]:=True
             End
            Else k[i]:=ThucHien;
           End
          Else k[i]:=false;
         End;
       A[T[1],T[2]]:=True;
       A[T[2],T[1]]:=True;
       ThucHien:=k[1] and k[2];
       If ThucHIen then exit;
      End;
   End;
End;
Procedure Output;
Var f:text;
    i:integer;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,dem);
 For i:=1 to dem do Writeln(f,B[i].x,' ',B[i].y);
 Close(f);
End;
Begin
 Clrscr;
  Fillchar(A,sizeof(A),False);
  Fillchar(M_Dinh,sizeof(M_Dinh),False);
  Input;
  Dem:=0;
  ThucHien;
  Writeln(dem);
  For i:=1 to dem do Writeln(B[i].x,' ',B[i].y);
  Output;
 Readln
End.
