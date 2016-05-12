var startTime = new Date().getTime();
var formKey = "1vfIIx0uu51rNb6S9TR2openuR8LXon3NdRiK3bBgiSQ";
var entryID = "495906984";

function stopTimer() {
	return t = (new Date().getTime() - startTime) / 1000;
}

window.onbeforeunload = function() {
	var xhttp = new XMLHttpRequest();
	xhttp.open("GET", "https://docs.google.com/forms/d/" + formKey + "/formResponse?entry." + entryID + "=" + stopTimer() + "&submit=Submit", true);
	xhttp.send();
	window.onbeforeunload = null;
	return "esc";
}
