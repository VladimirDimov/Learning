namespace JQDT.DataProcessing
{
    using JQDT.Models;
    using System.Linq;

    internal class PagingDataProcessor : IDataProcess
    {
        public IQueryable<object> ProcessedData { get; set; }

        public IQueryable<object> ProcessData(IQueryable<object> data, DataTableAjaxPostModel filterModel)
        {
            var pagedData = data
                .Skip(filterModel.start)
                .Take(filterModel.length);

            return pagedData;
        }
    }
}