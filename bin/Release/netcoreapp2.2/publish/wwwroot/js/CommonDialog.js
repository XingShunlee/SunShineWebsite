/*
 *自定义弹窗
 */
//自执行函数 形成封闭的作用域 避免全局污染 
//传入windwo和document对象 相当于将window和document作为了作用域中的局部变量，
//就不需要内部函数沿着作用域链再查找到最顶层的window 提高运行效率。
(function (window, document) {
    //定义一个构造函数Msg 作为弹窗实例的构造函数。
    var Msg = function (options) {
        //执行初始化操作
        this._init(options);
    }
    //定义初始化方法 并对方法传递的参数进行初始化
    Msg.prototype = {
        constructor: Msg,
        _init: function (options) {
            //将传入的值绑定到this上 
            this.content = options.content;
            this.type = options.type;
            this.useHTML = options.useHTML;
            this.showIcon = options.showIcon;
            this.confirm = options.confirm || function () { };
            this.cancle = options.cancle || function () { };
            this.footer = options.footer;
            this.header = this.footer ? options.header : true;
            this.title = options.title || "提示";
            this.contentStyle = options.contentStyle;
            this.contentFontSize = options.contentFontSize;
            this.btnName = options.btnName || ["确定", "取消"];
            //执行创建元素方法
            this._creatElement();
            //显示弹窗及遮罩
            this._show({
                el: this._el,
                overlay: this._overlay
            });
            //绑定事件处理函数
            this._bind({
                el: this._el,
                overlay: this._overlay
            });
        },
        //创建弹窗元素方法
        _creatElement: function () {
            //创建最外层得包裹元素
            var wrap = document.createElement("div");
            wrap.className = "msg__wrap";
            //定义弹窗得两个按钮
            confirmBtnName = this.btnName[0];
            if (this.btnName.length > 1)
                cancelBtnName = this.btnName[1];
            //判断是否显示弹窗标题
            var headerHTML = this.header ?
        '<div class="msg-header"><span>' + this.title + '</span><span class="msg-header-close-button">×</span></div>' : "";
            //判断是否显示图标
            var iconHTML = this.showIcon ?
        '<div class="msg-body-icon">\
          <div class="msg-body-icon-${this.type}"></div>\
        </div>' : "";
            //判断是否显示弹窗底部按钮
            var footerHTML = this.footer ?
        '<div class="msg-footer">\
            <button class="msg-footer-btn msg-footer-confirm-button">' + confirmBtnName + '</button>' : "";
            if (this.btnName.length > 1)
                footerHTML += '<button class="msg-footer-btn msg-footer-cancel-button">' + cancelBtnName + '</button>'
            if (this.footer)
                footerHTML += '</div>'
            //拼接完整html
            var innerHTML = headerHTML + '\
      <div class="msg-body">'
        + iconHTML + '\
        <div class="msg-body-content"></div>\
      </div>'
      + footerHTML;
            //将拼接的html赋值到wrap中
            wrap.innerHTML = innerHTML;
            //把自定义的样式进行合并
            var contentStyle = {
                fontSize: this.contentFontSize
            }
            //获取内容所属DOM
            var content = wrap.querySelector(".msg-body .msg-body-content");
            //将传过来的样式添加到contentDOM
            for (var key in contentStyle) {
                if (contentStyle.hasOwnProperty(key)) {
                    content.style[key] = contentStyle[key];
                }
            }
            //给弹窗的conntent赋值
            if (this.useHTML) {
                content.innerHTML = this.content;
            } else {
                content.innerText = this.content;
            }
            //创建遮罩层
            var overlay = document.createElement("div");
            overlay.className = "msg__overlay";
            //把dom挂载到当前实例上
            this._overlay = overlay;
            this._el = wrap;
        },
        //弹窗展现方法
        _show: function (ele) {
            //把弹窗的dom和遮罩插入到页面中
            document.body.appendChild(ele.el);
            document.body.appendChild(ele.overlay);
            //将弹窗显示出来 timeout进行异步处理显示动画
            setTimeout(function () {
                ele.el.style.transform = "translate(-50%,-50%) scale(1,1)";
                ele.overlay.style.opacity = "1";
            })
        },
        //关闭弹窗方法
        _close: function (ele) {
            //隐藏dom 
            ele.el.style.transform = "translate(-50%,-50%) scale(0,0)";
            ele.overlay.style.opcity = "0";
            //根据动画时间 动画完成再移除
            setTimeout(function () {
                //把弹窗的dom和遮罩移除
                document.body.removeChild(ele.el)
                document.body.removeChild(ele.overlay);
            }, 300);
        },
        //事件处理函数，为DOM绑定事件
        _bind: function (ele) {
            var cancle = function (e) {
                this.cancle && this.cancle.call(this, e);
                this._close(ele);
            }
            //确认弹窗
            var confirm = function (e) {
                this.confirm && this.confirm.call(this, e);
                this._close(ele);
            }
            //顶部关闭按钮绑定事件
            if (this.header) {
                ele.el.querySelector(".msg-header-close-button").addEventListener("click", cancle.bind(this));
            }
            //弹窗底部两个按钮事件监听
            if (this.footer) {
                if (this.btnName.length > 1)
                    ele.el.querySelector(".msg-footer-cancel-button").addEventListener("click", cancle.bind(this));
                ele.el.querySelector(".msg-footer-confirm-button").addEventListener("click", confirm.bind(this))
            }
        }
    }
    //将构造函数暴露到window，这样才能在全局作用域下直接调用 
    window.$Msg = Msg;
})(window, document);
