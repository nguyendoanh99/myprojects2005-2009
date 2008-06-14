Uses crt;
Const tf='D:\MAP.IN';
      Ai:array[1..4] of -1..1=(-1,0,1,0);
      Aj:array[1..4] of -1..1=(0,1,0,-1);
Var A:array[1..600] of string[70];
    Td:record
        x,y:integer;
       End;
    Ltcu,Ltmoi:longint;
    c:char;
    maxi:0..2000;
    maxj:1..70;
    i,j:integer;
Procedure Input;
Var f:text;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,c);
 maxi:=0;
 While not eof(f) do
  Begin
   Inc(maxi);
   Readln(f,a[maxi])
  End;
 Maxj:=length(A[maxi]);
 Close(f)
End;
Procedure MaHoa(k,l:integer;c,c1:char);
Var i,j:integer;
Begin
 A[k][l]:=c1;
 For i:=1 to 4 do
  If (i<>0)or((i=3)and(k+ai[i]<=maxi))or((i=1)and(k+ai[i]>0)) then
   For j:=1 to 4 do
    If ((j<>0)or((j=2)and(l+aj[j]<=maxj))or((j=4)and(l+aj[j]>0)))and(A[k+ai[i]][l+aj[j]]=c) then
     Begin
      Inc(Ltmoi);
      Mahoa(k+ai[i],l+aj[j],c,c1);
     End
End;
Begin
 Clrscr;
  Input;
  Ltcu:=0;
  For i:=1 to maxi do
   For j:=1 to maxj do
    If A[i][j]=c then
     Begin
      Ltmoi:=1;
      MaHoa(i,j,c,'1');
      If ltcu<ltmoi then
       Begin
        ltcu:=ltmoi;
        td.x:=i;
        td.y:=j
       End
     End;
  Mahoa(td.x,td.y,'1','*');
  For i:=1 to maxi do Writeln(a[i]);
  Write(ltcu);
 Readln
End.