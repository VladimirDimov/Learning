namespace ControllerTypeResolverDemo.App_Start
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    public class MyControllerTypeResolver : DefaultHttpControllerTypeResolver
    {
        public MyControllerTypeResolver(Type baseControllertype)
            : base(
                  type =>
                    {
                        // No problem to use reflection because this logic is cached!

                        var meetCommonRequirements =
                        type.IsClass &
                        type.IsVisible &
                        !type.IsAbstract &
                        type.Name.ToLower().EndsWith("controller");

                        var baseType = baseControllertype ?? typeof(ApiController);
                        var isController = baseType.IsAssignableFrom(type);

#if DEBUG
                        if (meetCommonRequirements && !isController && !type.Assembly.FullName.StartsWith("System."))
                        {
                            throw new TypeAccessException($"The controller {type.Name}  does not inherrit the {baseControllertype.FullName}");
                        }
#endif

                        return meetCommonRequirements && isController;
                    })
        {
        }
    }
}