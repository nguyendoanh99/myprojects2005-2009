{Bai 172/2004 - Nha guong cuoi}
Uses crt;
Const fi='C:\MIRROR.INP';
      fo='C:\MIRROR.OUT';
      nmax=33;
      Ai:array[1..4] of shortint=(-1,0,1,0);
      Aj:array[1..4] of shortint=(0,1,0,-1);
Type Mang=array[0..nmax+1,0..nmax+1] of char;
Var A:Mang;
    n:byte;
    d:word;
Procedure Input;
Var f:text;
    i,j:byte;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n);
 For i:=1 to n do
  Begin
   For j:=1 to n do Read(f,A[i,j]);
   Readln(f)
  End;
 For i:=0 to n+1 do
  Begin
   A[i,0]:='#';
   A[i,n+1]:='#';
   A[0,i]:='#';
   A[n+1,i]:='#'
  End;
 For i:=0 to n+1 do
  Begin
   For j:=0 to n+1 do Write(a[i,j]);
   Writeln
  End;
 Close(f)
End;
Procedure Try(y,x:byte);
Var i:byte;
Begin
 A[y,x]:='1';
 For i:=1 to 4 do
  If A[y+Ai[i],x+Aj[i]]='#' then Inc(d);
 For i:=1 to 4 do
  If A[y+Ai[i],x+Aj[i]]='.' then
   Try(y+Ai[i],x+Aj[i])
End;
Procedure OutPut;
Var f:text;
Begin
 Assign(f,fo);Rewrite(f);
 Write(f,(d-4)*9);
 Close(f)
End;
Begin
 Clrscr;
  Input;
  d:=0;
  Try(1,1);
  OutPut;
  Writeln(d-4);
 Readln
End.