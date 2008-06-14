Uses crt;
Const fi='C:\DUONGDI.INP';
      fo='C:\DUONGDI.OUT';
Var Ma:array[1..100,1..100] of integer;
    Mb:array[1..100] of boolean;
    Mcu,Mmoi:array[1..100] of byte;
    T1,T2:integer;
    i,n,d:integer;
Procedure Input;
Var i,j:integer;
    f:text;
Begin
 Fillchar(Ma,sizeof(Ma),0);
 Assign(f,fi);Reset(f);
 Readln(f,n);
 For i:=1 to n-1 do
  Begin
   For j:=1 to n-1 do
    Begin
     Read(f,Ma[i,j+1]);
     If j>i-1 then Ma[j+1,i]:=Ma[i,j+1]
    End;
   Readln(f)
  End;
 For i:=1 to n-1 do
  Begin
   For j:=2 to n do Write(Ma[i,j]:4);
   Writeln;
  End;
 Close(f)
End;
Procedure Try(a:integer);
Var i:integer;
Begin
 For i:=1 to n do
  If (not Mb[i])and(Ma[a,i]>0) then
   Begin
    Inc(T2,Ma[a,i]);
    Mb[i]:=true;
    Inc(d);
    Mmoi[d]:=i;
    If i=n then
     If T2<T1 then
      Begin
       Mcu:=Mmoi;
       T1:=T2
      End
     Else
    Else Try(i);
    Dec(T2,Ma[a,i]);
    Mb[i]:=false;
    Mmoi[d]:=0;
    Dec(d)
   End
End;
Procedure Output;
Var f:text;
    i:integer;
Begin
 Assign(f,fo);Rewrite(f);
 i:=1;
 While Mcu[i]<>n do
  Begin
   Write(f,Mcu[i],' ');
   Inc(i)
  End;
 Close(f)
End;
Begin
 Clrscr;
  Fillchar(mb,sizeof(mb),false);
  Fillchar(mmoi,sizeof(mmoi),0);
  T1:=maxint;
  T2:=0;
  d:=0;
  Input;
  Try(1);
  Output;
 Readln
End.