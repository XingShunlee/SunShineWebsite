/*
 name : yanggang;
 QQ:392017299;
 E-mail:yanggang1@conew.com;
 */
var UA = window.navigator.userAgent,IsAndroid = (/Android|HTC/i.test(UA)),IsIPad = !IsAndroid && /iPad/i.test(UA),IsIPhone = !IsAndroid && /iPod|iPhone/i.test(UA),IsIOS = IsIPad || IsIPhone,clearAnimatea = null;
var testStyle=document.createElement('div').style,
camelCase=function(str){
    return str.replace(/^-ms-/, "ms-").replace(/-([a-z]|[0-9])/ig, function(all, letter){
        return (letter+"").toUpperCase();
    });
},
cssVendor=(function(){
    var ts=testStyle,
        cases=['-o-','-webkit-','-moz-','-ms-',''],i=0;
    do {
        if(camelCase(cases[i]+'transform') in ts){
            return cases[i];
        }
    } while(++i<cases.length);
    return '';
})(),
transitionend=(function(){
    return ({
        '-o-':'otransitionend',
        '-webkit-':'webkitTransitionEnd',
        '-moz-':'transitionend',
        '-ms-':'MSTransitionEnd transitionend',
        '':'transitionend'
    })[cssVendor];
})(),
isCSS = function(property){
    var ts=testStyle,
        name=camelCase(property),
        _name=camelCase(cssVendor+property);
    return (name in ts) && name || (_name in ts) && _name || '';
};
var liebaoBrowser = {
    domAnimation: function(ele){
    },
    banSlide: function(item,time,ele,speed){
        clearTimeout(clearAnimatea);
        var length = ele.slide.length- 1;//项
        /*自动播放*/
        function autoPlay() {
            item++;
            if (item == length+1) {
                item = 0;
                aniObj(item);
            }else{
                aniObj(item);
            }
            spanCur(item);
            clearAnimatea = setTimeout(autoPlay, time);
        }
        clearAnimatea = setTimeout(autoPlay, time);
        /*点击切换动画*/
        function slidePrev(e){
            e.preventDefault();
            if(!ele.slide.is(':animated')){
                if (item == 0) {
                    item = length;
                    aniObj(item);
                } else {
                    item--;
                    aniObj(item);
                }
                spanCur(item);
            }
        };
        function slideNext(e){
            e.preventDefault();
            if(!ele.slide.is(':animated')){
                if (item == length) {
                    item = 0;
                    aniObj(item);
                } else {
                    item++;
                    aniObj(item);
                }
                spanCur(item);
            }
        };
        /* 点击切换动画 */
        ele.slideCur.click(function() {
            clearTimeout(clearAnimatea);
            ele.slideCur.removeClass('cur');
            $(this).addClass('cur');
            item = $(this).index();
            if (item <= length) {
                aniObj(item);
            }
        });
        /*执行动画方法*/
        function aniObj(getNum){
            ele.slide.hide().css({ opacity: 0.5,zIndex: 0});
            ele.slide.eq(getNum).show().stop(true,true).animate({opacity:1,zIndex:8},speed);
            if(ele.aniMation){
                ele.slide.removeClass('banAnimate');
                ele.slide.eq(getNum).addClass('banAnimate');
            }
        }
        /*当前动画指示*/
        function spanCur(eqNum) {
            ele.slideCur.removeClass('cur');
            ele.slideCur.eq(eqNum).addClass('cur');
        }
        /* 触发执行事件 */
        ele.prev.click(slidePrev);
        ele.next.click(slideNext);
            /*滑过主体区域停止动画*/
            ele.stopAnimte.hover(function() {
                clearTimeout(clearAnimatea);
            }, function() {
                clearAnimatea = setTimeout(autoPlay, time);
            });
        /*初始化动画*/
        ele.slide.eq(0).show().addClass('banAnimate');
    },
   
    flipObj: function(ele,time){
       
    },
    staJS: function(){
        $(document).on('click','a',function(e){
            var statData = $(this).attr('stat');
            try {
                _hmt.push(['_trackEvent',statData, 'webLB', 'click', 'download',statData]);
            } catch (e) {}
        });
    },
    init: function(ele){
        liebaoBrowser.banSlide(0,5000,ele,500);//滑动内容
        liebaoBrowser.domAnimation(ele);
        liebaoBrowser.flipObj(ele,2000);
        liebaoBrowser.staJS();//项工具条
    }
};
//-------------------------入口-------------------------
$(function(){
    var domEle = {
		windowMain: $(window), 
		bodyEle: $('body'), 
		stopAnimte: $('.slide,.prev,.next,.item'), 
		prev: $('.prev'),
		next: $('.next'), 
		slide: $('.slide'), 
		slideCur: $('.item a')
	};
	liebaoBrowser.init(domEle);
});
