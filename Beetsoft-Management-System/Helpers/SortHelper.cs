using System.Text;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Beetsoft_Management_System.Helpers
{
    public class SortHelper<T> : ISortHelper<T>
    {
        public IQueryable<T> AppySort(IQueryable<T> entities, string orderByQueryString)
        {
            if(!entities.Any())
            {
                return entities;
            }
            if(string.IsNullOrEmpty(orderByQueryString))
            {
                return entities;
            }

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if(string.IsNullOrEmpty(param)) continue;
                
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName));

                if(objectProperty == null)
                {
                    continue;
                }

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            return entities.OrderBy(orderQuery);
        }

       
    }
}