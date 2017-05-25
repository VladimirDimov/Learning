namespace RouteHandlerDemo.RouteHandlers
{
    using System.Xml.Serialization;

    public class PingResult
    {
        [XmlElement]
        public string ApplicationName { get; set; }

        [XmlElement]
        public string Version { get; set; }
    }
}