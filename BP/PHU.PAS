Uses crt;
Const fi='C:\PHU.INP';
      fo='C:\PHU.OUT';
      maxn=100000;
Type dthang=Record
                l,r:longint;
     End;
     ct=^contro;
     contro=Record
                  line:dthang;
                  tt:longint;
                  Next:ct;
     End;
Var n,n1:longint;
    P,Q:word;
    dt,ht1,ht2:ct;
    pointer:^integer;
    KQ:boolean;
Procedure Chen(Var ht:ct;tam:dthang;v:longint);
Var moi:ct;
Begin
 Inc(n1);
 New(moi);
 moi^.line:=tam;
 moi^.tt:=v;
 If dt=nil then
  Begin
   moi^.Next:=nil;
   dt:=moi
  End
 Else
  If ht<>nil then
   Begin
    moi^.next:=ht^.next;
    ht^.next:=moi;
   End
  Else
   Begin
    moi^.next:=dt;
    dt:=moi;
   End;
 ht:=moi;
End;
Procedure Xoa(ht:ct);
Var tam:ct;
Begin
 Dec(n1);
 If ht=nil then
  Begin
   tam:=dt;
   dt:=dt^.next;
  End
 Else
  Begin
   tam:=ht^.next;
   ht^.next:=tam^.next;
  End;
 Dispose(tam);
 tam:=dt;
 While tam<>nil do
  Begin
   Write(tam^.tt,'(',tam^.line.l,',',tam^.line.r,') ');
   tam:=tam^.next;
  End;  Writeln;
End;
Procedure Input;
Var f:text;
    i:longint;
    T:dthang;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n,P,Q);
 n1:=0;
 For i:=1 to n do
  Begin
   Readln(f,T.l,T.r);
   If ((T.l>=P)and(T.l<Q))or((T.r>P)and(T.r<=Q)) then
    Begin
     ht1:=nil;
     ht2:=dt;
     While (ht2<>nil)and(T.l>ht2^.line.l) do
      Begin
       ht1:=ht2;
       ht2:=ht2^.next;
      End;
     If (ht2=nil)or(T.l<ht2^.line.l) then Chen(ht1,T,i)
     Else
      If T.r>ht2^.line.r then
       Begin
        ht2^.line:=T;
        ht2^.tt:=i;
       End;
    End;
  End;
 Close(f);
End;
Procedure ThucHien;
Var ht3,ht4:ct;
Begin
 KQ:=false;
 If (dt=nil)or(dt^.line.l>P) then exit;
 ht1:=dt;
 While ht1<>nil do
  Begin
   Write(ht1^.tt,'(',ht1^.line.l,',',ht1^.line.r,') ');
   ht1:=ht1^.next;
  End;  Writeln;
 ht1:=nil;
 ht2:=dt;
 While (ht2<>nil)and(P<Q) do
  Begin
   ht3:=ht1;
   ht4:=ht2;
   ht1:=ht2;
   ht2:=ht2^.next;
   While (ht2<>nil)and(ht2^.line.l<=P) do
    Begin
     If ht2^.line.r>ht4^.line.r then
      Begin
       Xoa(ht3);
       If ht2=dt then ht3:=nil
       Else
        If ht3=nil then ht3:=dt
        Else While ht3^.next<>ht2 do ht3:=ht3^.next;
       ht4:=ht2;
      End
     Else
      Begin
       Xoa(ht1);
       ht2:=ht1;
      End;
     ht1:=ht2;
     ht2:=ht2^.next;
    End;
   If ht4^.line.l>P then exit;
   P:=ht4^.line.r;
  End;
 While ht1^.next<>nil do Xoa(ht1);
 If P<Q then exit;
 KQ:=True;
End;
Procedure Output;
Var f:text;
Begin
 Assign(f,fo);Rewrite(f);
 If not KQ then
  Begin
   Writeln(f,'0');
   Writeln('0');
  End
 Else
  Begin
   Writeln(f,n1);
   Writeln(n1);
   ht1:=dt;
   While ht1<>nil do
    Begin
     Write(f,ht1^.tt,' ');
     Write(ht1^.tt,' ');
     ht1:=ht1^.next;
    End;
  End;
 Close(f);
End;
Begin
 Clrscr;
 dt:=nil;
 Mark(pointer);
 Input;
 ThucHien;
 Output;
 Release(pointer);
 Readln
End.