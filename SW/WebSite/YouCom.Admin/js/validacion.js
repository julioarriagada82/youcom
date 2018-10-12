function validaRut(Objeto)
{
	var tmpstr = "";
	var intlargo = Objeto.value
	var rut="";
	if (intlargo.length> 0)
	{
		crut = Objeto.value
		largo = crut.length;
		if ( largo <2 )
		{
			alert('Rut Invalido')
			Objeto.value='';
			return false;
		}
		for ( i=0; i <crut.length ; i++ )
		if ( crut.charAt(i) != ' ' && crut.charAt(i) != '.' && crut.charAt(i) != '-' )
		{
			tmpstr = tmpstr + crut.charAt(i);
		}
		rut = tmpstr;
		crut=tmpstr;
		largo = crut.length;
	
		if ( largo> 2 )
			rut = crut.substring(0, largo - 1);
		else
			rut = crut.charAt(0);
	
		dv = crut.charAt(largo-1);
	
		if ( rut == null || dv == null )
		return 0;
	
		var dvr = '0';
		suma = 0;
		mul  = 2;
	
		for (i= rut.length-1 ; i>= 0; i--)
		{
			suma = suma + rut.charAt(i) * mul;
			if (mul == 7)
				mul = 2;
			else
				mul++;
		}
	
		res = suma % 11;
		if (res==1)
			dvr = 'k';
		else if (res==0)
			dvr = '0';
		else
		{
			dvi = 11-res;
			dvr = dvi + "";
		}
	
		if ( dvr != dv.toLowerCase() )
		{
			alert('El Rut Ingreso es Invalido')
			Objeto.value='';
			return false;
		}
		else{
			Objeto.value=formato_rut(tmpstr);
			return true;
		}
		
		
	}

}


function formato_rut(rut)
{
   var sRut1 = rut;
   //contador de para saber cuando insertar el . o la -
   var nPos = 0;
 
   //Guarda el rut invertido con los puntos y el guión agregado
   var sInvertido = "";
 
   //Guarda el resultado final del rut como debe ser
   var sRut = "";
 
   for(var i = sRut1.length - 1; i >= 0; i-- )
   {
        
           sInvertido += sRut1.charAt(i);
           if (i == sRut1.length - 1 )
               sInvertido += "-";
           else if (nPos == 3)
           {
               sInvertido += ".";
               nPos = 0;
           }
           nPos++;       
   }
 
   for(var j = sInvertido.length - 1; j >= 0; j-- )
   {
           if (sInvertido.charAt(sInvertido.length - 1) != ".")
                sRut += sInvertido.charAt(j);
           else if (j != sInvertido.length - 1 )
               sRut += sInvertido.charAt(j);
        
   }
   //Pasamos al campo el valor formateado
   rut = sRut.toUpperCase();
   return rut;
}

function validaDatosLoginPersona(){
    if(document.getElementById('usuario').value.length<8 || document.getElementById('usuario').value=='Rut Usuario')
    {   alert("Estimado Usuario, debe ingresar el rut para ingresar.");
        return false;
    }
    else if(document.getElementById('pass').value.length<4){
        alert("Estimado Usuario, debe ingresar la clave para ingresar.");
        return false;
    }
    else
        return true;
}
function validaDatosLoginEmpresa(){
    if(document.getElementById('empresa').value.length<8 || document.getElementById('empresa').value=='Rut Empresa'){
        alert("Estimado Usuario, debe ingresar el rut empresa para ingresar.");
        return false;
    }
    else if(document.getElementById('usuario_empresa').value.length<8 || document.getElementById('usuario_empresa').value=='Rut Usuario')
    {   alert("Estimado Usuario, debe ingresar el rut persona para ingresar.");
        return false;
    }
    else if(document.getElementById('pass_empresa').value.length<4){
        alert("Estimado Usuario, debe ingresar la clave para ingresar.");
        return false;
    }
    else
        return true;
}

function checkTextAreaMaxLength(textBox, e, length) {

    var mLen = textBox["MaxLength"];
    if (null == mLen)
        mLen = length;

    var maxLength = parseInt(mLen);
    if (!checkSpecialKeys(e)) {
        if (textBox.value.length > maxLength - 1) {
            if (window.event)//IE
                e.returnValue = false;
            else//Firefox
                e.preventDefault();
        }
    }
}
function checkSpecialKeys(e) {
    if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
        return false;
    else
        return true;
}

