Uses crt;
Const fi='C:\WORKING.INP';
      fo='C:\WORKING.OUT';
      maxn=30000;
Var n:integer;
    P,d,C:array[1..maxn] of integer;
    A1,A2:array[1..maxn] of integer;
    k:array[1..maxn] of boolean;
    thuong1,phat1,thuong2,phat2:integer;
    t:longint;
Procedure Input;
Var f:text;
    i:integer;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n);
 For i:=1 to n do Read(f,P[i]);
 For i:=1 to n do Read(f,d[i]);
 For i:=1 to n do Read(f,C[i]);
 Close(f);
End;
Procedure Try(j:integer);
Var i:integer;
Begin
 If j>n then
  Begin
   If thuong1-phat1>thuong2-phat2 then
    Begin
     thuong2:=thuong1;
     phat2:=phat1;
     A2:=A1;
    End;
  End
 Else
  For i:=1 to n do
   If not k[i] then
    Begin
     A1[j]:=i;
     k[i]:=True;
     Inc(t,P[i]);
     If t<=d[i] then Inc(thuong1,C[i]*(d[i]-t))
     Else Inc(phat1,C[i]*(t-d[i]));
     Try(j+1);
     A1[j]:=0;
     k[i]:=False;
     If t<=d[i] then Dec(thuong1,C[i]*(d[i]-t))
     Else Dec(phat1,C[i]*(t-d[i]));
     Dec(t,P[i]);
    End;
End;
Procedure Output;
Var f:text;
    i:integer;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(thuong2);
 Writeln(f,thuong2);
 Writeln(phat2);
 Writeln(f,phat2);
 For i:=1 to n do
  Begin
   Write(A2[i],' ');
   Write(f,A2[i],' ');
  End;
 Close(f);
End;
Begin
 Clrscr;
  Input;
  Fillchar(A1,sizeof(A1),0);
  Fillchar(k,sizeof(k),false);
  thuong1:=0;
  phat1:=0;
  thuong2:=0;
  phat2:=-1;
  Try(1);
  Output;
 Readln
End.