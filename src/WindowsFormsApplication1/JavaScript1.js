﻿var jqxBaseFramework = window.minQuery || window.jQuery; (function (a) {
    a.jqx = a.jqx || {};
    a.jqx.define = function (b, c, d) {
        b[c] = function () {
            if (this.baseType) {
                this.base = new b[this.baseType]();
                this.base.defineInstance()
            }
            this.defineInstance()
        };
        b[c].prototype.defineInstance = function () { };
        b[c].prototype.base = null;
        b[c].prototype.baseType = undefined;
        if (d && b[d]) {
            b[c].prototype.baseType = d
        }
    };
    a.jqx.invoke = function (e, d) {
        if (d.length == 0) {
            return
        }
        var f = typeof (d) == Array || d.length > 0 ? d[0] : d;
        var c = typeof (d) == Array || d.length > 1 ? Array.prototype.slice.call(d, 1) : a({}).toArray();
        while (e[f] == undefined && e.base != null) {
            if (e[f] != undefined && a.isFunction(e[f])) {
                return e[f].apply(e, c)
            }
            if (typeof f == "string") {
                var b = f.toLowerCase();
                if (e[b] != undefined && a.isFunction(e[b])) {
                    return e[b].apply(e, c)
                }
            }
            e = e.base
        }
        if (e[f] != undefined && a.isFunction(e[f])) {
            return e[f].apply(e, c)
        }
        if (typeof f == "string") {
            var b = f.toLowerCase();
            if (e[b] != undefined && a.isFunction(e[b])) {
                return e[b].apply(e, c)
            }
        }
        return
    };
    a.jqx.hasProperty = function (c, b) {
        if (typeof (b) == "object") {
            for (var e in b) {
                var d = c;
                while (d) {
                    if (d.hasOwnProperty(e)) {
                        return true
                    }
                    if (d.hasOwnProperty(e.toLowerCase())) {
                        return true
                    }
                    d = d.base
                }
                return false
            }
        } else {
            while (c) {
                if (c.hasOwnProperty(b)) {
                    return true
                }
                if (c.hasOwnProperty(b.toLowerCase())) {
                    return true
                }
                c = c.base
            }
        }
        return false
    };
    a.jqx.hasFunction = function (e, d) {
        if (d.length == 0) {
            return false
        }
        if (e == undefined) {
            return false
        }
        var f = typeof (d) == Array || d.length > 0 ? d[0] : d;
        var c = typeof (d) == Array || d.length > 1 ? Array.prototype.slice.call(d, 1) : {};
        while (e[f] == undefined && e.base != null) {
            if (e[f] && a.isFunction(e[f])) {
                return true
            }
            if (typeof f == "string") {
                var b = f.toLowerCase();
                if (e[b] && a.isFunction(e[b])) {
                    return true
                }
            }
            e = e.base
        }
        if (e[f] && a.isFunction(e[f])) {
            return true
        }
        if (typeof f == "string") {
            var b = f.toLowerCase();
            if (e[b] && a.isFunction(e[b])) {
                return true
            }
        }
        return false
    };
    a.jqx.isPropertySetter = function (c, b) {
        if (b.length == 1 && typeof (b[0]) == "object") {
            return true
        }
        if (b.length == 2 && typeof (b[0]) == "string" && !a.jqx.hasFunction(c, b)) {
            return true
        }
        return false
    };
    a.jqx.validatePropertySetter = function (f, d, b) {
        if (!a.jqx.propertySetterValidation) {
            return true
        }
        if (d.length == 1 && typeof (d[0]) == "object") {
            for (var e in d[0]) {
                var g = f;
                while (!g.hasOwnProperty(e) && g.base) {
                    g = g.base
                }
                if (!g || !g.hasOwnProperty(e)) {
                    if (!b) {
                        var c = g.hasOwnProperty(e.toString().toLowerCase());
                        if (!c) {
                            throw "Invalid property: " + e
                        } else {
                            return true
                        }
                    }
                    return false
                }
            }
            return true
        }
        if (d.length != 2) {
            if (!b) {
                throw "Invalid property: " + d.length >= 0 ? d[0] : ""
            }
            return false
        }
        while (!f.hasOwnProperty(d[0]) && f.base) {
            f = f.base
        }
        if (!f || !f.hasOwnProperty(d[0])) {
            if (!b) {
                throw "Invalid property: " + d[0]
            }
            return false
        }
        return true
    };
    if (!Object.keys) {
        Object.keys = (function () {
            var d = Object.prototype.hasOwnProperty,
            e = !({
                toString: null
            }).propertyIsEnumerable("toString"),
            c = ["toString", "toLocaleString", "valueOf", "hasOwnProperty", "isPrototypeOf", "propertyIsEnumerable", "constructor"],
            b = c.length;
            return function (h) {
                if (typeof h !== "object" && (typeof h !== "function" || h === null)) {
                    throw new TypeError("Object.keys called on non-object")
                }
                var f = [],
                j,
                g;
                for (j in h) {
                    if (d.call(h, j)) {
                        f.push(j)
                    }
                }
                if (e) {
                    for (g = 0; g < b; g++) {
                        if (d.call(h, c[g])) {
                            f.push(c[g])
                        }
                    }
                }
                return f
            }
        }())
    }
    a.jqx.set = function (e, h) {
        var c = 0;
        if (h.length == 1 && typeof (h[0]) == "object") {
            if (e.isInitialized && Object.keys && Object.keys(h[0]).length > 1) {
                var f = !e.base ? e.element : e.base.element;
                var b = a.data(f, e.widgetName).initArgs;
                if (b && JSON && JSON.stringify && h[0] && b[0]) {
                    try {
                        if (JSON.stringify(h[0]) == JSON.stringify(b[0])) {
                            var g = true;
                            a.each(h[0],
                            function (l, m) {
                                if (e[l] != m) {
                                    g = false;
                                    return false
                                }
                            });
                            if (g) {
                                return
                            }
                        }
                    } catch (d) { }
                }
                e.batchUpdate = h[0];
                var j = {};
                var k = {};
                a.each(h[0],
                function (l, m) {
                    var n = e;
                    while (!n.hasOwnProperty(l) && n.base != null) {
                        n = n.base
                    }
                    if (n.hasOwnProperty(l)) {
                        if (e[l] != m) {
                            j[l] = e[l];
                            k[l] = m;
                            c++
                        }
                    } else {
                        if (n.hasOwnProperty(l.toLowerCase())) {
                            if (e[l.toLowerCase()] != m) {
                                j[l.toLowerCase()] = e[l.toLowerCase()];
                                k[l.toLowerCase()] = m;
                                c++
                            }
                        }
                    }
                });
                if (c < 2) {
                    e.batchUpdate = null
                }
            }
            a.each(h[0],
            function (l, m) {
                var n = e;
                while (!n.hasOwnProperty(l) && n.base != null) {
                    n = n.base
                }
                if (n.hasOwnProperty(l)) {
                    a.jqx.setvalueraiseevent(n, l, m)
                } else {
                    if (n.hasOwnProperty(l.toLowerCase())) {
                        a.jqx.setvalueraiseevent(n, l.toLowerCase(), m)
                    } else {
                        if (a.jqx.propertySetterValidation) {
                            throw "jqxCore: invalid property '" + l + "'"
                        }
                    }
                }
            });
            if (e.batchUpdate != null) {
                e.batchUpdate = null;
                if (e.propertiesChangedHandler && c > 1) {
                    e.propertiesChangedHandler(e, j, k)
                }
            }
        } else {
            if (h.length == 2) {
                while (!e.hasOwnProperty(h[0]) && e.base) {
                    e = e.base
                }
                if (e.hasOwnProperty(h[0])) {
                    a.jqx.setvalueraiseevent(e, h[0], h[1])
                } else {
                    if (e.hasOwnProperty(h[0].toLowerCase())) {
                        a.jqx.setvalueraiseevent(e, h[0].toLowerCase(), h[1])
                    } else {
                        if (a.jqx.propertySetterValidation) {
                            throw "jqxCore: invalid property '" + h[0] + "'"
                        }
                    }
                }
            }
        }
    };
    a.jqx.setvalueraiseevent = function (c, d, e) {
        var b = c[d];
        c[d] = e;
        if (!c.isInitialized) {
            return
        }
        if (c.propertyChangedHandler != undefined) {
            c.propertyChangedHandler(c, d, b, e)
        }
        if (c.propertyChangeMap != undefined && c.propertyChangeMap[d] != undefined) {
            c.propertyChangeMap[d](c, d, b, e)
        }
    };
    a.jqx.get = function (e, d) {
        if (d == undefined || d == null) {
            return undefined
        }
        if (e.propertyMap) {
            var c = e.propertyMap(d);
            if (c != null) {
                return c
            }
        }
        if (e.hasOwnProperty(d)) {
            return e[d]
        }
        if (e.hasOwnProperty(d.toLowerCase())) {
            return e[d.toLowerCase()]
        }
        var b = undefined;
        if (typeof (d) == Array) {
            if (d.length != 1) {
                return undefined
            }
            b = d[0]
        } else {
            if (typeof (d) == "string") {
                b = d
            }
        }
        while (!e.hasOwnProperty(b) && e.base) {
            e = e.base
        }
        if (e) {
            return e[b]
        }
        return undefined
    };
    a.jqx.serialize = function (e) {
        var b = "";
        if (a.isArray(e)) {
            b = "[";
            for (var d = 0; d < e.length; d++) {
                if (d > 0) {
                    b += ", "
                }
                b += a.jqx.serialize(e[d])
            }
            b += "]"
        } else {
            if (typeof (e) == "object") {
                b = "{";
                var c = 0;
                for (var d in e) {
                    if (c++ > 0) {
                        b += ", "
                    }
                    b += d + ": " + a.jqx.serialize(e[d])
                }
                b += "}"
            } else {
                b = e.toString()
            }
        }
        return b
    };
    a.jqx.propertySetterValidation = true;
    a.jqx.jqxWidgetProxy = function (g, c, b) {
        var d = a(c);
        var f = a.data(c, g);
        if (f == undefined) {
            return undefined
        }
        var e = f.instance;
        if (a.jqx.hasFunction(e, b)) {
            return a.jqx.invoke(e, b)
        }
        if (a.jqx.isPropertySetter(e, b)) {
            if (a.jqx.validatePropertySetter(e, b)) {
                a.jqx.set(e, b);
                return undefined
            }
        } else {
            if (typeof (b) == "object" && b.length == 0) {
                return
            } else {
                if (typeof (b) == "object" && b.length == 1 && a.jqx.hasProperty(e, b[0])) {
                    return a.jqx.get(e, b[0])
                } else {
                    if (typeof (b) == "string" && a.jqx.hasProperty(e, b[0])) {
                        return a.jqx.get(e, b)
                    }
                }
            }
        }
        throw "jqxCore: Invalid parameter '" + a.jqx.serialize(b) + "' does not exist.";
        return undefined
    };
    a.jqx.applyWidget = function (c, d, k, l) {
        var g = false;
        try {
            g = window.MSApp != undefined
        } catch (f) { }
        var m = a(c);
        if (!l) {
            l = new a.jqx["_" + d]()
        } else {
            l.host = m;
            l.element = c
        }
        if (c.id == "") {
            c.id = a.jqx.utilities.createId()
        }
        var j = {
            host: m,
            element: c,
            instance: l,
            initArgs: k
        };
        l.widgetName = d;
        a.data(c, d, j);
        a.data(c, "jqxWidget", j.instance);
        var h = new Array();
        var l = j.instance;
        while (l) {
            l.isInitialized = false;
            h.push(l);
            l = l.base
        }
        h.reverse();
        h[0].theme = a.jqx.theme || "";
        a.jqx.jqxWidgetProxy(d, c, k);
        for (var b in h) {
            l = h[b];
            if (b == 0) {
                l.host = m;
                l.element = c;
                l.WinJS = g
            }
            if (l != undefined) {
                if (l.definedInstance) {
                    l.definedInstance()
                }
                if (l.createInstance != null) {
                    if (g) {
                        MSApp.execUnsafeLocalFunction(function () {
                            l.createInstance(k)
                        })
                    } else {
                        l.createInstance(k)
                    }
                }
            }
        }
        for (var b in h) {
            if (h[b] != undefined) {
                h[b].isInitialized = true
            }
        }
        if (g) {
            MSApp.execUnsafeLocalFunction(function () {
                j.instance.refresh(true)
            })
        } else {
            j.instance.refresh(true)
        }
    };
    a.jqx.jqxWidget = function (b, c, f) {
        var j = false;
        try {
            jqxArgs = Array.prototype.slice.call(f, 0)
        } catch (h) {
            jqxArgs = ""
        }
        try {
            j = window.MSApp != undefined
        } catch (h) { }
        var g = b;
        var l = "";
        if (c) {
            l = "_" + c
        }
        a.jqx.define(a.jqx, "_" + g, l);
        var k = new Array();
        if (!window[g]) {
            var d = function (m) {
                if (m == null) {
                    return ""
                }
                var e = a.type(m);
                switch (e) {
                    case "string":
                    case "number":
                    case "date":
                    case "boolean":
                    case "bool":
                        if (m === null) {
                            return ""
                        }
                        return m.toString()
                }
                var n = "";
                a.each(m,
                function (p) {
                    var r = this;
                    if (p > 0) {
                        n += ", "
                    }
                    n += "[";
                    var o = 0;
                    if (a.type(r) == "object") {
                        for (var q in r) {
                            if (o > 0) {
                                n += ", "
                            }
                            n += "{" + q + ":" + r[q] + "}";
                            o++
                        }
                    } else {
                        if (o > 0) {
                            n += ", "
                        }
                        n += "{" + p + ":" + r + "}";
                        o++
                    }
                    n += "]"
                });
                return n
            };
            window[g] = function (e, r) {
                var m = [];
                if (!r) {
                    r = {}
                }
                m.push(r);
                var n = e;
                if (a.type(n) === "object" && e[0]) {
                    n = e[0].id;
                    if (n === "") {
                        n = e[0].id = a.jqx.utilities.createId()
                    }
                }
                if (window.jqxWidgets && window.jqxWidgets[n]) {
                    if (r) {
                        a.each(window.jqxWidgets[n],
                        function (s) {
                            var t = a(this.element).data();
                            if (t && t.jqxWidget) {
                                a(this.element)[g](r)
                            }
                        })
                    }
                    if (window.jqxWidgets[n].length == 1) {
                        var p = a(window.jqxWidgets[n][0].widgetInstance.element).data();
                        if (p && p.jqxWidget) {
                            return window.jqxWidgets[n][0]
                        }
                    }
                    var p = a(window.jqxWidgets[n][0].widgetInstance.element).data();
                    if (p && p.jqxWidget) {
                        return window.jqxWidgets[n]
                    }
                }
                var o = a(e);
                if (o.length === 0) {
                    throw new Error("Invalid Selector - " + e + "! Please, check whether the used ID or CSS Class name is correct.")
                }
                var q = [];
                a.each(o,
                function (v) {
                    var x = o[v];
                    var u = null;
                    if (!k[g]) {
                        var y = x.id;
                        x.id = "";
                        u = a(x).clone();
                        x.id = y
                    }
                    a.jqx.applyWidget(x, g, m, undefined);
                    if (!k[g]) {
                        var t = a.data(x, "jqxWidget");
                        var w = u[g]().data().jqxWidget.defineInstance();
                        var s = function (A) {
                            var z = a.data(A, "jqxWidget");
                            this.widgetInstance = z;
                            var B = a.extend(this, z);
                            B.on = function (C, D) {
                                B.addHandler(B.host, C, D)
                            };
                            B.off = function (C) {
                                B.removeHandler(B.host, C)
                            };
                            return B
                        };
                        k[g] = s;
                        a.each(w,
                        function (A, z) {
                            Object.defineProperty(s.prototype, A, {
                                get: function () {
                                    if (this.widgetInstance) {
                                        return this.widgetInstance[A]
                                    }
                                    return z
                                },
                                set: function (C) {
                                    if (this.widgetInstance && this.widgetInstance[A] != C) {
                                        if (this.widgetInstance[A] != C && d(this.widgetInstance[A]) != d(C)) {
                                            var B = {};
                                            B[A] = C;
                                            this.widgetInstance.host[g](B);
                                            this.widgetInstance[A] = C
                                        }
                                    }
                                }
                            })
                        })
                    }
                    var t = new k[g](x);
                    q.push(t);
                    if (!window.jqxWidgets) {
                        window.jqxWidgets = new Array()
                    }
                    if (!window.jqxWidgets[n]) {
                        window.jqxWidgets[n] = new Array()
                    }
                    window.jqxWidgets[n].push(t)
                });
                if (q.length === 1) {
                    return q[0]
                }
                return q
            }
        }
        a.fn[g] = function () {
            var e = Array.prototype.slice.call(arguments, 0);
            if (e.length == 0 || (e.length == 1 && typeof (e[0]) == "object")) {
                if (this.length == 0) {
                    if (this.selector) {
                        throw new Error("Invalid Selector - " + this.selector + "! Please, check whether the used ID or CSS Class name is correct.")
                    } else {
                        throw new Error("Invalid Selector! Please, check whether the used ID or CSS Class name is correct.")
                    }
                }
                return this.each(function () {
                    var p = a(this);
                    var o = this;
                    var q = a.data(o, g);
                    if (q == null) {
                        a.jqx.applyWidget(o, g, e, undefined)
                    } else {
                        a.jqx.jqxWidgetProxy(g, this, e)
                    }
                })
            } else {
                if (this.length == 0) {
                    if (this.selector) {
                        throw new Error("Invalid Selector - " + this.selector + "! Please, check whether the used ID or CSS Class name is correct.")
                    } else {
                        throw new Error("Invalid Selector! Please, check whether the used ID or CSS Class name is correct.")
                    }
                }
                var n = null;
                var m = 0;
                this.each(function () {
                    var o = a.jqx.jqxWidgetProxy(g, this, e);
                    if (m == 0) {
                        n = o;
                        m++
                    } else {
                        if (m == 1) {
                            var p = [];
                            p.push(n);
                            n = p
                        }
                        n.push(o)
                    }
                })
            }
            return n
        };
        try {
            a.extend(a.jqx["_" + g].prototype, Array.prototype.slice.call(f, 0)[0])
        } catch (h) { }
        a.extend(a.jqx["_" + g].prototype, {
            toThemeProperty: function (e, m) {
                return a.jqx.toThemeProperty(this, e, m)
            }
        });
        a.jqx["_" + g].prototype.refresh = function () {
            if (this.base) {
                this.base.refresh(true)
            }
        };
        a.jqx["_" + g].prototype.createInstance = function () { };
        a.jqx["_" + g].prototype.applyTo = function (n, m) {
            if (!(m instanceof Array)) {
                var e = [];
                e.push(m);
                m = e
            }
            a.jqx.applyWidget(n, g, m, this)
        };
        a.jqx["_" + g].prototype.getInstance = function () {
            return this
        };
        a.jqx["_" + g].prototype.propertyChangeMap = {};
        a.jqx["_" + g].prototype.addHandler = function (o, e, m, n) {
            a.jqx.addHandler(o, e, m, n)
        };
        a.jqx["_" + g].prototype.removeHandler = function (n, e, m) {
            a.jqx.removeHandler(n, e, m)
        }
    };
    a.jqx.toThemeProperty = function (c, d, h) {
        if (c.theme == "") {
            return d
        }
        var g = d.split(" ");
        var b = "";
        for (var f = 0; f < g.length; f++) {
            if (f > 0) {
                b += " "
            }
            var e = g[f];
            if (h != null && h) {
                b += e + "-" + c.theme
            } else {
                b += e + " " + e + "-" + c.theme
            }
        }
        return b
    };
    a.jqx.addHandler = function (g, h, e, f) {
        var c = h.split(" ");
        for (var b = 0; b < c.length; b++) {
            var d = c[b];
            if (window.addEventListener) {
                switch (d) {
                    case "mousewheel":
                        if (a.jqx.browser.mozilla) {
                            g[0].addEventListener("DOMMouseScroll", e, false)
                        } else {
                            g[0].addEventListener("mousewheel", e, false)
                        }
                        continue;
                    case "mousemove":
                        if (!f) {
                            g[0].addEventListener("mousemove", e, false);
                            continue
                        }
                        break
                }
            }
            if (f == undefined || f == null) {
                if (g.on) {
                    g.on(d, e)
                } else {
                    g.bind(d, e)
                }
            } else {
                if (g.on) {
                    g.on(d, f, e)
                } else {
                    g.bind(d, f, e)
                }
            }
        }
    };
    a.jqx.removeHandler = function (f, g, e) {
        if (!g) {
            if (f.off) {
                f.off()
            } else {
                f.unbind()
            }
            return
        }
        var c = g.split(" ");
        for (var b = 0; b < c.length; b++) {
            var d = c[b];
            if (window.removeEventListener) {
                switch (d) {
                    case "mousewheel":
                        if (a.jqx.browser.mozilla) {
                            f[0].removeEventListener("DOMMouseScroll", e, false)
                        } else {
                            f[0].removeEventListener("mousewheel", e, false)
                        }
                        continue;
                    case "mousemove":
                        if (e) {
                            f[0].removeEventListener("mousemove", e, false);
                            continue
                        }
                        break
                }
            }
            if (d == undefined) {
                if (f.off) {
                    f.off()
                } else {
                    f.unbind()
                }
                continue
            }
            if (e == undefined) {
                if (f.off) {
                    f.off(d)
                } else {
                    f.unbind(d)
                }
            } else {
                if (f.off) {
                    f.off(d, e)
                } else {
                    f.unbind(d, e)
                }
            }
        }
    };
    a.jqx.theme = a.jqx.theme || "";
    a.jqx.scrollAnimation = a.jqx.scrollAnimation || false;
    a.jqx.resizeDelay = a.jqx.resizeDelay || 10;
    a.jqx.ready = function () {
        a(window).trigger("jqxReady")
    };
    a.jqx.init = function () {
        a.each(arguments[0],
        function (b, c) {
            if (b == "theme") {
                a.jqx.theme = c
            }
            if (b == "scrollBarSize") {
                a.jqx.utilities.scrollBarSize = c
            }
            if (b == "touchScrollBarSize") {
                a.jqx.utilities.touchScrollBarSize = c
            }
            if (b == "scrollBarButtonsVisibility") {
                a.jqx.utilities.scrollBarButtonsVisibility = c
            }
        })
    };
    a.jqx.utilities = a.jqx.utilities || {};
    a.extend(a.jqx.utilities, {
        scrollBarSize: 15,
        touchScrollBarSize: 0,
        scrollBarButtonsVisibility: "visible",
        createId: function () {
            var b = function () {
                return (((1 + Math.random()) * 65536) | 0).toString(16).substring(1)
            };
            return "jqxWidget" + b() + b()
        },
        setTheme: function (f, g, e) {
            if (typeof e === "undefined") {
                return
            }
            var h = e[0].className.split(" "),
            b = [],
            j = [],
            d = e.children();
            for (var c = 0; c < h.length; c += 1) {
                if (h[c].indexOf(f) >= 0) {
                    if (f.length > 0) {
                        b.push(h[c]);
                        j.push(h[c].replace(f, g))
                    } else {
                        j.push(h[c].replace("-" + g, "") + "-" + g)
                    }
                }
            }
            this._removeOldClasses(b, e);
            this._addNewClasses(j, e);
            for (var c = 0; c < d.length; c += 1) {
                this.setTheme(f, g, a(d[c]))
            }
        },
        _removeOldClasses: function (d, c) {
            for (var b = 0; b < d.length; b += 1) {
                c.removeClass(d[b])
            }
        },
        _addNewClasses: function (d, c) {
            for (var b = 0; b < d.length; b += 1) {
                c.addClass(d[b])
            }
        },
        getOffset: function (b) {
            var d = a.jqx.mobile.getLeftPos(b[0]);
            var c = a.jqx.mobile.getTopPos(b[0]);
            return {
                top: c,
                left: d
            }
        },
        resize: function (g, s, p, o) {
            if (o === undefined) {
                o = true
            }
            var l = -1;
            var k = this;
            var d = function (u) {
                if (!k.hiddenWidgets) {
                    return -1
                }
                var v = -1;
                for (var t = 0; t < k.hiddenWidgets.length; t++) {
                    if (u.id) {
                        if (k.hiddenWidgets[t].id == u.id) {
                            v = t;
                            break
                        }
                    } else {
                        if (k.hiddenWidgets[t].id == u[0].id) {
                            v = t;
                            break
                        }
                    }
                }
                return v
            };
            if (this.resizeHandlers) {
                for (var h = 0; h < this.resizeHandlers.length; h++) {
                    if (g.id) {
                        if (this.resizeHandlers[h].id == g.id) {
                            l = h;
                            break
                        }
                    } else {
                        if (this.resizeHandlers[h].id == g[0].id) {
                            l = h;
                            break
                        }
                    }
                }
                if (p === true) {
                    if (l != -1) {
                        this.resizeHandlers.splice(l, 1)
                    }
                    if (this.resizeHandlers.length == 0) {
                        var n = a(window);
                        if (n.off) {
                            n.off("resize.jqx");
                            n.off("orientationchange.jqx");
                            n.off("orientationchanged.jqx")
                        } else {
                            n.unbind("resize.jqx");
                            n.unbind("orientationchange.jqx");
                            n.unbind("orientationchanged.jqx")
                        }
                        this.resizeHandlers = null
                    }
                    var b = d(g);
                    if (b != -1 && this.hiddenWidgets) {
                        this.hiddenWidgets.splice(b, 1)
                    }
                    return
                }
            } else {
                if (p === true) {
                    var b = d(g);
                    if (b != -1 && this.hiddenWidgets) {
                        this.hiddenWidgets.splice(b, 1)
                    }
                    return
                }
            }
            var k = this;
            var m = function (v, D) {
                if (!k.resizeHandlers) {
                    return
                }
                var E = function (I) {
                    var H = -1;
                    var J = I.parentNode;
                    while (J) {
                        H++;
                        J = J.parentNode
                    }
                    return H
                };
                var u = function (K, I) {
                    if (!K.widget || !I.widget) {
                        return 0
                    }
                    var J = E(K.widget[0]);
                    var H = E(I.widget[0]);
                    try {
                        if (J < H) {
                            return -1
                        }
                        if (J > H) {
                            return 1
                        }
                    } catch (L) {
                        var M = L
                    }
                    return 0
                };
                var w = function (I) {
                    if (k.hiddenWidgets.length > 0) {
                        k.hiddenWidgets.sort(u);
                        var H = function () {
                            var K = false;
                            var M = new Array();
                            for (var L = 0; L < k.hiddenWidgets.length; L++) {
                                var J = k.hiddenWidgets[L];
                                if (a.jqx.isHidden(J.widget)) {
                                    K = true;
                                    M.push(J)
                                } else {
                                    if (J.callback) {
                                        J.callback(D)
                                    }
                                }
                            }
                            k.hiddenWidgets = M;
                            if (!K) {
                                clearInterval(k.__resizeInterval)
                            }
                        };
                        if (I == false) {
                            H();
                            if (k.__resizeInterval) {
                                clearInterval(k.__resizeInterval)
                            }
                            return
                        }
                        if (k.__resizeInterval) {
                            clearInterval(k.__resizeInterval)
                        }
                        k.__resizeInterval = setInterval(function () {
                            H()
                        },
                        100)
                    }
                };
                if (k.hiddenWidgets && k.hiddenWidgets.length > 0) {
                    w(false)
                }
                k.hiddenWidgets = new Array();
                k.resizeHandlers.sort(u);
                for (var A = 0; A < k.resizeHandlers.length; A++) {
                    var G = k.resizeHandlers[A];
                    var C = G.widget;
                    var z = G.data;
                    if (!z) {
                        continue
                    }
                    if (!z.jqxWidget) {
                        continue
                    }
                    var t = z.jqxWidget.width;
                    var F = z.jqxWidget.height;
                    if (z.jqxWidget.base) {
                        if (t == undefined) {
                            t = z.jqxWidget.base.width
                        }
                        if (F == undefined) {
                            F = z.jqxWidget.base.height
                        }
                    }
                    if (t === undefined && F === undefined) {
                        t = z.jqxWidget.element.style.width;
                        F = z.jqxWidget.element.style.height
                    }
                    var B = false;
                    if (t != null && t.toString().indexOf("%") != -1) {
                        B = true
                    }
                    if (F != null && F.toString().indexOf("%") != -1) {
                        B = true
                    }
                    if (a.jqx.isHidden(C)) {
                        if (d(C) === -1) {
                            if (B || v === true) {
                                if (G.data.nestedWidget !== true) {
                                    k.hiddenWidgets.push(G)
                                }
                            }
                        }
                    } else {
                        if (v === undefined || v !== true) {
                            if (B) {
                                G.callback(D);
                                if (k.hiddenWidgets.indexOf(G) >= 0) {
                                    k.hiddenWidgets.splice(k.hiddenWidgets.indexOf(G), 1)
                                }
                            }
                            if (z.jqxWidget.element) {
                                var x = z.jqxWidget.element.className;
                                if (x.indexOf("dropdownlist") >= 0 || x.indexOf("datetimeinput") >= 0 || x.indexOf("combobox") >= 0 || x.indexOf("menu") >= 0) {
                                    if (z.jqxWidget.isOpened) {
                                        var y = z.jqxWidget.isOpened();
                                        if (y) {
                                            if (D && D == "resize" && a.jqx.mobile.isTouchDevice()) {
                                                continue
                                            }
                                            z.jqxWidget.close()
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                w()
            };
            if (!this.resizeHandlers) {
                this.resizeHandlers = new Array();
                var n = a(window);
                if (n.on) {
                    this._resizeTimer = null;
                    this._initResize = null;
                    n.on("resize.jqx",
                    function (t) {
                        if (k._resizeTimer != undefined) {
                            clearTimeout(k._resizeTimer)
                        }
                        if (!k._initResize) {
                            k._initResize = true;
                            m(null, "resize")
                        } else {
                            k._resizeTimer = setTimeout(function () {
                                m(null, "resize")
                            },
                            a.jqx.resizeDelay)
                        }
                    });
                    n.on("orientationchange.jqx",
                    function (t) {
                        m(null, "orientationchange")
                    });
                    n.on("orientationchanged.jqx",
                    function (t) {
                        m(null, "orientationchange")
                    })
                } else {
                    n.bind("resize.jqx",
                    function (t) {
                        m(null, "orientationchange")
                    });
                    n.bind("orientationchange.jqx",
                    function (t) {
                        m(null, "orientationchange")
                    });
                    n.bind("orientationchanged.jqx",
                    function (t) {
                        m(null, "orientationchange")
                    })
                }
            }
            var e = g.data();
            if (o) {
                if (l === -1) {
                    this.resizeHandlers.push({
                        id: g[0].id,
                        widget: g,
                        callback: s,
                        data: e
                    })
                }
            }
            try {
                var c = e.jqxWidget.width;
                var r = e.jqxWidget.height;
                if (e.jqxWidget.base) {
                    if (c == undefined) {
                        c = e.jqxWidget.base.width
                    }
                    if (r == undefined) {
                        r = e.jqxWidget.base.height
                    }
                }
                if (c === undefined && r === undefined) {
                    c = e.jqxWidget.element.style.width;
                    r = e.jqxWidget.element.style.height
                }
                var j = false;
                if (c != null && c.toString().indexOf("%") != -1) {
                    j = true
                }
                if (r != null && r.toString().indexOf("%") != -1) {
                    j = true
                }
                if (j) {
                    if (!this.watchedElementData) {
                        this.watchedElementData = []
                    }
                    var k = this;
                    var f = function (t) {
                        if (k.watchedElementData.forEach) {
                            k.watchedElementData.forEach(function (u) {
                                if (u.element.offsetWidth !== u.offsetWidth || u.element.offsetHeight !== u.offsetHeight) {
                                    u.offsetWidth = u.element.offsetWidth;
                                    u.offsetHeight = u.element.offsetHeight;
                                    if (u.timer) {
                                        clearTimeout(u.timer)
                                    }
                                    u.timer = setTimeout(function () {
                                        if (!a.jqx.isHidden(a(u.element))) {
                                            u.callback()
                                        }
                                    })
                                }
                            })
                        }
                    };
                    k.watchedElementData.push({
                        element: g[0],
                        offsetWidth: g[0].offsetWidth,
                        offsetHeight: g[0].offsetHeight,
                        callback: s
                    });
                    if (!k.observer) {
                        k.observer = new MutationObserver(f);
                        k.observer.observe(document.body, {
                            attributes: true,
                            childList: true,
                            characterData: true
                        })
                    }
                }
            } catch (q) { }
            if (a.jqx.isHidden(g) && o === true) {
                m(true)
            }
            a.jqx.resize = function () {
                m(null, "resize")
            }
        },
        html: function (c, d) {
            if (!a(c).on) {
                return a(c).html(d)
            }
            try {
                return a.access(c,
                function (s) {
                    var f = c[0] || {},
                    m = 0,
                    j = c.length;
                    if (s === undefined) {
                        return f.nodeType === 1 ? f.innerHTML.replace(rinlinejQuery, "") : undefined
                    }
                    var r = /<(?:script|style|link)/i,
                    n = "abbr|article|aside|audio|bdi|canvas|data|datalist|details|figcaption|figure|footer|header|hgroup|mark|meter|nav|output|progress|section|summary|time|video",
                    h = /<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\w:]+)[^>]*)\/>/gi,
                    p = /<([\w:]+)/,
                    g = /<(?:script|object|embed|option|style)/i,
                    k = new RegExp("<(?:" + n + ")[\\s/>]", "i"),
                    q = /^\s+/,
                    t = {
                        option: [1, "<select multiple='multiple'>", "</select>"],
                        legend: [1, "<fieldset>", "</fieldset>"],
                        thead: [1, "<table>", "</table>"],
                        tr: [2, "<table><tbody>", "</tbody></table>"],
                        td: [3, "<table><tbody><tr>", "</tr></tbody></table>"],
                        col: [2, "<table><tbody></tbody><colgroup>", "</colgroup></table>"],
                        area: [1, "<map>", "</map>"],
                        _default: [0, "", ""]
                    };
                    if (typeof s === "string" && !r.test(s) && (a.support.htmlSerialize || !k.test(s)) && (a.support.leadingWhitespace || !q.test(s)) && !t[(p.exec(s) || ["", ""])[1].toLowerCase()]) {
                        s = s.replace(h, "<$1></$2>");
                        try {
                            for (; m < j; m++) {
                                f = this[m] || {};
                                if (f.nodeType === 1) {
                                    a.cleanData(f.getElementsByTagName("*"));
                                    f.innerHTML = s
                                }
                            }
                            f = 0
                        } catch (o) { }
                    }
                    if (f) {
                        c.empty().append(s)
                    }
                },
                null, d, arguments.length)
            } catch (b) {
                return a(c).html(d)
            }
        },
        hasTransform: function (d) {
            var c = "";
            c = d.css("transform");
            if (c == "" || c == "none") {
                c = d.parents().css("transform");
                if (c == "" || c == "none") {
                    var b = a.jqx.utilities.getBrowser();
                    if (b.browser == "msie") {
                        c = d.css("-ms-transform");
                        if (c == "" || c == "none") {
                            c = d.parents().css("-ms-transform")
                        }
                    } else {
                        if (b.browser == "chrome") {
                            c = d.css("-webkit-transform");
                            if (c == "" || c == "none") {
                                c = d.parents().css("-webkit-transform")
                            }
                        } else {
                            if (b.browser == "opera") {
                                c = d.css("-o-transform");
                                if (c == "" || c == "none") {
                                    c = d.parents().css("-o-transform")
                                }
                            } else {
                                if (b.browser == "mozilla") {
                                    c = d.css("-moz-transform");
                                    if (c == "" || c == "none") {
                                        c = d.parents().css("-moz-transform")
                                    }
                                }
                            }
                        }
                    }
                } else {
                    return c != "" && c != "none"
                }
            }
            if (c == "" || c == "none") {
                c = a(document.body).css("transform")
            }
            return c != "" && c != "none" && c != null
        },
        getBrowser: function () {
            var c = navigator.userAgent.toLowerCase();
            var b = /(chrome)[ \/]([\w.]+)/.exec(c) || /(webkit)[ \/]([\w.]+)/.exec(c) || /(opera)(?:.*version|)[ \/]([\w.]+)/.exec(c) || /(msie) ([\w.]+)/.exec(c) || c.indexOf("compatible") < 0 && /(mozilla)(?:.*? rv:([\w.]+)|)/.exec(c) || [];
            var d = {
                browser: b[1] || "",
                version: b[2] || "0"
            };
            if (c.indexOf("rv:11.0") >= 0 && c.indexOf(".net4.0c") >= 0) {
                d.browser = "msie";
                d.version = "11";
                b[1] = "msie"
            }
            if (c.indexOf("edge") >= 0) {
                d.browser = "msie";
                d.version = "12";
                b[1] = "msie"
            }
            d[b[1]] = b[1];
            return d
        }
    });
    a.jqx.browser = a.jqx.utilities.getBrowser();
    a.jqx.isHidden = function (c) {
        if (!c || !c[0]) {
            return false
        }
        var b = c[0].offsetWidth,
        d = c[0].offsetHeight;
        if (b === 0 || d === 0) {
            return true
        } else {
            return false
        }
    };
    a.jqx.ariaEnabled = true;
    a.jqx.aria = function (c, e, d) {
        if (!a.jqx.ariaEnabled) {
            return
        }
        if (e == undefined) {
            a.each(c.aria,
            function (g, h) {
                var k = !c.base ? c.host.attr(g) : c.base.host.attr(g);
                if (k != undefined && !a.isFunction(k)) {
                    var j = k;
                    switch (h.type) {
                        case "number":
                            j = new Number(k);
                            if (isNaN(j)) {
                                j = k
                            }
                            break;
                        case "boolean":
                            j = k == "true" ? true : false;
                            break;
                        case "date":
                            j = new Date(k);
                            if (j == "Invalid Date" || isNaN(j)) {
                                j = k
                            }
                            break
                    }
                    c[h.name] = j
                } else {
                    var k = c[h.name];
                    if (a.isFunction(k)) {
                        k = c[h.name]()
                    }
                    if (k == undefined) {
                        k = ""
                    }
                    try {
                        !c.base ? c.host.attr(g, k.toString()) : c.base.host.attr(g, k.toString())
                    } catch (f) { }
                }
            })
        } else {
            try {
                if (c.host) {
                    if (!c.base) {
                        if (c.host) {
                            if (c.element.setAttribute) {
                                c.element.setAttribute(e, d.toString())
                            } else {
                                c.host.attr(e, d.toString())
                            }
                        } else {
                            c.attr(e, d.toString())
                        }
                    } else {
                        if (c.base.host) {
                            c.base.host.attr(e, d.toString())
                        } else {
                            c.attr(e, d.toString())
                        }
                    }
                } else {
                    if (c.setAttribute) {
                        c.setAttribute(e, d.toString())
                    }
                }
            } catch (b) { }
        }
    };
    if (!Array.prototype.indexOf) {
        Array.prototype.indexOf = function (c) {
            var b = this.length;
            var d = Number(arguments[1]) || 0;
            d = (d < 0) ? Math.ceil(d) : Math.floor(d);
            if (d < 0) {
                d += b
            }
            for (; d < b; d++) {
                if (d in this && this[d] === c) {
                    return d
                }
            }
            return -1
        }
    }
    a.jqx.mobile = a.jqx.mobile || {};
    a.jqx.position = function (b) {
        var e = parseInt(b.pageX);
        var d = parseInt(b.pageY);
        if (a.jqx.mobile.isTouchDevice()) {
            var c = a.jqx.mobile.getTouches(b);
            var f = c[0];
            e = parseInt(f.pageX);
            d = parseInt(f.pageY)
        }
        return {
            left: e,
            top: d
        }
    };
    a.extend(a.jqx.mobile, {
        _touchListener: function (h, f) {
            var b = function (j, l) {
                var k = document.createEvent("MouseEvents");
                k.initMouseEvent(j, l.bubbles, l.cancelable, l.view, l.detail, l.screenX, l.screenY, l.clientX, l.clientY, l.ctrlKey, l.altKey, l.shiftKey, l.metaKey, l.button, l.relatedTarget);
                k._pageX = l.pageX;
                k._pageY = l.pageY;
                return k
            };
            var g = {
                mousedown: "touchstart",
                mouseup: "touchend",
                mousemove: "touchmove"
            };
            var d = b(g[h.type], h);
            h.target.dispatchEvent(d);
            var c = h.target["on" + g[h.type]];
            if (typeof c === "function") {
                c(h)
            }
        },
        setMobileSimulator: function (c, e) {
            if (this.isTouchDevice()) {
                return
            }
            this.simulatetouches = true;
            if (e == false) {
                this.simulatetouches = false
            }
            var d = {
                mousedown: "touchstart",
                mouseup: "touchend",
                mousemove: "touchmove"
            };
            var b = this;
            if (window.addEventListener) {
                var f = function () {
                    for (var g in d) {
                        if (c.addEventListener) {
                            c.removeEventListener(g, b._touchListener);
                            c.addEventListener(g, b._touchListener, false)
                        }
                    }
                };
                if (a.jqx.browser.msie) {
                    f()
                } else {
                    f()
                }
            }
        },
        isTouchDevice: function () {
            if (this.touchDevice != undefined) {
                return this.touchDevice
            }
            var c = "Browser CodeName: " + navigator.appCodeName + "";
            c += "Browser Name: " + navigator.appName + "";
            c += "Browser Version: " + navigator.appVersion + "";
            c += "Platform: " + navigator.platform + "";
            c += "User-agent header: " + navigator.userAgent + "";
            if (c.indexOf("Android") != -1) {
                return true
            }
            if (c.indexOf("IEMobile") != -1) {
                return true
            }
            if (c.indexOf("Windows Phone") != -1) {
                return true
            }
            if (c.indexOf("WPDesktop") != -1) {
                return true
            }
            if (c.indexOf("ZuneWP7") != -1) {
                return true
            }
            if (c.indexOf("BlackBerry") != -1 && c.indexOf("Mobile Safari") != -1) {
                return true
            }
            if (c.indexOf("ipod") != -1) {
                return true
            }
            if (c.indexOf("nokia") != -1 || c.indexOf("Nokia") != -1) {
                return true
            }
            if (c.indexOf("Chrome/17") != -1) {
                return false
            }
            if (c.indexOf("CrOS") != -1) {
                return false
            }
            if (c.indexOf("Opera") != -1 && c.indexOf("Mobi") == -1 && c.indexOf("Mini") == -1 && c.indexOf("Platform: Win") != -1) {
                return false
            }
            if (c.indexOf("Opera") != -1 && c.indexOf("Mobi") != -1 && c.indexOf("Opera Mobi") != -1) {
                return true
            }
            var d = {
                ios: "i(?:Pad|Phone|Pod)(?:.*)CPU(?: iPhone)? OS ",
                android: "(Android |HTC_|Silk/)",
                blackberry: "BlackBerry(?:.*)Version/",
                rimTablet: "RIM Tablet OS ",
                webos: "(?:webOS|hpwOS)/",
                bada: "Bada/"
            };
            try {
                if (this.touchDevice != undefined) {
                    return this.touchDevice
                }
                this.touchDevice = false;
                for (i in d) {
                    if (d.hasOwnProperty(i)) {
                        prefix = d[i];
                        match = c.match(new RegExp("(?:" + prefix + ")([^\\s;]+)"));
                        if (match) {
                            if (i.toString() == "blackberry") {
                                this.touchDevice = false;
                                return false
                            }
                            this.touchDevice = true;
                            return true
                        }
                    }
                }
                var f = navigator.userAgent;
                if (navigator.platform.toLowerCase().indexOf("win") != -1) {
                    if (f.indexOf("Windows Phone") >= 0 || f.indexOf("WPDesktop") >= 0 || f.indexOf("IEMobile") >= 0 || f.indexOf("ZuneWP7") >= 0) {
                        this.touchDevice = true;
                        return true
                    } else {
                        if (f.indexOf("Touch") >= 0) {
                            var b = ("MSPointerDown" in window) || ("pointerdown" in window);
                            if (b) {
                                this.touchDevice = true;
                                return true
                            }
                            if (f.indexOf("ARM") >= 0) {
                                this.touchDevice = true;
                                return true
                            }
                            this.touchDevice = false;
                            return false
                        }
                    }
                }
                if (navigator.platform.toLowerCase().indexOf("win") != -1) {
                    this.touchDevice = false;
                    return false
                }
                if (("ontouchstart" in window) || window.DocumentTouch && document instanceof DocumentTouch) {
                    this.touchDevice = true
                }
                return this.touchDevice
            } catch (g) {
                this.touchDevice = false;
                return false
            }
        },
        getLeftPos: function (b) {
            var c = b.offsetLeft;
            while ((b = b.offsetParent) != null) {
                if (b.tagName != "HTML") {
                    c += b.offsetLeft;
                    if (document.all) {
                        c += b.clientLeft
                    }
                }
            }
            return c
        },
        getTopPos: function (c) {
            var e = c.offsetTop;
            var b = a(c).coord();
            while ((c = c.offsetParent) != null) {
                if (c.tagName != "HTML") {
                    e += (c.offsetTop - c.scrollTop);
                    if (document.all) {
                        e += c.clientTop
                    }
                }
            }
            var d = navigator.userAgent.toLowerCase();
            var f = (d.indexOf("windows phone") != -1 || d.indexOf("WPDesktop") != -1 || d.indexOf("ZuneWP7") != -1 || d.indexOf("msie 9") != -1 || d.indexOf("msie 11") != -1 || d.indexOf("msie 10") != -1) && d.indexOf("touch") != -1;
            if (f) {
                return b.top
            }
            if (this.isSafariMobileBrowser()) {
                if (this.isSafari4MobileBrowser() && this.isIPadSafariMobileBrowser()) {
                    return e
                }
                if (d.indexOf("version/7") != -1) {
                    return b.top
                }
                if (d.indexOf("version/6") != -1 || d.indexOf("version/5") != -1) {
                    e = e + a(window).scrollTop()
                }
                if (/(Android.*Chrome\/[.0-9]* (!?Mobile))/.exec(navigator.userAgent)) {
                    return e + a(window).scrollTop()
                }
                if (/(Android.*Chrome\/[.0-9]* Mobile)/.exec(navigator.userAgent)) {
                    return e + a(window).scrollTop()
                }
                return b.top
            }
            return e
        },
        isChromeMobileBrowser: function () {
            var c = navigator.userAgent.toLowerCase();
            var b = c.indexOf("android") != -1;
            return b
        },
        isOperaMiniMobileBrowser: function () {
            var c = navigator.userAgent.toLowerCase();
            var b = c.indexOf("opera mini") != -1 || c.indexOf("opera mobi") != -1;
            return b
        },
        isOperaMiniBrowser: function () {
            var c = navigator.userAgent.toLowerCase();
            var b = c.indexOf("opera mini") != -1;
            return b
        },
        isNewSafariMobileBrowser: function () {
            var c = navigator.userAgent.toLowerCase();
            var b = c.indexOf("ipad") != -1 || c.indexOf("iphone") != -1 || c.indexOf("ipod") != -1;
            b = b && (c.indexOf("version/5") != -1);
            return b
        },
        isSafari4MobileBrowser: function () {
            var c = navigator.userAgent.toLowerCase();
            var b = c.indexOf("ipad") != -1 || c.indexOf("iphone") != -1 || c.indexOf("ipod") != -1;
            b = b && (c.indexOf("version/4") != -1);
            return b
        },
        isWindowsPhone: function () {
            var c = navigator.userAgent.toLowerCase();
            var b = (c.indexOf("windows phone") != -1 || c.indexOf("WPDesktop") != -1 || c.indexOf("ZuneWP7") != -1 || c.indexOf("msie 9") != -1 || c.indexOf("msie 11") != -1 || c.indexOf("msie 10") != -1 && c.indexOf("touch") != -1);
            return b
        },
        isSafariMobileBrowser: function () {
            var c = navigator.userAgent.toLowerCase();
            if (/(Android.*Chrome\/[.0-9]* (!?Mobile))/.exec(navigator.userAgent)) {
                return true
            }
            if (/(Android.*Chrome\/[.0-9]* Mobile)/.exec(navigator.userAgent)) {
                return true
            }
            var b = c.indexOf("ipad") != -1 || c.indexOf("iphone") != -1 || c.indexOf("ipod") != -1 || c.indexOf("mobile safari") != -1;
            return b
        },
        isIPadSafariMobileBrowser: function () {
            var c = navigator.userAgent.toLowerCase();
            var b = c.indexOf("ipad") != -1;
            return b
        },
        isMobileBrowser: function () {
            var c = navigator.userAgent.toLowerCase();
            var b = c.indexOf("ipad") != -1 || c.indexOf("iphone") != -1 || c.indexOf("android") != -1;
            return b
        },
        getTouches: function (b) {
            if (b.originalEvent) {
                if (b.originalEvent.touches && b.originalEvent.touches.length) {
                    return b.originalEvent.touches
                } else {
                    if (b.originalEvent.changedTouches && b.originalEvent.changedTouches.length) {
                        return b.originalEvent.changedTouches
                    }
                }
            }
            if (!b.touches) {
                b.touches = new Array();
                b.touches[0] = b.originalEvent != undefined ? b.originalEvent : b;
                if (b.originalEvent != undefined && b.pageX) {
                    b.touches[0] = b
                }
                if (b.type == "mousemove") {
                    b.touches[0] = b
                }
            }
            return b.touches
        },
        getTouchEventName: function (b) {
            if (this.isWindowsPhone()) {
                var c = navigator.userAgent.toLowerCase();
                if (c.indexOf("windows phone 7") != -1) {
                    if (b.toLowerCase().indexOf("start") != -1) {
                        return "MSPointerDown"
                    }
                    if (b.toLowerCase().indexOf("move") != -1) {
                        return "MSPointerMove"
                    }
                    if (b.toLowerCase().indexOf("end") != -1) {
                        return "MSPointerUp"
                    }
                }
                if (b.toLowerCase().indexOf("start") != -1) {
                    return "pointerdown"
                }
                if (b.toLowerCase().indexOf("move") != -1) {
                    return "pointermove"
                }
                if (b.toLowerCase().indexOf("end") != -1) {
                    return "pointerup"
                }
            } else {
                return b
            }
        },
        dispatchMouseEvent: function (b, f, d) {
            if (this.simulatetouches) {
                return
            }
            var c = document.createEvent("MouseEvent");
            c.initMouseEvent(b, true, true, f.view, 1, f.screenX, f.screenY, f.clientX, f.clientY, false, false, false, false, 0, null);
            if (d != null) {
                d.dispatchEvent(c)
            }
        },
        getRootNode: function (b) {
            while (b.nodeType !== 1) {
                b = b.parentNode
            }
            return b
        },
        setTouchScroll: function (b, c) {
            if (!this.enableScrolling) {
                this.enableScrolling = []
            }
            this.enableScrolling[c] = b
        },
        touchScroll: function (B, M, W, H, x, m) {
            if (B == null) {
                return
            }
            var G = this;
            var e = 0;
            var q = 0;
            var f = 0;
            var g = 0;
            var s = 0;
            var h = 0;
            if (!this.scrolling) {
                this.scrolling = []
            }
            this.scrolling[H] = false;
            var j = false;
            var o = a(B);
            var Q = ["select", "input", "textarea"];
            var U = 0;
            var J = 0;
            if (!this.enableScrolling) {
                this.enableScrolling = []
            }
            this.enableScrolling[H] = true;
            var H = H;
            var u = this.getTouchEventName("touchstart") + ".touchScroll";
            var D = this.getTouchEventName("touchend") + ".touchScroll";
            var Y = this.getTouchEventName("touchmove") + ".touchScroll";
            var k, T, z, V, ad, P, X, c, F, aa, t, d, w, v, R, b, E, ac, n;
            P = M;
            ad = 0;
            X = 0;
            xoffset = 0;
            initialOffset = 0;
            initialXOffset = 0;
            V = x.jqxScrollBar("max");
            n = 325;
            function A(ag) {
                if (ag.targetTouches && (ag.targetTouches.length >= 1)) {
                    return ag.targetTouches[0].clientY
                } else {
                    if (ag.originalEvent && ag.originalEvent.clientY !== undefined) {
                        return ag.originalEvent.clientY
                    } else {
                        var af = G.getTouches(ag);
                        return af[0].clientY
                    }
                }
                return ag.clientY
            }
            function ab(ag) {
                if (ag.targetTouches && (ag.targetTouches.length >= 1)) {
                    return ag.targetTouches[0].clientX
                } else {
                    if (ag.originalEvent && ag.originalEvent.clientX !== undefined) {
                        return ag.originalEvent.clientX
                    } else {
                        var af = G.getTouches(ag);
                        return af[0].clientX
                    }
                }
                return ag.clientX
            }
            var I = function () {
                var ah, af, ai, ag;
                ah = Date.now();
                af = ah - w;
                w = ah;
                ai = X - d;
                xdelta = xoffset - xframe;
                d = X;
                xframe = xoffset;
                F = true;
                ag = 1000 * ai / (1 + af);
                xv = 1000 * xdelta / (1 + af);
                t = 0.8 * ag + 0.2 * t;
                xvelocity = 0.8 * xv + 0.2 * xvelocity
            };
            var C = false;
            var U = function (ag) {
                if (!G.enableScrolling[H]) {
                    return true
                }
                if (a.inArray(ag.target.tagName.toLowerCase(), Q) !== -1) {
                    return
                }
                X = m.jqxScrollBar("value");
                xoffset = x.jqxScrollBar("value");
                var ah = G.getTouches(ag);
                var ai = ah[0];
                if (ah.length == 1) {
                    G.dispatchMouseEvent("mousedown", ai, G.getRootNode(ai.target))
                }
                V = x.jqxScrollBar("max");
                P = m.jqxScrollBar("max");
                function af(aj) {
                    C = false;
                    F = true;
                    c = A(aj);
                    ac = ab(aj);
                    t = R = xvelocity = 0;
                    d = X;
                    xframe = xoffset;
                    w = Date.now();
                    clearInterval(v);
                    v = setInterval(I, 100);
                    initialOffset = X;
                    initialXOffset = xoffset;
                    if (X > 0 && X < P && m[0].style.visibility != "hidden") { }
                }
                af(ag);
                j = false;
                q = ai.pageY;
                s = ai.pageX;
                if (G.simulatetouches) {
                    if (ai._pageY != undefined) {
                        q = ai._pageY;
                        s = ai._pageX
                    }
                }
                G.scrolling[H] = true;
                e = 0;
                g = 0;
                return true
            };
            if (o.on) {
                o.on(u, U)
            } else {
                o.bind(u, U)
            }
            var Z = function (ag, af) {
                X = (ag > P) ? P : (ag < ad) ? ad : ag;
                W(null, ag, 0, 0, af);
                return (ag > P) ? "max" : (ag < ad) ? "min" : "value"
            };
            var l = function (ag, af) {
                xoffset = (ag > V) ? V : (ag < ad) ? ad : ag;
                W(ag, null, 0, 0, af);
                return (ag > V) ? "max" : (ag < ad) ? "min" : "value"
            };
            function S() {
                var af, ag;
                if (R) {
                    af = Date.now() - w;
                    ag = -R * Math.exp(-af / n);
                    if (ag > 0.5 || ag < -0.5) {
                        Z(b + ag, event);
                        requestAnimationFrame(S)
                    } else {
                        Z(b);
                        m.fadeOut("fast")
                    }
                }
            }
            function N() {
                var af, ag;
                if (R) {
                    af = Date.now() - w;
                    ag = -R * Math.exp(-af / n);
                    if (ag > 0.5 || ag < -0.5) {
                        l(E + ag);
                        requestAnimationFrame(N)
                    } else {
                        l(E);
                        x.fadeOut("fast")
                    }
                }
            }
            var y = function (af) {
                if (!G.enableScrolling[H]) {
                    return true
                }
                if (!G.scrolling[H]) {
                    return true
                }
                if (C) {
                    af.preventDefault();
                    af.stopPropagation()
                }
                var ak = G.getTouches(af);
                if (ak.length > 1) {
                    return true
                }
                var ag = ak[0].pageY;
                var ai = ak[0].pageX;
                if (G.simulatetouches) {
                    if (ak[0]._pageY != undefined) {
                        ag = ak[0]._pageY;
                        ai = ak[0]._pageX
                    }
                }
                var am = ag - q;
                var an = ai - s;
                J = ag;
                touchHorizontalEnd = ai;
                f = am - e;
                h = an - g;
                j = true;
                e = am;
                g = an;
                var ah = x != null ? x[0].style.visibility != "hidden" : true;
                var al = m != null ? m[0].style.visibility != "hidden" : true;
                function aj(aq) {
                    var at, ar, ap;
                    if (F) {
                        at = A(aq);
                        ap = ab(aq);
                        ar = c - at;
                        xdelta = ac - ap;
                        var ao = "value";
                        if (ar > 2 || ar < -2) {
                            c = at;
                            ao = Z(X + ar, aq);
                            I();
                            if (ao == "min" && initialOffset === 0) {
                                return true
                            }
                            if (ao == "max" && initialOffset === P) {
                                return true
                            }
                            if (!al) {
                                return true
                            }
                            aq.preventDefault();
                            aq.stopPropagation();
                            C = true;
                            return false
                        } else {
                            if (xdelta > 2 || xdelta < -2) {
                                ac = ap;
                                ao = l(xoffset + xdelta, aq);
                                I();
                                if (ao == "min" && initialXOffset === 0) {
                                    return true
                                }
                                if (ao == "max" && initialXOffset === V) {
                                    return true
                                }
                                if (!ah) {
                                    return true
                                }
                                C = true;
                                aq.preventDefault();
                                aq.stopPropagation();
                                return false
                            }
                        }
                        aq.preventDefault()
                    }
                }
                if (ah || al) {
                    if ((ah) || (al)) {
                        aj(af)
                    }
                }
            };
            if (o.on) {
                o.on(Y, y)
            } else {
                o.bind(Y, y)
            }
            var r = function (ag) {
                if (!G.enableScrolling[H]) {
                    return true
                }
                var ah = G.getTouches(ag)[0];
                if (!G.scrolling[H]) {
                    return true
                }
                F = false;
                clearInterval(v);
                if (t > 10 || t < -10) {
                    R = 0.8 * t;
                    b = Math.round(X + R);
                    w = Date.now();
                    requestAnimationFrame(S);
                    m.fadeIn(100)
                } else {
                    if (xvelocity > 10 || xvelocity < -10) {
                        R = 0.8 * xvelocity;
                        E = Math.round(xoffset + R);
                        w = Date.now();
                        requestAnimationFrame(N);
                        x.fadeIn(100)
                    } else {
                        x.fadeOut(100);
                        m.fadeOut(100)
                    }
                }
                G.scrolling[H] = false;
                if (j) {
                    G.dispatchMouseEvent("mouseup", ah, ag.target)
                } else {
                    var ah = G.getTouches(ag)[0],
                    af = G.getRootNode(ah.target);
                    G.dispatchMouseEvent("mouseup", ah, af);
                    G.dispatchMouseEvent("click", ah, af);
                    return true
                }
            };
            if (this.simulatetouches) {
                var p = a(window).on != undefined || a(window).bind;
                var O = function (af) {
                    try {
                        r(af)
                    } catch (ag) { }
                    G.scrolling[H] = false
                };
                a(window).on != undefined ? a(document).on("mouseup.touchScroll", O) : a(document).bind("mouseup.touchScroll", O);
                if (window.frameElement) {
                    if (window.top != null) {
                        var L = function (af) {
                            try {
                                r(af)
                            } catch (ag) { }
                            G.scrolling[H] = false
                        };
                        if (window.top.document) {
                            a(window.top.document).on ? a(window.top.document).on("mouseup", L) : a(window.top.document).bind("mouseup", L)
                        }
                    }
                }
                var ae = a(document).on != undefined || a(document).bind;
                var K = function (af) {
                    if (!G.scrolling[H]) {
                        return true
                    }
                    G.scrolling[H] = false;
                    var ah = G.getTouches(af)[0],
                    ag = G.getRootNode(ah.target);
                    G.dispatchMouseEvent("mouseup", ah, ag);
                    G.dispatchMouseEvent("click", ah, ag)
                };
                a(document).on != undefined ? a(document).on("touchend", K) : a(document).bind("touchend", K)
            }
            if (o.on) {
                o.on("dragstart",
                function (af) {
                    af.preventDefault()
                });
                o.on("selectstart",
                function (af) {
                    af.preventDefault()
                })
            }
            o.on ? o.on(D + " touchcancel.touchScroll", r) : o.bind(D + " touchcancel.touchScroll", r)
        }
    });
    a.jqx.cookie = a.jqx.cookie || {};
    a.extend(a.jqx.cookie, {
        cookie: function (e, f, c) {
            if (arguments.length > 1 && String(f) !== "[object Object]") {
                c = a.extend({},
                c);
                if (f === null || f === undefined) {
                    c.expires = -1
                }
                if (typeof c.expires === "number") {
                    var h = c.expires,
                    d = c.expires = new Date();
                    d.setDate(d.getDate() + h)
                }
                f = String(f);
                return (document.cookie = [encodeURIComponent(e), "=", c.raw ? f : encodeURIComponent(f), c.expires ? "; expires=" + c.expires.toUTCString() : "", c.path ? "; path=" + c.path : "", c.domain ? "; domain=" + c.domain : "", c.secure ? "; secure" : ""].join(""))
            }
            c = f || {};
            var b, g = c.raw ?
            function (j) {
                return j
            } : decodeURIComponent;
            return (b = new RegExp("(?:^|; )" + encodeURIComponent(e) + "=([^;]*)").exec(document.cookie)) ? g(b[1]) : null
        }
    });
    a.jqx.string = a.jqx.string || {};
    a.extend(a.jqx.string, {
        replace: function (f, d, e) {
            if (d === e) {
                return this
            }
            var b = f;
            var c = b.indexOf(d);
            while (c != -1) {
                b = b.replace(d, e);
                c = b.indexOf(d)
            }
            return b
        },
        contains: function (b, c) {
            if (b == null || c == null) {
                return false
            }
            return b.indexOf(c) != -1
        },
        containsIgnoreCase: function (b, c) {
            if (b == null || c == null) {
                return false
            }
            return b.toString().toUpperCase().indexOf(c.toString().toUpperCase()) != -1
        },
        equals: function (b, c) {
            if (b == null || c == null) {
                return false
            }
            b = this.normalize(b);
            if (c.length == b.length) {
                return b.slice(0, c.length) == c
            }
            return false
        },
        equalsIgnoreCase: function (b, c) {
            if (b == null || c == null) {
                return false
            }
            b = this.normalize(b);
            if (c.length == b.length) {
                return b.toUpperCase().slice(0, c.length) == c.toUpperCase()
            }
            return false
        },
        startsWith: function (b, c) {
            if (b == null || c == null) {
                return false
            }
            return b.slice(0, c.length) == c
        },
        startsWithIgnoreCase: function (b, c) {
            if (b == null || c == null) {
                return false
            }
            return b.toUpperCase().slice(0, c.length) == c.toUpperCase()
        },
        normalize: function (b) {
            if (b.charCodeAt(b.length - 1) == 65279) {
                b = b.substring(0, b.length - 1)
            }
            return b
        },
        endsWith: function (b, c) {
            if (b == null || c == null) {
                return false
            }
            b = this.normalize(b);
            return b.slice(-c.length) == c
        },
        endsWithIgnoreCase: function (b, c) {
            if (b == null || c == null) {
                return false
            }
            b = this.normalize(b);
            return b.toUpperCase().slice(-c.length) == c.toUpperCase()
        }
    });
    a.extend(a.easing, {
        easeOutBack: function (f, g, e, k, j, h) {
            if (h == undefined) {
                h = 1.70158
            }
            return k * ((g = g / j - 1) * g * ((h + 1) * g + h) + 1) + e
        },
        easeInQuad: function (f, g, e, j, h) {
            return j * (g /= h) * g + e
        },
        easeInOutCirc: function (f, g, e, j, h) {
            if ((g /= h / 2) < 1) {
                return -j / 2 * (Math.sqrt(1 - g * g) - 1) + e
            }
            return j / 2 * (Math.sqrt(1 - (g -= 2) * g) + 1) + e
        },
        easeInOutSine: function (f, g, e, j, h) {
            return -j / 2 * (Math.cos(Math.PI * g / h) - 1) + e
        },
        easeInCubic: function (f, g, e, j, h) {
            return j * (g /= h) * g * g + e
        },
        easeOutCubic: function (f, g, e, j, h) {
            return j * ((g = g / h - 1) * g * g + 1) + e
        },
        easeInOutCubic: function (f, g, e, j, h) {
            if ((g /= h / 2) < 1) {
                return j / 2 * g * g * g + e
            }
            return j / 2 * ((g -= 2) * g * g + 2) + e
        },
        easeInSine: function (f, g, e, j, h) {
            return -j * Math.cos(g / h * (Math.PI / 2)) + j + e
        },
        easeOutSine: function (f, g, e, j, h) {
            return j * Math.sin(g / h * (Math.PI / 2)) + e
        },
        easeInOutSine: function (f, g, e, j, h) {
            return -j / 2 * (Math.cos(Math.PI * g / h) - 1) + e
        }
    })
})(jqxBaseFramework); (function (b) {
    b.extend(b.event.special, {
        close: {
            noBubble: true
        },
        open: {
            noBubble: true
        },
        cellclick: {
            noBubble: true
        },
        rowclick: {
            noBubble: true
        },
        tabclick: {
            noBubble: true
        },
        selected: {
            noBubble: true
        },
        expanded: {
            noBubble: true
        },
        collapsed: {
            noBubble: true
        },
        valuechanged: {
            noBubble: true
        },
        expandedItem: {
            noBubble: true
        },
        collapsedItem: {
            noBubble: true
        },
        expandingItem: {
            noBubble: true
        },
        collapsingItem: {
            noBubble: true
        }
    });
    b.fn.extend({
        ischildof: function (f) {
            var d = b(this).parents().get();
            for (var c = 0; c < d.length; c++) {
                if (typeof f != "string") {
                    var e = d[c];
                    if (f !== undefined) {
                        if (e == f[0]) {
                            return true
                        }
                    }
                } else {
                    if (f !== undefined) {
                        if (b(d[c]).is(f)) {
                            return true
                        }
                    }
                }
            }
            return false
        }
    });
    b.fn.jqxProxy = function () {
        var e = b(this).data().jqxWidget;
        var c = Array.prototype.slice.call(arguments, 0);
        var d = e.element;
        if (!d) {
            d = e.base.element
        }
        return b.jqx.jqxWidgetProxy(e.widgetName, d, c)
    };
    var a = this.originalVal = b.fn.val;
    b.fn.val = function (d) {
        if (typeof d == "undefined") {
            if (b(this).hasClass("jqx-widget")) {
                var c = b(this).data().jqxWidget;
                if (c && c.val) {
                    return c.val()
                }
            }
            return a.call(this)
        } else {
            if (b(this).hasClass("jqx-widget")) {
                var c = b(this).data().jqxWidget;
                if (c && c.val) {
                    if (arguments.length != 2) {
                        return c.val(d)
                    } else {
                        return c.val(d, arguments[1])
                    }
                }
            }
            return a.call(this, d)
        }
    };
    if (b.fn.modal && b.fn.modal.Constructor) {
        b.fn.modal.Constructor.prototype.enforceFocus = function () {
            b(document).off("focusin.bs.modal").on("focusin.bs.modal", b.proxy(function (c) {
                if (this.$element[0] !== c.target && !this.$element.has(c.target).length) {
                    if (b(c.target).parents().hasClass("jqx-popup")) {
                        return true
                    }
                    this.$element.trigger("focus")
                }
            },
            this))
        }
    }
    b.fn.coord = function (o) {
        var e, k, j = {
            top: 0,
            left: 0
        },
        f = this[0],
        m = f && f.ownerDocument;
        if (!m) {
            return
        }
        e = m.documentElement;
        if (!b.contains(e, f)) {
            return j
        }
        if (typeof f.getBoundingClientRect !== undefined) {
            j = f.getBoundingClientRect()
        }
        var d = function (p) {
            return b.isWindow(p) ? p : p.nodeType === 9 ? p.defaultView || p.parentWindow : false
        };
        k = d(m);
        var h = 0;
        var c = 0;
        var g = navigator.userAgent.toLowerCase();
        var n = g.indexOf("ipad") != -1 || g.indexOf("iphone") != -1;
        if (n) {
            h = 2
        }
        if (true == o) {
            if (b(document.body).css("position") != "static") {
                var l = b(document.body).coord();
                h = -l.left;
                c = -l.top
            }
        }
        return {
            top: c + j.top + (k.pageYOffset || e.scrollTop) - (e.clientTop || 0),
            left: h + j.left + (k.pageXOffset || e.scrollLeft) - (e.clientLeft || 0)
        }
    }
})(jqxBaseFramework);