Uses crt;
Const fi='C:\DISTANCE.INP';
      fo='C:\DISTANCE.OUT';
Var s:string;
Function Tang(s:char):char;
Begin
 Case s of
 '0':Tang:='1';
 '1':Tang:='2';
 '2':Tang:='3';
 '3':Tang:='4';
 '4':Tang:='5';
 '5':Tang:='6';
 '6':Tang:='7';
 '7':Tang:='8';
 '8':Tang:='9';
 '9':Tang:='A';
 'A':Tang:='B';
 'B':Tang:='C';
 'C':Tang:='D';
 'D':Tang:='E';
 'E':Tang:='F';
 'F':Tang:='0'
 End
End;
Function Add(s:string):string;
Var n,i:byte;
Begin
 s[length(s)]:=Tang(s[length(s)]);
 If s[length(s)]='0' then n:=1
 Else n:=0;
 i:=length(s)-1;
 While (i>=1)and(n=1) do
  Begin
   s[i]:=Tang(s[i]);
   If s[i]='0' then n:=1
   Else n:=0;
   Dec(i)
  End;
 If n=1 then s:='1'+s;
 Add:=s
End;
Function XuLy(s:string):longint;
Var s1,s2:string;
    i,j,x:byte;
    d:longint;
Begin
 s1:='';
 s2:='0';
 For x:=1 to 2 do
  Begin
   i:=1;
   j:=1;
   d:=0;
   While length(s1)<length(s) do
    Begin
     s2:=Add(s2);
     s1:=s1+s2
    End;
   Repeat
    If s1[j]=s[i] then
     Begin
      Inc(i);
      Inc(j)
     End
    Else
     Begin
      Delete(s1,1,1);
      Inc(d);
      While length(s1)<length(s) do
       Begin
        s2:=Add(s2);
        s1:=s1+s2
       End;
      i:=1;
      j:=1
     End;
   Until j>length(s);
   Delete(s1,1,length(s));
  End;
 Xuly:=d
End;
Procedure In_Ouput;
Var f,g:text;
    s:string;
Begin
 Assign(f,fi);Reset(f);
 Assign(g,fo);Rewrite(g);
 While not eof(f) do
  Begin
   Readln(f,s);
   Writeln(g,Xuly(s))
  End;
 Close(f);
 Close(g)
End;
Begin
 Clrscr;
  In_Ouput;
 Readln
End.