
 function BannerSlider(){
	 this.clearAnimatea=0;
 }
 
    BannerSlider.prototype.banSlide=function(item,time,ele,speed){
        
        var length = ele.slide.length- 1;//项
        /*自动播放*/
        function autoPlay() {
			clearTimeout(ele.clearAnimatea);
            item++;
            if (item == length+1) {
                item = 0;
                aniObj(item);
            }else{
                aniObj(item);
            }
            spanCur(item);
            ele.clearAnimatea = setTimeout(autoPlay, time);
        }
        ele.clearAnimatea = setTimeout(autoPlay, time);
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
            clearTimeout(ele.clearAnimatea);
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
                clearTimeout(ele.clearAnimatea);
            }, function() {
                ele.clearAnimatea = setTimeout(autoPlay, time);
            });
        /*初始化动画*/
        ele.slide.eq(0).show().addClass('banAnimate');
    }
  
    BannerSlider.prototype.staJS=function(){
        $(document).on('click','a',function(e){
            var statData = $(this).attr('stat');
            try {
                _hmt.push(['_trackEvent',statData, 'webLB', 'click', 'download',statData]);
            } catch (e) {}
        });
    }
    BannerSlider.prototype.init=function(ele){
        this.banSlide(0,5000,ele,500);//滑动内容
    }
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
	var slider =new BannerSlider();
	slider.init(domEle);
});
