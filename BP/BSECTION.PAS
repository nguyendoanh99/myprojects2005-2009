Uses crt;
Const fi='C:\BSECTION.INP';
      fo='C:\BSECTION.OUT';
Type point=^tpoint;
     tg=Record
         a,b,c:extended;
        End;
     tpoint=Record
             a:tg;
             t:point;
            End;
Var n,dem:integer;
    A:tg;
    d,hh:point;
Function Bp(a:extended):extended;
Begin
 Bp:=a*a;
End;
Function DDang(A1,A2:tg):boolean;
Begin
 If (round(A1.a)/round(A2.a)=round(A1.b)/round(A2.b))
 and(round(A1.a)/round(A2.a)=round(A1.c)/round(A2.c)) then DDang:=True
 Else DDang:=False;
End;
Function Tim(A:tg):boolean;
Var t:point;
Begin
 t:=d;
 Tim:=false;
 While t<>nil do
  Begin
   If DDang(A,t^.a) then
    Begin
     Tim:=True;
     Exit;
    End;
   t:=t^.t;
  End;
End;
Procedure Them(A:tg);
Var tam:point;
Begin
 New(tam);
 tam^.A:=A;
 tam^.t:=nil;
 If d=nil then
  Begin
   d:=tam;
   hh:=tam;
  End
 Else
  Begin
   hh^.t:=tam;
   hh:=tam;
  End;
End;
Procedure DoiCho(var a,b:extended);
Var t:extended;
Begin
 If a<b then
  Begin
   t:=b;
   b:=a;
   a:=t;
  End;
End;
Procedure SX(var a:tg);
Begin
 With a do
  Begin
   DoiCho(a,b);
   DoiCho(a,c);
   DoiCho(b,c);
  End;
End;
Procedure Input;
Var f:text;
Begin
 Assign(f,fi);Reset(f);
 With A do Readln(f,a,b,c,n);
 SX(A);
 Close(f);
End;
Procedure Try(A:tg;k:integer);
Var A1:tg;
Begin
 If k<=n then
  Begin
   A1.a:=(A.a/2);
   A1.b:=(A.b);
   A1.c:=sqrt((Bp(A.b)+Bp(A.c)-Bp(A.a)/2)/2);
   SX(A1);
   Try(A1,k+1);
   A1.a:=(A.a/2);
   A1.b:=(A.c);
   A1.c:=sqrt((Bp(A.b)+Bp(A.c)-Bp(A.a)/2)/2);
   SX(A1);
   Try(A1,k+1);
  End
 Else
  Begin
   Writeln(a.a,' ',a.b,' ',a.c);
   If (dem=0)or((dem<>0)and(not Tim(A))) then
    Begin
     Inc(dem);
     Them(A);
    End
  End;
End;
Begin
 Clrscr;
  Input;
  d:=nil;
  dem:=0;
  Try(A,1);
  Write(dem);
  Release(d);
 Readln
End.