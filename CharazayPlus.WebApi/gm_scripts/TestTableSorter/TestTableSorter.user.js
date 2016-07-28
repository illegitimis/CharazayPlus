// ==UserScript==
// @name        TestTableSorter
// @namespace   http://charazayplus.ml/
// @include     https://notepad-plus-plus.org/features/
// @version     1
// @require 	  https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js
// @require 	  https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.26.6/js/jquery.tablesorter.js
// @grant       GM_addStyle
// @grant       GM_getResourceText
// ==/UserScript==

//var newCSS = GM_getResourceText("TABLE_SORTER_DEFAULT_THEME");
//GM_addStyle(newCSS);


tryTablesorter();


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

// @resource 	  TABLE_SORTER_DEFAULT_THEME https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.26.6/css/theme.default.min.css

///////////////////////////////////////////////////////////////////////////////

function tryTablesorter() {
  
  // <link rel="stylesheet" href=>
  externalLinkCss("https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.26.6/css/theme.default.min.css")


  //load tablesorter scripts, tablesorter widgets (optional)
  var head = $("head");
  var lastScript = head.find("script:last");

  //var script1 = $('<script/>').attr({ type: "text/javascript", src: "https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.26.6/js/jquery.tablesorter.js" });
  //var script2 = $('<script/>').attr({ type: "text/javascript", src: "https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.26.6/js/jquery.tablesorter.widgets.js" });
  //var script3 = $('<script/>').attr({ type: "text/javascript", src: "https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" });
  // right ordre is 3,1,2
  if (lastScript.length) {
    //lastScript.after(script2);
    //lastScript.after(script1);
    //lastScript.after(script3);
  } else {
    //head.append(script3);
    //head.append(script1);
    //head.append(script2);
  }

  // body trigger
  //var script = $('<script/>').attr(type, "text/javascript").text('$(document).ready(function () { $("#myTable").tablesorter({ theme: "default" }); });');
  //var script = document.createElement('script');
  //script.type = 'text/javascript';
  //script.innerHTML = '$(document).ready(function () { $("#myTable").tablesorter({ theme: "default" }); });';
  //$('body').prepend(script);
  
  //$('#mc .mc-ls').append(tbl);
  var tbl = $('<table/>').attr({ id: "myTable", class: "tablesorter" }).html('<thead> <tr> <th>Last Name</th> <th>First Name</th> <th>Email</th> <th>Due</th> <th>Web Site</th> </tr> </thead> <tbody> <tr> <td>Smith</td> <td>John</td> <td>jsmith@gmail.com</td> <td>$50.00</td> <td>http://www.jsmith.com</td> </tr> <tr> <td>Bach</td> <td>Frank</td> <td>fbach@yahoo.com</td> <td>$50.00</td> <td>http://www.frank.com</td> </tr> <tr> <td>Doe</td> <td>Jason</td> <td>jdoe@hotmail.com</td> <td>$100.00</td> <td>http://www.jdoe.com</td> </tr> <tr> <td>Conway</td> <td>Tim</td> <td>tconway@earthlink.net</td> <td>$50.00</td> <td>http://www.timconway.com</td> </tr> </tbody>');  
  $('#main').append(tbl);

  //direct trigger  
  $(function () {
    console.log('before call 1', $("#myTable").length);    
    $("#myTable")
      .tablesorter({
        theme: "default"
      });
    console.log('after call 1');
  });  

}



///////////////////////////////////////////////////////////////////////////////
// http://stackoverflow.com/a/12093551/2239678
// JavaScript can be referenced from any domain, but can only enact changes to the exact domain of the document that is executing it. 
// By exact domain I mean everything from the protocol to just before the first directory must be identical.
// href: "https://raw.githubusercontent.com/illegitimis/CharazayPlus/master/CharazayPlus.WebApi/gm_scripts/Player/tblbkmrk.css"
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