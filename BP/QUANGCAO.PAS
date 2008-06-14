Uses crt;
Const fi='C:\QUANGCAO.INP';
      fo='C:\QUANGCAO.OUT';
      n_max=10;
      m_max=100;
Type Mang=array[1..n_max,1..m_max] of boolean;
     Mang1=array[1..n_max*m_max] of string[4];{Cac thao tac}
Var Ma:Mang;
    n,m:byte;
    D:array[1..n_max] of boolean;
    C:array[1..m_max] of boolean;
    M_TT1,M_TT2:Mang1;
    dd2,dd,T1,T2:integer;
Function ThaoTac(Var A:mang;t:byte;c:char):integer;
Var i:byte;
    kq:integer;
Begin
 kq:=0;
 Case c of
 'C':For i:=1 to n do
      Begin
       A[i,t]:=not A[i,t];
       if A[i,t] then Inc(kq)
       Else Dec(kq)
      End;
 'D':For i:=1 to m do
      Begin
       A[t,i]:=not A[t,i];
       if A[t,i] then Inc(kq)
       Else Dec(kq)
      End
 End;
 ThaoTac:=kq
End;
Procedure Input(Var A:Mang;var kq:integer);
Var t,i,j:byte;
    f:text;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n,m);
 kq:=0;
 For i:=1 to n do
  Begin
   For j:=1 to m do
    Begin
     Read(f,t);
     If t=1 then
      Begin
       Inc(kq);
       A[i,j]:=True
      End
     Else A[i,j]:=False
    End;
   Readln(f)
  End;
 Close(f)
End;
Procedure Try(a:byte;k:char);
Var i:char;
    j:byte;
    q:string;
Begin
 For i:='C' to 'D' do
  Begin
   If i='C' then
    Begin
     If k='D' then a:=1;
     For j:=a to m-1 do
      If C[j] then
      Begin
       C[j]:=not C[j];
       Inc(T1,ThaoTac(Ma,j,i));
       Inc(dd);
       str(j,q);
       M_TT1[dd]:='C'+q;
       If T1>T2 then
        Begin
         dd2:=dd;
         T2:=T1;
         M_TT2:=M_TT1
        End
       Else Try(j+1,'C');
       Dec(dd);
       C[j]:=not C[j];
       Inc(T1,ThaoTac(Ma,j,i));
      End
    End
   Else
    Begin
     If k='C' then a:=1;
     For j:=a to n-1 do
      If D[j] then
      Begin
       D[j]:=not D[j];
       Inc(T1,ThaoTac(Ma,j,i));
       Inc(dd);
       str(j,q);
       M_TT1[dd]:='D'+q;
       If T1>T2 then
        Begin
         dd2:=dd;
         T2:=T1;
         M_TT2:=M_TT1
        End
       Else Try(j+1,'D');
       Dec(dd);
       D[j]:=not D[j];
       Inc(T1,ThaoTac(Ma,j,i))
      End
    End
  End
End;
Procedure OutPut(A:mang1;d:integer;kq:integer);
Var f:text;
    cc,l,k,o,i:integer;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,kq);
 Writeln(f,d);
 For i:=1 to d do
  Begin
   Writeln(f,A[i]);
   val(copy(a[i],2,length(a[i])-1),o,cc);
   ThaoTac(Ma,o,A[i][1]);
   Writeln(a[i]);
   For l:=1 to n do
    Begin
     For k:=1 to m do
      Begin
       if ma[l,k] then Write('1 ')
       Else write('0 ');
      End;
     writeln
    End;
  End;
 Close(f)
End;
Begin
 Clrscr;
  Fillchar(c,sizeof(c),True);
  Fillchar(d,sizeof(d),True);
  Input(Ma,T2);
  T1:=T2;
  Try(1,'C');
  OutPut(M_TT2,dd2,T2)
End.