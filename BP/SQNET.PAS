Uses crt;
Const fi='C:\SQNET.INP';
      fo='C:\SQNET.OUT';
      Bi:array[1..4] of integer=(-1,0,1,0);
      Bj:array[1..4] of integer=(0,1,0,-1);
Type Mang=array[1..100,1..100] of byte;
Var m,n,p:byte;
    A:mang;
Procedure Quet(x,y:integer;c:byte);
Var i,j:byte;
Begin
 A[x,y]:=0;
 For i:=1 to 4 do
  If (x+bi[i]>=1)and(x+bi[i]<=m)and(y+bj[i]>=1)and(y+bj[i]<=n) then
   If A[x+bi[i],y+bj[i]]=c then Quet(x+bi[i],y+bj[i],c)
End;
Procedure Doc(Var A:mang);
Var f:text;
    k,i,j,x,y,u,v:byte;
Begin
 Fillchar(a,sizeof(a),0);
 Assign(f,fi);Reset(f);
 Readln(f,m,n);
 Readln(f,p);
 For k:=1 to p do
  Begin
   Readln(f,x,y,u,v);
   For i:=x to u do
    For j:=y to v do Inc(a[i,j])
  End;
 For i:=1 to m do                     begin
  For j:=1 to n do Write(a[i,j],' ');      writeln;end;writeln;
 Close(f)
End;
Procedure Ghi;
Var f:text;
    i,j:byte;
    K:array[1..20] of byte;
Begin
 Fillchar(K,sizeof(k),0);
 Assign(f,fo);Rewrite(f);
 For i:=1 to m do
  For j:=1 to n do
   If a[i,j]<>0 then
    Begin
     Inc(k[a[i,j]]);
     Quet(i,j,a[i,j])
    End;             t
 For i:=1 to p do Writeln(f,k[i]);
 Close(f)
End;
Begin
 Clrscr;
  Doc(a);
  Ghi;
End.