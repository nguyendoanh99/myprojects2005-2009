{DE THI TIN HOC QUOC TE LAN THU 10 - 1998 Polygon}
Uses crt;
Const fi='C:\POLYGON.INP';
      fo='C:\POLYGON.OUT';
Type Mang=array[1..50] of byte;
Var n:integer;
    Ma:array[1..50] of Record
                         n:array[1..2] of char;
                         so:integer;
                         t:array[1..2] of byte;
                        End;
    Mdinh:array[1..50] of boolean;
    kq,kq2:integer;
    A:Mang;
    i,k,d:byte;
Function ThucHien(a,b:integer;c:char;k:byte):integer;
Begin
 If k=1 then
  Case c of
  '+':ThucHien:=a+b;
  '*':ThucHien:=a*b;
  End
 Else
  Case c of
  '+':ThucHien:=a-b;
  '*':ThucHien:=a div b;
  End
End;
Procedure Input;
Var f:text;
    s,s1:string;
    d:byte;
    i,c:integer;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n);
 Readln(f,s);
 d:=0;
 s1:='';
 For i:=1 to length(s) do
  Begin
   Case s[i] of
   't','x':
     Begin
      Inc(d);
      If d-1>0 then Ma[d].t[1]:=d-1
      Else Ma[d].t[1]:=n;
      If d+1<=n then Ma[d].t[2]:=d+1
      Else Ma[d].t[2]:=1;
      If s[i]='t' then Ma[d].n[1]:='+'
      Else Ma[d].n[1]:='*'
     End;
   ' ':Begin
        If s1<>'' then
         Begin
          Val(s1,Ma[d].so,c);
          s1:=''
         End
       End;
   Else
     s1:=s1+s[i]
   End
  End;
 Val(s1,Ma[d].so,c);
 For i:=1 to n do
  Ma[i].n[2]:=Ma[Ma[i].t[2]].n[1];
 Close(f)
End;
Procedure Try;
Var tam,e,i,j:byte;
    k:integer;
Begin
 For i:=1 to n do
  If Mdinh[i] then
   Begin
    For j:=1 to 2 do
     With Ma[i] do
      If (t[j]<>0)and(t[j]-i>0) then
       Begin
        tam:=t[j];
        k:=so;
        so:=ThucHien(so,Ma[tam].so,n[j],1);
        Mdinh[tam]:=False;
        If j=2 then e:=1
        Else e:=2;
        t[j]:=Ma[tam].t[j];
        Ma[Ma[tam].t[j]].t[e]:=i;
        Ma[tam].t[1]:=0;
        Ma[tam].t[2]:=0;
        If (t[1]=0)and(t[2]=0) then
         Begin
          If so>kq then kq:=so
         End
        Else Try;
        Mdinh[tam]:=True;
        Ma[tam].t[j]:=t[j];
        Ma[tam].t[e]:=i;
        t[j]:=tam;
        Ma[Ma[tam].t[j]].t[e]:=tam;
        so:=ThucHien(so,Ma[tam].so,n[j],2);
       End
   End
End;
Procedure OutPut(A:mang;kq:integer);
Var f:text;
    i:byte;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,kq);
 For i:=1 to d do Write(f,A[i],' ');
 Close(f)
End;
Begin
 Clrscr;
  Fillchar(Mdinh,sizeof(Mdinh),true);
  Input;
  kq2:=0;
  d:=0;
  For i:=1 to n do
   Begin
    kq:=-maxint;
    k:=Ma[i].t[1];
    Ma[k].t[2]:=0;
    Ma[i].t[1]:=0;
    Try;
    If kq>kq2 then
     Begin
      kq2:=kq;
      d:=1;
      A[d]:=i
     End
    Else
     If kq=kq2 then
      Begin
       Inc(d);
       A[d]:=i
      End;
    Ma[k].t[2]:=i;
    Ma[i].t[1]:=k
   End;
  OutPut(A,kq2);
 Readln
End.