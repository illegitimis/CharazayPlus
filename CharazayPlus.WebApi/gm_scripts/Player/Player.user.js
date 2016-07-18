// ==UserScript==
// @name        PlayerEvaluator
// @namespace   CharazayPlus
// @description Charazay Plus Player Evaluator
// @version     1.1
// @grant       none
// @grant 		  GM_xmlhttpRequest
// @include     http://www.charazay.com/index.php?act=player&code=1&id=*
// @include     http://www.charazay.com/?act=player&code=1&id=*
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

//'head > style:nth-child(26)'
/* <style type="text/css">.ita {font-style:italic;}</style> */
console.log ("No styles in head", $('head > style').length);


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
///////////////////////////////////////////////////////////////////////////////

var rcs =  $("<div/>").attr ({class: "rc-s", id: "cpe"});
var rct = $("<div/>").attr ("class", "rc-t").text("Charazay+ Player Evaluator");
$(rcs).append(rct);
$(rcs).append($("<ul/>").attr ({id: "ulimg"}));

//.concat(i.toString())
//$("#ulimg").append($("<li/>").attr ({ class: "imgli", id: "imgli" }));		
//$("#ulimg").append($("<li>test</li>");		
/* var percents = [0,10,20,30,40,50,60,70,80,90,100];
for(var i=0; i<11 ; i++) {
	//addULProgressBar (ul, percents[i]);
	var li =  $("<li/>").attr ({ class: "imgli", id: "imgli".concat(i.toString()) });
    $('#ulimg').append(li);		
} */

//addParagraph(rcs,"greeting-id","The ID is ");
//addParagraph(rcs,"greeting-content","The content is ");
// var JSON_CATEGORIES = [,"Position","ValueIndex","TotalScore","DefensiveScore","OffensiveScore","OffensiveAbility","ShootingScore","TransferMarketValue"];
// for (var c=0; c<JSON_CATEGORIES.length; c++) {
	// $(rcs).append($('<p />').attr ("id", "cpe".concat(JSON_CATEGORIES[c])).text(JSON_CATEGORIES[c]));	
// }

$(rcs).append($('<table />').html('<tbody><tr><td>Position</td><td id="cpePosition"></td></tr><tr><td>ValueIndex</td><td id="cpeValueIndex"></td></tr><tr><td>TotalScore</td><td id="cpeTotalScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgTotalScore"></td></tr><tr><td>DefensiveScore</td><td id="cpeDefensiveScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgDefensiveScore"></td></tr><tr><td>OffensiveScore</td><td id="cpeOffensiveScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgOffensiveScore"></td></tr><tr><td>OffensiveAbility</td><td id="cpeOffensiveAbility"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgOffensiveScore"></td></tr><tr><td>ShootingScore</td><td id="cpeShootingScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgShootingScore"></td></tr><tr><td>TransferMarketValue</td><td id="cpeTransferMarketValue"></td><td>M</td></tr></tbody>'));	

var b64s = Base64Skills();
ajaxCallCharazayPlusWebApi(b64s);

//ajaxCallHelloSvc();

$('#rc').prepend(rcs);

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
function ajaxCallCharazayPlusWebApi(b64s){
	
	//contentType: 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8'
	//var surl = "http://localhost/CharazayPlus.WebApi/player/facets/top/".concat(b64s);
	var surl = "http://172.18.19.244:8080/player/facets/top/".concat(b64s);
    $.getJSON(surl, function (data) { console.log(data); })
	.done(function(data) {
		$('#cpePosition').append( $("<strong/>").attr ({align: "right"}).text(data.Position) );
		$('#cpeValueIndex').append( $("<strong/>").text(data.ValueIndex) );
		$("#cpeTotalScore").append(data.TotalScore);
		jqProgress ("#imgTotalScore", data.TotalScore);
		$("#cpeDefensiveScore").append(data.DefensiveScore);
		jqProgress ("#imgDefensiveScore", data.DefensiveScore);
		$("#cpeOffensiveScore").append(data.OffensiveScore);
		jqProgress ("#imgOffensiveScore", data.OffensiveScore);
		$("#cpeOffensiveAbility").append(data.OffensiveAbility);
		//jqProgress ("#imgOffensiveScore", data.OffensiveAbility);
		$("#cpeShootingScore").append(data.ShootingScore);
		//jqProgress ("#imgShootingScore", data.ShootingScore);
		$("#cpeTransferMarketValue").append($("<strong/>").text(data.TransferMarketValue) );
    })
	.fail(function(jqxhr, textStatus, error) { 
		console.log( surl, " getJSON failed ", jqxhr.statusText, "readyState:", jqxhr.readyState, "status:", textStatus, "error:", error);
	});
	
	/*
	//$.getJSON("https://api.github.com/users/jeresig?callback=?",function(json){ console.log(json); });
	$.getJSON(
		"http://172.18.19.244:8080/player/test1", function (data) { 
		console.log(data); 
	})
	.done(function(data) {
       $('#greeting-id').append(data.Success);
       $('#greeting-content').append(data.Message);
    })
	.fail(function(jqxhr, textStatus, error) { 
		console.log( "getJSON failed", "jqxhr:", jqxhr.statusText, "readyState:", jqxhr.readyState, "status:", textStatus, "error:", error);
	})
    .always(function() { console.log( "complete" ); });*/
	
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
// adds a li with progress bar to a ul
///////////////////////////////////////////////////////////////////////////////
function addULProgressBar (ul, value)
{
var li = document.createElement("li");
addProgressBar(li, value);
ul.appendChild(li);	
}

///////////////////////////////////////////////////////////////////////////////
// add a progress bar to a parent element
///////////////////////////////////////////////////////////////////////////////
function addProgressBar(parentElem, value) {
	var percent=value.toString().concat(" %");
	var px = 0.79*value-79;
	var style= "background-position: ".concat(px.toString()).concat("px 0pt;");
  //<img ="" alt="16 %" title="16 %" ="" style="background-position: -65.2px 0pt;">
  
  var img = document.createElement("img");
  img.setAttribute("src", "images/FAPercent_back.gif");
  img.setAttribute("alt", percent);
  img.setAttribute("title", percent);
  img.setAttribute("class", "FAPercent");
  img.setAttribute("style", style);
  
  parentElem.appendChild(img);
}


function jqProgress(imgId, value) {		
	//
	var normalizedValue = (value/30*100).toFixed(2);
	var percent=normalizedValue.toString().concat(" %");
	var px = 0.79*normalizedValue-79;
	var style= "background-position: ".concat(px.toString()).concat("px 0pt;");
    
	//$("#ulimg").append($("<li/>").attr ({ class: "imgli", id: "imgli" }));	
	//$("#imgTotalScore")
	$(imgId).append($("<img/>").attr({
		"src": "images/FAPercent_back.gif",
		"alt": percent,
		"title": percent,
		"class": "FAPercent",
		"style": style
	}));
}

///////////////////////////////////////////////////////////////////////////////
// http://stackoverflow.com/questions/18190148/create-span-tag-and-insert-with-jquery#18190187
///////////////////////////////////////////////////////////////////////////////
function addParagraph(rcs, id, innerText){
	//var p = document.createElement("p");
	//p.setAttribute("id",id);
	//p.innerText = innerText;	
	var p =  $('<p />').attr ("id", id).text(innerText);
	//rcs.appendChild(p);	
	$(rcs).append(p);	
}

// load jQuery and execute the callback
//addJQuery(function () {
  // Note, jQ replaces $ to avoid conflicts.
  //alert("There are " + jQ('a').length + " links on this page.");
  //alert("There are " + $('a').length + " links on this page.");
//});

///////////////////////////////////////////////////////////////////////////////
// Base64Skills: convert skills array to base 64
///////////////////////////////////////////////////////////////////////////////
function Base64Skills ()
{
	var trOffset = 0;
	if ( $('.mc-ls > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(1)').attr("class") == "center highlight")
		trOffset = 2;
	//console.log("trOffset: ", trOffset);
		
	// From a length
	var bytes = new Uint8Array(15);

	for (var i=0; i<TUPLES_LENGTH; i++) {
	// $('#idHeight').append($('.mc-ls table:nth-child(2) tbody:nth-child(1) tr:nth-child(4) td:nth-child(2)').text());
	//".mc-ls table:nth-child(2) tbody:nth-child(1)  tr:nth-child(NTR) td:nth-child(NTD)", 
	var selector = ".mc-ls table:nth-child(2) tbody:nth-child(1) ";
	selector = selector.concat("tr:nth-child(");
	selector = selector.concat( (tuples[i].ntr+trOffset).toString());
	selector = selector.concat (") td:nth-child(");
	selector = selector.concat(tuples[i].ntd.toString());
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
//console.log("Index:", i, "Value", bytes[i]);	           
console.log (bytes);

// byte array to base 64 string
var b64s = btoa(String.fromCharCode.apply(null, bytes));
console.log ("Base64: ", b64s);

return b64s;
}

////
/* GM_xmlhttpRequest({
  method: "GET",
  url: "http://rest-service.guides.spring.io/greeting",
  headers: {
    "User-Agent": "Mozilla/5.0",    // If not specified, navigator.userAgent will be used.
    "Accept": "text/json"           // If not specified, browser defaults will be used.
  },
  onload: function(response) {
    var responseXML = null;
    // Inject responseXML into existing Object (only appropriate for XML content).
    if (!response.responseXML) {
      responseXML = new DOMParser()
        .parseFromString(response.responseText, "text/xml");
    }

    GM_log([
      response.status,
      response.statusText,
      response.readyState,
      response.responseHeaders,
      response.responseText,
      response.finalUrl,
      responseXML
    ].join("\n"));
  }
}); */

