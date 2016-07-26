// ==UserScript==
// @name        PlayerEvaluator
// @namespace   CharazayPlus
// @description Charazay Plus Player Evaluator
// @version     1.2.3
// @grant       none
// @grant 		  GM_xmlhttpRequest
// @include     http://www.charazay.com/index.php?act=player&code=1&id=*
// @include     http://www.charazay.com/?act=player&code=1&id=*
// @include     http://www.charazay.com/index.php?act=youthplayer&code=1&id=*
// @include     http://www.charazay.com/?act=youthplayer&code=1&id=*
// @require 	  https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js
// ==/UserScript==


///////////////////////////////////////////////////////////////////////////////
// a function that loads jQuery and 
// calls a callback function when jQuery has finished loading
// http://stackoverflow.com/questions/2246901/how-can-i-use-jquery-in-greasemonkey-scripts-in-google-chrome#3550261
///////////////////////////////////////////////////////////////////////////////
/* function addJQuery(callback) {
  var script = document.createElement("script");
  //script.setAttribute("src", "//ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js");
  script.setAttribute("src", "https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js");
  script.addEventListener('load', function() {
    var script = document.createElement("script");
    script.textContent = "window.jQ=jQuery.noConflict(true);(" + callback.toString() + ")();";
    document.body.appendChild(script);
  }, false);
  document.body.appendChild(script);
} */

this.$ = this.jQuery = jQuery.noConflict(true);

///////////////////////////////////////////////////////////////////////////////
// Base64: tuple definition
///////////////////////////////////////////////////////////////////////////////
var tuples = [
{ name: "Age", 			ntr: 3 , ntd: 2}  ,   //.mc-ls > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(5) > td:nth-child(2)
{ name: "Height", 		ntr: 4 , ntd: 2}  ,   //.mc-ls > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(6) > td:nth-child(2)
{ name: "Weight", 		ntr: 4 , ntd: 5}  , 
{ name: "Form", 		ntr: 2 , ntd: 1}  ,   //.mc-ls > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(4) > td:nth-child(1)
{ name: "Fatigue", 		ntr: 3 , ntd: 5}  , 
{ name: "Defence", 		ntr: 7 , ntd: 2}  , 
{ name: "FreeThrows", 	ntr: 7 , ntd: 5}  , 
{ name: "TwoPoint", 	ntr: 8 , ntd: 2}  , 
{ name: "ThreePoint", 	ntr: 8 , ntd: 5}  , 
{ name: "Dribbling", 	ntr: 9 , ntd: 2}  , 
{ name: "Passing", 		ntr: 9 , ntd: 5}  , 
{ name: "Speed", 		ntr:10 , ntd: 2}  , 
{ name: "Footwork", 	ntr:10 , ntd: 5}  , 
{ name: "Rebounds", 	ntr:11 , ntd: 2}  , 
{ name: "Experience", 	ntr:11 , ntd: 5}  
//
//{ name: "SkillsIndex", 	ntr: 5 , ntd: 2}  , 
//{ name: "Salary", 		ntr: 5 , ntd: 5}  , 
];

var TUPLES_LENGTH = tuples.length;

///////////////////////////////////////////////////////////////////////////////
//console.info("the guts of this userscript");
// if no skills available => nothing ...
// <table style="margin: 0 auto;" cellpadding="0" cellspacing="0" width="80%">
///////////////////////////////////////////////////////////////////////////////


var DATA_LENGTH = $('table[width="80%"] tr').length;
console.log ('DATA_LENGTH', DATA_LENGTH);

if (DATA_LENGTH == 11 || DATA_LENGTH == 13) {

var rcs =  $("<div/>").attr ({class: "rc-s", id: "cpe"});
$(rcs).append( $("<div/>").attr ("class", "rc-t").text("Charazay+ Player Evaluator") );

// http://stackoverflow.com/questions/18190148/create-span-tag-and-insert-with-jquery
$(rcs).append($('<table />').html('<tbody><tr><td>Position</td><td id="cpePosition"></td></tr><tr><td>ValueIndex</td><td id="cpeValueIndex"></td></tr><tr><td>TotalScore</td><td id="cpeTotalScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgTotalScore"></td></tr><tr><td>DefensiveScore</td><td id="cpeDefensiveScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgDefensiveScore"></td></tr><tr><td>OffensiveScore</td><td id="cpeOffensiveScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgOffensiveScore"></td></tr><tr><td>OffensiveAbility</td><td id="cpeOffensiveAbility"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgOffensiveScore"></td></tr><tr><td>ShootingScore</td><td id="cpeShootingScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgShootingScore"></td></tr><tr><td>TransferMarketValue</td><td id="cpeTransferMarketValue"></td><td>M</td></tr></tbody>'));	

$(rcs).append( $("<p/>").attr ("id", "pselect") );
 
  // bookmark button
$(rcs).append($("<input/>").attr({
    id: "bukmark",
    style: "display: inline-block",
    class: "inputSubmit",
    type: "submit",
    value: "Bookmark"
  }));
  $(rcs).append($("<i/>").attr("id", "imark").text(''));

  // view bookamrks
  $(rcs).append( $("<a/>").attr({ id: "vwbkmrk", href: "#" }).text('View bookmarks') );

  // evaluate
var b64s = Base64Skills();
var b64 = Base64ReplaceCharacters(b64s); 
ajax_CharazayPlusWebApi_GetEvaluation(b64, 1, "");

  // yo
$('#rc').prepend(rcs);

  // after evaluation
  // position combo 
$("#pselect").html('<u>As</u>: <select id="selected_position" class="form_small"><option value="PG">Point Guard</option><option value="SG">Shooting Guard</option><option value="SF">Small Forward</option><option value="PF">Power Forward</option><option value="C">Center</option></select>');
  $('#selected_position').change(function () { ajax_CharazayPlusWebApi_GetEvaluation(b64, 2, $(this).val()); });    

  // CLICK EVENT FOR BOOKMARK BUTTON
$('#bukmark').click(ajax_CharazayPlusWebApi_PostBookmark);
   
  // click event for bookmark view
  $('#vwbkmrk').click(onViewBookmarks);
}

///////////////////////////////////////////////////////////////////////////////
// ajax_CharazayPlusWebApi_PostBookmark
//https://weblog.west-wind.com/posts/2012/May/08/Passing-multiple-POST-parameters-to-Web-API-Controller-Methods
///////////////////////////////////////////////////////////////////////////////
function ajax_CharazayPlusWebApi_PostBookmark() {
    var intPrice = parseInt($("#new_bid").attr("value").replace(/\./g,''));
    var bookmarkData = {
      Position: $('#cpePosition').text(),
      ValueIndex: parseFloat($('#cpeValueIndex').text()),
      TotalScore: parseFloat($('#cpeTotalScore').text()),
      DefensiveScore: parseFloat($('#cpeDefensiveScore').text()),
      OffensiveScore: parseFloat($('#cpeOffensiveScore').text()),
      OffensiveAbility: parseFloat($('#cpeOffensiveAbility').text()),
      ShootingScore: parseFloat($('#cpeShootingScore').text()),
      TransferMarketValue: parseFloat($('#cpeTransferMarketValue').text()),

      CharazayId: parseInt($(".number_id").text().replace('(', '').replace(')', '')),
      FullName: $("#pagetitle a:nth-child(1)").text(),
      When: $("#now").text(),
      Deadline: $("#deadline").text(),
      Price: intPrice/1000000
    };
    console.log(bookmarkData);

    
    $.ajax(
    {
      url: "http://localhost/CharazayPlus.WebApi/bookmark",
      type: "POST",
      data: bookmarkData,
      success: function (result) {
        console.info(result);
        $('#imark').html('&#10004;')
      },
      error: function (xhr, status, p3, p4) {
        var err = "Error " + " " + status + " " + p3;
        if (xhr.responseText && xhr.responseText[0] == "{")
          err = JSON.parse(xhr.responseText).message;
        alert(err);
      }
    });
    
  }


///////////////////////////////////////////////////////////////////////////////
// calls a rest service at
// https://spring.io/guides/gs/consuming-rest-jquery/
///////////////////////////////////////////////////////////////////////////////
function ajaxCallHelloSvc(){
	//alert("Getting the Data");
    $.ajax({
		//type: "GET",
        //dataType: "json",
        url: "http://rest-service.guides.spring.io/greeting",
		success: function(data){        
                console.log(data);
		}
    }).then(function(data) {
       $('#greeting-id').append(data.id);
       $('#greeting-content').append(data.content);
    });
}

///////////////////////////////////////////////////////////////////////////////
// calls player evaluator service
// http://localhost/CharazayPlus.WebApi/player/facets/top/D890BCUFBAUHAgQFCQcB
// http://localhost/CharazayPlus.WebApi/player/facets/Htp+BAEVBwMFBgUJGg0Z1
// http://172.18.19.244:8080/player/facets/top/D890BCUFBAUHAgQFCQcB
// Accept:"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
// Cross-Origin Request Blocked: The Same Origin Policy disallows reading the remote resource at http://172.18.19.244:8080/api/values. (Reason: CORS header 'Access-Control-Allow-Origin' missing).
// https://www.sitepoint.com/jsonp-examples/
// http://stackoverflow.com/questions/24371734/firefox-cors-request-giving-cross-origin-request-blocked-despite-headers
// http://stackoverflow.com/questions/24663126/cross-origin-request-blocked#24663331
// http://api.jquery.com/jQuery.getJSON/
//  Due to browser security restrictions, most "Ajax" requests are subject to the same origin policy; the request can not successfully retrieve data from a different domain, subdomain, port, or protocol.
// Script and JSONP requests are not subject to the same origin policy restrictions.
// Get-Project CharazayPlus.WebApi | Install-Package Microsoft.AspNet.WebApi.Cors -Verbose
// http://enable-cors.org/server_aspnet.html
///////////////////////////////////////////////////////////////////////////////
function ajax_CharazayPlusWebApi_GetEvaluation(b64, expression, pos){
	
	//contentType: 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8'
	var surl = "";

	switch(expression) {
    case 1:
        //var surl = "http://172.18.19.244:8080/player/facets/top/".concat(b64s);
        // http://localhost/CharazayPlus.WebApi/player/facets/top?base64StringState=Gqw/BAQXCAUDCwkXBgYR
        surl = "http://localhost/CharazayPlus.WebApi/player/facets/top/".concat(b64);
        break;
    case 2:
        //http://localhost/CharazayPlus.WebApi/player/c/F85nBgQOBwUEBwUNFwYL
        //http://localhost/CharazayPlus.WebApi/player/sg?base64StringState=Gqw/BAQXCAUDCwkXBgYR
		surl = "http://localhost/CharazayPlus.WebApi/player/".concat(pos).concat("/").concat(b64);
        break;
	case 3:
	    //http://localhost/CharazayPlus.WebApi/player/aggregate/F85nBgQOBwUEBwUNFwYL
	    //http://localhost/CharazayPlus.WebApi/player/aggregate/top?base64StringState=Gqw/BAQXCAUDCwkXBgYR
		surl = "http://localhost/CharazayPlus.WebApi/player/aggregate/top/".concat(b64);
		break;	
	case 4:		
        surl = "http://localhost/CharazayPlus.WebApi/player/facets/".concat(b64);
        break;
	case 5:		
        surl = "http://localhost/CharazayPlus.WebApi/player/aggregate/".concat(b64);
		break;	
    default:
        ;
	}	
	console.log("surl", surl);
	
    $.getJSON(surl, function (data) { console.log(data); })
	.done(function(data) {
		$('#cpePosition').html( $("<strong/>").attr ({align: "right"}).text(data.Position) );
		$('#cpeValueIndex').html( $("<strong/>").text(data.ValueIndex) );
		$("#cpeTotalScore").html(data.TotalScore);
		jqProgress ("#imgTotalScore", data.TotalScore);
		$("#cpeDefensiveScore").html(data.DefensiveScore);
		jqProgress ("#imgDefensiveScore", data.DefensiveScore);
		$("#cpeOffensiveScore").html(data.OffensiveScore);
		jqProgress ("#imgOffensiveScore", data.OffensiveScore);
		$("#cpeOffensiveAbility").html(data.OffensiveAbility);
		//jqProgress ("#imgOffensiveScore", data.OffensiveAbility);
		$("#cpeShootingScore").html(data.ShootingScore);
		//jqProgress ("#imgShootingScore", data.ShootingScore);
		$("#cpeTransferMarketValue").html($("<strong/>").text(data.TransferMarketValue) );
		//http://stackoverflow.com/questions/16627203/how-to-set-the-selected-option-of-a-select-list-by-value-not-by-selectedindex-us#16627236
		var jqs = "#selected_position option[value='".concat(data.Position).concat("']");   
		$(jqs).prop('selected', true);
  $('#imark').text('');
    })
	.fail(function(jqxhr, textStatus, error) { 
		console.log( surl, " getJSON failed ", jqxhr.statusText, "readyState:", jqxhr.readyState, "status:", textStatus, "error:", error);
	});	
	
	/*
	$.ajax({
		url: "http://172.18.19.244:8080/player/test2"
		, type: "GET"
		, dataType: "JSON"
		//, data: { url: "http://pandodaily.com/2013/03/26/y-combinator-demo-day-2013-still-looking-for- the-next-airbnb-or-dropbox/"}
		, success: function (data) { console.log(data); }
	}).done(function(json) {
        $('#greeting-id').append(json.Success);
		$('#greeting-content').append(json.Message);
	}).fail(function(jqxhr, textStatus, error){
        var err = textStatus + ', ' + error;
        console.log("Request Failed: " + err);
	});
	*/
}

///////////////////////////////////////////////////////////////////////////////
// add/replace existing a progress bar to a parent element
///////////////////////////////////////////////////////////////////////////////
function jqProgress(imgId, value) {		
	//
	var normalizedValue = (value/30*100).toFixed(2);
	var percent=normalizedValue.toString().concat(" %");
	var dscr = value.toString().concat("/30 ").concat(percent);
	var px = 0.79*normalizedValue-79;
	var style= "background-position: ".concat(px.toString()).concat("px 0pt;");
    
	$(imgId).html($("<img/>").attr({
		"src": "images/FAPercent_back.gif",
		"alt": dscr,
		"title": dscr,
		"class": "FAPercent",
		"style": style
	}));
}

///////////////////////////////////////////////////////////////////////////////
// Base64Skills: convert skills array to base 64
///////////////////////////////////////////////////////////////////////////////
function Base64Skills() {
	var trOffset = 0;
	if ( $('.mc-ls > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(1)').attr("class") == "center highlight")
		trOffset = 2;
  console.log("trOffset: ", trOffset);
		
	// From a length
	var bytes = new Uint8Array(15);

	for (var i=0; i<TUPLES_LENGTH; i++) {
	// $('#idHeight').append($('.mc-ls table:nth-child(2) tbody:nth-child(1) tr:nth-child(4) td:nth-child(2)').text());
	//".mc-ls table:nth-child(2) tbody:nth-child(1)  tr:nth-child(NTR) td:nth-child(NTD)", 
	var selector = ".mc-ls table:nth-child(2) tbody:nth-child(1) ";
	selector = selector.concat("tr:nth-child(");
    selector = selector.concat((TUPLES[i].ntr + trOffset).toString());
	selector = selector.concat (") td:nth-child(");
    selector = selector.concat(TUPLES[i].ntd.toString());
	selector = selector.concat(")");
	// append values to labels jquery id selector
	//var id = "#id".concat(tuples[i].name);
	//$(id).append($(selector).text());	
	//console.log (selector);
	
	if (i == 3) {
		bytes[i] = parseInt ($(selector).text().replace("Form: ",""));
	} else if (i == 4) {
		// .mc-ls > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(5) > img:nth-child(1)
		selector = selector.concat(" img:nth-child(1)");
		bytes[i] = parseInt ($(selector).attr("title"));
	} else {
		bytes[i] = parseInt ($(selector).text());
	}
}    
  console.log (bytes);

// byte array to base 64 string
var b64s = btoa(String.fromCharCode.apply(null, bytes));
console.log ("Base64", b64s);

return b64s;
}

///////////////////////////////////////////////////////////////////////////////
// for some reason webapi discards the url encoding sometimes, going back to replacing problematic characters
    // var postfix = "";
	// if (b64s.indexOf("/") < 0 && b64s.indexOf("+") < 0) postfix = "/".concat(b64s);
	// else 												postfix = "?base64StringState=".concat(b64s);
	//RIGHT WAY TO DO THIS IS WITH URL ENCODING
	// +, /, = in base64 will get url encoded
	// on webapi side of things use HttpUtility.UrlDecode
	//var postfix = encodeURIComponent(b64s);
	//console.log("postfix", postfix);
///////////////////////////////////////////////////////////////////////////////
function Base64ReplaceCharacters(b64s) {
	var s = b64s.replace('/','~');
	s = s.replace ('+','_');
	s = s.replace('=', '|');
	console.log('Base64ReplaceCharacters',s);
	return s;	
}

///////////////////////////////////////////////////////////////////////////////
//$('form[name="bid"]').before ("<p>http://api.jquery.com/before/</p>");
///////////////////////////////////////////////////////////////////////////////
function onViewBookmarks () {    
	//console.log ('onViewBookmarks ()', $('.mc-ls .mc-t').length, $('.mc-ls table[width="100%"]').length);
    
	$('.mc-ls .mc-t').remove(); 
    $('.mc-ls table[width="100%"]').remove();
		
	$('.mc-ls').append ( 
	  $("<div/>").attr("class","tg-wrap")
	  .html('<table style="margin: 0 auto;" cellpadding="0" cellspacing="0" width="80%" id="tblbkmrk" class="tg"></table>')
	); 
	
	// header row
	var tr = $('<tr/>');
	for (var i = 0; i < BKHDR_LENGTH; i++) {
		console.log(i, BKHDR[i].a, BKHDR[i].b);
		 var abbr = $('<abbr/>').attr("title", BKHDR[i].a).text(BKHDR[i].b);
		 var th = $('<th/>').attr("class","tg-yw4l");		 
		 $(th).append ( abbr );
		 $(tr).append ( th );	     	
	} 
	$('#tblbkmrk').append (tr);
	
  // http://localhost/CharazayPlus.WebApi/bookmarks/0/5
	$.getJSON('http://localhost/CharazayPlus.WebApi/bookmarks/0/5', function (data) {
    // key is the array index, val is the actual object
	  $.each(data, function (key, val) {
	    var tr = $('<tr/>');

	    $(tr).append($('<td/>').text(val.Position));
	    $(tr).append($('<td/>').text(val.ValueIndex));
	    $(tr).append($('<td/>').text(val.TotalScore));
	    $(tr).append($('<td/>').text(val.DefensiveScore));
	    $(tr).append($('<td/>').text(val.OffensiveScore));
	    $(tr).append($('<td/>').text(val.OffensiveAbility));
	    $(tr).append($('<td/>').text(val.ShootingScore));
	    $(tr).append($('<td/>').text(val.TransferMarketValue));
	    $(tr).append($('<td/>').text(val.CharazayId));
	    $(tr).append($('<td/>').text(val.FullName));
	    $(tr).append($('<td/>').text(val.When));
	    $(tr).append($('<td/>').text(val.Deadline));
	    $(tr).append($('<td/>').text(val.Price));	    

	    $('#tblbkmrk').append(tr);
	  });
	});
}
