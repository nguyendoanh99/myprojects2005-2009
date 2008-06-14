Uses crt;
Const fi='D:\RECTANG.DAT';
      fo='D:\RECTANG.SOL';
      Ai:array[1..4] of shortint=(-1,0,1,0);
      Aj:array[1..4] of shortint=(0,1,0,-1);
      max=30;
Type da=record mau:byte;dt:real End;
Var A:array[0..max+1,0..max+1] of byte;
    B:array[1..100] of da;
    Tam:da;
    f,g:text;
    i,j,r,x1,y1,x2,y2:shortint;
    n,mau,a1,b1,a2,b2:byte;
Procedure SX(l,r:shortint);
Var g,i,j:shortint;
Begin
 g:=(l+r) div 2;
 i:=l;
 j:=r;
 Repeat
  While B[i].mau<B[g].mau do Inc(i);
  While B[j].mau>B[g].mau do Dec(j);
  If i<=j then
   Begin
    Tam:=B[i];
    B[i]:=B[j];
    B[j]:=Tam;
    Inc(i);
    Dec(j);
   End;
 Until i>j;
 If l<j then SX(l,j);
 If r>i then SX(i,r);
End;
Procedure Try(y,x:shortint;mau:byte;var dt:real);
Var i:shortint;
Begin
 A[y,x]:=0;
 dt:=dt+1;
 If odd(a1) and ((x=1)or(x=a2*2)) then dt:=dt-0.5;
 If odd(b1) and ((y=1)or(y=b2*2)) then dt:=dt-0.5;
 If odd(a1) and odd(b1) and (((x=1)or(x=a2*2))and((y=1)or(y=b2*2))) then dt:=dt+0.25;
 For i:=1 to 4 do
  If A[y+Ai[i],x+Aj[i]]=mau then
   Try(y+Ai[i],x+Aj[i],mau,dt);
End;
Begin
 Clrscr;
 Assign(f,fi);Reset(f);
 Assign(g,fo);Rewrite(g);
 While not eof(f) do  Begin
 Fillchar(a,sizeof(a),1);
 Readln(f,a1,b1,n);
 a2:=(a1+1) div 2;
 b2:=(b1+1) div 2;
 For i:=0 to a2*2+1 do
  Begin
   A[0,i]:=0;
   A[b2*2+1,i]:=0;
  End;
 For i:=0 to b2*2+1 do
  Begin
   A[i,0]:=0;
   A[i,a2*2+1]:=0;
  End;
 For i:=1 to n do
  Begin
   Readln(f,x1,y1,x2,y2,mau);
   For j:=y1+b2+1 to y2+b2 do
    For r:=x1+a2+1 to x2+a2 do A[j,r]:=mau;
  End;

 r:=0;
 For i:=1 to b2*2 do
  For j:=1 to a2*2 do
   If A[i,j]>0 then
    Begin
     Inc(r);
     B[r].dt:=0;
     B[r].mau:=A[i,j];
     Try(i,j,A[i,j],B[r].dt);
    End;
 SX(1,r);

 For i:=1 to r do
  Begin
   Writeln(B[i].mau,' ',trunc(B[i].dt));
   Writeln(g,B[i].mau,' ',trunc(B[i].dt));
  End;
 Writeln(g);
 Writeln;
 Readln(f);
                      End;
 Close(f);Close(g);
End.