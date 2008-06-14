Uses crt;
Const fi='D:\DONGY.INP';
      fo='D:\DONGY.OUT';
      maxn=7;
Var A:array['a'..'g','a'..'g'] of char;
    B:array['a'..'g'] of boolean;
    c,max:char;
    max1:byte;
    f:text;
    s,s1:string;
Procedure Input;
Var f:text;
    s,s1:string;
    n,i,j:byte;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n);
 max:='a';
 For i:=1 to n do
  Begin
   Readln(f,s);
   s1:=copy(s,1,pos('->',s)-1);
   If pos(' ',s1)>0 then s1:=copy(s1,1,pos(' ',s1)-1);
   j:=length(s);
   If max<s[j] then max:=s[j];
   If max<s1[1] then max:=s1[1];
   If length(s1)=1 then A[s1[1],s[j]]:='1'
   Else
    Begin
     A[s1[1],s[j]]:=s1[2];
     A[s1[2],s[j]]:=s1[1];
     If max<s1[2] then max:=s1[2];
    End;
  End;
 max1:=ord(max)-96;
 Close(f);
End;
Procedure Duyet(c:char;var s:string);
Var i:char;
Begin
 If not B[c] then
  Begin
   B[c]:=True;
   s:=s+c;
   For i:='a' to max do
    If ((A[c,i]='1') or ((A[c,i]<>'0')and(B[A[c,i]])))and (not B[i]) then
     Duyet(i,s);
  End;
End;
Procedure Duyet1(s:string;var s1:string);
Var i:byte;
Begin
 Fillchar(b,sizeof(b),false);
 For i:=1 to length(s) do Duyet(s[i],s1);
End;
Procedure Caua;
Var s,s1:string;
Begin
 Writeln('Cau a');
 s1:='';
 Readln(s);
 Duyet1(s,s1);
 Writeln(s1);
End;
Procedure Try(t:byte;var s,s1:string);
Var i:char;
Begin
 If length(s)=t then
  Begin
   s1:='';
   Duyet1(s,s1)
  End
 Else Begin
 If length(s)>0 then c:=s[length(s)]
 Else c:='a';
 For i:=c to max do
  If (max1>length(s1))and(pos(i,s)=0) then
   Begin
    s:=s+i;
    Try(t,s,s1);
    If max1>length(s1) then s:=copy(s,1,length(s)-1);
   End;End;
End;
Function Caub:byte;
Var s,s1:string;
    i:byte;
Begin
 Writeln('Cau b');
 i:=1;
 Repeat
  s1:='';
  s:='';
  Try(i,s,s1);
  Inc(i);
 Until (i>max1)or(max1=length(s1));
 Writeln(s);
 Caub:=i-1;
End;
Procedure Cauc(t:byte;var s,s1:string);
Var i:char;
Begin
 If length(s)=t then
  Begin
   s1:='';
   Duyet1(s,s1);
   If length(s1)=max1 then Writeln(f,s);
  End
 Else  Begin
 If length(s)>0 then c:=s[length(s)]
 Else c:='a';
 For i:=c to max do
  If pos(i,s)=0 then
   Begin
    s:=s+i;
    Cauc(t,s,s1);
    s:=copy(s,1,length(s)-1);
   End;
       End;
End;
Begin
 Clrscr;
 Fillchar(a,sizeof(a),'0');
 Input;
 Caua;
 Assign(f,fo);Rewrite(f);
 s:='';
 Cauc(Caub,s,s1);
 Close(f);
End.