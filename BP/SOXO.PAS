Uses crt;
Const tf='D:\SOXO.IN';
Var i,n:integer;
    A:array[1..10] of record
                       ten,kyhieu:string;
                       kt:boolean;
                      End;
Function Doi(s:string):longint;
Var i:integer;
    t:longint;
Begin
 t:=1;
 For i:=1 to length(s) do t:=t*(ord(s[i])-64);
 Doi:=t
End;
Procedure Input;
Var f:text;
    s:string;
    j,i:integer;
Begin
 Assign(f,tf);Reset(f);
 Readln(f,n);
 For i:=1 to n do
  Begin
   Readln(f,s);
   j:=1;
   While s[j]<>' ' do Inc(j);
   With A[i] do
    Begin
     ten:=copy(s,1,j-1);
     kyhieu:=copy(s,j+1,length(s)-j);
     If (doi(ten) mod 47)=(doi(kyhieu) mod 47) then kt:=True
     Else kt:=False
    End
  End;
 Close(f)
End;
Begin
 Clrscr;
  Input;
  For i:=1 to n do Writeln(a[i].ten,' ',a[i].kt);
 Readln
End.