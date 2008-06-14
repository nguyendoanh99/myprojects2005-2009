{Bai 196/2004 - Mon qua dau nam}
Uses crt;
const fi='C:\HELPUS.TXT';
      fo='C:\FORYOU.TXT';
      B:array[1..3] of byte=(3,5,7);
Var A:array[0..3000] of longint;
    d:integer;
Function Tim(n:integer):longint;
Var k,i,j:longint;
    t:shortint;
    m:integer;
Begin
 t:=1;
 If n mod 10>5 then
  Begin
   t:=-1;
   i:=(n div 10)+1
  End
 Else i:=n div 10;
 If i>d then
  Begin
   i:=d;
   t:=1;
  End;
 m:=i*10;
 i:=A[i];
 While m<>n do
  Begin
   Inc(i,t*2);
   k:=i;
   For j:=1 to 3 do
    While k mod B[j]=0 do k:=k div B[j];
   If k=1 then
    Begin
     Inc(m,t);
     Write(i:10);
     If m mod 10=0 then
      Begin
       Inc(d);
       A[d]:=i
      End
    End
  End;
 Tim:=i
End;
Procedure InOutPut;
Var n,a,i:integer;
    f,g:text;
Begin
 Assign(f,fi);Reset(f);
 Assign(g,fo);Rewrite(g);
 Readln(f,n);
 For i:=1 to n do
  Begin
   Readln(f,a);
   Write(g,Tim(a),' ');
  End;
 Close(f);
 Close(g);
End;
Begin
 Clrscr;
  d:=0;
  A[0]:=1;
  Writeln(Tim(21):10);
{  InOutPut;         }
 Readln
End.
