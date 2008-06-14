Uses crt;
Const fi='C:\DISK.INP';
      fo='C:\DISK.OUT';
Var n,p,q,u,v,l,t,z:integer;
Procedure Input;
Var f:text;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n,p,q,u,v);
 z:=v-u;
 Close(f);
End;
Function UCLN(a,b:integer):integer;
Var r:integer;
Begin
 r:=a mod b;
 While r<>0 do
  Begin
   a:=b;
   b:=r;
   r:=a mod b;
  End;
 UCLN:=b;
End;
Procedure Output;
Var m,h:integer;
    f:text;
    k:boolean;
Begin
 Assign(f,fo);Rewrite(f);
 If z mod UCLN(p,q)<>0 then
  Begin
   Writeln(f,'-1');
   Writeln('-1');
  End
 Else
  Begin
   t:=0;
   While (t*p-z<0)or((t*p-z) mod q<>0) do Inc(t);
   l:=(t*p-z) div q;
   Writeln(f,t+l);
   Writeln(t+l);
   If (t<>0)and((n-u) div p>0) then k:=True
   Else k:=False;
   h:=u;
   Repeat
    If k then
     Begin
      If t>0 then
       Begin
        If (n-h) div p>=t then
         Begin
          Write(f,'T',t,' ');
          Write('T',t,' ');
          Inc(h,t*p);
          t:=0;
         End
        Else
         Begin
          m:=(n-h) div p;
          If m=0 then m:=1;
          Write(f,'T',m,' ');
          Write('T',m,' ');
          Dec(t,m);
          Inc(h,m*p);
         End;
       End;
     End
    Else
     If l>0 then
      Begin
       If h div q>=l then
        Begin
         Write(f,'L',l,' ');
         Write('L',l,' ');
         Dec(h,l*q);
         l:=0;
        End
       Else
        Begin
         m:=h div q;
         If m=0 then m:=1;
         Write(f,'L',m,' ');
         Write('L',m,' ');
         Dec(l,m);
         Dec(h,m*q);
        End;
       End;
    k:=not k;
   Until (h<0)or(h>n)or(h=v);
   If (h<0)or(h>n) then
    Begin
     Close(f);
     Assign(f,fo);Rewrite(f);
     Writeln(f,'-1');
     Clrscr;
     Writeln('-1');
    End;
  End;
 Close(f);
End;
Begin
 Clrscr;
  Input;
  Output;
 Readln;
End.