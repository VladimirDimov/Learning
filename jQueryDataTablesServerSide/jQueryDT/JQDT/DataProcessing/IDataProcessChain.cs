using System.Collections;
using System.Collections.Generic;

namespace JQDT.DataProcessing
{
    internal interface IDataProcessChain
    {
        IEnumerable<IDataProcess> DataProcessors { get; }

        void AddDataProcessor(IDataProcess dataProcessor);
    }
}