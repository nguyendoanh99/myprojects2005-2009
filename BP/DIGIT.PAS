 Uses crt;
Const fi='C:\DIGIT.INP';
      fo='C:\DIGIT.OUT';
      T:array['A'..'F'] of byte=(10,11,12,13,14,15);
Var x:char;
    l:longint;
    A,b:array[0..15] of byte;
    C:array[0..15] of boolean;
    dem:longint;
Function Doi(s:char):byte;
Var o,d:integer;
Begin
 If (s>='0')and(s<='9') then    val(s,o,d)
  Else
    o:=t[s];
 Doi:=o;
End;
Procedure Input;
Var f:text;
    m:string;
    o:integer;
    i:byte;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,m);
 For i:=1 to length(m) do
  Begin
   o:=Doi(m[i]);
    Inc(a[o]);
    C[o]:=true;
  End;
 Readln(f,l);
 Readln(f,x);
 dem:=a[doi(x)];
 Close(f);
End;
Procedure Coso(p:integer);
Begin
 Repeat
  Inc(b[p mod 16]);
  c[p mod 16]:=true;
  p:=p div 16;
 Until p=0;
End;
Procedure Thuchien;
Var i:longint;
    j:byte;
Begin
 For i:=1 to l do
  Begin
   For j:=0 to 15 do
    If c[j] then Inc(b[j]);
   For j:=0 to 15 do
    Begin
     
     If a[j]<>0 then
      Begin
       If (a[j]>0)and(a[j]<=9) then
        Begin
         Inc(b[a[j]]);
         c[a[j]]:=true;
         End
       Else Coso(a[j]);
      End;
    End;
   dem:=dem+b[doi(x)];
   a:=b;
   fillchar(b,sizeof(b),0);
  End;
End;
Procedure Output;
Var f:text;
Begin
 Assign(f,fo);Rewrite(f);
 Write(f,dem);
 Writeln(dem);
 Close(f);
End;
Begin
 clrscr;
 Fillchar(c,sizeof(c),false);
 Fillchar(b,sizeof(c),0);
 dem:=0;
 Input;
 ThucHien;
 Output;
End.
