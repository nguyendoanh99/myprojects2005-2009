Uses crt;
Const fi='C:\ANALYS.INP';
      fo='C:\ANALYS.OUT';
Var n,n1:integer;
    A:array[1..30000] of record
                          a,b:integer;
                          k:boolean;
                         End;
Function ChuoiSo(s:string;var a:integer):integer;
Var i,b,c:integer;
Begin
 While (s[a]<'0')or(s[a]>'9') do Inc(a);
 i:=a+1;
 While (i<=length(s))and(s[i]>='0')and(s[i]<='9') do Inc(i);
 Val(copy(s,a,i-a),b,c);
 ChuoiSo:=b;
 a:=i;
End;
Procedure Input;
Var f:text;
    s:string;
    t:integer;
Begin
 Assign(f,fi);Reset(f);
 n:=0;
 While not eof(f) do
  Begin
   Readln(f,s);
   Inc(n);
   t:=5;
   With A[n] do
    Begin
     k:=false;
     If s='NEXT' then
      Begin
       a:=0;
       b:=0;
      End
     Else
      If copy(s,1,4)='GOTO' then
       Begin
        a:=ChuoiSo(s,t);
        b:=0;
       End
      Else
       Begin
        a:=ChuoiSo(s,t);
        b:=ChuoiSo(s,t);
       End;
    End;
  End;
 Close(f);
End;
Procedure Try(i:integer);
Begin
 With A[i] do
  If not k then
   Begin
    Dec(n1);
    k:=true;
    If (a=0)and(b=0) then
     Begin
      If i+1<=n then Try(i+1)
     End
    Else
     Begin
      Try(a);
      If b<>0 then Try(b);
     End;
   End;
End;
Procedure Output;
Var f:text;
    i:integer;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,n1);
 If n1>0 then
  For i:=1 to n do
   If not A[i].k then
    Writeln(f,i);
 Close(f);
End;
Begin
 Clrscr;
 Input;
 n1:=n;
 Try(1);
 Writeln(n1);
 Output;
 Readln
End.