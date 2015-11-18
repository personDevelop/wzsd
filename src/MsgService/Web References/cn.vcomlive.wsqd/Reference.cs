﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.18444 版自动生成。
// 
#pragma warning disable 1591

namespace MsgService.cn.vcomlive.wsqd {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SmsServiceSoap", Namespace="http://www.vcomcn.co/")]
    public partial class SmsService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetBalanceOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendSmsOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendSmsGroupOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendSmsGroupSpnumOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetResultbyTimeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetResultbyIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSmsStateReportOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSmsRespOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SmsService() {
            this.Url = global::MsgService.Properties.Settings.Default.MsgService_cn_vcomlive_wsqd_SmsService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetBalanceCompletedEventHandler GetBalanceCompleted;
        
        /// <remarks/>
        public event SendSmsCompletedEventHandler SendSmsCompleted;
        
        /// <remarks/>
        public event SendSmsGroupCompletedEventHandler SendSmsGroupCompleted;
        
        /// <remarks/>
        public event SendSmsGroupSpnumCompletedEventHandler SendSmsGroupSpnumCompleted;
        
        /// <remarks/>
        public event GetResultbyTimeCompletedEventHandler GetResultbyTimeCompleted;
        
        /// <remarks/>
        public event GetResultbyIdCompletedEventHandler GetResultbyIdCompleted;
        
        /// <remarks/>
        public event GetSmsStateReportCompletedEventHandler GetSmsStateReportCompleted;
        
        /// <remarks/>
        public event GetSmsRespCompletedEventHandler GetSmsRespCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vcomcn.co/GetBalance", RequestNamespace="http://www.vcomcn.co/", ResponseNamespace="http://www.vcomcn.co/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetBalance(string login_name, string password) {
            object[] results = this.Invoke("GetBalance", new object[] {
                        login_name,
                        password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetBalanceAsync(string login_name, string password) {
            this.GetBalanceAsync(login_name, password, null);
        }
        
        /// <remarks/>
        public void GetBalanceAsync(string login_name, string password, object userState) {
            if ((this.GetBalanceOperationCompleted == null)) {
                this.GetBalanceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBalanceOperationCompleted);
            }
            this.InvokeAsync("GetBalance", new object[] {
                        login_name,
                        password}, this.GetBalanceOperationCompleted, userState);
        }
        
        private void OnGetBalanceOperationCompleted(object arg) {
            if ((this.GetBalanceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBalanceCompleted(this, new GetBalanceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vcomcn.co/SendSms", RequestNamespace="http://www.vcomcn.co/", ResponseNamespace="http://www.vcomcn.co/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendSms(string login_name, string password, string mobile, string message, string start_time, string Search_ID) {
            object[] results = this.Invoke("SendSms", new object[] {
                        login_name,
                        password,
                        mobile,
                        message,
                        start_time,
                        Search_ID});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SendSmsAsync(string login_name, string password, string mobile, string message, string start_time, string Search_ID) {
            this.SendSmsAsync(login_name, password, mobile, message, start_time, Search_ID, null);
        }
        
        /// <remarks/>
        public void SendSmsAsync(string login_name, string password, string mobile, string message, string start_time, string Search_ID, object userState) {
            if ((this.SendSmsOperationCompleted == null)) {
                this.SendSmsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendSmsOperationCompleted);
            }
            this.InvokeAsync("SendSms", new object[] {
                        login_name,
                        password,
                        mobile,
                        message,
                        start_time,
                        Search_ID}, this.SendSmsOperationCompleted, userState);
        }
        
        private void OnSendSmsOperationCompleted(object arg) {
            if ((this.SendSmsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendSmsCompleted(this, new SendSmsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vcomcn.co/SendSmsGroup", RequestNamespace="http://www.vcomcn.co/", ResponseNamespace="http://www.vcomcn.co/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendSmsGroup(string login_name, string password, string mobile, string message, string start_time, string Search_ID) {
            object[] results = this.Invoke("SendSmsGroup", new object[] {
                        login_name,
                        password,
                        mobile,
                        message,
                        start_time,
                        Search_ID});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SendSmsGroupAsync(string login_name, string password, string mobile, string message, string start_time, string Search_ID) {
            this.SendSmsGroupAsync(login_name, password, mobile, message, start_time, Search_ID, null);
        }
        
        /// <remarks/>
        public void SendSmsGroupAsync(string login_name, string password, string mobile, string message, string start_time, string Search_ID, object userState) {
            if ((this.SendSmsGroupOperationCompleted == null)) {
                this.SendSmsGroupOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendSmsGroupOperationCompleted);
            }
            this.InvokeAsync("SendSmsGroup", new object[] {
                        login_name,
                        password,
                        mobile,
                        message,
                        start_time,
                        Search_ID}, this.SendSmsGroupOperationCompleted, userState);
        }
        
        private void OnSendSmsGroupOperationCompleted(object arg) {
            if ((this.SendSmsGroupCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendSmsGroupCompleted(this, new SendSmsGroupCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vcomcn.co/SendSmsGroupSpnum", RequestNamespace="http://www.vcomcn.co/", ResponseNamespace="http://www.vcomcn.co/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendSmsGroupSpnum(string login_name, string password, string mobile, string message, string start_time, string Search_ID, string spNum) {
            object[] results = this.Invoke("SendSmsGroupSpnum", new object[] {
                        login_name,
                        password,
                        mobile,
                        message,
                        start_time,
                        Search_ID,
                        spNum});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SendSmsGroupSpnumAsync(string login_name, string password, string mobile, string message, string start_time, string Search_ID, string spNum) {
            this.SendSmsGroupSpnumAsync(login_name, password, mobile, message, start_time, Search_ID, spNum, null);
        }
        
        /// <remarks/>
        public void SendSmsGroupSpnumAsync(string login_name, string password, string mobile, string message, string start_time, string Search_ID, string spNum, object userState) {
            if ((this.SendSmsGroupSpnumOperationCompleted == null)) {
                this.SendSmsGroupSpnumOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendSmsGroupSpnumOperationCompleted);
            }
            this.InvokeAsync("SendSmsGroupSpnum", new object[] {
                        login_name,
                        password,
                        mobile,
                        message,
                        start_time,
                        Search_ID,
                        spNum}, this.SendSmsGroupSpnumOperationCompleted, userState);
        }
        
        private void OnSendSmsGroupSpnumOperationCompleted(object arg) {
            if ((this.SendSmsGroupSpnumCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendSmsGroupSpnumCompleted(this, new SendSmsGroupSpnumCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vcomcn.co/GetResultbyTime", RequestNamespace="http://www.vcomcn.co/", ResponseNamespace="http://www.vcomcn.co/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetResultbyTime(string login_name, string password, string mobile, string start_time, string end_time) {
            object[] results = this.Invoke("GetResultbyTime", new object[] {
                        login_name,
                        password,
                        mobile,
                        start_time,
                        end_time});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetResultbyTimeAsync(string login_name, string password, string mobile, string start_time, string end_time) {
            this.GetResultbyTimeAsync(login_name, password, mobile, start_time, end_time, null);
        }
        
        /// <remarks/>
        public void GetResultbyTimeAsync(string login_name, string password, string mobile, string start_time, string end_time, object userState) {
            if ((this.GetResultbyTimeOperationCompleted == null)) {
                this.GetResultbyTimeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetResultbyTimeOperationCompleted);
            }
            this.InvokeAsync("GetResultbyTime", new object[] {
                        login_name,
                        password,
                        mobile,
                        start_time,
                        end_time}, this.GetResultbyTimeOperationCompleted, userState);
        }
        
        private void OnGetResultbyTimeOperationCompleted(object arg) {
            if ((this.GetResultbyTimeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetResultbyTimeCompleted(this, new GetResultbyTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vcomcn.co/GetResultbyId", RequestNamespace="http://www.vcomcn.co/", ResponseNamespace="http://www.vcomcn.co/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetResultbyId(string login_name, string password, string Search_ID) {
            object[] results = this.Invoke("GetResultbyId", new object[] {
                        login_name,
                        password,
                        Search_ID});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetResultbyIdAsync(string login_name, string password, string Search_ID) {
            this.GetResultbyIdAsync(login_name, password, Search_ID, null);
        }
        
        /// <remarks/>
        public void GetResultbyIdAsync(string login_name, string password, string Search_ID, object userState) {
            if ((this.GetResultbyIdOperationCompleted == null)) {
                this.GetResultbyIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetResultbyIdOperationCompleted);
            }
            this.InvokeAsync("GetResultbyId", new object[] {
                        login_name,
                        password,
                        Search_ID}, this.GetResultbyIdOperationCompleted, userState);
        }
        
        private void OnGetResultbyIdOperationCompleted(object arg) {
            if ((this.GetResultbyIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetResultbyIdCompleted(this, new GetResultbyIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vcomcn.co/GetSmsStateReport", RequestNamespace="http://www.vcomcn.co/", ResponseNamespace="http://www.vcomcn.co/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetSmsStateReport(string login_name, string password) {
            object[] results = this.Invoke("GetSmsStateReport", new object[] {
                        login_name,
                        password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetSmsStateReportAsync(string login_name, string password) {
            this.GetSmsStateReportAsync(login_name, password, null);
        }
        
        /// <remarks/>
        public void GetSmsStateReportAsync(string login_name, string password, object userState) {
            if ((this.GetSmsStateReportOperationCompleted == null)) {
                this.GetSmsStateReportOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSmsStateReportOperationCompleted);
            }
            this.InvokeAsync("GetSmsStateReport", new object[] {
                        login_name,
                        password}, this.GetSmsStateReportOperationCompleted, userState);
        }
        
        private void OnGetSmsStateReportOperationCompleted(object arg) {
            if ((this.GetSmsStateReportCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSmsStateReportCompleted(this, new GetSmsStateReportCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vcomcn.co/GetSmsResp", RequestNamespace="http://www.vcomcn.co/", ResponseNamespace="http://www.vcomcn.co/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetSmsResp(string login_name, string password) {
            object[] results = this.Invoke("GetSmsResp", new object[] {
                        login_name,
                        password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetSmsRespAsync(string login_name, string password) {
            this.GetSmsRespAsync(login_name, password, null);
        }
        
        /// <remarks/>
        public void GetSmsRespAsync(string login_name, string password, object userState) {
            if ((this.GetSmsRespOperationCompleted == null)) {
                this.GetSmsRespOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSmsRespOperationCompleted);
            }
            this.InvokeAsync("GetSmsResp", new object[] {
                        login_name,
                        password}, this.GetSmsRespOperationCompleted, userState);
        }
        
        private void OnGetSmsRespOperationCompleted(object arg) {
            if ((this.GetSmsRespCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSmsRespCompleted(this, new GetSmsRespCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetBalanceCompletedEventHandler(object sender, GetBalanceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetBalanceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBalanceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void SendSmsCompletedEventHandler(object sender, SendSmsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendSmsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendSmsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void SendSmsGroupCompletedEventHandler(object sender, SendSmsGroupCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendSmsGroupCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendSmsGroupCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void SendSmsGroupSpnumCompletedEventHandler(object sender, SendSmsGroupSpnumCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendSmsGroupSpnumCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendSmsGroupSpnumCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetResultbyTimeCompletedEventHandler(object sender, GetResultbyTimeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetResultbyTimeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetResultbyTimeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetResultbyIdCompletedEventHandler(object sender, GetResultbyIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetResultbyIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetResultbyIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetSmsStateReportCompletedEventHandler(object sender, GetSmsStateReportCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSmsStateReportCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSmsStateReportCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetSmsRespCompletedEventHandler(object sender, GetSmsRespCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSmsRespCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSmsRespCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591