UE.plugins.wximage = function() {
    var u = baidu;
    var a = this,
    c = u.editor.ui,
    b = u.editor.dom.domUtils;

    function strip_stack_span(html) {
        var docObj = $('' + html + ' ');
        docObj.find('li,colgroup,a').each(function() {
            if ($.trim($(this).text()) == "" && $(this).find('img').size() == 0) {
                $(this).remove();
            }
        });
        var has_secspan = false;
        do {
            has_secspan = false;
            docObj.find('span:has(span)').each(function(i) {
                var innerobj = $(this).find('> span');
                if (innerobj.size() > 1) {
                    $(this).find('span').each(function () {
                        if ($.trim($(this).text()) == "") {
                            $(this).replaceWith($(this).html());
                        }
                    });
                    return;
                } else if (innerobj.size() == 0) {
                    return;
                }
                if ($.trim($(this).text()) == $.trim(innerobj.text())) {
                    has_secspan = true;
                    var style = $(this).attr('style');
                    var innserstyle = innerobj.attr('style');
                    var newStyle = '';
                    if (style && style != "") {
                        newStyle += ';' + style;
                    }
                    if (innserstyle && innserstyle != "") {
                        newStyle += ';' + innserstyle;
                    }
                    var new_html = '';
                    $(this).find('> *').each(function() {
                        if (this.tagName == "SPAN") {
                            new_html += $(innerobj).html();
                        } else {
                            new_html += $(this).prop('outerHTML');
                        }
                    });
                    $(this).attr('style', newStyle).html(new_html);
                }
            });
        } while ( has_secspan );
        return docObj.html();
    }
    a.addListener("beforepaste",
    function(b, c, g) {
        b = c.html;
        "function" == typeof strip_stack_span && (b = strip_stack_span(b));
        b = $("" + b + " ");
        b.find("img").each(function() {
            var a = "",
            a = this.src && "" != this.src ? this.src: $(this).attr("data-src");
            $(this).removeAttr("data-src");
            "undefined" == typeof a || "" == a ? $(this).remove() : (a = a.replace(/http:\/\/mmbiz.qpic.cn/g, "https://mmbiz.qlogo.cn"), a = a.replace(/https:\/\/mmbiz.qpic.cn/g, "https://mmbiz.qlogo.cn"), a = a.replace(/http:\/\/mmbiz.qlogo.cn/g, "https://mmbiz.qlogo.cn"), a = a.replace(/&wxfrom=\d+/g, ""), a = a.replace(/wxfrom=\d+/g, ""), a = a.replace(/&wx_lazy=\d+/g, ""), a = a.replace(/wx_lazy=\d+/g, ""), a = a.replace(/&tp=[a-z]+/g, ""), a = a.replace(/tp=[a-z]+/g, ""), a = a.replace(/\?&/g, "?"), $(this).attr("src", a), $(this).attr("_src", a))
        });
        c.html = b.html()
    });
};