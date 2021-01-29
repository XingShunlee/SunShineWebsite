function DaojishiPlug(obj,callbackfn){
this.controlobj =obj;
this.callbackfn=callbackfn;
}
DaojishiPlug.prototype.intervalTime=function(){
 if (this.stamp > 0) {
            var day = Math.floor(this.stamp / (60 * 60 * 24));
            var hour = Math.floor(this.stamp / (60 * 60)) - (day * 24);
            var minute = Math.floor(this.stamp / 60) - (day * 24 * 60) - (hour * 60);
            var second = Math.floor(this.stamp) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60);

            if (day <= 9) day = '0' + day;
            if (hour <= 9) hour = '0' + hour;
            if (minute <= 9) minute = '0' + minute;
            if (second <= 9) second = '0' + second;
            $('#'+this.controlobj).text(minute+":"+second);
            this.stamp--;
			 
        }
		else{
			if( typeof( this.callbackfn)=="function")
				this.callbackfn();
			clearInterval(this.tid);
		}
        
}
DaojishiPlug.prototype.timer=function (stampend) {
        this.stamp = parseInt(stampend); //剩余时间戳
		var that = this;
        //this.tid=setInterval(this.intervalTime.bind(that), 1000);
		this.tid =setInterval(function(){that.intervalTime();},1000);
}
    
	
	
	
function DaojishiPlug2(obj,callbackfn){
this.controlobj =obj;
this.callbackfn=callbackfn;
}
DaojishiPlug2.prototype.intervalTime=function(){
	var that = this;
 if (this.stamp > 0) {
            var day = Math.floor(this.stamp / (60 * 60 * 24));
            var hour = Math.floor(this.stamp / (60 * 60)) - (day * 24);
            var minute = Math.floor(this.stamp / 60) - (day * 24 * 60) - (hour * 60);
            var second = Math.floor(this.stamp) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60);

            if (day <= 9) day = '0' + day;
            if (hour <= 9) hour = '0' + hour;
            if (minute <= 9) minute = '0' + minute;
            if (second <= 9) second = '0' + second;
            $('#'+this.controlobj).text(minute+":"+second);
            this.stamp--;
			clearTimeout(this.tid);
			 this.tid=setTimeout(function(){that.intervalTime();},1000);
        }
		else{
			if( typeof( this.callbackfn)=="function")
				this.callbackfn();
			clearTimeout(this.tid);
		}
        
}
DaojishiPlug2.prototype.timer=function (stampend) {
        this.stamp = parseInt(stampend); //剩余时间戳
		var that = this;
		this.tid=setTimeout(function(){that.intervalTime();},1000);
    }
	
	
	
	
	
	
function DaojishiPlugEx(obj,callbackfn){
this.controlobj =obj;
this.callbackfn=callbackfn;
}
DaojishiPlugEx.prototype.intervalTime=function(){
 if (this.stamp > 0) {
            var day = Math.floor(this.stamp / (60 * 60 * 24));
            var hour = Math.floor(this.stamp / (60 * 60)) - (day * 24);
            var minute = Math.floor(this.stamp / 60) - (day * 24 * 60) - (hour * 60);
            var second = Math.floor(this.stamp) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60);

            if (day <= 9) day = '0' + day;
            if (hour <= 9) hour = '0' + hour;
            if (minute <= 9) minute = '0' + minute;
            if (second <= 9) second = '0' + second;
            $('#'+this.controlobj).text(minute+":"+second);
            this.stamp--;
			clearTimeout(this.tid);
			 this.tid=setTimeout(arguments.callee.bind(this),1000);
        }
		else{
			if( typeof( this.callbackfn)=="function")
				this.callbackfn();
			clearTimeout(this.tid);
		}
        
}
DaojishiPlugEx.prototype.timer=function (stampend) {
        this.stamp = parseInt(stampend); //剩余时间戳
		var that = this;
		this.tid=setTimeout(function(){that.intervalTime();},1000);
    }
	
	
function DaojishiPlugEx2(obj,callbackfn){
this.controlobj =obj;
this.callbackfn=callbackfn;
}
DaojishiPlugEx2.prototype.intervalTime=function(ele){
	function autoPlay() {
		clearTimeout(ele.tid);
		if (ele.stamp > 0) {
            var day = Math.floor(ele.stamp / (60 * 60 * 24));
            var hour = Math.floor(ele.stamp / (60 * 60)) - (day * 24);
            var minute = Math.floor(ele.stamp / 60) - (day * 24 * 60) - (hour * 60);
            var second = Math.floor(ele.stamp) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60);

            if (day <= 9) day = '0' + day;
            if (hour <= 9) hour = '0' + hour;
            if (minute <= 9) minute = '0' + minute;
            if (second <= 9) second = '0' + second;
            $('#'+ele.controlobj).text(minute+":"+second);
            ele.stamp--;
			
			 ele.tid=setTimeout(autoPlay,1000);
        }
		else{
			if( typeof( ele.callbackfn)=="function")
				ele.callbackfn();
			clearTimeout(ele.tid);
		}
	}
	//
	ele.tid=setTimeout(autoPlay,1000);
}
DaojishiPlugEx2.prototype.timer=function (stampend) {
        this.stamp = parseInt(stampend); //剩余时间戳
		this.intervalTime(this);
    }