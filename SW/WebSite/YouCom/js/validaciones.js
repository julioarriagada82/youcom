//Contiene las funciones javascript especialmente desarrolladas para la aplicacion


function validaFormulario(form) {

    if (Empty(form.nombre.value)) // Pregunta si el campo nombre viene vacio
    {
        alert('Ingrese su nombre');  // Si viene vacio envia un alerta
        form.nombre.focus(); // Pone el cursor en el campo validado
        return false; // Detine el envio del formulario
    }

    if (!isRut(form.rut.value)) // Pregunta si el campo viene vacio y ademas que sea un RUT válido
    {
        alert('Ingrese su RUT')	 // Si viene vacio o no es RUT válido envia un alerta
        form.rut.focus(); // Pone el cursor en el campo validado
        form.rut.select(); // Selecciona el texto ingresado en el campo
        return false; // Detine el envio del formulario
    }

    if (!isRut(form.rut2.value + '-' + form.digito.value)) // Pregunta si el campo rut2 más el campo digito forman un RUT valido
    {
        alert('Ingrese su RUT')	 // Si viene alguno vacio o no forman un RUT válido envia un alerta
        form.rut2.focus(); // Pone el cursor en el campo validado
        form.rut2.select(); // Selecciona el texto ingresado en el campo
        return false; // Detine el envio del formulario
    }

    if (!isInteger(form.fono.value)) // Valida que el campo sea númerico
    {
        alert('Ingrese su telefono') // Si viene vacio o con letras envia un alerta
        form.fono.focus(); // Pone el cursor en el campo validado
        form.fono.select(); // Selecciona el texto ingresado en el campo
        return false; // Detine el envio del formulario
    }

    if (!isMail(form.mail.value)) // Valida que no venga vacio y sea un e-mail válido 
    {
        alert('Ingrese su e-mail')  // Si no es valido envia un alerta
        form.mail.focus(); // Pone el cursor en el campo validado
        form.mail.select(); // Selecciona el texto ingresado en el campo
        return false; // Detine el envio del formulario
    }

    if (!isURL(form.url.value)) // Valida que no venga vacio y sea una URL válida 
    {
        alert('Ingrese una URL valido')  // Si no es valido envia un alerta
        form.url.focus(); // Pone el cursor en el campo validado
        form.url.select(); // Selecciona el texto ingresado en el campo
        return false; // Detine el envio del formulario
    }


    if (!isDate(form.fecha.value)) // Valida que no venga vacio y sea una fecha válida en formato dd/mm/aaaa
    {
        alert('Ingrese una fecha valida en formato dd/mm/aaaa')  // Si no es valido envia un alerta
        form.fecha.focus(); // Pone el cursor en el campo validado
        form.fecha.select(); // Selecciona el texto ingresado en el campo
        return false; // Detine el envio del formulario
    }

    if (!isAlpha(form.alfabetico.value)) // Valida que no venga vacio y contenga solo caracteres alfabeticos
    {
        alert('Ingrese solo caracteres alfabeticos')  // Si no es valido envia un alerta
        form.alfabetico.focus(); // Pone el cursor en el campo validado
        form.alfabetico.select(); // Selecciona el texto ingresado en el campo
        return false; // Detine el envio del formulario
    }


    sw = 0;
    for (i = 0; i < form.radiobutton.length && sw == 0; i++) {
        if (form.radiobutton[i].checked) sw = 1;
    }
    if (!sw) {
        alert('Seleccione una opcion')
        form.radiobutton[0].focus();
        return false;
    }


    if (!isSelected(form.ciudad)) // Valida que se seleccione una opcion del pulldown
    {
        alert('Seleccione una ciudad') // Si no es valido envia un alerta
        form.ciudad.focus(); // Pone el cursor en el campo validado
        return false;
    }

    if (!isSelected(form.comuna)) // Valida que se seleccione una opcion con un value distinto a '0'
    {
        alert('Seleccione una comuna') // Si no es valido envia un alerta
        form.comuna.focus(); // Pone el cursor en el campo validado
        return false; // Detine el envio del formulario
    }


    return; // Si pasa todas las validaciones el formulario se envia.

}


function altrim(s) {
    return s.replace(/^\s+/, "");
}
function artrim(s) {
    return s.replace(/\s+$/, "");
}
function quita(s) {
    return artrim(altrim(s));
}
function formateaRut(pvarInput, pvarFormato) {
    if (pvarInput.value == '') {
        return;
    }
    else {

        var wvarValor = quita(pvarInput.value);

        wvarValor = wvarValor.toUpperCase();
        var wvarValorFormateado = "";
        var wvarIndex = 0;

        while (wvarValor.indexOf(".") > -1) {
            wvarValor = wvarValor.replace(".", "");
        }

        while (wvarValor.indexOf("-") > -1) {
            wvarValor = wvarValor.replace("-", "");
        }

        while (wvarValor.charAt(0) == '0' && wvarValor.length > 1) {
            wvarValor = wvarValor.replace("0", "");
        }

        wvarIndex = wvarValor.length - 1;
        for (var i = pvarFormato.length - 1; i >= 0; i--) {
            if (pvarFormato.charAt(i) == "X") {
                if (wvarIndex < 0) {
                    wvarValorFormateado = "0" + wvarValorFormateado;
                }
                else {
                    wvarValorFormateado = wvarValor.charAt(wvarIndex) + wvarValorFormateado;
                    wvarIndex--;
                }
            }
            else {
                wvarValorFormateado = pvarFormato.charAt(i) + wvarValorFormateado;
            }
        }

        if (wvarIndex >= 0) {
            wvarValorFormateado = wvarValor.substring(0, wvarIndex + 1) + wvarValorFormateado;
        }

        while ((wvarValorFormateado.charAt(0) == '0' || wvarValorFormateado.charAt(0) == '.') && wvarValorFormateado.length > 1) {
            if (wvarValorFormateado.charAt(0) == '0') {
                wvarValorFormateado = wvarValorFormateado.replace("0", "");
            }
            else {
                wvarValorFormateado = wvarValorFormateado.replace(".", "");
            }
        }
        pvarInput.value = wvarValorFormateado;
    }
}

function _isModule11(value) {
    var pattern = new RegExp("^(([0-9]{1,2}\\.[0-9]{3}\\.[0-9]{3})|([0-9]{7,8}))\\-([0-9K])$", "i");
    var pattern_point = new RegExp("\\.", "g");
    var pattern_dv = new RegExp("([0-9]+)\\-([0-9K])", "i");
    value = Trim(value);
    if (value.match(pattern)) {
        value = value.replace(pattern_point, "");
        if (value.match(pattern_dv)) {
            number = new String(RegExp.$1);
            dv = new String(RegExp.$2);
            sum = 0;
            mul = 2;
            for (i = number.length - 1; i >= 0; i--) {
                sum += number.charAt(i) * mul;
                mul == 7 ? mul = 2 : mul++;
            }
            rest = sum % 11;
            if (rest == 1) dvr = 'K';
            else if (rest == 0) dvr = '0';
            else {
                dvr = 11 - rest;
            }
            if (dvr == dv.toUpperCase()) {

                return true;
            }
            else {
                alert('Ingrese Rut valido por favor');
                return false;
            }

        }
    }
    else {
        alert('Ingrese Rut valido por favor');
        return false;
    }
}

// LTrim: Quita espacios en blanco a la izquerda de una cadena
function LTrim(value) {
    var pattern = new RegExp("^\\s+", "g")
    return value.replace(pattern, "");
}

// RTrim: Quita espacios en blanco a la derecha de una cadena
function RTrim(value) {
    var pattern = new RegExp("\\s+$", "g")
    return value.replace(pattern, "");
}

// Trim: Quita espacios en blanco a la derecha y a la izquierda de una cadena
function Trim(value) {
    return RTrim(LTrim(value));
}

function EsRutPasajero(source, arguments) {
    if (arguments.Value == '') arguments.IsValid = false;
    arguments.IsValid = _validar_rut_nuevo(arguments.Value);

}

function KeyCheck(e) {
    if (e.keyCode == 60)
        e.keyCode = 0
}

function EsFechaValida(source, arguments) {
    if (arguments.Value == '') arguments.IsValid = false;
    arguments.IsValid = _isDateValida(arguments.Value);
}

function _isDateValida(valor) {

    var mayor;

    var dia = (new Date()).getday();
    var mes = (new Date()).getmonth();
    var anio = (new Date()).getFullYear();


    var vdia = valor.substr(0, 2);
    var vmes = valor.substr(3, 2);
    var vanio = valor.substr(6, 4);

    alert(vdia);
    alert(vmes);
    alert(vanio);
    if (anio < vanio) { mayor = 1; }
    if (mes < vmes && anio == vanio) { mayor = 1; }
    if (dia < vdia && mes == vmes && anio == vanio) { mayor = 1; }
    if (mayor == 1) {
        return false;
    }
}


//nuevo
function validar_rut_nuevo(value) {
    var rut = value; suma = 0; mul = 2; i = 0;

    for (i = rut.length - 3; i >= 0; i--) {
        suma = suma + parseInt(rut.charAt(i)) * mul;
        mul = mul == 7 ? 2 : mul + 1;
    }

    var dvr = '' + (11 - suma % 11);
    if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

    if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr)
        arguments.IsValid = false;
    else
        arguments.IsValid = true;
}

function validarRut(source, arguments) {
    if (arguments.Value == 'Rut')
        arguments.IsValid = false;
    else
        if (!isRut(arguments.Value))
            arguments.IsValid = false;
        else
            arguments.IsValid = true;
}

// isModule11: devuelve verdadero si value es valido para el modulo 11
function isRut(value) {
    var pattern = new RegExp("^(([0-9]{1,2}\\.[0-9]{3}\\.[0-9]{3})|([0-9]{7,8}))\\-([0-9K])$", "i");
    var pattern_point = new RegExp("\\.", "g");
    var pattern_dv = new RegExp("([0-9]+)\\-([0-9K])", "i");

    value = Trim(value);
    if (value.match(pattern)) {
        value = value.replace(pattern_point, "");
        if (value.match(pattern_dv)) {
            number = new String(RegExp.$1);
            dv = new String(RegExp.$2);
            sum = 0;
            mul = 2;
            for (i = number.length - 1; i >= 0; i--) {
                sum += number.charAt(i) * mul;
                mul == 7 ? mul = 2 : mul++;
            }
            rest = sum % 11;
            if (rest == 1) dvr = 'K';
            else if (rest == 0) dvr = '0';
            else {
                dvr = 11 - rest;
            }
            return dvr == dv.toUpperCase();

        }
    }
}

function GetNumeroEntero(str) {
    if (str != 13) {
        if (str < 48 || str > 57) {
            event.returnValue = false;
        }
    }
}

function formatearNumeroToMiles(objeto) {
    var nNmb = reemplazarEnCadena(objeto.value, ".", "");
    var sRes = "";
    if (nNmb == '0') {
        sRes = "0";
    } else {
        //var sRes = "";
        for (var j, i = nNmb.length - 1, j = 0; i >= 0; i--, j++) {
            sRes = nNmb.charAt(i) + ((j > 0) && (j % 3 == 0) ? "." : "") + sRes;
        }
    }
    document.getElementById(objeto.id).value = sRes;
}

function reemplazarEnCadena(cadena, string_a_reemplazar, string_nuevo) {
    cadena = cadena.split(string_a_reemplazar);
    cadena = cadena.join(string_nuevo);
    return cadena;
}
