{Bai 170/2004 - Xay dung hang rao}
Uses crt;
Const fi='C:\PRINCESS.INP';
      fo='C:\PRINCESS.OUT';
      nmax=20;
Type point=record
            x,y:integer
           End;
     Mpoint=array[1..nmax+1] of point;
Var n:integer;
    A:Mpoint;
Function Theta(p1,p2:point):real;
Var dx,dy:integer;
    t:real;
Begin
 dx:=p2.x-p1.x;
 dy:=p2.y-p1.y;
 If (dx=0)and(dy=0) then t:=0
 Else t:=dy/(abs(dx)+abs(dy));
 If dx<0 then t:=2-t
 Else If dy<0 then t:=4+t;
 theta:=t*90
End;
Procedure Input(Var n:integer;Var A:Mpoint);
Var f:text;
    m,i,j,k,x,y:integer;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n);
 k:=0;
 m:=n;
 For i:=1 to n do
  Begin
   Readln(f,x,y);
   j:=1;
   While (j<=k)and((A[j].x<>x)or(A[j].y<>y)) do Inc(j);
   If j<=k then Dec(m);
   k:=j;
   A[k].x:=x;
   A[k].y:=y;
  End;
 n:=m;
 Close(f)
End;
Function BocGoi(Var A:Mpoint;n:integer):integer;
Var m,min,i:integer;
    g,mingoc,v:real;
    t:point;
Begin
 min:=1;
 for i:=2 to n do
  if A[min].y>A[i].y then min:=i;
 for i:=2 to n do
  if (A[min].y=A[i].y)and(A[min].x<A[i].x) then min:=i;
 m:=0;
 A[n+1]:=A[min];
 mingoc:=0;
 Repeat
  Inc(m);
  t:=A[m];
  A[m]:=A[min];
  A[min]:=t;
  min:=n+1;
  v:=mingoc;
  mingoc:=360;
  For i:=m+1 to n+1 do
   Begin
    g:=theta(A[m],A[i]);
    If g>v then
     If ((g=mingoc)and(sqrt(sqr(A[i].x-A[m].x)+sqr(A[i].y-A[m].y))>sqrt(sqr(A[min].x-A[m].x)+sqr(A[min].y-A[m].y))))
     or(g<mingoc) then
      Begin
       min:=i;
       mingoc:=g
      End
   End
 Until min=n+1;
 bocgoi:=m
End;
Function Chon(p1,p2:point;var p3:point):boolean;
Var g:real;
    dx,dy:integer;
    k:boolean;
Begin
 g:=theta(p1,p2);
 dx:=abs(p1.x-p2.x);
 dy:=abs(p1.y-p2.y);
 k:=true;
 With p3 do
  If (g>0)and(g<45) then
   Begin
    k:=false;
    x:=p2.x-dy;
    y:=p1.y
   End
  Else
   If (g>45)and(g<90) then
    Begin
     k:=false;
     x:=p2.x;
     y:=p1.y+dx
    End
   Else
    If (g>90)and(g<135) then
     Begin
      k:=false;
      x:=p1.x;
      y:=p2.y-dx
     End
    Else
     If (g>135)and(g<180) then
      Begin
       k:=false;
       x:=p1.x-dy;
       y:=p2.y
      End
     Else
      If (g>180)and(g<225) then
       Begin
        k:=false;
        x:=p2.x+dy;
        y:=p1.y
       End
      Else
       If (g>225)and(g<270) then
        Begin
         k:=false;
         x:=p2.x;
         y:=p1.y-dx
        End
       Else
        If (g>225)and(g<270) then
         Begin
          k:=false;
          x:=p2.x;
          y:=p1.y-dx
         End
        Else
         If (g>270)and(g<315) then
          Begin
           k:=false;
           x:=p1.x;
           y:=p2.y+dx
          End
         Else
          If (g>315)and(g<360) then
           Begin
            k:=false;
            x:=p1.x+dy;
            y:=p2.y
           End;
 Chon:=k
End;
Procedure OutPut(n:integer;A:Mpoint);
Var f:text;
    p:point;
    i,m:integer;
    B:Mpoint;
Begin
 Assign(f,fo);Rewrite(f);
 i:=2;
 m:=1;
 B[m]:=A[1];
 Repeat
  Inc(m);
  If Chon(A[i-1],A[i],p) then
   Begin
    B[m]:=A[i];
   End
  Else
   Begin
    If theta(p,A[i])=theta(p,A[i+1]) then Inc(i);
    B[m]:=p;
    Inc(m);
    B[m]:=A[i]
   End;
  Inc(i)
 Until i>n;
 If B[m].y=B[2].y then
  Begin
   Dec(m);
   i:=2
  End
 Else i:=1;
 Writeln(f,m);
 Repeat
  Writeln(f,B[i].x,' ',B[i].y);
  Inc(i)
 Until i>m;
 Close(f)
End;
Begin
 Clrscr;
  Input(n,A);
  OutPut(BocGoi(A,n),A);
End.