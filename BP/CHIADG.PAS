Uses crt;
Const tf='D:\CHIADG.INP';
      max=7;
Type Toado=record
            x,y:integer
           End;
Var n:integer;
    DG:array[1..max] of toado;
    A:array[1..max,1..max] of byte;
    Dinh,DCcu,Dcmoi:array[1..max-2] of byte;
    i,T:byte;
    TCu,Tmoi:real;
Function TimDinh(B,C:Byte;Var D:byte):boolean;
Var i,j:byte;
    k:boolean;
Begin
 i:=1;
 k:=False;
 While (i<=n)and(k=False) do
  Begin
   If (i<>c)and(i<>b)and(A[b,i]=1)and(A[c,i]=1) then
    Begin
     k:=True;
     D:=i
    End;
   Inc(i)
  End;
 TimDinh:=k
End;
Procedure Input;
Var i:integer;
    f:text;
Begin
 Fillchar(A,Sizeof(a),0);
 Assign(f,tf);Reset(f);
 Readln(f,n);
 For i:=1 to n do
  Begin
   Readln(f,dg[i].x,dg[i].y);
   A[i,i]:=1;
   If i<n then A[i,i+1]:=1
   Else A[i,1]:=1;
   If i>1 then A[i,i-1]:=1
   Else A[i,n]:=1;
  End;
 Close(f)
End;
Procedure Tang(Var a:byte;i:byte);
Begin
 If a+i<=n then Inc(a,i)
 Else a:=a-n+i
End;
Procedure Giam(Var a:byte;i:byte);
Begin
 If a-i>=1 then Dec(a,i)
 Else a:=n+a-i
End;
Function KtDinh(a:byte):boolean;
Var i:byte;
Begin
 i:=1;
 While (Dinh[i]<>0)and(dinh[i]<>a) do Inc(i);
 If Dinh[i]=0 then ktdinh:=false
 Else KtDinh:=true
End;
Procedure Try(q:byte);
Var i,j,d:byte;
Begin
 i:=q;
 j:=q;
 Tang(i,2);
 Giam(j,1);
 Repeat
  If (A[q,i]=0)and(not ktdinh(i))and(timdinh(q,i,d)) then
   Begin
    Inc(t);
    Dcmoi[t]:=i;
    Tmoi:=tmoi+sqrt(sqr(dg[i].x-dg[q].x)+sqr(dg[i].y-dg[q].y));
    Dinh[t-1]:=d;
    A[q,i]:=1;
    A[i,q]:=1;
    If t=n-2 then
     Begin
      If Tmoi<tcu then
       Begin
        tcu:=tmoi;
        Dccu:=dcmoi
       End
     End
    Else Try(i);
    Dcmoi[t]:=0;
    Tmoi:=tmoi-sqrt(sqr(dg[i].x-dg[q].x)+sqr(dg[i].y-dg[q].y));
    Dinh[t-1]:=0;
    A[q,i]:=0;
    A[i,q]:=0;
    Dec(t)
   End;
  Tang(i,1)
 Until i=j
End;
Begin
 Clrscr;
  Input;
  Fillchar(Dccu,Sizeof(dccu),0);
  Fillchar(Dcmoi,Sizeof(dcmoi),0);
  Fillchar(Dinh,Sizeof(Dinh),0);
  T:=1;
  Tcu:=1.7e38;
  For i:=1 to n do
   Begin
    Dcmoi[1]:=i;
    Tmoi:=0;
    Try(i)
  End;
  Writeln(tcu:0:9);
  For i:=1 to n-2 do Write(dccu[i],' ');
 Readln
End.