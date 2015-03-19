

  /////////////////////////////////////////////////
  //
  //   Menus by : shoaib ali
  //
  //   use the code according to your need there is no copyright..(i dont mind if u give me some credit)
  //   you can contact me at alleey@usa.net
  //   your comments and suggestions are always Welcome!
  //
  //   minor tweaks for Netscape - Pete Davis, javasOK@netscape.net
  //
  /////////////////////////////////////////////////

//
//pd
//added for Netscape support
//used by TrackPopUp(...)
//
function sniffIE()
{
	var sAgent = navigator.userAgent

	//alert("navigator.userAgent = " + sAgent)

	var isIE = (sAgent.indexOf("MSIE")  > -1)

	return isIE;
}

function onmenuclick(obj,code)
{
	hide(obj);
	eval(code);
}

function show(obj)
{
 	if(typeof(obj) == "undefined")
		return;
 	obj.style.visibility = 'visible';
}

function hide(obj)
{
	if(typeof(obj) == "undefined")
		return;
	obj.style.visibility = 'hidden';
}

function SetColor(obj,color)
{
	if(typeof(obj) == "undefined")
		return;
	obj.style.backgroundColor = color;
}

function OnMouseOverBar(obj,rowid,colid,color)
{
	SetColor(obj,color);
	window.status = menuArr[rowid][colid][2];
}

function OnMouseOutOfBar(obj,rowid,colid,color)
{
	SetColor(obj,color);
	window.status = "";
}


function Initialize(rows,cols)
{
  menuArr = new Array();
  titles =  new Array();
  for(i=0; i< rows; i++)
  {
     titles[i] =  new Array(2)
	 titles[i][0] = "";
	 titles[i][1] = 0;
  }
  for (i=0; i < rows; i++) 
  {
	menuArr[i] = new Array(cols)
	for (j=0; j < cols; j++) 
	{
		menuArr[i][j] = new Array(3)
		for(k=0; k < 3 ; k++)
		 menuArr [i][j][k] = "";
	}
  }
}

function CreatePopUpMenu(rowid,x,y,width,height,hColor,dColor,bColor,items,align,border)
{
	if(!items)
	{
	   return;
	}
	var divHTML ;

	divHTML = "<DIV id=\"popup_"+rowid+"\"" ;
	divHTML += "style=\"position:absolute; top:"+y+"px; left:"+x+"px; width:"+width+"px; visibility:hidden; padding-left:"+border+"; background-color:"+bColor+";\" ";
	divHTML += "onmouseover=\"show(this);\" onmouseout=\"hide(this);\" >\n";
	divHTML += CreateSeparatorBar(bColor,width-(border*2),border);

	for (i=0;i<items;i++)
	{
		divHTML += CreateMenuBar('popup_'+rowid,rowid,i,width-(border*2),height,hColor,dColor,align);
		divHTML += CreateSeparatorBar(bColor,width-(border*2),border);
	}  
	  
	divHTML += "</DIV>";
	document.write(divHTML);
}

function CreateMenu(rowid,x,y,width,height,hColor,dColor,bColor,items,align,border)
{
	if(!items)
	{
	   return;
	}
	var divHTML ;
	var menuBar;
	menuBar ="<DIV id=\"main_div_"+rowid+"\" align=\""+align+"\" style=\" position:absolute; CURSOR: hand; top:"+y+"px; left:"+x+"px; width:"+width+"px; height:"+height+"px; visibility:visible;  background-color:"+dColor+";\" ";
	//pd - replaced document.all(...) with document.getElementById(...)
	menuBar += " onmouseover=\"show(document.getElementById(\'div_"+rowid+"\'));\"  onmouseout=\"hide(document.getElementById(\'div_"+rowid+"\'));\" >"; 
	menuBar += titles[rowid][0] + " </DIV>";
	document.write (menuBar);
	
	//pd - replaced document.all(...) with document.getElementById(...)
	y += document.getElementById("main_div_"+rowid).offsetHeight;

	divHTML = "<DIV id=\"div_"+rowid+"\"" ;
	divHTML += "style=\"position:absolute; top:"+y+"px; left:"+x+"px; width:"+width+"px; visibility:hidden; padding-left:"+border+"; background-color:"+bColor+";\" ";
	divHTML += "onmouseover=\"show(this);\" onmouseout=\"hide(this);\" >\n";
	divHTML += CreateSeparatorBar(bColor,width-(border*2),border);

	for (i=0;i<items;i++)
	{
		divHTML += CreateMenuBar('div_'+rowid,rowid,i,width-(border*2),height,hColor,dColor,align);
		divHTML += CreateSeparatorBar(bColor,width-(border*2),border);
	}  
	  
	divHTML += "</DIV>";
	document.write(divHTML);
}

function CreateSeparatorBar(dColor,width,border)
{
	var sepHTML; 
	sepHTML = "<DIV id=\"line_separator\" style=\"position:relative; height:1px; background-color:"+dColor+";\" >";
	sepHTML += "<img src=\"\" width=" + width  + " height="+border/2+"></DIV> \n";
	return sepHTML;
}

function CreateMenuBar(parent,rowid,colid,width,height,hColor,dColor,align)
{
	var subMenuHTML; 
	subMenuHTML = "\n<DIV align="+align+" id=\"div_"+rowid+"_"+colid+"\" style=\"position:relative; CURSOR: hand; width:"+width+"px; background-color:"+dColor+";\" ";
	subMenuHTML += " onmouseover=\"OnMouseOverBar(this,"+rowid+","+colid+",\'"+hColor+"\');\" ";
	subMenuHTML += " onclick=\"onmenuclick(document.getElementById(\'"+parent+"\'),\'" + menuArr[rowid][colid][1] + "\');\" ";
	subMenuHTML += " onmouseout=\"OnMouseOutOfBar(this,"+rowid+","+colid+",\'"+dColor+"\');\" >";
	subMenuHTML +=  menuArr[rowid][colid][0];
	subMenuHTML += " </DIV> \n";
	return subMenuHTML;
}

//
//pd
//Modified to work with Netscape which doesn't support window.event.x/y
//Although this works, I didn't like it : 1. the "if" statements are a 
//bit ugly, 2. the popups display relative to the pointer position rather
//than the table cell.
//
//When calling from html, pass in "this.event" eg.,
//onmouseover="TrackPopUp('popup_#',event)"
//
function TrackPopUp(objId,event)
{

	if(typeof(objId) == "undefined")
		return;
		
	obj = document.getElementById(objId)
	var winWidth  = document.body.clientWidth;
	var winHeight = document.body.clientHeight;
	
	if (sniffIE()){
		//MSIE
		x = winWidth - (obj.offsetWidth + window.event.x);
		y = winHeight - (obj.offsetHeight + window.event.y);
		obj.style.left = x<0 ? window.event.x + (x + 20): window.event.x + 20;
		obj.style.top = y<0 ? window.event.y + y : window.event.y;	
	}else{
		//Mozilla/Netscape
		x = winWidth - (obj.offsetWidth + event.pageX);
		y = winHeight - (obj.offsetHeight + event.pageY);
		obj.style.left = x<0 ? event.pageX + x : event.pageY;
		obj.style.top = y<0 ? event.pageY + y : event.pageY;
	}
	show(obj);
	return false;
}
// pd - added
//
// Assumes the PopUp will be attached to a <td> table cell.
// Supports nesting of tables within tables.
// NOT tested when nested within other elements.
//
// Parms : objId = the element id of the popup menu
// Parms : parentId = the element id of the <tr> table row to place the popup next to
//
function PositionPopUp(objId,parentId)
{
	if(typeof(objId) == "undefined")
		return;

	//first get a reference to the popup menu
	obj = document.getElementById(objId)

	//next get a reference to the <tr>
	var thisParent = document.getElementById(parentId);
	
	//now walk up the DOM until the BODY element is reached.
	//along the way, add up the Left & Top offsets
	var myLeft = 0;
	var myTop = 0;
	var trParent = thisParent.offsetParent;
	myLeft += trParent.offsetLeft;
	myTop += trParent.offsetTop;	
	while (trParent.offsetParent.tagName != 'BODY'){
		trParent = trParent.offsetParent;	//get the next parent up the nest
		myLeft += trParent.offsetLeft;
		myTop += trParent.offsetTop;
	}

	obj.style.left = myLeft + thisParent.offsetLeft + thisParent.offsetWidth;
	obj.style.top = myTop + thisParent.offsetTop + thisParent.offsetHeight/2;

	show(obj);
	return false;
}
