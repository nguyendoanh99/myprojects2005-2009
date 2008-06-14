Uses crt;
Const Ai:array[1..4] of shortint=(-1,0,1,0);
      Aj:array[1..4] of shortint=(0,1,0,-1);
      fi='C:\XUCXAC.INP';
      fo='C:\XUCXAC.OUT';
Var A:array[1..10,1..10] of integer;
    t,p,d,t1,t2,m,n:integer;
Procedure Input;
Var f:text;
    i,j:integer;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,t,p,d);
 Readln(f,m,n);
 For i:=1 to m do
  Begin
   For j:=1 to n do Read(f,a[i,j]);
   Readln(f)
  End;
 Close(f)
End;
Procedure Try(y,x,t,p:integer);
Var i,k,t1,p1:integer;
Begin
 If (y=m)and(x=n) then
  Begin
   If t1<t2 then t2:=t1
  End
 Else
  For i:=1 to 4 do
   Begin
    Case i of
    1:Begin
       k:=7-t;
       t1:=A[y,x];
       p1:=p
      End;
    2:Begin
       k:=p;
       t1:=t;
       p1:=7-A[y,x]
      End;
    3:Begin
       k:=t;
       t1:=7-A[y,x];
       p1:=p
      End;
    4:Begin
       k:=7-p;
       t1:=t;
       p1:=p
      End
    End;
    If (y+ai[i]>0)and(y+ai[i]<=m)
       and(x+aj[i]>0)and(x+aj[i]<=n)
       and(A[y+ai[i],x+aj[i]]=k) then
     Begin
      Inc(t1,A[y,x]);
      Try(y+ai[i],x+aj[i],t1,p1);
      Dec(t1,A[y,x])
     End
   End
End;
Procedure Output;
Var f:text;
Begin
 Assign(f,fo);Rewrite(f);
 If t2=maxint then Writeln(f,'Khong co duong di')
 Else Writeln(f,t2);
 Close(f)
End;
Begin
 Clrscr;
 t1:=0;
 t2:=maxint;
 Input;
 Try(1,1,t,p);
 Output;
End.