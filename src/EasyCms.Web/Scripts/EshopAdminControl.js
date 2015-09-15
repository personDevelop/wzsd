﻿function CreateGrid(gridid, url, datafields, columns, isMutilSelect, opts, dataOpts) {
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
                  id: 'id',
                  url: url,
              };

    var dataAdapter = new $.jqx.dataAdapter($.extend(source, dataOpts));
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
    var totalHeight = $(window).outerHeight();
    if (totalHeight == 0) {
        totalHeight = $(window).clientHeight();
    }
    var topHight = 50;

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
     }, opts));
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

                $(gridid).jqxGrid('deleteRow', rowindexes[0]);
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
