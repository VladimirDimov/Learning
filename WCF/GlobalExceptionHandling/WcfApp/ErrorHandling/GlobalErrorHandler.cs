namespace WcfApp.ErrorHandling
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    public class GlobalErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            // Specific rules may be added;
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            var newEx = new FaultException(string.Format("Exception caught at Service Application GlobalErrorHandler{0}Method: {1}{2}Message: {3}",
                Environment.NewLine, error.TargetSite.Name,
                Environment.NewLine, error.Message));

            MessageFault msgFault = newEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, newEx.Action);
        }
    }
}