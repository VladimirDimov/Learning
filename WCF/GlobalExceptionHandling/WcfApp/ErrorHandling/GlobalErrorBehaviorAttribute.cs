namespace WcfApp.ErrorHandling
{
    using System;
    using System.Collections.ObjectModel;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    public class GlobalErrorBehaviorAttribute : Attribute, IServiceBehavior

    {
        private Type errorHandlerType;

        public GlobalErrorBehaviorAttribute(Type errorHandlerType)

        {
            this.errorHandlerType = errorHandlerType;
        }

        public void Validate(ServiceDescription description, ServiceHostBase serviceHostBase)

        {
        }

        public void AddBindingParameters(ServiceDescription description, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection parameters)

        {
        }

        public void ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)

        {
            var errorHandler = (IErrorHandler)Activator.CreateInstance(errorHandlerType);

            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)

            {
                ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;

                channelDispatcher.ErrorHandlers.Add(errorHandler);
            }
        }
    }
}