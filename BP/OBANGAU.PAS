Uses crt;
Const fi='C:\OBANGAU.INP';
      fo='C:\OBANGAU.OUT';
      maxn=100;
Var A:array[1..maxn,1..maxn] of byte;
    Tham:array[1..maxn] of boolean;
    B:array[1..2,1..maxn] of integer;
    j,vt,v,d,i,dich,n,s,t:byte;
    MinD,MinT,Tong:integer;
Procedure Input;
Var f:text;
    i,m:integer;
    x,y,l:byte;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n,m,s,t);
 For i:=1 to m do
  Begin
   Readln(f,x,y,l);
   A[x,y]:=l;
   A[y,x]:=l;
  End;
 Close(f);
End;
Procedure Try(x:byte);
Var i:byte;
Begin
 If x=dich then B[v,d]:=Tong
 Else
  Begin
   For i:=1 to n do
    If (A[x,i]<>0)And(not Tham[i]) then
     Begin
      Inc(Tong,A[x,i]);
      Tham[i]:=True;
      Inc(d);
      Try(i);
      Dec(d);
      Dec(Tong,A[x,i]);
      Tham[i]:=False;
     End;
  End;
End;
Procedure Output;
Var f:text;
Begin
 Assign(f,fo);Rewrite(f);
 If vt=0 then
  Begin
   Writeln(f,'CRY');
   Writeln('CRY');
  End
 Else
  Begin
   Writeln(f,vt);
   Writeln(vt);
  End;
 Close(f);
End;
Begin
 Clrscr;
 Fillchar(A,sizeof(A),0);
 Fillchar(Tham,sizeof(Tham),False);
 Input;
 MinD:=maxint;
 vt:=0;
 d:=0;
 Tong:=0;
 For i:=1 to n do
  If (i<>s)and(i<>t) then
   Begin
    Fillchar(B,sizeof(B),0);
    Tham[i]:=True;
    dich:=s;
    v:=1;
    Try(i);
    dich:=t;
    v:=2;
    Try(i);
    MinT:=maxint;
    For j:=1 to n do
     If (B[1,j]>0)and(B[2,j]>0) then
      If B[1,j]+B[2,j]<MinT then MinT:=B[1,j]+B[2,j];
    If MinT<MinD then
     Begin
      MinD:=MinT;
      vt:=i;
     End;
    Tham[i]:=False;
   End;
 Output;
 Readln
End.