{Ky thi chon hoc sinh gioi quoc gia
 Lop 12 THPT nam 2002-2003
 Bang A
 Robot di dao}
Uses crt;
Const fi='C:\TOUR.INP';
      fo='C:\TOUR.OUT';
      Ai:array[1..4] of shortint=(1,1,-1,-1);{cot}
      Aj:array[1..4] of shortint=(-1,1,1,-1);{dong}
      Bi:array[1..4] of shortint=(1,1,-1,-1);{cot}
      Bj:array[1..4] of shortint=(1,-1,-1,1);{dong}
Var A:array[0..15,0..15] of boolean;
    B:array[1..20] of integer;
    Dd:array[1..20] of record
                         x,y:byte
                        End;
    i,j,n,m,d:byte;
    k:boolean;
Procedure Tim(t:integer;var a,b:integer);
Var i:integer;
Begin
 i:=1;
 While frac(sqrt(t-sqr(i)))<>0 do Inc(i);
 a:=i;
 b:=trunc(sqrt(t-sqr(i)))
End;
Procedure Input;
Var f:text;
    i:byte;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,n,m);
 For i:=1 to m do Read(f,B[i]);
 Close(f)
End;
Procedure Try(x,y:shortint);
Var i,u,v,x1,y1:integer;
Begin
 Dd[d+1].x:=x;
 Dd[d+1].y:=y;
 A[y,x]:=true;
 Inc(d);
 Tim(b[d],u,v);
 For i:=1 to 4 do
  If not k then
   Begin
    x1:=x+u*Ai[i];
    y1:=y+v*Aj[i];
    If (x1>=0)and(x1<=n)and(y1>=0)and(y1<=n) then
     Begin
      If d<m then
       If not A[y1,x1] then Try(x1,y1)
       Else
      Else
       If (x1=Dd[1].x)and(y1=Dd[1].y) then k:=true;
      If (not k)and(u<>v) then
       Begin
        x1:=x1+(v-u)*Bi[i];
        y1:=y1+(v-u)*Bj[i];
        If (x1>=0)and(x1<=n)and(y1>=0)and(y1<=n) then
         Begin
          If d<m then
           If not A[y1,x1] then Try(x1,y1)
           Else
          Else
           If (x1=Dd[1].x)and(y1=Dd[1].y) then k:=true
         End
       End
     End
   End;
 A[y,x]:=false;
 Dec(d)
End;
Procedure Output;
Var f:text;
Begin
 Assign(f,fo);Rewrite(f);
 If k then
  For i:=1 to m do Writeln(f,Dd[i].x,' ',Dd[i].y)
 Else Writeln(f,-1);
 Close(f)
End;
Begin
 Clrscr;
  Input;
  d:=0;
  k:=false;
  i:=0;
  While (i<=n div 2)and not k do
   Begin
    j:=0;
    While (j<=(n div 2)-i)and not k do
     Begin
      Try(j,i);
      Inc(j)
     End;
   Inc(i)
   End;
  Output;
 Readln
End.