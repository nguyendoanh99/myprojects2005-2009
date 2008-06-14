Uses crt;
Var i,m,tong,tich,r:integer;
    B,A:array[1..100] of byte;
Procedure Try(i:byte);
Var j:byte;
Begin
 If (tich<=R)and(tong<R) then
  Begin
   j:=1;
   Repeat
    tich:=tich*j;
    tong:=tong+j;
    Inc(m);
    A[m]:=j;
    If not((tich=R)and(tong=R)) then
     Begin
      Try(j);
      tich:=tich div a[m];
      tong:=tong-a[m];
      A[m]:=0;
      Dec(m)
     End
    Else
     If (tich=R)and(tong=R) then
      Begin
       b:=a;
       exit
      End;
    Inc(j)
   Until j=5;
  End
End;
Begin
 Clrscr;
  Write('R = ');Readln(r);
  Fillchar(a,sizeof(a),0);
  tong:=0;
  Tich:=1;
  m:=0;
  Try(1);
  i:=1;
  While b[i]<>0 do
   Begin
    Write(b[i],' ');
    Inc(i);
   End;
  If i=1 then write('Khong co cach bien doi.');
 Readln
End.