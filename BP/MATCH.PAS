{$N+}
Uses crt;
Const fi='C:\MATCH.INP';
      fo='C:\MATCH.OUT';
      maxn=10000000;
      maxn1=1000;
Var A,B:array[1..maxn] of integer;
    A1,B1:array[1..maxn] of boolean;
    n:longint;
    k:integer;
    C1,C2:array[1..maxn1] of Record
                              i,j:longint;
                             End;
    m1,m2:extended;
Procedure Input;
Var i:longint;
    f:text;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n,k);
 For i:=1 to n do Readln(f,A[i],B[i]);
 Close(f);
End;
Procedure Try(x:integer);
Var i,j:longint;
Begin
 If x>k then
  Begin
   If m1>m2 then
    Begin
     m2:=m1;
     C2:=C1;
    End;
  End
 Else
  For i:=1 to n do
   If not A1[i] then
    Begin
     A1[i]:=True;
     For j:=1 to n do
      If not B1[j] then
       Begin
        B1[j]:=True;
        m1:=m1+a[i]*b[j];
        C1[x].i:=i;
        C1[x].j:=j;
        Try(x+1);
        B1[j]:=False;
        m1:=m1-a[i]*b[j];
       End;
     A1[i]:=False;
    End;
End;
Procedure Output;
Var f:text;
    i:integer;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,m2:0:0);
 Writeln(m2:0:0);
 For i:=1 to k do
  Begin
   Writeln(f,C2[i].i,' ',C2[i].j);
   Writeln(C2[i].i,' ',C2[i].j);
  End;
 Close(f);
End;
Begin
 Clrscr;
  Input;
  m1:=0;
  m2:=-maxlongint;
  Fillchar(A1,sizeof(A1),false);
  Fillchar(B1,sizeof(B1),false);
  Try(1);
  Output;
 Readln;
End.