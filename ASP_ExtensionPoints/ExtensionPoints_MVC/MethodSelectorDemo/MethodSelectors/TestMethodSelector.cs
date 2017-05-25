namespace MethodSelectorDemo.ActionInvokers
{
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    public class OverloadSelector : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            var methodArguments = methodInfo.GetParameters().Select(x => new { Name = x.Name, Type = x.ParameterType }).ToList();
            var queryParameters = controllerContext.HttpContext.Request.QueryString.AllKeys;

            if (queryParameters.Length != methodArguments.Count)
            {
                return false;
            }

            foreach (var item in queryParameters)
            {
                if (!methodArguments.Any(x => x.Name == item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}