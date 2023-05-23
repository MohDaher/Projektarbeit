//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.CloudCode.Internal.Http;



namespace Unity.Services.CloudCode.Internal.Models
{
    /// <summary>
    /// AxiosInvocationErrorResponseResponse model
    /// </summary>
    [Preserve]
    [DataContract(Name = "AxiosInvocationErrorResponse_response")]
    internal class AxiosInvocationErrorResponseResponse
    {
        /// <summary>
        /// Creates an instance of AxiosInvocationErrorResponseResponse.
        /// </summary>
        /// <param name="type">type param</param>
        /// <param name="title">title param</param>
        /// <param name="status">status param</param>
        /// <param name="code">code param</param>
        /// <param name="detail">detail param</param>
        /// <param name="requestId">requestId param</param>
        [Preserve]
        public AxiosInvocationErrorResponseResponse(string type = default, string title = default, decimal status = default, decimal code = default, string detail = default, string requestId = default)
        {
            Type = type;
            Title = title;
            Status = status;
            Code = code;
            Detail = detail;
            RequestId = requestId;
        }

        /// <summary>
        /// Parameter type of AxiosInvocationErrorResponseResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type{ get; }
        
        /// <summary>
        /// Parameter title of AxiosInvocationErrorResponseResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title{ get; }
        
        /// <summary>
        /// Parameter status of AxiosInvocationErrorResponseResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public decimal Status{ get; }
        
        /// <summary>
        /// Parameter code of AxiosInvocationErrorResponseResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public decimal Code{ get; }
        
        /// <summary>
        /// Parameter detail of AxiosInvocationErrorResponseResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "detail", EmitDefaultValue = false)]
        public string Detail{ get; }
        
        /// <summary>
        /// Parameter requestId of AxiosInvocationErrorResponseResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "requestId", EmitDefaultValue = false)]
        public string RequestId{ get; }
    
        /// <summary>
        /// Formats a AxiosInvocationErrorResponseResponse into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Type != null)
            {
                serializedModel += "type," + Type + ",";
            }
            if (Title != null)
            {
                serializedModel += "title," + Title + ",";
            }
            serializedModel += "status," + Status.ToString() + ",";
            serializedModel += "code," + Code.ToString() + ",";
            if (Detail != null)
            {
                serializedModel += "detail," + Detail + ",";
            }
            if (RequestId != null)
            {
                serializedModel += "requestId," + RequestId;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a AxiosInvocationErrorResponseResponse as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Type != null)
            {
                var typeStringValue = Type.ToString();
                dictionary.Add("type", typeStringValue);
            }
            
            if (Title != null)
            {
                var titleStringValue = Title.ToString();
                dictionary.Add("title", titleStringValue);
            }
            
            var statusStringValue = Status.ToString();
            dictionary.Add("status", statusStringValue);
            
            var codeStringValue = Code.ToString();
            dictionary.Add("code", codeStringValue);
            
            if (Detail != null)
            {
                var detailStringValue = Detail.ToString();
                dictionary.Add("detail", detailStringValue);
            }
            
            if (RequestId != null)
            {
                var requestIdStringValue = RequestId.ToString();
                dictionary.Add("requestId", requestIdStringValue);
            }
            
            return dictionary;
        }
    }
}
