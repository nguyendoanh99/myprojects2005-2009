Uses crt;
Const tf='D:\SQUARE.IN';
Var A:array[1..100,1..100] of 0..1;
    tcu,tmoi,m,n,p,q:word;
Procedure Input;
Var i,j:word;
    f:text;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,m,n);
 For i:=1 to m do
  For j:=1 to n do Read(f,a[i,j]);
 Close(f)
End;
Function Kt(p,q,t:word):boolean;
Var i,j:word;
    k:boolean;
Begin
 i:=q;
 j:=p+t;
 k:=true;
 While (i<=q+t)and(a[j,i]=1) do Inc(i);
 If i>q+t then
  Begin
   i:=p;
   j:=q+t;
   While (i<=p+t-1)and(a[i,j]=1) do Inc(i);
   If i<=p+t-1 then k:=false;
  End
 Else k:=false;
 kt:=k
End;
Procedure Try;
Var i,j:word;
Begin
 i:=1;
 Repeat
  j:=1;
  Repeat
   If (A[i,j]=1)and(i+tcu<m)and(j+tcu<n) then
    Begin
     tmoi:=0;
     While Kt(i,j,tmoi) do Inc(tmoi);
     If tmoi>tcu then
      Begin
       p:=i;
       q:=j;
       tcu:=tmoi-1
      End
    End;
   Inc(j)
  Until j>=n-tcu;
  Inc(i)
 Until i>=m-tcu
End;
Begin
 Clrscr;
  Input;
  tcu:=0;
  tmoi:=0;
  Try;
  Writeln(tcu+1);
  Write(p,' ',q,' ',p+tcu,' ',q+tcu);
 Readln
End.