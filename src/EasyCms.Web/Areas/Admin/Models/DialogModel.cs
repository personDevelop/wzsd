using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EasyCms.Web
{
    public class DialogModel
    {
        public string DialogID { get; set; }
        public string Title { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string InnitFunc { get; set; }
        public string OnOk { get; set; }

        public bool IsMutiSelect { get; set; }

        public string DataControlID { get; set; }

        public bool IsTree { get; set; }

        public string FiledID { get; set; }

    }
    public class EditDialogModel
    {
        public string DialogID { get; set; }
        public string Title { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string HeadIconName { get; set; } 
    }
    public class FileUpCallBack
    {
        public string OnDeleteName { get; set; }
        public string OnUpSccessName { get; set; }
    }


    public class DropDownListInfo
    {
        public string Url { get; set; }
        public string ValueMember { get; set; }
        public string DisplayMember { get; set; }
        public string select { get; set; }
        public string unselect { get; set; }
        public string change { get; set; }

        /// <summary>
        /// 初始数据，如果不是从url 异步获取，则通过该innitdata 主动后台赋值
        /// </summary>
        public DataTable InnitData { get; set; }

        public string JsonDataRoor { get; set; }
    }


    public class HelpEditModel
    {

       
        private string _SearchField= "Name";
        private string _PlaceHolder= "请选择";
        private string _HelpTitle="请选择";
        private string _Width="700";
        private string _Height="500";
        private string _ReturnValueField="ID";
        private string _ReturnDisplayField="Name";
        private string _OtherSet="{}";

        /// <summary>
        /// 帮助窗体标题  默认 请选择
        /// </summary>
        public string HelpTitle
        {
            get
            {
                return _HelpTitle;
            }
            set
            {
                _HelpTitle = value;
            }
        }

        /// <summary>
        /// 帮助的label
        /// </summary>
        public string Lable { get; set; }

        /// <summary>
        /// 帮助的值对应字段
        /// </summary>
        public string ValueField { get; set; }

        /// <summary>
        /// 帮助返回值对应字段  默认ID
        /// </summary>
        public string ReturnValueField
        {
            get
            {
                return _ReturnValueField;
            }
            set
            {
                _ReturnValueField = value;
            }
        }



        /// <summary>
        /// 帮助的默认值
        /// </summary>
        public string ValueFieldValue { get; set; }

        /// <summary>
        /// 帮助的显示字段
        /// </summary>

        public string DisplayField { get; set; }

        /// <summary>
        /// 帮助窗体中的过滤条件对应字段  默认 Name
        /// </summary>
        public string SearchField
        {
            get
            {
                return _SearchField;
            }
            set
            {
                _SearchField = value;
            }
        }
        /// <summary>
        /// 执行额外查询参数的脚步函数 参数为data
        /// </summary>
        public string OtherSerchFieldFunction { get; set; }
        /// <summary>
        /// 帮助返回值对应字段 默认Name
        /// </summary>
        public string ReturnDisplayField
        {
            get
            {
                return _ReturnDisplayField;
            }
            set
            {
                _ReturnDisplayField = value;
            }
        }
         
        /// <summary>
        /// 帮助对应的默认显示值
        /// </summary>
        public string DisplayFieldValue { get; set; }


        /// <summary>
        /// 帮助其他对应字段
        /// </summary>
        public string OtherField { get; set; }

        /// <summary>
        /// 帮助其他对应字段
        /// </summary>
        public string ReturnOtherField { get; set; }

        /// <summary>
        /// 是否是树形数据结构
        /// </summary>

        public bool IsTree { get; set; }

        /// <summary>
        /// 是否多选
        /// </summary>
        public bool IsMutiSelect { get; set; }

        /// <summary>
        /// 是否是查看模式 查看模式下 帮助控件不可用
        /// </summary>
        public bool IsViewModel { get; set; }


        public string Hint { get; set; }
        /// <summary>
        /// 帮助控件水印文字 默认 请选择
        /// </summary>
        public string PlaceHolder
        {
            get
            {
                return _PlaceHolder;
            }
            set
            {
                _PlaceHolder = value;
            }
        }

        /// <summary>
        /// 帮助取值URL
        /// </summary>
        public string Url { get; set; }

       
        /// <summary>
        /// 帮助的字段信息
        /// </summary>
        public string DataFields { get; set; }
        /// <summary>
        /// 帮助的列信息
        /// </summary>
        public string Columns { get; set; }
        /// <summary>
        /// 帮助数据控件的其他参数
        /// </summary>
        public string OtherSet
        {
            get
            {
                return _OtherSet;
            }
            set
            {

                _OtherSet = value;
            }
        }

        /// <summary>
        /// 选中完成事件 参数是选中的值
        /// </summary>
        public string OnOk { get; set; }

        /// <summary>
        /// 选中完成前事件 只有返回true 才会继续赋值
        /// </summary>
        public string OnOking { get; set; }
        
        /// <summary>
        /// 帮助框高度 默认500
        /// </summary>
        public string Height
        {
            get
            {
                return _Height;
            }
            set
            {
                 
                _Height = value;
            }
        }
        /// <summary>
        /// 帮助框宽度 默认700
        /// </summary>
        public string Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
            }
        }
        
        public string OtherConditionView
        {
            get;
            set;
        }
    }


    public class HelpEditShopProductModel
    { 
        /// <summary>
        /// 帮助的label
        /// </summary>
        public string Lable { get; set; }

        /// <summary>
        /// 帮助的值对应字段
        /// </summary>
        public string ValueField { get; set; } 

        /// <summary>
        /// 帮助的默认值
        /// </summary>
        public string ValueFieldValue { get; set; }

        /// <summary>
        /// 帮助的显示字段
        /// </summary>

        public string DisplayField { get; set; }
         

        /// <summary>
        /// 帮助对应的默认显示值
        /// </summary>
        public string DisplayFieldValue { get; set; }
         
        /// <summary>
        /// 是否多选
        /// </summary>
        public bool IsMutiSelect { get; set; }

        /// <summary>
        /// 是否是查看模式 查看模式下 帮助控件不可用
        /// </summary>
        public bool IsViewModel { get; set; }


        public string Hint { get; set; }


        /// <summary>
        /// 帮助其他对应字段
        /// </summary>
        public string OtherField { get; set; }

        /// <summary>
        /// 帮助其他对应字段
        /// </summary>
        public string ReturnOtherField { get; set; }



    }
    public class HelpEditShopProductCategory
    {
        /// <summary>
        /// 帮助的label
        /// </summary>
        public string Lable { get; set; }

        /// <summary>
        /// 帮助的值对应字段
        /// </summary>
        public string ValueField { get; set; }

        /// <summary>
        /// 帮助的默认值
        /// </summary>
        public string ValueFieldValue { get; set; }

        /// <summary>
        /// 帮助的显示字段
        /// </summary>

        public string DisplayField { get; set; }


        /// <summary>
        /// 帮助对应的默认显示值
        /// </summary>
        public string DisplayFieldValue { get; set; }

        /// <summary>
        /// 是否多选
        /// </summary>
        public bool IsMutiSelect { get; set; }

        /// <summary>
        /// 是否是查看模式 查看模式下 帮助控件不可用
        /// </summary>
        public bool IsViewModel { get; set; }


        public string Hint { get; set; }


        /// <summary>
        /// 帮助其他对应字段
        /// </summary>
        public string OtherField { get; set; }

        /// <summary>
        /// 帮助其他对应字段
        /// </summary>
        public string ReturnOtherField { get; set; }



    }
    public class HelpEditCouponModel
    {
        /// <summary>
        /// 帮助的label
        /// </summary>
        public string Lable { get; set; }

        /// <summary>
        /// 帮助的值对应字段
        /// </summary>
        public string ValueField { get; set; }

        /// <summary>
        /// 帮助的默认值
        /// </summary>
        public string ValueFieldValue { get; set; }

        /// <summary>
        /// 帮助的显示字段
        /// </summary>

        public string DisplayField { get; set; }


        /// <summary>
        /// 帮助对应的默认显示值
        /// </summary>
        public string DisplayFieldValue { get; set; }

        /// <summary>
        /// 是否多选
        /// </summary>
        public bool IsMutiSelect { get; set; }

        /// <summary>
        /// 是否是查看模式 查看模式下 帮助控件不可用
        /// </summary>
        public bool IsViewModel { get; set; }


        public string Hint { get; set; }


        /// <summary>
        /// 帮助其他对应字段
        /// </summary>
        public string OtherField { get; set; }

        /// <summary>
        /// 帮助其他对应字段
        /// </summary>
        public string ReturnOtherField { get; set; }



    }

    public class HelpEditProductType
    { 
        /// <summary>
        /// 帮助的值对应字段
        /// </summary>
        public string ValueField { get; set; }

        /// <summary>
        /// 帮助的默认值
        /// </summary>
        public string ValueFieldValue { get; set; }

        /// <summary>
        /// 帮助的显示字段
        /// </summary>

        public string DisplayField { get; set; }


        /// <summary>
        /// 帮助对应的默认显示值
        /// </summary>
        public string DisplayFieldValue { get; set; }

       

        /// <summary>
        /// 是否是查看模式 查看模式下 帮助控件不可用
        /// </summary>
        public bool IsViewModel { get; set; }


        public string Hint { get; set; }

        public string OnOk { get; set; }

        /// <summary>
        /// 只有这个方法返回true 才会继续打开帮助窗口
        /// </summary>
        public string OnSelecting { get; set; }

        /// <summary>
        /// 只有这个方法返回true 才会继续清空数据
        /// </summary>
        public string OnClearing { get; set; }
        
    }
}
 