Uses crt;
Const tf='D:\MATSYM.IN';
Type ct=^contro;
     contro=record
             so:byte;
             Tiep:ct
            End;
Var A:array[1..100] of ct;
    ht:ct;
    x,y,i,j,n,d,d1:byte;
Procedure Input;
Var i,j:byte;
    f:text;
    t:ct;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,n);
 For i:=1 to n do
  Begin
   A[i]:=nil;
   For j:=1 to n do
    Begin
     New(t);
     Read(f,t^.so);
     t^.tiep:=nil;
     If a[i]<>nil then
      Begin
       ht^.tiep:=t;
       ht:=t
      End
     Else
      Begin
       A[i]:=t;
       ht:=A[i]
      End
    End
  End;
 Close(f)
End;
Function Xem(j,k:byte):byte;
Var i:byte;
Begin
 ht:=a[j];
 For i:=1 to k-1 do ht:=ht^.tiep;
 Xem:=ht^.so
End;
Procedure Try(y,x:byte;var f:byte);
Var m,i,j,d1:byte;
    k:boolean;
Begin
 If n-x>n-y then m:=n-y
 Else m:=n-x;
 Inc(m);
 If m>d then
  Begin
   d1:=d+1;
   k:=true;
   While (d1<=m)and(k) do
    Begin
     i:=1;
     While (i<=d1)and(k) do
      Begin
       j:=i+1;
       While (j<=d1)and(k) do
        Begin
         If Xem(i+y-1,j+x-1)<>Xem(j+y-1,i+x-1) then k:=false;
         Inc(j)
        End;
       Inc(i)
      End;
     If not k then f:=d1-1;
     Inc(d1)
    End;
   If k then f:=d1-1
  End
 Else f:=0
End;
Begin
 Clrscr;
  Input;
  d:=0;
  For i:=1 to n do
   For j:=1 to n do
    Begin
     Try(i,j,d1);
     If d1>d then
      Begin
       d:=d1;
       y:=i;
       x:=j
      End
    End;
  Write(y,' ',x,' ',d);
 Readln
End.