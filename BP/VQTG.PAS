Uses crt;
Const Max=10;
      tf='D:\BL3.INP';
Var A:array[0..max] of integer;
    b,c:array[0..max] of byte;
    i,tp1,tp,d1,d,p,n:integer;
Procedure Input;
Var f:text;
    i:integer;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,n);
 Readln(f,p);
 For i:=1 to n do Read(f,a[i]);
 Close(f)
End;
Procedure Try(i:integer);
Var j,k:integer;
Begin
 For j:=i to n do
   Begin
    Inc(d);
    b[d]:=j;
    tp:=tp+abs(a[j]-a[i-1]-p);
    If j<n then Try(j+1)
    Else
     Begin
      If tp1>tp then
       Begin
        tp1:=tp;
        d1:=d;
        fillchar(c,sizeof(c),0);
        For k:=1 to d1 do c[k]:=b[k]
       End
     End;
    tp:=tp-abs(a[j]-a[i-1]-p);
    b[d]:=0;
    Dec(d)
   End
End;
Begin
 Clrscr;
  tp1:=32000;
  d:=0;
  tp:=0;
  Input;
  Try(1);
  tp1:=0;
  Writeln(d1);
  For i:=1 to d1 do
   Begin
    Inc(tp1,sqr(a[c[i]]-a[c[i-1]]-p));
    Write(c[i],' ')
   End;
  Writeln;Write(tp1);
 Readln
End.