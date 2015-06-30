﻿using System;
using System.Collections.Generic;
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
    }

    
}