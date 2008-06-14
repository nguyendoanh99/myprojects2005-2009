Uses crt;
Var s:string;
    a:array[0..9] of integer;
    c,i:integer;
    max,k:byte;
Begin
 Clrscr;
  Fillchar(a,sizeof(a),0);
  Write('Nhap 1 day so nguyen : ');Readln(s);
  For i:=1 to length(s) do
   If s[i] in ['0'..'9'] then
    Begin
     Val(s[i],k,c);
     Inc(a[k])
    End;
  Max:=0;
  For i:=1 to 9 do
   If a[max]<a[i] then max:=i;
  Write(max);
 Readln
End.