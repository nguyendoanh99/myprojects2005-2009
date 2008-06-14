Uses crt;
Const fi='C:\DAYSO.INP';
      fo='C:\DAYSO.OUT';
Var n:integer;
    A:array[1..301] of integer;
    C:array[1..300] of char;
Procedure Input;
Var f:text;
Begin
 Assign(f,fi);Reset(f);
 n:=0;
 Fillchar(c,sizeof(c),0);
 While not eof(f) do
  Begin
   Inc(n);
   A[n]:=1;
   Read(f,c[n]);
  End;
 a[n+1]:=1;
 Close(f);
End;
Function SS(v1,v2,t:integer):boolean;
Begin
 Case c[t] of
 '>':SS:=a[v1]>a[v2];
 '<':SS:=a[v1]<a[v2];
 '=':SS:=a[v1]=a[v2];
 End;
End;
Procedure Duyet1;
Var i:integer;
Begin
 For i:=1 to n do
  If not SS(i,i+1,i) then
   Case c[i] of
   '<':a[i+1]:=a[i]+1;
   '=':a[i+1]:=a[i];
   End;
End;
Procedure Duyet2;
Var i:integer;
Begin
 For i:=n+1 downto 2 do
  If not SS(i-1,i,i-1) then
   Case c[i-1] of
   '>':a[i-1]:=a[i]+1;
   '=':a[i-1]:=a[i];
   End;
End;
Procedure Output;
Var f:text;
    i:integer;
Begin
 For i:=1 to n+1 do Write(a[i],c[i]);
End;
Begin
 Clrscr;
 Input;
 Duyet1;
 Duyet2;
 Output;
End.