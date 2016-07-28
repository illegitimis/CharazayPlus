// ==UserScript==
// @name        CharazayPlus
// @namespace   http://charazayplus.ml/
// @description Charazay Plus Player Evaluator
// @version     1.2.11
// @include     http://www.charazay.com/index.php?act=player&code=1&id=*
// @include     http://www.charazay.com/?act=player&code=1&id=*
// @include     http://www.charazay.com/index.php?act=youthplayer&code=1&id=*
// @include     http://www.charazay.com/?act=youthplayer&code=1&id=*
// @require 	  https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js
// @require 	  https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.26.6/js/jquery.tablesorter.js
// @grant       none
// @grant       GM_addStyle
// @grant       GM_getResourceText
// @grant       GM_xmlhttpRequest
// ==/UserScript==

console.info ('Charazay Plus Player Evaluator', 'v 1.2.8.1');
this.$ = this.jQuery = jQuery.noConflict(true);

///////////////////////////////////////////////////////////////////////////////
// Base64: tuple definition
// .mc-ls > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(<NTR>) > td:nth-child(<NTD>)
///////////////////////////////////////////////////////////////////////////////
var TUPLES = [
{ name: "Age", ntr: 3, ntd: 2 },   
{ name: "Height", ntr: 4, ntd: 2 },
{ name: "Weight", ntr: 4, ntd: 5 },
{ name: "Form", ntr: 2, ntd: 1 },  
{ name: "Fatigue", ntr: 3, ntd: 5 },
{ name: "Defence", ntr: 7, ntd: 2 },
{ name: "FreeThrows", ntr: 7, ntd: 5 },
{ name: "TwoPoint", ntr: 8, ntd: 2 },
{ name: "ThreePoint", ntr: 8, ntd: 5 },
{ name: "Dribbling", ntr: 9, ntd: 2 },
{ name: "Passing", ntr: 9, ntd: 5 },
{ name: "Speed", ntr: 10, ntd: 2 },
{ name: "Footwork", ntr: 10, ntd: 5 },
{ name: "Rebounds", ntr: 11, ntd: 2 },
{ name: "Experience", ntr: 11, ntd: 5 }
//
//{ name: "SkillsIndex", 	ntr: 5 , ntd: 2}  , 
//{ name: "Salary", 		ntr: 5 , ntd: 5}  , 
];

var TUPLES_LENGTH = TUPLES.length;

var BKHDR = [
	  {a:"Position on the court" , b:"POS" },
	  {a:"Age / Value Index" , b:"VI" },
	  {a:"Total Score / out of 30" , b:"TOT" },
//	  {a:"Defensive Score" , b:"DEF" },
//	  {a:"Offensive Score" , b:"OFF" },
//	  {a:"Offensive Ability" , b:"AB" },
//	  {a:"Shooting Score" , b:"SH" },
    { a: "Current price / bid", b: "Price" },
	  { a: "Estimated Transfer Market Value", b: "Value" },
    { a: "Profitability", b: "Prof" },
//	  {a:"Charazay Id" , b:"ID" },
	  {a:"Full Name" , b:"Name" },
//	  {a:"When" , b:"@" },
	  {a:"Deadline" , b:"DDL" },	  
  ];
var BKHDR_LENGTH = BKHDR.length;  

///////////////////////////////////////////////////////////////////////////////
// console.info("the guts of this userscript");
// if no skills available => nothing ...
// <table style="margin: 0 auto;" cellpadding="0" cellspacing="0" width="80%">
///////////////////////////////////////////////////////////////////////////////

var DATA_LENGTH = $('table[width="80%"] tr').length;
console.log('TUPLES_LENGTH', TUPLES_LENGTH, 'BKHDR_LENGTH', BKHDR_LENGTH, 'DATA_LENGTH', DATA_LENGTH);

if (DATA_LENGTH == 11 || DATA_LENGTH == 13) {
  var rcs = $("<div/>").attr({ class: "rc-s", id: "cpe" });
  $(rcs).append($("<div/>").attr("class", "rc-t").text("Charazay+ Player Evaluator"));
  
  // http://stackoverflow.com/questions/18190148/create-span-tag-and-insert-with-jquery
  $(rcs).append($('<table />').html('<tbody><tr><td>Position</td><td id="cpePosition"></td></tr><tr><td>ValueIndex</td><td id="cpeValueIndex"></td></tr><tr><td>TotalScore</td><td id="cpeTotalScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgTotalScore"></td></tr><tr><td>DefensiveScore</td><td id="cpeDefensiveScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgDefensiveScore"></td></tr><tr><td>OffensiveScore</td><td id="cpeOffensiveScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgOffensiveScore"></td></tr><tr><td>OffensiveAbility</td><td id="cpeOffensiveAbility"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgOffensiveScore"></td></tr><tr><td>ShootingScore</td><td id="cpeShootingScore"></td><td>&nbsp;&nbsp;&nbsp;</td><td id="imgShootingScore"></td></tr><tr><td>TransferMarketValue</td><td id="cpeTransferMarketValue"></td><td>M</td></tr></tbody>'));

  // position combo placeholder
  $(rcs).append($("<p/>").attr("id", "pselect"));
 
  // bookmark button
  // console.log("$('form[name=\"bid\"]').length", $('form[name="bid"]').length);
  if ($('form[name="bid"]').length == 1) {
    $(rcs).append($("<input/>").attr({
      id: "bukmark",
      style: "display: inline-block",
      class: "inputSubmit",
      type: "submit",
      value: "Bookmark"
    }));
    $(rcs).append($("<i/>").attr("id", "imark").text(''));
  }
 
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


/*
tryTablesorter();
styleBookmarkTableCss();
*/


///////////////////////////////////////////////////////////////////////////////
//http://jquery-howto.blogspot.ro/2013/09/jquery-cross-domain-ajax-request.html
//function ajax_CharazayPlusWebApi_BookmarkTableCss() {
///////////////////////////////////////////////////////////////////////////////
function styleBookmarkTableCss() {
  var SCRIPT_TEXT = 'var TgTableSort = window.TgTableSort || function (n, t) { "use strict"; function r(n, t) { for (var e = [], o = n.childNodes, i = 0; i < o.length; ++i) { var u = o[i]; if ("." == t.substring(0, 1)) { var a = t.substring(1); f(u, a) && e.push(u) } else u.nodeName.toLowerCase() == t && e.push(u); var c = r(u, t); e = e.concat(c) } return e } function e(n, t) { var e = [], o = r(n, "tr"); return o.forEach(function (n) { var o = r(n, "td"); t >= 0 && t < o.length && e.push(o[t]) }), e } function o(n) { return n.textContent || n.innerText || "" } function i(n) { return n.innerHTML || "" } function u(n, t) { var r = e(n, t); return r.map(o) } function a(n, t) { var r = e(n, t); return r.map(i) } function c(n) { var t = n.className || ""; return t.match(/\S+/g) || [] } function f(n, t) { return -1 != c(n).indexOf(t) } function s(n, t) { f(n, t) || (n.className += " " + t) } function d(n, t) { if (f(n, t)) { var r = c(n), e = r.indexOf(t); r.splice(e, 1), n.className = r.join(" ") } } function v(n) { d(n, L), d(n, E) } function l(n, t, e) { r(n, "." + E).map(v), r(n, "." + L).map(v), e == T ? s(t, E) : s(t, L) } function g(n) { return function (t, r) { var e = n * t.str.localeCompare(r.str); return 0 == e && (e = t.index - r.index), e } } function h(n) { return function (t, r) { var e = +t.str, o = +r.str; return e == o ? t.index - r.index : n * (e - o) } } function m(n, t, r) { var e = u(n, t), o = e.map(function (n, t) { return { str: n, index: t } }), i = e && -1 == e.map(isNaN).indexOf(!0), a = i ? h(r) : g(r); return o.sort(a), o.map(function (n) { return n.index }) } function p(n, t, r, o) { for (var i = f(o, E) ? N : T, u = m(n, r, i), c = 0; t > c; ++c) { var s = e(n, c), d = a(n, c); s.forEach(function (n, t) { n.innerHTML = d[u[t]] }) } l(n, o, i) } function x(n, t) { var r = t.length; t.forEach(function (t, e) { t.addEventListener("click", function () { p(n, r, e, t) }), s(t, "tg-sort-header") }) } var T = 1, N = -1, E = "tg-sort-asc", L = "tg-sort-desc"; return function (t) { var e = n.getElementById(t), o = r(e, "tr"), i = o.length > 0 ? r(o[0], "td") : []; 0 == i.length && (i = r(o[0], "th")); for (var u = 1; u < o.length; ++u) { var a = r(o[u], "td"); if (a.length != i.length) return } x(e, i) } }(document); document.addEventListener("DOMContentLoaded", function (n) { TgTableSort("tblbkmrk") });';
  var CSS = ".tg { border-collapse: collapse; border-spacing: 0; width: 100%; } .tg td { font-family: Arial, sans-serif; font-size: 12px; padding: 8px 4px; border-color: #bbbbbb; border-style: solid; border-width: 1px; overflow: hidden; word-break: normal; } .tg th { font-family: Arial, sans-serif; font-size: 14px; font-weight: normal; padding: 10px 5px; border-style: solid; border-width: 1px; border-color: #999999; overflow: hidden; word-break: normal; background: #bbbbbb; } .tg tr:nth-child(odd) { background: #dddddd; } .tg tr:nth-child(even) { background: #eeeeee; } .tg .tg-hc { vertical-align: top; } th.tg-sort-header::-moz-selection { background: transparent; } th.tg-sort-header::selection { background: transparent; } th.tg-sort-header { cursor: pointer; } table th.tg-sort-header:after { content: ''; float: right; margin-top: 7px; border-width: 0 4px 4px; border-style: solid; border-color: #404040 transparent; visibility: hidden; } table th.tg-sort-header:hover:after { visibility: visible; } table th.tg-sort-desc:after, table th.tg-sort-asc:after, table th.tg-sort-asc:hover:after { visibility: visible; opacity: 0.4; } table th.tg-sort-desc:after { border-bottom: none; border-width: 4px 4px 0; }  @media screen and (max-width: 767px) { .tg { width: auto !important; } .tg col { width: auto !important; } .tg-wrap { overflow-x: auto; -webkit-overflow-scrolling: touch; } }";
  
  var $head = $("head");

  var $headstylelast = $head.find("style:last");
  var style = $('<style type="text/css"></style>').text(CSS);
  if ($headstylelast.length) {
    $headstylelast.after(style);
  }
  else {
    $head.append(style);
  }
    
  //var $headscriptlast = $head.find("script:last");
  var script = $('<script/>').attr({ type: "text/javascript", charset: "utf-8" }).text(SCRIPT_TEXT);
  style.after(script);
  //if ($headscriptlast.length) {
  //  $headscriptlast.after(script);
  //}
  //else {
  //  $head.append(script);
  //}
}

///////////////////////////////////////////////////////////////////////////////
// ajax_CharazayPlusWebApi_PostBookmark
// https://weblog.west-wind.com/posts/2012/May/08/Passing-multiple-POST-parameters-to-Web-API-Controller-Methods
///////////////////////////////////////////////////////////////////////////////
function ajax_CharazayPlusWebApi_PostBookmark() {

  // build bookmark data transfer object
  var intPrice = parseInt($("#new_bid").attr("value").replace(/\./g, ''));
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
    console.log('ajax_CharazayPlusWebApi_PostBookmark', bookmarkData);

    // ajax post
    $.ajax(
    {
      url: "http://localhost/CharazayPlus.WebApi/bookmark",
      type: "POST",
      data: bookmarkData,
      success: function (result) {
        console.info(result);
        $('#imark').html('&#10004;');
      },
      error: function (xhr, status, p3, p4) {
        var err = "Error " + " " + status + " " + p3;
        if (xhr.responseText && xhr.responseText[0] == "{")
          err = JSON.parse(xhr.responseText).message;
        alert(err);
      }
    });
    
    // add row if bookmark table visible
    if ($('#tblbkmrk').length > 0) {
      appendBookmarkRow(bookmarkData);
    }    
}

///////////////////////////////////////////////////////////////////////////////
// calls a rest service at
// https://spring.io/guides/gs/consuming-rest-jquery/
///////////////////////////////////////////////////////////////////////////////
function ajaxCallHelloSvc() {
  //alert("Getting the Data");
  $.ajax({
    //type: "GET",
    //dataType: "json",
    url: "http://rest-service.guides.spring.io/greeting",
    success: function (data) {
      console.log(data);
    }
  }).then(function (data) {
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

  switch (expression) {
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
.done(function (data) {
  $('#cpePosition').html($("<strong/>").attr({ align: "right" }).text(data.Position));
  $('#cpeValueIndex').html($("<strong/>").text(data.ValueIndex));
  $("#cpeTotalScore").html(data.TotalScore);
  jqProgress("#imgTotalScore", data.TotalScore);
  $("#cpeDefensiveScore").html(data.DefensiveScore);
  jqProgress("#imgDefensiveScore", data.DefensiveScore);
  $("#cpeOffensiveScore").html(data.OffensiveScore);
  jqProgress("#imgOffensiveScore", data.OffensiveScore);
  $("#cpeOffensiveAbility").html(data.OffensiveAbility);
  //jqProgress ("#imgOffensiveScore", data.OffensiveAbility);
  $("#cpeShootingScore").html(data.ShootingScore);
  //jqProgress ("#imgShootingScore", data.ShootingScore);
  $("#cpeTransferMarketValue").html($("<strong/>").text(data.TransferMarketValue));
  //http://stackoverflow.com/questions/16627203/how-to-set-the-selected-option-of-a-select-list-by-value-not-by-selectedindex-us#16627236
  var jqs = "#selected_position option[value='".concat(data.Position).concat("']");
  $(jqs).prop('selected', true);
  $('#imark').text('');
})
.fail(function (jqxhr, textStatus, error) {
  console.log(surl, " getJSON failed ", jqxhr.statusText, "readyState:", jqxhr.readyState, "status:", textStatus, "error:", error);
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
  var normalizedValue = (value / 30 * 100).toFixed(2);
  var percent = normalizedValue.toString().concat(" %");
  var dscr = value.toString().concat("/30 ").concat(percent);
  var px = 0.79 * normalizedValue - 79;
  var style = "background-position: ".concat(px.toString()).concat("px 0pt;");

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
  if ($('.mc-ls > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(1)').attr("class") == "center highlight")
    trOffset = 2;
  console.log("trOffset: ", trOffset);

  // From a length
  var bytes = new Uint8Array(15);

  for (var i = 0; i < TUPLES_LENGTH; i++) {
    // $('#idHeight').append($('.mc-ls table:nth-child(2) tbody:nth-child(1) tr:nth-child(4) td:nth-child(2)').text());
    //".mc-ls table:nth-child(2) tbody:nth-child(1)  tr:nth-child(NTR) td:nth-child(NTD)", 
    var selector = ".mc-ls table:nth-child(2) tbody:nth-child(1) ";
    selector = selector.concat("tr:nth-child(");
    selector = selector.concat((TUPLES[i].ntr + trOffset).toString());
    selector = selector.concat(") td:nth-child(");
    selector = selector.concat(TUPLES[i].ntd.toString());
    selector = selector.concat(")");
    // append values to labels jquery id selector
    //var id = "#id".concat(tuples[i].name);
    //$(id).append($(selector).text());	
    //console.log (selector);

    if (i == 3) {
      bytes[i] = parseInt($(selector).text().replace("Form: ", ""));
    } else if (i == 4) {
      // .mc-ls > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(5) > img:nth-child(1)
      selector = selector.concat(" img:nth-child(1)");
      bytes[i] = parseInt($(selector).attr("title"));
    } else {
      bytes[i] = parseInt($(selector).text());
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
// http://localhost/CharazayPlus.WebApi/bookmarks/0/5
// Charazay css classes {table: gtable, tr: detail, td:right }
// Tablesorter css classes {table: tablesorter}
// add tablesorter default theme css
// externalLinkCss("https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.26.6/css/theme.default.min.css")
//direct table sorter trigger
//$(function () { $("#tblbkmrk").tablesorter({ theme: "default" }); });
///////////////////////////////////////////////////////////////////////////////
function onViewBookmarks () {    

  // remove 'last 10 performance' table    
	$('.mc-ls .mc-t').remove(); 
  $('.mc-ls table[width="100%"]').remove();
		
	$('.mc-ls').append ( 
	  $("<div/>").attr("class","tg-wrap")
	  //.html('<table style="margin: 1 auto;" cellpadding="1" cellspacing="1" width="100%" id="tblbkmrk" class="tg"><thead></thead><tbody></tbody></table>')
    .html('<table id="tblbkmrk" class="gtable"><thead></thead><tbody></tbody></table>')
    //.html('<table id="tblbkmrk" class="tablesorter" width="100%"><thead></thead><tbody></tbody></table>')
	); 
	
	// header row
	var tr = $('<tr/>');
	for (var i = 0; i < BKHDR_LENGTH; i++)
	{		
		 var abbr = $('<abbr/>').attr("title", BKHDR[i].a).text(BKHDR[i].b);
	  var th = $('<th/>').append(abbr);
		 $(tr).append ( th );	     	
	}
	$(tr).append($('<th/>').text('del?'));
	$('#tblbkmrk thead').append(tr);
	  
  // ajax call to get bookmarks
	$.getJSON('http://localhost/CharazayPlus.WebApi/bookmarks/', function (data) {
    // key is the array index, val is the actual object
	  $.each(data, function (key, val) {
	    appendBookmarkRow(val);
	  });
	});
  
}

///////////////////////////////////////////////////////////////////////////////
// ajax call CharazayPlusWebApi delete a bookmark
///////////////////////////////////////////////////////////////////////////////
function ajax_CharazayPlusWebApi_DeleteBookmark(playerId) {

  // ajax delete bookmark call
  var pid = playerId.toString();
  var uri = "http://localhost/CharazayPlus.WebApi/bookmark/".concat(pid);
  $.ajax(
    {
      url: uri,
      type: "DELETE",
      crossDomain: true,
      cache: false,
      success: function (result) {
        console.info(result);      
      },
      error: function (xhr, status) {
        var err = 'Error!  Status = ' + xhr.status + " Message = " + xhr.statusText;
        if (xhr.responseText && xhr.responseText[0] == "{")
          err = JSON.parse(xhr.responseText).message;
        console.error(err);
      },
      statusCode: {
        200: function (data) {
          // Successful DELETE
        }, 
        404: function (data) {
          alert(apiUrl + " ... Not Found");
        }, 
        400: function (data) {
          alert("Bad Request O");
        } 
      } 
    });

  // table row removal  
  console.log($('#tr' + pid).text());
  $('#tr' + pid).remove();
  
}

///////////////////////////////////////////////////////////////////////////////
// https://raw.githubusercontent.com/Mottie/tablesorter/master/js/jquery.tablesorter.js
// https://raw.githubusercontent.com/Mottie/tablesorter/master/js/jquery.tablesorter.widgets.js    
// https://mottie.github.io/tablesorter/docs/#Examples
// https://cdnjs.com/libraries/jquery.tablesorter
// https://github.com/Mottie/tablesorter/blob/master/css/theme.default.css
// https://jsfiddle.net/Mottie/bbxxomhx/
// https://github.com/Mottie/tablesorter/tree/master/js
// http://stackoverflow.com/questions/610995/cant-append-script-element
// @require 	  https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.26.6/js/jquery.tablesorter.widgets.js
///////////////////////////////////////////////////////////////////////////////
// body trigger
//var script = $('<script/>').attr(type, "text/javascript").text('$(document).ready(function () { $("#myTable").tablesorter({ theme: "default" }); });');
//var script = document.createElement('script');
//script.type = 'text/javascript';
//script.innerHTML = '$(document).ready(function () { $("#myTable").tablesorter({ theme: "default" }); });';
//$('body').prepend(script);
///////////////////////////////////////////////////////////////////////////////
function appendBookmarkRow(bookmarkDTO) {
  var sid = bookmarkDTO.CharazayId.toString();
  var tr = $('<tr/>').attr({id: 'tr' + sid, class: "detail"});

  $(tr).append($('<td/>').attr('class', 'right').text(bookmarkDTO.Position));
  $(tr).append($('<td/>').attr('class', 'right').append($('<strong/>').text(bookmarkDTO.ValueIndex)));
  $(tr).append($('<td/>').attr('class', 'right').text(bookmarkDTO.TotalScore));
  //$(tr).append($('<td/>').text(bookmarkDTO.DefensiveScore));
  //$(tr).append($('<td/>').text(bookmarkDTO.OffensiveScore));
  //$(tr).append($('<td/>').text(bookmarkDTO.OffensiveAbility));
  //$(tr).append($('<td/>').text(bookmarkDTO.ShootingScore));	    
  $(tr).append($('<td/>').attr('class', 'right').append($('<strong/>').text(bookmarkDTO.Price)));
  $(tr).append($('<td/>').attr('class', 'right').text(bookmarkDTO.TransferMarketValue));

  var profitability = Math.max(0.01, bookmarkDTO.TransferMarketValue / bookmarkDTO.Price).toFixed(2);
  console.log('prof', profitability);
  $(tr).append($('<td/>').attr('class', 'right').append($('<i/>').text(profitability.toString())));

  //<a href="index.php?act=player&code=1&id=30308369">Emilio Diaz</a>
  var href = "index.php?act=player&code=1&id=".concat(sid);
  $(tr).append($('<td/>').attr('class', 'right').append($('<a/>').attr('href', href).text(bookmarkDTO.FullName)));

  //$(tr).append($('<td/>').text(bookmarkDTO.When));
  $(tr).append($('<td/>').attr('class', 'right').text(bookmarkDTO.Deadline));

  // delete bookmark action
  var a = $('<a/>').attr('href', '#').click(function () { ajax_CharazayPlusWebApi_DeleteBookmark(bookmarkDTO.CharazayId); });
  var img = $("<img/>").attr({ src: "/images/delete.png", title: "Delete Bookmark" });
  $(a).html(img);
  $(tr).append($('<td/>').attr('class', 'right').html(a));

  // append table row
  $('#tblbkmrk tbody').append(tr);
}


///////////////////////////////////////////////////////////////////////////////
// http://stackoverflow.com/a/12093551/2239678
// JavaScript can be referenced from any domain, but can only enact changes to the exact domain of the document that is executing it. 
// By exact domain I mean everything from the protocol to just before the first directory must be identical.
// href: "https://raw.githubusercontent.com/illegitimis/CharazayPlus/master/CharazayPlus.WebApi/gm_scripts/Player/tblbkmrk.css"
///////////////////////////////////////////////////////////////////////////////
// this should have worked
// @resource 	  TABLE_SORTER_DEFAULT_THEME https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.26.6/css/theme.default.min.css
// var newCSS = GM_getResourceText("TABLE_SORTER_DEFAULT_THEME");
// GM_addStyle(newCSS);
///////////////////////////////////////////////////////////////////////////////
function externalLinkCss(externalHref) {
  var head = $("head");
  var headlinklast = head.find("link[rel='stylesheet']:last");
  var linkElement = $('<link/>').attr({
    rel: "stylesheet",
    type: "text/css",
    href: externalHref
  });
  if (headlinklast.length) {
    headlinklast.after(linkElement);
  }
  else {
    head.append(linkElement);
  }
}

