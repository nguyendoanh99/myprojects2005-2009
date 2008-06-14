Uses crt;
Const tf='C:\DAYTF.INP';
Var a:array[1..255] of char;
    s,i,j,n,p:integer;
Procedure Nhap;
Var f:text;
    i:integer;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,n);
 For i:=1 to n do Readln(f,a[i]);
 Close(f);
End;
Function Sosanh(p,s:integer):boolean;
Var t,f,i:integer;
Begin
 t:=0;
 f:=0;
 For i:=p to s do
  If a[i]='F' then Inc(f)
  Else Inc(t);
 Sosanh:=t=f;
End;
Procedure Tim(var p,s:integer);
Begin
 p:=0;
 s:=0;
 For i:=1 to n-1 do
  For j:=n downto i+1 do
   If odd(j-i) then
    If (Sosanh(i,j))and(p<j-i+1) then
     Begin
      p:=j-i+1;
      s:=i
     End
End;
Begin
 Clrscr;
 Nhap;
 Tim(p,s);
 Write(p,' ',s);
 Readln;
End.