$(document).ready(function(){
	/* This code is executed after the DOM has been completely loaded */

	/* Changing thedefault easing effect - will affect the slideUp/slideDown methods: */
	$.easing.def = "jswing";
	
	/*Opening the first drop down section once page is loaded*/
	$('li.menu:first-child .accordion_content').slideToggle('slow');
	
	/* Binding a click event handler to the links: */
	$('li.button a').click(function(e){

		/* Finding the drop down list that corresponds to the current section: */
		var accordion_content = $(this).parent().next();
		
		//alert($(this).parent().next().html());
		
		/* Closing all other drop down sections, except the current one */
		$('.accordion_content').not(accordion_content).slideUp('slow');
		accordion_content.slideToggle('slow');
		
		/* Preventing the default event (which would be to navigate the browser to the link's address) */
		e.preventDefault();
	})
	
});