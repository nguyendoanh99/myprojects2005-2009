Uses crt;
Const tf='D:\LINES.IN';
      Ai:array[1..4] of -1..1=(-1,0,1,0);
      Aj:array[1..4] of -1..1=(0,1,0,-1);
      n=9;
Type Toado=record
            y,x:byte;
           End;
Var A:array[0..n-1,0..n-1] of '0'..'3';
    A1:array[1..n*n div 2] of byte;
    Ddicu,Ddimoi:array[1..n*n+1] of byte;
    da,dcu,dmoi,t,s,i:byte;
    td1:toado;
    td:array[1..2] of toado;
Procedure Input;
Var f:text;
    i,d:0..n;
    j:byte;
    s:string;
Begin
 Assign(f,tf);Reset(f);
 For i:=0 to n-1 do
  Begin
   Readln(f,s);
   d:=0;
   For j:=1 to length(s) do
    If s[j]<>' ' then
     Begin
      a[i,d]:=s[j];
      Inc(d)
     End
  End;
 For i:=0 to n-1 do
  Begin
   For j:=0 to n-1 do Write(a[i,j],' ');
   Writeln
  End;
 Close(f)
End;
Procedure Bd(m:byte;Var b:toado);
Begin
 b.y:=m div n;
 b.x:=m mod n;
End;
Procedure Try(y1,x1,y2,x2:byte);
Var i,j,z,b:byte;
Begin
 For i:=1 to 4 do
  If (y1+ai[i]>=0)and(y1+ai[i]<n)and(x1+aj[i]>=0)and(x1+aj[i]<n)then
   If (A[y1+ai[i],x1+aj[i]]='0')and(dcu>dmoi+da) then
    Begin
     Inc(dmoi);
     Ddimoi[dmoi]:=((y1+ai[i])*n)+x1+aj[i];
     A[y1+ai[i],x1+aj[i]]:='2';
     For j:=1 to 4 do
      If (y2+ai[j]>=0)and(y2+ai[j]<n)and(x2+aj[j]>=0)and(x2+aj[j]<n) then
       If (A[y2+ai[j],x2+aj[j]]='0')and(dcu>da+dmoi) then
        Begin
         Inc(da);
         A1[da]:=((y2+ai[j])*n)+x2+aj[j];
         A[y2+ai[j],x2+aj[j]]:='3';
         Try(y1+ai[i],x1+aj[i],y2+ai[j],x2+aj[j]);
         A1[da]:=0;
         A[y2+ai[j],x2+aj[j]]:='0';
         Dec(da)
        End
       Else
        If A[y2+ai[j],x2+aj[j]]='2' then
         Begin
          z:=dmoi;
          While Ddimoi[z]<>((y2+ai[j])*n)+x2+aj[j] do Dec(z);
          If z+da<dcu then
           Begin
            dcu:=z+da;
            For b:=1 to z do Ddicu[b]:=Ddimoi[b];
            For b:=da downto 1 do Ddicu[dcu-b+1]:=A1[b];
           End
         End;
     Ddimoi[dmoi]:=0;
     A[y1+ai[i],x1+aj[i]]:='0';
     Dec(dmoi)
    End
   Else
    If A[y1+ai[i],x1+aj[i]]='3' then
     Begin
      z:=da;
      While A1[z]<>((y1+ai[i])*n)+x1+aj[i] do Dec(z);
      If dmoi+z<dcu then
       Begin
        dcu:=dmoi+z;
        Ddicu:=Ddimoi;
        For b:=z downto 1 do Ddicu[dcu-b+1]:=A1[b]
       End
     End
End;
Begin
 Clrscr;
  Input;
  Write('s=');readln(td[1].y,td[1].x);
  Write('t=');readln(td[2].y,td[2].x);
  If (A[td[1].y,td[1].x]='1')and(A[td[2].y,td[2].x]='0') then
   Begin
    dcu:=255;
    dmoi:=0;
    A[td[1].y,td[1].x]:='2';
    A[td[2].y,td[2].x]:='3';
    dmoi:=1;
    da:=1;
    Fillchar(A1,sizeof(A1),0);
    Fillchar(Ddimoi,sizeof(Ddimoi),0);
    Ddimoi[1]:=(td[1].y*n)+td[1].x;
    A1[1]:=(td[2].y*n)+td[2].x;
    Try(td[1].y,td[1].x,td[2].y,td[2].x);
    If dcu<>255 then
     Begin
      Textcolor(14);
      For i:=1 to dcu do
       Begin
        Bd(Ddicu[i],td1);
        Gotoxy((td1.x+1)*2-1,td1.y+1);Write('*');
       End
     End
    Else Writeln('Khong the di chuyen duoc.')
   End
  Else Writeln('Khong the di chuyen duoc.');
 Readln
End.