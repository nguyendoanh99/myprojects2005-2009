Uses crt;
Const fi='D:\NOIDAY.IN';
      fo='D:\NOIDAY.OUT';
      maxn=8;
Var max:real;
    A:array[0..maxn] of Record x,y:shortint; End;
    B:array[0..maxn,0..maxn] of real;
    C:array[1..maxn] of Record u,v:byte; End;
    Tree:array[0..maxn] of byte;
    n:byte;
Procedure Input;
Var f:text;
    i,j:shortint;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n);
 b[0,0]:=max;
 Tree[0]:=0;
 For i:=1 to n do
  Begin
   Tree[i]:=i;
   b[i,i]:=max;
   Readln(f,a[i].x,a[i].y);
   For j:=0 to i-1 do
    Begin
     B[i,j]:=sqrt(sqr(a[i].x-a[j].x)+sqr(a[i].y-a[j].y));
     B[j,i]:=B[i,j];
    End;
  End;
 Close(f);
End;
Procedure Chon(var u,v:byte);
Var i,j:shortint;
    t:real;
Begin
 t:=max;
 For i:=0 to n do
  For j:=i+1 to n do
   If (b[i,j]<t)and(Tree[i]<>Tree[j]) then
    Begin
     u:=i;
     v:=j;
     t:=b[i,j];
    End;
End;
Procedure Noi(vt,u,v:byte);
Var tam,i:byte;
Begin
 C[vt].u:=u;
 C[vt].v:=v;
 tam:=tree[v];
 For i:=1 to n do
  If tree[i]=tam then tree[i]:=tree[u];
End;
Procedure ThucHien;
Var i,u,v:byte;
Begin
 For i:=1 to n do
  Begin
   Chon(u,v);
   Noi(i,u,v);
  End;
End;
Procedure Output;
Var i:byte;
    f:text;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,n);
 For i:=1 to n do Writeln(f,c[i].u,' ',c[i].v);
 Close(f);
End;
Begin
 max:=sqrt(2)*200+1;
 Input;
 ThucHien;
 Output;
End.