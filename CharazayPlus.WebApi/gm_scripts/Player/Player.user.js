// ==UserScript==
// @name        PlayerEvaluator
// @namespace   CharazayPlus
// @description Charazay Plus Player Evaluator
// @version     1
// @grant       none
// @grant 		  GM_xmlhttpRequest
// @include     http://www.charazay.com/index.php?act=player&code=1&id=*
// @include     http://www.charazay.com/?act=player&code=1&id=*
// @require 	  https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js
// ==/UserScript==

/*
$( init );

function init() {
  var newPara = $( "<p>Here's some new text</p>" );
  $('#rc').prepend( newPara );
}
*/

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
// Accept:"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
///////////////////////////////////////////////////////////////////////////////
function ajaxCallCharazayPlusWebApi(b64s){
	var surl = "http://localhost/CharazayPlus.WebApi/player/facets/top/".concat(b64s);
    $.ajax({
		//type: "GET",
        dataType: "xml",
        url: "http://127.0.0.1/CharazayPlus.WebApi/api/values",		
		beforeSend: function(xhr){
			 xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
			 //> response.addHeader("Access-Control-Allow-Methods", request.getHeader("Access-Control-Request-Methods"));
			 //> response.addHeader("Access-Control-Allow-Headers", request.getHeader("Access-Control-Request-Headers"));
		},
		success: function(data/*, textStatus, */){        
			console.log(data/*, textStatus, qXHR*/);
		},
		error: function(qXHR, textStatus, errorThrown) {
			console.log( "error: ", errorThrown, "R:", qXHR.responseText, "Status: ", textStatus);			 
		}
    }).then(function(data) {
       //$('#greeting-id').append(data.id);
       //$('#greeting-content').append(data.content);
    });
	
	$.ajax({
		//type: "POST",
        dataType: "xml",
		//contentType: 'application/json',
		//contentType: 'text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8'
        url: "http://127.0.0.1/CharazayPlus.WebApi/api/values/3",		
		success: function(data/*, textStatus, */){        
			console.log(data/*, textStatus, qXHR*/);
		},
		error: function(qXHR, textStatus, errorThrown) {
			console.log( "error: ", errorThrown, "R:", qXHR.responseText, "Status: ", textStatus);
    }
    })
	/*
	$.getJSON(surl, 
		function (data) {
			console.log(data);
		});
		*/
	$.getJSON("http://127.0.0.1/CharazayPlus.WebApi/player/test1", function (data) { console.log(data); });
	$.getJSON("http://127.0.0.1/CharazayPlus.WebApi/player/test2", function (data) { console.log(data); });
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

///////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////
function addParagraph(rcs, id, innerText){
	var p = document.createElement("p");
	p.setAttribute("id",id);
	p.innerText = innerText;
	rcs.appendChild(p);
}

// load jQuery and execute the callback
//addJQuery(function () {
  // Note, jQ replaces $ to avoid conflicts.
  //alert("There are " + jQ('a').length + " links on this page.");
  //alert("There are " + $('a').length + " links on this page.");
//});

// Append some text to the element with id someText using the jQuery library.
$("#pagetitle").append(" more text.");

///////////////////////////////////////////////////////////////////////////////
// convert skills array to base 64
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
{ name: "Experience", 	ntr:11 , ntd: 5}  ,
//
//{ name: "SkillsIndex", 	ntr: 5 , ntd: 2}  , 
//{ name: "Salary", 		ntr: 5 , ntd: 5}  , 
];

var len = tuples.length;

function Base64Skills ()
{
	var trOffset = 0;
if ( $('.mc-ls > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(1)').attr("class") == "center highlight")
	trOffset = 2;
console.log("trOffset: ", trOffset);

// From a length
var bytes = new Uint8Array(15);

for (var i=0; i<len; i++) {
	// $('#idHeight').append($('.mc-ls table:nth-child(2) tbody:nth-child(1) tr:nth-child(4) td:nth-child(2)').text());
	//".mc-ls table:nth-child(2) tbody:nth-child(1)  tr:nth-child(NTR) td:nth-child(NTD)", 
	var selector = '.mc-ls table:nth-child(2) tbody:nth-child(1) ';
	selector = selector.concat('tr:nth-child(');
	selector = selector.concat( (tuples[i].ntr+trOffset).toString());
	selector = selector.concat (') td:nth-child(');
	selector = selector.concat(tuples[i].ntd.toString());
	selector = selector.concat(')');
	// append values to labels jquery id selector
	//var id = "#id".concat(tuples[i].name);
	//$(id).append($(selector).text());	
	//alert (id.concat('\t').concat(selector));
	if (i == 3) {
		bytes[i] = parseInt ($(selector).text().replace("Form: ",""));
	} else if (i == 4) {
		// .mc-ls > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(5) > img:nth-child(1)
		selector = selector.concat(' img:nth-child(1)');
		bytes[i] = parseInt ($(selector).attr('title'));
	} else {
		bytes[i] = parseInt ($(selector).text());
	}
	
	//console.log("Index:", i, "Value", bytes[i]);	
}               

console.log (bytes);

// byte array to base 64 string
var b64s = btoa(String.fromCharCode.apply(null, bytes));
console.log ("Base64: ", b64s);
return b64s;
}

///////////////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////////////////
// the guts of this userscript
///////////////////////////////////////////////////////////////////////////////
var rcs = document.createElement("div");
rcs.setAttribute("class", "rc-s")


var rct = document.createElement("div");
rct.setAttribute("class", "rc-t")
rct.innerText="Charazay+ Player Evaluator";
rcs.appendChild(rct);

var ul = document.createElement("ul");
addULProgressBar (ul, 0)
addULProgressBar (ul, 13)
addULProgressBar (ul, 26)
addULProgressBar (ul, 39)
addULProgressBar (ul, 65)
addULProgressBar (ul, 80)
addULProgressBar (ul, 91)
addULProgressBar (ul, 100)
rcs.appendChild(ul);

addParagraph(rcs,"greeting-id","The ID is ");
addParagraph(rcs,"greeting-content","The content is ");

var rc = document.getElementById("rc");
rc.appendChild(rcs);

ajaxCallHelloSvc();

var b64s = Base64Skills();
ajaxCallCharazayPlusWebApi(b64s);

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

