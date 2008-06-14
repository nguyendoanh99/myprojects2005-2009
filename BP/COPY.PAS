Uses crt;
Const fi='C:\COPY.INP';
      fo='C:\COPY.OUT';
Var f,g:text;
    i,j,z,n:integer;
    s:string[11];
    s1:string;
    k:boolean;
Begin
 Clrscr;
 Assign(f,fi);Reset(f);
 Readln(f,n);
 s:='???????????';
 Readln(f,s1);
 k:=false;
 Repeat
  If s1[1]='+' then
   Begin
    j:=2;
    Repeat
     s[j-1]:=s1[j];
     Inc(j);
    Until (j>length(s1))or(s1[j]='.');
    If (j<length(s1)) then
     Begin
      z:=j+1;
      Repeat
       s[8+z-j]:=s1[z];
       Inc(z);
      Until (z>length(s1));
     End;
   End
  Else k:=true;
 Until (s1[1]='+');
 For i:=2 to n do
  Begin
   Readln(f,s1);
   If s1[1]='+' then
    Begin
     j:=2;
     Repeat
      If s[j-1]<>s1[j] then s[j-1]:='?';
      Inc(j);
     Until (j>length(s1))or(s1[j]='.');
     For z:=j-1 to 8 do s[z]:='?';
     If (j<length(s1)) then
      Begin
       z:=j+1;
       Repeat
        If s[8+z-j]<>s1[z] then s[8+z-j]:='?';
        Inc(z);
       Until (z>length(s1));
      End;
    End
   Else
    Begin
     k:=true;
     j:=2;
     Repeat
      If s[j-1]=s1[j] then s[j-1]:='?';
      Inc(j);
     Until (j>length(s1))or(s1[j]='.');
     For z:=j-1 to 8 do s[z]:='?';
     If (j<length(s1)) then
      Begin
       z:=j+1;
       Repeat
        If s[8+z-j]=s1[z] then s[8+z-j]:='?';
        Inc(z);
       Until (z>length(s1));
      End;
    End;
  End;
 If (k)and(s='???????????') then Writeln('KHONG CO')
 Else
  Begin
   i:=8;
   While (i>0)and(s[i]='?') do Dec(i);
   s1:=copy(s,9,3);
   s:=copy(s,1,i)+'*';
   i:=3;
   While (i>0)and(s1[i]='?') do Dec(i);
   s1:=copy(s1,1,i)+'*';
   Writeln('COPY A:\',s,'.',s1);
  End;
 Close(f);
 Readln;
End.