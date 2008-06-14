Uses crt;
Const fi='C:\PALINDR.INP';
      fo='C:\PALINDR.OUT';
Var s:string;
    A,A1:array[1..255] of byte;
    d,d1:integer;
Function Palindrome(s:string):boolean;
Var i:byte;
Begin
 Palindrome:=True;
 For i:=1 to Length(s) div 2 do
  If s[i]<>s[length(s)-i+1] then
   Begin
    Palindrome:=False;
    Exit
   End
End;
Procedure Input;
Var f:text;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,s);
 Close(f)
End;
Procedure Try(s:string);
Var i:byte;
Begin
 If s<>'' then
  Begin
   For i:=1 to length(s) do
    If Palindrome(copy(s,1,i)) then
     Begin
      Inc(d);
      A[d]:=i;
      Try(copy(s,i+1,length(s)-i));
      Dec(d)
     End
  End
 Else
  If d<d1 then
   Begin
    d1:=d;
    A1:=A
   End;
End;
Procedure Output;
Var i,j:integer;
    f:text;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,d1);
 j:=1;
 For i:=1 to d1 do
  Begin
   Writeln(f,copy(s,j,A1[i]));
   Inc(j,A1[i])
  End;
 Close(f)
End;
Begin
 Clrscr;
  d:=0;
  d1:=256;
  Input;
  Try(s);
  Output;
 Readln
End.
