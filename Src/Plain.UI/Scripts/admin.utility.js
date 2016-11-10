function request() {
	var name, value, i;
	var str = location.href;
	var num = str.indexOf("?");
	str = str.substr(num + 1);
	var arrtmp = str.split("&");
	for (i = 0; i < arrtmp.length; i++) {
		num = arrtmp[i].indexOf("=");
		if (num > 0) {
			name = arrtmp[i].substring(0, num);
			value = arrtmp[i].substr(num + 1);
			this[name] = value;
		}
	}
}

function converUrlParas(url) {
	var parasStr = url;
	if (url.indexOf('?') !== -1) {
		  parasStr= url.split('?')[1];
	}

	if (!!parasStr) {
		var parasArr = parasStr.split('&');
		var paraLen = parasArr.length;
		var paras = {};
		for (var i = 0; i < paraLen; i++) {
			var key = parasArr[i].split('=')[0];
			var value = parasArr[i].split('=')[1];
			paras[key] = value;

		}
		return paras;
	}
 
}
