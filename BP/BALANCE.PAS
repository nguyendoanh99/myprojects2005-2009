{Bai 173/2004 - Can bang}
Uses crt;
Const fi='C:\BALANCE.INP';
      fo='C:\BALANCE.OUT';
      max=200;
Type arr=array[0..max] of word;
     Tree=record
          n:word;
          Ke,Index:arr
         End;
Var t:Tree;
Procedure Input(Var t:Tree);
Var f:text;
    a,b,i,j:word;
Begin
 Assign(f,fi);Reset(f);
 Readln(f,t.n);
 Fillchar(t.Index,sizeof(t.index),0);
 With t do
  For i:=1 to n-1 do
   Begin
    Readln(f,a,b);
    For j:=index[n] downto index[a]+1 do ke[j+1]:=ke[j];
    ke[index[a]+1]:=b;
    For j:=n downto a do Inc(index[j])
   End;
 Close(f)
End;
{Dem so nut cua cay goc g}
Procedure DemNut(t:tree;g,l:word;Var d:word);
Var i:word;
Begin
 Inc(d);
 With t do
  For i:=index[g-1]+1 to index[g] do
   If ke[i]<>l then DemNut(t,ke[i],l,d)
End;
{Tim can bang cua nut d}
Function CanBang(t:tree;d:word):word;
Var m1,m2,i:word;
Begin
 m1:=0;
 With t do
  Begin
   For i:=1 to n do
    If i<>d then
     Begin
      m2:=0;
      DemNut(t,i,d,m2);
      If m2>m1 then m1:=m2
     End
  End;
 CanBang:=m1
End;
Procedure Output(t:tree);
Var i,k1,k2,l:word;
    f:text;
Begin
 Assign(f,fo);Rewrite(f);
 k1:=CanBang(t,1);
 l:=1;
 For i:=2 to t.n do
  Begin
   k2:=CanBang(t,i);
   If k2<k1 then
    Begin
     k1:=k2;
     l:=i
    End
  End;
 Writeln(f,l);
 Writeln(f,k1);
 Close(f)
End;
Begin
 Clrscr;
 Input(t);
 Output(t);
 Readln;
End.