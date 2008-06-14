var images="coffee.gif";

var docLayers = (document.layers) ? true:false;
var ns6=document.getElementById&&!document.all;


var SizeMax = 13;
var distanceY = 180;
var distanceX = 400;
var Xcur;
var Ycur;
var posX; // Toa do X cua chuot
var posY; // Toa do Y cua chuot

function randommaker(range)
{		
	return Math.floor(range*Math.random())
}
// Dau sai (X)
var Ai = [0, 7, 1, 6, 2, 5, 3, 4, 4, 3, 5, 2, 6, 1, 7, 0];
var Aj = [0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7];
// Dau dung (tick)
var Bi = [7, 6, 5, 4, 3, 2, 1, 0, 1, 2, 3, 4];
var Bj = [0, 1, 2, 3, 4, 5, 4, 3, 5, 6, 5, 4];
var Diem2; // goc phai duoi cua dau sai (X)
var Diem3; // goc phai duoi cua dau dung (tick)
var amount = Ai.length;    
var amount2 = Bi.length;

function KiemTraThuoc(x,y)
{
	var x1 = posX - (Diem2.x + 4)/2 * SizeMax;
	var x2 = posX + (Diem2.x + 4)/2 * SizeMax;
	var y1 = posY - (Diem2.y + 4)/2 * SizeMax;
	var y2 = posY + (Diem2.y + 4)/2 * SizeMax;
	return (x1 <= x && x <= x2) && (y1 <= y && y <= y2);
}

function TaoToaDoNgauNhien()
{	
	var Bi = [0, document.body.clientWidth - distanceX - (Diem2.x + 1)*SizeMax, 0, document.body.clientWidth - distanceX - (Diem2.x + 1)*SizeMax];
	var Bj = [distanceY, distanceY , document.body.clientHeight - (Diem2.y + 1)*SizeMax, document.body.clientHeight - (Diem2.y + 1)*SizeMax];
	
	Xcur = randommaker(document.body.clientWidth - distanceX);
	Ycur = randommaker(document.body.clientHeight - distanceY - (Diem2.y + 1)*SizeMax) + distanceY;
	
	if (KiemTraThuoc(Xcur, Ycur) ||
		KiemTraThuoc(Xcur + (Diem2.x + 1)*SizeMax, Ycur) ||
		KiemTraThuoc(Xcur, Ycur + (Diem2.y + 1)*SizeMax) ||
		KiemTraThuoc(Xcur + (Diem2.x + 1)*SizeMax, Ycur + (Diem2.y + 1)*SizeMax))
	{
		for (i = 0; i < 4; ++i)
		{
			Xcur = Bi[i];
			Ycur = Bj[i];

			if (!(KiemTraThuoc(Xcur, Ycur) ||
				KiemTraThuoc(Xcur + (Diem2.x + 1)*SizeMax, Ycur) ||
				KiemTraThuoc(Xcur, Ycur+ (Diem2.y + 1)*SizeMax) ||
				KiemTraThuoc(Xcur + (Diem2.x + 1)*SizeMax, Ycur + (Diem2.y + 1)*SizeMax)))
				return ;
		}
	}
}
function ToaDo(x,y)
{
	this.x = x;
	this.y = y;
}

function Lay_XmaxYmax(Ai,Aj)
{
	var X2 = 0;
	var Y2 = 0;
	for(i = 0; i < amount; ++i)
	{
		X2 = Math.max(X2, Ai[i]);
		Y2 = Math.max(Y2, Aj[i]);
	}

	return new ToaDo(X2, Y2);
}
var t;


var marginbottom;
var marginright;

var sparklewidth=20;
var sparkleheight=20;
var x_random=new Array();
var y_random=new Array();
var max_explsteps=80;
var i_explsteps=0;
var speed=20;

function init()
{
	marginbottom=document.body.clientHeight;
	marginright=document.body.clientWidth;
	i_explsteps = 0;

	for (i=0;i<=amount;i++) {
		x_random[i]=Math.ceil(20*Math.random())-10;
        y_random[i]=Math.ceil(20*Math.random())-10;
		while(x_random[i]>-2 && x_random[i]<2) {
        	x_random[i]=Math.ceil(20*Math.random())-10;
        	y_random[i]=Math.ceil(20*Math.random())-10;
		}
	}
	clearTimeout(t);
	explode();
}

function explode() 
{
	if (i_explsteps<=max_explsteps) 
	{
		for (i=0;i<amount;i++) 
		{
			with (ieDiv.all.pictures.all[i].style)
			{
				left = parseInt(left)+x_random[i];
				top = parseInt(top)+y_random[i];	
			}			
		}
		i_explsteps++;
		t=setTimeout("explode()",speed);		
	}
	else // Hoi tu chu tai mot diem
	{ 
		clearTimeout(t);
		TaoToaDoNgauNhien();	
		for (i = 0; i < amount; ++i)
		{
			t=setTimeout("LineBres(" + i +", " + (Xcur + Ai[i] * SizeMax) +", " + (Ycur + Aj[i] * SizeMax) +")", 20);	
		}		
	}
	
}
var heso = new Array();
function LineBres(index, x2, y2)
{
	var x1 = parseInt(ieDiv.all.pictures.all[index].style.left);
	var y1 = parseInt(ieDiv.all.pictures.all[index].style.top);
	var Dx = x2 - x1;
	var Dy = y2 - y1;
	var dx = (Dx < 0) ? -1 : 1;	
	Dx = Math.abs(Dx);
	var dy = (Dy < 0) ? -1 : 1;	
	Dy = Math.abs(Dy);	
	if (Dx > Dy)
	{
		var p = 2 * Dy - Dx;
		var Const1 = 2 * Dy;
		var Const2 = 2 * (Dy-Dx);
		heso[index] = Dx / 50;
		t=setTimeout("Line1(" + index + ", " + x1 + ", " + y1 + ", " + x2 + ", " +  y2 + ", " + dx + ", " + dy + ", " + p + ", " + Const1 + ", " + Const2 + ")", 20);
	}
	else
	{
		var p = 2 * Dx - Dy;
		var Const1 = 2 * Dx;
		var Const2 = 2 * (Dx-Dy);
		heso[index] = Dy / 50;
		t=setTimeout("Line2(" + index + ", " + x1 + ", " + y1 + ", " + x2 + ", " +  y2 + ", " + dx + ", " + dy + ", " + p + ", " + Const1 + ", " + Const2 + ")", 20);
	}

}

function Line1(index, x, y, x2, y2, dx, dy, p, Const1, Const2)
{
	if (x != x2) 
	{

		if (p < 0) {
			p += Const1 * heso[index];
		} 
		else {
			p += Const2 * heso[index];
			y += dy * heso[index];
			if ((dy == -1 && y < y2) || (dy == 1 && y > y2))		
				y = y2;
		}
		x += dx * heso[index];
		if ((dx == -1 && x < x2) || (dx == 1 && x > x2))
		{
			x = x2;
			y = y2;
		}
		with (ieDiv.all.pictures.all[index].style)
		{
			left = x;
			top = y;
		}
	
		t=setTimeout("Line1(" + index + ", " + x + ", " + y + ", " + x2 + ", " + y2 + ", " + dx + ", " + dy + ", " + p + ", " + Const1 + ", " + Const2 + ")", 20);
	}
}

function Line2(index, x, y, x2, y2, dx, dy, p, Const1, Const2)
{
	if (y != y2) 
	{
		if (p < 0) {
			p += Const1 * heso[index];
		} 
		else {
			p += Const2 * heso[index];
			x += dx * heso[index];
			if ((dx == -1 && x < x2) || (dx == 1 && x > x2))		
				x = x2;
		}
		y += dy * heso[index];

		if ((dy == -1 && y < y2) || (dy == 1 && y > y2))		
		{
			x = x2;
			y = y2;
		}
		with (ieDiv.all.pictures.all[index].style)
		{
			left = x;
			top = y;
		}
	
		t=setTimeout("Line2(" + index + ", " + x + ", " + y + ", " + x2 + ", " + y2 + ", " + dx + ", " + dy + ", " + p + ", " + Const1 + ", " + Const2 + ")", 20);
	}
}

function VeChu(Xpos, Ypos) // Dau sai
{
	 for (i=0;i<ieDiv.all.pictures.all.length;i++)
	 {
		 ieDiv.all.pictures.all[i].style.top = (Ypos + Aj[i] * SizeMax);
		 ieDiv.all.pictures.all[i].style.left = (Xpos + Ai[i] * SizeMax);
	 }
 }

function VeChu2(Xpos, Ypos) // Dau dung
{
	 for (i=0;i<ieDiv.all.pictures2.all.length;i++)
	 {
		 ieDiv.all.pictures2.all[i].style.top = (Ypos + Bj[i] * SizeMax);
		 ieDiv.all.pictures2.all[i].style.left = (Xpos + Bi[i] * SizeMax);
	 }
 }


function KhoiTao()
{
	if (document.all)
	{
		document.write('<div id="ieDiv" style="position:absolute;top:0px;left:0px">')
		// Dau sai
		document.write('<div id="pictures" style="position:relative">');
		for (n=0; n < amount; n++)
			document.write('<img src=" '+images+'" style="position:absolute;top:0px;left:0px" width="' + SizeMax + '" height="' + SizeMax + '" onmouseover="init()"">')
		document.write('</div>')
		// Dai dung
		document.write('<div id="pictures2" style="position:relative">');
		for (n=0; n < amount2; n++)
			document.write('<img src=" '+images+'" style="position:absolute;top:0px;left:0px" width="' + SizeMax + '" height="' + SizeMax + '" onclick="_open()">')
		document.write('</div>')
		document.write('</div>')

	}
	Diem2 = Lay_XmaxYmax(Ai,Aj);
	Diem3 = Lay_XmaxYmax(Bi, Bj);
	TaoToaDoNgauNhien();
    VeChu(Xcur, Ycur);
	VeChu2(document.body.clientWidth - 150, document.body.clientHeight - 300);
}

function _open()
{
	alert("Biet co mui khong kho");
	alert("Tri het mui moi kho");
	alert("Chuyen gi kho da co rexona");
	document.location = "fullpage.html";
}

KhoiTao();

function alert1()
{
	var Xpos = 300;
	var Ypos = 300;
//	alert(document.body.scrollTop);
//	alert(posX + " " + posY);
	TaoToaDoNgauNhien();

}

 function LayToaDoChuot(e) {
  posX = getMouseXPos(e);
  posY = getMouseYPos(e);

}
// Get the horizontal position of the mouse
function getMouseXPos(e) {
  if (document.layers||ns6) {
    return parseInt(e.pageX+10)
  } else {
    return (parseInt(event.clientX+10) + parseInt(document.body.scrollLeft))
  }
}
// Get the vartical position of the mouse
function getMouseYPos(e) {
  if (document.layers||ns6) {
    return parseInt(e.pageY)
  } else {
    return (parseInt(event.clientY) + parseInt(document.body.scrollTop))
  }
}
function Begin(){

if (docLayers) {
  document.captureEvents(Event.MOUSEMOVE)
  document.onMouseMove = LayToaDoChuot
} else {
  document.onmousemove = LayToaDoChuot
}
}
Begin();
//window.onload=Begin
