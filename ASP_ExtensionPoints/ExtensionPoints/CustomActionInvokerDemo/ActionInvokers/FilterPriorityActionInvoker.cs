namespace CustomActionInvokerDemo.ActionInvokers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Filters;

    public class FilterPriorityActionInvoker : ControllerActionInvoker
    {
        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);

            return filters;
        }

        protected override ActionExecutedContext InvokeActionMethodWithFilters(
            ControllerContext controllerContext,
            IList<IActionFilter> filters,
            ActionDescriptor actionDescriptor,
            IDictionary<string, object> parameters)
        {
            var prioritizedFilters = this.GetPrioritizedFilters(filters);

            return base.InvokeActionMethodWithFilters(controllerContext, prioritizedFilters, actionDescriptor, parameters);
        }

        /// <summary>
        /// Moves the filters which inherrit from <see cref="IProprityFilter"/> on the top of the filters collection.
        /// Keeps the other filters order.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <returns>Collection with prioritized filters</returns>
        private IList<IActionFilter> GetPrioritizedFilters(IList<IActionFilter> filters)
        {
            var priorityFilters = new List<IActionFilter>(filters.Count);
            var noProprityFilters = new List<IActionFilter>(filters.Count);

            foreach (var filter in filters)
            {
                if (filter is IProprityFilter)
                {
                    priorityFilters.Add(filter);
                }
                else
                {
                    noProprityFilters.Add(filter);
                }
            }

            var prioritizedFilters = priorityFilters.Concat(noProprityFilters).ToList();

            return prioritizedFilters;
        }
    }
}