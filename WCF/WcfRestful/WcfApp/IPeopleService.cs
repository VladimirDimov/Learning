﻿namespace WcfApp
{
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface IPeopleService
    {
        [OperationContract]
        //[WebInvoke(
        //    Method = "Get",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Wrapped,
        //    UriTemplate = "api/{id}")]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "getbyid/{id}")]
        PersonModel GetById(string id);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class PersonModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        public int Id { get; set; }
    }
}