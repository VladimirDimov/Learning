using System.Web.OData.Builder;

namespace Employees.ODataConfiguration
{

    public interface IHaveCustomODataConfiguration
    {
        void CustomODataConfiguration(ODataModelBuilder builder);
    }
}