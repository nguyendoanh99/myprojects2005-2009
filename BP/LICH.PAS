Uses crt;
Const tf='D:\LICH.IN';
Type ct=^contro;
     contro=record
             so,mau:byte;
             tiep:ct
            End;
Var A:array[1..50] of ct;
    ht:array[1..50] of ct;
    m,n,i:byte;
    TH:set of byte;
    t:ct;
Procedure Them(x,y:byte);
Var t:ct;
Begin
 New(t);
 t^.so:=y;
 t^.mau:=0;
 t^.tiep:=nil;
 If A[x]<>nil then
  Begin
   ht[x]^.tiep:=t;
   ht[x]:=t;
  End
 Else
  Begin
   A[x]:=t;
   ht[x]:=a[x]
  End
End;
Procedure Input;
Var f:text;
    x,y,i:byte;
    ht:ct;    
Begin
 Assign(f,tf);Reset(f);
 Readln(f,n);
 For i:=1 to n do A[i]:=nil;
 While not eof(f) do
  Begin
   Readln(f,x,y);
   If (x<>0)and(y<>0) then
    Begin
     Them(x,y);
     Them(y,x)
    End
  End;
 For i:=1 to n do
  Begin
   Write(i,' : ');
   ht:=a[i];
   While ht<>nil do
    Begin
     Write(ht^.so,' ');
     ht:=ht^.tiep
    End;
   Writeln
  End;
 Close(f)
End;
Procedure ThemTH(s:byte);
Begin
 t:=a[s];
 While t<>nil do
  Begin
   If (t^.mau<>0)and not (t^.mau in th) then th:=th+[t^.mau];
   t:=t^.tiep
  End
End;
Procedure Try(s:byte);
Var ht:ct;
    i:byte;
Begin
 ht:=a[s];
 While ht<>nil do
  Begin
   If (ht^.so>s)and(ht^.mau=0) then
    Begin
     th:=[];
     ThemTH(s);
     ThemTH(ht^.so);
     i:=1;
     While i in th do Inc(i);
     ht^.mau:=i;
     t:=a[ht^.so];
     While t^.so<>s do t:=t^.tiep;
     t^.mau:=i;
     Inc(m);
     Try(ht^.so)
    End;
   ht:=ht^.tiep
  End
End;
Begin
 Clrscr;
  Input;
  m:=0;
  Try(1);
  Writeln;
  For i:=1 to n do
   Begin
    t:=a[i];
    While t<>nil do
     Begin
      If t^.so>i then Writeln(i,' ',t^.so,' ',t^.mau);
      t:=t^.tiep
     End
   End;
 Readln
End.