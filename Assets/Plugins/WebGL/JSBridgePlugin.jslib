var Plugin = {

    GetValue: function(key){
		var returnStr = onUnityRequestValue(UTF8ToString(key));
		var bufferSize = lengthBytesUTF8(returnStr) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(returnStr, buffer, bufferSize);
		return buffer;
    },
	
	SendValue: function(key, val){
		onUnitySendValue(UTF8ToString(key), UTF8ToString(val));
	},
	
	ShowMessageBox: function(info){
		window.alert(UTF8ToString(info));
	}
};

mergeInto(LibraryManager.library, Plugin);