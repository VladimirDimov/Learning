namespace JQDT
{
    using JQDT.DataProcessing;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Web.Mvc;

    [AttributeUsage(validOn: AttributeTargets.Method, AllowMultiple = false)]
    public class JQDataTableAttribute : ActionFilterAttribute
    {
        object model;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            IQueryable<object> data = (IQueryable<object>)filterContext.Controller.ViewData.Model;

            var filterModel = this.GetAjaxModel(filterContext);

            // Apply search
            var filteredData = CommonFilter.ProcessData(data, filterModel);

            // Apply Ordering
            var orderedData = OrderProcessor.ProcessData(filteredData, filterModel);

            // Apply paging
            var pagedData = orderedData
                .Skip(filterModel.start)
                .Take(filterModel.length);


            var jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            jsonResult.Data = new
            {
                draw = filterModel.draw,
                recordsTotal = data.Count(),
                recordsFiltered = orderedData.Count(),
                data = pagedData.ToList()
            };

            filterContext.Result = jsonResult;

            base.OnActionExecuted(filterContext);
        }

        private DataTableAjaxPostModel GetAjaxModel(ActionExecutedContext filterContext)
        {
            var controllerContext = filterContext.Controller.ControllerContext;

            var ajaxForm = ((System.Web.HttpRequestWrapper)((System.Web.HttpContextWrapper)filterContext.RequestContext.HttpContext).Request).Form;
            var lengthStr = ajaxForm["length"];

            // TODO: Throw appropriate exceptions when mandatory value is missing;
            int start = 0;
            int.TryParse(ajaxForm["start"], out start);

            int length = 0;
            int.TryParse(ajaxForm["length"], out length);

            var model = new DataTableAjaxPostModel
            {
                start = start,
                length = length,
                search = new Search
                {
                    value = ajaxForm["search[value]"]
                },
                order = this.GetOrderList(ajaxForm),
                columns = this.GetColumns(ajaxForm)
            };

            return model;
        }

        private List<Column> GetColumns(NameValueCollection ajaxForm)
        {
            const string Pattern = @"^columns\[(\d+)\]\[data\]$";
            var columns = new List<Column>();
            var colData = new SortedList<int, string>();
            foreach (var key in ajaxForm.AllKeys)
            {
                var matches = Regex.Match(key, Pattern);

                if (matches.Success)
                {
                    colData.Add(int.Parse(matches.Groups[1].Value), ajaxForm[key]);
                }
            }

            foreach (var item in colData)
            {
                columns.Add(new Column
                {
                    data = item.Value
                });
            }

            return columns;
        }

        private List<Order> GetOrderList(NameValueCollection form)
        {
            var orders = new List<Order>();
            const string DirectionPattern = @"^order\[(\d+)\]\[dir\]$";
            var colNumbers = new List<int>();
            foreach (var key in form.AllKeys)
            {
                var match = Regex.Match(key, DirectionPattern);
                if (match.Success)
                {
                    orders.Add(new Order
                    {
                        column = int.Parse(match.Groups[1].Value),
                        dir = form[key]
                    });
                }
            }

            var col = form["order[0][column]"];

            return orders;
        }
    }
}