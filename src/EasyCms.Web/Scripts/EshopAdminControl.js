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
    var source =
              {
                  datatype: "json",
                  cache: false,
                  datafields: datafields,
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
    $(gridid).jqxGrid(
     $.extend({
         width: "95%",
         height: middleHeight,
         source: dataAdapter,
         columnsresize: true,
         virtualmode: true,
         selectionmode: selectionmode,
         altrows: true,
         rendergridrows: function (params) {
             return params.data;
         },
         pagerrenderer: pagerrenderer,
         pageSize: 20,
         pageable: true,
         columns: columns
     }, opts.grid));
}

function EditGrid(gridid, url) {
    gridid = '#' + gridid;
    var rowindex = $(gridid).jqxGrid('getselectedrowindexes');

    if (rowindex.length != 1) {
        ErrorMsg("请选择一条数据");
    } else {
        var data = $(gridid).jqxGrid('getrowdata', rowindex[0]);

        if (data) {
            location.href = url + "/" + data.ID;
        } else { ErrorMsg("请选择一条数据"); }
    }
}

function DelGrid(gridid, url) {
    gridid = '#' + gridid;
    var rowindexes = $(gridid).jqxGrid('getselectedrowindexes');


    if (rowindexes.length == 1) {
        var data = $(gridid).jqxGrid('getrowdata', rowindexes[0]);

        $.post(url, { ID: data.ID }, function (d) {
            ErrorMsg(d);
            if (d.indexOf("成功") > -1) {

                $(gridid).jqxGrid('updatebounddata');
            }
        });
    } else { ErrorMsg("请选择一条数据"); }
}


function CreateTree(treeid, url, datafields, columns, isMutilSelect, opts) {
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
    var dataAdapter = new $.jqx.dataAdapter(source);
    var totalHeight = $(window).outerHeight();
    if (totalHeight == 0) {
        totalHeight = $(window).clientHeight();
    }
    var topHight = 50;

    var middleHeight = totalHeight - topHight;
    selectionmode = "checkbox";
    if (!isMutilSelect) {
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

    $(treeid).jqxTreeGrid($.extend({
        width: "95%",
        height: middleHeight,
        source: dataAdapter,
        columns: columns
    }, opts));
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
        gridid = "#jqxgrid";
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
        width: 250, position: "top-right"
    });
})
function SucessMsg(msg, append) {
    $("#msgDiv").text(msg);
    $("#messageNotification").jqxNotification({
        template: "success", appendContainer: append
    });
    $("#messageNotification").jqxNotification("open");
}
function ErrorMsg(msg, append) {
    $("#msgDiv").text(msg);
    $("#messageNotification").jqxNotification({
        template: "error", appendContainer: append
    });
    $("#messageNotification").jqxNotification("open");

}
function InfoMsg(msg, append) {
    $("#msgDiv").text(msg);
    $("#messageNotification").jqxNotification({
        template: "info", appendContainer: append
    });
    $("#messageNotification").jqxNotification("open");
}
function WarningMsg(msg, append) {
    $("#msgDiv").text(msg);
    $("#messageNotification").jqxNotification({
        template: "warning", appendContainer: append
    });
    $("#messageNotification").jqxNotification("open");
}

function Query(msg, onOk, title) {
    if (!title) {
        title = "确认";
    }
    $('#eventWindow').jqxWindow({
        maxHeight: 150, maxWidth: 280, minHeight: 30, minWidth: 250, height: 145, width: 270,
        resizable: false, isModal: true, modalOpacity: 0.3, autoOpen: false,
        okButton: $('#ok'), cancelButton: $('#cancel'),
        initContent: function () {
          
            $('#ok').jqxButton({ width: '65px' }); 
            $('#cancel').jqxButton({ width: '65px' });
            $('#ok').focus(); 
        }
    });
    $('#eventWindowContent').html(msg);
    $('#eventWindowTitle').html(title);
    $('#ok').one('click', onOk);
    $('#eventWindow').jqxWindow('open');
};