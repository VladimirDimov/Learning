using System.ServiceModel;

namespace WcfApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        decimal GetDataUsingDataContract(decimal a, decimal b);

        // TODO: Add your service operations here
    }
}