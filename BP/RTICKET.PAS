Uses crt;
Const tf='D:\RTICKET.INP';
Var L:array[1..3] of integer;
    C:array[1..3] of integer;
    d,s,t,n:byte;
    A:array[1..10] of byte;
    tcu,tmoi:integer;
Procedure Input;
Var f:text;
    i:byte;
Begin
 Assign(f,tf);Reset(f);
 For i:=1 to 3 do Read(f,l[i]);
 For i:=1 to 3 do Read(f,c[i]);
 Readln(f);
 Readln(f,n);
 Readln(f,s,t);
 For i:=2 to n do Readln(f,a[i]);
 Close(f)
End;
Procedure Try(m,n:byte);
Var i:Byte;
    h:integer;
Begin
 i:=m;
 Repeat
  h:=a[i]-a[n];
  If (0<h)and(h<=l[3]) then
   Begin
    If (0<h)and(h<=l[1]) then Inc(tcu,c[1])
    Else
     If (l[1]<h)and(h<=l[2]) then Inc(tcu,c[2])
     Else
      If (l[2]<h)and(h<=l[3]) then Inc(tcu,c[3]);
    If i=t then
     Begin
      If tmoi>tcu then tmoi:=tcu
     End
    Else Try(i+1,m);
    If (0<h)and(h<=l[1]) then Dec(tcu,c[1])
    Else
     If (l[1]<h)and(h<=l[2]) then Dec(tcu,c[2])
     Else
      If (l[2]<h)and(h<=l[3]) then Dec(tcu,c[3])
   End;
  Inc(i)
 Until (i>t)or(h>l[3])
End;
Begin
 Clrscr;
  Input;
  tmoi:=32000;
  tcu:=0;
  Try(s+1,s);
  Write(tmoi);
 Readln
End.