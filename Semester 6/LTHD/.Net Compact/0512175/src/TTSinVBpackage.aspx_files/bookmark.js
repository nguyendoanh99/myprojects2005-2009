// Copyright (c) 2008, The Code Project. All rights reserved.

var obid, obtid;
var noteNode;

function bookmarkMe(objId, objTypeId) {
	obid = objId.toString(); obtid = objTypeId.toString();
	LoadWaitMessage();
	jx.load("/Script/Bookmarks/Ajax/Add.aspx?obtid="+ objTypeId + "&obid=" + objId, callback);
	return false;
}
function callback(data) {
	if(data.length > 0) {
		var re = new RegExp("<span id=\"bmResult\">(.+)<\/span>");
		var match = re.exec(data);
		if(match&&match[1]) noteNode.innerHTML = match[1];
	}
}

function LoadWaitMessage() {
	var sel = document.getElementById("bm_" + obid + "," + obtid);
	if(sel) {
		noteNode = sel.nextSibling;
		sel.parentNode.removeChild(sel);
		if(noteNode.style.visibility == "hidden") {
			noteNode.innerHTML = " please wait... ";
			noteNode.style.visibility = "visible";
		}
	}
}
