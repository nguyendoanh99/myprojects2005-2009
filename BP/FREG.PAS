Uses crt;
Const tf='D:\FREG.INP';
Var A:array[65..90] of integer;
    Max,i:integer;
Procedure Input;
Var f:text;
    s:string;
    i:integer;
Begin
 Assign(f,tf);Reset(f);
 While not eof(f) do
  Begin
   Readln(f,s);
   Writeln(s);
   For i:=1 to length(s) do
    If ord(s[i]) in [97..119] then Inc(A[ord(s[i])-32])
    Else Inc(A[ord(s[i])])
  End;
 Close(f);
 max:=65;
 For i:=66 to 90 do
  If a[i]>a[max] then max:=i
End;
Begin
 Clrscr;
  Fillchar(A,Sizeof(a),0);
  Input;
  Write(chr(max),' ',a[max]);
 Readln
End.