mergeInto(LibraryManager.library, {

	Hello: function () {
		window.alert("Hello dark world");
		console.log("HDW");
	},

	GiveMePlayerData: function () {
		MyGameInstance.SendMessage("Yandex", "SetName", player.getName())
		MyGameInstance.SendMessage("Yandex", "SetPhoto", player.getPhoto("medium"))

		console.log(player.getName());
		console.log(player.getPhoto("medium"));
	},
	SaveExtern: function (date){
		var dateString = UTF8ToString(date);
		var myobj = JSON.parse(dateString);
		player.setData(myobj);
		console.log("Save" + date);
	},
	LoadExtern: function (){
		player.getData().then(_date => {
			const myJSON = JSON.stringify(_date);
			MyGameInstance.SendMessage('GameInfo', 'SetGameInfo', myJSON)
			console.log("Load" + myJSON);
		});
	},
	ShowAdvInternal: function (){
		ysdk.adv.showFullscreenAdv({
    		callbacks: {
       			 onClose: function(wasShown) {
         		 	console.log("696969 Ad Closed 696969" + myJSON);
        		},
        		onError: function(error) {
          			// some action on error
        		}
   			 }
		})
	},

});