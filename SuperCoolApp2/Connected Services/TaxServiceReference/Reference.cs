﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaxServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="YourTaxDetails", Namespace="http://schemas.datacontract.org/2004/07/TaxCalculator")]
    public partial class YourTaxDetails : object
    {
        
        private string TimePeriodField;
        
        private decimal EarningsField;
        
        private decimal RaContribField;
        
        private short AgeInYearsField;
        
        private TaxServiceReference.MedicalDetails MedicalField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TimePeriod
        {
            get
            {
                return this.TimePeriodField;
            }
            set
            {
                this.TimePeriodField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public decimal Earnings
        {
            get
            {
                return this.EarningsField;
            }
            set
            {
                this.EarningsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public decimal RaContrib
        {
            get
            {
                return this.RaContribField;
            }
            set
            {
                this.RaContribField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public short AgeInYears
        {
            get
            {
                return this.AgeInYearsField;
            }
            set
            {
                this.AgeInYearsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public TaxServiceReference.MedicalDetails Medical
        {
            get
            {
                return this.MedicalField;
            }
            set
            {
                this.MedicalField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MedicalDetails", Namespace="http://schemas.datacontract.org/2004/07/TaxCalculator")]
    public partial class MedicalDetails : object
    {
        
        private short DependantsField;
        
        private bool HaveMedicalAidField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short Dependants
        {
            get
            {
                return this.DependantsField;
            }
            set
            {
                this.DependantsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool HaveMedicalAid
        {
            get
            {
                return this.HaveMedicalAidField;
            }
            set
            {
                this.HaveMedicalAidField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="YourTaxDetailsResponse", Namespace="http://schemas.datacontract.org/2004/07/TaxCalculator")]
    public partial class YourTaxDetailsResponse : object
    {
        
        private decimal TaxPayableField;
        
        private decimal TakeHomeField;
        
        private decimal TakeHomeLessRAField;
        
        private decimal EffectiveTaxRateField;
        
        private decimal TaxableIncomeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TaxPayable
        {
            get
            {
                return this.TaxPayableField;
            }
            set
            {
                this.TaxPayableField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public decimal TakeHome
        {
            get
            {
                return this.TakeHomeField;
            }
            set
            {
                this.TakeHomeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public decimal TakeHomeLessRA
        {
            get
            {
                return this.TakeHomeLessRAField;
            }
            set
            {
                this.TakeHomeLessRAField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public decimal EffectiveTaxRate
        {
            get
            {
                return this.EffectiveTaxRateField;
            }
            set
            {
                this.EffectiveTaxRateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public decimal TaxableIncome
        {
            get
            {
                return this.TaxableIncomeField;
            }
            set
            {
                this.TaxableIncomeField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TaxServiceReference.ITaxService")]
    public interface ITaxService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaxService/ShowTaxPayableAsync", ReplyAction="http://tempuri.org/ITaxService/ShowTaxPayableAsyncResponse")]
        System.Threading.Tasks.Task<TaxServiceReference.YourTaxDetailsResponse> ShowTaxPayableAsyncAsync(TaxServiceReference.YourTaxDetails details, short age, bool annual, bool medical);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public interface ITaxServiceChannel : TaxServiceReference.ITaxService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public partial class TaxServiceClient : System.ServiceModel.ClientBase<TaxServiceReference.ITaxService>, TaxServiceReference.ITaxService
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TaxServiceClient() : 
                base(TaxServiceClient.GetDefaultBinding(), TaxServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ITaxService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TaxServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(TaxServiceClient.GetBindingForEndpoint(endpointConfiguration), TaxServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TaxServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TaxServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TaxServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TaxServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TaxServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<TaxServiceReference.YourTaxDetailsResponse> ShowTaxPayableAsyncAsync(TaxServiceReference.YourTaxDetails details, short age, bool annual, bool medical)
        {
            return base.Channel.ShowTaxPayableAsyncAsync(details, age, annual, medical);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITaxService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITaxService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost/TaxCalculatorService/TaxService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return TaxServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ITaxService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return TaxServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ITaxService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ITaxService,
        }
    }
}
