$(document).ready(function() {
	
	//Login Behaviour
	
	$(".ingreso").hide();
	
	$("#login ul > li:first-child, #login ul > li:nth-child(3)").on('click', function (e) {
		var login = $(this);
		//alert($(this).attr("class"));
		
		var activeTab = "#login"+login.attr("id");
		
		if(login.attr("class")!="current"){
			$("#login ul > li").removeClass("current");
			//alert($(activeTab).attr("id"));
			//alert("es diferente");
			$(".ingreso").slideUp();
			$(activeTab).slideDown();
			login.addClass("current");
			return false;
		}
		else {
			//alert("es igual");
			//alert($(activeTab).attr("id"));
			$(activeTab).slideUp("slow");
			$("#login ul > li").removeClass("current");
		}
	});

	
	// Submenú Behaviour
	var menu = $("nav");
	$(overlaynav).css("display", "none");	
	$("header").css("overflow","hidden").addClass("close");
	//Mostrar Overlay
	
	
		
	//mostrar submenu respectivo
	$(".dropdown").hover(function(){
		$(this).addClass("mouseover");
		var submenu = $(this).children().attr('href');
		$(submenu).show();
		$("header").css("overflow","visible").addClass("open");
		
		if($(this).children().attr('href') == "#banco"){
			//alert("soy banco");
			$(this).children().children().children().next().show();
			
		}
		
	},
	function(){
		$(this).removeClass("mouseover");
		var submenu = $(this).children().attr('href');
		$(submenu).hide();
		
	});
	
	//mostrar productos - servicios
	var cat = $(".subnav.cat").children();
	$(".subnav.pag").hide();
	
	$(cat).hover(function(){
		
		$(this).addClass("current");
		$(this).parent().addClass("current").css("border-right","1px solid #a5a6a6");
		$(this).children().next().show();
	},
	function(){
		$(this).removeClass("current");
		$(this).parent().css("border-right","none")
		$(this).children().next().hide();
	});
	
	//Increase header height
	
		
	
	
	
});

$(document).mouseup(function (e)
{
    var container = $("#login");

    if (!container.is(e.target) // if the target of the click isn't the container...
        && container.has(e.target).length === 0) // ... nor a descendant of the container
    {
		//alert($(container).attr("id"));
        $(".ingreso").slideUp();
    }
});