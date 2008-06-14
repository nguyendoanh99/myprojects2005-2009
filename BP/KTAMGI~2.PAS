{Truong THPT chuyen Nguyen Binh Khiem Tinh Vinh Long
Bai 2}
Uses crt;
Const fi='C:\KTAMGIAC.INP';
      fo='C:\KTAMGIAC.OUT';
Var k,l,r,p,q:integer;
Function Dong(tg:integer):integer;
Begin
 Dong:=trunc(sqrt(tg-1))
End;
Function XoaBang(tg:integer;n:integer;k:byte):integer;
{k=0  : xoa bang ben phai
 k<>0 : xoa bang ben trai}
Var a:integer;
Begin
 a:=dong(tg);
 Dec(tg);
 If k=0 then XoaBang:=sqr(a+n)+(tg-sqr(a))
 Else XoaBang:=sqr(a+n+1)-(sqr(a+1)-tg);
 Inc(XoaBang)
End;
Function KT(tg,k:integer):integer;
Var d1,d2:integer;
Begin
 d1:=dong(tg);
 d2:=dong(k);
 If (d1>d2)
 or(XoaBang(tg,d2-d1,0)>k)
 or(XoaBang(tg,d2-d1,0)+(d2-d1)*2<k) then kt:=0
 Else KT:=(sqr(d2-d1)+1)+k-XoaBang(tg,d2-d1,0)
End;
Function SoBuoc(p,q:integer):integer;
Var d1,d2,g,t,m:integer;
Begin
 If p>q then
  Begin
   t:=p;
   p:=q;
   q:=t
  End;
 d1:=dong(p);
 d2:=dong(q);
 If odd(d2-d1) then
  If odd(p) then m:=(d2-d1)*2-1
  Else m:=(d2-d1)*2+1
 Else m:=(d2-d1)*2;
 t:=p-(sqr(d1)+1)+(d2-d1);
 g:=(sqr(d2)+1)+t;
 if abs(q-g)<=d2-d1 then
  If odd(q-g) then
   If odd(d2-d1) then SoBuoc:=m+1
   Else SoBuoc:=m-1
  Else SoBuoc:=m
 Else SoBuoc:=m+abs(q-g)-(d2-d1)
End;
Procedure Input(Var k,l,r,p,q:integer);
Var f:text;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,k,l,r);
 Readln(f,p,q);
 Close(f)
End;
Procedure Output;
Var f:text;
Begin
 Assign(f,fo);Rewrite(f);
 Writeln(f,KT(XoaBang(XoaBang(1,l,1),r,0),k));
 Writeln(f,SoBuoc(p,q));
 Close(f)
End;
Begin
 Clrscr;
 Input(k,l,r,p,q);
 Output;
End.
