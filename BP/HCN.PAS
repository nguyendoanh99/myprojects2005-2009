Uses crt;
Const tf='D:\INPUT.INP';
      Cj:array[1..3] of shortint = (-1,0,1);
      Ci:array[1..3] of shortint = (1,1,1);
Var i,t,tcu,Tmoi,m,n,x,y1,y2:integer;
    A:array[1..5,1..5] of integer;
    B,C:array[1..10] of record
                         x,y:byte
                        End;
Procedure Input;
Var f:text;
    i,j:integer;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,m,n);
 For i:=1 to m do
  Begin
   For j:=1 to n do
    Begin
     Read(f,a[i,j]);
     Write(a[i,j],' ')
    End;
   Writeln
  End;
 Close(f)
End;
Procedure Try(x,y:byte);
Var i:byte;
Begin
 If x<>n then
  For i:=1 to 3 do
   If ((i=1)and(x<n)and(y>1))or((i=2)and(x<n))or((i=3)and(x<n)and(y<m)) then
    If abs(n-x)>=abs(y2-y) then
     Begin
      Inc(tmoi,a[y+cj[i],x+ci[i]]);
      Inc(t);
      B[t].x:=x+ci[i];
      B[t].y:=y+cj[i];
      If (b[t].x=n)and(b[t].y=y2)and(tmoi<tcu) then
       Begin
        tcu:=tmoi;
        c:=b
       End
      Else Try(b[t].x,b[t].y);
      Dec(tmoi,a[y+cj[i],x+ci[i]]);
      B[t].x:=0;
      B[t].y:=0;
      Dec(t);
     End
End;
Begin
 Clrscr;
  Input;
  Write('Dau va cuoi = ');Readln(y1,y2);
  tcu:=32000;
  tmoi:=a[y1,1];
  Fillchar(b,sizeof(b),0);
  Fillchar(c,sizeof(c),0);
  t:=1;
  B[t].x:=1;
  B[t].y:=y1;
  Try(1,y1);
  Writeln(tcu);
  i:=1;
  While (c[i].x<>0)and(c[i].y<>0) do
   Begin
    Writeln(c[i].y,' ',c[i].x);
    Inc(i)
   End;
 Readln
End.