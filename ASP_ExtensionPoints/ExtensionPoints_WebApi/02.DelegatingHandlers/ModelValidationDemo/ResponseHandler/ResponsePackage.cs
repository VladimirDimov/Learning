namespace ModelValidationDemo.ResponseHandler
{
    using System.Collections.Generic;

    public class ResponsePackage
    {
        public List<string> Errors { get; set; }

        public object Result { get; set; }
    }
}