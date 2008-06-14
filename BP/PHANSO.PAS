Uses crt;
Var A:Array[1..100] of record
                        a,b:byte
                       End;
    d,n,i,j:byte;
Procedure Sapxep;
Var i,j:byte;
    t:record
       a,b:byte;
      End;
Begin
 For i:=1 to d do
  For j:=i+1 to d do
   If A[i].a/A[i].b>A[j].a/a[j].b then
    Begin
     t.a:=A[i].a;
     t.b:=A[i].b;
     A[i].a:=a[j].a;
     A[i].b:=a[j].b;
     A[j].a:=t.a;
     A[j].b:=t.b
    End
End;
Begin
 Clrscr;
  a[1].a:=0;
  a[1].b:=1;
  d:=1;
  Write('n=');Readln(n);
  For i:=1 to n-1 do
   For j:=n downto i+1 do
    If (j mod i<>0)or(i=1) then
    Begin
     Inc(d);
     A[d].a:=i;
     A[d].b:=j;
    End;
  Inc(d);A[d].a:=1;a[d].b:=1;
  Sapxep;
  For i:=1 to d do write(a[i].a,'/',a[i].b,' ');Writeln;
  Write(d);
 Readln
End.