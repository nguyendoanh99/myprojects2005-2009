Uses crt;
Const max=10;
Type Mang=array[1..max,1..max] of integer;
Var A:Mang;
    B:array[1..max] of boolean;
    d:integer;
Procedure Tang(Var a:byte;Var i:shortint;n:byte);
Begin
 Inc(a,i);
 If (i=-1)and(a=0) then
  Begin
   a:=1;
   i:=1
  End
 Else
  If (i=1)and(a>n) then
   Begin
    a:=n;
    i:=-1
   End
End;
Procedure Viet(A:mang;i,n:byte);
Var j:integer;
Begin
 For j:=1 to n do Write(A[i,j]:5);Writeln;
 Inc(d)
End;
Procedure TaoSo(Var A:Mang;n:byte);
Var i,j,k,m:byte;
    B:array[1..max] of boolean;
Begin
 Fillchar(B,sizeof(B),false);
 Fillchar(A,sizeof(A),0);
 For i:=1 to n do
  Begin
   j:=0;
   m:=0;
   k:=random(n-i+1);
   Repeat
    Inc(j);
    If not B[j] then Inc(m);
   Until (m>=k)and(not B[j]);
   If j<=n div 2 then A[i,1]:=j-1
   Else A[i,1]:=j+1;
   B[j]:=True
  End
End;
Procedure HV(n,p:byte);
Var i,j,k:byte;
    m:shortint;
Begin
 TaoSo(A,n);
 If p=1 then
  For i:=1 to n do Write(A[i,1]:5)
 Else
  Begin
   Fillchar(B,sizeof(B),false);
   m:=1;
   i:=1;
   j:=1;
   Repeat
    k:=a[i,j];
    If ((A[i,1]<=n div 2)and(odd(j)))
    or(((A[i,1]>n div 2)and(not odd(j)))) then
     Begin
      Inc(k);
      While (k<=n)and(B[k]) do Inc(k)
     End
    Else
     Begin
      Dec(k);
      While (k>0)and(B[k]) do Dec(k)
     End;
    If (k<=n)and(k>0) then
     Begin
      B[k]:=True;
      A[i,j]:=k;
      If j=p then
       Begin
        Viet(A,i,p);
        Tang(i,m,n);
        Fillchar(B,sizeof(B),false);
        If A[i,p]=0 then j:=1
        Else
         Begin
          For k:=1 to p-1 do B[A[i,k]]:=True;
          j:=p
         End
       End
      Else
       Begin
        Inc(j);
        If A[i,j]=0 then
         If ((A[i,1]<=n div 2)and(not odd(j)))
         or(((A[i,1]>n div 2)and(odd(j)))) then A[i,j]:=n+1
       End
     End
    Else
     Begin
      B[A[i,j]]:=False;
      A[i,j]:=0;
      Dec(j);
      If (i<>1)and(j<2) then
       Begin
        Tang(i,m,n);
        Fillchar(B,sizeof(B),false);
        If A[i,p]=0 then j:=1
        Else
         Begin
          For k:=1 to p-1 do B[A[i,k]]:=True;
          j:=p
         End
       End
      ELse B[A[i,j]]:=False
     End
   Until (i=1)and(j<2)
  End
End;
BEGIN
 Clrscr;
 Randomize;
 d:=0;
 HV(6,6);
 Write(d);
 Readln
END.
{Uses crt;
Var A:array[1..10,1..10] of byte;
    F:array[1..10] of byte;
    B:array[1..10] of boolean;
Procedure HV(n:byte);
Var i,j,k,m:byte;
Begin
 j:=1;
 Fillchar(B,sizeof(B),false);
 i:=1;
 For i:=1 to n do A[i,j]:=i-1;
 Repeat
  k:=a[i,j]+1;
  While B[k] and(k<=n) do Inc(k);
  If k<=n then
   Begin
    B[k]:=True;
    A[i,j]:=k;
    If j=n then
     Begin
      For m:=1 to n do write(A[i,m]:5);Writeln;
     End
    Else
      Inc(j);
   End
  Else
   Begin
    B[A[i,j]]:=False;
    A[i,j]:=0;
    Dec(j);
    If j>0 then B[A[i,j]]:=False;
   End;
 Until j<1;
End;
BEGIN
 Clrscr;
 HV(3);
 Readln
END.
Uses crt;
Type Mang=array[1..4,1..4] of integer;
Var A:Mang;
    B:array[1..10] of boolean;
Procedure Tang(Var a:byte;Var i:shortint;n:byte);
Begin
 Inc(a,i);
 If (i=-1)and(a=0) then
  Begin
   a:=1;
   i:=1
  End
 Else
  If (i=1)and(a>n) then
   Begin
    a:=n;
    i:=-1
   End
End;
Procedure Viet(A:mang;i,n:byte);
Var j:integer;
Begin
 For j:=1 to n do Write(A[i,j]:5);Writeln;
End;
Procedure HV(n:byte);
Var i,j,k:byte;
    m:shortint;
Begin
 Fillchar(B,sizeof(B),false);
 Fillchar(A,sizeof(A),0);
 For i:=1 to n do
  Begin
   j:=0;
   m:=0;
   k:=random(n-i+1);
   Repeat
    Inc(j);
    If not B[j] then Inc(m);
   Until (m>=k)and(not B[j]);
   If j<=n div 2 then A[i,1]:=j-1
   Else A[i,1]:=j+1;
   B[j]:=True
  End;
 Fillchar(B,sizeof(B),false);
 m:=1;
 i:=1;
 j:=1;
 Repeat
  k:=a[i,j];
  If ((A[i,1]<=n div 2)and(odd(j)))
  or(((A[i,1]>n div 2)and(not odd(j)))) then
   Begin
    Inc(k);
    While (B[k])and(k<=n) do Inc(k);
   End
  Else
   Begin
    Dec(k);
    While (k>0)and(B[k]) do Dec(k);
   End;
  If (k<=n)and(k>0) then
   Begin
    B[k]:=True;
    A[i,j]:=k;
    If j=n then
     Begin
      Viet(A,i,n);

      If A[i,n]=0 then
       Begin
        Fillchar(B,sizeof(B),false);
        j:=1;
       End
      Else j:=n;
     End
    Else
     Begin
      Inc(j);
      If A[i,j]=0 then
       If ((A[i,1]<=n div 2)and(not odd(j)))
       or(((A[i,1]>n div 2)and(odd(j)))) then A[i,j]:=n+1;
     End
   End
  Else
   Begin
    B[A[i,j]]:=False;
    A[i,j]:=0;
    Dec(j);
    If j>0 then B[A[i,j]]:=False
   End;
 Until (i=1)and(j<2)
End;}