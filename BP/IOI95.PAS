Uses crt;
Const Tip='D:\Input.txt';
      Top='D:\Offer.txt';
Var b:0..5;
    s:0..99;
    Tcu,Tmoi:integer;
    Can:array[1..5] of record
                        c:1..999;
                        k:1..5;
                        p:1..999
                       End;
    Cach:array[1..99] of record
                          n:1..5;
                          Hang:array[1..5] of record
                                               c:1..999;
                                               k:1..5
                                              End;
                          p:1..9999
                         End;
Function Lay(a:byte):Boolean;
Var i,j:byte;
    k:Boolean;
Begin
 k:=True;
 i:=1;
 While (i<=cach[a].n)and(k=true) do
  Begin
   j:=1;
   While (j<=b)and(can[j].c<>cach[a].hang[i].c) do Inc(j);
   If (can[j].c<>cach[a].hang[i].c)or(can[j].k<cach[a].hang[i].k) then k:=not k;
   Inc(i)
  End;
 Lay:=k
End;
Procedure Input;
Var f:text;
    i,j:byte;
Begin
 Assign(f,Tip);Reset(f);
 Readln(f,b);
 For i:=1 to b do
  Begin
   With can[i] do Read(f,c,k,p);
   Readln(f)
  End;
 Close(f);
 Assign(f,Top);Reset(f);
 Readln(f,s);
 For i:=1 to s do
  Begin
   With cach[i] do
    Begin
     Read(f,n);
     For j:=1 to n do
      With Hang[j] do Read(f,c,k);
     Readln(f,p)
    End
  End;
 Close(f)
End;
Procedure Try(a:byte);
Var k,i,j:byte;
Begin
 For k:=a to s do
  Begin
   If lay(k) then
    Begin
     For i:=1 to cach[k].n do
      Begin
       j:=1;
       While can[j].c<>cach[k].hang[i].c do Inc(j);
       Dec(can[j].k,cach[k].hang[i].k)
      End;
     Inc(Tmoi,cach[k].p);
     Try(k);
     For i:=1 to cach[k].n do
      Begin
       j:=1;
       While can[j].c<>cach[k].hang[i].c do Inc(j);
       Inc(can[j].k,cach[k].hang[i].k)
      End;
     Dec(Tmoi,cach[k].p)
    End
   Else
     If k=s then
      Begin
       For i:=1 to b do
        Inc(Tmoi,Can[i].k*can[i].p);
       If Tmoi<Tcu then Tcu:=Tmoi;
       For i:=1 to b do
        Dec(Tmoi,Can[i].k*can[i].p);
      End;
  End;
End;
Begin
 Clrscr;
  Input;
  Tcu:=32000;
  Tmoi:=0;
  Try(1);
  Write(tcu);
 Readln
End.