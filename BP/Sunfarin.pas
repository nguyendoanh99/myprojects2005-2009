Uses crt;
Const fi='C:\SUNFARIN.INP';
      fo='C:\SUNFARIN.OUT';
      nmax=200;
Var A:array[1..nmax] of integer;
    n,m,d:integer;
Procedure Input;
Var f:text;
    k,i:integer;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n);
 k:=0;
 For i:=1 to n do
  Begin
   Read(f,a[i]);
   Inc(k,a[i]);
  End;
 m:=k div n;
 Close(F)
End;
Procedure Try(i:integer);
Var j,k:integer;
Begin
 Repeat
  j:=i;
  While (j<=n)and(A[j]<=m) do Inc(j);
  If j<=n then
   Begin
    k:=j-1;
    While (k>=1)and(A[k]>=m) do Dec(k);
    If k>=1 then
     Begin
      Inc(A[k]);
      Dec(A[j])
     End;
    k:=j+1;
    While (k<=n)and(A[k]>=m) do Inc(k);
    If k<=n then
     Begin
      Inc(A[k]);
      Dec(A[j]);
      Try(k+1);
     End
   End
  Else Inc(d);
 Until (i<>1)or((i=1)and(j>n));
End;
Procedure Output;
Var f:text;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,d-1);
 Close(f);
End;
Begin
 Clrscr;
 Input;
 d:=0;
 Try(1);
 Output;
 Readln
End.