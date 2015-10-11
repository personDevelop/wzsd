function CreateGrid() {
    var url = "/Admin/ShopComment/GetList";
    var deleteUrl = "/Admin/ShopComment/Delete";
    var datafields = [
{ name: 'ID' },
{ name: 'ReviewText' },
  { name: 'ProductId' },
        { name: 'UserId' },
    { name: 'Status' },
    { name: 'OrderId' },
    { name: 'ProductName' },
    { name: 'Name' },
    { name: 'CreatedDate' },
{ name: 'IsManager' }];
    var columns = [
{ text: '评论内容', dataField: 'ReviewText', cellsalign: "left" },
{ text: '商品', dataField: 'ProductName', cellsalign: "left", width: 200 },
{ text: '评论人', dataField: 'Name', cellsalign: "left", width: 100 },
{
    text: '是管理员', dataField: 'IsManager', width: 100, valObj: [{ key: true, val: '启用' }, { key: false, val: '停用' }]
},
{ text: '评论时间', dataField: 'CreatedDate', width: 130, cellsformat: "yyyy-MM-dd HH:mm" },
{ text: '状态', dataField: 'Status', cellsalign: "left", width: 100 },
{
    text: '操作', datafield: 'ID', width: 200, cellsrenderer: function (row, column, value) {

        var html = "  <div style='text-align: center; overflow: hidden; padding-bottom: 2px; margin-top: 4px; text-overflow: ellipsis;'>";
        html +=
             "<a href='javascript:;' onclick='VideDeatil(\"" + value + "\");'  >详细信息</a> &nbsp;&nbsp;&nbsp;" +
         "<a  href='javascript:;' onclick='DelTree(\"jqxgrid\",\"" + deleteUrl + "\",\"" + value + "\");'  >删除</a>";
        html += "</div>";
        return html;
    }
}];

    CreateGrid("jqxgrid", url, datafields, columns, {
        isMutilSelect: true, adapter: {
            formatData: function (data) {
                data.StartDate = $("#StartDate").val();
                data.EndDate = $("#EndDate").val();
                data.ShopProduct = $("#ShopProduct").val();
                data.QryDjStatus = $("#QryDjStatus").val();
            }

        }, grid: { localization: "zh-Hans" }
    });
}
$(document).ready(function () {
    CreateGrid();
});
function VideDeatil(rowid) {
    var data = $('#jqxgrid').jqxGrid('getrowdatabyid', rowid);
    var detail = "详细信息：" + data.Info;
    $("#detail").val(detail);
    $('#window').jqxWindow("open");
}