function CreateGrid(gridid, url, datafields, columns, opts) {
    if (!opts) {
        opts = {};
    }
    if (!opts.isMutilSelect) {
        opts.isMutilSelect = false;
    }
    if (!opts.data) {
        opts.data = {};
    }
    if (!opts.adapter) {
        opts.adapter = {};
    }
    if (!opts.grid) {
        opts.grid = {};
    }
    gridid = '#' + gridid;
    for (var i = 0; i < datafields.length; i++) {
        if (!datafields[i].type) {
            datafields[i].align = "string";
        }
    }
    var source = {
                  datatype: "json",
                  cache: false,
                  datafields: datafields,
                  loadError: function (data) {
                      var dataResult = $.parseJSON(data.responseText);
                      if (dataResult && dataResult.Msg) {
                          ErrorMsg(dataResult.Msg);
                      }
                      else {

                          ErrorMsg(data.responseText);
                      }
                  },
                  beforeLoadComplete: function () {

                  },
                  loadComplete: function () {
                      if (opts.isMutilSelect) {
                          $(gridid).jqxGrid('clearselection'); 

                      }
                  },
                  beforeprocessing: function (data) {
                      source.totalrecords = data.total;
                  },
                  root: 'Rows',
                  id: 'ID',
                  url: url,
              };

    var dataAdapter = new $.jqx.dataAdapter($.extend(source, opts.data), opts.adapter);
    selectionmode = "checkbox";
    if (!opts.isMutilSelect) {
        selectionmode = "singlerow";
    }
    for (var i = 0; i < columns.length; i++) {
        if (!columns[i].align) {
            columns[i].align = "center";
        }
        if (!columns[i].cellsalign) {
            columns[i].cellsalign = "center";
        }
        if (columns[i].valObj) {
            columns[i].cellsrenderer = function (row, columnfield, value, defaulthtml, columnproperties) {
                for (var j = 0; j < columns.length; j++) {

                    if (columns[j].dataField == columnfield) {
                        for (var k = 0; k < columns[j].valObj.length; k++) {
                            var val = columns[j].valObj[k];
                            if (val.key == value) {
                                return '<div style="text-align: ' + columns[j].cellsalign + '; overflow: hidden; padding-bottom: 2px; margin-top: 4px; text-overflow: ellipsis;">' + val.val + '</div>';

                            }
                        }

                        return "未知";

                        break;

                    }


                }

            };
        }
    }
    var totalHeight = $(window).outerHeight();
    if (totalHeight == 0) {
        totalHeight = $(window).clientHeight();
    }
    var topHight = 250;

    var middleHeight = totalHeight - topHight;
    if (opts.grid.pageable == undefined) {
        opts.grid.pageable = true;
    }
    if (!opts.grid.pageable) {
        opts.grid.rendergridrows = null, opts.grid.virtualmode = false, opts.grid.pagerrenderer = null;
    }
    
    $(gridid).jqxGrid(
     $.extend({
         width: "99%",
         autoheight: true,
         source: dataAdapter,
         columnsresize: true,
         theme: "metro",
         virtualmode: false,
         selectionmode: selectionmode,
         altrows: true,
         rendergridrows: function (params) {
             return params.data;
         },
         pagermode: 'simple',
        /* pagerrenderer: pagerrenderer,*/
         pageSize: 20,
         pageable: true,
         columns: columns, localization: "zh-Hans"
     }, opts.grid));
     
   
   
}

function EditGrid(gridid, url, id, other) {
    gridid = '#' + gridid;
    if (!id) {


        var rowindex = $(gridid).jqxGrid('getselectedrowindexes');

        if (rowindex.length != 1) {
            ErrorMsg("请选择一条数据");
            return;
        } else {
            var data = $(gridid).jqxGrid('getrowdata', rowindex[0]);
            if (data) {
                id = data.ID;
            } else { ErrorMsg("请选择一条数据"); return; }
        }
    }
    if (id) {
        url += "/" + id;
    }
    if (other) {
        url += "/" + other;
    }
    location.href = url;

}

function DelGrid(gridid, url, id, other, success) {
    gridid = '#' + gridid;
    if (!id) {

        var rowindexes = $(gridid).jqxGrid('getselectedrowindexes');
        var selectionmode = $(gridid).jqxGrid('selectionmode');
        if (selectionmode == "checkbox") {
            /*多选*/
            if (rowindexes.length > 0) {
                id = "";
                for (var i = 0; i < rowindexes.length; i++) {
                    if (i > 0) {
                        id += ",";
                    }
                    var data = $(gridid).jqxGrid('getrowdata', rowindexes[i]);
                    if (data) {
                        id += data.ID;
                    }

                }
            } else { ErrorMsg("请选择一条数据"); return; }

        } else {
            if (rowindexes.length == 1) {
                var data = $(gridid).jqxGrid('getrowdata', rowindexes[0]);
                if (data) {
                    id = data.ID;
                } else { ErrorMsg("请选择一条数据");   return; }

            } else { ErrorMsg("请选择一条数据"); return; }
        }
    }
    if (id) {
        var postdata = { ID: id }

        if (other) {
            postdata.other = other;
        }
        $.post(url, postdata, function (d) {
            if (jQuery.type(d) == "object") {
                if (d.IsSuccess) {
                    if (!d.Msg) {
                        SucessMsg("操作成功");
                    } else
                        SucessMsg(d.Msg);
                } else {
                    ErrorMsg(d.Msg);

                }
            } else {
                if (d.indexOf("成功") > -1) {
                    $(gridid).jqxGrid('updatebounddata');
                    if (success) {
                        success();
                    }
                    SucessMsg(d);
                } else
                    ErrorMsg(d);
            }
        });
    }


}

function CreateTree(treeid, url, datafields, columns, opts) {
    if (!opts) {
        opts = {};
    }
    if (!opts.isMutilSelect) {
        opts.isMutilSelect = false;
    }
    if (!opts.data) {
        opts.data = {};
    }
    if (!opts.adapter) {
        opts.adapter = {};
    }
    if (!opts.tree) {
        opts.tree = {};
    }
    treeid = '#' + treeid;
    for (var i = 0; i < datafields.length; i++) {
        if (!datafields[i].type) {
            datafields[i].align = "string";
        }
    }
    var source =
              {
                  datatype: "json",
                  datafields: datafields,
                  timeout: 10000,
                  loadError: function (data) {
                      var dataResult = $.parseJSON(data.responseText);
                      if (dataResult && dataResult.Msg) {
                          ErrorMsg(dataResult.Msg);
                      }
                      else {

                          ErrorMsg(data.responseText);
                      }

                  },
                  beforeLoadComplete: function () {

                  },
                  loadComplete: function () {

                  },
                  hierarchy:
                  {
                      keyDataField: { name: 'ID' },
                      parentDataField: { name: 'ParentID' }
                  },
                  id: 'ID',
                  root: 'Rows',
                  url: url
              };
    var dataAdapter = new $.jqx.dataAdapter($.extend(source, opts.data), opts.adapter);
    selectionmode = "checkbox";
    if (!opts.isMutilSelect) {
        selectionmode = "singlerow";
    }


    for (var i = 0; i < columns.length; i++) {
        if (!columns[i].align) {
            columns[i].align = "center";
        }
        if (!columns[i].cellsalign) {
            columns[i].cellsalign = "center";
        }
        if (columns[i].valObj) {
            columns[i].cellsrenderer = function (row, columnfield, value, defaulthtml, columnproperties) {
                for (var j = 0; j < columns.length; j++) {

                    if (columns[j].dataField == columnfield) {
                        for (var k = 0; k < columns[j].valObj.length; k++) {
                            var val = columns[j].valObj[k];
                            if (val.key == value) {
                                return '<div style="text-align: ' + columns[j].cellsalign + '; overflow: hidden; padding-bottom: 2px; margin-top: 4px; text-overflow: ellipsis;">' + val.val + '</div>';

                            }
                        }

                        return "未知";

                        break;

                    }


                }

            };
        }
    }
    var totalHeight = $(window).outerHeight();
    if (totalHeight == 0) {
        totalHeight = $(window).clientHeight();
    }
    var topHight = 50;

    var middleHeight = totalHeight - topHight;
    $(treeid).jqxTreeGrid($.extend({
        width: "95%",
        theme: "metro",
        height: middleHeight,
        source: dataAdapter,
        columns: columns
    }, opts.tree));
}
function CreateAjaxLoadTree(treeid, url, datafields, columns, opts) {
    if (!opts) {
        opts = {};
    }
    if (!opts.isMutilSelect) {
        opts.isMutilSelect = false;
    }
    if (!opts.data) {
        opts.data = {};
    }
    if (!opts.adapter) {
        opts.adapter = {};
    }
    if (!opts.tree) {
        opts.tree = {};
    }
    treeid = '#' + treeid;
    for (var i = 0; i < datafields.length; i++) {
        if (!datafields[i].type) {
            datafields[i].align = "string";
        }
    }
    var source =
              {
                  datatype: "json",
                  datafields: datafields,
                  timeout: 10000,
                  hierarchy:
                  {
                      keyDataField: { name: 'ID' },
                      parentDataField: { name: 'ParentID' }
                  },
                  id: 'ID',
                  root: 'Rows',
                  url: url
              };

    var totalHeight = $(window).outerHeight();
    if (totalHeight == 0) {
        totalHeight = $(window).clientHeight();
    }
    var topHight = 50;

    var middleHeight = totalHeight - topHight;
    selectionmode = "checkbox";
    if (!opts.isMutilSelect) {
        selectionmode = "singlerow";
    }

    for (var i = 0; i < columns.length; i++) {


        if (!columns[i].align) {
            columns[i].align = "center";
        }
        if (!columns[i].cellsalign) {
            columns[i].cellsalign = "center";
        }
        if (columns[i].valObj) {
            columns[i].cellsrenderer = function (row, columnfield, value, defaulthtml, columnproperties) {
                for (var k = 0; k < columns[i].valObj.length; k++) {
                    var val = columns[i].valObj[k];
                    if (val.key == value) {
                        return val.val;
                    }
                }
            };
        }
    }
    $(treeid).data("source", source);
    $(treeid).jqxTreeGrid($.extend({
        width: "95%",
        height: middleHeight,
        columns: columns,
        virtualModeRecordCreating: function (record) {

            // record is creating.

        },
        virtualModeCreateRecords: function (expandedRecord, done) {
            var dataAdapter = new $.jqx.dataAdapter($.extend($(treeid).data("source"), opts.data), $.extend(
                {
                    formatData: function (data) {

                        if (expandedRecord == null) {

                            data.parentID = 0;

                        }

                        else {

                            data.parentID = expandedRecord.ID;

                        }

                        return data;

                    },

                    loadComplete: function () {

                        done(dataAdapter.records);

                    },

                    loadError: function (xhr, status, error) {

                        done(false);

                        throw new Error("http://services.odata.org: " + error.toString());

                    }
                }, opts.adapter));
            dataAdapter.dataBind();

        },
    }, opts.tree));
}
function EditTree(treeid, url) {
    treeid = '#' + treeid;
    var data = $(treeid).jqxTreeGrid('getSelection');
    if (data.length == 1) {

        location.href = url + "/" + data[0].ID;
    } else { ErrorMsg("请选择一条数据"); }


}

function DelTree(treeid, url) {
    treeid = '#' + treeid;
    var data = $(treeid).jqxTreeGrid('getSelection');
    if (data.length == 1) {
        $.post(url, { ID: data[0].ID }, function (d) {
            ErrorMsg(d);
            if (d.indexOf("成功") > -1) {
                $(treeid).jqxTreeGrid('deleteRow', data[0].ID);
            }
        });
    } else { ErrorMsg("请选择一条数据"); }
}

function errorPlace(error, element) {

    if (element.is(":radio"))
        error.insertAfter($(element).parent());
    else if (element.is(":checkbox"))
        error.insertAfter($(element).parent());
    else
        error.insertAfter(element);
}

var theme = "";

var pagerrenderer = function (gridid) {
    var pageelement;
    if (!gridid) {
        gridid = "#" + this.wrapper.prevObject[0].id;
    }


    var datainfo = $(gridid).jqxGrid('getdatainformation');
    var paginginfo = datainfo.paginginformation;

    pageelement = $("<div style='margin-left: 10px; margin-top: 5px; width: 100%; height: 100%;'></div>");

    var leftButton = $("<div style='padding: 0px; float: left;'><div style='margin-left: 9px; width: 16px; height: 16px;'></div></div>");
    leftButton.find('div').addClass('jqx-icon-arrow-left');
    leftButton.width(36);
    leftButton.jqxButton({ theme: theme });
    var rightButton = $("<div style='padding: 0px; margin: 0px 3px; float: left;'><div style='margin-left: 9px; width: 16px; height: 16px;'></div></div>");
    rightButton.find('div').addClass('jqx-icon-arrow-right');
    rightButton.width(36);
    rightButton.jqxButton({ theme: theme });
    leftButton.appendTo(pageelement);
    rightButton.appendTo(pageelement);

    var label = $("<div style='font-size: 11px; margin: 2px 3px; font-weight: bold; float: left;'></div>");
    if (datainfo.rowscount == 0) {
        label.text("无符合条件的记录");
    } else {
        label.text("第" + (1 + paginginfo.pagenum * paginginfo.pagesize) + "-" + Math.min(datainfo.rowscount, (paginginfo.pagenum + 1) * paginginfo.pagesize) + '  条,共  ' + datainfo.rowscount + "条记录");
    }

    label.appendTo(pageelement);
    self.label = label;

    // update buttons states.
    var handleStates = function (event, button, className, add) {
        button.on(event, function () {
            if (add == true) {
                button.find('div').addClass(className);
            }
            else button.find('div').removeClass(className);
        });
    }
    if (theme != '') {
        handleStates('mousedown', rightButton, 'jqx-icon-arrow-right-selected-' + theme, true);
        handleStates('mouseup', rightButton, 'jqx-icon-arrow-right-selected-' + theme, false);
        handleStates('mousedown', leftButton, 'jqx-icon-arrow-left-selected-' + theme, true);
        handleStates('mouseup', leftButton, 'jqx-icon-arrow-left-selected-' + theme, false);
        handleStates('mouseenter', rightButton, 'jqx-icon-arrow-right-hover-' + theme, true);
        handleStates('mouseleave', rightButton, 'jqx-icon-arrow-right-hover-' + theme, false);
        handleStates('mouseenter', leftButton, 'jqx-icon-arrow-left-hover-' + theme, true);
        handleStates('mouseleave', leftButton, 'jqx-icon-arrow-left-hover-' + theme, false);
    }
    rightButton.click(function () {
        $(gridid).jqxGrid('gotonextpage');
    });
    leftButton.click(function () {
        $(gridid).jqxGrid('gotoprevpage');
    });

    return pageelement;
}

$(function () {
    $("#messageNotification").jqxNotification({
        theme: "metro",
        width: 250, position: "top-right"
    });
})
function SucessMsg(msg, append) {
    $("#msgDiv").text(msg);
    $("#messageNotification").jqxNotification({
        theme: "metro",
        template: "success", appendContainer: append
    });
    $("#messageNotification").jqxNotification("open");
}
function ErrorMsg(msg, append) {
    $("#msgDiv").text(msg);
    $("#messageNotification").jqxNotification({
        theme: "metro",
        template: "error", appendContainer: append
    });
    $("#messageNotification").jqxNotification("open");

}
function InfoMsg(msg, append) {
    $("#msgDiv").text(msg);
    $("#messageNotification").jqxNotification({
        theme: "metro",
        template: "info", appendContainer: append
    });
    $("#messageNotification").jqxNotification("open");
}
function WarningMsg(msg, append) {
    $("#msgDiv").text(msg);
    $("#messageNotification").jqxNotification({
        theme: "metro",
        template: "warning", appendContainer: append
    });
    $("#messageNotification").jqxNotification("open");
}

function Query(msg, onOk, title, onCancel) {
    if (!title) {
        title = "确认";
    }
    $('#eventWindow').jqxWindow({
        theme: "metro",
        maxHeight: 150, maxWidth: 280, minHeight: 30, minWidth: 250, height: 145, width: 270,
        resizable: false, isModal: true, modalOpacity: 0.3, autoOpen: false,
        okButton: $('#ok'), cancelButton: $('#cancel'),
        initContent: function () {

            $('#ok').jqxButton({ width: '65px', template: "success" });
            $('#cancel').jqxButton({ width: '65px', template: "warning" });
            $('#ok').focus();
        }
    });
    $('#eventWindowContent').html(msg);
    $('#eventWindowTitle').html(title);
    $('#ok').one('click', onOk);
    if (onCancel) {
        $('#cancel').one('click', onCancel);
    }
    
    $('#eventWindow').jqxWindow('open');
};


function CloseDialog() {
    if (!document.parentWindow) {
        window.parent.CloseThisDialog();

    } else {
        document.parentWindow.parent.CloseThisDialog();
    }

}
function SetDialogState(isChanged) {
    if (!document.parentWindow) {
        window.parent.SetThisDialogState(isChanged);

    } else {
        document.parentWindow.parent.SetThisDialogState(isChanged);
    }

}
function get3MonthBefor() {
    var resultDate, year, month, date, hms;
    var currDate = new Date();
    year = currDate.getFullYear();
    month = currDate.getMonth();
    date = currDate.getDate();
    /*hms = currDate.getHours() + ':' + currDate.getMinutes() + ':' + (currDate.getSeconds() < 10 ? '0' + currDate.getSeconds() : currDate.getSeconds());*/
    switch (month) {
        case 0:
        case 1:
        case 2:
            month += 8;
            year--;
            break;
        default:
            month -= 3;
            break;
    }
    month = (month < 10) ? ('0' + month) : month;

    resultDate = new Date(year, month, date);
    return resultDate;
}

function OnFail(result) {
    ErrorMsg("程序出现异常！" + result.responseJSON.Msg);
}
