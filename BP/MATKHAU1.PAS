Uses crt;
Const fi='C:\MATKHAU.INP';
      fo='C:\MATKHAU.OUT';
Type so=record
      cs:integer;
      mu:integer;
     End;
Var maxc,k:byte;
    A:array[1..100] of integer;
    B,C:array[1..100] of so;
Function Lt(tam:so):longint;
Var t:longint;
    i:byte;
Begin
 t:=1;
 For i:=1 to tam.mu do t:=t*tam.cs;
 lt:=t;
End;
Procedure Chen(vt:byte;tam:so);
Var i:byte;
Begin
 If not((vt>maxc)or(maxc=0)) then
  For i:=maxc downto vt do c[i+1]:=c[i];
 c[vt]:=tam;
 Inc(maxc);
End;
Procedure Input;
Var f:text;
    i:byte;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,k);
 Fillchar(a,sizeof(a),0);
 For i:=1 to k do Read(f,a[i]);
 Close(f);
End;
Procedure pt(s:integer);
Var i,j,t:integer;
Begin
 Fillchar(b,sizeof(b),0);
 If s=1 then
  Begin
   b[1].cs:=1;
   b[1].mu:=1;
  End;
 i:=2;
 t:=0;
 While i<=s do
  Begin
   j:=0;
   While s mod i=0 do
    Begin
     Inc(j);
     s:=s div i;
    End;
   If j<>0 then
    Begin
     Inc(t);
     b[t].cs:=i;
     b[t].mu:=j;
    End;
   Inc(i);
  End;
End;
Procedure Output;
Var f:text;
    j,t,i:byte;
    tong:longint;
Begin
 Assign(f,fo);Rewrite(f);
 Fillchar(c,sizeof(c),0);
 For i:=1 to k do
  Begin
   pt(a[i]);
   j:=1;
   t:=1;
   While b[j].cs<>0 do
    Begin
     While (c[t].cs<>0)and(c[t].cs<b[j].cs) do Inc(t);
     If c[t].cs=b[j].cs then
      If c[t].mu<b[j].mu then c[t].mu:=b[j].mu
     Else
     Else Chen(t,b[j]);
     Inc(j);
    End;
  End;
 i:=1;
 tong:=1;
 While c[i].cs<>0 do
  Begin
   tong:=tong*lt(c[i]);
   Inc(i);
  End;
 Write(f,tong);
 Writeln(tong);
 Close(f);
End;
Begin
 Input;
 maxc:=0;
 Output;
End.