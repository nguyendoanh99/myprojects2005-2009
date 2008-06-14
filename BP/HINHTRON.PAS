Uses crt;
Const fi='C:\HINHTRON.INP';
      fo='C:\HINHTRON.OUT';
      maxn=100;
Var A:array[1..maxn] of Record
                        x,y,r:real;
                       End;
    B:array[1..maxn,1..maxn+1] of byte;
    d,n:byte;
Procedure Input;
Var f:text;
    i:integer;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n);
 For i:=1 to n do
  With A[i] do Readln(f,x,y,r);
 Close(f);
End;
Function Kt(i,j:integer):boolean;
Begin
 Kt:=abs(A[i].r-A[j].r)>=sqrt(sqr(A[i].x-A[j].x)+sqr(A[i].y-A[j].y));
End;
Procedure ThucHien;
Var i,j,z:byte;
    k:boolean;
Begin
 d:=0;
 For i:=1 to n do
  Begin
   j:=1;
   k:=False;
   While (j<=d)and(not k) do
    Begin
     z:=2;
     While (z<=B[j,1]+1)and(not Kt(B[j,z],i)) do Inc(z);
     If z>B[j,1]+1 then k:=True
     Else Inc(j);
    End;
   Inc(B[j,1]);
   B[j,B[j,1]+1]:=i;
   If j>d then d:=j;
  End;
End;
Procedure Output;
Var f:text;
    i,j:byte;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,d);
 For i:=1 to d do
  Begin
   Write(f,B[i,1],' ');
   For j:=2 to B[i,1]+1 do Write(f,B[i,j],' ');
   Writeln(f);
  End;
 Close(f);
End;
Begin
 Clrscr;
  Fillchar(B,sizeof(B),0);
  Input;
  ThucHien;
  Output;
 Readln;
End.