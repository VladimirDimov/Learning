namespace WcfApp
{
    using System.Collections.Generic;
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
        [WebGet]
        IEnumerable<PersonModel> Get(int id);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class PersonModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }
    }
}
