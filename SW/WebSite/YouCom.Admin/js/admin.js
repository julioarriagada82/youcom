function getElementsByAttribute(oElm, strTagName, strAttributeName, strAttributeValue){
    var arrElements = (strTagName == "*" && oElm.all)? oElm.all : oElm.getElementsByTagName(strTagName);
    var arrReturnElements = new Array();
    var oAttributeValue = (typeof strAttributeValue != "undefined")? new RegExp("(^|\\s)" + strAttributeValue + "(\\s|$)") : null;
    var oCurrent;
    var oAttribute;
    for(var i=0; i<arrElements.length; i++){
        oCurrent = arrElements[i];
        oAttribute = oCurrent.getAttribute && oCurrent.getAttribute(strAttributeName);
        if(typeof oAttribute == "string" && oAttribute.length > 0){
            if(typeof strAttributeValue == "undefined" || (oAttributeValue && oAttributeValue.test(oAttribute))){
                arrReturnElements.push(oCurrent);
            }
        }
    }
    return arrReturnElements;
}


function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}
//Cambia color de un td via css
function mOvr(src,clrOver){ 
 if (!src.contains(event.fromElement)){ 
  src.style.cursor = 'hand'; 
  src.className = clrOver; 
 } 
} 
function mOut(src,clrIn){ 
 if (!src.contains(event.toElement)){ 
  src.style.cursor = 'hand'; 
  src.className = clrIn; 
 } 
}

function mClk(src, clrIn) 
{
	if(event.srcElement.tagName=='TD')
	{
		src.children.tags('A')[0].click();
		src.className = clrIn;
	}
}


function helpMinPanel (text) {
	
	
}

function helpSection (section, opc)
{
	window.open('pop_ayuda.php?section='+section+'&opc='+opc,'ayuda','width=800,height=600,scrollbars=no');
}


function abreExplorador(image, hiddenResult, path)
{
    window.open('popup/DirectoryNavigator.aspx?image='+image+'&hidden='+hiddenResult+'&path='+path,'Logos','width=500,height=400,scrollbars=yes');
}

function getElementById(id) {
	if (document.getElementById) {
		return document.getElementById(id);
	} else if (document.all) {
		return document.all[id];
	} else if (document.elements) {
		return document.elements[id];
	} else {
		return false;
	}
}
	function showDiv(div, visibility)
	{
		if(document.all)
		{
			layer = document.all[div];
		} 
		else
		{
			layer = document.getElementById(div);
		}
		display = (visibility)?'block':'none';
		layer.style.display = display;
	}

function isDoc(source, arguments)
{
	if(arguments.Value=='')arguments.IsValid=true;
	arguments.IsValid = _isDoc(arguments.Value);
}

function isDocPdf(source, arguments)
{
	if(arguments.Value=='')arguments.IsValid=true;
	arguments.IsValid = _isDocPdf(arguments.Value);
}

function isPdf(source, arguments)
{
	if(arguments.Value=='')arguments.IsValid=true;
	arguments.IsValid = _isPdf(arguments.Value);
}

function isImage(source, arguments)
{
	if(arguments.Value=='')arguments.IsValid=true;
	arguments.IsValid = _isImage(arguments.Value);
}

function isCV(source, arguments)
{
	if(arguments.Value=='')arguments.IsValid=true;
	arguments.IsValid = _isCV(arguments.Value);
}

function isImageFlash(source, arguments)
{
	if(arguments.Value=='')arguments.IsValid=true;
	arguments.IsValid = _isImageFlash(arguments.Value);
}

function isMinLength(source, arguments)
{
	//if(arguments.Value=='')arguments.IsValid=true;
	arguments.IsValid = _isMinLength(arguments.Value);
}

function _isMinLength(value) {
	return (value.length>5);
}

function _isMail(value) {
    var pattern=new RegExp("^([a-zA-Z0-9_\\-]+\\.{0,1})+@([a-zA-Z0-9_\\-]+\\.)+[a-zA-Z0-9_\\-]+$");
    return value.match(pattern);
}

function _isDocPdf(valor)
{
	if (valor!=''){
		ext = valor.slice(valor.lastIndexOf(".")+1,valor.length).toUpperCase();
		if (ext != "PDF" && ext != "DOC" && ext != "XLS" && ext != "PPT" && ext != "PDF"){
			return false;
		}
	}
	return true;
}

function _isCV(valor)
{
	if (valor!=''){
		ext = valor.slice(valor.lastIndexOf(".")+1,valor.length).toUpperCase();
		if (ext != "DOC" && ext != "PDF" && ext != "RTF" && ext != "ZIP" && ext != "RAR" && ext != "JPG" && ext != "JPEG"){
			return false;
		}
	}
	return true;
}

function _isPdf(valor)
{
	if (valor!=''){
		ext = valor.slice(valor.lastIndexOf(".")+1,valor.length).toUpperCase();
		if (ext != "PDF"){
			return false;
		}
	}
	return true;
}

function _isFile(valor)
{
	if (valor!=''){
		ext = valor.slice(valor.lastIndexOf(".")+1,valor.length).toUpperCase();
		if (ext != "PDF"){
			return false;
		}
	}
	return true;
}

function _isImageFlash(valor)
{
	if (valor!=''){
		ext = valor.slice(valor.lastIndexOf(".")+1,valor.length).toUpperCase();
		if (ext != "JPG" && ext != "GIF" && ext != "PNG" && ext != "JPEG" && ext != "BMP" && ext != "SWF"){
			return false;
		}
	}
	return true;
}
function _isImage(valor)
{
	if (valor!=''){
		ext = valor.slice(valor.lastIndexOf(".")+1,valor.length).toUpperCase();
		if (ext != "JPG" && ext != "GIF" && ext != "PNG" && ext != "JPEG" && ext != "BMP"){
			return false;
		}
	}
	return true;
}

function muestraDocumento(doc, type) {
	window.open(doc);
}

function muestraSpanImagen(span) {
		spn = getElementById(span)
		{
			if(spn.style.display == ''){
				spn.style.display = 'none';
			} else {
				spn.style.display = '';
			}
		}
}

function checkMaxLength (textarea, evt, maxLength) {
	try
	{
		if (textarea.selected && evt.shiftKey) 
			// ignore shift click for select
			return true;
		var allowKey = false;
		if (textarea.selected && textarea.selectedLength > 0) {
			allowKey = true;
		} else {
			var keyCode = document.layers ? evt.which : evt.keyCode;
			if (keyCode < 32 && keyCode != 13) {
			  allowKey = true;
			} else {
				allowKey = textarea.value.length < maxLength;
				if(!allowKey) {return false;}
			}
		}
		textarea.selected = false;
		return allowKey;
	}
	catch(e)
	{
		alert('error ' + e.Description);
	}
}

function storeSelection (field) {
  if (document.all) {
    field.selected = true;
    field.selectedLength = 
      field.createTextRange ?
        document.selection.createRange().text.length : 1;
  }
}
