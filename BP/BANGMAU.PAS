Uses crt;
Const fi='C:\BL1.INP';
      fo='C:\BL1.OUT';
      fo1='C:\BL.OUT';
      maxn=128;
Type Mang=array[1..maxn,1..maxn] of byte;
Var d2,n:byte;
    A1,A2:Mang;
    A:array[1..maxn] of Record
                         t,x,y:byte;
                        End;
    g:text;
Procedure Bd(Var A:mang;t,x,y:byte);
Var i,k:byte;
Begin
 Writeln(g,t,' ',x,' ',y);
 Case t of
 1:Begin
    For i:=1 to n do
     Begin
      k:=A[x,i];
      A[x,i]:=A[y,i];
      A[y,i]:=k;
     End;
   End;
 2:Begin
    For i:=1 to n do
     Begin
      k:=A[i,x];
      A[i,x]:=A[i,y];
      A[i,y]:=k;
     End;
   End;
 End;
 For i:=1 to n do
  Begin
   For k:=1 to n do Write(g,A[i,k]:4);
   Writeln(g);
  End;
End;
Procedure Input;
Var f:text;
    i,j:byte;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n);
 For i:=1 to n do
  Begin
   For j:=1 to n do Read(f,A1[i,j]);
   Readln(f);
  End;
 For i:=1 to n do
  Begin
   For j:=1 to n do Read(f,A2[i,j]);
   Readln(f);
  End;
 For i:=1 to n do
  Begin
   For j:=1 to n do Write(g,A1[i,j]:4);
   Writeln(g);
  End;
 Close(f);
End;
Function Dem(u,q:byte):byte;
Var j,t,i:byte;
    A:array[1..maxn] of byte;
Begin
 t:=0;
 If q>1 then t:=1;
 Case u of
 1:
  Begin
   For i:=1 to n do A[i]:=A1[i,1];
   For i:=1 to n-1 do
    If A[i]<>A2[i,q] then
     Begin
      Inc(t);
      j:=i+1;
      While A[j]<>A2[i,q] do Inc(j);
      A[j]:=A[i];
      A[i]:=A2[i,q];
     End;
  End;
 2:
  Begin
   For i:=1 to n do A[i]:=A1[1,i];
   For i:=1 to n-1 do
    If A[i]<>A2[q,i] then
     Begin
      Inc(t);
      j:=i+1;
      While A[j]<>A2[q,i] do Inc(j);
      A[j]:=A[i];
      A[i]:=A2[q,i];
     End;
  End;
 End;
 Dem:=t;
End;
Procedure ThucHien;
Var j,i,d,d1,vt:byte;
Begin
{Doc}
 d:=Dem(1,1);
 vt:=1;
 i:=2;
 While (i<=n)and(d>2) do
  Begin
   d1:=Dem(1,i);
   If d1<d then
    Begin
     d:=d1;
     vt:=i;
    End;
   Inc(i);
  End;
 d:=0;
 For i:=1 to n do
  If A1[i,1]<>A2[i,vt] then
   Begin
    j:=i+1;
    While A1[j,1]<>A2[i,vt] do Inc(j);
    Bd(A1,1,i,j);
    Inc(d);
    With A[d] do
     Begin
      t:=1;
      x:=i;
      y:=j;
     End;
   End;
 If vt>1 then
  Begin
   Bd(A1,2,1,vt);
   Inc(d);
   With A[d] do
    Begin
     t:=2;
     x:=1;
     y:=vt;
    End;
  End;
{Ngang}
 d2:=Dem(2,1);
 vt:=1;
 i:=2;
 While (i<=n)and(d2>2) do
  Begin
   d1:=Dem(2,i);
   If d1<d2 then
    Begin
     d2:=d1;
     vt:=i;
    End;
   Inc(i);
  End;
 d2:=d;
 For i:=1 to n do
  If A1[1,i]<>A2[vt,i] then
   Begin
    j:=i+1;
    While A1[1,j]<>A2[vt,i] do Inc(j);
    Bd(A1,2,i,j);
    Inc(d2);
    With A[d2] do
     Begin
      t:=2;
      x:=i;
      y:=j;
     End;
   End;
 If vt>1 then
  Begin
   Bd(A1,1,1,vt);
   Inc(d);
   With A[d] do
    Begin
     t:=1;
     x:=1;
     y:=vt;
    End;
  End;
End;
Procedure Output;
Var f:text;
    i:byte;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,d2);
 For i:=1 to d2 do
  With A[i] do Writeln(f,t,' ',x,' ',y);
 Close(f);
End;
Begin
 Clrscr;
 Assign(g,fo1);Rewrite(g);
 Input;
 ThucHien;
 Output;
 Close(g);
 Readln;
End.