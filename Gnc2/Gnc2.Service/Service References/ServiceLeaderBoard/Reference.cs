﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gnc2.Service.ServiceLeaderBoard {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LeaderListRequest", Namespace="http://schemas.datacontract.org/2004/07/w2.Ws")]
    [System.SerializableAttribute()]
    public partial class LeaderListRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TotalCountField;
        
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
        public int TotalCount {
            get {
                return this.TotalCountField;
            }
            set {
                if ((this.TotalCountField.Equals(value) != true)) {
                    this.TotalCountField = value;
                    this.RaisePropertyChanged("TotalCount");
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
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Gnc2.Service.ServiceLeaderBoard.BaseWsModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Gnc2.Service.ServiceLeaderBoard.LeaderListModel))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseWsModel", Namespace="http://schemas.datacontract.org/2004/07/w2.Ws.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Gnc2.Service.ServiceLeaderBoard.LeaderListModel))]
    public partial class BaseWsModel : Gnc2.Service.ServiceLeaderBoard.BaseResponse {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LeaderListModel", Namespace="http://schemas.datacontract.org/2004/07/w2.Ws")]
    [System.SerializableAttribute()]
    public partial class LeaderListModel : Gnc2.Service.ServiceLeaderBoard.BaseWsModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Gnc2.Service.ServiceLeaderBoard.LeaderModel[] LeadersField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Gnc2.Service.ServiceLeaderBoard.LeaderModel[] Leaders {
            get {
                return this.LeadersField;
            }
            set {
                if ((object.ReferenceEquals(this.LeadersField, value) != true)) {
                    this.LeadersField = value;
                    this.RaisePropertyChanged("Leaders");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LeaderModel", Namespace="http://schemas.datacontract.org/2004/07/w2.Ws")]
    [System.SerializableAttribute()]
    public partial class LeaderModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PictureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PointField;
        
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
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Picture {
            get {
                return this.PictureField;
            }
            set {
                if ((object.ReferenceEquals(this.PictureField, value) != true)) {
                    this.PictureField = value;
                    this.RaisePropertyChanged("Picture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Point {
            get {
                return this.PointField;
            }
            set {
                if ((this.PointField.Equals(value) != true)) {
                    this.PointField = value;
                    this.RaisePropertyChanged("Point");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="UserRankRequest", Namespace="http://schemas.datacontract.org/2004/07/w2.Ws")]
    [System.SerializableAttribute()]
    public partial class UserRankRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceLeaderBoard.ILeaderBoard")]
    public interface ILeaderBoard {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILeaderBoard/TopN", ReplyAction="http://tempuri.org/ILeaderBoard/TopNResponse")]
        Gnc2.Service.ServiceLeaderBoard.LeaderListModel TopN(Gnc2.Service.ServiceLeaderBoard.LeaderListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILeaderBoard/TopN", ReplyAction="http://tempuri.org/ILeaderBoard/TopNResponse")]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceLeaderBoard.LeaderListModel> TopNAsync(Gnc2.Service.ServiceLeaderBoard.LeaderListRequest request);
        
        // CODEGEN: Generating message contract since the wrapper name (Json_x002F_TopN) of message Json_x002F_TopNRequest does not match the default value (JsonTopN)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILeaderBoard/Json/TopN", ReplyAction="http://tempuri.org/ILeaderBoard/Json/TopNResponse")]
        Gnc2.Service.ServiceLeaderBoard.JsonTopNResponse JsonTopN(Gnc2.Service.ServiceLeaderBoard.JsonTopNRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILeaderBoard/Json/TopN", ReplyAction="http://tempuri.org/ILeaderBoard/Json/TopNResponse")]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceLeaderBoard.JsonTopNResponse> JsonTopNAsync(Gnc2.Service.ServiceLeaderBoard.JsonTopNRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILeaderBoard/GetUserRank", ReplyAction="http://tempuri.org/ILeaderBoard/GetUserRankResponse")]
        Gnc2.Service.ServiceLeaderBoard.LeaderListModel GetUserRank(Gnc2.Service.ServiceLeaderBoard.UserRankRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILeaderBoard/GetUserRank", ReplyAction="http://tempuri.org/ILeaderBoard/GetUserRankResponse")]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceLeaderBoard.LeaderListModel> GetUserRankAsync(Gnc2.Service.ServiceLeaderBoard.UserRankRequest request);
        
        // CODEGEN: Generating message contract since the wrapper name (Json_x002F_GetUserRank) of message Json_x002F_GetUserRankRequest does not match the default value (JsonGetUserRank)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILeaderBoard/Json/GetUserRank", ReplyAction="http://tempuri.org/ILeaderBoard/Json/GetUserRankResponse")]
        Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankResponse JsonGetUserRank(Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILeaderBoard/Json/GetUserRank", ReplyAction="http://tempuri.org/ILeaderBoard/Json/GetUserRankResponse")]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankResponse> JsonGetUserRankAsync(Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Json/TopN", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class JsonTopNRequest {
        
        public JsonTopNRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Json/TopNResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class JsonTopNResponse {
        
        public JsonTopNResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Json/GetUserRank", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class JsonGetUserRankRequest {
        
        public JsonGetUserRankRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Json/GetUserRankResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class JsonGetUserRankResponse {
        
        public JsonGetUserRankResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILeaderBoardChannel : Gnc2.Service.ServiceLeaderBoard.ILeaderBoard, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LeaderBoardClient : System.ServiceModel.ClientBase<Gnc2.Service.ServiceLeaderBoard.ILeaderBoard>, Gnc2.Service.ServiceLeaderBoard.ILeaderBoard {
        
        public LeaderBoardClient() {
        }
        
        public LeaderBoardClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LeaderBoardClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LeaderBoardClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LeaderBoardClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Gnc2.Service.ServiceLeaderBoard.LeaderListModel TopN(Gnc2.Service.ServiceLeaderBoard.LeaderListRequest request) {
            return base.Channel.TopN(request);
        }
        
        public System.Threading.Tasks.Task<Gnc2.Service.ServiceLeaderBoard.LeaderListModel> TopNAsync(Gnc2.Service.ServiceLeaderBoard.LeaderListRequest request) {
            return base.Channel.TopNAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Gnc2.Service.ServiceLeaderBoard.JsonTopNResponse Gnc2.Service.ServiceLeaderBoard.ILeaderBoard.JsonTopN(Gnc2.Service.ServiceLeaderBoard.JsonTopNRequest request) {
            return base.Channel.JsonTopN(request);
        }
        
        public void JsonTopN() {
            Gnc2.Service.ServiceLeaderBoard.JsonTopNRequest inValue = new Gnc2.Service.ServiceLeaderBoard.JsonTopNRequest();
            Gnc2.Service.ServiceLeaderBoard.JsonTopNResponse retVal = ((Gnc2.Service.ServiceLeaderBoard.ILeaderBoard)(this)).JsonTopN(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceLeaderBoard.JsonTopNResponse> Gnc2.Service.ServiceLeaderBoard.ILeaderBoard.JsonTopNAsync(Gnc2.Service.ServiceLeaderBoard.JsonTopNRequest request) {
            return base.Channel.JsonTopNAsync(request);
        }
        
        public System.Threading.Tasks.Task<Gnc2.Service.ServiceLeaderBoard.JsonTopNResponse> JsonTopNAsync() {
            Gnc2.Service.ServiceLeaderBoard.JsonTopNRequest inValue = new Gnc2.Service.ServiceLeaderBoard.JsonTopNRequest();
            return ((Gnc2.Service.ServiceLeaderBoard.ILeaderBoard)(this)).JsonTopNAsync(inValue);
        }
        
        public Gnc2.Service.ServiceLeaderBoard.LeaderListModel GetUserRank(Gnc2.Service.ServiceLeaderBoard.UserRankRequest request) {
            return base.Channel.GetUserRank(request);
        }
        
        public System.Threading.Tasks.Task<Gnc2.Service.ServiceLeaderBoard.LeaderListModel> GetUserRankAsync(Gnc2.Service.ServiceLeaderBoard.UserRankRequest request) {
            return base.Channel.GetUserRankAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankResponse Gnc2.Service.ServiceLeaderBoard.ILeaderBoard.JsonGetUserRank(Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankRequest request) {
            return base.Channel.JsonGetUserRank(request);
        }
        
        public void JsonGetUserRank() {
            Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankRequest inValue = new Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankRequest();
            Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankResponse retVal = ((Gnc2.Service.ServiceLeaderBoard.ILeaderBoard)(this)).JsonGetUserRank(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankResponse> Gnc2.Service.ServiceLeaderBoard.ILeaderBoard.JsonGetUserRankAsync(Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankRequest request) {
            return base.Channel.JsonGetUserRankAsync(request);
        }
        
        public System.Threading.Tasks.Task<Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankResponse> JsonGetUserRankAsync() {
            Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankRequest inValue = new Gnc2.Service.ServiceLeaderBoard.JsonGetUserRankRequest();
            return ((Gnc2.Service.ServiceLeaderBoard.ILeaderBoard)(this)).JsonGetUserRankAsync(inValue);
        }
    }
}
