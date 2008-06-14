Uses crt;
Const max=15000;
Var A:array[1..2,0..max] of integer;
    i,j,m,n:integer;
Begin
 Write('m,n=');Readln(m,n);
 For i:=0 to max do A[1,i]:=i+1;
 For i:=1 to m do
  Begin
   j:=0;
   Fillchar(a[2],sizeof(a[2]),0);
   Repeat
    If j=0 then A[2,j]:=A[1,1]
    Else A[2,j]:=A[1,A[2,j-1]];
    Inc(j);
   Until (j>max)or(A[2,j-1]>max)or((j>n)and(i=m));
   A[1]:=A[2];
  End;
 Writeln(A[1,n]);
 Readln;
End.