Uses crt;
Const fi='D:\FOOD.INP';
      fo='D:\FOOD.OUT';
      maxn=100;
Var A:array[0..maxn,0..maxn] of integer;
    B:array[1..maxn,1..maxn] of integer;
    m,n:word;
Procedure Input;
Var f:text;
    i,j:integer;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,m,n);
 Fillchar(a,sizeof(a),0);
 For i:=1 to m do
  Begin
   For j:=1 to n do Read(f,a[i,j]);
   Readln(f);
  End;
 Close(f);
End;
Function Max(y,x:integer):integer;
Begin
 If A[y-1,x]>A[y,x-1] then
  Begin
   max:=A[y-1,x];
   B[y,x]:=y-1;
  End
 Else
  Begin
   max:=A[y,x-1];
   B[y,x]:=y;
  End;
End;
Procedure Tao;
Var i,j:integer;
Begin
 For i:=1 to m do
  For j:=1 to n do
   If i=m then
    Begin
     b[i,j]:=i-1;
     a[i,j]:=a[i-1,j]+a[i,j]
    End
   Else a[i,j]:=max(i,j)+a[i,j];
 For i:=1 to m do  Begin
  For j:=1 to n do Write(a[i,j]:3,' ');Writeln; End;
End;
Procedure Output;
Var f:text;
    maxx,k,i,j,t:integer;
    C:array[1..maxn+2] of byte;
Begin
 Assign(f,fo);Rewrite(f);
 maxx:=a[m,1];
 k:=1;
 For i:=2 to n do
  If maxx<a[m,i] then
   Begin
    maxx:=a[m,i];
    k:=i;
   End;
 Writeln(f,maxx);
 j:=m;
 C[1]:=m;
 t:=1;
 Repeat
  Inc(t);
  C[t]:=B[j,k];
  If C[t]=j then Dec(k);
  j:=C[t];
 Until (k=1)and(j=1);
 Write(f,'(1,1) ');
 j:=1;
 For i:=t-1 downto 1 do
  Begin
   If C[i]=C[i+1] then Inc(j);
   Write(f,'(',C[i],',',j,') ');
  End;
 Close(f);
End;
Begin
 Clrscr;
 Input;
 Tao;
 Output;
End.