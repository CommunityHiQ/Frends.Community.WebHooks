#pragma warning disable 1591

using System.ComponentModel.DataAnnotations;

namespace Frends.Community.WebHooks
{

    public class WebHookAttributes
    {
        public WebHookBasicInformation WebHookBasicInformation { get; set; }
        public WebHookAttributeDescription[] WebHookAttributeDescription { get; set; }
    }

    /// <summary>
    /// Specify domain object such as "Customer" or "Order".
    /// </summary>
    public class WebHookBasicInformation
    {
        /// <summary>
        /// Specify domain object such as "Customer" or "Order".
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Domain { get; set; }
        
        /// <summary>
        /// Application which has the main functionality of using specific domain objects.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string App { get; set; }
        
        /// <summary>
        /// Description about the appliance.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Description { get; set; }
        
        /// <summary>
        /// Content based routing.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Endpoint { get; set; }

        /// <summary>
        /// Content type such as application/json.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string ContentType { get; set; }

        /// <summary>
        /// Server timestamp when web hook is created.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public long ServerTimestamp { get; set; }
        
        /// <summary>
        /// Server GUID when web hook is created.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string ServerGuid { get; set; }
        
        /// <summary>
        /// Unique id which is correlated with the webhook form submission
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string CorrelationId { get; set; }
        public string DeviceId { get; set; }
        
        /// <summary>
        /// Information about the tenant
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Tenant { get; set; }
        
        /// <summary>
        /// Synchroinizer token which is calculated from form sub mission attributes in addition to server GUID, Device Id and correlation id
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string SynchronizerToken { get; set; }
        
    }

    /// <summary>
    /// Web hook contains several attributes, which could be sent by using form submission.
    /// </summary>
    public class WebHookAttributeDescription
    {
        /// <summary>
        /// Dom information about the attribute position in layout.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string DomTreeId { get; set; }

        /// <summary>
        /// Field type describes the information about the field.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string FieldType { get; set; }
        
        /// <summary>
        /// Format which describes the outlook of the field content.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Format { get; set; }
        
        /// <summary>
        /// select options.
        /// </summary>
        /// [DisplayFormat(DataFormatString = "Text")]
        public enum InputType
        {
            TEXT_INPUT, TEXT_AREA, SELECT, CHECK_BOX, DATE_PICKER
        }

        public string[] FieldOptions { get; set; }
        
        /// <summary>
        /// Validation pattern for a spcecic input.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string ValidationPattern { get; set; }
        
        /// <summary>
        /// Name of the input field.V
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Name { get; set; }

        /// <summary>
        /// Value of the input field.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Value { get; set; }
        
        /// <summary>
        /// Base 64 encoding of the value field.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public bool Base64 { get; set; }

        /// <summary>
        /// Crypt the chosen field value.
        /// </summary>
        public bool Crypt { get; set; }

        /// <summary>
        /// Algorithm to be used with the field value.
        /// </summary>
        public bool Algorithm { get; set; }
        
        /// <summary>
        /// Server URL which hides the original platform address.
        /// </summary>
        public bool UseTinyUrl { get; set; }

    }

    /// <summary>
    /// Options class provides additional optional parameters for setting metadata for the web hook.
    /// </summary>
    public class Options
    {    
        /// <summary>
        /// Unique device id.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string DeviceId { get; set; }

        /// <summary>
        /// Maximum latency when sending information in to the backend API. System must response in given time frame.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public int MaximumLatency { get; set; }
        
        /// <summary>
        /// Messaging version which can be used for routing.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string MessageVersion { get; set; }
        
    }

    public class Result
    {
        /// <summary>
        /// Result data generated by the webhook task.
        /// </summary>
        public string Data;
        
        /// <summary>
        /// Array of specific attribute metadata to be utilized by the client webhook handler.
        /// </summary>
        public WebHookAttributeDescription[] WebHookAttributeDescription { get; set; }
        
    }
    
}
