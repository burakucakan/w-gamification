﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gnc2.Service.ServiceSiteActivity {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NotifyUserLogin", Namespace="http://schemas.datacontract.org/2004/07/w2.Service.Gigya.Socialize.CustomModels")]
    [System.SerializableAttribute()]
    public partial class NotifyUserLogin : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MsisdnField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cid {
            get {
                return this.CidField;
            }
            set {
                if ((object.ReferenceEquals(this.CidField, value) != true)) {
                    this.CidField = value;
                    this.RaisePropertyChanged("Cid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key {
            get {
                return this.KeyField;
            }
            set {
                if ((object.ReferenceEquals(this.KeyField, value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Msisdn {
            get {
                return this.MsisdnField;
            }
            set {
                if ((object.ReferenceEquals(this.MsisdnField, value) != true)) {
                    this.MsisdnField = value;
                    this.RaisePropertyChanged("Msisdn");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseResponse", Namespace="http://schemas.datacontract.org/2004/07/w2.Service.Gigya")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Gnc2.Service.ServiceSiteActivity.NotifyUserLoginResponse))]
    public partial class BaseResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CallIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ErrorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CallId {
            get {
                return this.CallIdField;
            }
            set {
                if ((object.ReferenceEquals(this.CallIdField, value) != true)) {
                    this.CallIdField = value;
                    this.RaisePropertyChanged("CallId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ErrorCode {
            get {
                return this.ErrorCodeField;
            }
            set {
                if ((this.ErrorCodeField.Equals(value) != true)) {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NotifyUserLoginResponse", Namespace="http://schemas.datacontract.org/2004/07/w2.Service.Gigya.Socialize.CustomModels")]
    [System.SerializableAttribute()]
    public partial class NotifyUserLoginResponse : Gnc2.Service.ServiceSiteActivity.BaseResponse {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MsisdnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SignatureTimestampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UIDSignatureField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Msisdn {
            get {
                return this.MsisdnField;
            }
            set {
                if ((object.ReferenceEquals(this.MsisdnField, value) != true)) {
                    this.MsisdnField = value;
                    this.RaisePropertyChanged("Msisdn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SignatureTimestamp {
            get {
                return this.SignatureTimestampField;
            }
            set {
                if ((object.ReferenceEquals(this.SignatureTimestampField, value) != true)) {
                    this.SignatureTimestampField = value;
                    this.RaisePropertyChanged("SignatureTimestamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UID {
            get {
                return this.UIDField;
            }
            set {
                if ((object.ReferenceEquals(this.UIDField, value) != true)) {
                    this.UIDField = value;
                    this.RaisePropertyChanged("UID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UIDSignature {
            get {
                return this.UIDSignatureField;
            }
            set {
                if ((object.ReferenceEquals(this.UIDSignatureField, value) != true)) {
                    this.UIDSignatureField = value;
                    this.RaisePropertyChanged("UIDSignature");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceSiteActivity.ISiteActivity")]
    public interface ISiteActivity {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISiteActivity/SiteLogin", ReplyAction="http://tempuri.org/ISiteActivity/SiteLoginResponse")]
        Gnc2.Service.ServiceSiteActivity.NotifyUserLoginResponse SiteLogin(Gnc2.Service.ServiceSiteActivity.NotifyUserLogin userInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISiteActivity/SiteLogin", ReplyAction="http://tempuri.org/ISiteActivity/SiteLoginResponse")]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceSiteActivity.NotifyUserLoginResponse> SiteLoginAsync(Gnc2.Service.ServiceSiteActivity.NotifyUserLogin userInfo);
        
        // CODEGEN: Generating message contract since the wrapper name (Json_x002F_SiteLogin) of message Json_x002F_SiteLoginRequest does not match the default value (JsonSiteLogin)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISiteActivity/Json/SiteLogin", ReplyAction="http://tempuri.org/ISiteActivity/Json/SiteLoginResponse")]
        Gnc2.Service.ServiceSiteActivity.JsonSiteLoginResponse JsonSiteLogin(Gnc2.Service.ServiceSiteActivity.JsonSiteLoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISiteActivity/Json/SiteLogin", ReplyAction="http://tempuri.org/ISiteActivity/Json/SiteLoginResponse")]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceSiteActivity.JsonSiteLoginResponse> JsonSiteLoginAsync(Gnc2.Service.ServiceSiteActivity.JsonSiteLoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISiteActivity/SiteRegister", ReplyAction="http://tempuri.org/ISiteActivity/SiteRegisterResponse")]
        Gnc2.Service.ServiceSiteActivity.NotifyUserLoginResponse SiteRegister(Gnc2.Service.ServiceSiteActivity.NotifyUserLogin userInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISiteActivity/SiteRegister", ReplyAction="http://tempuri.org/ISiteActivity/SiteRegisterResponse")]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceSiteActivity.NotifyUserLoginResponse> SiteRegisterAsync(Gnc2.Service.ServiceSiteActivity.NotifyUserLogin userInfo);
        
        // CODEGEN: Generating message contract since the wrapper name (Json_x002F_SiteRegister) of message Json_x002F_SiteRegisterRequest does not match the default value (JsonSiteRegister)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISiteActivity/Json/SiteRegister", ReplyAction="http://tempuri.org/ISiteActivity/Json/SiteRegisterResponse")]
        Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterResponse JsonSiteRegister(Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISiteActivity/Json/SiteRegister", ReplyAction="http://tempuri.org/ISiteActivity/Json/SiteRegisterResponse")]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterResponse> JsonSiteRegisterAsync(Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Json/SiteLogin", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class JsonSiteLoginRequest {
        
        public JsonSiteLoginRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Json/SiteLoginResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class JsonSiteLoginResponse {
        
        public JsonSiteLoginResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Json/SiteRegister", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class JsonSiteRegisterRequest {
        
        public JsonSiteRegisterRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Json/SiteRegisterResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class JsonSiteRegisterResponse {
        
        public JsonSiteRegisterResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISiteActivityChannel : Gnc2.Service.ServiceSiteActivity.ISiteActivity, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SiteActivityClient : System.ServiceModel.ClientBase<Gnc2.Service.ServiceSiteActivity.ISiteActivity>, Gnc2.Service.ServiceSiteActivity.ISiteActivity {
        
        public SiteActivityClient() {
        }
        
        public SiteActivityClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SiteActivityClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SiteActivityClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SiteActivityClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Gnc2.Service.ServiceSiteActivity.NotifyUserLoginResponse SiteLogin(Gnc2.Service.ServiceSiteActivity.NotifyUserLogin userInfo) {
            return base.Channel.SiteLogin(userInfo);
        }
        
        public System.Threading.Tasks.Task<Gnc2.Service.ServiceSiteActivity.NotifyUserLoginResponse> SiteLoginAsync(Gnc2.Service.ServiceSiteActivity.NotifyUserLogin userInfo) {
            return base.Channel.SiteLoginAsync(userInfo);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Gnc2.Service.ServiceSiteActivity.JsonSiteLoginResponse Gnc2.Service.ServiceSiteActivity.ISiteActivity.JsonSiteLogin(Gnc2.Service.ServiceSiteActivity.JsonSiteLoginRequest request) {
            return base.Channel.JsonSiteLogin(request);
        }
        
        public void JsonSiteLogin() {
            Gnc2.Service.ServiceSiteActivity.JsonSiteLoginRequest inValue = new Gnc2.Service.ServiceSiteActivity.JsonSiteLoginRequest();
            Gnc2.Service.ServiceSiteActivity.JsonSiteLoginResponse retVal = ((Gnc2.Service.ServiceSiteActivity.ISiteActivity)(this)).JsonSiteLogin(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceSiteActivity.JsonSiteLoginResponse> Gnc2.Service.ServiceSiteActivity.ISiteActivity.JsonSiteLoginAsync(Gnc2.Service.ServiceSiteActivity.JsonSiteLoginRequest request) {
            return base.Channel.JsonSiteLoginAsync(request);
        }
        
        public System.Threading.Tasks.Task<Gnc2.Service.ServiceSiteActivity.JsonSiteLoginResponse> JsonSiteLoginAsync() {
            Gnc2.Service.ServiceSiteActivity.JsonSiteLoginRequest inValue = new Gnc2.Service.ServiceSiteActivity.JsonSiteLoginRequest();
            return ((Gnc2.Service.ServiceSiteActivity.ISiteActivity)(this)).JsonSiteLoginAsync(inValue);
        }
        
        public Gnc2.Service.ServiceSiteActivity.NotifyUserLoginResponse SiteRegister(Gnc2.Service.ServiceSiteActivity.NotifyUserLogin userInfo) {
            return base.Channel.SiteRegister(userInfo);
        }
        
        public System.Threading.Tasks.Task<Gnc2.Service.ServiceSiteActivity.NotifyUserLoginResponse> SiteRegisterAsync(Gnc2.Service.ServiceSiteActivity.NotifyUserLogin userInfo) {
            return base.Channel.SiteRegisterAsync(userInfo);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterResponse Gnc2.Service.ServiceSiteActivity.ISiteActivity.JsonSiteRegister(Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterRequest request) {
            return base.Channel.JsonSiteRegister(request);
        }
        
        public void JsonSiteRegister() {
            Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterRequest inValue = new Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterRequest();
            Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterResponse retVal = ((Gnc2.Service.ServiceSiteActivity.ISiteActivity)(this)).JsonSiteRegister(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterResponse> Gnc2.Service.ServiceSiteActivity.ISiteActivity.JsonSiteRegisterAsync(Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterRequest request) {
            return base.Channel.JsonSiteRegisterAsync(request);
        }
        
        public System.Threading.Tasks.Task<Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterResponse> JsonSiteRegisterAsync() {
            Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterRequest inValue = new Gnc2.Service.ServiceSiteActivity.JsonSiteRegisterRequest();
            return ((Gnc2.Service.ServiceSiteActivity.ISiteActivity)(this)).JsonSiteRegisterAsync(inValue);
        }
    }
}
