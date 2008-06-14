{Ky thi chon hoc sinh gioi quoc gia
 Lop 12 THPT nam 2002-2003
 Bang A
 Mang may tinh}
Uses crt;
Const fi='C:\COMNET.INP';
      fo='C:\COMNET.OUT';
Var A:array[1..5000] of integer;
    n,t:integer;
    m:longint;
Procedure Input;
Var f:text;
    t1,t2,i,j,x,y,d:integer;
Begin
 Fillchar(a,sizeof(a),0);
 Assign(f,fi);Reset(f);
 Readln(f,n,m);
 d:=0;
 t:=0;
 For i:=1 to m do
  Begin
   Readln(f,x,y);
   If A[x]<>0 then
    If A[y]<>0 then
     Begin
      If A[x]>A[y] then
       Begin
        t1:=A[x];
        t2:=A[y]
       End
      Else
       If A[x]<A[y] then
        Begin
         t1:=A[y];
         t2:=A[x]
        End;
      If A[y]<>A[x] then
       Begin
        Dec(t);
        For j:=1 to n do
         Begin
          If A[j]=t1 then A[j]:=t2
         End
       End
      Else
     End
    Else A[y]:=A[x]
   Else
    If A[y]<>0 then A[x]:=A[y]
    Else
     Begin
      Inc(d);
      Inc(t);
      A[x]:=d;
      A[y]:=d
     End
  End;
 For i:=1 to n do
  If A[i]=0 then Inc(t);
 Close(f)
End;
Procedure Output;
Var f:text;
    t1,t2,i,j,d:integer;
Begin
 Assign(f,fo);Rewrite(f);
 i:=2;
 d:=0;
 Writeln(f,t);
 While (d<t)and(i<=n) do
  Begin
   If A[1]<>0 then
    If A[i]<>0 then
     Begin
      If A[1]>A[i] then
       Begin
        t1:=A[1];
        t2:=A[i]
       End
      Else
       If A[1]<A[i] then
        Begin
         t1:=A[i];
         t2:=A[1]
        End;
      If A[1]<>A[i] then
       Begin
        Inc(d);
        Writeln(f,1,' ',i);
        For j:=1 to n do
         Begin
          If A[j]=t1 then A[j]:=t2
         End
       End
      Else
     End
    Else
     Begin
      Inc(d);
      Writeln(f,1,' ',i);
      A[i]:=A[1]
     End
   Else
    If A[i]<>0 then
     Begin
      Inc(d);
      Writeln(f,1,' ',i);
      A[1]:=A[i]
     End
    Else
     Begin
      Inc(d);
      Writeln(f,1,' ',i)
     End;
   Inc(i)
  End;
 Close(f)
End;
Begin
 Clrscr;
  Input;
  Output;
 Readln
End.