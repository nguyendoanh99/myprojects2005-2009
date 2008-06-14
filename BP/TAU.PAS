Uses crt;
Const fi='D:\TAU.IN';
      fo='D:\TAU.OUT';
      maxn=24;
      maxm=4;
Var sl,bd,dd,n,m:byte;
    A:array[1..maxn,0..maxm] of byte;
    B:array[1..maxm,1..maxm] of boolean;
    Taudd:array[1..maxm] of boolean;
    Tau:array[1..maxm] of Record x,y:byte End;
    DD1,DD2:array[1..maxm] of byte;
Procedure Taodd(t:byte);
Var i:shortint;
Begin
 i:=tau[t].x;
 While i<=n do
  Begin
   Inc(A[i,0]);
   A[i,A[i,0]]:=t;
   Inc(i,tau[t].y);
  End;
 i:=tau[t].x-tau[t].y;
 While i>=1 do
  Begin
   Inc(A[i,0]);
   A[i,A[i,0]]:=t;
   Dec(i,tau[t].y);
  End;
End;
Procedure Input;
Var f:text;
    i:byte;
    s:string;
    t:integer;
    c:char;
Begin
 Assign(f,fi);reset(f);
 Readln(f,n,m,bd,dd);
 s:='';
 i:=1;
 While not eof(f) do
  Begin
   Read(f,c);
   Case c of
   '_': Begin
         Val(s,tau[i].x,t);
         s:='';
        End;
   ' ',chr(13): Begin
         Val(s,tau[i].y,t);
         s:='';
         Taodd(i);
         Inc(i);
        End
   Else s:=s+c;
   End;
  End;
 Close(f);
End;
Procedure TaoDoThi;
Var i,j,r:shortint;
Begin
 For i:=1 to n do
  Begin
   For j:=1 to A[i,0]-1 do
    For r:=j+1 to A[i,0] do
     Begin
      B[a[i,j],a[i,r]]:=true;
      B[a[i,r],a[i,j]]:=true;
     End;
  End;
End;
Function Kt(t,dd:byte):boolean;
Var i:byte;
Begin
 i:=1;
 While (i<=a[dd,0])and(a[dd,i]<>t) do Inc(i);
 Kt:=i<=a[dd,0];
End;
Procedure Try(t:byte);
Var i:byte;
Begin
 If kt(dd1[t],dd) then
  Begin
   If t<sl then
    Begin
     sl:=t;
     dd2:=dd1;
    End;
  End
 Else
 For i:=1 to m do
  If B[dd1[t],i] and not taudd[i] then
  Begin
   taudd[i]:=true;
   dd1[t+1]:=i;
   Try(t+1);
   taudd[i]:=false;
   dd1[t+1]:=0
  End;
End;
Procedure Output;
Var f:text;
    i,j:byte;
Begin
 Assign(f,fo);Rewrite(f);
 For i:=1 to a[bd,0] do
  Begin
   taudd[a[bd,i]]:=true;
   dd1[1]:=a[bd,i];
   Try(1);
   taudd[a[bd,i]]:=false;
  End;
 If sl<255 then
  Begin
   Writeln(f,sl);
   Write(f,tau[dd2[1]].x,'_',tau[dd2[1]].y,' ',bd,' ');
   For i:=2 to sl do
    Begin
     j:=1;
     While (j<=n)and not((kt(dd2[i-1],j)and(kt(dd2[i],j)))) do Inc(j);
     Writeln(f,j);
     Write(f,tau[dd2[i]].x,'_',tau[dd2[i]].y,' ',j,' ');
    End;
   Write(f,dd);
  End
 Else Writeln(f,-1);
 Close(f);
End;
Begin
 Fillchar(a,sizeof(a),0);
 Input;
 TaoDoThi;
 Fillchar(taudd,sizeof(taudd),false);
 Fillchar(dd1,sizeof(dd1),0);
 sl:=255;
 Output;
End.